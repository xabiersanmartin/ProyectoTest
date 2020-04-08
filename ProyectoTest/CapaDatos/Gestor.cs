using System;
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

			string ConsultaSiExiste = "SELECT * FROM CATEGORIAS WHERE Descripcion = '" + nombreCategoria + "'";
			string resultado = ExisteCategoria(ConsultaSiExiste);

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
				return "La categoria ya existe";
			}
			return "Categoria añadida correctamente";

		}

		public List<string> DevolverCategorias()
		{
			string queryDevolverCategorias = "SELECT * FROM CATEGORIAS";
			List<string> devolverCategorias = new List<string>();

			if (OpenConnection() == true)
			{
				SqlCommand cmd = new SqlCommand(queryDevolverCategorias, conexion);
				SqlDataReader dataReader = cmd.ExecuteReader();

				while (dataReader.Read())
				{
					devolverCategorias.Add(dataReader["Descripcion"].ToString());
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

		public String EliminarCategoria(string categoriaEliminar)
		{
			string queryBorrarCategoria = "DELETE FROM CATEGORIAS WHERE (((Descripcion) = '" + categoriaEliminar + "'))";
			if (HacerConsulta(queryBorrarCategoria) == "-1")
			{
				return error;
			}
			return "Categoria eliminada correctamente";
		}

		public String ModificarCategoria(string categoria, string nuevaCategoria)
		{
			if (String.IsNullOrWhiteSpace(nuevaCategoria))
			{
				return "No puedes dejar la categoria que vas a modificar en blanco";
			}
			string queryModificarCategoria = "UPDATE CATEGORIAS SET Descripcion = '" + nuevaCategoria + "' WHERE (((Descripcion) = '" + categoria + "'))";
			if (HacerConsulta(queryModificarCategoria) == "-1")
			{
				return error;
			}
			return "Categoria modificada correctamente";
		}
	}
}
