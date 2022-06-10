using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Paloma : AnimalVolador, IMensaje
    {
        public string destino;

        public Paloma(string nombre, string destino) : base(nombre)
        {
            this.destino = destino;
        }

        public string EnviarMensaje()
        {
            return "ola soy una paloma retrasada\n";
        }

        public string EnviarOtroMensaje(string unMensaje)
        {
            return unMensaje;
        }
    }
}
