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
    public partial class FrmMostrar : Form
    {
        public FrmMostrar()
        {
            InitializeComponent();
        }

        //Metodo asociado al delegado. Hago Invoke con el boton actualizar del frmTestDelegados
        public void ActualizarNombre(string value)
        {
            labelNombre.Text = value;
        }
    }
}
