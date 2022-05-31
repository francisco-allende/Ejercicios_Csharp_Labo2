using System;
using Biblio;

namespace modelo_json
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona alumno1 = new Alumno("fran", 22, 10);
            Persona maestro = new Maestro("baus", 45, 80000);

            /*No las toma porque le envie una persona. Por eso solo toma properties de la persona
            ((Alumno)alumno1).Materias.Add("Matematica");
            ((Alumno)alumno1).Materias.Add("Labo II");
            ((Alumno)alumno1).Materias.Add("falopaaaaaaa");
            */
            alumno1.Materias.Add("Matematica");
            alumno1.Materias.Add("Labo II");
            alumno1.Materias.Add("falopaaaaaaa");

            Serializador.SerializadorJson("miJson1.json", alumno1);
            //Serializador.SerializarJsonConFile("miJson2ConFile.json", alumno1);
            Console.WriteLine("Ya serialize");

            Persona personaDelJson = Serializador.DeserealizarJson("miJson1.json", alumno1);
            Console.WriteLine(personaDelJson.Nombre + " " + personaDelJson.Edad);

            Console.ReadKey();
        }
    }
}
