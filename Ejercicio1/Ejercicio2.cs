internal class Ejercicio2
{
    public static void Ejecutar()
    {
        Console.Write("Ingresar la base: ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("Ingresar la altura: ");
        float h = float.Parse(Console.ReadLine());

        triangulo t = new triangulo(b, h);

        Console.WriteLine($"Area: {t.CalcularArea()}");
    }
}