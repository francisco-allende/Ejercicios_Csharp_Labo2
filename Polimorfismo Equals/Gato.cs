using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Gato : Animal
    {

        bool tienePulgas;

        public Gato(string nombre, int edad) : base(nombre, edad)
        {
            this.tienePulgas = false;
        }

        public override string EmitirSonido()
        {
            return "Miau";
        }

        public static bool operator ==(Gato g1, Gato g2)
        {
            return (Animal)g1 == g2 && g1.tienePulgas == g2.tienePulgas; //casteo a animal el g1 y g2
        }

        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }

        public override bool Equals(object obj)
        {
            Gato gato = obj as Gato; //as intenta castear. Si no puede hacerlo, retorna null
            return gato is not null && this == (Gato)obj; //instancia de mi objeto, quiero que use este ==
        }

        public override int GetHashCode()
        {
            return this.id; //ta fue dado en Animal por el hash code, por eso ahora solo retorna el id
        }
    }
}
