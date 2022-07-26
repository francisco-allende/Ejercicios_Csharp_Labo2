using System;
using System.Collections.Generic;
using static System.Environment;

namespace Consola
{
    class Program
    {
        public delegate int DelegadoComparacion(string primerTexto, string segundoTexto);

        static void Main(string[] args)
        {
            /*
             * Claramente no termino nunca de entender este tema. Declaro el delegado
             * Codeo comparar. Comparar es como un sort, pero el criterio es un delegado
             * Que sera un lambda!
             * Este es un lambda. Porque mando los 2 textos como args y retorna un int. 
             * El delegado no apunta a comparar, este metodo solo lo recibe por param
             * Como los lamda que uso que comparar la longitud de los textos
             * Y luego le envio un lambda que compara longitudes. Que recibe dos textos, por ende
             * 
             * Despues lo que cambia en el 3 y 4 es que la lambda llama a funciones ya codeadas 
             * Osea, uso mis funciones ya codeadas con el lamda que las llama
             * Es como que ASOCIO IMPLICITAMENTE EL DELEGADO AL LAMBDA, Y ESTE A LA VEZ ES EL PARAMETRO
             * QUE RECIBE EL METODO COMPARAR
             */


            // Borrar o agregar la primera barra para switchear entre las pruebas fijas y el ingreso de texto por consola. 
            //*
            string primerTexto = "Vive como si fueras a morir mañana; aprende como si el mundo fuera a durar para siempre.";
            // Cant. caracteres: 88, Cant. palabras: 17 , Cant. vocales: 34, Cant. signos puntuación: 2 
            string segundoTexto = "La vida es como montar en bicicleta; para mantener el equilibrio debes seguir moviéndote.";
            // Cant. caracteres: 89, Cant. palabras: 13, Cant. vocales: 35, Cant. signos puntuación: 2

            /*
            Console.WriteLine("Ingrese el primer texto:");
            string primerTexto = Console.ReadLine();

            Console.WriteLine("Ingrese el segundo texto:");
            string segundoTexto = Console.ReadLine();
            */

            // Punto 2
            Console.WriteLine($"{NewLine}1era Comparación - Texto con más caracteres:");
            Comparar(primerTexto, segundoTexto, (txt1, txt2)=> txt1.Length - txt2.Length);
            
            // Punto 3. El Split separa en un array sin lo que recibe. Con el length, es como separar en palabras
            Console.WriteLine($"{NewLine}2da Comparación - Texto con más palabras:");
            Comparar(primerTexto, segundoTexto, (txt1, txt2) => txt1.Split(" ").Length - txt2.Split(" ").Length);

            // Punto 4
            Console.WriteLine($"{NewLine}3era Comparación - Texto con más vocales:");
            Comparar(primerTexto, segundoTexto, (txt1, txt2) => ContarVocales(txt1) - ContarVocales(txt2));

            // Punto 5
            Console.WriteLine($"{NewLine}4ta Comparación - Texto con más signos de puntuación:");
            Comparar(primerTexto, segundoTexto, (txt1, txt2) => ContarSignosPuntuacion(txt1) - ContarSignosPuntuacion(txt2));

        }

        public static int ContarVocales(string texto)
        {
            List<char> vocales = new List<char>()
            {
                'a', 'á', 'A', 'Á', 'e', 'é', 'E', 'É',
                'i', 'í', 'I', 'Í', 'o', 'ó', 'O', 'Ó',
                'u', 'ú', 'U', 'Ú'
            };


            return ContarCaracteres(texto, vocales);
        }

        public static int ContarSignosPuntuacion(string texto)
        {
            List<char> signosPuntuacion = new List<char>()
            {
                '.', ';', ','
            };

            return ContarCaracteres(texto, signosPuntuacion);
        }

        public static int ContarCaracteres(string texto, List<char> caracteres)
        {
            int cantidadCaracteres = 0;

            foreach (char caracter in texto)
            {
                if (caracteres.Contains(caracter))
                {
                    cantidadCaracteres++;
                }
            }

            return cantidadCaracteres;
        }

        public static void Comparar(string texto1, string texto2, DelegadoComparacion criterio)
        {
  
            if(criterio(texto1, texto2) > 0)
            {
                Console.WriteLine("El primer texto es MAYOR al segundo");
            }
            else if(criterio(texto1, texto2) < 0)
            {
                Console.WriteLine("El primer texto es MENOR al segundo");
            }
            else
            {
                Console.WriteLine("El primer texto es IGUAL al segundo");
            }
        }
    }
}
