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
            Categoria newCategoria = new Categoria();
            newCategoria = cboCategorias.SelectedItem as Categoria;

            List<Test> listaTest = Program.gestor.DevolverTestCategorias(newCategoria);

            //Comprobamos que esa categoria que introduce tiene tests, de no ser asi se lo decimos al usuario y reninicamos los combobox.
            if (listaTest.Count == 0)
            {
                MessageBox.Show("No tienes ningun test asocidado a esta categoria", "ATENCIÓN");

                List<Categoria> list = Program.gestor.DevolverCategorias();
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";

                List<Test> listTest = Program.gestor.DevolverTests();
                cboEliminarTest.Items.Clear();
                cboEliminarTest.Items.AddRange(listTest.ToArray());
                cboEliminarTest.DisplayMember = "Descripcion";
                return;
            }

            cboEliminarTest.Items.Clear();
            cboEliminarTest.Items.AddRange(listaTest.ToArray());
            cboEliminarTest.DisplayMember = "Descripcion";
        }

        private void FrmBorrarTest_Load(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("No hay categorias, no vas a poder realizar busquedas de test por categorias ya que no tienes.");
                return;
            }

            List<Test> listTest = Program.gestor.DevolverTests();
            if (listTest == null)
            {
                MessageBox.Show("No tienes ningun test para eliminar, para poder eliminarlos debes crearlos antes");
                cboEliminarTest.SelectedIndex = -1;
                cboCategorias.SelectedIndex = -1;
            }

            cboEliminarTest.Items.Clear();
            cboEliminarTest.Items.AddRange(listTest.ToArray());
            cboEliminarTest.DisplayMember = "Descripcion";

            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.DisplayMember = "Descripcion";
        }

        private void btnMostrarTest_Click(object sender, EventArgs e)
        {
            //Ponemos a este botón para facilitar al usuario el reinicio de los combobox, el el caso de que quiera eliminar un test, que no tiene categoria, para que le salgan todos.
            //Tambien porque si a seleccionado ya un combobox, no tendra forma de ver todos esos test en cuyo caso este sin categoria a no ser que salga del formulario y vuelva a entrar.
            
            cboEliminarTest.Text = "";
            cboEliminarTest.SelectedIndex = -1;

            List<Categoria> list = Program.gestor.DevolverCategorias();
            
            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.SelectedIndex = -1;
            cboCategorias.Text = "";

            List<Test> listTest = Program.gestor.DevolverTests();
            if (listTest == null)
            {
                MessageBox.Show("No tienes ningun test para eliminar, para poder eliminarlos debes crearlos antes");
                cboEliminarTest.SelectedIndex = -1;
                cboCategorias.SelectedIndex = -1;
            }

            cboEliminarTest.Items.Clear();
            cboEliminarTest.Items.AddRange(listTest.ToArray());
            cboEliminarTest.DisplayMember = "Descripcion";

        }
    }
}
