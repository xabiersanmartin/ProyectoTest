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
    public partial class FrmBorrarCategoria : Form
    {
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

            Categoria borrarCategoria = cboCategorias.SelectedItem as Categoria;

            //Vamos a comprobar con el usuario si quiere eliminar la categoria antes de eliminarla.
            DialogResult resultado = MessageBox.Show("Seguro que quieres eliminar la categoría " + borrarCategoria.Descripcion, "ELIMINAR", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                string mensaje = Program.gestor.BorrarCategoria(borrarCategoria.idCategoria);

                if (mensaje == "test")
                {
                    DialogResult result = new DialogResult();
                    List<Test> testAsociados = new List<Test>();
                    List<Pregunta> preguntasAsociadas = new List<Pregunta>();
                    string tests = "";

                    testAsociados = Program.gestor.DevolverTestsDeCategoria(borrarCategoria);
                    preguntasAsociadas = Program.gestor.DevolverTestConPreguntas(testAsociados);

                    for (int i = 0; i < testAsociados.Count; i++)
                    {
                        if ((i + 1) == testAsociados.Count)
                        {
                            tests += String.Concat(testAsociados[i].Descripcion + ".");
                        }
                        else
                        {
                            tests += String.Concat(testAsociados[i].Descripcion + ", ");
                        }
                    }

                    if (preguntasAsociadas.Count == 0)
                    {
                        DialogResult result2 = new DialogResult();
                        result2 = MessageBox.Show("Seguro que quieres eliminar la categoría " + borrarCategoria.Descripcion + " que tiene los tests " + tests, "CUIDADO", MessageBoxButtons.YesNo);

                        if (result2 == DialogResult.Yes)
                        {
                            string respuesta = Program.gestor.BorrarCategoriaTest(borrarCategoria);
                            MessageBox.Show(respuesta);

                            //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
                            string message = "";
                            List<Categoria> lista = Program.gestor.DevolverCategorias(out message);
                            if (message != "")
                            {
                                MessageBox.Show(message, "ATENCIÓN");
                            }
                            if (lista == null)
                            {
                                MessageBox.Show("Has eliminado todas las categorías");
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

                    result = MessageBox.Show("Seguro que quieres eliminar la categoría " + borrarCategoria.Descripcion + "\n" + "\n" + "Con los tests: " + tests + "\n" + "\n" + " Con las preguntas: " + preguntas, "CUIDADO", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string respuesta = Program.gestor.EliminarPreguntasDeTest(preguntasAsociadas);
                        string respuesta2 = Program.gestor.BorrarCategoriaTest(borrarCategoria);

                        if (respuesta == "Preguntas eliminadas" && respuesta2 == "Categoría y tests eliminados correctamente")
                        {
                            MessageBox.Show("La categoría fue eliminada correctamente con todos sus tests y preguntas");

                            string message = "";
                            List<Categoria> lista = Program.gestor.DevolverCategorias(out message);
                            if (message != "")
                            {
                                MessageBox.Show(message, "ATENCIÓN");
                            }

                            if (lista == null)
                            {
                                MessageBox.Show("Has eliminado todas las categorías");
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

                //Cargamos la lista de nuevo para que salga bien al seleccionar el combobox de nuevo
                string msg = "";
                List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
                if (msg != "" && msg != "Fallo en la conexión al devolver categorías, contacte con el administrador")
                {
                    MessageBox.Show("Has eliminado todas las categorías","ATENCIÓN");
                    cboCategorias.Items.Clear();
                    cboCategorias.Text = "";
                    btnBorrarTodo.Enabled = false;
                    btnEliminar.Enabled = false;
                    return;
                }else if(msg == "Fallo en la conexión al devolver categorías, contacte con el administrador")
                {
                    MessageBox.Show(msg,"ATENCIÓN");
                    btnBorrarTodo.Enabled = false;
                    btnEliminar.Enabled = false;
                    cboCategorias.Enabled = false;
                    return;
                }

                MessageBox.Show(mensaje);

                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(list.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.Text = "";
            }
            else
            {
                MessageBox.Show("No se eliminó la categoría " + borrarCategoria.Descripcion);
                cboCategorias.SelectedIndex = -1;
            }

        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<Categoria> list = Program.gestor.DevolverCategorias(out msg);
            if (msg != "")
            {
                MessageBox.Show(msg, "ATENCIÓN");
            }
            if (list == null)
            {
                MessageBox.Show("No puedes eliminar las categorías sino tienes ninguna");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar todas las categorías? \n \n Piensa que también eliminaras todos los test asociados a esas categorías y las preguntas asociadas a los test", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string mensaje = Program.gestor.EliminarCategorias();
                MessageBox.Show(mensaje);
                string message = "";
                list = Program.gestor.DevolverCategorias(out message);
                if (message != "")
                {
                    MessageBox.Show(message, "ATENCIÓN");
                }
                cboCategorias.Items.Clear();
                cboCategorias.Text = "";
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
    }
}
