using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tarea1, 2 y 3 son metodos. Las task estan asociadas a un metodo, a algo q van a hacer
            //Sintaxis sin parentesis.
            //El Run ejecuta. En el ejemplo 1 necesitas un start. El RUN comienza la tarea, llama al metodo.
            //Es como instanciar y llamar el metodo al toque sin esperar nada. Por eso no usamos Start aqui
            //Run ejecuta de una.
            //Run NO espera a que terminen los demas, el 1er mensaje es tarea 2 por tenes un sleep corto
            //
            //
            //
            Task tarea1 = Task.Run(Tarea01);
            Task tarea2 = Task.Run(Tarea02);
            Task tarea3 = Task.Run(Tarea03);

            //Como en el 1, si muere el hilo 1, mato todos los demas
            Thread.Sleep(10000);
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
