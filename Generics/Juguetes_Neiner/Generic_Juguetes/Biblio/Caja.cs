using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public static class Caja<T> 
        where T: Juguete
    {
        public static List<T> lista;

        static Caja()
        {
            lista = new List<T>();
        }

        //Metodo estatico. No necesito traeme la U a la clase
        public static List<T> Agregar<U>(T param) 
            where U : T
        {
            if(param != null)
            {
                Caja<T>.lista.Add(param);
            }

            return Caja<T>.lista; ;
        }

        public static string Mostrar<V>()
            where V : T
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in lista)
            {
                sb.AppendLine($"///////////////////////////////\n{item.ToString()}\n//////////////////////////////\n");
            }

            return sb.ToString();
        }



    }
}
