using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class NumerosPositivosException : Exception
    {
        public NumerosPositivosException()
        {
        }

        public NumerosPositivosException(string message) : base(message)
        {
        }

        public NumerosPositivosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
