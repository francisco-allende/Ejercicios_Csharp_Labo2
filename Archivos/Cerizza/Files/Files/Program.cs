using System;
using Biblio;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Archivo.Escribir();
            Archivo.EscribirEnUnArchivoYaExistenteSinPisarlo();
            Console.WriteLine("el txt dice: \n" + Archivo.Leer());





            //Archivo.UsandoPropertiesDelSistema(); descomentar para ver data del sistema
        }
    }
}
