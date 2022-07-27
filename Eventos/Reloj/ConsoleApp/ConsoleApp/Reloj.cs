using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp
{
    public class Reloj
    {
        //Primero declaro delegado, luego el evento
        //Esto es mi editor/publisher
        public delegate void NotificarCambioTiempo(object reloj, InfoTiempoEventArgs infoTiempo);
        public event NotificarCambioTiempo Notificar;

        public int hora;
        public int minuto;
        public int segundo;

        public void Ejecutar()
        {
            do
            {
                Thread.Sleep(100);
                DateTime dt = DateTime.Now;

                // si los segundos cambian
                // notifica a los suscriptores
                if (dt.Second != this.segundo)
                {
                    // crea una instancia de InfoTiempoEventArgs
                    // para pasar al suscriptor
                    InfoTiempoEventArgs infoTiempo = new InfoTiempoEventArgs(this.hora, this.minuto, this.segundo);

                    // verifico que haya suscriptores al evento, que apunte a algo y no sea null
                    if (Notificar != null)
                    {
                        //Lo invoco. Llama al metodo que tiene suscribido, el que muestra la hora en el Main
                        Notificar.Invoke(this, infoTiempo);
                    }
                }

                // actualizo el estado del objeto Reloj
                this.segundo = dt.Second;
                this.minuto = dt.Minute;
                this.hora = dt.Hour;
            } while (true);
        }
    }
}
