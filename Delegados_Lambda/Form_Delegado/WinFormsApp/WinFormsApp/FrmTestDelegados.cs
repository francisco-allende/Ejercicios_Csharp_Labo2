using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FrmTestDelegados : Form
    {
        //Creo el delegado
        //Lo hago action. No retorna nada y tiene un param


        //Tengo lios para instanciarlo y usarlo fuera del load, por lo que 
        //sera tambien un atributo de mi form. Esta vez si sera privado al ser atribute


        //ANTES, CON DELEGADO PROPIO
        //public delegate void DelegateActualizarNombre(string name);
        //private DelegateActualizarNombre actualizarNombre;

        //AHORA, CON ACTION. No creo delegado, ya es de System, solo hago el atributo
        private Action<string> actualizarNombre;

        public FrmTestDelegados(Action<string> delegadoActualizarNombre)
        {
            InitializeComponent();
            //Lo recibo por param del form principal y lo instancio
            this.actualizarNombre = delegadoActualizarNombre;
        }

        private void FrmTestDelegados_Load(object sender, EventArgs e)
        { 

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Lo cargo con su parametro, que es lo que tomo del input. Ambos hacen lo mismo
            //this.actualizarNombre(textNombre.Text);
            this.actualizarNombre.Invoke(textNombre.Text);
        }
    }
}
