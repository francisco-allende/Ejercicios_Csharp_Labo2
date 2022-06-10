using System;

namespace Biblio
{
    public abstract class Papel
    {
        protected string tipo;
        protected int cantidadHojas;

        public Papel(string tipo, int cantidadHojas)
        {
            this.tipo = tipo;
            this.cantidadHojas = cantidadHojas;
        }


    }
}
