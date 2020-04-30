namespace CapaPresentacion
{
    partial class FrmBorrarPregunta
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
            this.cboPreguntas = new System.Windows.Forms.ComboBox();
            this.btnBorrarPregunta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblValido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolverTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una pregunta para borrar";
            // 
            // cboPreguntas
            // 
            this.cboPreguntas.FormattingEnabled = true;
            this.cboPreguntas.Location = new System.Drawing.Point(350, 182);
            this.cboPreguntas.Name = "cboPreguntas";
            this.cboPreguntas.Size = new System.Drawing.Size(378, 24);
            this.cboPreguntas.TabIndex = 1;
            this.cboPreguntas.SelectedIndexChanged += new System.EventHandler(this.cboPreguntas_SelectedIndexChanged);
            // 
            // btnBorrarPregunta
            // 
            this.btnBorrarPregunta.Location = new System.Drawing.Point(432, 340);
            this.btnBorrarPregunta.Name = "btnBorrarPregunta";
            this.btnBorrarPregunta.Size = new System.Drawing.Size(112, 48);
            this.btnBorrarPregunta.TabIndex = 2;
            this.btnBorrarPregunta.Text = "Eliminar Pregunta";
            this.btnBorrarPregunta.UseVisualStyleBackColor = true;
            this.btnBorrarPregunta.Click += new System.EventHandler(this.btnBorrarPregunta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(407, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Borrar Pregunta";
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.AutoSize = true;
            this.lblEnunciado.Location = new System.Drawing.Point(350, 245);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(0, 17);
            this.lblEnunciado.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enunciado de la pregunta";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 450);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblValido
            // 
            this.lblValido.AutoSize = true;
            this.lblValido.Location = new System.Drawing.Point(350, 290);
            this.lblValido.Name = "lblValido";
            this.lblValido.Size = new System.Drawing.Size(0, 17);
            this.lblValido.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Validez de la prgeunta (Verdad/Falso)";
            // 
            // btnVolverTest
            // 
            this.btnVolverTest.Location = new System.Drawing.Point(183, 450);
            this.btnVolverTest.Name = "btnVolverTest";
            this.btnVolverTest.Size = new System.Drawing.Size(126, 45);
            this.btnVolverTest.TabIndex = 14;
            this.btnVolverTest.Text = "&Volver Al Test";
            this.btnVolverTest.UseVisualStyleBackColor = true;
            this.btnVolverTest.Click += new System.EventHandler(this.btnVolverTest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Test:";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(113, 64);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(0, 20);
            this.lblTest.TabIndex = 15;
            // 
            // FrmBorrarPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 520);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnVolverTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblValido);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEnunciado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBorrarPregunta);
            this.Controls.Add(this.cboPreguntas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmBorrarPregunta";
            this.Text = "Borrar Pregunta";
            this.Load += new System.EventHandler(this.FrmBorrarPregunta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPreguntas;
        private System.Windows.Forms.Button btnBorrarPregunta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblValido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVolverTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTest;
    }
}