using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_Libreria
{
    public class MiClaseEstatica //es estatica para romper las bolas, no cambia nada
    {
        public static string MiMetodoEstatico(string value)
        {
            MiClaseDeInstancia miClase;

            try
            {
                miClase = new MiClaseDeInstancia(value);
            }
            catch (NombreInvalido ex)
            {
                return "se produjo un error en el metodo estatico";
                //throw new Exception("Excepcion capturada y lanzada en un metodo estatico", ex); //este ex rescata la inner
            }

            return "No se produjo ningun error";
        }

        public static string MiMetodoEstatico2(string value)
        {
            try
            {
                MiMetodoEstatico(value);
            }
            catch (Exception ex)
            {
                throw ex; //cambia el stacktrace porque relanzo la excepcion
            }

            return value;
        }
    }
}
