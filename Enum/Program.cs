using System;

namespace mi_primer_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asigno un valor 
            Ecolor miColor = Ecolor.Amarillo;
            //Console.WriteLine(miColor);

            //Recorro mi enumerado con el metodo estático GetNames. Retorna un array de strings
            foreach(string nombreColor in Enum.GetNames(typeof(Ecolor)))
            {
                Console.WriteLine(nombreColor);
            }

            //Recorro mi enumerado con el metodo estático GetValues. Retorna con tipo de dato Ecolor
            foreach (Ecolor valoresColor in Enum.GetValues(typeof(Ecolor)))
            {
                Console.WriteLine(valoresColor); //en consola se ve igual, pero el tipo de dato es otro
            }

            //Mismo foreach GetValues. Casteo a int para averiguar su constante numerica asignada
            foreach (Ecolor valoresColor in Enum.GetValues(typeof(Ecolor)))
            {
                Console.WriteLine((int)valoresColor); 
            }

            //Lo mismo pero con for
            //Solo sirve si no hay saltos y los valores son 0, 1, 2, etc

            int cantidad = Enum.GetValues(typeof(Ecolor)).GetLength(0);
            Ecolor unColor;

            for (int i = 0; i < cantidad; i++)
            {
                unColor = (Ecolor)i; //casteo a ecolor. 
                Console.WriteLine($"El color {unColor} posee el valor numerico constante {i}");
            }

            //Usando switch con enum
            switch (miColor)
            {
                case Ecolor.Rojo:
                    break;
                case Ecolor.Azul:
                    break;
                case Ecolor.Amarillo:
                    break;
                case Ecolor.Verde:
                    break;
                case Ecolor.Negro:
                    break;
                case Ecolor.Blanco:
                    break;
                default:
                    break;
            }

            //Instancio una bicicleta blanca
            Bicicleta miBici = new Bicicleta(Ecolor.Blanco);
            Console.WriteLine($"Tengo una bici de color {miBici.color}");

            //Casteo string a ecolor. Ignora mayusculas, es case insensitive
            Bicicleta miBici2 = new Bicicleta((Ecolor)Enum.Parse(typeof(Ecolor), "azul", true));
            Console.WriteLine($"castie un string a ecolor { miBici2.color}");



        }
    }
}
