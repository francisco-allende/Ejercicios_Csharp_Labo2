using System;
using System.Collections.Generic;

namespace Biblio
{
    public class Persona
    {
        private int id;
        private string nombre;
        private string apellido;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Persona()
        {

        }

        //instancio yo
        public Persona(int id, string nombre, string apellido)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        //insert del sql
        public Persona(string nombre, string apellido)
        {

        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Nombre: {this.Nombre}, Apellido: {this.Apellido}"; 
        }

        public static bool SearchById(int id, List<Persona> lista)
        {
            foreach (Persona item in lista)
            {
                if (id == item.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
