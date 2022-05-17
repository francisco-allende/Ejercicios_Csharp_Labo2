using System;

namespace Mi_Libreria
{
    public class NombreInvalido : Exception //debe heredar de excepcion
    {
        public NombreInvalido(string mensaje):base(mensaje) //envio el msj personalizado a mi clase padre excepction
        {

        }

        public NombreInvalido(string mensaje, Exception inner) : base(mensaje, inner) //aca enviamos la excepcion que almacenamos
        {

        }
    }
}
