using System;

namespace Biblio
{
    public class Persona
    {
        private string nombre;
        private int id;

        public Persona()
        {

        }

        //Consutructor sin id para cuando inserte ya que el id es autoincremental
        //y no requiere (ni podes) hacerle asignacion
        public Persona(string nombre)
        {
            this.nombre = nombre;
        }

        public Persona(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return $"Nombre: {this.nombre}\nId: {this.id}\n";
        }
    }
}
