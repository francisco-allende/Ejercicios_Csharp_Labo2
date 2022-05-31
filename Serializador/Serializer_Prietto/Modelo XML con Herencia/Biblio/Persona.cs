using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Biblio
{
    //Le indico que al momento de serialziar tiene que incluir la clase que lo hereda
    [XmlInclude(typeof(Alumno))]
    public class Persona
    {
        protected string nombre;
        protected int edad;

        public Persona()
        {

        }

        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public int Edad { get => this.edad; set => this.edad = value; }
    }
}
