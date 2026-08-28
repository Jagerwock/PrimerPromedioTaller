using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Ejercicio5
    {
        public static void Ejecutar()
        {
            string continuar;

            do
            {
                Console.Write("Ingresa la primera variable: ");
                double numero1 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese la segunda variable: ");
                double numero2 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese una operación (+, -, *, /, %): ");
                string operacion = Console.ReadLine();

                switch (operacion)
                {
                    case "+":
                        Console.WriteLine("Resultado: " + (numero1 + numero2));
                        break;

                    case "-":
                        Console.WriteLine("Resultado: " + (numero1 - numero2));
                        break;

                    case "*":
                        Console.WriteLine("Resultado: " + (numero1 * numero2));
                        break;

                    case "/":
                        if (numero2 != 0)
                        {
                            Console.WriteLine("Resultado: " + (numero1 / numero2));
                        }
                        else
                        {
                            Console.WriteLine("No se puede dividir entre cero.");
                        }
                        break;

                    case "%":
                        if (numero2 != 0)
                        {
                            Console.WriteLine("Resultado: " + (numero1 % numero2));
                        }
                        else
                        {
                            Console.WriteLine("No se puede dividir entre cero.");
                        }
                        break;

                    default:
                        Console.WriteLine("Operación no válida.");
                        break;
                }

                Console.Write("¿Desea realizar otra operación? (s/n): ");
                continuar = Console.ReadLine().ToLower();

                Console.WriteLine();

            }

            while (continuar == "s");
        }
    }
}
