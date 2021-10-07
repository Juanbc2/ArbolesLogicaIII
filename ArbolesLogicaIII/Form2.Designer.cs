namespace ArbolesLogicaIII
{
    partial class Form2
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
            this.infoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.padreLabel = new System.Windows.Forms.Label();
            this.abueloLabel = new System.Windows.Forms.Label();
            this.tioLabel = new System.Windows.Forms.Label();
            this.direccionLabel = new System.Windows.Forms.Label();
            this.hijosLabel = new System.Windows.Forms.Label();
            this.hermanoLabel = new System.Windows.Forms.Label();
            this.ancestrosLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(6, 63);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(218, 25);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Información del árbol:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resultados del árbol";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Información de un nodo específico:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 335);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elija el nodo:";
            // 
            // padreLabel
            // 
            this.padreLabel.AutoSize = true;
            this.padreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.padreLabel.Location = new System.Drawing.Point(335, 274);
            this.padreLabel.Name = "padreLabel";
            this.padreLabel.Size = new System.Drawing.Size(10, 15);
            this.padreLabel.TabIndex = 7;
            this.padreLabel.Text = ".";
            // 
            // abueloLabel
            // 
            this.abueloLabel.AutoSize = true;
            this.abueloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abueloLabel.Location = new System.Drawing.Point(335, 296);
            this.abueloLabel.Name = "abueloLabel";
            this.abueloLabel.Size = new System.Drawing.Size(10, 15);
            this.abueloLabel.TabIndex = 8;
            this.abueloLabel.Text = ".";
            // 
            // tioLabel
            // 
            this.tioLabel.AutoSize = true;
            this.tioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tioLabel.Location = new System.Drawing.Point(335, 317);
            this.tioLabel.Name = "tioLabel";
            this.tioLabel.Size = new System.Drawing.Size(10, 15);
            this.tioLabel.TabIndex = 9;
            this.tioLabel.Text = ".";
            // 
            // direccionLabel
            // 
            this.direccionLabel.AutoSize = true;
            this.direccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionLabel.Location = new System.Drawing.Point(335, 337);
            this.direccionLabel.Name = "direccionLabel";
            this.direccionLabel.Size = new System.Drawing.Size(10, 15);
            this.direccionLabel.TabIndex = 10;
            this.direccionLabel.Text = ".";
            // 
            // hijosLabel
            // 
            this.hijosLabel.AutoSize = true;
            this.hijosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hijosLabel.Location = new System.Drawing.Point(335, 359);
            this.hijosLabel.Name = "hijosLabel";
            this.hijosLabel.Size = new System.Drawing.Size(10, 15);
            this.hijosLabel.TabIndex = 11;
            this.hijosLabel.Text = ".";
            // 
            // hermanoLabel
            // 
            this.hermanoLabel.AutoSize = true;
            this.hermanoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hermanoLabel.Location = new System.Drawing.Point(335, 379);
            this.hermanoLabel.Name = "hermanoLabel";
            this.hermanoLabel.Size = new System.Drawing.Size(10, 15);
            this.hermanoLabel.TabIndex = 12;
            this.hermanoLabel.Text = ".";
            // 
            // ancestrosLabel
            // 
            this.ancestrosLabel.AutoSize = true;
            this.ancestrosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ancestrosLabel.Location = new System.Drawing.Point(335, 399);
            this.ancestrosLabel.Name = "ancestrosLabel";
            this.ancestrosLabel.Size = new System.Drawing.Size(10, 15);
            this.ancestrosLabel.TabIndex = 13;
            this.ancestrosLabel.Text = ".";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 427);
            this.Controls.Add(this.ancestrosLabel);
            this.Controls.Add(this.hermanoLabel);
            this.Controls.Add(this.hijosLabel);
            this.Controls.Add(this.direccionLabel);
            this.Controls.Add(this.tioLabel);
            this.Controls.Add(this.abueloLabel);
            this.Controls.Add(this.padreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoLabel);
            this.Name = "Form2";
            this.Text = "Resultados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label padreLabel;
        private System.Windows.Forms.Label abueloLabel;
        private System.Windows.Forms.Label tioLabel;
        private System.Windows.Forms.Label direccionLabel;
        private System.Windows.Forms.Label hijosLabel;
        private System.Windows.Forms.Label hermanoLabel;
        private System.Windows.Forms.Label ancestrosLabel;
    }
}