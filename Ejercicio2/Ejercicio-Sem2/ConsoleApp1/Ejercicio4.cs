using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Circulo : Figura 
    {
        private double radio;
        public Circulo(double radio) 
        {
            Nombre = "Circulo";
            this.radio = radio;
        }

        public override double CalcularArea() 
        {
            return Math.PI * radio * radio;
        }
    }   

}
