using System;

namespace Mi_Libreria_Usando_Herencia
{
    public class Publicacion
    {
        protected string titulo;
        protected int cantidadDePaginas;
        protected DateTime fechaDePublicacion;

        public Publicacion(string titulo, int cantidadDePaginas)
        {
            this.titulo = titulo;
            this.cantidadDePaginas = cantidadDePaginas;
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
        }

        public int CantidadDePaginas
        {
            get
            {
                return this.cantidadDePaginas;
            }
            set
            {
                this.cantidadDePaginas = value;
            }
        }

        public DateTime FechaDePublicacion
        {
            get
            {
                return this.fechaDePublicacion;
            }
        }

        public string MostrarInformacion()
        {
            return $"Titulo: {this.Titulo} Cantidad de pagina: {this.CantidadDePaginas}" +
                $" Publicado el {this.FechaDePublicacion}";
        }
    }
}
