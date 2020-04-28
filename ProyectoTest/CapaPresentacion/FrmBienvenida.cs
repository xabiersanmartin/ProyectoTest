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
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();
        }

        private void añadirCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnadirCategoria frm = new FrmAnadirCategoria();
            frm.ShowDialog(this);
            
        }

        private void borrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBorrarCategoria frm = new FrmBorrarCategoria();
            frm.ShowDialog(this);
        }

        private void modificarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarCategoria frm = new FrmModificarCategoria();
            frm.ShowDialog(this);
        }

        private void añadirTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnadirTest frm = new FrmAnadirTest();
            frm.ShowDialog(this);
        }

        private void borrarTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBorrarTest frm = new FrmBorrarTest();
            frm.ShowDialog(this);
        }

        private void modificarTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarTest frm = new FrmModificarTest();
            frm.ShowDialog(this);
        }

        private void btnFomularioPreguntas_Click(object sender, EventArgs e)
        {
            List<Categoria> comprobarCategoria = Program.gestor.DevolverCategorias();
            if (comprobarCategoria == null)
            {
                MessageBox.Show("Para poder acceder aqui antes debes tener alguna categoria creada");
                return;
            }
            
            FrmPrincipalPreguntas frm = new FrmPrincipalPreguntas();
            frm.ShowDialog(this);
        }
    }
}
