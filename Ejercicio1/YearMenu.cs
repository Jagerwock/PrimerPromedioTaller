using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_08_26_SaenzTarea1
{
    internal class YearMenu
    {
        public void Execute()
        {
            Console.WriteLine("Hola! Introduce un Año");
            string yearInput = Console.ReadLine();

            int year;
            if (int.TryParse(yearInput, out year)) //a tener honestidad: intente con uhhh umm el readline pero me estrellaba le programa asique... :X
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
