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
        public static void Esperar(int milisegundos, DelegateSaludarConMsj delegado)
        {
            Thread.Sleep(milisegundos);
            delegado("Saludo tras 3 segundos");
        }
    }
}
