using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tests : IEquatable<Tests>
    {

        public int idTest { get; set; }
        public string Descripcion { get; set; }

        public Tests()
        {
        }

        public Tests(string descripcion)
        {
            Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tests);
        }

        public bool Equals(Tests other)
        {
            return other != null &&
                   idTest == other.idTest;
        }

        public override int GetHashCode()
        {
            return -1443069084 + idTest.GetHashCode();
        }
    }
}
