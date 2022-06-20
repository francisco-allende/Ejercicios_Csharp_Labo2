using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Task_05
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Task> listaTareas = new List<Task>()
            {
                new Task(Tarea01),
                new Task(Tarea02),
                new Task(Tarea03),
                new Task(Tarea04)
            };

            listaTareas.ForEach((x) => x.Start());

            //Espera a que se terminen de ejecutar todas las tareas. 
            //Espera un array, por eso paso a array la lista.
            Task.WaitAll(listaTareas.ToArray());

            //Lo mismo pero por indice
            // Task.WaitAll(listaTareas[0],listaTareas[1],listaTareas[2]);


            Console.WriteLine("Terminado todo");
        }


        public static void Tarea01()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Tarea 1");

        }
        public static void Tarea02()
        {
            Thread.Sleep(7000);
            Console.WriteLine("Tarea 2");

        }
        public static void Tarea03()
        {
            Thread.Sleep(9000);
            Console.WriteLine("Tarea 3");

        }

        public static void Tarea04()
        {
            Thread.Sleep(11000);
            Console.WriteLine("Tarea 4");

        }
    }
}
