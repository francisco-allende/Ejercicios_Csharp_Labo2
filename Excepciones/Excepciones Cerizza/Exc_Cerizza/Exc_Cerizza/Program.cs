using System;

namespace Exc_Cerizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayPalabras = new string[3] { "pepe", "manu", "iorio" };
            /*
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("El nombre es: " + arrayPalabras[i]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message + " Flasheaste perriki");
            }
            */

            //Forzando un error con throw
            try
            {
                BuscarPalabra(""); //(1) Llamo
            }
            catch (ArgumentNullException ex) //(4) Capturo
            {
                Console.WriteLine(ex.Message); //(5) Muestro
            }
        }
  

        public static string BuscarPalabra(string word)
        {
            if (word == string.Empty) //2) Valido 
            {
                throw new ArgumentNullException("No se aceptan palabras vacias"); //(3) Fuerzo el error

            }
            else
            {
                //Lo que sea. Si hay error, jamas se ejecuta
            }

            return "";
        }

    }
}
