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
        public FrmBorrarCategoria()
        {
            InitializeComponent();
        }

        private void FrmBorrarCategoria_Load(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();
            if (list != null)
            {
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
            }
            else
            {
                MessageBox.Show("No hay categorias que eliminar, debes añadir una antes.");
                cboCategorias.Enabled = false;
                btnBorrarTodo.Enabled = false;
                btnEliminar.Enabled = false;
            }
            
            
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoria para poder eliminar");
                return;
            }

            //Categoria borrarCategoria = cboCategorias.SelectedItem as Categoria;

            //Vamos a comprobar con el usuario si quiere eliminar la categoria antes de eliminarla.
            DialogResult resultado = MessageBox.Show("Seguro que quieres eliminar la categoria " + borrarCategoria.Descripcion, "ELIMINAR", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                string mensaje = Program.gestor.BorrarCategoria(borrarCategoria);

                if (mensaje == "preguntas")
                {
                    DialogResult result = new DialogResult();
                    List<Test> testAsociados = new List<Test>();
                    List<Pregunta> preguntasAsociadas = new List<Pregunta>();

                    testAsociados = Program.gestor.DevolverTestCategorias(borrarCategoria);
                    string tests = "";

                    for (int i = 0; i < testAsociados.Count; i++)
                    {
                        if ((i+1) == testAsociados.Count)
                        {
                            tests += String.Concat(testAsociados[i].Descripcion + ".");
                        }
                        else
                        {
                            tests += String.Concat(testAsociados[i].Descripcion + ", ");
                        }
                        
                    }

                    preguntasAsociadas = Program.gestor.DevolverTestConPreguntas(testAsociados);
                    string tests2 = "";

                    for (int i = 0; i < preguntasAsociadas.Count; i++)
                    {
                        if ((i + 1) == preguntasAsociadas.Count)
                        {
                            tests2 += String.Concat(preguntasAsociadas[i].enunciado + ".");
                        }
                        else
                        {
                            tests2 += String.Concat(preguntasAsociadas[i].enunciado + ", ");
                        }
                        
                    }

                    result = MessageBox.Show("Seguro que quieres eliminar la categoria " + borrarCategoria.Descripcion + "\n" + "\n" + "Con los tests: "  + tests + "\n" + "\n" + " Con las preguntas: "  + tests2, "CUIDADO", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string respuesta = Program.gestor.EliminarPreguntasDeTest(preguntasAsociadas);
                        string respuesta2 = Program.gestor.BorrarCategoriaTest(borrarCategoria);

                        if (respuesta == "Preguntas eliminadas" && respuesta2 == "Categoria y tests eliminados correctamente")
                        {
                            MessageBox.Show("La categoria fue eliminada correctamente con todos sus tests y preguntas");

                            List<Categoria> lista = Program.gestor.DevolverCategorias();

                            if (lista == null)
                            {
                                MessageBox.Show("Has eliminado todas las categorias");
                                cboCategorias.Items.Clear();
                                cboCategorias.Text = "";
                                return;
                            }

                            cboCategorias.Items.Clear();
                            cboCategorias.Items.AddRange(lista.ToArray());
                            cboCategorias.DisplayMember = "Descripcion";
                            cboCategorias.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ha sucedido un problema contacte con administrador.");
                        }
                    }

                    cboCategorias.SelectedIndex = -1;
                    return;
                }

                //Comprobacion de que la la Categoria no tenga test asociados
                if (mensaje == "test")
                {
                    DialogResult result = new DialogResult();
                    List<Test> testAsociados = new List<Test>();

                    testAsociados = Program.gestor.DevolverTestCategorias(borrarCategoria);
                    string tests = "";
                    for (int i = 0; i < testAsociados.Count; i++)
                    {

                        tests += String.Concat(testAsociados[i].Descripcion + " ,");

                    }

                    result = MessageBox.Show("Seguro que quieres eliminar la categoria " + borrarCategoria.Descripcion + " tiene asociados los tests " + tests, "CUIDADO", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string respuesta = Program.gestor.BorrarCategoriaTest(borrarCategoria);
                        MessageBox.Show(respuesta);

                        //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
                        List<Categoria> lista = Program.gestor.DevolverCategorias();
                        if (lista == null)
                        {
                            MessageBox.Show("Has eliminado todas las categorias");
                            cboCategorias.Items.Clear();
                            cboCategorias.Text = "";
                            return;
                        }

                        cboCategorias.Items.Clear();
                        cboCategorias.Items.AddRange(lista.ToArray());
                        cboCategorias.DisplayMember = "Descripcion";
                        cboCategorias.Text = "";
                    }

                    cboCategorias.SelectedIndex = -1;
                    return;
                }

                //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
                List<Categoria> list = Program.gestor.DevolverCategorias();
                if (list == null)
                {
                    MessageBox.Show("Has eliminado todas las categorias");
                    cboCategorias.Items.Clear();
                    cboCategorias.Text = "";
                    return;
                }

                MessageBox.Show(mensaje + " " + borrarCategoria.Descripcion);

                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.Text = "";
            }
            else
            {
                MessageBox.Show("No se elimino la categoria " + borrarCategoria.Descripcion);
                cboCategorias.SelectedIndex = -1;
            }

            

        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            List<Categoria> list = Program.gestor.DevolverCategorias();
            if (list == null)
            {
                MessageBox.Show("No puede eliminar categorias sino tienes ninguna");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar todas las categorias? \n \n Piensa que tambien eliminaras todos los test asociados a esas categorias y las preguntas asociadas a los test", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.EliminarCategorias();
                MessageBox.Show(mensaje);
                list = Program.gestor.DevolverCategorias();
                cboCategorias.Items.Clear();
                cboCategorias.Text = "";
            }
            else
            {
                MessageBox.Show("No se a eliminado nada.");
                return;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
