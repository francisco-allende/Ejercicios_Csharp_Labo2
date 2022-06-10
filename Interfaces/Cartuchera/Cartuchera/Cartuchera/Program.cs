using System;
using Biblio;

namespace Cartuchera
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor colorOriginal = Console.ForegroundColor;

            Lapiz miLapiz = new Lapiz(10);
            Boligrafo miBoligrafo = new Boligrafo(20, ConsoleColor.Green);

            //Las llamadas a metodos y properties de interfaz explicitas son de manera explicita
            EscrituraWrapper eLapiz = ((IAcciones)miLapiz).Escribir("Hola");
            Console.ForegroundColor = eLapiz.color;
            Console.WriteLine(eLapiz.texto);
            Console.ForegroundColor = colorOriginal;
            Console.WriteLine(miLapiz);

            EscrituraWrapper eBoligrafo = miBoligrafo.Escribir("Hola");
            Console.ForegroundColor = eBoligrafo.color;
            Console.WriteLine(eBoligrafo.texto);
            Console.ForegroundColor = colorOriginal;
            Console.WriteLine(miBoligrafo);

            //Genial esto. El metodo que llama lanza un throw new exception con un msj personalizado
            //Lo capturo. Si hago throw; || throw ex; rompe la app
            //Por ende, lo que hago es mostrar el mensaje de error Y LISTO!!!!
            try
            {
                ((IAcciones)miLapiz).Recargar(23);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
          
            Console.ReadKey();

            CartucheraMultiuso cartuMulti = new CartucheraMultiuso();
            CartucheraSimple cartuSimple = new CartucheraSimple();

            Lapiz miLapiz1 = new Lapiz(23);
            Lapiz miLapiz2 = new Lapiz(75);
            Lapiz miLapiz3 = new Lapiz(32);
            Boligrafo miBoligrafo2 = new Boligrafo(32, ConsoleColor.Yellow);
            Boligrafo miBoligrafo3 = new Boligrafo(0, ConsoleColor.Blue);
            Boligrafo miBoligrafo4 = new Boligrafo(23, ConsoleColor.DarkMagenta);

            
            cartuMulti.lista.Add(miLapiz);
            cartuMulti.lista.Add(miBoligrafo2);
            cartuMulti.lista.Add(miLapiz1);
            cartuMulti.lista.Add(miLapiz2);
            cartuMulti.lista.Add(miBoligrafo4);
            cartuMulti.lista.Add(miBoligrafo3);
            cartuMulti.lista.Add(miLapiz3);

            Console.WriteLine("Llamo metodo de catuchera multiuso\n" + cartuMulti.RecorrerElementos());

           
            cartuSimple.listaLapiz.Add(miLapiz);
            cartuSimple.listaBoligrafo.Add(miBoligrafo2);
            cartuSimple.listaLapiz.Add(miLapiz1);
            cartuSimple.listaBoligrafo.Add(miBoligrafo3);
            cartuSimple.listaLapiz.Add(miLapiz2);
            cartuSimple.listaBoligrafo.Add(miBoligrafo4);
            cartuSimple.listaLapiz.Add(miLapiz3);

            Console.WriteLine("Llamo metodo de catuchera simple\n" + cartuSimple.RecorrerElementos());

            //tiene que arrojar false porque mande un boligrafo vacio.
            //Si cambio ese boligrafo a un numero mayor, retorna true
            //Conclusion: el programa esta bien hecho
        }
    }
}
