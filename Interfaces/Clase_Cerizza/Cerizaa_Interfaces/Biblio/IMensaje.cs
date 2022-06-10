using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public interface IMensaje
    {
        string EnviarMensaje(); //Solo firma, sin cuerpo. La implementacion esta en las clases que usen esta interfaz
        string EnviarOtroMensaje(string unMensaje);
    }
}
