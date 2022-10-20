namespace ProjetIA2022
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxYinit = new System.Windows.Forms.TextBox();
            this.textBoxXInit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonInit1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxXFinal = new System.Windows.Forms.TextBox();
            this.textBoxYFinal = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonInit2 = new System.Windows.Forms.Button();
            this.buttonInit3 = new System.Windows.Forms.Button();
            this.buttonAstar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelOuverts = new System.Windows.Forms.Label();
            this.labelFermes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxYinit
            // 
            this.textBoxYinit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYinit.Location = new System.Drawing.Point(56, 80);
            this.textBoxYinit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxYinit.Name = "textBoxYinit";
            this.textBoxYinit.Size = new System.Drawing.Size(76, 23);
            this.textBoxYinit.TabIndex = 0;
            this.textBoxYinit.Text = "3";
            // 
            // textBoxXInit
            // 
            this.textBoxXInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXInit.Location = new System.Drawing.Point(56, 48);
            this.textBoxXInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxXInit.Name = "textBoxXInit";
            this.textBoxXInit.Size = new System.Drawing.Size(76, 23);
            this.textBoxXInit.TabIndex = 1;
            this.textBoxXInit.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xinit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yinit";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(866, 158);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(151, 180);
            this.listBox1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(866, 400);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(151, 160);
            this.treeView1.TabIndex = 5;
            // 
            // buttonInit1
            // 
            this.buttonInit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInit1.Location = new System.Drawing.Point(310, 25);
            this.buttonInit1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInit1.Name = "buttonInit1";
            this.buttonInit1.Size = new System.Drawing.Size(76, 24);
            this.buttonInit1.TabIndex = 6;
            this.buttonInit1.Text = "Init Env1";
            this.buttonInit1.UseVisualStyleBackColor = true;
            this.buttonInit1.Click += new System.EventHandler(this.buttonInit1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 158);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Xfinal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Yfinal";
            // 
            // textBoxXFinal
            // 
            this.textBoxXFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXFinal.Location = new System.Drawing.Point(56, 150);
            this.textBoxXFinal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxXFinal.Name = "textBoxXFinal";
            this.textBoxXFinal.Size = new System.Drawing.Size(76, 23);
            this.textBoxXFinal.TabIndex = 10;
            this.textBoxXFinal.Text = "16";
            // 
            // textBoxYFinal
            // 
            this.textBoxYFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYFinal.Location = new System.Drawing.Point(56, 188);
            this.textBoxYFinal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxYFinal.Name = "textBoxYFinal";
            this.textBoxYFinal.Size = new System.Drawing.Size(76, 23);
            this.textBoxYFinal.TabIndex = 11;
            this.textBoxYFinal.Text = "18";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, 372);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 219);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // buttonInit2
            // 
            this.buttonInit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInit2.Location = new System.Drawing.Point(448, 25);
            this.buttonInit2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInit2.Name = "buttonInit2";
            this.buttonInit2.Size = new System.Drawing.Size(79, 24);
            this.buttonInit2.TabIndex = 13;
            this.buttonInit2.Text = "Init Env2";
            this.buttonInit2.UseVisualStyleBackColor = true;
            this.buttonInit2.Click += new System.EventHandler(this.buttonInit2_Click);
            // 
            // buttonInit3
            // 
            this.buttonInit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInit3.Location = new System.Drawing.Point(580, 25);
            this.buttonInit3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInit3.Name = "buttonInit3";
            this.buttonInit3.Size = new System.Drawing.Size(94, 24);
            this.buttonInit3.TabIndex = 14;
            this.buttonInit3.Text = "Init Env3";
            this.buttonInit3.UseVisualStyleBackColor = true;
            this.buttonInit3.Click += new System.EventHandler(this.buttonInit3_Click);
            // 
            // buttonAstar
            // 
            this.buttonAstar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAstar.Location = new System.Drawing.Point(448, 81);
            this.buttonAstar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAstar.Name = "buttonAstar";
            this.buttonAstar.Size = new System.Drawing.Size(86, 31);
            this.buttonAstar.TabIndex = 15;
            this.buttonAstar.Text = "Lancer A*";
            this.buttonAstar.UseVisualStyleBackColor = true;
            this.buttonAstar.Click += new System.EventHandler(this.buttonAstar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(803, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nb Ouverts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(803, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nb fermés";
            // 
            // labelOuverts
            // 
            this.labelOuverts.AutoSize = true;
            this.labelOuverts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOuverts.Location = new System.Drawing.Point(885, 48);
            this.labelOuverts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOuverts.Name = "labelOuverts";
            this.labelOuverts.Size = new System.Drawing.Size(16, 17);
            this.labelOuverts.TabIndex = 18;
            this.labelOuverts.Text = "0";
            // 
            // labelFermes
            // 
            this.labelFermes.AutoSize = true;
            this.labelFermes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFermes.Location = new System.Drawing.Point(885, 67);
            this.labelFermes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFermes.Name = "labelFermes";
            this.labelFermes.Size = new System.Drawing.Size(16, 17);
            this.labelFermes.TabIndex = 19;
            this.labelFermes.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(867, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Chemin solution";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(872, 379);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Arbre de recherche";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(344, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Abscisses : valeurs de 0 à 19";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(283, 158);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 374);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 616);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelFermes);
            this.Controls.Add(this.labelOuverts);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAstar);
            this.Controls.Add(this.buttonInit3);
            this.Controls.Add(this.buttonInit2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxYFinal);
            this.Controls.Add(this.textBoxXFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonInit1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxXInit);
            this.Controls.Add(this.textBoxYinit);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Projet IA 2022";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Click += new System.EventHandler(this.buttonInit1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxYinit;
        private System.Windows.Forms.TextBox textBoxXInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonInit1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxXFinal;
        private System.Windows.Forms.TextBox textBoxYFinal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonInit2;
        private System.Windows.Forms.Button buttonInit3;
        private System.Windows.Forms.Button buttonAstar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelOuverts;
        private System.Windows.Forms.Label labelFermes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

