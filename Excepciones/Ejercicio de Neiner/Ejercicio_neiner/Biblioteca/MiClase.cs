using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MiClase 
    {
        //Capturar la excepción del punto anterior en uno de los constructores de instancia. Capturo con try catch
        //y relanzarla hacia el otro constructor de instancia. Capturo con try catch
        public MiClase()  //6)
        {
            try
            {
                MiClase.LanzarExcepcionNoDividirPorCero(); //7)
            }
            catch (DivideByZeroException)
            {
                throw; //where??? Nunca entra
            }
        }

        //En este segundo constructor se deberá instanciar otro objeto del tipo MiClase, capturando su excepción
        //Crear una excepción propia llamada UnaException(utilizar la propiedad InnerException para almacenar la excepción original)
        //y volver a lanzarla.
        public MiClase(int num) //4)
        {
            try
            {
                MiClase miClaseObj = new MiClase(); //5)
            }
            catch(DivideByZeroException ex) //10
            {
                //11. Llama a unaExcepcion, construye con el msg y el inner, que es la original, y es el dividebyzero
                throw new UnaExcepcion("Excepcion con parametros UnaExcpecion ", ex);  
            }
        }
    
        public static void LanzarExcepcionNoDividirPorCero() //8)
        {
            throw new DivideByZeroException("Eu, capo, no se puede dividir por cero"); //9) Recien aca lanzo lo primero
        }
    }
}
