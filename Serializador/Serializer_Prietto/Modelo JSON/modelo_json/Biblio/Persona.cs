using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Persona
    {
        protected string nombre;
        protected int edad;
        private List<string> materias;

        public Persona()
        {

        }

        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.materias = new List<string>();
        }

        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public int Edad { get => this.edad; set => this.edad = value; }
        public List<string> Materias { get => this.materias; set => this.materias = value; }
    }
}
