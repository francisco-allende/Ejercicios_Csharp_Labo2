using System;
using System.Runtime.Serialization;

namespace Library
{
    public class ParametrosVaciosException : Exception
    {
        public ParametrosVaciosException()
        {
        }

        public ParametrosVaciosException(string message) : base(message)
        {
        }

        public ParametrosVaciosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
