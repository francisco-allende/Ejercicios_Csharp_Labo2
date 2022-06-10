using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Email : IMensaje //al no heredar de nadie, voy directo con el :
    {
        private string account;

        public Email(string account)
        {
            this.account = account;
        }

        public string EnviarMensaje()
        {
            return "im the future\n";
        }

        public string EnviarOtroMensaje(string unMensaje)
        {
            return unMensaje;
        }
    }
}
