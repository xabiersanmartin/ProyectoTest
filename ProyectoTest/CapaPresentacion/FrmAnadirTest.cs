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

        List<Categoria> anadirCategoria = new List<Categoria>();
        public FrmAnadirTest()
        {
            InitializeComponent();
        }

        private void FrmAnadirTest_Load(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
                btnAnadirTest.Enabled = false;
                btnTestCategoria.Enabled = false;
                return;
            }
            if (list != null)
            {
                cboCategoria2.Items.Clear();
                cboCategoria2.Items.AddRange(list.ToArray());
                cboCategoria2.DisplayMember = "Descripcion";

                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";

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
            if (anadirCategoria.Count == 0)
            {
                MessageBox.Show("Tienes que asociar minimo con una categoria el test", "ATENCIÓN");
                return;
            }

            string mensaje = Program.gestor.AnadirTest(txtAnadirTest.Text,anadirCategoria);

            if (mensaje == "El test que quieres añadir ya existe.")
            {
                MessageBox.Show(mensaje);
                txtAnadirTest.Text = "";
                anadirCategoria.Clear();
                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";
                return;
            }

            MessageBox.Show(mensaje);

            txtAnadirTest.Text = "";

            cboCategorias.SelectedIndex = -1;
            cboCategorias.Text = "";

            List<Test> listTests = Program.gestor.DevolverTests();
            cboTests.Items.Clear();
            cboTests.Items.AddRange(listTests.ToArray());
            cboTests.DisplayMember = "Descripcion";

            anadirCategoria.Clear();
            lsbCategorias.Items.Clear();
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
                MessageBox.Show("Para poder asociar un categoría a un test, debes seleccionar ambos", "ATENCIÓN");
                return;
            }
            if (cboCategoria2.SelectedIndex == -1 && cboTests.SelectedIndex != -1)
            {
                MessageBox.Show("Para poder asociar el test " + cboTests.Text + " antes debes seleccionar a categoría quieres asociarlo", "ATENCIÓN");
                return;
            }

            if (cboCategoria2.SelectedIndex != -1 && cboTests.SelectedIndex == -1)
            {
                MessageBox.Show("Para poder asociar la categoría " + cboCategoria2.Text + " antes debes seleccionar con que test quiere asociarlo", "ATENCIÓN");
                return;
            }

            Categoria anadirCategoria = cboCategoria2.SelectedItem as Categoria;
            Test anadirTest = cboTests.SelectedItem as Test;

            string mensaje = Program.gestor.AnadirCategoriaTest(anadirCategoria, anadirTest);

            MessageBox.Show(mensaje);


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

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedIndex == -1)
            {
                return;           
            }

            Categoria categoriaAnadir = cboCategorias.SelectedItem as Categoria;
            if (anadirCategoria.Contains(categoriaAnadir))
            {
                return;
            }
            anadirCategoria.Add(categoriaAnadir);
            lsbCategorias.Items.Clear();
            lsbCategorias.Items.AddRange(anadirCategoria.ToArray());
            lsbCategorias.DisplayMember = "Descripcion";
        }

        private void lsbCategorias_DoubleClick(object sender, EventArgs e)
        {
            Categoria cat = lsbCategorias.SelectedItem as Categoria;
            anadirCategoria.Remove(cat);

            if (anadirCategoria.Count != 0) //Si el valor devuelto al eliminar no es 0 en la lista cargamos la lista otra vez con el elemento eliminado y reinicamos el combobox, para evitar la confusión del usuario.
            {
                lsbCategorias.Items.Clear();
                lsbCategorias.Items.AddRange(anadirCategoria.ToArray());
                lsbCategorias.DisplayMember = "Descripcion";
                cboCategorias.SelectedIndex = -1;
            }
            else //Comprobamos que la lista no este vacia para evitar problemas de ejecucion al meterle al listBox una lista que esta vacia al borrarle el ultimo objeto.
            {
                lsbCategorias.Items.Clear();
                cboCategorias.SelectedIndex = -1;
            }

        }
    }
}
