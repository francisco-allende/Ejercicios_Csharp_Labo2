using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public abstract class Llamada
    {
        public enum TipoLlamada { Local, Provincial, Todas }
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public float Duracion { get => duracion;  }
        public string NroDestino { get => nroDestino;  }
        public string NroOrigen { get => nroOrigen; }
        public abstract float CostoLlamada { get; } //propiedad abstracta

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        protected virtual string Mostrar()
        {
            return $"{this.Duracion} - {this.NroDestino} - {this.NroOrigen}";
        }

        public static int OrdenarPorDuracion(Llamada call_1, Llamada call_2)
        {
            int retorno = 0;

            if(call_1.Duracion > call_2.Duracion)
            {
                retorno = 1;
            }
            
            if(call_1.Duracion < call_2.Duracion)
            {
                retorno = -1;
            }
            
            if(call_1.Duracion == call_2.Duracion)
            {
                retorno = 0;
            }

            return retorno;
        }

        public static bool operator ==(Llamada l1, Llamada l2)
        {
            return l1.Equals(l2) && l1.NroDestino == l2.NroDestino && l1.NroOrigen == l2.NroOrigen;
        }

        public static bool operator !=(Llamada l1, Llamada l2)
        {
            return !(l1 == l2);
        }

    }
}
