using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Lapiz : IAcciones
    {
        private float tamanioMina;

        public Lapiz(int unidades)
        {
            this.tamanioMina = unidades;
        }

        //Asi se usan properties de una interfaz explicita
        ConsoleColor IAcciones.Color 
        {  
            get
            {
                return ConsoleColor.Gray;
            }

            set
            {
                throw new NotImplementedException("\nError: No se le puede cambiar el color a un lapiz\n");
            }
        }

        float IAcciones.UnidadDeEscritura
        {
            get
            {
                return this.tamanioMina;
            }
            set
            {
                this.tamanioMina = value;
            }
        }

        //Asi accedo a properties (casteando) y asi declaro un metodo
        EscrituraWrapper IAcciones.Escribir(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                ((IAcciones)this).UnidadDeEscritura -= (float)0.3;
            }

            return new EscrituraWrapper(texto, ((IAcciones)this).Color);
        }

        bool IAcciones.Recargar(int unidades)
        {
            throw new NotImplementedException("\nError: No se puede recargar un lapiz\n");
        }

        public override string ToString()
        {
            return $"\nEs un Lapiz\nMina color: {((IAcciones)this).Color}\nNivel de mina: {((IAcciones)this).UnidadDeEscritura}\n";
        }
    }
}
