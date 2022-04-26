using System;

namespace Biblioteca
{
    public abstract class Animal
    {
        protected int id;
        string nombre;
        int edad;

        public Animal(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public abstract string EmitirSonido();

        public static bool operator ==(Animal a1, Animal a2)
        {
            return a1 is not null &&
                a2 is not null &&
                a1.nombre == a2.nombre &&
                a1.edad == a2.edad;
        }

        public static bool operator !=(Animal a1, Animal a2)
        {
            return !(a1 == a2);
        }

        //es override porque es heredado de la clase Object
        public override bool Equals(object obj)
        {
            return this == (Animal)obj; 
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode(); //de esta forma asigno el id con el hash code 
        }
    }
}
