﻿using System;
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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void añadirCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnadirCategoria frm = new FrmAnadirCategoria();
            frm.Show();
        }

        private void borrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBorrarCategoria frm = new FrmBorrarCategoria();
            frm.Show();
        }

        private void modificarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarCategoria frm = new FrmModificarCategoria();
            frm.Show();
        }
    }
}
