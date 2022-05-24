using System;
using System.Text;

namespace Biblio
{
    public class Juguete
    {
        private string marca;
        private double precio;

        public Juguete(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        private string Mostrar()
        {
            return $"Marca del juguete: {this.marca}\nPrecio del juguete: {this.precio}";
        }

        public override string ToString()
        {
            return this.Mostrar();
        }


    }
}
