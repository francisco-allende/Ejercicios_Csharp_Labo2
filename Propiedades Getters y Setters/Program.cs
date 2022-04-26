using System;
using System.Collections.Generic;

namespace Getter_Y_Setters
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador miJugador = new Jugador(12345, "Messi", 100, 50);
            Jugador miJugador2 = new Jugador(789, "meempapé", 10, 1);

            //Console.WriteLine(miJugador.); No puedo acceder a ningun atributo, son priv

            //Getter
            int dni = miJugador.Dni;
            Console.WriteLine($"get Dni en variable {dni} get Dni directo de la propiedad {miJugador.Dni}");
            Console.WriteLine("Promedio goles " + miJugador.PromedioGoles);


            //Setter
            miJugador.Dni = 666;
            Console.WriteLine($"Settie el valor de DNI cambiandolo {miJugador.Dni}");

            miJugador.Nombre = "Messirve";
            Console.WriteLine(miJugador.Nombre);

            //////////////
            ///for each. Meto jugadores, getteo sus atributos y los muestro
            List<Jugador> jugadorsList = new List<Jugador>();

            jugadorsList.Add(miJugador);
            jugadorsList.Add(miJugador2);

            int dnii;
            string nombre;
            float promedio;

            foreach (Jugador unJugador in jugadorsList)
            {
                dnii = unJugador.Dni;
                nombre = unJugador.Nombre;
                promedio = unJugador.PromedioGoles;

                Console.WriteLine(dnii);
                Console.WriteLine(nombre);
                Console.WriteLine(promedio);
                Console.WriteLine("\n\n");
            }

            //////
            //uso setter y getter pero con un enum
            miJugador.ColorCamiseta = Color.Azul;
            Color getColor = miJugador.ColorCamiseta;
            Console.WriteLine(getColor);
        }
    }
}
