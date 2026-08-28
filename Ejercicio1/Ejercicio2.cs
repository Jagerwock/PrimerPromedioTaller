using System;

public class Ejercicio2
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
