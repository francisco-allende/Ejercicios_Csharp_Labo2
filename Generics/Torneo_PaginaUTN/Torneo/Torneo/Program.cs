using System;
using Entidades;

namespace Torneo
{
    class Program
    {
        static void Main(string[] args)
        {
            Torneo<EquipoFutbol> miTorneitoFubol = new Torneo<EquipoFutbol>("Copa Libertadores de américa");
            Torneo<EquipoBasket> miTorneitoBasket = new Torneo<EquipoBasket>("Copa NBArg");

            string bocaDate = "03/04/1905";
            string racingDate = "25/03/1903";
            string chacoForEverDate = "27/07/1913";
            string obrasDate = "27/03/1917";
            string atenasDate = "17/04/1938";
            string peñaDate = "11/11/1922";
            
            EquipoFutbol boca = new EquipoFutbol("Boca", DateTime.ParseExact(bocaDate, "dd/MM/yyyy", null));
            EquipoFutbol racing = new EquipoFutbol("Racing", DateTime.ParseExact(racingDate, "dd/MM/yyyy", null));
            EquipoFutbol chacoForEver = new EquipoFutbol("Chaco For Ever", DateTime.ParseExact(chacoForEverDate, "dd/MM/yyyy", null));
            EquipoBasket obrasSanitarias = new EquipoBasket("Obras Sanitarias", DateTime.ParseExact(obrasDate, "dd/MM/yyyy", null));
            EquipoBasket atenasCordoba = new EquipoBasket("Atenas de Cordoba", DateTime.ParseExact(atenasDate, "dd/MM/yyyy", null));
            EquipoBasket peñarolMDQ = new EquipoBasket("Peñarol de Mar del Plata", DateTime.ParseExact(peñaDate, "dd/MM/yyyy", null));

            miTorneitoFubol += boca;
            miTorneitoFubol += racing;
            miTorneitoFubol += chacoForEver;
            
            if(miTorneitoFubol == boca)
            {
                Console.WriteLine("Este equipo de futbol ya esta en el torneo");
            }

            miTorneitoBasket += obrasSanitarias;
            miTorneitoBasket += atenasCordoba;
            miTorneitoBasket += peñarolMDQ;

            if(miTorneitoBasket == obrasSanitarias)
            {
                Console.WriteLine("Este equipo de basket ya esta en el torneo");
            }


            Console.WriteLine("\n\n*** Listado equipos de futbol ***\n\n" +miTorneitoFubol.Mostrar());
            Console.WriteLine("\n\n*** Listado equipos de basket ***\n\n" + miTorneitoBasket.Mostrar());

            Console.WriteLine(miTorneitoFubol.JugarPartido);
            Console.WriteLine(miTorneitoFubol.JugarPartido);
            Console.WriteLine(miTorneitoBasket.JugarPartido);
            Console.WriteLine(miTorneitoBasket.JugarPartido);

            Console.ReadKey();
        }
    }
}
