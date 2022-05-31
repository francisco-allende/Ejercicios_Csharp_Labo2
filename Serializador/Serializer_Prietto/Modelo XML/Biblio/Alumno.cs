using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Alumno
    {
        private string nombre;
        private int edad;
        private List<string> materias;

        //El XML pide si o si un constructor sin parametros
        public Alumno()
        {

        }

        public Alumno(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.materias = new List<string>();
        }

        //Si o si las properties, el XML los usa como tags
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public int Edad { get => this.edad; set => this.edad = value; }
        public List<string> Materias { get => this.materias; set => this.materias = value; }
    }
}
