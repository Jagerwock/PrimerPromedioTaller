using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ejercicio2 : Figura
    {
        public int Base;
        public int Altura;

        public Rectangulo(int b, int h) : base("Rectangulo")
        {
            Base = b;
            Altura = h;
        }

        public override int Area()
        {
            return Base * Altura;
        }
    }
}
