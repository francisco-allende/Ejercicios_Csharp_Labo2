using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private async void btn_iniciar_Click(object sender, EventArgs e)
        {
            //Loop, hasta que se cierre la app
            for(; ; )
            {
                string time = await AsignarHora(); //retorna string en realidad. Debe ser task<stirng> para el await
                labelHora.Text = time; //modifico desde aca ya que este control es del hilo 1
                richTextBox.Text += "\n"+time;
            }
        }

        //retorna string. Para esto, necesito guardarlo en un Task<stirng>
        //ya que el int normal, void, string no pueden tener await
        private Task<string> AsignarHora()
        {   
            Task<string> getTime = Task.Run(() =>
            {
                string time = "";
                DateTime dt = DateTime.Now;
                Thread.Sleep(1000);
                DateTime dt2 = DateTime.Now;

                if (dt.Second != dt2.Second)
                {
                    time = $"{DateTime.Now:G}";
                }
                return time;
            });

            return getTime;
        }

    }
}
