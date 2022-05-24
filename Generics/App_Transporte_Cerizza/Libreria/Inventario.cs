using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Inventario<T, U>
        where T : class //casteo, siempre sera un objeto 
        where U : MedioDeTransporte //casteo a derivados de esta clase
        //where V : struct --> asi se veria si fuera para tipo de dato normal

    {
        List<T> lista;
        U item; //Como U es siempre un tipo de transporte, no importa que sea siempre tendré los metodos de la clase base medio de transporte

        public Inventario()
        {

        }

        //Ejemplo. Al ser Item un Medio de transporte, puedo acceder a sus atributos y metodos. 
        public void SumarCombustible()
        {
            item.nombre = "ejemplo random";
            item.MostrarChasis();
        }
    }
}
