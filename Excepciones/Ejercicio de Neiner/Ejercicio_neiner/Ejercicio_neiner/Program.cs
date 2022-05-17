using System;
using Biblioteca;

namespace Ejercicio_neiner
{
    class Program
    {
        static void Main(string[] args)
        {
            OtraClase otraClase = new OtraClase(); 
            string mensaje = string.Empty;

            try
            {
                otraClase.MetodoDeInstancia(); //1)
            }
            catch (Exception e) //16) generico porque recorri bocha. Capture todas.
            {
                Exception aux = e;
                do //17) itero con do while ya que tuve 3 excepciones. Lo hago hasta q sea null, que es cuando no hay mas
                {
                    mensaje = aux.Message + "\n" + mensaje; //18) recien aca muestro los msjs
                    aux = aux.InnerException;

                } while (aux is not null);
                Console.WriteLine(mensaje);
            }
            Console.ReadKey();
        }
    }
}
