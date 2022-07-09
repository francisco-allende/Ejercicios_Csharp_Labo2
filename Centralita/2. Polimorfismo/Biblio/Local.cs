using System;

namespace Biblio
{
    public class Local : Llamada
    {
        private float costo;

        public override float CostoLlamada { get => this.CalcularCosto(); }

        private float CalcularCosto()
        {
            return this.duracion * costo;
        }

        public Local(Llamada llamada, float costo)
            : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {
            
        }

        public Local(string origen, float duracion, string destino, float costo)
            :base(duracion, origen, destino)
        {
            this.costo = costo;
        }

        /*
         The as operator is used to perform conversion between compatible reference types or Nullable types. 
        This operator returns the object when they are compatible with the given type and return null 
        if the conversion is not possible instead of raising an exception. 
        The working of as operator is quite similar to is an operator but in shortening manner.
         */

        public override bool Equals(object obj)
        {
            return obj is Local;
        }

        //gracias al new puedo usar este metodo q se llama igual al de su clase base
        protected new string Mostrar() 
        {
            return $"{base.Mostrar()} - {this.CostoLlamada}";
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
