using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public delegate int BuscarMayorNumero(List<int> lista);
    
    class Program
    {
        static void Main(string[] args)
        {
            List<int> miLista = new List<int>();
            miLista.Add(09);
            miLista.Add(33);
            miLista.Add(22);
            miLista.Add(10);

            //Forma 1 declar antes, luego instancio asociando metodo
            BuscarMayorNumero funcionBuscar = BuscandoANemo;
            Console.WriteLine($"El mayor nro es {funcionBuscar(miLista)}");

            //Forma 2 creo el delegdo en tiempo real, una funcion anonima
            BuscarMayorNumero funcionDos = delegate (List<int> lista)
            {
                return lista.Find((x) => x > 1);
            };
            Console.WriteLine($"El primer numero mayor a 1 es {funcionDos(miLista)}");

            //Forma 3, con lambda
            BuscarMayorNumero funcionLambda = unaLista => unaLista.Count;
            Console.WriteLine($"La cantidad de elementos de la lista es {funcionLambda(miLista)}");

            //Al ser enviado como parametro, puedo enviarle cualquier funcion
            //que un delegado de tipo BuscarMayorNumero haya tenido
            Persona person = new Persona();
            person.Registrar(funcionLambda, miLista);

        }

        public static int BuscandoADory(List<int> lista)
        {
            return lista.Find((x) => x > 20);
        }

        public static int BuscandoANemo(List<int> lista)
        {
            return lista.Find((x)=> x > 20);
        }
    }

    public class Persona
    {
        public void Registrar(BuscarMayorNumero fn, List<int> lista)
        {
            Console.WriteLine("Me registro en la bbdd");
            int id = fn(lista);
            Console.WriteLine("envioo de mail con confirmacion a usuario de id: " + id);
        }
    }

}
