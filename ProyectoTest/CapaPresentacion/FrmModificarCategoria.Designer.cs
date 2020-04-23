namespace CapaPresentacion
{
    partial class FrmModificarCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboSeleccionarCat = new System.Windows.Forms.ComboBox();
            this.txtModificarCat = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona Categoria";
            // 
            // cboSeleccionarCat
            // 
            this.cboSeleccionarCat.FormattingEnabled = true;
            this.cboSeleccionarCat.Location = new System.Drawing.Point(417, 151);
            this.cboSeleccionarCat.Name = "cboSeleccionarCat";
            this.cboSeleccionarCat.Size = new System.Drawing.Size(194, 24);
            this.cboSeleccionarCat.TabIndex = 1;
            // 
            // txtModificarCat
            // 
            this.txtModificarCat.Location = new System.Drawing.Point(417, 213);
            this.txtModificarCat.Name = "txtModificarCat";
            this.txtModificarCat.Size = new System.Drawing.Size(194, 22);
            this.txtModificarCat.TabIndex = 2;
            this.txtModificarCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModificarCat_KeyPress);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(446, 294);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(115, 45);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar Categoria";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Escribe el nuevo nombre de la categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Modificar Categoria";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 393);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmModificarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtModificarCat);
            this.Controls.Add(this.cboSeleccionarCat);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmModificarCategoria";
            this.Text = "Modificar Categoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModificarCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSeleccionarCat;
        private System.Windows.Forms.TextBox txtModificarCat;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
    }
}