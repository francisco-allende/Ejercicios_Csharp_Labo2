using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_Libreria
{
    public class MiClaseDeInstancia
    {
        private string nombre;

        public MiClaseDeInstancia(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new NombreInvalido("Nombre invalido rey");
                }

                this.nombre = value;
            }
        }
    }
}
