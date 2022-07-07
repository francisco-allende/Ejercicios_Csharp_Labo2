using System;

namespace Biblio
{
    public class Local : Llamada
    {
        private float costo;

        public float CostoLlamada { get => this.CalcularCosto(); }

        private float CalcularCosto()
        {
            return this.duracion * costo;
        }

        public Local(Llamada llamada, float costo)
            : base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {
            
        }

        public Local(string origen, float duracion, string destino, float costo)
            : this(new Llamada(duracion, destino, origen), costo)
        {
            this.costo = costo;
        }

        //gracias al new puedo usar este metodo q se llama igual al de su clase base
        public new string Mostrar() 
        {
            return $"{base.Mostrar()} - {this.CostoLlamada}";
        }
    }
}
