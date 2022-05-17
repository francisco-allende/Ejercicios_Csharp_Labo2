using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MiExcepcion : Exception
    {
        public MiExcepcion() : base("Soy del tipo MiExcepcion")
        {

        }

        //15) final del recorrdio con la ultima excepcion a instanciar
        public MiExcepcion(Exception exception) : base("Exepcion con parametros MiExcepcion", exception) //la inner es el 2do param
        {

        }
    }
}
