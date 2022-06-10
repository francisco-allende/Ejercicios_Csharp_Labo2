using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class CartucheraMultiuso
    {
        public List<IAcciones> lista;
        
        public CartucheraMultiuso()
        {
            this.lista = new List<IAcciones>();
        }

        public bool RecorrerElementos()
        {
            //gasta
            foreach (IAcciones item in this.lista)
            {
                if(item.UnidadDeEscritura > 0) //chequeo que haya tinta
                {
                    item.UnidadDeEscritura -= 1;

                    if(item.UnidadDeEscritura >= 0 && item.UnidadDeEscritura < 1) //si tengo 0.99 y 0 de tinta, recargo
                    {
                        //No puedo recargar un lapiz
                        try
                        {
                            item.Recargar(20);
                        }
                        catch (NotImplementedException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    return false; //no pude gartar 1 porque habia un elemento sin tinta
                }
            }

            return true;//no importa si recargo o no, sino gastarles a todos 1
        }
    }
}
