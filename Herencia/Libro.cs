using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_Libreria_Usando_Herencia
{
    public class Libro : Publicacion //Con esto indico al compilador que Libro es hija de Publicacion
    {
        private int ISBN; //es como un id
        private string autor;

        public Libro(string titulo, string autor, int iSBN, int cantidadDePaginas) :base(titulo, cantidadDePaginas)
        {
            this.fechaDePublicacion = DateTime.Today;
            this.autor = autor;
            this.ISBN = iSBN;
        }

        public string MostrarInformacion()
        {
            return $"{base.MostrarInformacion()} de {this.autor} PORQUE SOY UN LIBRO";
        }


    }
}
