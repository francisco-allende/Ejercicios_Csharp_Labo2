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
using System.Data.SqlClient;

namespace WinFormsApp_crud
{
    public partial class ABM_Personas : Form
    {
        private List<Persona> lista;

        public ABM_Personas()
        {
            InitializeComponent();
        }

        private void ABM_Personas_Load(object sender, EventArgs e)
        {
            this.lista = new List<Persona>();
            this.PrintListBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox_Nombre.Text;
                string apellido = textBox_Apellido.Text;

                if (nombre != String.Empty && apellido != String.Empty)
                {
                    PersonaADO.Guardar(nombre, apellido);
                    this.PrintListBox();
                }
                else
                {
                    MessageBox.Show("Llene los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox_Nombre.Text;
                string apellido = textBox_Apellido.Text;
                int id = -1;

                if(nombre != String.Empty && apellido != String.Empty)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Leer por Id");

                    while (!int.TryParse(input, out id))
                    {
                        input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Media pila che");
                    }

                    if (Persona.SearchById(id, this.lista))
                    {
                        PersonaADO.Modificar(nombre, apellido, id);
                        this.PrintListBox();
                    }
                    else
                    {
                        MessageBox.Show("No existe aun persona con dicho Id");
                    }
                }
                else
                {
                    MessageBox.Show("Complete ambos campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                string input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Leer por Id");

                while (!int.TryParse(input, out id))
                {
                    input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Media pila che");
                }

                if (Persona.SearchById(id, this.lista))
                {
                    PersonaADO.Borrar(id);
                    this.PrintListBox();
                }
                else
                {
                    MessageBox.Show("No existe aun persona con dicho Id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Leer_Click(object sender, EventArgs e)
        {
            try
            {
                this.PrintListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_LeerPorId_Click(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                string input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Leer por Id");

                while (!int.TryParse(input, out id))
                {
                    input = Microsoft.VisualBasic.Interaction.InputBox("Introduzca Id", "Media pila che");
                }

                if(Persona.SearchById(id, this.lista))
                {
                    Persona p = PersonaADO.LeerPorId(id);
                    listBox_Personas.Items.Clear();
                    listBox_Personas.Items.Add(p.ToString());
                }
                else
                {
                    MessageBox.Show("No existe aun persona con dicho Id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Ahorro logica al leer todo con esto
        private void PrintListBox()
        {
            listBox_Personas.Items.Clear();
            this.lista = PersonaADO.Leer();
            foreach (Persona item in this.lista)
            {
                listBox_Personas.Items.Add(item.ToString());
            }
        }
    }
}
