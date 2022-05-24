using System;
using Entidades;

namespace Contabilidad
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio clase generica y objetos
            Contabilidad<Factura, Recibo> accounting = new Contabilidad<Factura, Recibo>();

            Recibo recibo1 = new Recibo();
            Recibo recibo2 = new Recibo(300);
            Recibo recibo3 = new Recibo(500);

            Factura factura1 = new Factura(100);
            Factura factura2 = new Factura(150);
            Factura factura3 = new Factura(80);

            //Agrego a la lista sobrecargando el + segun T || U
            accounting += recibo1;
            accounting += recibo2;
            accounting += recibo3;

            accounting += factura1;
            accounting += factura2;
            accounting += factura3;

            //Muestro
            Console.WriteLine(accounting.Mostrar());
            Console.WriteLine($"\nTotal: { accounting.Calcular()}");
            Console.ReadKey();
        }
    }
}
