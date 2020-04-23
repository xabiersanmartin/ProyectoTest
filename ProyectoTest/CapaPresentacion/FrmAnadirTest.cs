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
        public FrmAnadirTest()
        {
            InitializeComponent();
        }

        private void FrmAnadirTest_Load(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("No hay categorias que eliminar, debes añadir una antes.");
                return;
            }

            List<Test> listTests = Program.gestor.DevolverTests();
            if (!(list == null))
            {
                lsbTestExistentes.Items.AddRange(listTests.ToArray());
                lsbTestExistentes.DisplayMember = "Descripcion";
            }

            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.DisplayMember = "Descripcion";

            cboCategoria2.Items.Clear();
            cboCategoria2.Items.AddRange(list.ToArray());
            cboCategoria2.DisplayMember = "Descripcion";

            cboTests.Items.Clear();
            cboTests.Items.AddRange(listTests.ToArray());
            cboTests.DisplayMember = "Descripcion";

        }

        private void btnAnadirTest_Click(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar con que categoria quieres que corresponda el test, mas tarde podras añadirle mas Categorias, no puede quedarse vacio");
                return;
            }

            Categoria categoriaconTest = cboCategorias.SelectedItem as Categoria;

            string mensaje = Program.gestor.AnadirTest(categoriaconTest, txtAnadirTest.Text);

            MessageBox.Show(mensaje);

            cboCategorias.SelectedIndex = -1;
            txtAnadirTest.Text = "";

            List<Test> listTests = Program.gestor.DevolverTests();
            cboTests.Items.Clear();
            cboTests.Items.AddRange(listTests.ToArray());
            cboTests.DisplayMember = "Descripcion";

            if (!(listTests == null))
            {
                lsbTestExistentes.Items.Clear();
                lsbTestExistentes.Items.AddRange(listTests.ToArray());
                lsbTestExistentes.DisplayMember = "Descripcion";
            }

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
    }
}
