using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Alumno : Persona
    {
        private List<string> materias;
        private float nota;

        //El XML pide si o si un constructor sin parametros
        public Alumno()
        {

        }

        public Alumno(string nombre, int edad, float nota) : base(nombre, edad)
        {
            this.nota = nota;
            this.materias = new List<string>();
        }

        //Si o si las properties, el XML los usa como tags
        public List<string> Materias { get => this.materias; set => this.materias = value; }
        public float Nota { get => this.nota; set => this.nota = value; }
    }
}
