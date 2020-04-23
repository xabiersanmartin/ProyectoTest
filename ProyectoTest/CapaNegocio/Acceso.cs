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

        public List<Categoria> DevolverCategorias()
        {
            return nuevoAcceso.DevolverCategorias();
        }

        public string BorrarCategoria (Categoria eliminarCategoria)
        {
            return nuevoAcceso.EliminarCategoria(eliminarCategoria);
        }

        public string ModificarCategoria(Categoria categoria, string nuevaCategoria, List<Categoria> categorias)
        {
            return nuevoAcceso.ModificarCategoria(categoria, nuevaCategoria, categorias);
        }

        public string EliminarCategorias()
        {
            return nuevoAcceso.EliminarTodasCategorias();
        }

        public List<Test> DevolverTestCategorias (Categoria categoria)
        {
            return nuevoAcceso.DevolverTestAsociadoCategoria(categoria);
        }

        public string BorrarCategoriaTest( Categoria categoriaBorrar)
        {
            return nuevoAcceso.EliminarCategoriaConTest(categoriaBorrar);
        }

        public string AnadirTest(Categoria categoria, string nombreTest)
        {
           return nuevoAcceso.AnadirTest(categoria, nombreTest);
        }

        public List<Test> DevolverTests()
        {
            return nuevoAcceso.DevolverTests();
        }

        public List<Pregunta> DevolverTestConPreguntas (List<Test> listTest)
        {
            return nuevoAcceso.DevolverPreguntasDeTest(listTest);
        }

        public string EliminarPreguntasDeTest(List<Pregunta> listPreguntas)
        {
            return nuevoAcceso.BorrarCategoriaTestsPreguntas(listPreguntas);
        }
    }
}
