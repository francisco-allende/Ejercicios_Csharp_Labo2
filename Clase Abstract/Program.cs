using System;
using Biblioteca;

namespace Polimorfismo_Prietto
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Ya no puedo hacer esto, no son instanciables
            Animal animal1 = new Animal("Leon", 12);
            Animal animal2 = new Animal("Tigre", 8);
            */
            Gato gato1 = new Gato("Tokio", 5);

            Console.WriteLine(gato1.EmitirSonido());
        }
    }
}
