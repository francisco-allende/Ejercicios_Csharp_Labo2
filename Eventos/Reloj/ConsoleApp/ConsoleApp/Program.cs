using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reloj reloj = new Reloj();
            reloj.Notificar += MostrarTiempoCambiado; 
            reloj.Ejecutar();
            Console.ReadKey();
        }

        //si no es estatico, necesito intanciar un obj para asociarlo +=
        //Este es mi suscriptor
        public static void MostrarTiempoCambiado(object reloj, InfoTiempoEventArgs infoTiempo)
        {
            Console.WriteLine($"{infoTiempo.hora} {infoTiempo.minuto} {infoTiempo.segundo}");
        }
    }
}
