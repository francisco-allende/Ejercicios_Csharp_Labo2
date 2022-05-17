using System;
using Mi_Libreria; 

namespace mis_excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //NombreInvalido ex = new NombreInvalido("Nombre invalido rey :/"); No tiene mucho sentido hacer esto anyway
            MiClaseDeInstancia name = new MiClaseDeInstancia("Hola mundo");
            Console.WriteLine(name.Nombre);

            
            
            
            //algo muy bn no esta porque no se muestra lo q deberia
            /*
            try
            {
                MiClaseEstatica.MiMetodoEstatico2("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Exception inner = ex.InnerException;
                while(inner != null)
                {
                    Console.WriteLine(inner.Message);
                }
            }
            /*
            try
            {
                MiClaseEstatica.MiMetodoEstatico("");
            }
            catch (NombreInvalido ex)
            {
                Console.WriteLine(ex.InnerException.Message); //lanza el msj de la inner
                Console.WriteLine(ex.Message); //msg de mi expecion "hija"
            }

            try
            { 
                name.Nombre = " ";
                Console.WriteLine(name.Nombre);
            }
            catch (NombreInvalido ex) //ex, la excepcion a capturar. De la clase especifica q cree yo
            {
                Console.WriteLine(ex.Message); //propiedad q muestra el msj de error
            }
            catch(Exception ex) //catch generico
            {
                Console.WriteLine("Excepcion generica");
            }
            */
        }
    }
}
