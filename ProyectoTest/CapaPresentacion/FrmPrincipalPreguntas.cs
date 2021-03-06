﻿using Entidades;
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
    public partial class FrmPrincipalPreguntas : Form
    {
        public Test test = new Test();
        public Categoria categoria = new Categoria();
        public FrmPrincipalPreguntas()
        {
            InitializeComponent();
        }

        private void FrmPrincipalPreguntas_Load(object sender, EventArgs e)
        {
            string msg = "";
            cboTestDeCategorias.Enabled = false;
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
            }
            cboCategorias.Items.Clear();
            cboCategorias.Items.AddRange(list.ToArray());
            cboCategorias.DisplayMember = "Descripcion";

            if (categoria != null)
            {
                cboCategorias.SelectedItem = categoria;
                cboTestDeCategorias.SelectedItem = test;
            }

        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTestDeCategorias.SelectedIndex = -1;
            cboTestDeCategorias.Text = "";

            if (cboCategorias.SelectedIndex == -1)
            {
                return;
            }

            Categoria categoria = cboCategorias.SelectedItem as Categoria;

            List<Test> testsDeCategorias = Program.gestor.DevolverTestsPreguntasDeCategoria(categoria);
            if (testsDeCategorias.Count == 0)
            {
                MessageBox.Show("No tienes ningun test asociado a esta categoría", "ATENCIÓN");
                cboTestDeCategorias.Items.Clear();
                cboTestDeCategorias.Enabled = false;
                cboCategorias.SelectedIndex = -1;
                return;
            }
            cboTestDeCategorias.Enabled = true;
            cboTestDeCategorias.Items.Clear();
            cboTestDeCategorias.Items.AddRange(testsDeCategorias.ToArray());
            cboTestDeCategorias.DisplayMember = "Descripcion";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboTestDeCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTest.Text = "";
            lblTest.Text = cboTestDeCategorias.Text;
        }

        private void btnAnadirPreguntas_Click(object sender, EventArgs e)
        {
            if (cboTestDeCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("No puedes añadir una pregunta sin a ver seleccionado antes la categoría y el test al que quieres añadirle esas preguntas", "ATENCIÓN");
                return;
            }

            FrmAnadirPregunta frm = new FrmAnadirPregunta();
            frm.test = cboTestDeCategorias.SelectedItem as Test;
            frm.ShowDialog();
            Close();
        }

        private void btnBorrarPreguntas_Click(object sender, EventArgs e)
        {
            Test comprobarTest = cboTestDeCategorias.SelectedItem as Test;

            if (cboTestDeCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("No puedes borrar una pregunta sin haber seleccionado antes la categoría y el test", "ATENCIÓN");
                return;
            }

            if (comprobarTest.PreguntasTest.Count == 0)
            {
                MessageBox.Show("El test: " + comprobarTest.Descripcion + " no tiene preguntas que eliminar.");
                return;
            }

            FrmBorrarPregunta frm = new FrmBorrarPregunta();
            frm.test = cboTestDeCategorias.SelectedItem as Test;
            frm.ShowDialog();
            Close();
        }

        private void btnBorrarTodas_Click(object sender, EventArgs e)
        {
            Test test = cboTestDeCategorias.SelectedItem as Test;

            if (cboTestDeCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("No puedes eliminar todas las preguntas de un test sin a ver seleccionado antes la categoría y el test.", "ATENCIÓN");
                return;
            }

            if (test.PreguntasTest.Count == 0)
            {
                MessageBox.Show("En este test(" + test.Descripcion + ") no hay preguntas para borrar");
                return;
            }

            DialogResult result = MessageBox.Show("Estas seguro que de quieres eliminar todas las preguntas del test " + test.Descripcion, "ATENCIÓN", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.EliminarTodasPreguntasTest(test.idTest);

                MessageBox.Show(mensaje);

                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";

                cboTestDeCategorias.Items.Clear();
                cboTestDeCategorias.Text = "";

            }
            else
            {
                cboCategorias.SelectedIndex = -1;
                cboTestDeCategorias.SelectedIndex = -1;
            }
        }

        private void btnHacerTest_Click(object sender, EventArgs e)
        {
            Test test = cboTestDeCategorias.SelectedItem as Test;

            if (cboTestDeCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("No puedes hacer un test si antes no has seleccionado de que test quieres hacerlo.", "ATENCIÓN");
                return;
            }

            if (test.PreguntasTest.Count == 0)
            {
                MessageBox.Show("En este test(" + test.Descripcion + ") no hay preguntas.");
                return;
            }

            FrmHacerTest frm = new FrmHacerTest();
            frm.test = test;
            frm.categoria = cboCategorias.SelectedItem as Categoria;
            frm.ShowDialog();
            Close();
        }
    }
}
