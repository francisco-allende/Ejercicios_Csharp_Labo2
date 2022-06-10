using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class CartucheraSimple
    {
        public List<Boligrafo> listaBoligrafo;
        public List<Lapiz> listaLapiz;

        public CartucheraSimple()
        {
            this.listaBoligrafo = new List<Boligrafo>();
            this.listaLapiz = new List<Lapiz>();
        }

        public bool RecorrerElementos()
        {
            bool pudeGastarTinta = true;
            bool pudeGastarLapiz = true;
            
            foreach (Boligrafo item in this.listaBoligrafo)
            {
                if (item.UnidadDeEscritura > 0) 
                {
                    item.UnidadDeEscritura -= 1;

                    if (item.UnidadDeEscritura >= 0 && item.UnidadDeEscritura < 1) 
                    {
                        item.Recargar(20);
                    }
                }
                else
                {
                    pudeGastarTinta = false;
                    break;
                }
            }

            foreach (Lapiz item in this.listaLapiz)
            {
                if (((IAcciones)item).UnidadDeEscritura > 0) 
                {
                    ((IAcciones)item).UnidadDeEscritura -= 1;

                    if (((IAcciones)item).UnidadDeEscritura >= 0 && ((IAcciones)item).UnidadDeEscritura < 1) 
                    {
                        //No puedo recargar un lapiz
                        try
                        {
                            ((IAcciones)item).Recargar(20);
                        }
                        catch (NotImplementedException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    pudeGastarLapiz = false;
                    break;
                }
            }

            if(pudeGastarTinta && pudeGastarLapiz)
            {
                return true;
            }

            return false;
        }
    }
}
