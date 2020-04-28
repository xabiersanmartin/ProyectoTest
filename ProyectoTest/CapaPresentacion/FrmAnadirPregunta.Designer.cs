namespace CapaPresentacion
{
    partial class FrmAnadirPregunta
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
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.rdVerdadera = new System.Windows.Forms.RadioButton();
            this.rdFalsa = new System.Windows.Forms.RadioButton();
            this.btnAnadirPregunta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNumPreg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(578, 74);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 20);
            this.lbl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Pregunta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enunciado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Respuesta";
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Location = new System.Drawing.Point(366, 213);
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.Size = new System.Drawing.Size(217, 22);
            this.txtEnunciado.TabIndex = 5;
            this.txtEnunciado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnunciado_KeyPress);
            // 
            // rdVerdadera
            // 
            this.rdVerdadera.AutoSize = true;
            this.rdVerdadera.Location = new System.Drawing.Point(348, 281);
            this.rdVerdadera.Name = "rdVerdadera";
            this.rdVerdadera.Size = new System.Drawing.Size(96, 21);
            this.rdVerdadera.TabIndex = 6;
            this.rdVerdadera.TabStop = true;
            this.rdVerdadera.Text = "Verdadera";
            this.rdVerdadera.UseVisualStyleBackColor = true;
            // 
            // rdFalsa
            // 
            this.rdFalsa.AutoSize = true;
            this.rdFalsa.Location = new System.Drawing.Point(502, 279);
            this.rdFalsa.Name = "rdFalsa";
            this.rdFalsa.Size = new System.Drawing.Size(63, 21);
            this.rdFalsa.TabIndex = 7;
            this.rdFalsa.TabStop = true;
            this.rdFalsa.Text = "Falsa";
            this.rdFalsa.UseVisualStyleBackColor = true;
            // 
            // btnAnadirPregunta
            // 
            this.btnAnadirPregunta.Location = new System.Drawing.Point(387, 359);
            this.btnAnadirPregunta.Name = "btnAnadirPregunta";
            this.btnAnadirPregunta.Size = new System.Drawing.Size(114, 43);
            this.btnAnadirPregunta.TabIndex = 8;
            this.btnAnadirPregunta.Text = "Añadir Pregunta";
            this.btnAnadirPregunta.UseVisualStyleBackColor = true;
            this.btnAnadirPregunta.Click += new System.EventHandler(this.btnAnadirPregunta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Test:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 431);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(126, 45);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNumPreg
            // 
            this.lblNumPreg.AutoSize = true;
            this.lblNumPreg.Location = new System.Drawing.Point(366, 149);
            this.lblNumPreg.Name = "lblNumPreg";
            this.lblNumPreg.Size = new System.Drawing.Size(0, 17);
            this.lblNumPreg.TabIndex = 11;
            // 
            // FrmAnadirPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.lblNumPreg);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAnadirPregunta);
            this.Controls.Add(this.rdFalsa);
            this.Controls.Add(this.rdVerdadera);
            this.Controls.Add(this.txtEnunciado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmAnadirPregunta";
            this.Text = "Añadir Pregunta";
            this.Load += new System.EventHandler(this.FrmAnadirPregunta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.RadioButton rdVerdadera;
        private System.Windows.Forms.RadioButton rdFalsa;
        private System.Windows.Forms.Button btnAnadirPregunta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNumPreg;
    }
}