using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta : IEquatable<Pregunta>
    {
        public int idPregunta { get; set; }
        public int numPregunta { get; set; }
        public string enunciado { get; set; }
        public bool respV { get; set; }

        public Pregunta()
        {
        }

        public Pregunta(int idPreguntas, int numPregunta, string enunciado, bool respV)
        {
            this.idPregunta = idPreguntas;
            this.numPregunta = numPregunta;
            this.enunciado = enunciado;
            this.respV = respV;
        }

        public Pregunta(string enunciado)
        {
            this.enunciado = enunciado;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pregunta);
        }

        public bool Equals(Pregunta other)
        {
            return other != null &&
                   idPregunta == other.idPregunta;
        }

        public override int GetHashCode()
        {
            return -2025408053 + idPregunta.GetHashCode();
        }
    }
}
