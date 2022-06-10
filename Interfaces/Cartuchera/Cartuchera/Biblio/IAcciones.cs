using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public interface IAcciones
    {
        //Asi se hace la firma en una interfaz de properties. Probar de sacar el public, mepa que esta de mas
        public ConsoleColor Color { get; set; }
        public float UnidadDeEscritura { get; set; }

        EscrituraWrapper Escribir(string texto);
        bool Recargar(int unidades);
    }
}
