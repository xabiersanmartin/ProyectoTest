using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Acceso
    {
        Gestor nuevoAcceso = new Gestor();

        public String AnadirCategoria(string nombreCategoria)
        {
            return nuevoAcceso.AnadirCategoria(nombreCategoria);
        }

        public List<string> DevolverCategorias()
        {
            return nuevoAcceso.DevolverCategorias();
        }

        public string BorrarCategoria (string eliminarCategoria)
        {
            return nuevoAcceso.EliminarCategoria(eliminarCategoria);
        }

        public string ModificarCategoria(string categoria, string nuevaCategoria)
        {
            return nuevoAcceso.ModificarCategoria(categoria, nuevaCategoria);
        }
    }
}
