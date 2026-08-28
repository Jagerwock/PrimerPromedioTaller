using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Ejercicio2
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese la base: ");
            double baseTriangulo = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la altura: ");
            double altura = double.Parse(Console.ReadLine());

            double area = (baseTriangulo * altura) / 2;

            Console.WriteLine("Área: " + area);
        }
    }
}
