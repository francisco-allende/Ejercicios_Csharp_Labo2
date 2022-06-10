using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Cuervo : IMensaje, IEncriptado
    {
        string IMensaje.EnviarOtroMensaje(string unMensaje)
        {
            return unMensaje;
        }
        string IMensaje.EnviarMensaje()
        {
            return "mensaje del cuervo interfaz IMensaje";
        }

        string IEncriptado.EnviarMensaje()
        {
            return "mensaje del cuervo interfaz IEncriptado";
        }
    }
}
