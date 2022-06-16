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
    public partial class FrmAlta : Form
    {
        int codigoJuego;
        public FrmAlta(int codigoJuego, bool pintar) : this()
        {
            btnGuardar.Text = "Modificar";
            nupPrecio.Maximum = 10000;
            this.codigoJuego = codigoJuego;

            if(pintar)
            {
                PintarForm();
            }
        }

        private void PintarForm()
        {
            Juego juego = JuegoDAO.LeerPorId(codigoJuego);

            txtGenero.Text = juego.Genero;
            txtNombre.Text = juego.Nombre;
            nupPrecio.Value = (decimal)juego.Precio;
        }

        public FrmAlta()
        {
            InitializeComponent();
        }

        private void FrmAlta_Load(object sender, EventArgs e)
        {
            //trae todos los usuarios a la lista de opciones de usuarios disponibles
            //en el boton de opciones desplegables cmb
            cmbUsuarios.DataSource = UsuarioDAO.Leer(); 
        }

        protected virtual void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //casteo para adquirir el item seleccionado del cmb con el username. Adquirido eso, me traigo el id para la bbdd
                if (btnGuardar.Text != "Modificar")
                {
                    Juego juego = new Juego(txtNombre.Text, (double)nupPrecio.Value, txtGenero.Text,
                        ((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario);

                    JuegoDAO.Guardar(juego); //es el alta esto
                }
                else
                {
                    cmbUsuarios.Hide();
                    lblUsuarios.Text = string.Empty;

                    Juego juego = new Juego(txtNombre.Text, (double)nupPrecio.Value, txtGenero.Text, codigoJuego,
                        ((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario);

                    JuegoDAO.Modificar(juego); //es el alta esto
                }
                
                DialogResult = DialogResult.OK; //seteo el ok para referescar en el main form
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
