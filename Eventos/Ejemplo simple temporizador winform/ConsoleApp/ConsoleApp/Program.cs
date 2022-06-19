using System;
using Biblio;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Temporizador temp = new Temporizador();
            //Suscribo el evento al metodo
            temp.OnSegundosRestantes += NotificarSegundos;
            temp.OnTiempoFinalizado += NotificarTiempoCumplido;
            temp.Ejecutar(3);
        }

        private static void NotificarTiempoCumplido()
        {
            Console.WriteLine("\nEl temporizador llego a cero, tiempo cumplido!");
        }

        private static void NotificarSegundos(int sec)
        {
            Console.WriteLine($"Pasaron {sec} segundos\n");
        }
    }
}
