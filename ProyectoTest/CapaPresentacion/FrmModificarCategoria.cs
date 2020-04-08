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
    public partial class FrmModificarCategoria : Form
    {
        public FrmModificarCategoria()
        {
            InitializeComponent();
        }

        private void FrmModificarCategoria_Load(object sender, EventArgs e)
        {
            List<string> list = Program.gestor.DevolverCategorias();
            cboSeleccionarCat.Items.Clear();
            cboSeleccionarCat.Items.AddRange(list.ToArray());
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
                MessageBox.Show("Debes seleccionar una categoria para poder modificarla");
                return;
            }

            string  categoriaModifi = cboSeleccionarCat.SelectedItem as string;
            //La cargamos para enviarsela al gestor para comprobacion de errores.
            List<string> list = Program.gestor.DevolverCategorias();

            string mensaje = Program.gestor.ModificarCategoria(categoriaModifi, txtModificarCat.Text, list);
            
            //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
            list = Program.gestor.DevolverCategorias();

            MessageBox.Show(mensaje);

            cboSeleccionarCat.Items.Clear();
            cboSeleccionarCat.Items.AddRange(list.ToArray());
            cboSeleccionarCat.Text = "";

            txtModificarCat.Text = "";
        }
    }
}
