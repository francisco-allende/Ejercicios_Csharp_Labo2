using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Como crear una task y usarla
             */


            //Forma 1, con delegado action
            Action acc = MuestroMensaje;
            Task tarea1 = new Task(acc);
            Thread.Sleep(2000);
            tarea1.Start();
            Console.ReadKey();

            //Forma 2, directo codeo en la task
            Console.WriteLine("Giro la llave del auto");

            Task tarea2 = new Task(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Forma 2. Arranco el auto");
            });

            tarea2.Start();
            Console.ReadKey();

            //3era forma, Run directo, no usa Start ni necesito crear la task per se.
            Task.Run(() => 
            {
                Thread.Sleep(2000);
                Console.WriteLine("Forma 3. Ejecutado el Run!");
            });
            Console.ReadKey();
            LlamadsoAsincrono();
            Console.ReadKey();
        }

        public static async void LlamadsoAsincrono()
        {
            //4ta forma. Async await. Lo tuve que pasar a un metodo async, main no puedo
            //Si o si desde un metodo asincrono a otro asincrono.
            //Al llamar a las funciones, si o si await
            int r = await RandomAsync();
            string word = await RandomWord();
            int r2 = await TareaConParams(222, 3);
            Console.WriteLine(r + " " + r2 + " " + word);
        }

        //metodo asincrono. Uso el await para arrancarlo. Lo mismo para el Run
        // Tiene un <generic> con el tipo de dato que retorna la tarea
        public static async Task<int> RandomAsync()
        {
            var task = new Task<int>(() => new Random().Next(1000));
            task.Start();
            return await task; //banca a que termine y retorna el nro random
        }

        //Con parametros, super facil. A la task no le meto nada, ya reconoce
        //los parametros que recibe la funcion
        public static async Task<int> TareaConParams(int a, int b)
        {
            Thread.Sleep(2000);
            return await Task.Run(() => a * b);
        }

        public static async Task<string> RandomWord()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });

            return "Porotos negros. Forma 4 async - await, con y sin params";
        }

   

        public static void MuestroMensaje()
        {
            Console.WriteLine("Forma 1. Tarea finalizada");
        }
    }
}
