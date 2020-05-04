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
    public partial class FrmHacerTest : Form
    {
        public Test test = new Test();
        public Categoria categoria = new Categoria();

        List<TextBox> listText = new List<TextBox>();
        List<CheckBox> listCheck = new List<CheckBox>();
        List<PictureBox> listPicB = new List<PictureBox>();
        List<Point> points = new List<Point>();


        public FrmHacerTest()
        {
            InitializeComponent();
        }

        private void FrmHacerTest_Load(object sender, EventArgs e)
        {
            lblTest.Text = test.Descripcion;

            int columna = 180;
            int columna2 = 660;
            int fila = 50;

            for (int i = 0; i < test.preguntasTest.Count; i++)
            {
                TextBox newText = new TextBox();
                CheckBox newCheck = new CheckBox();

                newText.Text = test.preguntasTest[i].enunciado;
                newText.Location = new Point(columna, fila);
                newText.Width = 450;
                newText.Height = 120;
                newText.ReadOnly = true;

                newCheck.Text = "Verdadera";
                newCheck.Location = new Point(columna2, fila);

                listCheck.Add(newCheck);
                listText.Add(newText);
                fila += 40;
            }

            foreach (var text in listText)
            {
                groupBox1.Controls.Add(text);
            }

            foreach (var checkB in listCheck)
            {
                groupBox1.Controls.Add(checkB);
            }
        }

        private void btnAceptarTest_Click(object sender, EventArgs e)
        {
            List<bool> comprobarTest = new List<bool>();
            int contador = 0;

            foreach (var checkB in listCheck)
            {
                comprobarTest.Add(checkB.Checked);

                Point point = checkB.Location;
                points.Add(point);

            }

            for (int i = 0; i < test.preguntasTest.Count; i++)
            {
                if (test.preguntasTest[i].respV == comprobarTest[i])
                {
                    contador += 1;
                }
                else
                {
                    bool comprobar = false;
                    comprobarTest.Add(comprobar);

                    Image image = Image.FromFile("../../../Icono/interfaz.png");

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = image;
                    pictureBox.Width = 30;
                    pictureBox.Height = 20;
                    pictureBox.Location = points[i] + new Size(-20, +2);
                    listPicB.Add(pictureBox);
                }

            }


            if (listPicB.Count != 0)
            {
                foreach (var pic in listPicB)
                {
                    groupBox1.Controls.Add(pic);
                }
            }


            if (contador == 0)
            {
                MessageBox.Show("No has acertado ninguna pregunta", "ATENCIÓN");
            }
            else
            {
                MessageBox.Show("Has acertado " + contador.ToString() + " preguntas", "ATENCIÓN");
            }
            btnAceptarTest.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmPrincipalPreguntas frm = new FrmPrincipalPreguntas();
            frm.test = test;
            frm.categoria = categoria;
            frm.ShowDialog(this);
            Close();
        }

        private void btnHacerTest_Click(object sender, EventArgs e)
        {
            listCheck.Clear();
            points.Clear();
            listPicB.Clear();
            listText.Clear();

            groupBox1.Controls.Clear();

            btnAceptarTest.Enabled = true;

            int columna = 180;
            int columna2 = 660;
            int fila = 50;

            for (int i = 0; i < test.preguntasTest.Count; i++)
            {
                TextBox newText = new TextBox();
                CheckBox newCheck = new CheckBox();

                newText.Text = test.preguntasTest[i].enunciado;
                newText.Location = new Point(columna, fila);
                newText.Width = 450;
                newText.Height = 120;
                newText.ReadOnly = true;

                newCheck.Text = "Verdadera";
                newCheck.Location = new Point(columna2, fila);

                listCheck.Add(newCheck);
                listText.Add(newText);
                fila += 40;
            }

            foreach (var text in listText)
            {
                groupBox1.Controls.Add(text);
            }

            foreach (var checkB in listCheck)
            {
                groupBox1.Controls.Add(checkB);
            }
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            FrmAnadirPregunta frm = new FrmAnadirPregunta();
            frm.test = test;
            frm.volver = true;
            frm.categoria = categoria;
            frm.ShowDialog(this);
            Close();
        }

        private void btnBorrarPregunta_Click(object sender, EventArgs e)
        {
            FrmBorrarPregunta frm = new FrmBorrarPregunta();
            frm.test = test;
            frm.categoria = categoria;
            frm.volver = true;
            frm.ShowDialog(this);
            Close();
        }

        private void btnBorrarTodas_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro que de quieres eliminar todas las preguntas del test " + test.Descripcion, "ATENCIÓN", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.EliminarTodasPreguntasTest(test.idTest);

                MessageBox.Show(mensaje);

                FrmPrincipalPreguntas frm = new FrmPrincipalPreguntas();
                frm.ShowDialog(this);
                Close();
            }
        }
    }
}

