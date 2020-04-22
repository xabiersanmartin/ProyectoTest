﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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
				return "No se a podido conectar con la base de datos";
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
				error = "No se a podido conectar con la base de datos";
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
			catch (SqlException ex )
			{
				error = ex.Message;
				return false;
			}
		}


		//Funcion para comprobar si existe en la base de datos la categoria que nos pasen.
		private string ExisteCategoria(string consulta)
		{
			List<Categorias> listCat = new List<Categorias>();

			if (OpenConnection() == true)
			{
				SqlCommand cmd = new SqlCommand(consulta, conexion);
				SqlDataReader dataReader = cmd.ExecuteReader();

				while (dataReader.Read())
				{
					string nombreCategoria = dataReader["Descripcion"] + "";
					listCat.Add(new Categorias(nombreCategoria));
				}
				dataReader.Close();
				this.CloseConnection();

				if (listCat.Count() != 0)
				{
					return listCat[0].Descripcion.ToString();
				}
			}
			else
			{
				return "-1";
			}
			return "0";
		}

		//Funcion creada para acortar codigo y llamarla directamente al ejecutar una consulta.
		private String HacerConsulta(string consulta)
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
					error = ex.Message;
					return "-1";
				}
				this.CloseConnection();
			}
			else
			{
				return "-1";
			}
			return "1";
		}

		public string AnadirCategoria(string nombreCategoria)
		{
			if (String.IsNullOrWhiteSpace(nombreCategoria))
			{
				return "El nombre de la categoria que quieres añadir no puede estar vacio.";
			}
			//Consulta para comprobar si existe la categoeria que nos pasan, despues la pasamos a la función.
			string ConsultaSiExiste = "SELECT * FROM CATEGORIAS WHERE Descripcion = '" + nombreCategoria + "'";
			string resultado = ExisteCategoria(ConsultaSiExiste);

			//Comprobamos el resultado de la función para meterlo en la base de datos o decirle que no
			if (resultado == "-1")
			{
				return error;
			}

			if (resultado == "0")
			{
				string queryAnadirCategoria = "INSERT INTO Categorias (descripcion) VALUES('" + nombreCategoria + "')";
				if (HacerConsulta(queryAnadirCategoria)== "-1")
				{
					return error;
				}
			}
			else
			{
				return "Como puedes ver en el recuadro de al lado, la categoria ya existe";
			}
			return "Categoria añadida correctamente";

		}

		public List<Categorias> DevolverCategorias()
		{
			string queryDevolverCategorias = "SELECT * FROM CATEGORIAS";
			List<Categorias> devolverCategorias = new List<Categorias>();

			if (OpenConnection() == true)
			{
				SqlCommand cmd = new SqlCommand(queryDevolverCategorias, conexion);
				SqlDataReader dataReader = cmd.ExecuteReader();

				while (dataReader.Read())
				{
					Categorias nuevaCategoria = new Categorias();
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
			else{
				return null;
			}

		}

		public String EliminarCategoria(Categorias categoriaEliminar)
		{
			string comprobarTest = "SELECT * FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaEliminar.idCategoria + "'))";
			string result = "";

			if (OpenConnection() == true)
			{
				SqlCommand cmd = new SqlCommand(comprobarTest, conexion);
				SqlDataReader dataReader = cmd.ExecuteReader();


				while (dataReader.Read())
				{
					result = (dataReader["IdCategoria"].ToString());
				}
				dataReader.Close();
				this.conexion.Close();
			}

			if (!(result == ""))
			{
				return "test";
			}


			string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((Descripcion) = '" + categoriaEliminar.Descripcion + "'))";
			if (HacerConsulta(queryBorrarCategoria) == "-1")
			{
				return error;
			}
			return "Categoria eliminada correctamente";
		}

		public String ModificarCategoria(Categorias categoria, string nuevaCategoria, List<Categorias> categorias)
		{

			if (String.IsNullOrWhiteSpace(nuevaCategoria))
			{
				return "No puedes dejar la categoria que vas a modificar en blanco";
			}
			if (categoria.Descripcion.ToLower() == nuevaCategoria.ToLower())
			{
				return "No puedes cambiarlo por el mismo nombre";
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
			if (HacerConsulta(queryModificarCategoria) == "-1")
			{
				return error;
			}
			return "Categoria modificada correctamente";
		}

		public string EliminarTodasCategorias()
		{
			string queryEliminarCategorias = "DELETE FROM CATEGORIAS";
			if (HacerConsulta(queryEliminarCategorias) == "-1")
			{
				return error;
			}
			return "Todas las categorias se han eliminado con exito";
		}

		public List<Tests> DevolverTestAsociadoCategoria (Categorias categoriaRela)
		{
			List<Tests> testAsoc = new List<Tests>();
			List<Tests> testDevolver = new List<Tests>();
			string queryTestAsoc = "SELECT IdTest FROM CATEGORIASTESTS WHERE (((IdCategoria) = '" + categoriaRela.idCategoria + "'))";

			if (this.OpenConnection() == true)
			{
				SqlCommand cmd = new SqlCommand(queryTestAsoc, conexion);
				SqlDataReader dataReader = cmd.ExecuteReader();

				while (dataReader.Read())
				{
					Tests newTest = new Tests();
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
							Tests newTest2 = new Tests();
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

		public String EliminarCategoriaConTest (Categorias categoriaBorrar)
		{
			//Se nos borra automaticamente los test que tiene relacionados gracias al Borrar en Cascada en la base de datos.
			string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((IdCategoria) = '" + categoriaBorrar.idCategoria + "'))";
			if (HacerConsulta(queryBorrarCategoria) == "-1")
			{
				return error;
			}
			return "Categoria eliminada correctamente";
		}
	}
}
