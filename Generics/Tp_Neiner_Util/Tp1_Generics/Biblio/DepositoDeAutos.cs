using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class DepositoDeAutos
    {
        private int _capacidadMaxima;
        private List<Auto> _listaAutos; 

        private DepositoDeAutos()
        {
            this._listaAutos = new List<Auto>();
        }

        public DepositoDeAutos(int capacidad) : this()
        {
            this._capacidadMaxima = capacidad;
        }

        public static bool operator +(DepositoDeAutos d, Auto a)
        { 
            if(d._capacidadMaxima > d._listaAutos.Count)
            {
                d._listaAutos.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetIndice(Auto a)
        {
            for (int i = 0; i < this._listaAutos.Count; i++)
            {
                if(a.Equals(this._listaAutos[i])) 
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            int indiceAutoRemover = d.GetIndice(a); //chequeo que exista
            if(indiceAutoRemover != -1) //lo encontre, existe. Lo borro
            {
                d._listaAutos.Remove(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Auto a)
        {
            return this + a;
        }

        public bool Remover(Auto a)
        {
            return this - a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad máxima: {this._capacidadMaxima}");

            foreach (Auto item in this._listaAutos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

    }
}
