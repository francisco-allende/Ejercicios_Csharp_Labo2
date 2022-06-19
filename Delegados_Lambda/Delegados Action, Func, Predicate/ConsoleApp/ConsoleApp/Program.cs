using System;

namespace ConsoleApp
{
    //Deben compartir namespace o algo asi, sino no se conocen.
    public delegate int DelegateCompare(int num1, int num2);

    class Program
    {
        static void Main(string[] args)
        {
            //No recibe nada ni retorna nada
            Action delegado = Saludar;
            
            //como un geenric, va entre <> el tipo de dato del parametro
            Action<string> delegadoConMsj = SaludarConMsj; 
            
            //Retorna algo, uso func. Primer parametro es lo que retorna, luego lo que recibe
            Func<int, int, int> delegateCompare = Comparar;

            //Booleano. Todos retornan bool asi q no lo aclaro, solo aclaro el dato el parametro
            Predicate<int> delegateEsPar = EsPar;

            delegadoConMsj("Hola");
            delegado();
            Console.WriteLine(delegateEsPar(3));
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

        static bool EsPar(int num)
        {
            return num % 2 == 0;
        }
    }
}
