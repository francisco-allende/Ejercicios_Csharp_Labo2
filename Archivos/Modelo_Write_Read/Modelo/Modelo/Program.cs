using System;
using Biblio;

namespace Modelo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreFile = @"\Porong4.txt";
            string contenido = "Google traduce instantáneamente palabras,\n frases\n y páginas web";
            bool append = true;

            GestionarArchivos.Escribir(nombreFile, contenido);
            Console.ReadKey();

            GestionarArchivos.EscribirAContinuacion(nombreFile, "escribo a continuacion", append);
            Console.ReadKey();

            Console.WriteLine(GestionarArchivos.Leer(nombreFile));
            Console.ReadKey();
        }
    }
}
