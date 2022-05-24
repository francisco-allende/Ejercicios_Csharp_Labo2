using System;

namespace Biblio
{
    public class Auto
    {
        private string _color;
        private string _marca;

        public string Color
        {
            get
            {
                return this._color;
            }
        }

        public string Marca
        {
            get
            {
                return this._marca;
            }
        }

        public Auto(string color, string marca)
        {
            this._color = color;
            this._marca = marca;
        }

        public override bool Equals(object obj)
        {
            return obj is not null && obj is Auto && this == (Auto)obj;
        }

        public static bool operator ==(Auto a1, Auto a2)
        {
            return a1._color == a2._color && a1._marca == a2._marca;
        }

        public static bool operator !=(Auto a1, Auto a2)
        {
            return !(a1 == a2);
        }

        public override string ToString()
        {
            return $"Marca: {this._marca} - Color: {this._color}";
        }
    }
}
