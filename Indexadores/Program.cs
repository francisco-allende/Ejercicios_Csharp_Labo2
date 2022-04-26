using System;

namespace indexadores__de_clase_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dias losDiasHabiles = new Dias();

            Console.WriteLine(losDiasHabiles[2]); //si no codeo el indexador tira error

            //Segun el indice, muestro que dia es. Indice no numerico
            string queDiaEs = losDiasHabiles["ultimo dia"];
            Console.WriteLine(queDiaEs);
        }
    }
}
