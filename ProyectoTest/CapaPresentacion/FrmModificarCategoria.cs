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
    public partial class FrmModificarCategoria : Form
    {
        public FrmModificarCategoria()
        {
            InitializeComponent();
        }

        private void FrmModificarCategoria_Load(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show("No hay categorías, no vas a poder modificar", "ATENCIÓN");
            }
            if (list == null)
            {
                cboSeleccionarCat.Enabled = false;
                txtModificarCat.Enabled = false;
                btnModificar.Enabled = false;
                return;
            }
            cboSeleccionarCat.Items.Clear();
            cboSeleccionarCat.Items.AddRange(list.ToArray());
            cboSeleccionarCat.DisplayMember = "Descripcion";
        }

        private void txtModificarCat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (cboSeleccionarCat.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoría para poder modificarla");
                return;
            }

            Categoria  categoriaModifi = cboSeleccionarCat.SelectedItem as Categoria;
            //La cargamos para enviarsela al gestor para comprobacion de errores.
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);

            string mensaje = Program.gestor.ModificarCategoria(categoriaModifi, txtModificarCat.Text, list);

            //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
            string msg2 = "";
            list = Program.gestor.DevolverCategorias(out msg2);

            MessageBox.Show(mensaje);

            cboSeleccionarCat.Items.Clear();
            cboSeleccionarCat.Items.AddRange(list.ToArray());
            cboSeleccionarCat.DisplayMember = "Descripcion";
            cboSeleccionarCat.Text = "";

            txtModificarCat.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
