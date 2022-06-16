using System;

namespace Biblio
{
    public class Juego
    {
        private int codigoJuego;
        private int codigoUsuario;
        private string genero;
        private string nombre;
        private double precio;

        public Juego(string nombre, double precio, string genero, int codigoJuego, int codigoUsuario)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.genero = genero;
            this.codigoJuego = codigoJuego;
            this.codigoUsuario = codigoUsuario;
        }

        //Para el insert
        public Juego(string nombre, double precio, string genero, int codigoUsuario)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.genero = genero;
            this.codigoUsuario = codigoUsuario;
        }

        public Juego()
        {

        }

        public int CodigoJuego { get => codigoJuego;}
        public int CodigoUsuario { get => codigoUsuario;}
        public string Genero { get => genero;}
        public string Nombre { get => nombre;}
        public double Precio { get => precio;}
    }
}
