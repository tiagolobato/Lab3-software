namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnviarAltura = new System.Windows.Forms.Button();
            this.btnEnviarAngulo = new System.Windows.Forms.Button();
            this.lblAnguloFixo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblAlturaFixo = new System.Windows.Forms.Label();
            this.lblAlturaInfoFixo = new System.Windows.Forms.Label();
            this.lblAnguloInfoFixo = new System.Windows.Forms.Label();
            this.lblDistanciaInfoFixo = new System.Windows.Forms.Label();
            this.textBoxDistancia = new System.Windows.Forms.TextBox();
            this.textBoxAngulo = new System.Windows.Forms.TextBox();
            this.textBoxAltura = new System.Windows.Forms.TextBox();
            this.btnArrowUp = new System.Windows.Forms.Button();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.btnArrowRigth = new System.Windows.Forms.Button();
            this.btnArrowDown = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pctBoxControle = new System.Windows.Forms.PictureBox();
            this.btnLigarGuindaste = new System.Windows.Forms.Button();
            this.pctBoxGuindaste = new System.Windows.Forms.PictureBox();
            this.lblBoxGuindaste = new System.Windows.Forms.Label();
            this.lblInfoFixo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBoxIma = new System.Windows.Forms.Label();
            this.pctBoxIma = new System.Windows.Forms.PictureBox();
            this.btnLigarIma = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxControle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxGuindaste)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxIma)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnviarAltura
            // 
            this.btnEnviarAltura.Location = new System.Drawing.Point(244, 346);
            this.btnEnviarAltura.Name = "btnEnviarAltura";
            this.btnEnviarAltura.Size = new System.Drawing.Size(45, 33);
            this.btnEnviarAltura.TabIndex = 0;
            this.btnEnviarAltura.Text = "OK";
            this.btnEnviarAltura.UseVisualStyleBackColor = true;
            this.btnEnviarAltura.Click += new System.EventHandler(this.btnEnviarAltura_Click);
            // 
            // btnEnviarAngulo
            // 
            this.btnEnviarAngulo.Location = new System.Drawing.Point(244, 386);
            this.btnEnviarAngulo.Name = "btnEnviarAngulo";
            this.btnEnviarAngulo.Size = new System.Drawing.Size(45, 31);
            this.btnEnviarAngulo.TabIndex = 1;
            this.btnEnviarAngulo.Text = "OK";
            this.btnEnviarAngulo.UseVisualStyleBackColor = true;
            this.btnEnviarAngulo.Click += new System.EventHandler(this.btnEnviarAngulo_Click);
            // 
            // lblAnguloFixo
            // 
            this.lblAnguloFixo.AutoSize = true;
            this.lblAnguloFixo.Location = new System.Drawing.Point(51, 390);
            this.lblAnguloFixo.Name = "lblAnguloFixo";
            this.lblAnguloFixo.Size = new System.Drawing.Size(52, 17);
            this.lblAnguloFixo.TabIndex = 2;
            this.lblAnguloFixo.Text = "Ângulo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 390);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 351);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // lblAlturaFixo
            // 
            this.lblAlturaFixo.AutoSize = true;
            this.lblAlturaFixo.Location = new System.Drawing.Point(51, 351);
            this.lblAlturaFixo.Name = "lblAlturaFixo";
            this.lblAlturaFixo.Size = new System.Drawing.Size(45, 17);
            this.lblAlturaFixo.TabIndex = 4;
            this.lblAlturaFixo.Text = "Altura";
            // 
            // lblAlturaInfoFixo
            // 
            this.lblAlturaInfoFixo.AutoSize = true;
            this.lblAlturaInfoFixo.Location = new System.Drawing.Point(44, 71);
            this.lblAlturaInfoFixo.Name = "lblAlturaInfoFixo";
            this.lblAlturaInfoFixo.Size = new System.Drawing.Size(45, 17);
            this.lblAlturaInfoFixo.TabIndex = 7;
            this.lblAlturaInfoFixo.Text = "Altura";
            // 
            // lblAnguloInfoFixo
            // 
            this.lblAnguloInfoFixo.AutoSize = true;
            this.lblAnguloInfoFixo.Location = new System.Drawing.Point(149, 71);
            this.lblAnguloInfoFixo.Name = "lblAnguloInfoFixo";
            this.lblAnguloInfoFixo.Size = new System.Drawing.Size(52, 17);
            this.lblAnguloInfoFixo.TabIndex = 9;
            this.lblAnguloInfoFixo.Text = "Ângulo";
            // 
            // lblDistanciaInfoFixo
            // 
            this.lblDistanciaInfoFixo.AutoSize = true;
            this.lblDistanciaInfoFixo.Location = new System.Drawing.Point(244, 71);
            this.lblDistanciaInfoFixo.Name = "lblDistanciaInfoFixo";
            this.lblDistanciaInfoFixo.Size = new System.Drawing.Size(66, 17);
            this.lblDistanciaInfoFixo.TabIndex = 11;
            this.lblDistanciaInfoFixo.Text = "Distância";
            // 
            // textBoxDistancia
            // 
            this.textBoxDistancia.BackColor = System.Drawing.Color.Chartreuse;
            this.textBoxDistancia.Enabled = false;
            this.textBoxDistancia.ForeColor = System.Drawing.Color.White;
            this.textBoxDistancia.Location = new System.Drawing.Point(236, 91);
            this.textBoxDistancia.Name = "textBoxDistancia";
            this.textBoxDistancia.Size = new System.Drawing.Size(84, 22);
            this.textBoxDistancia.TabIndex = 10;
            this.textBoxDistancia.Text = "3cm";
            this.textBoxDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAngulo
            // 
            this.textBoxAngulo.BackColor = System.Drawing.Color.LawnGreen;
            this.textBoxAngulo.Enabled = false;
            this.textBoxAngulo.ForeColor = System.Drawing.Color.White;
            this.textBoxAngulo.Location = new System.Drawing.Point(136, 91);
            this.textBoxAngulo.Name = "textBoxAngulo";
            this.textBoxAngulo.Size = new System.Drawing.Size(84, 22);
            this.textBoxAngulo.TabIndex = 12;
            this.textBoxAngulo.Text = "150º";
            this.textBoxAngulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAltura
            // 
            this.textBoxAltura.BackColor = System.Drawing.Color.Chartreuse;
            this.textBoxAltura.Enabled = false;
            this.textBoxAltura.ForeColor = System.Drawing.Color.White;
            this.textBoxAltura.Location = new System.Drawing.Point(23, 91);
            this.textBoxAltura.Name = "textBoxAltura";
            this.textBoxAltura.Size = new System.Drawing.Size(84, 22);
            this.textBoxAltura.TabIndex = 13;
            this.textBoxAltura.Text = "20cm";
            this.textBoxAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnArrowUp
            // 
            this.btnArrowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrowUp.Location = new System.Drawing.Point(154, 57);
            this.btnArrowUp.Name = "btnArrowUp";
            this.btnArrowUp.Size = new System.Drawing.Size(49, 54);
            this.btnArrowUp.TabIndex = 14;
            this.btnArrowUp.UseVisualStyleBackColor = true;
            // 
            // btnArrowLeft
            // 
            this.btnArrowLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrowLeft.Location = new System.Drawing.Point(75, 126);
            this.btnArrowLeft.Name = "btnArrowLeft";
            this.btnArrowLeft.Size = new System.Drawing.Size(57, 58);
            this.btnArrowLeft.TabIndex = 15;
            this.btnArrowLeft.UseVisualStyleBackColor = true;
            // 
            // btnArrowRigth
            // 
            this.btnArrowRigth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrowRigth.Location = new System.Drawing.Point(216, 126);
            this.btnArrowRigth.Name = "btnArrowRigth";
            this.btnArrowRigth.Size = new System.Drawing.Size(60, 58);
            this.btnArrowRigth.TabIndex = 16;
            this.btnArrowRigth.UseVisualStyleBackColor = true;
            // 
            // btnArrowDown
            // 
            this.btnArrowDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrowDown.Location = new System.Drawing.Point(154, 126);
            this.btnArrowDown.Name = "btnArrowDown";
            this.btnArrowDown.Size = new System.Drawing.Size(49, 58);
            this.btnArrowDown.TabIndex = 17;
            this.btnArrowDown.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(75, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 45);
            this.button3.TabIndex = 18;
            this.button3.Text = "Habilitar Controle Manual";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnArrowRigth);
            this.panel1.Controls.Add(this.pctBoxControle);
            this.panel1.Controls.Add(this.btnArrowUp);
            this.panel1.Controls.Add(this.btnArrowLeft);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnArrowDown);
            this.panel1.Location = new System.Drawing.Point(46, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 278);
            this.panel1.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "OFF";
            // 
            // pctBoxControle
            // 
            this.pctBoxControle.BackColor = System.Drawing.Color.Red;
            this.pctBoxControle.Location = new System.Drawing.Point(5, 3);
            this.pctBoxControle.Name = "pctBoxControle";
            this.pctBoxControle.Size = new System.Drawing.Size(24, 23);
            this.pctBoxControle.TabIndex = 23;
            this.pctBoxControle.TabStop = false;
            // 
            // btnLigarGuindaste
            // 
            this.btnLigarGuindaste.BackColor = System.Drawing.SystemColors.Control;
            this.btnLigarGuindaste.Location = new System.Drawing.Point(41, 23);
            this.btnLigarGuindaste.Name = "btnLigarGuindaste";
            this.btnLigarGuindaste.Size = new System.Drawing.Size(122, 81);
            this.btnLigarGuindaste.TabIndex = 20;
            this.btnLigarGuindaste.Text = "Ligar Guindaste";
            this.btnLigarGuindaste.UseVisualStyleBackColor = false;
            this.btnLigarGuindaste.Click += new System.EventHandler(this.btnLigarGuindaste_Click);
            // 
            // pctBoxGuindaste
            // 
            this.pctBoxGuindaste.BackColor = System.Drawing.Color.Red;
            this.pctBoxGuindaste.Location = new System.Drawing.Point(182, 23);
            this.pctBoxGuindaste.Name = "pctBoxGuindaste";
            this.pctBoxGuindaste.Size = new System.Drawing.Size(84, 81);
            this.pctBoxGuindaste.TabIndex = 21;
            this.pctBoxGuindaste.TabStop = false;
            // 
            // lblBoxGuindaste
            // 
            this.lblBoxGuindaste.AutoSize = true;
            this.lblBoxGuindaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxGuindaste.Location = new System.Drawing.Point(272, 55);
            this.lblBoxGuindaste.Name = "lblBoxGuindaste";
            this.lblBoxGuindaste.Size = new System.Drawing.Size(52, 25);
            this.lblBoxGuindaste.TabIndex = 22;
            this.lblBoxGuindaste.Text = "OFF";
            // 
            // lblInfoFixo
            // 
            this.lblInfoFixo.AutoSize = true;
            this.lblInfoFixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoFixo.Location = new System.Drawing.Point(67, 21);
            this.lblInfoFixo.Name = "lblInfoFixo";
            this.lblInfoFixo.Size = new System.Drawing.Size(234, 32);
            this.lblInfoFixo.TabIndex = 23;
            this.lblInfoFixo.Text = "INFORMAÇÕES";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblInfoFixo);
            this.panel2.Controls.Add(this.lblAlturaInfoFixo);
            this.panel2.Controls.Add(this.lblAnguloInfoFixo);
            this.panel2.Controls.Add(this.textBoxDistancia);
            this.panel2.Controls.Add(this.lblDistanciaInfoFixo);
            this.panel2.Controls.Add(this.textBoxAngulo);
            this.panel2.Controls.Add(this.textBoxAltura);
            this.panel2.Location = new System.Drawing.Point(46, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 127);
            this.panel2.TabIndex = 24;
            // 
            // lblBoxIma
            // 
            this.lblBoxIma.AutoSize = true;
            this.lblBoxIma.Location = new System.Drawing.Point(254, 285);
            this.lblBoxIma.Name = "lblBoxIma";
            this.lblBoxIma.Size = new System.Drawing.Size(35, 17);
            this.lblBoxIma.TabIndex = 27;
            this.lblBoxIma.Text = "OFF";
            // 
            // pctBoxIma
            // 
            this.pctBoxIma.BackColor = System.Drawing.Color.Red;
            this.pctBoxIma.Location = new System.Drawing.Point(182, 275);
            this.pctBoxIma.Name = "pctBoxIma";
            this.pctBoxIma.Size = new System.Drawing.Size(44, 37);
            this.pctBoxIma.TabIndex = 26;
            this.pctBoxIma.TabStop = false;
            // 
            // btnLigarIma
            // 
            this.btnLigarIma.Location = new System.Drawing.Point(54, 275);
            this.btnLigarIma.Name = "btnLigarIma";
            this.btnLigarIma.Size = new System.Drawing.Size(77, 37);
            this.btnLigarIma.TabIndex = 25;
            this.btnLigarIma.Text = "Ligar Imã";
            this.btnLigarIma.UseVisualStyleBackColor = true;
            this.btnLigarIma.Click += new System.EventHandler(this.btnLigarIma_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pctBoxGuindaste);
            this.panel3.Controls.Add(this.lblBoxIma);
            this.panel3.Controls.Add(this.btnEnviarAltura);
            this.panel3.Controls.Add(this.pctBoxIma);
            this.panel3.Controls.Add(this.btnEnviarAngulo);
            this.panel3.Controls.Add(this.btnLigarIma);
            this.panel3.Controls.Add(this.lblAnguloFixo);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.lblBoxGuindaste);
            this.panel3.Controls.Add(this.lblAlturaFixo);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.btnLigarGuindaste);
            this.panel3.Location = new System.Drawing.Point(423, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 426);
            this.panel3.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxControle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxGuindaste)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxIma)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarAltura;
        private System.Windows.Forms.Button btnEnviarAngulo;
        private System.Windows.Forms.Label lblAnguloFixo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblAlturaFixo;
        private System.Windows.Forms.Label lblAlturaInfoFixo;
        private System.Windows.Forms.Label lblAnguloInfoFixo;
        private System.Windows.Forms.Label lblDistanciaInfoFixo;
        private System.Windows.Forms.TextBox textBoxDistancia;
        private System.Windows.Forms.TextBox textBoxAngulo;
        private System.Windows.Forms.TextBox textBoxAltura;
        private System.Windows.Forms.Button btnArrowUp;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.Button btnArrowRigth;
        private System.Windows.Forms.Button btnArrowDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLigarGuindaste;
        private System.Windows.Forms.PictureBox pctBoxGuindaste;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pctBoxControle;
        private System.Windows.Forms.Label lblBoxGuindaste;
        private System.Windows.Forms.Label lblInfoFixo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBoxIma;
        private System.Windows.Forms.PictureBox pctBoxIma;
        private System.Windows.Forms.Button btnLigarIma;
        private System.Windows.Forms.Panel panel3;
    }
}

