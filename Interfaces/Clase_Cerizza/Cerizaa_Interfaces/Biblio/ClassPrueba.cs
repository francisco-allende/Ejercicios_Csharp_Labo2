using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ClassPrueba : IPrueba<Courier>
    {
        public Courier MostrarPersona<U>(U nombre) where U : AnimalVolador
        {
            return new Courier();
        }
    }
}
