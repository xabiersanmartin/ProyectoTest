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
    public partial class FrmAnadirPregunta : Form
    {
        public bool volver = false;
        public Test test = new Test();
        int numPreg;
        public Categoria categoria = new Categoria();

        public FrmAnadirPregunta()
        {
            InitializeComponent();
        }

        private void FrmAnadirPregunta_Load(object sender, EventArgs e)
        {
            
            lbl.Text = test.Descripcion;

            numPreg = test.preguntasTest.Count() + 1;

            lblNumPreg.Text = numPreg.ToString();

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

        private void btnAnadirPregunta_Click(object sender, EventArgs e)
        {
            bool validez;

            if (!(rdFalsa.Checked || rdVerdadera.Checked))
            {
                MessageBox.Show("Debes marcar si quieres que la pregunta sea verdadera o falsa, no puedes dejarlo sin marcar.", "ATENCIÓN");
                return;
            }

            if (rdFalsa.Checked)
            {
                validez = false;
            }
            else
            {
                validez = true;
            }

            string mensaje = Program.gestor.AnadirPregunta(txtEnunciado.Text, validez, test);

            MessageBox.Show(mensaje);


            if (mensaje == "Esta pregunta ya existe no puedes añardirla")
            {
                txtEnunciado.Text = "";
                rdFalsa.Checked = false;
                rdVerdadera.Checked = false;
            }else if (mensaje == "Pregunta agregada correctamente")
            {
                txtEnunciado.Text = "";
                rdFalsa.Checked = false;
                rdVerdadera.Checked = false;

                numPreg += 1;
                lblNumPreg.Text = numPreg.ToString();
            }

        }

        private void txtEnunciado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipalPreguntas frm = new FrmPrincipalPreguntas();
            frm.ShowDialog(this);
            Close();
        }

        private void btnVolverTest_Click(object sender, EventArgs e)
        {
            FrmHacerTest frm = new FrmHacerTest();
            List<Test> listTestBUscar = Program.gestor.DevolverTestCategorias(categoria);
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
