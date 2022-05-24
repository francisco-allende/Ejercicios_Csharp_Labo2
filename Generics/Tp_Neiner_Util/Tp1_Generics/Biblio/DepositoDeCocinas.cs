using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class DepositoDeCocinas
    {
        private int _capacidadMaxima;
        private List<Cocina> _listaCocinas;

        private DepositoDeCocinas()
        {
            this._listaCocinas = new List<Cocina>();
        }

        public DepositoDeCocinas(int capacidad) : this()
        {
            this._capacidadMaxima = capacidad;
        }

        public static bool operator +(DepositoDeCocinas d, Cocina c)
        {
            if (d._capacidadMaxima > d._listaCocinas.Count)
            {
                d._listaCocinas.Add(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetIndice(Cocina c)
        {
            for (int i = 0; i < this._listaCocinas.Count; i++)
            {
                if (c.Equals(this._listaCocinas[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool operator -(DepositoDeCocinas d, Cocina c)
        {
            int indiceAutoRemover = d.GetIndice(c); 
            if (indiceAutoRemover != -1) 
            {
                d._listaCocinas.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Cocina c)
        {
            return this + c;
        }

        public bool Remover(Cocina c)
        {
            return this - c;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad máxima: {this._capacidadMaxima}");

            foreach (Cocina item in this._listaCocinas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
