using System;
using Biblio;

namespace Modelo_con_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreFile = @"\Porong4.txt";
            string contenido = "Google traduce instantáneamente palabras,\n frases\n y páginas web";
            bool append = true;

            GestionarArchivos arch = new GestionarArchivos();

            arch.Escribir(nombreFile, contenido);
            Console.ReadKey();

            arch.EscribirAContinuacion(nombreFile, "escribo a continuacion", append);
            Console.ReadKey();

            Console.WriteLine(arch.Leer(nombreFile));
            Console.ReadKey();
        }
    }
}
