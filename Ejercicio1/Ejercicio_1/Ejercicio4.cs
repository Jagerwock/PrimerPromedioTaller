using System;

namespace Ejercicio_1
{
    internal class Ejercicio4
    {
        {
    public static void Ejecutar()
        {
            string continuar;
            {
                Console.Write("Ingrese el primer número: ")
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ")
                double num2 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese el tipo de operación (+, -, *, /, %): ");
                string operacion = Console.ReadLine();

                switch (operacion)
                {
                    case "+":
                        Console.WriteLine("Resultado: " + (num1 + num2));
                        break;

                    case "-":
                        Console.WriteLine("Resultado: " + (num1 - num2));
                        break;

                    case "*":
                        Console.WriteLine("Resultado: " + (num1 * num2));
                        break;

                    case "/":
                        if (numero2 != 0)
                        {
                            Console.WriteLine("Resultado: " + (num1 / num2));
                        }
                        else
                        {
                            Console.WriteLine("No se puede dividir entre cero.");
                        }
                        break;

                    case "%":
                        if (numero2 != 0)
                        {
                            Console.WriteLine("Resultado: " + (num1 % num2));
                        }
                        else
                        {
                            Console.WriteLine("No se puede dividir entre cero.");
                        }
                        break;

                    default:
                        Console.WriteLine("La operación no válida.");
                        break;
                }
            }
        }
    }
}