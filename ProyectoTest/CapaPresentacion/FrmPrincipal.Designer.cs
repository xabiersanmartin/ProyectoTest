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
            this.btnAnadirC = new System.Windows.Forms.Button();
            this.btnBorrarC = new System.Windows.Forms.Button();
            this.btnModificarC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAnadirC
            // 
            this.btnAnadirC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnadirC.Location = new System.Drawing.Point(65, 191);
            this.btnAnadirC.Name = "btnAnadirC";
            this.btnAnadirC.Size = new System.Drawing.Size(123, 57);
            this.btnAnadirC.TabIndex = 1;
            this.btnAnadirC.Text = "Añadir Categoria";
            this.btnAnadirC.UseVisualStyleBackColor = true;
            this.btnAnadirC.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBorrarC
            // 
            this.btnBorrarC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarC.Location = new System.Drawing.Point(344, 191);
            this.btnBorrarC.Name = "btnBorrarC";
            this.btnBorrarC.Size = new System.Drawing.Size(117, 57);
            this.btnBorrarC.TabIndex = 2;
            this.btnBorrarC.Text = "Borrar Categoria";
            this.btnBorrarC.UseVisualStyleBackColor = true;
            this.btnBorrarC.Click += new System.EventHandler(this.btnBorrarC_Click);
            // 
            // btnModificarC
            // 
            this.btnModificarC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarC.Location = new System.Drawing.Point(620, 191);
            this.btnModificarC.Name = "btnModificarC";
            this.btnModificarC.Size = new System.Drawing.Size(114, 57);
            this.btnModificarC.TabIndex = 3;
            this.btnModificarC.Text = "Modificar Categoria";
            this.btnModificarC.UseVisualStyleBackColor = true;
            this.btnModificarC.Click += new System.EventHandler(this.btnModificarC_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModificarC);
            this.Controls.Add(this.btnBorrarC);
            this.Controls.Add(this.btnAnadirC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPrincipal";
            this.Text = "Formulario Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAnadirC;
        private System.Windows.Forms.Button btnBorrarC;
        private System.Windows.Forms.Button btnModificarC;
    }
}

