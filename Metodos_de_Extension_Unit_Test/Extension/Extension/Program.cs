using System;
using Library;

namespace Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Hola Mundo Cruel";
            int cantidadPalabras = texto.ContarPalabras();

            //int cantidadPalabras = StringExtendido.ContarPalabras(texto); esto es lo que realmente sucede. 

            Console.WriteLine(texto + " Posee " + cantidadPalabras + " palabras.");

            int nroFizBuzz = 50;
            Console.WriteLine(nroFizBuzz.FizzBuzz());
        }
    }
}
