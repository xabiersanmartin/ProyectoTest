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
    public partial class FrmBorrarPregunta : Form
    {
        public Test test = new Test();
        public Categoria categoria = new Categoria();
        public bool volver = false;

        public FrmBorrarPregunta()
        {
            InitializeComponent();
        }

        private void FrmBorrarPregunta_Load(object sender, EventArgs e)
        {
            lblTest.Text = test.Descripcion;

            cboPreguntas.Items.Clear();
            cboPreguntas.Items.AddRange(test.preguntasTest.ToArray());
            cboPreguntas.DisplayMember = "Enunciado";

            if (volver == true)
            {
                btnVolverTest.Visible = true;
                btnVolver.Text = "Volver al formulario principal";
                btnVolver.Height = 50;
            }
            else
            {
                btnVolverTest.Visible = false;
            }
        }

        private void btnBorrarPregunta_Click(object sender, EventArgs e)
        {
            if (cboPreguntas.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la pregunta para poder eliminarla", "ATENCIÓN");
                return;
            }
            Pregunta newPregunta = cboPreguntas.SelectedItem as Pregunta;

            DialogResult result = MessageBox.Show("Seguro que quieres eliminar la pregunta " + newPregunta.enunciado, "ATENCIÓN", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.BorrarPregunta(newPregunta.idPregunta);
                MessageBox.Show(mensaje);

                Test testBuscar = new Test();
                testBuscar.idTest = test.idTest;

                Test nuevoTest = Program.gestor.DevolverPreguntasTest(testBuscar);
                if (testBuscar.preguntasTest.Count !=  0)
                {
                    cboPreguntas.Items.Clear();
                    cboPreguntas.Items.AddRange(nuevoTest.preguntasTest.ToArray());
                    cboPreguntas.DisplayMember = "Enunciado";
                    cboPreguntas.Text = "";

                    lblEnunciado.Text = "";
                    lblValido.Text = "";
                }
                else
                {
                    MessageBox.Show("Se han eliminado todas las preguntas del test " + test.Descripcion, "ATENCIÓN");
                    cboPreguntas.SelectedIndex = -1;
                    cboPreguntas.Enabled = false;
                    btnBorrarPregunta.Enabled = false;
                    lblEnunciado.Text = "";
                    lblValido.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se elimino la pregunta "+newPregunta.enunciado);
                cboPreguntas.SelectedIndex = -1;
            }
        }

        private void cboPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPreguntas.SelectedIndex == -1)
            {
                return;
            }

            Pregunta preguntaEliminar = cboPreguntas.SelectedItem as Pregunta;
            lblEnunciado.Text = cboPreguntas.Text;

            if (preguntaEliminar.respV == true)
            {
                lblValido.Text = "Verdad";
            }
            else
            {
                lblValido.Text = "Falso";
            }
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipalPreguntas frm = new FrmPrincipalPreguntas();
            frm.ShowDialog(this);
            Close();
        }

        private void btnVolverTest_Click(object sender, EventArgs e)
        {
            FrmHacerTest frm = new FrmHacerTest();
            List<Test> listTestBUscar = Program.gestor.DevolverTestsDeCategoria(categoria);
            foreach (var testBuscar in listTestBUscar)
            {
                if (testBuscar.Descripcion == test.Descripcion)
                {
                    frm.test = testBuscar;
                    frm.categoria = categoria;
                    frm.ShowDialog(this);
                    Close();
                }
            }

        }
    }
}
