using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Carta : Papel, IMensaje
    {
        public string sello;
        List<Carta> cartaList;

        public Carta(string tipo, int cantidadHojas, string sello) : base(tipo, cantidadHojas)
        {
            this.sello = sello;
        }

        public string AbrirCarta()
        {
            return "Abriendo carta";
        }

        public string EnviarMensaje()
        {
            return "Esta es una declaracion de guerra\n";
        }

        public string EnviarOtroMensaje(string unMensaje)
        {
            return unMensaje;
        }

    }
}
