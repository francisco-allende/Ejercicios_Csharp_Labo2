using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_Libreria_Usando_Herencia
{
    public class Articulo : Publicacion
    {
        private string editorial;

        public Articulo(string titulo, string editorial, int cantidadDepaginas) : base(titulo, cantidadDepaginas)
        {
            this.editorial = editorial;
        }

        public string MostrarInformacion()      
        {
            return $"{base.MostrarInformacion()} de {this.editorial} PORQUE SOY UN ARTICULO";
        }
    }
}
