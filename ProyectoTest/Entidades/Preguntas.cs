using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Preguntas : IEquatable<Preguntas>
    {
        public int idPreguntas { get; set; }
        public int numPregunta { get; set; }
        public string enunciado { get; set; }
        public bool respV { get; set; }
        public int idTest { get; set; }

        public Preguntas()
        {
        }

        public Preguntas(int idPreguntas, int numPregunta, string enunciado, bool respV, int idTest)
        {
            this.idPreguntas = idPreguntas;
            this.numPregunta = numPregunta;
            this.enunciado = enunciado;
            this.respV = respV;
            this.idTest = idTest;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Preguntas);
        }

        public bool Equals(Preguntas other)
        {
            return other != null &&
                   idPreguntas == other.idPreguntas;
        }

        public override int GetHashCode()
        {
            return -2025408053 + idPreguntas.GetHashCode();
        }
    }
}
