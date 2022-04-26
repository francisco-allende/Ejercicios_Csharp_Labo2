using System;

namespace sobrecarga_constructores_tiempo
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(8, 30, 00);
            Time time2 = new Time(10, 45);
            Time time3 = new Time(12);

            string act1 = "laburo";
            string act2 = "me rasco las bolaas";

            Console.WriteLine(time1.Mostrar() + "\n");
            Console.WriteLine(time2.Mostrar(act1) + "\n");
            Console.WriteLine(time3.Mostrar(act1, act2) + "\n");
        }
    }
}
