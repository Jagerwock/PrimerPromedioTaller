using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cuadrado : Rectangulo
    {
        private int lado;

        public Cuadrado(int lado) : base(lado, lado)
        {
            Nombre = "Cuadrado";
            this.lado = lado;
        }

        public override double CalcularArea()
        {
            return lado * lado;
        }
    }
}
