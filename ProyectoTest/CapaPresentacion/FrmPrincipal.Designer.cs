namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preguntasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirPreguntaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarPreguntaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarPreguntaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriasToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.preguntasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirCategoriaToolStripMenuItem,
            this.borrarCategoriaToolStripMenuItem,
            this.modificarCategoriaToolStripMenuItem});
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // añadirCategoriaToolStripMenuItem
            // 
            this.añadirCategoriaToolStripMenuItem.Name = "añadirCategoriaToolStripMenuItem";
            this.añadirCategoriaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.añadirCategoriaToolStripMenuItem.Text = "Añadir Categoria";
            this.añadirCategoriaToolStripMenuItem.Click += new System.EventHandler(this.añadirCategoriaToolStripMenuItem_Click);
            // 
            // borrarCategoriaToolStripMenuItem
            // 
            this.borrarCategoriaToolStripMenuItem.Name = "borrarCategoriaToolStripMenuItem";
            this.borrarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.borrarCategoriaToolStripMenuItem.Text = "Borrar Categoria";
            this.borrarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.borrarCategoriaToolStripMenuItem_Click);
            // 
            // modificarCategoriaToolStripMenuItem
            // 
            this.modificarCategoriaToolStripMenuItem.Name = "modificarCategoriaToolStripMenuItem";
            this.modificarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.modificarCategoriaToolStripMenuItem.Text = "Modificar Categoria";
            this.modificarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.modificarCategoriaToolStripMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirTestsToolStripMenuItem,
            this.borrarTestsToolStripMenuItem,
            this.modificarTestsToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // añadirTestsToolStripMenuItem
            // 
            this.añadirTestsToolStripMenuItem.Name = "añadirTestsToolStripMenuItem";
            this.añadirTestsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.añadirTestsToolStripMenuItem.Text = "Añadir Tests";
            this.añadirTestsToolStripMenuItem.Click += new System.EventHandler(this.añadirTestsToolStripMenuItem_Click);
            // 
            // borrarTestsToolStripMenuItem
            // 
            this.borrarTestsToolStripMenuItem.Name = "borrarTestsToolStripMenuItem";
            this.borrarTestsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.borrarTestsToolStripMenuItem.Text = "Borrar Tests";
            this.borrarTestsToolStripMenuItem.Click += new System.EventHandler(this.borrarTestsToolStripMenuItem_Click);
            // 
            // modificarTestsToolStripMenuItem
            // 
            this.modificarTestsToolStripMenuItem.Name = "modificarTestsToolStripMenuItem";
            this.modificarTestsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.modificarTestsToolStripMenuItem.Text = "Modificar Tests";
            this.modificarTestsToolStripMenuItem.Click += new System.EventHandler(this.modificarTestsToolStripMenuItem_Click);
            // 
            // preguntasToolStripMenuItem
            // 
            this.preguntasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirPreguntaToolStripMenuItem,
            this.borrarPreguntaToolStripMenuItem,
            this.modificarPreguntaToolStripMenuItem});
            this.preguntasToolStripMenuItem.Name = "preguntasToolStripMenuItem";
            this.preguntasToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.preguntasToolStripMenuItem.Text = "Preguntas";
            // 
            // añadirPreguntaToolStripMenuItem
            // 
            this.añadirPreguntaToolStripMenuItem.Name = "añadirPreguntaToolStripMenuItem";
            this.añadirPreguntaToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.añadirPreguntaToolStripMenuItem.Text = "Añadir pregunta";
            // 
            // borrarPreguntaToolStripMenuItem
            // 
            this.borrarPreguntaToolStripMenuItem.Name = "borrarPreguntaToolStripMenuItem";
            this.borrarPreguntaToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.borrarPreguntaToolStripMenuItem.Text = "Borrar pregunta";
            // 
            // modificarPreguntaToolStripMenuItem
            // 
            this.modificarPreguntaToolStripMenuItem.Name = "modificarPreguntaToolStripMenuItem";
            this.modificarPreguntaToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.modificarPreguntaToolStripMenuItem.Text = "Modificar Pregunta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "BIENVENIDO AL PROGRAMA";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Formulario Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preguntasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirPreguntaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarPreguntaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarPreguntaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

