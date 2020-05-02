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
    public partial class FrmAnadirTest : Form
    {
        string nombreTest = "";
        bool cerrar = true;
        public FrmAnadirTest()
        {
            InitializeComponent();
        }

        private void FrmAnadirTest_Load(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();
            if (list != null)
            {
                cboCategoria2.Items.Clear();
                cboCategoria2.Items.AddRange(list.ToArray());
                cboCategoria2.DisplayMember = "Descripcion";

            }
            else
            {
                MessageBox.Show("No hay categorias, debes crear una categoria para asociarla al test que quieres crear", "CUIDADO");
                Close();
            }

           List<Test> listTests = Program.gestor.DevolverTests();
            if (listTests != null)
            {

                cboTests.Items.Clear();
                cboTests.Items.AddRange(listTests.ToArray());
                cboTests.DisplayMember = "Descripcion";
            }
        }

        private void btnAnadirTest_Click(object sender, EventArgs e)
        {

            string mensaje = Program.gestor.AnadirTest(txtAnadirTest.Text);

            if (mensaje == "El test que quieres añadir ya existe.")
            {
                MessageBox.Show(mensaje);
                txtAnadirTest.Text = "";
                return;
            }

            MessageBox.Show(mensaje);

            if (mensaje == "El test se ha añadido correctamente")
            {
                MessageBox.Show("Ahora debes relacionar el test " + txtAnadirTest.Text + " con minimo una categoria");
                btnVolver.Enabled = false;
                btnAnadirTest.Enabled = false;
                nombreTest = txtAnadirTest.Text;
                cerrar = false;
            }

            txtAnadirTest.Text = "";
            txtAnadirTest.Enabled = false;

            List<Test> listTests = Program.gestor.DevolverTests();
            cboTests.Items.Clear();
            cboTests.Items.AddRange(listTests.ToArray());
            cboTests.DisplayMember = "Descripcion";

            
        }

        private void txtAnadirTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            else
                if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
                if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnTestCategoria_Click(object sender, EventArgs e)
        {

            //Ponemos el maximo de mensajes para que al usuario le queden claro todos los posibles errores que le puedan salir.
            if (cboCategoria2.SelectedIndex == -1 && cboTests.SelectedIndex == -1)
            {
                MessageBox.Show("Para poder asociar un categoria a un test, debes seleccionar ambos", "ATENCIÓN");
                return;
            }
            if (cboCategoria2.SelectedIndex == -1 && cboTests.SelectedIndex != -1)
            {
                MessageBox.Show("Para poder asociar el test " + cboTests.Text + " antes debes seleccionar a categoria quieres asociarlo", "ATENCIÓN");
                return;
            }

            if (cboCategoria2.SelectedIndex != -1 && cboTests.SelectedIndex == -1)
            {
                MessageBox.Show("Para poder asociar la categoria " + cboCategoria2.Text + " antes debes seleccionar con que test quiere asociarlo", "ATENCIÓN");
                return;
            }

            Categoria anadirCategoria = cboCategoria2.SelectedItem as Categoria;
            Test anadirTest = cboTests.SelectedItem as Test;

            string mensaje = Program.gestor.AnadirCategoriaTest(anadirCategoria, anadirTest);

            MessageBox.Show(mensaje);

            if ((mensaje == "La categoria " + anadirCategoria.Descripcion + " añadido correctamente al test " + anadirTest.Descripcion) && (anadirTest.Descripcion == nombreTest))
            {
                btnVolver.Enabled = true;
                btnAnadirTest.Enabled = true;
                txtAnadirTest.Enabled = true;
                cerrar = true;
            }

            dgvTestCat.Columns.Clear();

            cboCategoria2.SelectedIndex = -1;
            cboTests.SelectedIndex = -1;
        }

        private void cboCategoria2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria categoriaTest = cboCategoria2.SelectedItem as Categoria;

            if (categoriaTest != null)
            {
                List<Test> listTest = Program.gestor.DevolverTestsDeCategoria(categoriaTest);

                dgvTestCat.DataSource = (from t in listTest
                                         select new { Categoria = categoriaTest.Descripcion, Test = t.Descripcion }).ToList();
            }

        }

        private void FrmAnadirTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrar== false)
            {
                e.Cancel = true;
            }
        }
    }
}
