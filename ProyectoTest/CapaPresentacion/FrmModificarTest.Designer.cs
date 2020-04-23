namespace CapaPresentacion
{
    partial class FrmModificarTest
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtModificarTest = new System.Windows.Forms.TextBox();
            this.cboSeleccionarTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Modificar Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Escribe el nuevo nombre del test";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(446, 322);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(115, 45);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar Test";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtModificarTest
            // 
            this.txtModificarTest.Location = new System.Drawing.Point(417, 241);
            this.txtModificarTest.Name = "txtModificarTest";
            this.txtModificarTest.Size = new System.Drawing.Size(194, 22);
            this.txtModificarTest.TabIndex = 8;
            // 
            // cboSeleccionarTest
            // 
            this.cboSeleccionarTest.FormattingEnabled = true;
            this.cboSeleccionarTest.Location = new System.Drawing.Point(417, 179);
            this.cboSeleccionarTest.Name = "cboSeleccionarTest";
            this.cboSeleccionarTest.Size = new System.Drawing.Size(194, 24);
            this.cboSeleccionarTest.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selecciona Test";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 393);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmModificarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtModificarTest);
            this.Controls.Add(this.cboSeleccionarTest);
            this.Controls.Add(this.label1);
            this.Name = "FrmModificarTest";
            this.Text = "Modificar Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtModificarTest;
        private System.Windows.Forms.ComboBox cboSeleccionarTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
    }
}