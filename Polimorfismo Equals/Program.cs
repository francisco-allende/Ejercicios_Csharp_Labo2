using System;
using Biblioteca;

namespace Polimorfismo_Prietto
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal("Leon", 12);
            Animal animal2 = new Animal("Tigre", 8);
            Gato gato1 = new Gato("Tokio", 5);

            Console.WriteLine(animal1.EmitirSonido());
            Console.WriteLine(gato1.EmitirSonido());
            Console.WriteLine(animal1.Equals(gato1)); //falso, no son iguales
            Console.WriteLine(animal1.Equals(animal1)); //true, apuntan a la misma dire en memoria
            Console.WriteLine(animal1.Equals(null)); //false, su dire en memoria no es null
        }
    }
}
