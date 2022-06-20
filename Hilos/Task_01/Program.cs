using System;
//Si o si importo esto
using System.Threading.Tasks;
using System.Threading;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio un objeto tipo Task. Dentro, posee una lambda
            //Las tareas ejecutan metodos. Cada Task tiene un tarea para hacer
            //La task es creada, pero no ejecutada.  Esta task es un hilo secundario
            //Los task son SIEMPRE hilos secundarios. Este es un Hilo 2
            //Si saco el sleep, se ejecuta primero ya que el start sigue yendo primero
            //y es tan rapido el start q va antes. 
            //Esta es "la forma chancha" la posta es await
            Task tarea1 = new Task(() =>
                                     {
                                         Thread.Sleep(3000); //demora
                                         Console.WriteLine("Primera tarea");
                                     }
              );

            //Recien aqui ejecuto el hilo secundario. 
            //Ejecuto el hilo secundario desde el principal
            tarea1.Start();

            //Este es el hilo principal
            Console.WriteLine("Segunda tarea");

            Console.WriteLine("Tercera tarea");

            //pido que aguante o sino la app se cierra antes de lso 3 segundos
            //Si muere la task principal, se mueren todas las task.
            //"Si tiras el arbol abajo se caen todas las ramas"
            Thread.Sleep(5000);
        }
    }
}
