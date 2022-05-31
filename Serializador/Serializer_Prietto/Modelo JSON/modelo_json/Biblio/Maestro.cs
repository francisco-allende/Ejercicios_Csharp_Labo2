using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Maestro : Persona
    {
        private float salario;

        public Maestro()
        {

        }

        public Maestro(string nombre, int edad, float salario) : base(nombre, edad)
        {
            this.salario = salario;
        }

        public float Salario { get => this.salario; set => this.salario = value; }
    }
}
