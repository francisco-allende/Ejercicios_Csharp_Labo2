using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Contabilidad<T, U>
        where T: Documento //Nombre clase base. Puede ser Documento o derivados
        where U : Documento, new() //Restricción. Deberá tener un constructor público y sin parámetros. (Osea, ser Recibo)
    {
        private List<T> egresos;
        private List<U> ingresos;

        public Contabilidad()
        {
            this.egresos = new List<T>();
            this.ingresos = new List<U>();
        }

        //Agrega un elemento a la lista egresos
        public static Contabilidad<T, U> operator +(Contabilidad<T, U> c, T egreso)
        {
            if(egreso != null)
            {
                c.egresos.Add(egreso);
            }
       
            return c;
        }

        //Agrega un elemento a la lista de ingresos. U es Recibo
        public static Contabilidad<T, U> operator +(Contabilidad<T, U> c, U ingreso)
        {
            if (ingreso != null)
            {
                c.ingresos.Add(ingreso);
            }

            return c;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Egresos: \n");

            foreach (T item in this.egresos)
            {
                sb.AppendLine(item.ToString());
            }


            sb.AppendLine("\nIngresos: \n");

            foreach (U item in this.ingresos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public int Calcular()
        {
            int sumaEgresos = 0;
            int sumaIngresos = 0;
            int total = 0;

            foreach (T item in this.egresos)
            {
                sumaEgresos += item.castMeDaddy();
            }

            foreach(U item in this.ingresos)
            {
                sumaIngresos += item.castMeDaddy();
            }

            total = sumaIngresos - sumaEgresos;

            return total;
        }
    }
}
