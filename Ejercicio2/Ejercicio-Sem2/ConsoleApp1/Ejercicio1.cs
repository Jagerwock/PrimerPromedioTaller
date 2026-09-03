using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Figura
    {
        public string Nombre { get; set; }

        public Figura(string nombre)
        {
            Nombre = nombre;
        }

        public virtual double CalcularArea()
        {
            return 0;
        }
    }
}
