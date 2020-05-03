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
            catch (Exception)
            {
                msg = "No se ha podido conectar con la base de datos";
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
        private bool NoExisteCategoria(string consulta)
        {

            int comprobarExiste = 0;

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
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

        private bool NoExisteTest(string consulta)
        {
            int comprobarExiste = 0;

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
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
        private bool HacerConsulta(string consulta, out string msg)
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd2 = new SqlCommand(consulta, conexion);
                int comprobar = 0;

                try
                {
                    comprobar = cmd2.ExecuteNonQuery();
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
            string ConsultaSiExiste = "SELECT * FROM CATEGORIAS WHERE Descripcion = '" + nombreCategoria + "'";
            bool resultado = NoExisteCategoria(ConsultaSiExiste);

            //Comprobamos el resultado de la función para meterlo en la base de datos o decirle que no
            if (resultado == false)
            {
                return "No se puede añadir la categoría " + nombreCategoria + " porque ya existe";
            }

            if (resultado == true)
            {
                string queryAnadirCategoria = "INSERT INTO Categorias (descripcion) VALUES('" + nombreCategoria + "')";
                string msg = "";
                if (HacerConsulta(queryAnadirCategoria, out msg) == false)
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

            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((IdCategoria) = " + categoriaEliminar + "))";
            string msg = "";
            if (HacerConsulta(queryBorrarCategoria, out msg) == false)
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

            string queryModificarCategoria = "UPDATE CATEGORIAS SET Descripcion = '" + nuevaCategoria + "' WHERE (((Descripcion) = '" + categoria.Descripcion + "'))";
            string msg = "";
            if (HacerConsulta(queryModificarCategoria, out msg) == false)
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
            List<Test> testDevolver = new List<Test>();
            string queryTestAsoc = "SELECT IdTest FROM CATEGORIASTESTS WHERE (((IdCategoria) = @IdCategoria))";

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryTestAsoc, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", categoriaRela.idCategoria);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Test newTest = new Test();
                    newTest.idTest = int.Parse(dataReader["IdTest"].ToString());

                    testAsoc.Add(newTest);
                }
                dataReader.Close();
                this.conexion.Close();

                foreach (var test in testAsoc)
                {
                    string queryTest = "SELECT * FROM TEST WHERE (((IdTest) = @IdTest))";
                    if (this.OpenConnection() == true)
                    {
                        SqlCommand cmd2 = new SqlCommand(queryTest, conexion);
                        cmd2.Parameters.AddWithValue("@IdTest", test.idTest);
                        SqlDataReader dataReader2 = cmd2.ExecuteReader();
                        Test newTest2 = new Test();

                        if (dataReader2.Read())
                        {
                            newTest2.idTest = int.Parse(dataReader2["IdTest"].ToString());
                            newTest2.Descripcion = dataReader2["Descripcion"].ToString();

                        }
                        dataReader2.Close();
                        this.conexion.Close();

                        string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = @IdTest))";
                        if (OpenConnection() == true)
                        {
                            SqlCommand cmd3 = new SqlCommand(queryPreguntas, conexion);
                            cmd3.Parameters.AddWithValue("@IdTest", test.idTest);
                            SqlDataReader dataReader3 = cmd3.ExecuteReader();

                            while (dataReader3.Read())
                            {
                                Pregunta newPregunta = new Pregunta();
                                newPregunta.idPregunta = int.Parse(dataReader3["IdPregunta"].ToString());
                                newPregunta.idTest = int.Parse(dataReader3["IdTest"].ToString());
                                newPregunta.enunciado = dataReader3["Enunciado"].ToString();
                                newPregunta.respV = bool.Parse(dataReader3["RespV"].ToString());

                                newTest2.preguntasTest.Add(newPregunta);
                            }

                            testDevolver.Add(newTest2);
                            dataReader3.Close();
                            this.conexion.Close();
                        }

                    }
                }
                return testDevolver;
            }

            else
            {
                return null;
            }
        }

        public string EliminarCategoriaConTest(Categoria categoriaBorrar)
        {

            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = " + categoriaBorrar.idCategoria + "))";
            string msg = "";

            List<int> idTests = new List<int>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
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
                string queryBorrarTest = "DELETE FROM TEST WHERE (((IdTest) = " + test + "))";
                if (HacerConsulta(queryBorrarTest, out msg) == false)
                {
                    return msg;
                }
            }


            //Se nos borra automaticamente los id de las tabla M-N ya que tiene relacionados gracias al Borrar en Cascada en la base de datos.
            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((IdCategoria) = " + categoriaBorrar.idCategoria + "))";
            if (HacerConsulta(queryBorrarCategoria, out msg) == false)
            {
                return msg;
            }

            return "Categoría y tests eliminados correctamente";
        }

        public string AnadirTest(string nombreTest)
        {
            if (String.IsNullOrWhiteSpace(nombreTest))
            {
                return "No puedes dejar vacio el nombre del test que quieres añadir.";
            }

            string ConsultaSiExiste = "SELECT * FROM TEST WHERE Descripcion = '" + nombreTest + "'";
            bool resultado = NoExisteTest(ConsultaSiExiste);

            if (resultado == false)
            {
                return "El test que quieres añadir ya existe.";
            }

            if (resultado == true)
            {
                string queryTest = "INSERT INTO TEST (descripcion) VALUES ('" + nombreTest + "')";
                string msg = "";
                if (HacerConsulta(queryTest, out msg) == false)
                {
                    return msg;
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
                string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = " + test.idTest + "))";
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand(queryPreguntas, conexion);
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
                string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE (((IdPregunta) = " + pregunta.idPregunta + "))";
                string msg = "";
                if (HacerConsulta(queryEliminarPreguntas, out msg) == false)
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

        public string EliminarTest(Test testEliminar)
        {
            string comprobarTest = "SELECT idTest FROM PREGUNTAS WHERE (((IdTest) = @IdTest))";
            int comprobacion = 0;

            if (OpenConnection() == true)
            {

                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                cmd.Parameters.AddWithValue("@IdTest", testEliminar.idTest);
                comprobacion = Convert.ToInt32(cmd.ExecuteScalar());
            }
            this.conexion.Close();

            if (comprobacion > 0)
            {
                return "preguntas";
            }
            else
            {
                string eliminarTest = "DELETE FROM TEST WHERE (((IdTest) =  " + testEliminar.idTest + "))";
                string msg = "";
                if (HacerConsulta(eliminarTest, out msg) == false)
                {
                    return msg;
                }
            }

            return "Test eliminado correctamente";
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

            string queryModificarTest = "UPDATE TEST SET Descripcion = '" + nuevoNombreTest + "' WHERE(((Descripcion) = '" + nombreTest + "'))";
            string msg = "";
            if (HacerConsulta(queryModificarTest, out msg) == false)
            {
                return msg;
            }

            return "Test modificado correctamente";

        }

        public string EliminarTestConPreguntas(Test eliminarTest)
        {
            string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IdTest = " + eliminarTest.idTest;
            string msg = "";
            if (HacerConsulta(queryEliminarPreguntas, out msg) == false)
            {
                return msg;
            }

            string queryEliminarTest = "DELETE FROM TEST WHERE Idtest = " + eliminarTest.idTest;
            if (HacerConsulta(queryEliminarTest, out msg) == false)
            {
                return msg;
            }

            return "Test " + eliminarTest.Descripcion + " y las preguntas asociadas elimanadas";
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
            string queryExistePregunta = "SELECT * FROM PREGUNTAS WHERE Enunciado = '" + enunciado + "'";
            int comprobacionExiste = 0;

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryExistePregunta, conexion);
                comprobacionExiste = Convert.ToInt32(cmd.ExecuteScalar());
            }
            this.conexion.Close();

            if (comprobacionExiste != 0)
            {
                return "Esta pregunta ya existe no puedes añardirla";
            }

            if (String.IsNullOrWhiteSpace(enunciado))
            {
                return "No puedes dejar vacio el enunciado";
            }


            string anadirPregunta = "INSERT INTO PREGUNTAS(Enunciado,RespV,Idtest) VALUES('" + enunciado + "','" + valido + "'," + agregarTest.idTest + ")";
            string msg = "";
            if (HacerConsulta(anadirPregunta, out msg) == false)
            {
                return msg;
            }

            return "Pregunta agregada correctamente";
        }

        public string BorrarPregunta(int idPregunta)
        {
            string queryBorrarPregunta = "DELETE FROM PREGUNTAS WHERE IdPregunta = " + idPregunta + "";
            string msg = "";
            if (HacerConsulta(queryBorrarPregunta, out msg) == false)
            {
                return msg;
            }
            return "La pregunta ha sido borrada correctamente.";
        }

        public string EliminarTodasLasPreguntasDeTest(int idTest)
        {
            string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IDTEST = " + idTest + "";
            string msg = "";
            if (HacerConsulta(queryEliminarPreguntas, out msg) == false)
            {
                return msg;
            }

            return "Se eliminaron todas las preguntas del test.";
        }

    }
}
