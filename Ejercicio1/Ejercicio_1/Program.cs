using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("===== EJERCICIOS =====");
                Console.WriteLine("1. Área y perímetro de un rectángulo");
                Console.WriteLine("2. Área de un triángulo");
                Console.WriteLine("3. Año bisiesto");
                Console.WriteLine("4. Calculadora simple");
                Console.WriteLine("5. Calculadora continua");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Ejercicio1.Ejecutar();
                        break;

                    case 2:
                        Ejercicio2.Ejecutar();
                        break;

                    case 3:
                        Ejercicio3 ejercicio3 = new Ejercicio3();
                        ejercicio3.Execute();
                        break;

                    case 4:
                        Ejercicio4.Ejecutar();
                        break;

                    case 5:
                        Ejercicio5.Ejecutar();
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != 0);
        }
    }
}
