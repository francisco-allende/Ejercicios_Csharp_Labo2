using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //Hereda de event args
    public class InfoTiempoEventArgs : EventArgs
    {
        public int hora;
        public int minuto;
        public int segundo;

        public InfoTiempoEventArgs(int hora, int minuto, int segundo)
        {
            this.hora = hora;
            this.minuto = minuto;
            this.segundo = segundo;
        }
    }
}
