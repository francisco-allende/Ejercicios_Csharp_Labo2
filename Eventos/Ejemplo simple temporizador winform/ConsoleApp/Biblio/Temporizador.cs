using System;
using System.Threading;
using System.Threading.Tasks;


namespace Biblio
{
    public class Temporizador
    {
        public delegate void TiempoIntervaloHandler(); //delegado
        public event TiempoIntervaloHandler OnTiempoFinalizado; //evento
        public event Action<int> OnSegundosRestantes;

        //Cuento para atras, cuando termino ejecuto evento
        public void Ejecutar(int intervaloSegundos)
        {
            //Sino hago esto me congela el programa hasta q termine
            Task.Run(() =>
            {
                while (intervaloSegundos > 0)
                {
                    if (OnSegundosRestantes is not null)
                    {
                        OnSegundosRestantes.Invoke(intervaloSegundos);
                    }
                    Thread.Sleep(1000);
                    intervaloSegundos--;
                }
                //cuando este metodo termina de contar hasta 0, invoco al evento 
                OnTiempoFinalizado.Invoke();
            });
        }
    }
}
