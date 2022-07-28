using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public delegate void DelegadoTemporizador();

    public class Temporizador
    {
        public event DelegadoTemporizador TiempoCumplido;

        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private Task hilo;
        private int intervalo;

        //Como no instancie la task aun, pongo el is not null asi no se rompe todo
        public bool EstaActivo
        { 
            get
            {
                return hilo is not null && hilo.Status == TaskStatus.Running;
            }
        }
        public int Intervalo { get => intervalo; set => intervalo = value; }

        public Temporizador(int intervalo)
        {
            this.Intervalo = intervalo;
        }

        public void IniciarTemporizador()
        {
            if (!EstaActivo)
            {
                //asigno los cancel token
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;

                //instancio la task con una funcion que retonre void y activo con strat
                hilo = new Task(CorrerTiempo);
                hilo.Start();
            }
        }

        private void CorrerTiempo()
        {
            //While el evento tenga un metodo suscripto y no me hayan pedido cancelar el hilo
            while(TiempoCumplido != null &&
                !cancellationToken.IsCancellationRequested)
            {
                TiempoCumplido.Invoke();
                Thread.Sleep(intervalo);
            }
        }

        public void DetenerTiempo()
        {
            if(EstaActivo)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
