using System;
using Biblio;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Temporizador temp = new Temporizador();
            //a la instancia de este temporizador, le asocio el metodo al evento
            //el evento se activa cuando el contador de segundos llega a cero
            temp.OnTiempoFinalizado += NotificarTiempoCumplido; 
            temp.Ejecutar(3);
            //Opcional. Lo desacoplo.
            temp.OnTiempoFinalizado -= NotificarTiempoCumplido;
        }

        private static void NotificarTiempoCumplido()
        {
            Console.WriteLine("El temporizador llego a cero, tiempo cumplido!");
        }
    }
}
