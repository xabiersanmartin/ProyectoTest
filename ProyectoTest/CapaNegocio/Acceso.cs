﻿using CapaDatos;
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

        public List<Categorias> DevolverCategorias()
        {
            return nuevoAcceso.DevolverCategorias();
        }

        public string BorrarCategoria (Categorias eliminarCategoria)
        {
            return nuevoAcceso.EliminarCategoria(eliminarCategoria);
        }

        public string ModificarCategoria(Categorias categoria, string nuevaCategoria, List<Categorias> categorias)
        {
            return nuevoAcceso.ModificarCategoria(categoria, nuevaCategoria, categorias);
        }

        public string EliminarCategorias()
        {
            return nuevoAcceso.EliminarTodasCategorias();
        }
    }
}
