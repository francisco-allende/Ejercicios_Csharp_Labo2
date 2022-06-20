using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; // thread.sleep   y   cancellationTokenSource 
using System.Threading.Tasks; // task
using System.Windows.Forms;

namespace Task_09
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts;
       // CancellationToken ct; comentado porque es lo mismo

        public Form1()
        {
            InitializeComponent();
            cts = new CancellationTokenSource(); //siempre instancio antes
         //   ct = cts.Token;
        }

        //Evento asincrono llama a metodo asincrono.
        //Metodo asincrono es cancelable
        private async void btn_longTask_Click(object sender, EventArgs e)
        {
            //Arrancamos con las excepciones porque hilos rompe por todos lados.
            try
            {
                //Le paso el token de cancelacion
                this.lb_informacion.Text = await GestorDatos.TraerRegistros2(cts.Token);
            }
            catch (TaskCanceledException ex) //nativa de Task
            {
                lb_informacion.Text = ex.Message;
            }

            catch (OperationCanceledException ex) //nativa de Task
            {
                lb_informacion.Text = ex.Message;
            }
          
            catch (Exception ex)
            {
                lb_informacion.Text = ex.Message;
            }



        }

        //Cancela todas las tasks secundarias
        private void btn_cancelarTarea_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
