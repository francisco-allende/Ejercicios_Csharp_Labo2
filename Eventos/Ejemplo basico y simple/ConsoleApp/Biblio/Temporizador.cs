using System;
using System.Threading;
using System.Threading.Tasks;


namespace Biblio
{
    public class Temporizador
    {
        public delegate void TiempoIntervaloHandler(); //delegado
        public event TiempoIntervaloHandler OnTiempoFinalizado; //evento

        //Cuento para atras, cuando termino ejecuto evento
        public void Ejecutar(int intervaloSegundos)
        {
            while(intervaloSegundos > 0)
            { 
                Thread.Sleep(1000);
                intervaloSegundos --;
            }
            //cuando este metodo termina de contar hasta 0, invoco al evento 
            OnTiempoFinalizado.Invoke();
        }
    }
}
