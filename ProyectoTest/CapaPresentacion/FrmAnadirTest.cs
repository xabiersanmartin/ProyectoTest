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
                MessageBox.Show("No hay categorias, debes crear una antes para poder asociarla con un test","CUIDADO");
                return;
            }

            List<Test> listTests = Program.gestor.DevolverTests();
            if (!(list == null))
            {
                lsbTestExistentes.Items.AddRange(listTests.ToArray());
                lsbTestExistentes.DisplayMember = "Descripcion";
            }


            cboCategoria2.Items.Clear();
            cboCategoria2.Items.AddRange(list.ToArray());
            cboCategoria2.DisplayMember = "Descripcion";

            cboTests.Items.Clear();
            cboTests.Items.AddRange(listTests.ToArray());
            cboTests.DisplayMember = "Descripcion";

        }

        private void btnAnadirTest_Click(object sender, EventArgs e)
        {

            string mensaje = Program.gestor.AnadirTest(txtAnadirTest.Text);

            MessageBox.Show(mensaje);

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


        private void btnTestCategoria_Click(object sender, EventArgs e)
        {

            //Ponemos el maximo de mensajes para que al usuario le queden claro todos los posibles errores que le puedan salir.
            if (cboCategoria2.SelectedIndex == -1 && cboTests.SelectedIndex == -1)
            {
                MessageBox.Show("Para poder asociar un categoria a un test, debes seleccionar ambos","ATENCIÓN");
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

            cboCategoria2.SelectedIndex = -1;
            cboTests.SelectedIndex = -1;
        }
    }
}
