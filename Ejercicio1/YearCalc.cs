using System;

public class Class1
{
	public Class1()
    {
    public void Execute()
    {
        Console.WriteLine("Hola! Introduce un Año");
        string yearInput = Console.ReadLine();

        int year;
        if (int.TryParse(yearInput, out year)) //a tener honestidad: intente con uhhh umm el readline pero me estrellaba le programa asique... :X
            //De lo khe yo entiendo, tryparse es "intenta descubrir un numero de este string!"
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                Console.WriteLine("Es bisiesto!");
            }
            else
            {
                Console.WriteLine("No es bisiesto!");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida para el año.");
        }
    }
}


         
    
}

