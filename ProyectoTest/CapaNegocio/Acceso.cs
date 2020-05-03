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
        Gestor nuevoAcceso = new Gestor(out string msg);

        public String AnadirCategoria(string nombreCategoria)
        {
            return nuevoAcceso.AnadirCategoria(nombreCategoria);
        }

        public List<Categoria> DevolverCategorias()
        {
            return nuevoAcceso.DevolverCategorias();
        }


        public string BorrarCategoria (int eliminarCategoria)
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

        public List<Test> DevolverTestsDeCategoria (Categoria categoria)
        {
            return nuevoAcceso.DevolverTestAsociadoCategoria(categoria);
        }

        public string BorrarCategoriaTest( Categoria categoriaBorrar)
        {
            return nuevoAcceso.EliminarCategoriaConTest(categoriaBorrar);
        }

        public string AnadirTest(string nombreTest,List<Categoria> categorias)
        {
           return nuevoAcceso.AnadirTest(nombreTest,categorias);
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

        public string AnadirCategoriaTest(Categoria categoria, Test test)
        {
            return nuevoAcceso.AnadirCategoriaTest(categoria, test);
        }

        public string EliminarTest(Test eliminarTest)
        {
            return nuevoAcceso.EliminarTest(eliminarTest);
        }

        public string ModificarTest(string nombreTest, string nuevoNombreTest, List<Test> tests)
        {
            return nuevoAcceso.ModificarTest(nombreTest, nuevoNombreTest, tests);
        }

        public string EliminarPreguntasDeTest(Test eliminarTest)
        {
            return nuevoAcceso.EliminarTestConPreguntas(eliminarTest);
        }

        public Test DevolverPreguntasTest (Test buscarTest)
        {
            return nuevoAcceso.DevolverTestConPreguntas(buscarTest);
        }

        public string AnadirPregunta(string enunciado, bool validez, Test agregarTest)
        {
            return nuevoAcceso.AnadirPregunta(enunciado, validez, agregarTest);
        }

        public string BorrarPregunta(int idPregunta)
        {
            return nuevoAcceso.BorrarPregunta(idPregunta);
        }

        public string EliminarTodasPreguntasTest(int idTest)
        {
            return nuevoAcceso.EliminarTodasLasPreguntasDeTest(idTest);
        }
    }
}
