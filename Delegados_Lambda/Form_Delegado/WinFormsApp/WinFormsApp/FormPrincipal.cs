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
    public partial class FormPrincipal : Form
    {
        private FrmMostrar formMostrar;
        private FrmTestDelegados formTestDelegados;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        //Me faltaba asignarle el mdi parent
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.formMostrar = new FrmMostrar();
            //Le digo que el form padre de este mdi es el principal
            this.formMostrar.MdiParent = this; 

            //El gran truco es este. Lo asocio con un metodo del mostrar, por eso sin
            //parentesis, y lo mando y se lo asigno al delegado
            //ahora mi form test delegado posee una referencia al metodo publico del form mostrar
            //y cuando lo invoko, cuando lo uso estoy llamando a este metodo, ya puedo usar un
            //metodo del mostrar en el test delegado. Clave instanciar antes el mostrar.
            this.formTestDelegados = new FrmTestDelegados(formMostrar.ActualizarNombre);
            this.formTestDelegados.MdiParent = this;

            mostrarToolStripMenuItem.Enabled = false;
        }

        private void testDelegadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                formTestDelegados.Show();
                mostrarToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.formMostrar.Show();
        }
    }
}
