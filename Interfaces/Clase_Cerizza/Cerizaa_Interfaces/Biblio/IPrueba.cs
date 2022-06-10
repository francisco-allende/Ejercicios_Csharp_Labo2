using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public interface IPrueba<T> 
        where T: Persona, new()
    {
        //retorna un T persona, recibe un U animal volador. Metodo genérico
        T MostrarPersona<U>(U nombre) where U : AnimalVolador; 
    }
}
