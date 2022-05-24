using System;

namespace Entidades
{
    public class Documento
    {
        private int numero;

        public Documento(int numero)
        {
            this.numero = numero;
        }

        public override string ToString()
        {
            return $"Numero: {this.numero}";
        }

        public int castMeDaddy()
        {
            return this.numero;
        }
    }
}
