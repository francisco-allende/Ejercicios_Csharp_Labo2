using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lista de tasks con sus metodos. Instancio, pero no ejecuto
            List<Task> listaTareas = new List<Task>()
            {
                new Task(Tarea01),
                new Task(Tarea02),
                new Task(Tarea03),
            };

            //Lambda!!! Ejecuta cada task. X es cada item.
            //En vez de run, uso start para ejecutar cuando sea necesario y no de inmediato
            listaTareas.ForEach((x) => x.Start());

            Thread.Sleep(7000);

            //EJEMPLOS LAMBDA UTILES 

            //nombres.ForEach((nomb) => nomb.ToString());

            //List<string> dato = nombres.FindAll(x => x.Length == 6);

            //bool existe = nombres.Exists(x => x == "Pepe");
        }

        public static void Tarea01()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Tarea 1");

        }
        public static void Tarea02()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Tarea 2");

        }
        public static void Tarea03()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Tarea 3");

        }
    }
}
