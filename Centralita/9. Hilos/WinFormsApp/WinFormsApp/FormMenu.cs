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
using EntidadesDAO;

namespace WinFormsApp
{
    public partial class FormMenu : Form
    {
        private Centralita centralita;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            centralita = new Centralita("Nombre Generico");

            try
            {
                List<Local> listaLocal = LocalDAO.Leer();
                List<Provincial> listaProv = ProvincialDAO.Leer();

                if (listaLocal.Count > 1)
                {
                    foreach (Local item in listaLocal)
                    {
                        this.centralita.Llamadas.Add(item);
                    }
                }

                if (listaProv.Count > 1)
                {
                    foreach (Provincial item in listaProv)
                    {
                        this.centralita.Llamadas.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_GenerarLlamada_Click(object sender, EventArgs e)
        {
            this.GenerateSecondaryForm("Llamador");
        }


        private void btn_FactTotal_Click(object sender, EventArgs e)
        {
            this.GenerateSecondaryForm("Mostrar", TipoLlamada.Todas);
        }

        private void btn_FactLocal_Click(object sender, EventArgs e)
        {
            this.GenerateSecondaryForm("Mostrar", TipoLlamada.Local);
        }

        private void btn_FactProv_Click(object sender, EventArgs e)
        {
            this.GenerateSecondaryForm("Mostrar", TipoLlamada.Provincial);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.PreguntarAntesDeCerrar();
        }

        //Metodos

        private void GenerateSecondaryForm(string tipoForm)
        {
            try
            {
                switch (tipoForm)
                {
                    case "Llamador":
                        using(FormLlamador formLlamador = new FormLlamador(this.centralita))
                        {
                            formLlamador.ShowDialog();
                        }
                        
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el formulario");
            }
        }

        private void GenerateSecondaryForm(string tipoForm, TipoLlamada tipo)
        {
            try
            {
                switch (tipoForm)
                {
                    case "Mostrar":
                        using (FormMostrar formMostrar = new FormMostrar(this.centralita, tipo))
                        {
                            formMostrar.ShowDialog();
                        }
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el formulario");
            }
        }

        public void PreguntarAntesDeCerrar()
        {
            string pregunta = "¿Seguro de querer salir?";
            string titulo = "Salir";
            MessageBoxButtons opciones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Question;

            DialogResult respuesta = MessageBox.Show(pregunta, titulo, opciones, icono);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

     
    }
}
