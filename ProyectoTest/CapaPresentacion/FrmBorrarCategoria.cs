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
    public partial class FrmBorrarCategoria : Form
    {
        public FrmBorrarCategoria()
        {
            InitializeComponent();
        }

        private void FrmBorrarCategoria_Load(object sender, EventArgs e)
        {
            List<Categorias> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("No hay categorias que eliminar, debes añadir una antes.");
                return;
            }
            
            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.DisplayMember = "Descripcion";
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoria para poder eliminar");
                return;
            }

            Categorias borrarCategoria = cboCategorias.SelectedItem as Categorias;

            //List<string> cats = cboCategorias. as string;

            string mensaje = Program.gestor.BorrarCategoria(borrarCategoria);

            if (mensaje == "test")
            {
                DialogResult result = MessageBox.Show("Seguro que quieres eliminar la categoria "+borrarCategoria+ " tiene asociado el test ", "CUIDADO", MessageBoxButtons.YesNo);
                return;
            }

            //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
            List<Categorias> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("Has eliminado todas las categorias");
                cboCategorias.Items.Clear();
                cboCategorias.Text = "";
                return;
            }

            MessageBox.Show(mensaje);

            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.DisplayMember = "Descripcion";
            cboCategorias.Text = "";

        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            List<Categorias> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("No puede eliminar categorias sino tienes ninguna");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar todas las categorias?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.EliminarCategorias();
                MessageBox.Show(mensaje);
                list = Program.gestor.DevolverCategorias();
                cboCategorias.Items.Clear();
                cboCategorias.Text = "";
            }
            else
            {
                MessageBox.Show("No se a eliminado nada.");
                return;
            }
        }
    }
}
