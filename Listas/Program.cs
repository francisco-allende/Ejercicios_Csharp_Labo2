using System;
using System.Collections.Generic;

namespace Listas_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto1 = new Auto("azy 974", "Honda", 2015);
            Auto auto2 = new Auto("rtq 804", "Susuki", 2012);
            Auto auto3 = new Auto("gty 911", "Chevrolet", 2019);


            #region Arrays
            //Las dos formas de declarar un array. Sin cargar o ya cargado
            int[] numeros = new int[6];
            int[] numerosYaCargados = { 9, 8, 7, 6, 5 };

            //instancio dos autos y cargo valores por indice
            Auto[] autos = new Auto[2];
            autos[0] = new Auto("123", "Fiat", 1999);
            autos[1] = new Auto("456", "Toyota", 1997);
            #endregion

            #region Listas
            //entre los piquitos va el tipo de dato. Aqui instancio
            List<string> nombres = new List<string>();
            List<Auto> garage = new List<Auto>();
            List<int> listaNumeros = new List<int>();

            //Añado valores con add
            nombres.Add("Franco");
            nombres.Add("Lucia");
            nombres.Add("Diana");
            nombres.Add("Roman");
            nombres.Add("Leonel");

            //Puedo añadir valores creando el objeto dentro
            garage.Add(new Auto("1234", "Fiat", 2001));

            //Elimino un valor por valor. 
            nombres.Remove("Leonel");

            //Elimino por indice
            nombres.RemoveAt(0);

            //Propiedad. Elemetos de la coleccion
            Console.WriteLine(nombres.Count);

            //Recorro la lista
            foreach (string name in nombres)
            {
                Console.WriteLine(name);
            }

            //sort con numeros. Por defecto, de menor a mayor
            listaNumeros.Add(50);
            listaNumeros.Add(100);
            listaNumeros.Add(10);
            listaNumeros.Add(2000);
            listaNumeros.Add(40);
            listaNumeros.Add(69);
            listaNumeros.Add(420);
            listaNumeros.Add(666);

            listaNumeros.Sort();
            foreach (var item in listaNumeros)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\nOrdeno autos por modelo\n\n\n");

            //Sort con objetos usando un puntero a funcion
            garage.Add(new Auto("1234", "Fiat", 2001));
            garage.Add(new Auto("0101", "Hyundai", 2022));
            garage.Add(new Auto("333", "Renault", 2013));

            garage.Sort(Auto.Comparacion);

            foreach (var item in garage)
            {
                Console.WriteLine(item.modelo);
            }

           
            Console.WriteLine("\nLo mismo inverso\n");
            garage.Sort(Auto.ComparacionMayorAMenor);

            foreach (var item in garage)
            {
                Console.WriteLine(item.modelo);
            }

            #endregion

            #region Diccionarios

            //Par clave valor
            Dictionary<string, int> agenda = new Dictionary<string, int>();

            agenda.Add("Fran", 1234);
            agenda.Add("Morio", 1562);

            //recorro y muestro por clave y valor
            foreach (KeyValuePair<string, int> item in agenda)
            {
                Console.WriteLine($"La key es: {item.Key}, El value es {item.Value}");
            }

            //Solo key + contains
            foreach (var item in agenda.Keys)
            {
                if (agenda.ContainsKey("Fran"))
                {
                    Console.WriteLine($"{item} ha sido agendado");
                    break;
                }
            }

            //Solo valor + contains
            foreach (var item in agenda.Values)
            {
                if(agenda.ContainsValue(1562))
                {
                    Console.WriteLine($"El value es {item} y se enocuentra agendado");
                    break;
                }
            }

            foreach (KeyValuePair<string, int> item in agenda)
            {
                if(agenda.TryGetValue("Fran", out int value))
                {
                    Console.WriteLine($"uso un try get value y lo hayo {value}");
                    break;
                }
            }
            #endregion
            
            #region Coleccion Queue, cola

            Queue<Auto> autoCola = new Queue<Auto>();

            //Añado a la cola en orden FIFO
            autoCola.Enqueue(auto1);
            autoCola.Enqueue(auto2);
            autoCola.Enqueue(auto3);

            foreach (Auto item in autoCola)
            {
                Console.WriteLine(item.Mostrar());
            }

            //Muestro el primer elemento de la cola
            Console.WriteLine("\nPrimer elemento de la cola: " + autoCola.Peek().Mostrar());

            //Muestro y elimino el ultimo elemento de la cola
            Console.WriteLine("\n Muestro y elimino el primer elemento de la cola: " + autoCola.Dequeue().Mostrar());

            Console.WriteLine("Saque el primer auto (first in, first out) con dequeue y me quedaron estos en la cola:\n ");
            foreach (Auto item in autoCola)
            {
                Console.WriteLine(item.Mostrar());
            }

            #endregion

            #region Coleccion Stack, pila 

            //Orden LIFO. Las in, first out. Pila de platos, balas de cartucho.
            Stack<Auto> autoPila = new Stack<Auto>();

            //Añado con push
            autoPila.Push(auto1);
            autoPila.Push(auto2);
            autoPila.Push(auto3);

            //Saco con pop el ultimo en ser ingresado, osea el auto3 chevrolet
            autoPila.Pop();

            foreach (Auto item in autoPila)
            {
                Console.WriteLine(item.Mostrar());
            }

            //Metodo contains. Ojo que es por referencia y no por la pila
            if(autoPila.Contains(auto1))
            {
                Console.WriteLine("Esta en la pila");
            }

            #endregion
        }
    }
}
