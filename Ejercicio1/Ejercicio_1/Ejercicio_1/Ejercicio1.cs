using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Ejercicio1
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Ingresar la base: ");
            float base1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Ingresar la altura: ");
            float altura = float.Parse(Console.ReadLine());

            float area = base1 * altura;
            float perimetro = 2 * (base1 + altura);

            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimetro {perimetro}");
        }
    }
}
