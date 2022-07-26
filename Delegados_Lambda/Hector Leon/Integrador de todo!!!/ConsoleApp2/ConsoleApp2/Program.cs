using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        public delegate void Mostrar(string cadena);

        static void Main(string[] args)
        {
            //instancio y llamo desde main
            Mostrar funcMostrar = Show;
            funcMostrar("Envio texto por delegado!");

            //instancio y lo envio por parametro 
            Mostrar funcMuestraRojo = ShowInRed;
            HacerAlgo(funcMuestraRojo);

            //Uso un Func
            Func<string, int> funcPalabras = CuentoPalabras;
            Console.WriteLine("Cantidad de palabras del texto: " + funcPalabras("La Mona Lisa"));

            //Uso un act por parametro
            Action<string> funcMostrarAction = Show;
            funcMostrar("Uso action");

            //Fusiono palabras con metodo y luego sumo con lambda
            Action<string, string> funcUnirPalabras = UnirPalabras;
            FusionaPalabras(funcUnirPalabras);

            Action<int, int> sumarYMostrar = (a, b) => Console.WriteLine($"{a} + {b} = {a + b}");
            sumarYMostrar(12, 8);

            Func<string, string, int> concatenaYCuenta = (str1, str2) => (str1+str2).Length;
            Console.WriteLine($"Nro de caracteres en toy story: {concatenaYCuenta("toy", "story")}");

            //Funcion lambda (anonima) que busca a nemo
            List<string> list = new List<string>();
            list.Add("Dory");
            list.Add("Nemo");
            list.Add("Mr Crabb");

            list.ForEach((x) => 
            {
                if (x.Contains("Nemo"))
                {
                    Console.WriteLine("Nemo esta!");
                }
            });

            //Declaro delegate y le asocio una func anonima lamda
            //Luego llamo al metodo que recibe delegado por param y ahi recien invoko
            Func<string, int> funcLamdaMasDelegado = (x) => x.Length; //almacena esta func anonima
            PrueboLamdaMasDelegado(funcLamdaMasDelegado);

            //Uso otro delegado para el mismo metodo, ahora retorna el indice de una letra
            //poseo distintos criterios
            Func<string, int> funcIndiceLetraConLambda = (x) => x.IndexOf("L");
            PrueboLamdaMasDelegado(funcIndiceLetraConLambda);
        }


        public static void PrueboLamdaMasDelegado(Func<string, int> funchi)
        {
            Console.WriteLine("Pruebo lambda mas delegado por param");
            Console.WriteLine("Caracteres: "+funchi("La muerte es ocultar la verdad"));
        }

        public static void FusionaPalabras(Action<string, string> funcionFinal)
        {
            funcionFinal("TEXTO FUSIONADO","CON DELEGADO ACTION COMO PARAMETRO");
        }

        public static void UnirPalabras(string txt1, string txt2)
        {
            Console.WriteLine(txt1+" "+txt2);
        }

        public static int CuentoPalabras(string txt)
        {
            return txt.Split(" ").Length;
        }

        public static void HacerAlgo(Mostrar funcionFinal)
        {
            funcionFinal("TEXTO ROJO CON DELEGADO COMO PARAMETRO");
        }


        public static void ShowInRed(string texto) //no tiene porque llamarse cadena
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void Show(string texto) //no tiene porque llamarse cadena
        {
            Console.WriteLine(texto);
        }
    }
}
