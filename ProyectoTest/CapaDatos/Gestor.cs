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
        private string error; // TODO esta variable no tiene sentido, en todo caso debería ser un parámetero de salida en los métodos en que se pueden producir errores y no pueden salir como resultado de la función

        public Gestor()
        {
            Initialize(); // TODO Sin sentido ni la llamada ni el método, que devuelve mensajes que no sirven para nada
        }

        //Vamos a darle el valor a la conexion para no tener que estar constantemente usandolo.
        private String Initialize() // TODO Sin sentido
        {
            conexion = new SqlConnection(cadena);

            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                return "No se ha podido conectar con la base de datos";
            }

            conexion.Close();
            return "Conectado a la base de datos";
        }

        //Creamos esto para llamarlo despues en cada funcion
        private bool OpenConnection() // TODO ¿Para qué se almacena en error ese valor, si luego no se usa en ningún lugar?
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (SqlException)
            {
                error = "No se ha podido conectar con la base de datos";
                return false;
            }
        }


        //Lo llamamos en cada funcion para cerrar la conexión.
        private bool CloseConnection() // Mª Lo comentado en Open
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return false;
            }
        }


        //Funcion para comprobar si existe en la base de datos la categoria que nos pasen.
        private bool ExisteCategoria(string consulta) // TODO Si solo necesita saber si exiswte o no, ¿para qué usar una consulta de tipo ExecuteReader y si solo puede haber 1, ¿por qué while? Y ¿que sentido tiene este parámetro? Lo lógico es que se haga dentro la sql
        {
            List<Categoria> listCat = new List<Categoria>(); // TODO Esto es copia de otros lugares, pero en esta función no tiene sentido

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read()) // ¿pueden ser varias?
                {
                    string nombreCategoria = dataReader["Descripcion"] + "";
                    listCat.Add(new Categoria(nombreCategoria));
                }
                dataReader.Close();
                this.CloseConnection();

                if (listCat.Count() != 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }


        private bool ExisteTest(string consulta) //Mª Idem a Categoria
        {
            List<Test> listTest = new List<Test>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string nombreTest = dataReader["Descripcion"] + "";
                    listTest.Add(new Test(nombreTest));
                }
                dataReader.Close();
                this.CloseConnection();

                if (listTest.Count() != 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }


        //Funcion creada para acortar codigo y llamarla directamente al ejecutar una consulta.
        private bool HacerConsulta(string consulta) // TODO Si hay errores, debería salir de este método el error, no en una variable global privada que nadie va a consultar 
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd2 = new SqlCommand(consulta, conexion);

                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    error = "Se ha producido un error con la conexión pruebe otra vez o contacte con el administrador mensaje de error: " + ex.Message;
                    return false;
                }
                this.CloseConnection();
            }
            else
            {
                return false;
            }
            return true;
        }

        public string AnadirCategoria(string nombreCategoria)
        {
            if (String.IsNullOrWhiteSpace(nombreCategoria))
            {
                return "El nombre de la categoria que quieres añadir no puede estar vacio.";
            }
            //Consulta para comprobar si existe la categoeria que nos pasan, despues la pasamos a la función.
            string ConsultaSiExiste = "SELECT * FROM CATEGORIAS WHERE Descripcion = '" + nombreCategoria + "'";
            bool resultado = ExisteCategoria(ConsultaSiExiste);

            //Comprobamos el resultado de la función para meterlo en la base de datos o decirle que no
            if (resultado == false)
            {
                return "No puede añadir la categoria " + nombreCategoria + " porque ya existe";
            }

            if (resultado == true)
            {
                string queryAnadirCategoria = "INSERT INTO Categorias (descripcion) VALUES('" + nombreCategoria + "')";
                if (HacerConsulta(queryAnadirCategoria) == false)
                {
                    return error;
                }
            }

            return "Categoria añadida correctamente";

        }

        public List<Categoria> DevolverCategorias() // TODO Si hay errores de ejecución, no salen al exterior
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

        public String EliminarCategoria(Categoria categoriaEliminar) // TODO No tiene sentido que reciba toda la categoría, con el id debería bastar. Ver resto de comentarios de la función
        {
            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaEliminar.idCategoria + "'))";
            //  No se deben hacer las consultas así (con + ) sino con parámetros. Así son más fáciles de hackear (está en los apuntes)
            // Si solo necesitas saber la cantidad de categorías esta consulta no es la lógica, sino  (Count)
            string result = "";
            string result2 = "";
            List<Test> listTest = new List<Test>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                // TODO Si lo que quieres saber es si tiene o no test, ?para qué necesita recorrerlos todos? Bastaría con una consulta Scalar (Count) o sino con HasRows, pero el while que haces carece de sentido
                while (dataReader.Read()) 
                {
                    result = (dataReader["IdCategoria"].ToString()); // ¿?¿?¿? Es una lógica muy extraña
                    Test newTest = new Test();
                    newTest.idTest = int.Parse(dataReader["IdTest"].ToString());
                    newTest.idCategoria = int.Parse(dataReader["IdCategoria"].ToString());
                    listTest.Add(newTest);
                }
                dataReader.Close();
                this.conexion.Close();
            }

            foreach (var test in listTest)
            {
                // De nuevo esta búsqueda así planteada no tiene sentido
                string comprobarPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = '" + test.idTest + "'))";
                if (OpenConnection() == true)
                {
                    SqlCommand cmd2 = new SqlCommand(comprobarPreguntas, conexion);
                    SqlDataReader dataReader2 = cmd2.ExecuteReader();

                    while (dataReader2.Read())
                    {
                        result2 = dataReader2["IdTest"].ToString(); // Un while para 1 sola variable
                    }
                    dataReader2.Close();
                    this.conexion.Close();
                }
            }

            if (result != "" && result2 == "")
            {
                return "test";
            }

            if (!((result == "") && (result2 == "")))
            {
                return "preguntas";
            }
       

            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((Descripcion) = '" + categoriaEliminar.Descripcion + "'))";
            if (HacerConsulta(queryBorrarCategoria) == false)
            {
                return error;
            }
            return "Categoria eliminada correctamente";
        }

        public String ModificarCategoria(Categoria categoria, string nuevaCategoria, List<Categoria> categorias)
        {

            if (String.IsNullOrWhiteSpace(nuevaCategoria))
            {
                return "No puedes dejar la categoria que vas a modificar en blanco";
            }
            if (categoria.Descripcion.ToLower() == nuevaCategoria.ToLower())
            {
                return "No puedes ponerle el mismo nombre a la categoria.";
            }

            //Comprobamos que ese nombre que mete no sea el mismo de uno que ya existe en la BD.
            foreach (var cat in categorias)
            {
                if (cat.Descripcion.Equals(nuevaCategoria))
                {
                    return "No puede ponerle el mismo nombre que a una categoria existente";
                }
            }


            string queryModificarCategoria = "UPDATE CATEGORIAS SET Descripcion = '" + nuevaCategoria + "' WHERE (((Descripcion) = '" + categoria.Descripcion + "'))";
            if (HacerConsulta(queryModificarCategoria) == false)
            {
                return error;
            }
            return "Categoria modificada correctamente";
        }


        public string EliminarTodasCategorias()
        {
            string queryEliminarCategorias = "DELETE FROM CATEGORIAS";
            string queryEliminarTest = "DELETE T FROM TEST AS T INNER JOIN CATEGORIASTESTS ON T.IDTEST = CATEGORIASTESTS.IDTEST WHERE T.IDTEST = CATEGORIASTESTS.IDTEST";
            string queryEliminarPreg = "DELETE P FROM PREGUNTAS AS P INNER JOIN TEST ON P.IDTEST = TEST.IDTEST WHERE P.IDTEST = TEST.IDTEST";
            if (HacerConsulta(queryEliminarPreg) == false)
            {
                return error;
            }
            if (HacerConsulta(queryEliminarTest) == false)
            {
                return error;
            }
            if (HacerConsulta(queryEliminarCategorias) == false)
            {
                return error;
            }
            return "Todas las categorias, test y preguntas se han eliminado con exito";
        }

        public List<Test> DevolverTestAsociadoCategoria(Categoria categoriaRela) // TODO Observa la cantidad de código que se repite con EliminarCategoria
        {
            
            List<Test> testAsoc = new List<Test>();
            List<Test> testDevolver = new List<Test>();
            string queryTestAsoc = "SELECT IdTest FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaRela.idCategoria + "'))"; // el tipo es int ¿por qué pones esas comillas?

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryTestAsoc, conexion);
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
                    string queryTest = "SELECT * FROM TEST WHERE (((IdTest) = '" + test.idTest + "'))";
                    if (this.OpenConnection() == true)
                    {
                        SqlCommand cmd2 = new SqlCommand(queryTest, conexion);
                        SqlDataReader dataReader2 = cmd2.ExecuteReader();
                        Test newTest2 = new Test();

                        while (dataReader2.Read()) // De nuevo, si esto fuese un while no tendría sentido el código interior.
                        {
                            newTest2.idTest = int.Parse(dataReader2["IdTest"].ToString());
                            newTest2.Descripcion = dataReader2["Descripcion"].ToString();

                        }
                        dataReader2.Close();
                        this.conexion.Close();

                        string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = '" + test.idTest + "'))";
                        if (OpenConnection() == true)
                        {
                            SqlCommand cmd3 = new SqlCommand(queryPreguntas, conexion);
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

            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaBorrar.idCategoria + "'))";

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
                string queryBorrarTest = "DELETE FROM TEST WHERE (((IdTest) = '" + test + "'))";
                if (HacerConsulta(queryBorrarTest) == false)
                {
                    return error;
                }
            }


            //Se nos borra automaticamente los id de las tabla M-N ya que tiene relacionados gracias al Borrar en Cascada en la base de datos.
            string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((IdCategoria) = '" + categoriaBorrar.idCategoria + "'))";
            if (HacerConsulta(queryBorrarCategoria) == false)
            {
                return error;
            }

            return "Categoria y tests eliminados correctamente";
        }

        public string AnadirTest(string nombreTest)
        {
            if (String.IsNullOrWhiteSpace(nombreTest))
            {
                return "No puedes dejar vacio el nombre del test que quieres añadir.";
            }

            string ConsultaSiExiste = "SELECT * FROM TEST WHERE Descripcion = '" + nombreTest + "'";
            bool resultado = ExisteTest(ConsultaSiExiste);

            if (resultado == false)
            {
                return "El test " + nombreTest + " que quieres añadir ya existe.";
            }

            if (resultado == true)
            {
                string queryTest = "INSERT INTO TEST (descripcion) VALUES ('" + nombreTest + "')";
                if (HacerConsulta(queryTest) == false)
                {
                    return error;
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
                string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = '" + test.idTest + "'))";
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
                string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE (((IdPregunta) = '" + pregunta.idPregunta + "'))";
                if (HacerConsulta(queryEliminarPreguntas) == false)
                {
                    return error;
                }

            }
            return "Preguntas eliminadas";
        }

        public string AnadirCategoriaTest(Categoria categoria, Test test)
        {

            try
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
                                return "La categoria " + categoria.Descripcion + " ya esta asociado con el test " + test.Descripcion;
                            }
                        }
                        dr.Close();
                    }
                    this.conexion.Close();
                }

            }
            catch (Exception ex)
            {
                error = "Fallo al conectar, contace con el administrador descripcion del error: " + ex.Message;
                return error;
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
                    return "Fallo al añadir la categoria " + categoria.Descripcion + "con el test " + test.Descripcion + ", contacte con el administrador";
                }
                this.conexion.Close();
            }

            return "La categoria " + categoria.Descripcion + " añadido correctamente al test " + test.Descripcion;
        }

        public string EliminarTest(Test testEliminar)
        {
            string comprobarTest = "SELECT idTest FROM PREGUNTAS WHERE (((IdTest) = '" + testEliminar.idTest + "'))";
            int comprobacion = 0;

            if (OpenConnection() == true)
            {

                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                comprobacion = Convert.ToInt32(cmd.ExecuteScalar());
            }
            this.conexion.Close();

            if (comprobacion > 0)
            {
                return "preguntas";
            }
            else
            {
                string eliminarTest = "DELETE FROM TEST WHERE (((IdTest) =  '" + testEliminar.idTest + "'))";
                if (HacerConsulta(eliminarTest) == false)
                {
                    return error;
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
            if (HacerConsulta(queryModificarTest) == false)
            {
                return error;
            }

            return "Test modificado correctamente";

        }

        public string EliminarTestConPreguntas(Test eliminarTest)
        {
            string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IdTest = " + eliminarTest.idTest;
            if (HacerConsulta(queryEliminarPreguntas) == false)
            {
                return error;
            }

            string queryEliminarTest = "DELETE FROM TEST WHERE Idtest = " + eliminarTest.idTest;
            if (HacerConsulta(queryEliminarTest) == false)
            {
                return "error";
            }

            return "Test " + eliminarTest.Descripcion + " con las preguntas asociadas elimanado";
        }

        public Test DevolverTestConPreguntas(Test buscarTest)
        {

            List<Test> testConPreguntas = new List<Test>();


            string queryPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = '" + buscarTest.idTest + "'))";
            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(queryPreguntas, conexion);
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


            string anadirPregunta = "INSERT INTO PREGUNTAS(Enunciado,RespV,Idtest) VALUES('" + enunciado + "','" + valido + "','" + agregarTest.idTest + "')";

            if (HacerConsulta(anadirPregunta) == false)
            {
                return error;
            }

            return "Pregunta agregada correctamente";
        }

        public string BorrarPregunta (int idPregunta)
        {
            string queryBorrarPregunta = "DELETE FROM PREGUNTAS WHERE IdPregunta = '" + idPregunta + "'";
            if (HacerConsulta(queryBorrarPregunta) == false)
            {
                return error;
            }
            return "La pregunta ha sido borrada correctamente.";
        }

        public string EliminarTodasLasPreguntasDeTest(int idTest)
        {
            string queryEliminarPreguntas = "DELETE FROM PREGUNTAS WHERE IDTEST = '" + idTest + "'";
            if (HacerConsulta(queryEliminarPreguntas) == false)
            {
                return error;
            }

            return "Se eliminaron todas las preguntas del test.";
        }

    }
}
