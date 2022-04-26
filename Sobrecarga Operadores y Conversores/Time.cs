using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sobrecarga_constructores_tiempo
{
    class Time
    {
        private int hour;
        private int minutes;
        private int seconds;

        //El "original". Recibe todos, setea todos.
        public Time(int hour, int minutes, int seconds)
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        //Recibe 2 parametros, hardcodea los segundos
        public Time(int hour, int minutes) : this(hour, minutes, 59)
        {

        }

        //Recibe un unico parametro, hardcodea el 2do y all llamar al otro, termina por hardcodear el 3ero
        public Time(int hour) : this(hour, 59)
        {

        }

        //Metodo sin parametros
        public string Mostrar()
        {
            return $"{this.hour} : {this.minutes} : {this.seconds}";
        }

        //Comparo que cada valor sea identico. Ya puedo igualar estos objetos, sobrecargue el operador!
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.hour == t2.hour && t1.minutes == t2.minutes && t1.seconds == t2.seconds; 
        }

        //El == (y otros mas) se sobrecargan de a pares. El par de == es !=
        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2); //Niego que sean iguales. Ya puedo igualarlos y por ende, negarlos y hacerlos distintos
        }

        //Casteo de operador + para sumar objetos
        public static int operator +(Time t1, Time t2)
        {
            return (t1.hour + t2.hour) + (t1.minutes + t2.minutes) + (t1.seconds + t2.seconds);
        }

        //Casteo de operador - para restar objetos
        public static int operator -(Time t1, Time t2)
        {
            return (t1.hour - t2.hour) - (t1.minutes - t2.minutes) - (t1.seconds - t2.seconds);
        }

        //CASTEO IMPLICITO
        //Convierto string a objeto Time. Retorna un Time y por eso esta ahi en la firma
        public static implicit operator Time(string tiempoEnCaracteres)
        {
            string [] tiempoStr = tiempoEnCaracteres.Split(':'); //No visto, paso string a array, split es de arrays
            //Parseo los valores y los guardo en variables
            int hour = int.Parse(tiempoStr[0]);
            int min = int.Parse(tiempoStr[1]);
            int sec  = int.Parse(tiempoStr[2]);

            //Retorno un objeto Time cargado con los valores que envio el string
            return new Time(hour, min, sec);
        }

        //CASTEO EXPLICITO
        //suma los valores de hora y minutos por 60 para pasar todo a segundos. Enroscado, pero se entiende.
        public static explicit operator int(Time t)
        {
            return (t.hour * 60 + t.minutes * 60) + t.seconds;
        }
    }
}
