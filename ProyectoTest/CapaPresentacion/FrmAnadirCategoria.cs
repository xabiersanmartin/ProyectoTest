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
    public partial class FrmAnadirCategoria : Form
    {
        public FrmAnadirCategoria()
        {
            InitializeComponent();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            string respuesta = Program.gestor.AnadirCategoria(txtCategoria.Text);

            if (respuesta == "Como puedes ver en el recuadro de al lado, la categoria ya existe")
            {
                MessageBox.Show(respuesta, "ERROR");
                txtCategoria.Text = "";
                return;
            }

            MessageBox.Show(respuesta);

            txtCategoria.Text = "";
            //Cargamos a tiempo real la lista para que se cargue el listbox al añadir una nueva categoria.
            List<Categoria> list = Program.gestor.DevolverCategorias();

            //Controlamos este error aqui porque si clicka el boton de añadir sin introducir nada, al estar la lista vacia porque no se a creado nada
            //se rompe el programa.
            if (!(list == null))
            {
                lsbCategorias.Items.Clear();
                lsbCategorias.Items.AddRange(list.ToArray());
                lsbCategorias.DisplayMember = "Descripcion";
            }

        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmAnadirCategoria_Load(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();

            if (!(list == null))
            {
                lsbCategorias.Items.AddRange(list.ToArray());
                lsbCategorias.DisplayMember = "Descripcion";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
