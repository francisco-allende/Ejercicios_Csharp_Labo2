using System;

namespace ConsoleApp
{
    //Deben compartir namespace o algo asi, sino no se conocen.
    public delegate void DelegateSaludar();
    public delegate void DelegateSaludarConMsj(string algo);
    public delegate int DelegateCompare(int num1, int num2);

    class Program
    {
        static void Main(string[] args)
        {
            DelegateSaludar delegado = Saludar;
            DelegateSaludarConMsj delegadoConMsj = SaludarConMsj;
            DelegateCompare delegateCompare = Comparar;

            delegadoConMsj("hola");
            delegado();
            Temporizador.Esperar(3000, delegadoConMsj);


            int result = delegateCompare(5, 3);
            if(result > 0)
            {
                Console.WriteLine("1er parametro mayor al 2do");
            }
            else if(result == 0)
            {
                Console.WriteLine("Ambos iguales");
            }  
            else if(result < 0)
            {
                Console.WriteLine("2do mayor al 1ero");
            }
        }

        static void Saludar()
        {
            Console.WriteLine("Hola mundo, soy un delegado");
        }


        static void SaludarConMsj(string msj)
        {
            Console.WriteLine(msj);
        }

        static int Comparar(int tiempo1, int tiempo2)
        {
            //si es mayor retornara un positivo, si son iguales 0, si el 2do es mayor un nro negativo. Es un sort simplificado
            return tiempo1 - tiempo2;
        }
    }
}
