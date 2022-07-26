using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 4, 6, 7, 8 };

            if (FindConsecutiveNumber(arr) != -1)
            {
                Console.WriteLine($"Los numeros consecutivos son: {FindConsecutiveNumber(arr)}\n ");
            }
            else
            {
                Console.WriteLine("Error en consecutive");
            }

            //Declaro arr2, instancio delegado (no importa si es metodo static o no), lo llamo y muestro. 
            int[] arr2 = { 5, 8, 4, 3, 1, 6, 7, 8 };
            Func<int[], int> dele = FindDuplicateNumber;

            Console.WriteLine("El valor repetido es " + dele.Invoke(arr));
            Console.WriteLine("Lo mismo sin el invoke. " + dele(arr));

            //Declara, cargo y sorteo lamda
            List<int> lista = new List<int>();

            for (int i = 0; i < arr2.Length; i++)
            {
                lista.Add(arr2[i]);
            }

            lista.Sort((x, y) => x - y);

            foreach (int item in lista)
            {
                Console.WriteLine(item);
            }
        }

        public static int ReturnNumChanged(int num)
        {
            return 0 ;
        }

        public static int FindDuplicateNumber(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - 1; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        return arr[i];
                    }
                }
            }

            return -1;
        }

        public static int FindConsecutiveNumber(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0 && arr[i] == arr[i -1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
