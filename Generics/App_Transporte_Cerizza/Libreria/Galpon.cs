using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    //Clase genérica con tipo de dato genérico T
    public class Galpon <T> 
    {  
        int idGalpon;
        int cantidadEstantes;
        string sector;
        //Lista genérica. Mismo tipo de dato T que el de la clase
        List<T> listaDeElementos;     

        //Constructor genérico, instancia la lista
        public Galpon() 
        {
            this.listaDeElementos = new List<T>();
        }

        public Galpon(int idGalpon, int cantidadEstantes, string sector) 
            : this()
        {
            this.idGalpon = idGalpon;
            this.cantidadEstantes = cantidadEstantes;
            this.sector = sector;
        }

        //Mas de lo mismo, getter genérico
        public int CantidadDeElementos
        {
            get
            {
                return listaDeElementos.Count;
            }
        }

        //Esta T es la de Gondola<T> cuando instancie en Program.cs RETORNA T
        public T PrimerElemento()
        {
            return listaDeElementos[0];
        }

        //Recibe algo en el formato de la var que lo invoque, al ser generico cambia
        public bool GuardarObj(T objAGuardar)
        {
            return true;
        }

        public string ShowTipoDeDato()
        { 
            System.Type tipo = this.listaDeElementos.GetType();
            string StrTipo = tipo.ToString();

            StrTipo = finAndRemovedChar(StrTipo, '[');
            StrTipo = finAndRemovedChar(StrTipo, '.');
            StrTipo = StrTipo.TrimEnd(']');

            StrTipo = $"La clase y la lista son de tipo de dato {StrTipo}";

            return StrTipo;
        }

        public string finAndRemovedChar(string palabra, char searchValue)
        {
            int endRemoveIndex = 0;

            foreach (char letter in palabra)
            {
                endRemoveIndex++;
                if (letter == searchValue)
                {
                    break;
                }
            }

            palabra = palabra.Remove(0, endRemoveIndex);

            return palabra;
        }
    }
}
