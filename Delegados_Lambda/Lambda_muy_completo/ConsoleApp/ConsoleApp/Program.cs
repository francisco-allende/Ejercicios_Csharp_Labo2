using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>(){ 1, 2, 3, 150, 5, 99};
            
            //find retorna el 1er elemento encontrado. Condicion
            int num = lista.Find((x) => x > 20);
            Console.WriteLine("Find: " +num);

            //filter (o find all). Retorna un list filtrado. For each para mostrar
            List<int> filterList = lista.FindAll((x) => x > 20);
            filterList.ForEach((x) => Console.WriteLine("Find all: "+x));

            //Contains. retorna booleano si lo encuentra, flase sino. Es como el Some de js
            bool existe = lista.Contains(99);

            //Necesita un delegado como condicion si no quiero q sea valor exacto
            //Any es de Linq. Puedo poner directo la lambda tmbn, usar exists
            Func<int, bool> funcMayorACinco = ((x) => x > 5);
            bool existeConDele = lista.Any(funcMayorACinco);
            bool existeConLamda = lista.Exists((num)=> num >100);

            Console.WriteLine("Contains: "+existe);
            Console.WriteLine("Any, Linq, delegado func: "+existeConDele);
            Console.WriteLine("exists o any, directo el lamda: "+existeConLamda);


            //Instancio producto y lista
            Producto pr = new Producto();
            List<Producto> productos = new List<Producto>()
            {
                new Celular(true, "Samsung S22", 150000),
                new Celular(true, "Motorola E Plus", 129999),
                new Celular(false, "Samsung A12", 36000),
                new Tv(true, "Sony Bravia 4k", 199999),
                new Tv(false, "Phillips de culo gordo", 30000),
            };


            //simplemente itero con for each. mostrar retorna str. acumulo y muestro
            string everyProduct = "";
            productos.ForEach((item) => everyProduct += item.Mostrar());
            Console.WriteLine("\n\t\tTabla productos\n\n"+everyProduct+"\n");

            //Filtro solo los que son marca samsung
            pr.Lista = productos.FindAll((x) =>x.Marca.Contains("Samsung"));
            pr.Lista.ForEach((x) => Console.WriteLine(x.Mostrar()));


            //Sort con lamda, el mejor de todos
            Console.WriteLine("\n\n\t\t Sort con Lamda\t");
            everyProduct = "";
            productos.Sort((x, y) => y.Precio - x.Precio);
            productos.ForEach((x)=> everyProduct += x.Mostrar());
            Console.WriteLine(everyProduct);


            //Sort con puntero a funcion con criterio
            Console.WriteLine("\n\n\t\t Sort con puntero a funcion\t");
            everyProduct = "";
            pr.Lista.Sort(ordenameDaddy);
            pr.Lista.ForEach((x)=> everyProduct+=x.Mostrar());
            Console.WriteLine(everyProduct);


            //Sort con delegado que es un criterio de orden
            Console.WriteLine("\n\n\t\t Sort con delegado\t");
            everyProduct = "";
            Func<Producto, Producto, int> funcSortMe = ordenameDaddyDelegado;
            productos.Sort((x, y)=> funcSortMe(x, y)); //esto si o si asi mando los params
            productos.ForEach((item) => everyProduct += item.Mostrar());
            Console.WriteLine(everyProduct);


            //Order by alfabetico
            Console.WriteLine("\n\n\t\t Order By alfabetico\t");
            everyProduct = "";
            productos.OrderBy((x)=> x.Marca); 
            productos.ForEach((item) => everyProduct += item.Mostrar());
            Console.WriteLine(everyProduct);



            //Sort alfabetico con puntero
            Console.WriteLine("\n\n\t\t Sort Alfabetico puntero a func\t");
            everyProduct = "";
            productos.Sort(ordenAlfabetico);
            productos.ForEach((item) => everyProduct += item.Mostrar());
            Console.WriteLine(everyProduct);


            //Sort alfabetico con delegado
            Console.WriteLine("\n\n\t\t Sort Alfabetico con delegado\t");
            everyProduct = "";
            Func<Producto, Producto, int> funcAlfabetico = ordenAlfabetico;
            productos.Sort((x, y) => funcAlfabetico(x, y));
            productos.ForEach((item) => everyProduct += item.Mostrar());
            Console.WriteLine(everyProduct);




            //integrador, un poco de todo
            Console.WriteLine("\n\n\t\t Contains con Predicate con lamda y delegado\t");
            everyProduct = "";
            Predicate<Producto> funcTieneCulo = (x)=> x.Marca.Contains("culo gordo");

            productos.ForEach((item) =>
            {
                if (funcTieneCulo(item))
                    Console.WriteLine("\nHay un producto con culo gordo: "+item.Mostrar());
            });
           
            Console.ReadKey();
        }

        //String compare retorna un int segun sea en ascii su valor
        public static int ordenAlfabetico(Producto x, Producto y)
        {
            int retorno = 0;

            if(string.Compare(x.Marca, y.Marca) > 0)
            {
                retorno = 1;
            }
            if(string.Compare(x.Marca, y.Marca) < 0)
            {
                retorno = -1;
            }

            return retorno;
        }

        public static int ordenameDaddyDelegado(Producto x, Producto y)
        {
            int retorno = 0;

            if (x.Precio > y.Precio)
            {
                retorno = 1;
            }
            else if (x.Precio < y.Precio)
            {
                retorno = -1;
            }

            return retorno;
        }

        public static int ordenameDaddy(Producto x, Producto y)
        {
            int retorno = 0;

            if(x.Precio > y.Precio)
            {
                retorno = 1;
            }
            else if(x.Precio < y.Precio)
            {
                retorno = -1;
            }

            return retorno;
        }

        public class Producto
        {
            private string marca;
            private int precio;
            private List<Producto> lista;

            public string Marca { get => marca; set => marca = value; }
            public int Precio { get => precio; set => precio = value; }
            public List<Producto> Lista { get => lista; set => lista = value; }


            public Producto()
            {
                this.lista = new List<Producto>(); 
            }
            public Producto(string marca, int precio):this()
            {
                this.marca = marca;
                this.precio = precio;
            }

            public virtual string Mostrar()
            {
                return $"- {this.Marca} - {this.Precio}";
            }

    }

        public class Celular : Producto
        {
            private bool tiene5g;
            public bool Tiene5g { get => tiene5g; set => tiene5g = value; }

            public Celular()
            {

            }

            public Celular(bool tiene5g, string marca, int precio)
                :base(marca, precio)
            {
                this.tiene5g = tiene5g;
            }

            public override string Mostrar()
            {
                return $"{base.Mostrar()} - es 5G {this.tiene5g}\n";
            }
        }

        public class Tv : Producto
        {
            private bool esSmart;
            public bool EsSmart { get => esSmart; set => esSmart = value; }

            public Tv()
            {

            }

            public Tv(bool esSmart, string marca, int precio) 
                : base(marca, precio)
            {
                this.esSmart = esSmart;
            }

            public override string Mostrar()
            {
                return $"{base.Mostrar()} - es Smart {this.esSmart}\n";
            }
        }

    }
}
