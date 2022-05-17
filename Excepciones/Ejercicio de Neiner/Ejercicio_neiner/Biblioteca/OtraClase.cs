using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class OtraClase
    {
        /*
         *método de instancia, donde se instancie un objeto MiClase y se capture la excepción anterior. 
         *Este método generará una excepción propia llamada MiException y la lanzará. 
         */
        public void MetodoDeInstancia() //2)
        {
            try
            {
                MiClase miClase = new MiClase(10); //3)
            }
            catch (UnaExcepcion e) //13. Ya recorri todo y lanzo lo ultimo.
            {
                throw new MiExcepcion(e); //14) Instancio esta nueva excepcion
            }
        }
    }
}
