using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Triangulo : Figura
    {
        private int b;
        private int h;

        public Triangulo(int b, int h) : base("Triangulo")
        {
            this.b = b;
            this.h = h;
        }

        public override float CalcularArea()
        {
            return (b * h) / 2f;
        }
    }
}
