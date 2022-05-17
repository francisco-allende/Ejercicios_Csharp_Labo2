using System;

namespace Biblioteca
{
    public class UnaExcepcion : Exception
    {
        //Crear una excepción propia llamada UnaException (utilizar la propiedad InnerException
        //para almacenar la excepción original) y volver a lanzarla.

        public UnaExcepcion() : base("Soy del tipo UnaExcepcion") 
        {

        }

        //12)
        //msj + inner. La inner es divide by zero, la lanze desde MiClase con el throw new(msj, ex)
        //ahora vuelvo a OtraClase
        public UnaExcepcion(string mensaje, Exception exception)
            : base(mensaje, exception)
        {

        }
    }
}
