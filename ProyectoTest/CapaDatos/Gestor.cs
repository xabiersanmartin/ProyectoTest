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
        private string error;

        public Gestor()
        {
            Initialize();
        }

        //Vamos a darle el valor a la conexion para no tener que estar constantemente usandolo.
        private String Initialize()
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
        private bool OpenConnection()
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
        private bool CloseConnection()
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
        private bool ExisteCategoria(string consulta)
        {
            List<Categoria> listCat = new List<Categoria>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
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

        //private bool ExisteTestCategoria(string consulta)
        //{
        //    List<Test> listTest = new List<Test>();
        //    List<Categoria> listCat = new List<Categoria>();

        //    if (OpenConnection() == true)
        //    {
        //        SqlCommand cmd = new SqlCommand(consulta, conexion);
        //        cmd.ExecuteScalar();


        //        {

        //        }
        //        int id;
        //        int id2;

        //        while (dataReader.Read())
        //        {
        //            string idTest = (dataReader["IdTest"].ToString());
        //            string idCategoria = dataReader["idCategoria"].ToString();
        //            id = Convert.ToInt32(idCategoria);
        //            id2 = Convert.ToInt32(idTest);

        //            listCat.Add(new Categoria(id));
        //            listTest.Add(new Test(id2));
        //        }
        //        dataReader.Close();
        //        this.CloseConnection();

        //        if (listTest.Count() != 0 && listCat.Count() != 0)
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private bool ExisteTest(string consulta)
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
        private bool HacerConsulta(string consulta)
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

        public String EliminarCategoria(Categoria categoriaEliminar)
        {
            string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaEliminar.idCategoria + "'))";
            string result = "";
            string result2 = "";
            List<Test> listTest = new List<Test>();

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
                SqlDataReader dataReader = cmd.ExecuteReader();


                while (dataReader.Read())
                {
                    result = (dataReader["IdCategoria"].ToString());
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
                string comprobarPreguntas = "SELECT * FROM PREGUNTAS WHERE (((IdTest) = '" + test.idTest + "'))";
                if (OpenConnection() == true)
                {
                    SqlCommand cmd2 = new SqlCommand(comprobarPreguntas, conexion);
                    SqlDataReader dataReader2 = cmd2.ExecuteReader();

                    while (dataReader2.Read())
                    {
                        result2 = dataReader2["IdTest"].ToString();
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
            if (HacerConsulta(queryEliminarCategorias) == false)
            {
                return error;
            }
            return "Todas las categorias se han eliminado con exito";
        }

        public List<Test> DevolverTestAsociadoCategoria(Categoria categoriaRela)
        {
            List<Test> testAsoc = new List<Test>();
            List<Test> testDevolver = new List<Test>();
            string queryTestAsoc = "SELECT IdTest FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaRela.idCategoria + "'))";

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

                        while (dataReader2.Read())
                        {
                            Test newTest2 = new Test();
                            newTest2.idTest = int.Parse(dataReader2["IdTest"].ToString());
                            newTest2.Descripcion = dataReader2["Descripcion"].ToString();

                            testDevolver.Add(newTest2);
                        }
                        dataReader.Close();
                        this.conexion.Close();
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
            return "El test "+nombreTest+ " se ha añadido correctamente";
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
                    newPregunta.numPregunta = int.Parse(dataReader["Npregunta"].ToString());
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
                                return "La categoria " + categoria.Descripcion+ " ya esta asociado con el test "+test.Descripcion;
                            }
                        }
                        dr.Close();
                    }
                    this.conexion.Close();
                }
                
            }
            catch (Exception ex)
            {
                error = "Fallo al conectar, contace con el administrador descripcion del error: " +ex.Message;
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
                    return "Fallo al añadir la categoria " + categoria.Descripcion+ "con el test "+test.Descripcion + ", contacte con el administrador";
                }
                this.conexion.Close();
            }

            return "La categoria " + categoria.Descripcion + " añadido correctamente al test " + test.Descripcion;
        }
}
}
