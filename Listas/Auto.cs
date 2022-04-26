using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Arrays
{
    public class Auto
    {
        private string patente;
        private string marca;
        public int modelo;

        public Auto(string patente, string marca, int modelo)
        {
            this.patente = patente;
            this.marca = marca;
            this.modelo = modelo;
        }

        public static int Comparacion(Auto a, Auto b)
        {
            return a.modelo - b.modelo; 
        }

        public static int ComparacionMayorAMenor(Auto a, Auto b)
        {
            return b.modelo - a.modelo; 
        }

        public string Mostrar()
        {
            return $"{this.patente} {this.marca} {this.modelo}";
        }
    }
}
