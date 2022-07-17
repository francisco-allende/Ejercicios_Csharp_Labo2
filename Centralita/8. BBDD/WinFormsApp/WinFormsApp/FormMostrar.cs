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
    public partial class FormMostrar : Form
    {
        private Centralita centralita;
        private TipoLlamada keyword;
        public TipoLlamada Keyword { set => keyword = value; }

        public FormMostrar(Centralita centralita, TipoLlamada keyword)
        {
            InitializeComponent();
            this.centralita = centralita;
            this.Keyword = keyword;
        }

        private void FormMostrar_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            this.Mostrar();
        }

        private void Mostrar()
        {
            switch (this.keyword)
            {
                case TipoLlamada.Todas:
                    richTextBox.Text += "Total ganancias: " +this.centralita.GananciasPorTotal.ToString();
                    break;

                case TipoLlamada.Local:
                    richTextBox.Text += "Total por local: " +this.centralita.GananciasPorLocal.ToString();
                    break;

                case TipoLlamada.Provincial:
                    richTextBox.Text += "Total por provincial: " +this.centralita.GananciasPorProvincial;
                    break;
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            { 
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado");
            }
        }
    }
}
