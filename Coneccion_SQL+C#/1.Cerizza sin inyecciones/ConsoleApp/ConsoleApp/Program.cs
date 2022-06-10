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
                List<Persona> lista =  ConexionBBDD.Leer("SELECT * FROM personas");
           
                //instancio sin id. Al insertar, lo hara el sql autoincremental ya que id isIdentity
                Persona persona1 = new Persona("Reynaldo");

                //importantisimo las comillas simples ' ' en los values de string
                ConexionBBDD.Insertar($"INSERT INTO personas (Nombre) VALUES ('{persona1.Nombre}')");
   
                
                ConexionBBDD.Eliminar($"DELETE FROM personas WHERE Id = 3");
                lista = ConexionBBDD.Leer("SELECT * FROM personas");
   

                ConexionBBDD.Editar($"UPDATE personas SET Nombre = '{persona1.Nombre}' WHERE Nombre LIKE '%r%'");
                
                //leo la tabla
                lista = ConexionBBDD.Leer("SELECT * FROM personas");
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
