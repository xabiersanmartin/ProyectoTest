using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBorrarTest : Form
    {
        public FrmBorrarTest()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedIndex == -1)
            {
                return;
            }

            cboEliminarTest.SelectedIndex = -1;

            Categoria newCategoria = new Categoria();
            newCategoria = cboCategorias.SelectedItem as Categoria;

            List<Test> listaTest = Program.gestor.DevolverTestsPreguntasDeCategoria(newCategoria);

            //Comprobamos que esa categoria que introduce tiene tests, de no ser asi se lo decimos al usuario y reninicamos los combobox.
            if (listaTest.Count <= 0)
            {
                MessageBox.Show("No tienes ningun test asocidado a esta categoría", "ATENCIÓN");

                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";

                cboEliminarTest.SelectedIndex = -1;
                cboEliminarTest.Text = "";
                return;
            }

            cboEliminarTest.Items.Clear();
            cboEliminarTest.Items.AddRange(listaTest.ToArray());
            cboEliminarTest.DisplayMember = "Descripcion";
        }

        private void FrmBorrarTest_Load(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
            }
            if (list != null)
            {
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
            }
            else
            {
                cboCategorias.Enabled = false;
                cboEliminarTest.Enabled = false;
                btnEliminarTest.Enabled = false;
            }

            List<Test> listTest = Program.gestor.DevolverTests();
            if (listTest == null)
            {
                MessageBox.Show("No tienes ningun test para eliminar, para poder eliminarlos debes crearlos antes");
                cboEliminarTest.SelectedIndex = -1;
                cboCategorias.SelectedIndex = -1;
                cboEliminarTest.Enabled = false;
                cboCategorias.Enabled = false;
                btnEliminarTest.Enabled = false;
                return;
            }

            cboEliminarTest.Items.Clear();
            cboEliminarTest.Items.AddRange(listTest.ToArray());
            cboEliminarTest.DisplayMember = "Descripcion";


        }

        private void btnEliminarTest_Click(object sender, EventArgs e)
        {
            if (cboEliminarTest.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un test para poder borrarlo.", "ATENCIÓN");
                return;
            }
            if (cboCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una categoría para borrar el test", "ATENCIÓN");
                return;
            }

            Test eliminarTest = cboEliminarTest.SelectedItem as Test;

            DialogResult result = MessageBox.Show("Seguro que quieres eliminar el test " + eliminarTest.Descripcion + " ?", "CUIDADO", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                bool comprobar = false;
                if (eliminarTest.PreguntasTest.Count != 0)
                {
                    string preguntas = "";

                    foreach (var preg in eliminarTest.PreguntasTest)
                    {
                        preguntas += String.Concat(preg.enunciado + ", ");
                    }

                    DialogResult result1 = MessageBox.Show("Seguro que quieres eliminar el test " + eliminarTest.Descripcion + " que tiene las preguntas \n \n " + preguntas, "ATENCION", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        comprobar = true;
                    }

                }
                else
                {
                    comprobar = true;
                }

                if (comprobar == true)
                {
                    string respuesta = Program.gestor.EliminarTest(eliminarTest);

                    MessageBox.Show(respuesta);

                    List<Test> listTest = Program.gestor.DevolverTests();
                    if (listTest == null)
                    {
                        MessageBox.Show("No tienes ningun test para eliminar, para poder eliminarlos debes crearlos antes");
                        cboEliminarTest.Items.Clear();
                        cboEliminarTest.Text = "";
                        cboCategorias.Text = "";
                        cboEliminarTest.Enabled = false;
                        cboCategorias.Enabled = false;
                        btnEliminarTest.Enabled = false;
                        return;
                    }

                    cboEliminarTest.Items.Clear();
                    cboEliminarTest.Items.AddRange(listTest.ToArray());
                    cboEliminarTest.Text = "";

                    cboCategorias.SelectedIndex = -1;
                    cboCategorias.Text = "";

                }

                else
                {
                    cboCategorias.SelectedIndex = -1;
                    cboCategorias.Text = "";

                    cboEliminarTest.SelectedIndex = -1;
                    cboEliminarTest.Text = "";
                }
            }
            else
            {
                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";

                cboEliminarTest.SelectedIndex = -1;
                cboEliminarTest.Text = "";
            }
        }
    }
}
