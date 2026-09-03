using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ejercicio6
    {
        public void Ejecutar()
        {
            List<Figura> figuras = new List<Figura>();

            int opcion = 0;

            while (opcion != 6)
            {
                Console.WriteLine();
                Console.WriteLine("1. Agregar Rectangulo");
                Console.WriteLine("2. Agregar Cuadrado");
                Console.WriteLine("3. Agregar Circulo");
                Console.WriteLine("4. Agregar Triangulo");
                Console.WriteLine("5. Ver Figuras");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.Write("Ingrese la base: ");
                    int b = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese la altura: ");
                    int h = Convert.ToInt32(Console.ReadLine());

                    Rectangulo rectangulo = new Rectangulo(b, h);
                    figuras.Add(rectangulo);
                }
                else if (opcion == 2)
                {
                    Console.Write("Ingrese el lado: ");
                    int lado = Convert.ToInt32(Console.ReadLine());

                    Cuadrado cuadrado = new Cuadrado(lado);
                    figuras.Add(cuadrado);
                }
                else if (opcion == 3)
                {
                    Console.Write("Ingrese el radio: ");
                    double radio = Convert.ToDouble(Console.ReadLine());

                    Circulo circulo = new Circulo(radio);
                    figuras.Add(circulo);
                }
                else if (opcion == 4)
                {
                    Console.Write("Ingrese la base: ");
                    int b = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese la altura: ");
                    int h = Convert.ToInt32(Console.ReadLine());

                    Triangulo triangulo = new Triangulo(b, h);
                    figuras.Add(triangulo);
                }
                else if (opcion == 5)
                {
                    Console.WriteLine();

                    foreach (Figura figura in figuras)
                    {
                        Console.WriteLine("Figura: " + figura.Nombre);
                        Console.WriteLine("Area: " + figura.CalcularArea());
                        Console.WriteLine();
                    }
                }
                else if (opcion == 6)
                {
                    Console.WriteLine("Saliendo...");
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                }
            }
        }
    }
}
