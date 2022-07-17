using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public interface IGuardar<T>
    {
        string RutaDeArchivo{ get; }
        bool Guardar(List<T> contenido);
        T Leer();
    }
}
