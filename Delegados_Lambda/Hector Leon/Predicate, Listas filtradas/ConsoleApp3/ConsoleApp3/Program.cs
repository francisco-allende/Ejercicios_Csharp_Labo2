using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(4);
            list.Add(6);
            list.Add(3); 
            list.Add(8);
            list.Add(27);

            //Instancio un predicado. <unico param>. Le asigno un metodo booleano
            Predicate<int> predicate = (x) => x % 2 == 0;
            Console.WriteLine(predicate(6));
            Console.WriteLine(predicate(3));

            //Le asocio al find all un predicado. Muestra todos los que sean true de la lista
            Console.WriteLine("Uso predicate para filtrar nros pares de una lista\n");
            var dividers = list.FindAll(predicate);

            foreach (int item in dividers)
            {
                Console.WriteLine(item);
            }

            //Aca lo mismo, pero lo inverso, solo impares. Por eso niego el predicado anterior
            Console.WriteLine("\n\nniego el predicate para filtrar nros impares\n");
            Predicate<int> negativePredicate = x => !predicate(x);
            var notDivider = list.FindAll(negativePredicate);

            foreach (int item in notDivider)
            {
                Console.WriteLine(item);
            }

            //Si tiene mas de 5 de alchol me deja borracho
            //El predicate es el lamda del parametro. Evalua el nivel de alcohol ed cada birra
            //el find all es muy poderoso, con un predicate de filtro te retorna la lista
            //filtrada. Como haciamos a mano en C con los criterios, aca mucho ams facil
            var birras = new List<Beer>()
            {
                new Beer() {Name = "Quilmes", Alcohol = 6 },
                new Beer() {Name = "Salta", Alcohol = 4 },
                new Beer() {Name = "Corona", Alcohol = 3 },
                new Beer() {Name = "Waffteiner", Alcohol = 8 },
                new Beer() {Name = "Grosch", Alcohol = 8 },
                new Beer() {Name = "Stella", Alcohol = 5 }
            };

            Console.WriteLine("\nBirras que me ponen en pedo:\n");
            ShowMeDrunkBeers(birras, x => x.Alcohol >= 6); //este lambda es el predicado
            
            //Ambos ahcen lo mismo
            Predicate<Beer> prediBorracho = (x) => x.Alcohol >= 6;
            ShowMeDrunkBeers(birras, prediBorracho);
        }

        static void ShowMeDrunkBeers(List<Beer> lista, Predicate<Beer> condition)
        {
            var evilBeers = lista.FindAll(condition);
            evilBeers.ForEach(b => Console.WriteLine($"{b.Name} - {b.Alcohol}% de alcohol"));
        }

        public class Beer
        {
            private string name;
            private int alcohol;

            public string Name { get => name; set => name = value; }
            public int Alcohol { get => alcohol; set => alcohol = value; }

            public Beer()
            {

            }

            public Beer(string name, int alcohol)
            {
                this.name = name;
                this.alcohol = alcohol;
            }
        }
    }
}
