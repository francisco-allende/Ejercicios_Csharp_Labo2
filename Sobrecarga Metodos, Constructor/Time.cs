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

        //Metodos sobrecargado con un unico parámetro
        public string Mostrar(string actividad1)
        {
            return $"A las {Mostrar()} tengo {actividad1}";
        }

        //Metodo sobrecargado con dos parametros
        public string Mostrar(string actividad1, string actividad2)
        {
            return $"{Mostrar(actividad1)} y luego {actividad2}";
        }

        //Esto no lo puedo hacer
        /*
        public int Mostrar()
        {
            return 404;
        }
        */
    }
}
