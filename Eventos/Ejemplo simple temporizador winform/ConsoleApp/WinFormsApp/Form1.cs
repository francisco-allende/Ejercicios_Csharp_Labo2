using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblio;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Temporizador temp = new Temporizador();
            temp.OnSegundosRestantes += MostrarTiempoRestante;
            temp.OnTiempoFinalizado += NotificarTiempoCumplido;
            temp.Ejecutar(int.Parse(textBox_Result.Text));
        }

        private void NotificarTiempoCumplido()
        {
            MessageBox.Show("Tiempo cumplido!");
        }

        private void MostrarTiempoRestante(int segundos)
        {
            if (this.InvokeRequired)
            {
                //Delegado que encapusla refe al mismo metodo
                Action<int> delegado = MostrarTiempoRestante;
                //invoke con delegado y "array de objects"
                Invoke(delegado, segundos);
            }
            else
            {
                label1.Text = $"Quedan {segundos} segundos";
            }
        }
    }
}
