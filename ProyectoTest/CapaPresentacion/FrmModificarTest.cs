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
    public partial class FrmModificarTest : Form
    {
        public FrmModificarTest()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmModificarTest_Load(object sender, EventArgs e)
        {
            List<Test> listTest = Program.gestor.DevolverTests();

            if (listTest == null)
            {
                MessageBox.Show("No puedes mofidificar ningun test, porque no tienes niguno","ATENCIÓN");
                btnModificar.Enabled = false;
                cboSeleccionarTest.Enabled = false;
                txtModificarTest.Enabled = false;
                return;
            }

            cboSeleccionarTest.Items.Clear();
            cboSeleccionarTest.Items.AddRange(listTest.ToArray());
            cboSeleccionarTest.DisplayMember = "Descripcion";
        }

        private void txtModificarTest_KeyPress(object sender, KeyPressEventArgs e)
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
            List<Test> listTest = Program.gestor.DevolverTests();

            string mensaje = Program.gestor.ModificarTest(cboSeleccionarTest.Text, txtModificarTest.Text, listTest);

            listTest = Program.gestor.DevolverTests();

            MessageBox.Show(mensaje);

            cboSeleccionarTest.Items.Clear();
            cboSeleccionarTest.Items.AddRange(listTest.ToArray());
            cboSeleccionarTest.DisplayMember = "Descripcion";
            cboSeleccionarTest.SelectedIndex = -1;
            cboSeleccionarTest.Text = "";

            txtModificarTest.Text = "";
        }
    }
}
