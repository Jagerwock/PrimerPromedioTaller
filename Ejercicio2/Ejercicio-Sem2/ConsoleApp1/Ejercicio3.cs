using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ejercicio3 : Ejercicio2
    {
        private int Lado1;
        private int Lado2;
        public Cuadrado (int L1, int L2)
        {
            this.Lado1 = L1;
            this.Lado2 = L2;
        }
        public override float CalcularArea()
        {
            return L1 * L2;
        }
    }
}
