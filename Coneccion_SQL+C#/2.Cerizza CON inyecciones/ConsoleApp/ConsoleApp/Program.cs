using System;
using Biblio;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Persona> lista = ConexionBBDD.Leer(2);

                Persona persona1 = new Persona("Javier");

                ConexionBBDD.Insertar(persona1.Nombre);

                ConexionBBDD.Eliminar(9);

                ConexionBBDD.Editar("Roman", 1);

                lista = ConexionBBDD.LeerTodo();
                foreach (Persona item in lista)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
