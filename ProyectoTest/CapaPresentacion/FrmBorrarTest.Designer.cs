namespace CapaPresentacion
{
    partial class FrmBorrarTest
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
            this.cboEliminarTest = new System.Windows.Forms.ComboBox();
            this.btnAnadirTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eliminar Test";
            // 
            // cboEliminarTest
            // 
            this.cboEliminarTest.FormattingEnabled = true;
            this.cboEliminarTest.Location = new System.Drawing.Point(365, 170);
            this.cboEliminarTest.Name = "cboEliminarTest";
            this.cboEliminarTest.Size = new System.Drawing.Size(190, 24);
            this.cboEliminarTest.TabIndex = 2;
            // 
            // btnAnadirTest
            // 
            this.btnAnadirTest.Location = new System.Drawing.Point(303, 245);
            this.btnAnadirTest.Name = "btnAnadirTest";
            this.btnAnadirTest.Size = new System.Drawing.Size(120, 38);
            this.btnAnadirTest.TabIndex = 3;
            this.btnAnadirTest.Text = "&Eliminar Test";
            this.btnAnadirTest.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selecciona el Test a eliminar";
            // 
            // FrmBorrarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnadirTest);
            this.Controls.Add(this.cboEliminarTest);
            this.Controls.Add(this.label1);
            this.Name = "FrmBorrarTest";
            this.Text = "Eliminar Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEliminarTest;
        private System.Windows.Forms.Button btnAnadirTest;
        private System.Windows.Forms.Label label2;
    }
}