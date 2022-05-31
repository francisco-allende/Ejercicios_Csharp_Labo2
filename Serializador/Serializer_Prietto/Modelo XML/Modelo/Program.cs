using System;
using Biblio;

namespace Modelo
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno1 = new Alumno("Roque perez", 26);
            alumno1.Materias.Add("Matematica");
            alumno1.Materias.Add("Programacion II");
            alumno1.Materias.Add("Laboratorio II");
            alumno1.Materias.Add("Falopita");
            alumno1.Materias.Add("Ingles II");

            Serializadora.Serialziar("alumno_serializado.xml", alumno1);
            Console.WriteLine("Ya serialize");
            Console.ReadKey();

            Alumno alumnoDes = Serializadora.Deserializar("alumno_serializado.xml", alumno1);
            Console.WriteLine("Nombre: " + alumnoDes.Nombre);
            Console.WriteLine("Edad: " + alumnoDes.Edad);
            Console.ReadKey();

            //Modifico los datos y lo vuelvo a enviar al XML
            alumnoDes.Nombre = "Gabirel";
            alumnoDes.Edad = 19;
            Serializadora.Serialziar("alumno_serializado.xml", alumnoDes);

            Console.ReadKey();
        }
    }
}
