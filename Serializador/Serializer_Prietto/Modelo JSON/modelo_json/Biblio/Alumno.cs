using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Alumno : Persona
    {
        private float nota;

        public Alumno()
        {

        }

        public Alumno(string nombre, int edad, float nota) : base(nombre, edad)
        {
            this.nota = nota;
        }

        public float Nota { get => this.nota; set => this.nota = value; }
    }
}
