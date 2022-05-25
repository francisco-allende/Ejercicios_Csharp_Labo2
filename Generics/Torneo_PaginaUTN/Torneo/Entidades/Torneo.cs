using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Torneo<T>
        where T : Equipo
    {
        private string nombre;
        private List<T> listaEquipos;

        public string JugarPartido
        {
            get
            {
                Random rnd = new Random();
                int maxValue = this.listaEquipos.Count;
                int indexOfEquipo1 = rnd.Next(0, maxValue);
                int indexOfEquipo2 = rnd.Next(0, maxValue);
                bool hayE1 = false;
                bool hayE2 = false;
                T equipo1 = null;
                T equipo2 = null;

                for (int i = 0; i <= maxValue; i++)
                {
                    if(i == indexOfEquipo1)
                    {
                        equipo1 = this.listaEquipos[i];
                        hayE1 = true;
                    }

                    if(i == indexOfEquipo2)
                    {
                        equipo2 = this.listaEquipos[i];
                        hayE2 = true;
                    }
                }

                if(hayE1 && hayE2)
                {
                    return CalcularPartido(equipo1, equipo2);
                }

                return "No se pudo jugar el partido";
                
            }
        }

        public Torneo(string nombre)
        {
            this.nombre = nombre;
            this.listaEquipos = new List<T>();
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Nombre del Torneo: {this.nombre}\n");

            foreach (T item in this.listaEquipos)
            {
                sb.Append(item.Ficha());
            }

            return sb.ToString();
        }

        private string CalcularPartido(T equipo1, T equipo2)
        {
            Random rnd = new Random();
            int puntosEquipo1 = 0;
            int puntosEquipo2 = 0;

            if (equipo1 is EquipoFutbol)
            {
                puntosEquipo1 = rnd.Next(0, 7);
                puntosEquipo2 = rnd.Next(0, 7);
            }
            else
            {
                puntosEquipo1 = rnd.Next(0, 124);
                puntosEquipo2 = rnd.Next(0, 124);
            }
   

            return $"{equipo1.nombre} {puntosEquipo1} - {equipo2.nombre} {puntosEquipo2}";
        }

        public static bool operator ==(Torneo<T> t ,T e)
        {
            foreach (T item in t.listaEquipos)
            {
                if(item == e) //ya esta inscripto
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Torneo<T> t, T e)
        {
            return !(t == e);
        }

        public static Torneo<T> operator +(Torneo<T> t, T e)
        {
            if(t != e)
            {
                t.listaEquipos.Add(e);
            }

            return t;
        }
    }
}
