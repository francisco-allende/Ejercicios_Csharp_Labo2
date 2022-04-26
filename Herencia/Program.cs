using System;
using Mi_Libreria_Usando_Herencia;
using System.Collections.Generic;

namespace Herencia_Prietto
{
    class Program
    {
        static void Main(string[] args)
        {
            Publicacion publicacion = new Publicacion("Batman", 50);
            Libro libro = new Libro("Los cuentos de la selva", "Horacio Quiroga", 1234567891, 120);
            Libro libro2 = new Libro("El señor de los anillos", "JJ Tolkien", 1234567892, 600);
            Libro libro3 = new Libro("Cuentos de amor, locura y de muertes", "Horacio Quiroga", 1234567893, 200);
            Libro libro4 = new Libro("Juego de tronos", "George Martin", 1234567894, 550);

            Articulo articulo1 = new Articulo("UTN", "Herencias en C#", 1250);


            //Lista de tipo publicacion, acepta sus clases derivadas
            List<Publicacion> listaPublicacion = new List<Publicacion>();

            //La propiedad get Tiyulo es accedible por ambos
            Console.WriteLine(publicacion.Titulo +" "+libro.Titulo);

            //Metodo accedible por ambos. Principio Liskov, Libro es Libro y Publicacion a al vez.
            Console.WriteLine(publicacion.MostrarInformacion());
            Console.WriteLine(libro.MostrarInformacion());

            listaPublicacion.Add(libro);
            listaPublicacion.Add(libro2);
            listaPublicacion.Add(libro3);
            listaPublicacion.Add(libro4);
            listaPublicacion.Add(articulo1);

            //El if esta porque sino el metodo mostrar informacion especifico del objeto Libro o Articulo no salta,
            //Sino que salta el especifico de Publicacion. Casteo el item
            foreach (Publicacion item in listaPublicacion)
            {
                if(item is Libro)
                {
                    Console.WriteLine(((Libro)item).MostrarInformacion());
                }
                else
                {
                    Console.WriteLine(((Articulo)item).MostrarInformacion());
                }
            }
        }
    }
}
