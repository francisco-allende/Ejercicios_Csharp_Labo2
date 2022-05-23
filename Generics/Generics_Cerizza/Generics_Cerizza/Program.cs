using System;
using Libreria;

namespace Generics_Cerizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Galpon<string> galponPalabras = new Galpon<string>(1, 10, "Words");
            Galpon<int> galponNumeros = new Galpon<int>(2, 15, "Nums");
            Galpon<double> galponFlotantes = new Galpon<double>(3, 22, "Floats");
            Galpon<Avion> hangar = new Galpon<Avion>(4, 3, "Planes");

            Console.WriteLine(galponPalabras.ShowTipoDeDato());
            Console.WriteLine(hangar.ShowTipoDeDato());
            Console.WriteLine(galponFlotantes.ShowTipoDeDato());

            //Uso en retorno
            /*
            try
            {
                int retornaNumero = galponNumeros.PrimerElemento();
                string retornaString = galponPalabras.PrimerElemento();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("No cargaste nada a la lista");
            }
            */


            //Envio por parametro 
            galponFlotantes.GuardarObj(10.5);
            galponPalabras.GuardarObj("Envio un stirng");
            galponNumeros.GuardarObj(12);

            //Clase con 3 tipos de datos distintos
            Inventario<Avion, Auto> inv1 = new Inventario<Avion, Auto>();
            Inventario<Auto, Avion> inv2 = new Inventario<Auto, Avion>();
            //Inventario<float, char, Avion> inv2 = new Inventario<float, char, Avion>(); No puedo usarlo, dije "where T : class" y en este caso no lo es
        }
    }
}
