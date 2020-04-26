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
            this.btnEliminarTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.btnMostrarTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eliminar Test";
            // 
            // cboEliminarTest
            // 
            this.cboEliminarTest.FormattingEnabled = true;
            this.cboEliminarTest.Location = new System.Drawing.Point(479, 212);
            this.cboEliminarTest.Name = "cboEliminarTest";
            this.cboEliminarTest.Size = new System.Drawing.Size(190, 24);
            this.cboEliminarTest.TabIndex = 2;
            // 
            // btnEliminarTest
            // 
            this.btnEliminarTest.Location = new System.Drawing.Point(338, 288);
            this.btnEliminarTest.Name = "btnEliminarTest";
            this.btnEliminarTest.Size = new System.Drawing.Size(120, 38);
            this.btnEliminarTest.TabIndex = 3;
            this.btnEliminarTest.Text = "&Eliminar Test";
            this.btnEliminarTest.UseVisualStyleBackColor = true;
            this.btnEliminarTest.Click += new System.EventHandler(this.btnEliminarTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selecciona el Test que quieres eliminar";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selecciona una categoria para cargar sus test";
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(479, 152);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(190, 24);
            this.cboCategorias.TabIndex = 11;
            this.cboCategorias.SelectedIndexChanged += new System.EventHandler(this.cboCategorias_SelectedIndexChanged);
            // 
            // btnMostrarTest
            // 
            this.btnMostrarTest.Location = new System.Drawing.Point(725, 200);
            this.btnMostrarTest.Name = "btnMostrarTest";
            this.btnMostrarTest.Size = new System.Drawing.Size(166, 46);
            this.btnMostrarTest.TabIndex = 12;
            this.btnMostrarTest.Text = "Mostrar todos los test";
            this.btnMostrarTest.UseVisualStyleBackColor = true;
            this.btnMostrarTest.Click += new System.EventHandler(this.btnMostrarTest_Click);
            // 
            // FrmBorrarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 450);
            this.Controls.Add(this.btnMostrarTest);
            this.Controls.Add(this.cboCategorias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarTest);
            this.Controls.Add(this.cboEliminarTest);
            this.Controls.Add(this.label1);
            this.Name = "FrmBorrarTest";
            this.Text = "Eliminar Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBorrarTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEliminarTest;
        private System.Windows.Forms.Button btnEliminarTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Button btnMostrarTest;
    }
}