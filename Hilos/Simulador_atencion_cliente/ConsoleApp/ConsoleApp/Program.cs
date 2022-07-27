using System;
using Biblio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Otra manera. Yo lo hice directo con action
            /*Caja.DelegadoClienteAtendido funcMsj = (c, s) =>
            {
                Console.WriteLine($"{DateTime.Now} - Hilo {Task.CurrentId} - {c.NombreCaja} - Atendiendo a - Quedan {c.CantidadDeClientesALaEspera} clientes en esta caja");
            };
            */

            Action<Caja, string> funcMsj = (caja, cliente) =>
            {
                Console.WriteLine($"{DateTime.Now:HH:MM:ss} - Hilo {Task.CurrentId} - {caja.NombreCaja} - Atendiendo a: {cliente} - Quedan {caja.CantidadDeClientesALaEspera} clientes en esta caja");
            };

            Caja caja1 = new Caja("Caja 01", funcMsj);
            Caja caja2 = new Caja("Caja 02", funcMsj);
            Caja caja3 = new Caja("Caja 03", funcMsj);

            List<Caja> listaCajas = new List<Caja>();
            listaCajas.Add(caja1);
            listaCajas.Add(caja2);
            listaCajas.Add(caja3);

            Negocio negocio = new Negocio(listaCajas);

            Console.WriteLine("Asignando cajas...");

            List<Task> hilos = negocio.ComenzarAtencion();
            Task.WaitAll(hilos.ToArray());
        }
    }
}
