using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Usuario
    {
        private string username;
        private int codigoUsuario;

        public int CodigoUsuario { get => this.codigoUsuario;}

        public Usuario(string username, int codigoUsuario)
        {
            this.username = username;
            this.codigoUsuario = codigoUsuario;
        }

        public Usuario()
        {

        }

        public override string ToString()
        {
            return $"{this.username}";
        }
    }
}
