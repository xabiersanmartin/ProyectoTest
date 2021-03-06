﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Test : IEquatable<Test>
    {

        public int idTest { get; set; }
        public string Descripcion { get; set; }

        public List<Pregunta> PreguntasTest = new List<Pregunta>();



        public Test()
        {
        }

        public Test(string descripcion)
        {
            Descripcion = descripcion;
        }

        public Test(int idTest, string descripcion, List<Pregunta> preguntasTest)
        {
            this.idTest = idTest;
            Descripcion = descripcion;
            this.PreguntasTest = preguntasTest;
        }

        public Test(int idTest)
        {
            this.idTest = idTest;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Test);
        }

        public bool Equals(Test other)
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
