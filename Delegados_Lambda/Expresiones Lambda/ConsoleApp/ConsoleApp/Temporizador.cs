using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Temporizador
    {
        public static void Esperar(int milisegundos, DelegateSaludar msj)
        {
            Thread.Sleep(milisegundos);
            msj(); //lo uso como delegadomporque LO ES
        }

        public static void EsperarYMsj(int milisegundos, DelegateSaludarConMsj msj)
        {
            Thread.Sleep(milisegundos);
            msj("Soy otro delegado lambda, ahora con parametros"); //recien aqui asigno parametro
        }

        public static void Comparo(Func<int, int, int> del)
        {
            int result = del(5, 3);
            if (result > 0)
            {
                Console.WriteLine("1er parametro mayor al 2do");
            }
            else if (result == 0)
            {
                Console.WriteLine("Ambos iguales");
            }
            else if (result < 0)
            {
                Console.WriteLine("2do mayor al 1ero");
            }
        }
    }
}
