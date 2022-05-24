using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Cocina
    {
        private int _codigo;
        private bool _esIndustrial;
        private double _precio;

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
        }

        public bool EsIndustrial
        {
            get
            {
                return this._esIndustrial;
            }
        }

        public double Precio
        {
            get
            {
                return this._precio;
            }
        }


        public Cocina(int codigo, double precio, bool esIndustrial)
        {
            this._codigo = codigo;
            this._precio = precio;
            this._esIndustrial = esIndustrial;
        }

        public override bool Equals(object obj)
        {
            return obj is not null && obj is Cocina && this == (Cocina)obj;
        }

        public static bool operator ==(Cocina c1, Cocina c2)
        {
            return c1._codigo == c2._codigo;
        }

        public static bool operator !=(Cocina c1, Cocina c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"Codigo: {this._codigo} - Precio: ${this._precio} - Es Industrial: {this._esIndustrial}";
        }
    }
}
