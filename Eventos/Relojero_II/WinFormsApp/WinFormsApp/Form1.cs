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
        private Temporizador temporizador;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.temporizador = new Temporizador(1000);
            temporizador.TiempoCumplido += AsignarHora;
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            temporizador.IniciarTemporizador(); 
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            temporizador.DetenerTiempo();
        }

        private void AsignarHora()
        {   
            //Invoke required sera true si estamos en un hilo distinto al que instanciamos
            //el form y los controles
            //false si no estamos en ese hilo
            if(labelHora.InvokeRequired) 
            {
                //Guardo en un delegado el metodo que quiero llamar
                //desde el hilo donde se instancio el control o form. 
                //El metodo que va a cambiar el control. Al ser este, es recursivo
                //Con invoke ejecuto el metodo referenciado desde el hilo correcto
                Action asignarHora = AsignarHora;
                labelHora.Invoke(asignarHora);
            }
            else
            {
                //Recursivo, vuelvo al mismo metodo desde el primer hilo.
                //El invokeRequired pasa a ser false y ya puedo cambiar el label
                labelHora.Text = $"{DateTime.Now:G}";
            }
        }

      
    }
}
