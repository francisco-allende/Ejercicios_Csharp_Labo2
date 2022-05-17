using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace TestProject1
{
    [TestClass]
    public class StringTester
    {
        [TestMethod]
        public void ContarPalabras_CuandoRecibe2Palabras_Shoul_RetornarNumero2()
        {
            //Arrange. Instancio, inicializo variables para que funque el metodo a testear
            string texto = "Hola Mundo";
            int expected = 2; //es una convencion. Yo espero un 2
            int actual; //otra convencion. Es el valor actual

            //Act
            actual = texto.ContarPalabras();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContarPalabras_CuandoRecibe2Palabras_Shoul_RetornarNumero2()
        {
            //Arrange. Instancio, inicializo variables para que funque el metodo a testear
            string texto = "Hola Mundo";
            int expected = 1; //es una convencion. Yo espero un 2
            int actual; //otra convencion. Es el valor actual

            //Act
            actual = texto.ContarPalabras();

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
