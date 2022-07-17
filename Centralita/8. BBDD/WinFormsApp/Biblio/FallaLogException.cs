using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class FallaLogException : Exception
    {
        public FallaLogException() : this("Error. No se pudo guardar la data en el archivo")
        {

        }

        public FallaLogException(string message)
            : base(message)
        {

        }
    }
}
