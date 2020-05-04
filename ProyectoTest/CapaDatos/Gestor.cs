using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class Gestor
    {
        private const string cadena = "data source =.; initial catalog =TestXabierSanMartin; integrated security = true";
        private SqlConnection conexion;

        public Gestor(out string msg)
        {
            msg = "";
            conexion = new SqlConnection(cadena);

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                msg = "No se ha podido conectar con la base de datos " + ex.Message;
            }

            conexion.Close();
        }

        //Creamos esto para llamarlo despues en cada funcion
        private bool OpenConnection()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        //Lo llamamos en cada funcion para cerrar la conexión.
        private bool CloseConnection()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        //Funcion para comprobar si existe en la base de datos la categoria que nos pasen.
        private bool NoExiste(string consulta, string parametro)
        {

            int comprobarExiste = 0;

            if (OpenConnection() == true)
            {

                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@valor", parametro);
                comprobarExiste = Convert.ToInt32(cmd.ExecuteScalar());

                this.CloseConnection();

                if (comprobarExiste != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            return false;
        }

        //Funcion creada para acortar codigo y llamarla directamente al ejecutar una consulta.
        private bool HacerConsulta(string consulta, out string msg, string tipoConsulta = "", Dictionary<string, string> parametros = null)
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                if (tipoConsulta != "")
                {
                    switch (tipoConsulta)
                    {
                        case "INSERT":
                            string verga = parametros["VALUES"];
                            cmd.Parameters.AddWithValue("@VALOR", verga);
                            break;
                        case "UPDATE":
                            cmd.Parameters.AddWithValue("@VALOR1", parametros["SET"]);
                            cmd.Parameters.AddWithValue("@VALOR2", parametros["WHERE"]);
                            break;
                        case "DELETE":
                            cmd.Parameters.AddWithValue("@VALOR", parametros["WHERE"]);
                            break;
                        default:
                            break;
                    }
                }

                int comprobar = 0;

                try
                {
                    comprobar = cmd.ExecuteNonQuery();
                    if (comprobar == 0)
                    {
                        this.CloseConnection();
                        msg = "Fallo al ejecutarse";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    msg = "Se ha producido un error con la conexión pruebe otra vez o contacte con el administrador mensaje de error: " + ex.Message;
                    return false;
                }
                this.CloseConnection();
            }
            else
            {
                msg = "Error con la conexion a la base de datos";
                return false;
            }
            msg = "";
            return true;
        }

        public string AnadirCategoria(string nombreCategoria)
        {
            if (String.IsNullOrWhiteSpace(nombreCategoria))
            {
                return "El nombre de la categoría que quieres añadir no puede estar vacio.";
            }
            //Consulta para comprobar si existe la categoeria que nos pasan, despues la pasamos a la función.
            string ConsultaSiExiste = "SELECT * FROM CATEGORIAS WHERE Descripcion = @valor";


            bool resultado = NoExiste(ConsultaSiExiste, nombreCategoria);

            //Comprobamos el resultado de la función para meterlo en la base de datos o decirle que no
            if (resultado == false)
            {
                return "No se puede añadir la categoría " + nombreCategoria + " porque ya existe";
            }

            if (resultado == true)
            {
                string queryAnadirCategoria = "INSERT INTO Categorias (descripcion) VALUES(@valor)";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("VALUES", nombreCategoria);
                string msg = "";
                if (HacerConsulta(queryAnadirCategoria, out msg, "INSERT", dic) == false)
                {
                    return msg;
                }

            }

            return "Categoría añadida correctamente";
        }

        public List<Categoria> DevolverCategorias()
        {
            string queryDevolverCategorias = "SELECT * FROM CATEGORIAS";
            List<Categoria> devolverCategorias = new List<Categoria>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryDevolverCategorias, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Categoria nuevaCategoria = new Categoria();

                    nuevaCategoria.Descripcion = dataReader["Descripcion"].ToString();
                    nuevaCategoria.idCategoria = int.Parse(dataReader["IdCategoria"].ToString());

                    devolverCategorias.Add(nuevaCategoria);
                }
                dataReader.Close();
                this.CloseConnection();
                if (devolverCategorias.Count() != 0)
                {
                    return devolverCategorias;
                }
                else
                {
                    return null;
                }
            }
            else
            {

                return null;
            }
        }

        public String EliminarCategoria(int categoriaEliminar)
        {
            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = @IdCategoria))";
            int comprobar = 0;

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", categoriaEliminar);
                comprobar = Convert.ToInt32(cmd.ExecuteScalar());

                this.CloseConnection();

                if (comprobar != 0)
                {
                    return "test";
                }

            }

            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((IdCategoria) = @VALOR))";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("WHERE", categoriaEliminar.ToString());
            string msg = "";
            if (HacerConsulta(queryBorrarCategoria, out msg, "DELETE", dic) == false)
            {
                return msg;
            }
            return "Categoría eliminada correctamente";
        }

        public String ModificarCategoria(Categoria categoria, string nuevaCategoria, List<Categoria> categorias)
        {

            if (String.IsNullOrWhiteSpace(nuevaCategoria))
            {
                return "No puedes dejar la categoría que vas a modificar en blanco";
            }
            if (categoria.Descripcion.ToLower() == nuevaCategoria.ToLower())
            {
                return "No puedes ponerle el mismo nombre a la categoría.";
            }

            //Comprobamos que ese nombre que mete no sea el mismo de uno que ya existe en la BD.
            foreach (var cat in categorias)
            {
                if (cat.Descripcion.Equals(nuevaCategoria))
                {
                    return "No puede ponerle el mismo nombre que a una categoría existente";
                }
            }

            string queryModificarCategoria = "UPDATE CATEGORIAS SET Descripcion = @VALOR1 WHERE (((Descripcion) = @VALOR2))";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SET", nuevaCategoria);
            dic.Add("WHERE", categoria.Descripcion);
            string msg = "";
            if (HacerConsulta(queryModificarCategoria, out msg, "UPDATE", dic) == false)
            {
                return msg;
            }
            return "Categoría modificada correctamente";
        }


        public string EliminarTodasCategorias()
        {
            string queryEliminarCategorias = "DELETE FROM CATEGORIAS";
            string queryEliminarTest = "DELETE T FROM TEST AS T INNER JOIN CATEGORIASTESTS ON T.IDTEST = CATEGORIASTESTS.IDTEST WHERE T.IDTEST = CATEGORIASTESTS.IDTEST";
            string queryEliminarPreg = "DELETE P FROM PREGUNTAS AS P INNER JOIN TEST ON P.IDTEST = TEST.IDTEST WHERE P.IDTEST = TEST.IDTEST";
            string msg = "";
            if (HacerConsulta(queryEliminarPreg, out msg) == false)
            {
                return msg;
            }
            if (HacerConsulta(queryEliminarTest, out msg) == false)
            {
                return msg;
            }
            if (HacerConsulta(queryEliminarCategorias, out msg) == false)
            {
                return msg;
            }
            return "Todas las categorías, test y preguntas se han eliminado con exito";
        }

        public List<Test> DevolverTestAsociadoCategoria(Categoria categoriaRela)
        {
            List<Test> testAsoc = new List<Test>();
            string queryTestAsoc = "SELECT TEST.IdTest, Test.Descripcion FROM TEST INNER JOIN CATEGORIASTESTS INNER JOIN CATEGORIAS ON CATEGORIASTESTS.IDCATEGORIA = CATEGORIAS.IDCATEGORIA ON TEST.IDTEST = CATEGORIASTESTS.IDTEST  WHERE CATEGORIAS.IDCATEGORIA = @IdCategoria";

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryTestAsoc, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", categoriaRela.idCategoria);

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Test newTest = new Test();
                    newTest.idTest = int.Parse(dataReader["IdTest"].ToString());
                    newTest.Descripcion = dataReader["Descripcion"].ToString();

                    testAsoc.Add(newTest);
                }
                dataReader.Close();

                string queryPreguntasAsoc = "SELECT * FROM PREGUNTAS WHERE IdTest = @IdTest";
                foreach (var test in testAsoc)
                {
                    SqlCommand cmd2 = new SqlCommand(queryPreguntasAsoc, conexion);
                    cmd2.Parameters.AddWithValue("@IdTest", test.idTest);
                    SqlDataReader dataReader2 = cmd2.ExecuteReader();

                    while (dataReader2.Read())
                    {
                        Pregunta newPregunta = new Pregunta();
                        newPregunta.idPregunta = int.Parse(dataReader2["IdPregunta"].ToString());
                        newPregunta.idTest = int.Parse(dataReader2["IdTest"].ToString());
                        newPregunta.enunciado = dataReader2["Enunciado"].ToString();
                        newPregunta.respV = bool.Parse(dataReader2["RespV"].ToString());

                        test.preguntasTest.Add(newPregunta);
                    }
                    dataReader2.Close();

                }
                this.conexion.Close();

                return testAsoc;
            }

            else
            {
                return null;
            }
        }

        public string EliminarCategoriaConTest(Categoria categoriaBorrar)
        {

            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE IdCategoria = @IdCategoria";
            string msg = "";

            List<int> idTests = new List<int>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", categoriaBorrar.idCategoria);
                SqlDataReader dataReader = cmd.ExecuteReader();


                while (dataReader.Read())
                {
                    int result = int.Parse(dataReader["IdTest"].ToString());
                    idTests.Add(result);
                }
                dataReader.Close();
                this.conexion.Close();
            }


            foreach (var test in idTests)
            {
                string queryBorrarTest = "DELETE FROM TEST WHERE IdTest = @VALOR";
                Dictionary<string, string> dic2 = new Dictionary<string, string>();
                dic2.Add("WHERE", test.ToString());
                if (HacerConsulta(queryBorrarTest, out msg, "DELETE", dic2) == false)
                {
                    return msg;
                }
            }


            //Se nos borra automaticamente los id de las tabla M-N ya que tiene relacionados gracias al Borrar en Cascada en la base de datos.
            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE IdCategoria = @VALOR";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("WHERE", categoriaBorrar.idCategoria.ToString());
            if (HacerConsulta(queryBorrarCategoria, out msg, "DELETE", dic) == false)
            {
                return msg;
            }

            return "Categoría y tests eliminados correctamente";
        }

        public string AnadirTest(string nombreTest, List<Categoria> categorias)
        {

            if (String.IsNullOrWhiteSpace(nombreTest))
            {
                return "No puedes dejar vacio el nombre del test que quieres añadir.";
            }

            string ConsultaSiExiste = "SELECT * FROM TEST WHERE Descripcion = @valor";

            bool resultado = NoExiste(ConsultaSiExiste, nombreTest);

            if (resultado == false)
            {
                return "El test que quieres añadir ya existe.";
            }

            if (resultado == true)
            {
                string queryTest = "INSERT INTO TEST (descripcion) VALUES (@valor)";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("VALUES", nombreTest);
                string msg = "";
                if (HacerConsulta(queryTest, out msg, "INSERT", dic) == false)
                {
                    return msg;
                }

                if (OpenConnection() == true)
                {
                    string queryIdTest = "SELECT IdTest FROM TEST WHERE Descripcion = @Descripcion";
                    SqlCommand cmd = new SqlCommand(queryIdTest, conexion);
                    cmd.Parameters.AddWithValue("@Descripcion", nombreTest);
                    SqlDataReader reader = cmd.ExecuteReader();
                    int idTest = 0;

                    while (reader.Read())
                    {
                        idTest = int.Parse(reader["IdTest"].ToString());
                    }

                    reader.Close();

                    foreach (var cat in categorias)
                    {
                        string queryTestCategorias = "INSERT INTO CATEGORIASTESTS VALUES (@IdCategoria,@IdTest)";
                        SqlCommand cmd2 = new SqlCommand(queryTestCategorias, conexion);
                        cmd2.Parameters.AddWithValue("@IdCategoria", cat.idCategoria);
                        cmd2.Parameters.AddWithValue("@IdTest", idTest);

                        int comprobacion = Convert.ToInt32(cmd2.ExecuteNonQuery());
                        if (comprobacion == 0)
                        {
                            this.conexion.Close();
                            return "No se ejecuto correctamente";
                        }
                    }
                    this.conexion.Close();
                }

            }
            return "El test se ha añadido correctamente";
        }

        public List<Test> DevolverTests()
        {
            string queryDevolverCategorias = "SELECT * FROM TEST";
            List<Test> devolverTests = new List<Test>();

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryDevolverCategorias, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Test nuevoTest = new Test();
                    Pregunta newPregunta = new Pregunta();

                    nuevoTest.Descripcion = dataReader["Descripcion"].ToString();
                    nuevoTest.idTest = int.Parse(dataReader["IdTest"].ToString());

                    devolverTests.Add(nuevoTest);
                }
                dataReader.Close();
                this.CloseConnection();

                if (devolverTests.Count() != 0)
                {
                    return devolverTests;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public List<Pregunta> DevolverPreguntasDeTest(List<Test> listTest)
        {
            List<Pregunta> testConPreguntas = new List<Pregunta>();

            foreach (var test in listTest)
            {
                string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE IdTest = @IdTest";
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand(queryPreguntas, conexion);
                    cmd.Parameters.AddWithValue("@IdTest", test.idTest);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Pregunta newPregunta = new Pregunta();
                        newPregunta.idPregunta = int.Parse(dataReader["IdPregunta"].ToString());
                        newPregunta.idTest = int.Parse(dataReader["IdTest"].ToString());
                        newPregunta.enunciado = dataReader["Enunciado"].ToString();
                        newPregunta.respV = bool.Parse(dataReader["RespV"].ToString());
                        testConPreguntas.Add(newPregunta);
                    }
                    dataReader.Close();
                    this.conexion.Close();
                }
            }
            return testConPreguntas;

        }

        public string BorrarCategoriaTestsPreguntas(List<Pregunta> preguntasEliminar)
        {
            foreach (var pregunta in preguntasEliminar)
            {
                string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IdPregunta = @VALOR";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("WHERE", pregunta.idPregunta.ToString());
                string msg = "";
                if (HacerConsulta(queryEliminarPreguntas, out msg, "DELETE", dic) == false)
                {
                    return msg;
                }

            }
            return "Preguntas eliminadas";
        }

        public string AnadirCategoriaTest(Categoria categoria, Test test)
        {

            if (OpenConnection() == true)
            {
                string queryComprobacion = "SELECT * FROM CATEGORIASTESTS WHERE IdCategoria = @IdCategoria AND IdTest = @IdTest ";
                SqlCommand cmd = new SqlCommand(queryComprobacion, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", categoria.idCategoria);
                cmd.Parameters.AddWithValue("@IdTest", test.idTest);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Test test1 = new Test();
                        Categoria categoria1 = new Categoria();

                        test1.idTest = int.Parse(dr["IdTest"].ToString());
                        categoria1.idCategoria = int.Parse(dr["IdCategoria"].ToString());

                        if (test1.idTest == test.idTest && categoria1.idCategoria == categoria.idCategoria)
                        {
                            dr.Close();
                            this.conexion.Close();
                            return "La categoría " + categoria.Descripcion + " ya esta asociado con el test " + test.Descripcion;
                        }
                    }
                    dr.Close();
                }
                this.conexion.Close();
            }


            if (OpenConnection() == true)
            {
                string queryCatTest = "INSERT INTO CATEGORIASTESTS VALUES (@IdCategoria, @IdTest)";
                SqlCommand cmdAnadir = new SqlCommand(queryCatTest, conexion);

                cmdAnadir.CommandText = queryCatTest;
                cmdAnadir.Parameters.AddWithValue("@IdCategoria", categoria.idCategoria);
                cmdAnadir.Parameters.AddWithValue("@IdTest", test.idTest);

                int numFilas = cmdAnadir.ExecuteNonQuery();
                if (numFilas <= 0)
                {
                    return "Fallo al añadir la categoría " + categoria.Descripcion + "con el test " + test.Descripcion + ", contacte con el administrador";
                }
                this.conexion.Close();
            }

            return "La categoría " + categoria.Descripcion + " añadida correctamente al test " + test.Descripcion;
        }

        public string ModificarTest(string nombreTest, string nuevoNombreTest, List<Test> listTest)
        {
            if (String.IsNullOrWhiteSpace(nuevoNombreTest))
            {
                return "El nuevo nombre del test no puede quedar vacio";
            }

            if (String.IsNullOrWhiteSpace(nombreTest))
            {
                return "Debes seleccionar el nombre del test que quieres cambiar";
            }

            if (nombreTest.ToLower() == nuevoNombreTest.ToLower())
            {
                return "No puedes ponerles el mismo nombre";
            }

            foreach (var test in listTest)
            {
                if (test.Descripcion.Equals(nuevoNombreTest))
                {
                    return "No puedes ponerle el mismo nombre que a otro test que ya tienes creado";
                }
            }

            string queryModificarTest = "UPDATE TEST SET Descripcion = @VALOR1 WHERE(((Descripcion) = @VALOR2))";
            string msg = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SET", nuevoNombreTest);
            dic.Add("WHERE", nombreTest);
            if (HacerConsulta(queryModificarTest, out msg, "UPDATE", dic) == false)
            {
                return msg;
            }

            return "Test modificado correctamente";

        }

        public string EliminarTest(Test eliminarTest)
        {
            string msg = "";
            bool mensaje = false;

            if (eliminarTest.preguntasTest.Count != 0)
            {
                mensaje = true;
                string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IdTest = @VALOR";

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("WHERE", eliminarTest.idTest.ToString());
                if (HacerConsulta(queryEliminarPreguntas, out msg, "DELETE", dic) == false)
                {
                    return msg;
                }
            }

            string queryEliminarTest = "DELETE FROM TEST WHERE Idtest = @VALOR";
            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("WHERE", eliminarTest.idTest.ToString());
            if (HacerConsulta(queryEliminarTest, out msg, "DELETE", dic2) == false)
            {
                return msg;
            }

            if (mensaje == true)
            {
                return "Test " + eliminarTest.Descripcion + " y las preguntas asociadas eliminadas";

            }
            return "Test " + eliminarTest.Descripcion + " eliminado correctamente";
        }

        public Test DevolverTestConPreguntas(Test buscarTest)
        {
            List<Test> testConPreguntas = new List<Test>();

            string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = @IdTest))";

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryPreguntas, conexion);
                cmd.Parameters.AddWithValue("@IdTest", buscarTest.idTest);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Pregunta newPregunta = new Pregunta();
                    newPregunta.enunciado = dataReader["Enunciado"].ToString();
                    newPregunta.idPregunta = int.Parse(dataReader["IdPregunta"].ToString());

                    buscarTest.preguntasTest.Add(newPregunta);
                }
                dataReader.Close();
                this.conexion.Close();
            }

            return buscarTest;

        }

        public string AnadirPregunta(string enunciado, bool valido, Test agregarTest)
        {
            string queryExistePregunta = "SELECT * FROM PREGUNTAS WHERE Enunciado = @valor";

            bool resultado = NoExiste(queryExistePregunta, enunciado);

            if (resultado == false)
            {
                return "Esta pregunta ya existe no puedes añardirla";
            }

            if (String.IsNullOrWhiteSpace(enunciado))
            {
                return "No puedes dejar vacio el enunciado";
            }


            string anadirPregunta = "INSERT INTO PREGUNTAS(Enunciado,RespV,Idtest) VALUES(@enunciado,@valido,@IdTest)";
            if (OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(anadirPregunta, conexion);
                cmd.Parameters.AddWithValue("@enunciado", enunciado);
                cmd.Parameters.AddWithValue("@valido", valido);
                cmd.Parameters.AddWithValue("@IdTest", agregarTest.idTest);
                int comprobar = 0;
                comprobar = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (comprobar == 0)
                {
                    return "No se ha podido insertar la pregunta";
                }
                this.conexion.Close();
            }

            return "Pregunta agregada correctamente";
        }

        public string BorrarPregunta(int idPregunta)
        {
            string queryBorrarPregunta = "DELETE FROM PREGUNTAS WHERE IdPregunta = @VALOR";
            string msg = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("WHERE", idPregunta.ToString());
            if (HacerConsulta(queryBorrarPregunta, out msg, "DELETE", dic) == false)
            {
                return msg;
            }
            return "La pregunta ha sido borrada correctamente.";
        }

        public string EliminarTodasLasPreguntasDeTest(int idTest)
        {
            string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IDTEST = @VALOR";
            string msg = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("WHERE", idTest.ToString());
            if (HacerConsulta(queryEliminarPreguntas, out msg, "DELETE", dic) == false)
            {
                return msg;
            }

            return "Se eliminaron todas las preguntas del test.";
        }

    }
}
