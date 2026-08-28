using System;

class Ejercicio5
{
    public static void Execute()
    {
        string continuar;
        do
        {
            Console.Write("ingresa la primera variable: ")
            double numero1 = double.Parse(Console.ReadLine());

            Console.Write("ingresa la segunda variable: ")
            double numero2 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la operación (+, -, *, /, %): ");
            string operacion = Console.ReadLine();

            switch (operacion)
            {
                case "+":
                    Console.WriteLine("Resultado: " + (numero1 + numero2));
                    break;

                case "-":
                    Console.WriteLine("Resultado: " + (numero1 - numero2));
                    break;

                case "":
                    Console.WriteLine("Resultado: " + (numero1 numero2));
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