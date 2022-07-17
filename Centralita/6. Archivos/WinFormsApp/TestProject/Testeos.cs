using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblio;

namespace TestProject
{
    [TestClass]
    public class Testeos
    {
        [TestMethod]
        public void ValidaInstanciaDeLaListaDeLlamadasDeCentralita_Shoul_RetrunUnElemento()
        {
            //Arrange
            Centralita central = new Centralita();
            Local l = new Local("X", 8, "Y", 9);
            int expected = 1;
            int actual;

            //Act
            central = central += l;
            actual = central.Llamadas.Count;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        //En este metodo y el siguiente yo DESEO que se lanze una excepcion
        //por lo que uso la etiqueta de ExpectedExecption. 
        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void LanzarExcepcionConDosLlamadasLocalesIguales()
        {
            //Arrange
            Centralita c = new Centralita("Poronga");
            Local l1 = new Local("origennn", 666, "Destinooo", 000);
            Local l2 = new Local("origennn", 777, "Destinooo", 111);

            //Act. El test lanza una exception, lo que esperaba!
            c += l1;
            c += l2;
        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void LanzarExcepcionConDosLlamadasProvincialesIguales()
        {
            //Arrange
            Centralita c = new Centralita("Poronga");
            Provincial p1 = new Provincial("origennn", Franja.Franja_1, 3, "Destinooo");
            Provincial p2 = new Provincial("origennn", Franja.Franja_2, 33, "Destinooo");

            //Act
            c += p1;
            c += p2;
        }


        [TestMethod]
        public void ComparaInstancias_Should_ReturnTrueSiCompartenTipoClase()
        {
            Local l1 = new Local("origennn", 8, "Destinooo", 9);
            Local l2 = new Local("origennn", 88, "Destinooo", 99);
            Provincial p1 = new Provincial("origennn", Franja.Franja_1 , 3, "Destinooo");
            Provincial p2 = new Provincial("origennn", Franja.Franja_2, 33, "Destinooo");

            bool expectedL = true;
            bool expectedP = true;
            bool expectedMix = false;

            bool locales = l1.Equals(l2);
            bool provinciales = p1.Equals(p2);
            bool mixtos = l1.Equals(p2);

            //Assert
            Assert.AreEqual(expectedL, locales);
            Assert.AreEqual(expectedP, provinciales);
            Assert.AreEqual(expectedMix, mixtos);
        }
    }
}
