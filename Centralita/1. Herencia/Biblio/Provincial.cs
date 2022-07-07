using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Provincial : Llamada
    {
        public enum Franja{Franja_1, Franja_2, Franja_3}
        private Franja franjaHoraria;

        public float CostoLlamada { get => this.CalcularCosto(); }

        private float CalcularCosto()
        {
            if (this.franjaHoraria == Franja.Franja_1)
            {
                return this.duracion * 0.99f;
            }

            if (this.franjaHoraria == Franja.Franja_2)
            {
                return this.duracion * 1.25f;
            }

            if (this.franjaHoraria == Franja.Franja_3)
            {
                return this.duracion * 0.66f;
            }

            return 0;
        }

        public Provincial(Franja franjaHoraria, Llamada llamada)
            : base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {

        }

        public Provincial(string origen, Franja franjaHoraria, float duracion, string destino)
            : this(franjaHoraria, new Llamada(duracion, destino, origen))
        {
            this.franjaHoraria = franjaHoraria;
        }

        public new string Mostrar()
        {
            return $"{base.Mostrar()} - {this.CostoLlamada} - {this.franjaHoraria}";
        }


    }
}
