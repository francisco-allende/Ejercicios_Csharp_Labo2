using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class CentralitaException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        public string NombreClase { get => nombreClase; }
        public string NombreMetodo { get => nombreMetodo; }

        public CentralitaException() : this("Error. La llamada ya se encuentra en la centralita")
        {

        }

        public CentralitaException(string message)
            : base(message)
        {

        }

        public CentralitaException(string message, string clase, string metodo)
               : this(message, clase, metodo, null)
        {

        }

        public CentralitaException(string message, string clase, string metodo, Exception innerException)
               : base(message, innerException)
        {
            this.nombreMetodo = metodo;
            this.nombreClase = clase;
        }

    }
}
