using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Este no tiene async await no sirve
        private void btn_iniciarLongTask2_Click(object sender, EventArgs e)
        {
    
        }

        /* Async lo q busca es "ir de la mano" con un metodo NO es sincronico, osea, 
         * un metodo que NO esta ejecutandose en el hilo principal, sino en un hilo secundario
         * El metodo en si es del hilo 1, pero dentro habre una task en hilo 2
         * 
         * Esto es un evento ¿Porque tiene tambien async y await?
         * Porque va a esperar al que el metodo asincrono que abre un nuevo hilo termine
         * Y como va a tardar mas esta tarea, le digo al form principal que no cuelgue,
         * que siga con lo suyo, pero que banque al metodo asincro no que llamo.

         * Evento async await llama a metodo async await q dentro crea task
        */
        private async void btn_iniciarLongTask_Click(object sender, EventArgs e)
        {
            this.lb_informacion.Text = await GestorDatos.TraerRegistros2Async();
        }


    }
}
