using System;

namespace sobrecarga_constructores_tiempo
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(8, 30, 00);
            Time copiaTime1 = new Time(8, 30, 00);

            Console.WriteLine($"Comparcion de objetos de identico valor == {time1 == copiaTime1}"); //me tira false. Compara espacios en memoria, no valores de atributos
            Console.WriteLine($"Comparcion de objetos de identico valor != {time1 != copiaTime1}");
            Console.WriteLine($"Sumo objetos como si nada sobrecargando el operador + {time1 + copiaTime1}");
            Console.WriteLine($"Resto objetos como si nada sobrecargando el operador - {time1 - copiaTime1}");

            /*********
            Sobrecarga de operadores de CONVERSION
            /*********/

            //Casteo implícito
            //No interviene el programador, no hay pérdida de información

            //Convierto un string a un objeto Time de manera IMPLICITA
            Time timeEnStringCasteadoImplicito = "21:45:19"; //me deja hacer Time x = "string";

            Console.WriteLine($"string parseado a objeto time {timeEnStringCasteadoImplicito.Mostrar()}"); //puedo acceder a metodos

            //Casteo explícito
            //Interviene el prgramdor, se puede perder informacion

            int tiempoEnSegundos = (int)time1;
            Console.WriteLine($"Casteo explicito. El total de segundos es de {tiempoEnSegundos}");

            


        }
    }
}
