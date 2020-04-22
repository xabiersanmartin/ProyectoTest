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
            this.lsbTestExistentes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.txtAnadirTest.Location = new System.Drawing.Point(177, 227);
            this.txtAnadirTest.Name = "txtAnadirTest";
            this.txtAnadirTest.Size = new System.Drawing.Size(233, 22);
            this.txtAnadirTest.TabIndex = 1;
            // 
            // btnAnadirTest
            // 
            this.btnAnadirTest.Location = new System.Drawing.Point(215, 295);
            this.btnAnadirTest.Name = "btnAnadirTest";
            this.btnAnadirTest.Size = new System.Drawing.Size(120, 38);
            this.btnAnadirTest.TabIndex = 2;
            this.btnAnadirTest.Text = "&Añadir Test";
            this.btnAnadirTest.UseVisualStyleBackColor = true;
            // 
            // lsbTestExistentes
            // 
            this.lsbTestExistentes.FormattingEnabled = true;
            this.lsbTestExistentes.ItemHeight = 16;
            this.lsbTestExistentes.Location = new System.Drawing.Point(512, 134);
            this.lsbTestExistentes.Name = "lsbTestExistentes";
            this.lsbTestExistentes.Size = new System.Drawing.Size(260, 212);
            this.lsbTestExistentes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Test Existentes";
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(274, 154);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(158, 24);
            this.cboCategorias.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selecciona Categoria a la que pertenece";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripcion del test";
            // 
            // FrmAnadirTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCategorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsbTestExistentes);
            this.Controls.Add(this.btnAnadirTest);
            this.Controls.Add(this.txtAnadirTest);
            this.Controls.Add(this.label1);
            this.Name = "FrmAnadirTest";
            this.Text = "Añadir Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnadirTest;
        private System.Windows.Forms.Button btnAnadirTest;
        private System.Windows.Forms.ListBox lsbTestExistentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}