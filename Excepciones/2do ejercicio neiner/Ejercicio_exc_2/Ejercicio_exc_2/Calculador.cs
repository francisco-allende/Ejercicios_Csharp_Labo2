using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace Ejercicio_exc_2
{
    public partial class Calculador : Form
    {
        public Calculador()
        {
            InitializeComponent();
        }

        private void Calculador_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        //Vamos a hacer que 1km son 10 litros de nafta
        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            string kilometrosTxt = txtBoxKM.Text;
            string litrosTxt = txtBoxLit.Text;
            float kilometros = 0;
            float litros = 0;

            try
            {
                Logica.ChequearParametros(kilometrosTxt, litrosTxt);
                kilometros = Logica.ConversionPosible(kilometrosTxt);
                litros = Logica.ConversionPosible(litrosTxt);
                Logica.PuedoDividir(kilometros);

                richTextBox.Text = Logica.Calcular(kilometros, litros);
            }
            catch (Exception ex)
            {
                string titulo = "Ups! Sucedio un error";
                MessageBoxButtons opciones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Error;
                string mensaje = "";

                //El codigo esta bien, pero no sirve, ya que no hay nunca inner exceptions
                while (ex.InnerException != null) 
                {
                    mensaje += ex.Message + "\n";
                    ex = ex.InnerException;
                }
                mensaje += ex.Message + "\n"; //capturo el primero, la locomotra

                MessageBox.Show(mensaje, titulo, opciones, icono);
            }
        }
    }
}
