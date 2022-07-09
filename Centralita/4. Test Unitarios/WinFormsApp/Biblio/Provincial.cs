using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Provincial : Llamada
    {
        private Franja franjaHoraria;

        public override float CostoLlamada { get => this.CalcularCosto(); }

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
            : this(llamada.NroOrigen, franjaHoraria, llamada.Duracion, llamada.NroDestino)
        {

        }

        public Provincial(string origen, Franja franjaHoraria, float duracion, string destino)
            : base(duracion, destino, origen)
        {
            this.franjaHoraria = franjaHoraria;
        }

        protected new string Mostrar()
        {
            return $"{base.Mostrar()} - {this.CostoLlamada} - {this.franjaHoraria}";
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Provincial;
        }
    }
}
