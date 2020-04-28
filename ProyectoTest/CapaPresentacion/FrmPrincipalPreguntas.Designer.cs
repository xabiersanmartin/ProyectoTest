namespace CapaPresentacion
{
    partial class FrmPrincipalPreguntas
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
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTestDeCategorias = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnHacerTest = new System.Windows.Forms.Button();
            this.btnAnadirPreguntas = new System.Windows.Forms.Button();
            this.btnBorrarPreguntas = new System.Windows.Forms.Button();
            this.btnBorrarTodas = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categorias: ";
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(130, 71);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(172, 24);
            this.cboCategorias.TabIndex = 1;
            this.cboCategorias.SelectedIndexChanged += new System.EventHandler(this.cboCategorias_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test por categoria: ";
            // 
            // cboTestDeCategorias
            // 
            this.cboTestDeCategorias.FormattingEnabled = true;
            this.cboTestDeCategorias.Location = new System.Drawing.Point(553, 71);
            this.cboTestDeCategorias.Name = "cboTestDeCategorias";
            this.cboTestDeCategorias.Size = new System.Drawing.Size(185, 24);
            this.cboTestDeCategorias.TabIndex = 3;
            this.cboTestDeCategorias.SelectedIndexChanged += new System.EventHandler(this.cboTestDeCategorias_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "TEST: ";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(362, 166);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(0, 42);
            this.lblTest.TabIndex = 5;
            // 
            // btnHacerTest
            // 
            this.btnHacerTest.Location = new System.Drawing.Point(143, 294);
            this.btnHacerTest.Name = "btnHacerTest";
            this.btnHacerTest.Size = new System.Drawing.Size(97, 43);
            this.btnHacerTest.TabIndex = 6;
            this.btnHacerTest.Text = "Hacer Test";
            this.btnHacerTest.UseVisualStyleBackColor = true;
            // 
            // btnAnadirPreguntas
            // 
            this.btnAnadirPreguntas.Location = new System.Drawing.Point(286, 294);
            this.btnAnadirPreguntas.Name = "btnAnadirPreguntas";
            this.btnAnadirPreguntas.Size = new System.Drawing.Size(94, 43);
            this.btnAnadirPreguntas.TabIndex = 7;
            this.btnAnadirPreguntas.Text = "Añadir Preguntas";
            this.btnAnadirPreguntas.UseVisualStyleBackColor = true;
            this.btnAnadirPreguntas.Click += new System.EventHandler(this.btnAnadirPreguntas_Click);
            // 
            // btnBorrarPreguntas
            // 
            this.btnBorrarPreguntas.Location = new System.Drawing.Point(433, 294);
            this.btnBorrarPreguntas.Name = "btnBorrarPreguntas";
            this.btnBorrarPreguntas.Size = new System.Drawing.Size(94, 43);
            this.btnBorrarPreguntas.TabIndex = 8;
            this.btnBorrarPreguntas.Text = "Borrar Preguntas";
            this.btnBorrarPreguntas.UseVisualStyleBackColor = true;
            this.btnBorrarPreguntas.Click += new System.EventHandler(this.btnBorrarPreguntas_Click);
            // 
            // btnBorrarTodas
            // 
            this.btnBorrarTodas.Location = new System.Drawing.Point(578, 294);
            this.btnBorrarTodas.Name = "btnBorrarTodas";
            this.btnBorrarTodas.Size = new System.Drawing.Size(94, 43);
            this.btnBorrarTodas.TabIndex = 9;
            this.btnBorrarTodas.Text = "Borrar Todas";
            this.btnBorrarTodas.UseVisualStyleBackColor = true;
            this.btnBorrarTodas.Click += new System.EventHandler(this.btnBorrarTodas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 467);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmPrincipalPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnBorrarTodas);
            this.Controls.Add(this.btnBorrarPreguntas);
            this.Controls.Add(this.btnAnadirPreguntas);
            this.Controls.Add(this.btnHacerTest);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTestDeCategorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCategorias);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPrincipalPreguntas";
            this.Text = "FrmPrincipalPreguntas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipalPreguntas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTestDeCategorias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnHacerTest;
        private System.Windows.Forms.Button btnAnadirPreguntas;
        private System.Windows.Forms.Button btnBorrarPreguntas;
        private System.Windows.Forms.Button btnBorrarTodas;
        private System.Windows.Forms.Button btnVolver;
    }
}