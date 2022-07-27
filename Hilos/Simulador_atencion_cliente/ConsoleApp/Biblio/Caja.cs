using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Biblio
{
    public class Caja
    {
        public Action<Caja, string> delegadoClienteAtendido; 
        //public delegate void DelegadoClienteAtendido(Caja caja, string cliente);

        private static Random nroRandom;
        private Queue<string> clientesALaEspera;
        private string nombreCaja;
        //private DelegadoClienteAtendido delegadoClienteAtendido;

        public int CantidadDeClientesALaEspera { get => clientesALaEspera.Count; }
        public string NombreCaja { get => nombreCaja; }

        static Caja()
        {
            nroRandom = new Random();
        }

        public Caja(string nombreCaja, Action<Caja, string> funcDelegate)
        {
            this.clientesALaEspera = new Queue<string>();
            this.nombreCaja = nombreCaja;
            this.delegadoClienteAtendido = funcDelegate;
        }

        internal Task IniciarAtencion()
        {
            return Task.Run(AtencionCliente);
        }

        internal void AtencionCliente()
        {
            do
            {
                if(clientesALaEspera.Any())
                {
                    string cliente = clientesALaEspera.Dequeue();
                    delegadoClienteAtendido.Invoke(this, cliente);
                    Thread.Sleep(nroRandom.Next(1000, 5000));
                }
            } while(true); //"hasta que se cierre la aplicacion"
        }

        internal void AgregarCliente(string cliente)
        {
            this.clientesALaEspera.Enqueue(cliente);
        }

       
    }
}
