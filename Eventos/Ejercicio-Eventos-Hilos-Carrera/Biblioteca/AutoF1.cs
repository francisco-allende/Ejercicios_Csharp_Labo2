using System;

namespace Biblioteca
{
    public class AutoF1
    {
        string escuderia;
        int posicion;
        int puntoPartida;
        int velocidad;

        public AutoF1()
        {
        }

        public AutoF1(string escuderia, int velocidad, int puntoPartida)
        {
            this.escuderia = escuderia;
            this.velocidad = velocidad;
            this.puntoPartida = puntoPartida;

        }

        public string Escuderia { get => escuderia; set => escuderia = value; }
        public int Posicion { get => posicion; set => posicion = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }

        /// <summary>
        /// La propiedad UbicacionEnPista retornara el punto de partida.
        /// </summary>

        public int UbicacionEnPista { get => puntoPartida; set => puntoPartida = value; }



        //TODO:  sumara el atributo velocidad a puntoPartida.
        public void Acelerar()
        {
            puntoPartida += velocidad;
        }

        //TODO: Sobre escribir el método ToString, el cual expondrá la escudería y la posición del vehículo:
        public override string ToString()
        {
            return $"Escuderia {this.escuderia} - Posición {this.posicion}";
        }
    }
}
