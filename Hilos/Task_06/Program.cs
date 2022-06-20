using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quizas quiero cancelar la tarea por algun motivo, como x ej que tarde mucho.
            //Cancelo la tarea. 
            //Uso este objeto que se lo pasamos por parametro a la tarea para cancelarla. Instancio
            //Cada Token posee asociado un id unico. Accedo con la propertie "Token"
            //Esta propertie Token de este objeto CancellationTokenSource es lo que envio por parametro
            //A la Task que pueda llegar a cancelar. Pasarla no la cancela de por si, necesito
            //Que mi variable con el token llame al método cancel

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            //Lo mismo de Otra forma, lo guardo en una var
            //   CancellationToken ct = cancelTokenSource.Token;
            //  Task tarea2 = Task.Run(() => Tarea02(ct));
            // ct.Cancel();


            Task tarea1 = Task.Run(Tarea01);

            //La tarea 2 y 4 reciben el token. Este debe ser activado
            //Pasar el token no cancela la tarea per se, debe ser activado
            Task tarea2 = Task.Run(() => Tarea02(cancelTokenSource.Token));

            Task tarea3 = Task.Run(Tarea03);

            Task tarea4 = Task.Run(() => Tarea04(cancelTokenSource.Token));

            Thread.Sleep(3000);

            //RECIEN ACA CANCELO DE VERDAD. Por eso la validacion,
            //porque debo ejecutar este metodo cancel para cancelar todo los q tnegan este token
            cancelTokenSource.Cancel();


            Task.WaitAll(tarea1, tarea2, tarea3, tarea4);

            Console.WriteLine("Terminado todo");
        }


        public static void Tarea01()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Tarea 1");

        }
        public static void Tarea02(CancellationToken cancelToken)
        {
            int i = 1;
            while (true) //Esto es infinito, siempre seguira hasta que cancele la task
            {
                //Valido. Si es true, cancela (sucede cuando el token llame a Cancel)
                if (!cancelToken.IsCancellationRequested)
                {

                    Thread.Sleep(500);
                    Console.WriteLine("Tarea 2 : " + i);
                    i++;
                }
                else
                {
                    Console.WriteLine("tarea 2 cancelada");
                    return;
                }

            }

        }
        public static void Tarea03()
        {
            Thread.Sleep(9000);
            Console.WriteLine("Tarea 3");

        }
        public static void Tarea04(CancellationToken cancelToken)
        {

            Thread.Sleep(5000);
            //Lo mismo que el 2, valido que vaya a cancelarla
            //(Se cancela recien con el metodo cancel)
            if (cancelToken.IsCancellationRequested)
            {
                Console.WriteLine("Tarea 4 cancelada");

                return;
            }
            Console.WriteLine("Tarea 4"); //esta linea se ejecuta hasta q el token llame al cancel

        }
    }
}
