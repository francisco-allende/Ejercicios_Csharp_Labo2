using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    //Buen ejercicio para comparar como es. La logica es identica. El encapsulameinto ayuda y mucho
    //Solo pongo unas <T> y un where y ya funca para todo
    public class Deposito<T>
        where T : class
    {
        private int _capacidadMaxima;
        private List<T> _listaGenerica;

        private Deposito()
        {
            this._listaGenerica = new List<T>();
        }

        public Deposito(int capacidad) : this()
        {
            this._capacidadMaxima = capacidad;
        }

        //cndo envio la clase generic, aclaro que es generic con T
        public static bool operator +(Deposito<T> d, T a) 
        {
            if (d._capacidadMaxima > d._listaGenerica.Count)
            {
                d._listaGenerica.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetIndice(T a)
        {
            for (int i = 0; i < this._listaGenerica.Count; i++)
            {
                if (a.Equals(this._listaGenerica[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool operator -(Deposito<T> d, T a)
        {
            int indiceTRemover = d.GetIndice(a); 
            if (indiceTRemover != -1) 
            {
                d._listaGenerica.Remove(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(T a)
        {
            return this + a;
        }

        public bool Remover(T a)
        {
            return this - a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad máxima: {this._capacidadMaxima}");

            foreach (T item in this._listaGenerica)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
