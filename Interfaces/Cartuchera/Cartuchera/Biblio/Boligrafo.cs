using System;

namespace Biblio
{
    public class Boligrafo : IAcciones
    {
        private ConsoleColor colorTinta;
        private float tinta;
     
        public ConsoleColor Color
        {
            get
            {
                return this.colorTinta;
            }
            set
            {
                this.colorTinta = value;
            }
        }


        public float UnidadDeEscritura
        {
            get
            {
                return this.tinta;
            }
            set
            {
                this.tinta = value;
            }
        }

        public Boligrafo(int unidades, ConsoleColor colorTinta)
        {
            this.colorTinta = colorTinta;
            this.tinta = unidades;
        }

        public EscrituraWrapper Escribir(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                this.UnidadDeEscritura -= (float)0.3;
            }

            return new EscrituraWrapper(texto, this.Color);
        }

        public bool Recargar(int unidades)
        {
            if(unidades > 0)
            {
                this.tinta = unidades;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"\nEs un Boligrafo\nTinta color: {this.Color}\nNivel de tinta: {this.UnidadDeEscritura}\n"; 
        }
    }
}
