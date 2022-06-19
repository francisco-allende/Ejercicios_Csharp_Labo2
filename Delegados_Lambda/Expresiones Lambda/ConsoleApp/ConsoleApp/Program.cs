using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public delegate void DelegateSaludar();
    public delegate void DelegateSaludarConMsj(string msj);
    public delegate int DelegateCompare(int num, int num2);

    class Program
    {
        static void Main(string[] args)
        {
            //Le envio un delegado de una funcion anonima
            //Literal le envio el metodo saludar lambda. Respeta la firma del delegado
            Temporizador.Esperar(
                2000,
                () => Console.WriteLine("Hola mundo soy un lambda")
            );

            Temporizador.EsperarYMsj(
             2000,
             (m) => Console.WriteLine(m)
         );


            Temporizador.Comparo(
                (n, m) => n - m
                );

            List<Persona> lista = new List<Persona>()
            {
                new Persona(1234),
                new Persona(7890),
                new Persona(1554),
                new Persona(0989)
            };

            //Criterio del sort en una sola linea!!!
            //Si es positivo acomoda p1 antes
            //si es cero, se restan y son iguales
            //si es negativo acomoda p2 antes
            //Aqui se ve el potencial. Me ahorro mucho codigo y no creo el metodo que compara
            //al ser una lista de personas, el compilador ya sabe que los parametros son personas
            lista.Sort((p, p2 )=> p.Dni - p2.Dni);
            lista.Sort((p, p2) => p.Dni.CompareTo(p2.Dni)); //otra forma de hacer lo mismo

            foreach (Persona item in lista)
            {
                Console.WriteLine(item.Dni);
            }

            

        }
    }
}
