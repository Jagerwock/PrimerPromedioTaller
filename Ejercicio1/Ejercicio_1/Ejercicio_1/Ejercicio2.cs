using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class triangulo
    {
        private float b;
        private float h;

        public triangulo(float b, float h)
        {
            this.b = b;
            this.h = h;
        }

        public float CalcularArea()
        {
            return (b * h) / 2;
        }
    }
}
