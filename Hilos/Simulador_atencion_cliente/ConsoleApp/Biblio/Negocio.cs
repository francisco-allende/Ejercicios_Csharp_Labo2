using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NameGenerator.Generators;
using System.Collections.Concurrent;


namespace Biblio
{
    public class Negocio
    {
        private static RealNameGenerator nombreRandom;
        private ConcurrentQueue<string> clientes;
        private List<Caja> cajas;

        static Negocio()
        {
            nombreRandom = new RealNameGenerator();
        }

        public Negocio(List<Caja> cajas)
        {
            this.cajas = cajas;
            this.clientes = new ConcurrentQueue<string>();
        }

        public List<Task> ComenzarAtencion()
        {
            List<Task> hilos = new List<Task>();

            //1) Inicio la atencion en todas las cajas
            hilos.AddRange(AbrirCaja());

            //2) Hilo con clientes, iterativo hasta que se cierre la app
            hilos.Add(Task.Run(GenerarCliente));

            //3) Asignar cajas
            hilos.Add(Task.Run(AsignarClientesACajas));

            return hilos;
        }

        internal List<Task> AbrirCaja()
        {
            List<Task> hilosAbreCajas = new List<Task>();

            foreach (Caja caja in cajas)
            {
                hilosAbreCajas.Add(caja.IniciarAtencion());
            }

            return hilosAbreCajas;
        }


        internal void GenerarCliente()
        {
            do
            {
                Thread.Sleep(1000);
                this.clientes.Enqueue(nombreRandom.Generate());
            } while (true);
        }

        //Asigno clientes a la caja con menos fila
        internal void AsignarClientesACajas()
        {
            do
            {
                Caja caja = cajas.OrderBy(c => c.CantidadDeClientesALaEspera).First();
                clientes.TryDequeue(out string cliente);
                
                if(!string.IsNullOrWhiteSpace(cliente))
                {
                    caja.AgregarCliente(cliente);
                }
            } while (true);
        }
    }
}
