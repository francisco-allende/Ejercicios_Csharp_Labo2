using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexadores__de_clase_
{
    public class Dias
    {
        private string[] diasHabiles = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes"}; //array de strings
        private string primerDiaHabil = "Lunes";
        private string ultimoDiaHabil = "Viernes"; 

        //indexador
        public string this[int index] //index no es una palabra reservada
        {
            get
            {
                if (index < diasHabiles.Length) //valido el rango
                {
                    return diasHabiles[index];
                }
                return "";
            }
            set
            {
                diasHabiles[index] = value;
            }
        }

        //Sobrecargo. Bizarro, poco usado
        public string this[string index]
        {
            get
            {
                if(index == "primerDia")
                {
                    return primerDiaHabil;
                }
                else if(index == "ultimo dia")
                {
                    return ultimoDiaHabil;
                }

                return "";
            }
        }
    }
}
