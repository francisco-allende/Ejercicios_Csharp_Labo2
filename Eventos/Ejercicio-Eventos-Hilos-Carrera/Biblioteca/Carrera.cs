using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca
{
   


    /// <summary>
    ///  clase encargada de simular la carrera.
    /// </summary>
    public class Carrera
    {
        //TODO: Declarar el delegado y el evento necesario para informar el avance o la llegada
        //  el evento que informe la llegada debera llevar el la informacion del vehiculo que llego a la meta.
        //  Reutilizar ToString()

        public delegate void InformarAvanceHandler();
        public delegate void InformarLlegadaHandler(string ganador);

        public event InformarLlegadaHandler OnInformarllegada;
        public event InformarAvanceHandler OnInformarAvance;


        List<AutoF1> autos;
        int kms;

        public Carrera()
        {
            autos = new List<AutoF1>();
        }

        public Carrera(int kms) : this()
        {
            this.kms = kms;
        }

        public List<AutoF1> Autos { get => autos; set => autos = value; }
        public int Kms { get => kms; set => kms = value; }


        //TODO: El método Iniciar carrera será ejecutado en un hilo secundario y deberá:
        //        i.Se deberá iterar hasta que todos los autos se les haya asignado
        //posición.
        //ii.Recorrer la lista de vehículos de la carrera, acelerar cada
        //vehículo.
        //iii.Informar avance del vehículo.
        //iv.Realizar un Sleep de 10 milisegundos.
        //v.Si la ubicación en pista del vehículo es mayor a Kms de carrera y
        //la posición del Auto aun no fue asignada:
        //1. Se asignará la posición de llegada del vehículo, al ganador
        //se le asignará 1 y al siguiente 2, etc.
        //2. Se informará la llegada del vehículo a la meta, reutilizar el
        //ToString de AutoF1
        public void IniciarCarrera()
        {
            int i = 1;
            while (i <= Autos.Count) 
            { 
                foreach (AutoF1 item in Autos)
                {
                    item.Acelerar();
                    OnInformarAvance.Invoke(); //disparo evento
                    Thread.Sleep(18);

                    if (item.UbicacionEnPista > this.Kms && item.Posicion == 8)
                    {
                        item.Posicion = i;
                        i++;
                        //si llego alguno, disparo el evento
                        //Reutilizo el to string al mandar los datos del auto que llego desde el evento
                        this.OnInformarllegada.Invoke(item.ToString()); 

                    }
                }
            }
        }
        public static Carrera operator +(Carrera c, AutoF1 a)
        {
            c.Autos.Add(a);
            return c;
        }
    }
}
