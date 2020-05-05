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
    public partial class FrmBorrarCategoria : Form
    {
        Categoria categoriaTests = new Categoria();
        public FrmBorrarCategoria()
        {
            InitializeComponent();
        }

        private void FrmBorrarCategoria_Load(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
            }
            if (list != null)
            {
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
            }
            else
            {
                cboCategorias.Enabled = false;
                btnBorrarTodo.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoría para poder eliminar");
                return;
            }

            //Vamos a comprobar con el usuario si quiere eliminar la categoria antes de eliminarla.
            DialogResult resultado = MessageBox.Show("Seguro que quieres eliminar la categoría " + categoriaTests.Descripcion, "ELIMINAR", MessageBoxButtons.YesNo);
            List<Pregunta> preguntasAsociadas = new List<Pregunta>();

            if (resultado == DialogResult.Yes)
            {
                if (categoriaTests.TestCategorias.Count != 0)
                {
                    string tests = "";

                    for (int i = 0; i < categoriaTests.TestCategorias.Count; i++)
                    {
                        if ((i + 1) == categoriaTests.TestCategorias.Count)
                        {
                            tests += String.Concat(categoriaTests.TestCategorias[i].Descripcion + ".");
                        }
                        else
                        {
                            tests += String.Concat(categoriaTests.TestCategorias[i].Descripcion + ", ");
                        }
                    }

                    preguntasAsociadas = Program.gestor.DevolverTestConPreguntas(categoriaTests.TestCategorias);
                    if (preguntasAsociadas.Count != 0)
                    {
                        string preguntas = "";

                        for (int i = 0; i < preguntasAsociadas.Count; i++)
                        {
                            if ((i + 1) == preguntasAsociadas.Count)
                            {
                                preguntas += String.Concat(preguntasAsociadas[i].enunciado + ".");
                            }
                            else
                            {
                                preguntas += String.Concat(preguntasAsociadas[i].enunciado + ", ");
                            }
                        }
                        DialogResult result = new DialogResult();
                        result = MessageBox.Show("Seguro que quieres eliminar la categoría " + categoriaTests.Descripcion + "\n" + "\n" + "Con los tests: " + tests + "\n" + "\n" + " Con las preguntas: " + preguntas, "CUIDADO", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string message = Program.gestor.BorrarCategoria(categoriaTests, preguntasAsociadas);
                            MessageBox.Show(message);

                            string message2 = "";
                            List<Categoria> listCategoriasNuevas = Program.gestor.DevolverCategorias(out message2);
                            if (message2 != "")
                            {
                                MessageBox.Show("Has eliminado todas las categorías", "ATENCIÓN");
                            }
                            if (listCategoriasNuevas == null)
                            {
                                cboCategorias.Items.Clear();
                                cboCategorias.Text = "";
                                cboCategorias.Enabled = false;
                                btnBorrarTodo.Enabled = false;
                                btnEliminar.Enabled = false;
                                return;
                            }

                            cboCategorias.Items.Clear();
                            cboCategorias.Items.AddRange(listCategoriasNuevas.ToArray());
                            cboCategorias.DisplayMember = "Descripcion";
                            cboCategorias.Text = "";
                        }
                        else
                        {
                            cboCategorias.SelectedIndex = -1;
                            return;
                        }
                    }
                    else
                    {
                        DialogResult result = new DialogResult();
                        result = MessageBox.Show("Seguro que quieres eliminar la categoría " + categoriaTests.Descripcion + " que tiene los tests " + tests, "CUIDADO", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string message = Program.gestor.BorrarCategoria(categoriaTests, preguntasAsociadas);
                            MessageBox.Show(message);

                            string message2 = "";
                            List<Categoria> listCategoriasNuevas = Program.gestor.DevolverCategorias(out message2);
                            if (message2 != "")
                            {
                                MessageBox.Show("Has eliminado todas las categorías", "ATENCIÓN");
                            }
                            if (listCategoriasNuevas == null)
                            {
                                cboCategorias.Items.Clear();
                                cboCategorias.Text = "";
                                cboCategorias.Enabled = false;
                                btnBorrarTodo.Enabled = false;
                                btnEliminar.Enabled = false;
                                return;
                            }

                            cboCategorias.Items.Clear();
                            cboCategorias.Items.AddRange(listCategoriasNuevas.ToArray());
                            cboCategorias.DisplayMember = "Descripcion";
                            cboCategorias.Text = "";
                        }
                        else
                        {
                            cboCategorias.SelectedIndex = -1;
                            return;
                        }
                    }
                }
                else
                {
                    string mensaje = Program.gestor.BorrarCategoria(categoriaTests, preguntasAsociadas);
                    MessageBox.Show(mensaje);

                    string message3 = "";
                    List<Categoria> lista = Program.gestor.DevolverCategorias(out message3);
                    if (message3 != "")
                    {
                        MessageBox.Show("Has eliminado todas las categorías", "ATENCIÓN");
                    }
                    if (lista == null)
                    {
                        cboCategorias.Items.Clear();
                        cboCategorias.Text = "";
                        cboCategorias.Enabled = false;
                        btnBorrarTodo.Enabled = false;
                        btnEliminar.Enabled = false;
                        return;
                    }

                    cboCategorias.Items.Clear();
                    cboCategorias.Items.AddRange(lista.ToArray());
                    cboCategorias.DisplayMember = "Descripcion";
                    cboCategorias.Text = "";
                }
            }
            else
            {
                cboCategorias.SelectedIndex = -1;
                cboCategorias.Text = "";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
                return;
            }


            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar todas las categorías? \n \n Piensa que también eliminaras todos los test asociados a esas categorías y las preguntas asociadas a los test", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string message2 = "";
                string mensaje = Program.gestor.EliminarCategorias(out message2);
                if (message2 != "")
                {
                    MessageBox.Show(message2);
                }
                MessageBox.Show(mensaje);
                string message = "";
                list = Program.gestor.DevolverCategorias(out message);
                if (message != "")
                {
                    MessageBox.Show(message, "ATENCIÓN");
                }
                cboCategorias.Items.Clear();
                cboCategorias.Text = "";
                cboCategorias.Enabled = false;
                btnBorrarTodo.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se ha eliminado nada.");
                return;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriaTests.TestCategorias.Count != 0)
            {
                categoriaTests.TestCategorias.Clear();
            }
            
            if (cboCategorias.SelectedIndex == -1)
            {
                return;
            }
            Categoria categoria = cboCategorias.SelectedItem as Categoria;
            string msg = "";
            if (msg == "No se ha podido establecer conexión, conacte con el administrador")
            {
                MessageBox.Show(msg);
                return;
            }
            categoriaTests = Program.gestor.DevolverTestAsociadosCategoria(categoria, out msg);
        }
    }
}
