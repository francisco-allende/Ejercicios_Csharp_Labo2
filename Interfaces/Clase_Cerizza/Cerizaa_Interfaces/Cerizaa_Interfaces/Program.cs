using System;
using Biblio;
using System.Collections.Generic;

namespace Cerizaa_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Paloma paloma = new Paloma("Azir", "Shurima");
            Courier courier = new Courier("Vault", "Deleuze", "98765");
            Carta carta = new Carta("A4", 1, "pampam");
            Email email = new Email("perereto@gamil.com");

            //Lista de tipo interfaz IMensaje
            List<IMensaje> mensajes = new List<IMensaje>(); 

            //Solo puedo añadirlos si su clase implementan IMensaje.
            //Guardo elementos muy distintos en una misma lista
            mensajes.Add(email);
            mensajes.Add(paloma);
            mensajes.Add(courier);
            mensajes.Add(carta);

            //Cada item de la lista muestra su distinto mensaje
            foreach (IMensaje item in mensajes)
            {
                Console.WriteLine(item.EnviarMensaje());
            }

            Cuervo cuervo = new Cuervo();

            //Uso una interfaz explicita. Casteo
            Console.WriteLine(((IEncriptado)cuervo).EnviarMensaje());

            //Usando la interfaz abstracta
            ClassPrueba test = new ClassPrueba();
            Courier courier2 = test.MostrarPersona<Paloma>(paloma);
        }
    }
}
