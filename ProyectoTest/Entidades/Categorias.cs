using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias : IEquatable<Categorias>
    {
        int idCategoria { get; set; }
        public string Descripcion { get; set; }


        public Categorias(string descripcion)
        {
            Descripcion = descripcion;
        }

        public Categorias()
        {
        }

        public Categorias(int idCategoria, string descripcion)
        {
            this.idCategoria = idCategoria;
            Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Categorias);
        }

        public bool Equals(Categorias other)
        {
            return other != null &&
                   idCategoria == other.idCategoria;
        }

        public override int GetHashCode()
        {
            return -964325053 + idCategoria.GetHashCode();
        }
    }
}
