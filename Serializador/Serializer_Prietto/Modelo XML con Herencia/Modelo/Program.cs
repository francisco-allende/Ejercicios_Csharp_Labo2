using System;
using Biblio;

namespace Modelo
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona alumno1 = new Alumno("Roque perez", 26, 7.8f);

            Serializadora.Serialziar("Persona_serializado_Herencia.xml", alumno1);          
        }

    }
}
