using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Rectangulo : Figura
    {
        public int Base;
        public int Altura;

        public Rectangulo(int b, int h) : base("Rectangulo")
        {
            Base = b;
            Altura = h;
        }

        public override double CalcularArea()
        {
            return Base * Altura;
        }
    }
}
