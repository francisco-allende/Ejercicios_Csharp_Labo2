using System;
using Biblio;

namespace Generic_Juguetes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio juguetes
            Juguete j1 = new Juguete("Lego", 7773);
            Juguete j2 = new Juguete("Mattel", 3423);
            Juguete j3 = new Juguete("Ditoys", 2329);
            Juguete j4 = new Juguete("ToyCo", 45443);

            //Los agrego a la lista
            Caja<Juguete>.Agregar<Juguete>(j1);
            Caja<Juguete>.Agregar<Juguete>(j2);
            Caja<Juguete>.Agregar<Juguete>(j3);
            Caja<Juguete>.lista = Caja<Juguete>.Agregar<Juguete>(j4); //??

            //Muestro
            Console.WriteLine(Caja<Juguete>.Mostrar<Juguete>());
            Console.ReadKey();
        }
    }
}
