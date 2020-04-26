namespace CapaPresentacion
{
    partial class FrmAnadirTest
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
            this.txtAnadirTest = new System.Windows.Forms.TextBox();
            this.btnAnadirTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCategoria2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTests = new System.Windows.Forms.ComboBox();
            this.btnTestCategoria = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvTestCat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Añadir Test";
            // 
            // txtAnadirTest
            // 
            this.txtAnadirTest.Location = new System.Drawing.Point(192, 160);
            this.txtAnadirTest.Name = "txtAnadirTest";
            this.txtAnadirTest.Size = new System.Drawing.Size(273, 22);
            this.txtAnadirTest.TabIndex = 1;
            this.txtAnadirTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnadirTest_KeyPress);
            // 
            // btnAnadirTest
            // 
            this.btnAnadirTest.Location = new System.Drawing.Point(215, 219);
            this.btnAnadirTest.Name = "btnAnadirTest";
            this.btnAnadirTest.Size = new System.Drawing.Size(120, 38);
            this.btnAnadirTest.TabIndex = 2;
            this.btnAnadirTest.Text = "&Crear Test";
            this.btnAnadirTest.UseVisualStyleBackColor = true;
            this.btnAnadirTest.Click += new System.EventHandler(this.btnAnadirTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(637, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(594, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Los Test que tiene la categoria seleccionada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripcion del test";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "Añadir Test a Categoria";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Selecciona Categoria a la que pertenece";
            // 
            // cboCategoria2
            // 
            this.cboCategoria2.FormattingEnabled = true;
            this.cboCategoria2.Location = new System.Drawing.Point(277, 377);
            this.cboCategoria2.Name = "cboCategoria2";
            this.cboCategoria2.Size = new System.Drawing.Size(190, 24);
            this.cboCategoria2.TabIndex = 9;
            this.cboCategoria2.SelectedIndexChanged += new System.EventHandler(this.cboCategoria2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Selecciona el test que quieres añadir";
            // 
            // cboTests
            // 
            this.cboTests.FormattingEnabled = true;
            this.cboTests.Location = new System.Drawing.Point(277, 443);
            this.cboTests.Name = "cboTests";
            this.cboTests.Size = new System.Drawing.Size(190, 24);
            this.cboTests.TabIndex = 12;
            // 
            // btnTestCategoria
            // 
            this.btnTestCategoria.Location = new System.Drawing.Point(192, 502);
            this.btnTestCategoria.Name = "btnTestCategoria";
            this.btnTestCategoria.Size = new System.Drawing.Size(183, 47);
            this.btnTestCategoria.TabIndex = 13;
            this.btnTestCategoria.Text = "&Añadir Test a Categoria";
            this.btnTestCategoria.UseVisualStyleBackColor = true;
            this.btnTestCategoria.Click += new System.EventHandler(this.btnTestCategoria_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(6, 723);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvTestCat
            // 
            this.dgvTestCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestCat.Location = new System.Drawing.Point(653, 202);
            this.dgvTestCat.Name = "dgvTestCat";
            this.dgvTestCat.RowHeadersWidth = 51;
            this.dgvTestCat.RowTemplate.Height = 24;
            this.dgvTestCat.Size = new System.Drawing.Size(564, 297);
            this.dgvTestCat.TabIndex = 15;
            // 
            // FrmAnadirTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 780);
            this.Controls.Add(this.dgvTestCat);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnTestCategoria);
            this.Controls.Add(this.cboTests);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCategoria2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnadirTest);
            this.Controls.Add(this.txtAnadirTest);
            this.Controls.Add(this.label1);
            this.Name = "FrmAnadirTest";
            this.Text = "Añadir Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAnadirTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnadirTest;
        private System.Windows.Forms.Button btnAnadirTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCategoria2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTests;
        private System.Windows.Forms.Button btnTestCategoria;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvTestCat;
    }
}