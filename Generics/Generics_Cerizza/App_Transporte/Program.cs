using System;
using Libreria;

namespace App_Transporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario<Persona, Avion> inventarioPersonas = new Inventario<Persona, Avion>();
            Inventario<Juguete, Auto> inv2 = new Inventario<Juguete, Auto>();
        }
    }
}
