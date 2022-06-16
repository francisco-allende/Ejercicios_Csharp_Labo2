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

namespace Vista
{
    public partial class FrmBiblioteca : Form
    {
        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void FrmBiblioteca_Load(object sender, EventArgs e)
        {
            RefrescarBiblioteca();
        }

        private void RefrescarBiblioteca()
        {
            try
            {
                dtgvBiblioteca.DataSource = JuegoDAO.Leer();
                dtgvBiblioteca.Refresh();
                dtgvBiblioteca.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmAlta formAlta = new FrmAlta();

            try
            {
                if(formAlta.ShowDialog() == DialogResult.OK)
                {
                    this.RefrescarBiblioteca();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Chequeo que haya al menos un item seleccionado en el datagrid
                if (dtgvBiblioteca.SelectedRows.Count > 0)
                {
                    //me traigo ese objeto y lo casteo a Biblioteca
                    Biblioteca biblioteca = (Biblioteca)dtgvBiblioteca.CurrentRow.DataBoundItem;
                    JuegoDAO.Eliminar(biblioteca.CodigoJuego); //accedo a su id y lo envio para eliminarlo
                    this.RefrescarBiblioteca();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvBiblioteca.SelectedRows.Count > 0)
                {
                    Biblioteca biblioteca = (Biblioteca)dtgvBiblioteca.CurrentRow.DataBoundItem;

                    FrmAlta formModificar = new FrmAlta(biblioteca.CodigoJuego, true);

                    if(formModificar.ShowDialog() == DialogResult.OK)
                    {
                        this.RefrescarBiblioteca();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
