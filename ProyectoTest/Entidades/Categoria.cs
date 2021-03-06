﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria : IEquatable<Categoria>
    {
        public int idCategoria { get; set; }
        public string Descripcion { get; set; }

        public List<Test> TestCategorias = new List<Test>();


        public Categoria(string descripcion)
        {
            Descripcion = descripcion;
        }

        public Categoria()
        {
        }

        public Categoria(int idCategoria, string descripcion)
        {
            this.idCategoria = idCategoria;
            Descripcion = descripcion;
        }

        public Categoria(int idCategoria)
        {
            this.idCategoria = idCategoria;
        }

        public Categoria(int idCategoria, string descripcion, List<Test> testCategorias) : this(idCategoria, descripcion)
        {
            this.TestCategorias = testCategorias;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Categoria);
        }

        public bool Equals(Categoria other)
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
