using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Logica
    {
        public static void ChequearParametros(string param1, string param2)
        {
            //este bloqeu try catch es presindible. No cambia nada. Me interesa el ex
            try
            {
                if(param1 == string.Empty || param2 == string.Empty)
                {
                    throw new ParametrosVaciosException("No se pueden dejar vacios los inputs");
                }
            }
            catch (ParametrosVaciosException ex) //me da data, pero no estoy pudiendo con la inner exception
            {
                throw ex;
            }
        }

        public static float ConversionPosible(string param1)
        {
            if (!float.TryParse(param1, out float numParsed))
            {
                throw new FormatException("Solo pueden usarse numeros");
            }

            NoEsNegativo(numParsed);

            return numParsed;
        }

        public static void NoEsNegativo(float num)
        {
            if (num < 0)
            {
                throw new NumerosPositivosException("Solo se aceptan numeros positivos");
            }       
        }

        public static void PuedoDividir(float denominador)
        {
            if (denominador == 0)
            {
                throw new DivideByZeroException("El kilometraje no puede ser cero");
            }
        }

        public static string Calcular(float kilometros, float combustible)
        {
            return ((combustible / kilometros) * 100).ToString(); //litros a consumir. Tiene q estar mal
        }
    }
}
