using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public interface IArchivos
    {
        void Escribir(string nombreFile, string contenido);
        void EscribirAContinuacion(string nombreFile, string contenido, bool append);
        string Leer(string ruta);
    }
}
