using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Persona
    {
        private int dni;

        public Persona()
        {

        }

        public Persona(int dni)
        {
            this.dni = dni;
        }

        public int Dni { get => dni; set => dni = value; }
    }
}
