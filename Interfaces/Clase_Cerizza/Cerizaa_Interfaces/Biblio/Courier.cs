using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Courier : Persona, IMensaje
    {
        public Courier()
        {

        }

        public Courier(string nombre, string apellido, string dni)
            :base(nombre, apellido, dni)
        {

        }

        public string EnviarMensaje()
        {
            return "Soy un courier, osea, un cartero francoise\n";
        }

        public string EnviarOtroMensaje(string unMensaje)
        {
            return unMensaje;
        }
    }
}
