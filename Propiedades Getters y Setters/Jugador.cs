using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getter_Y_Setters
{
    public class Jugador //ir a la izq, quick actions, generate constructor
    {
        private int dni;
        private string nombre;
        private int partidosJugados;
        private int totalGoles;
        private float promedioGoles;
        private Color colorCamiseta;


        //Propiedad nombre con sintaxis resumida. Susceptible a errores, no me funciona bien
        //public string Nombre { get; set; }

        //Lo mejor es hacerlo de la manera segura
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        //Propiedad dni con sintaxis mas explicativa
        public int Dni
        {
            get
            {
                return this.dni; 
            }
            set
            {
                this.dni = value;
            }
        }

        //Propiedad con logica que retorna el promedio
        public float PromedioGoles
        {
            get
            {
                return (float)totalGoles / partidosJugados;
            }
        }
        
        //Lo mismo con enum
        public Color ColorCamiseta
        {
            get
            {
                return this.colorCamiseta;
            }
            set
            {
                this.colorCamiseta = value;
            }
        }

        public Jugador(int dni, string nombre, int partidosJugados, int totalGoles)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.partidosJugados = partidosJugados;
            this.totalGoles = totalGoles;
        }
    }
}
