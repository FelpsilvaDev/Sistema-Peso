namespace Sistema_de_medidas
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.bntCalcinha = new System.Windows.Forms.Button();
            this.btnCalcinha = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bntCalcinha
            // 
            this.bntCalcinha.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.logotipo;
            this.bntCalcinha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.bntCalcinha.Location = new System.Drawing.Point(372, 49);
            this.bntCalcinha.Margin = new System.Windows.Forms.Padding(4);
            this.bntCalcinha.Name = "bntCalcinha";
            this.bntCalcinha.Size = new System.Drawing.Size(164, 69);
            this.bntCalcinha.TabIndex = 0;
            this.bntCalcinha.Text = "CALCINHA";
            this.bntCalcinha.UseMnemonic = false;
            this.bntCalcinha.UseVisualStyleBackColor = false;
            this.bntCalcinha.Click += new System.EventHandler(this.btnCalcinha_Click);
            // 
            // btnCalcinha
            // 
            this.btnCalcinha.BackColor = System.Drawing.Color.Transparent;
            this.btnCalcinha.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.logotipo;
            this.btnCalcinha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcinha.Location = new System.Drawing.Point(128, 46);
            this.btnCalcinha.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcinha.Name = "btnCalcinha";
            this.btnCalcinha.Size = new System.Drawing.Size(143, 69);
            this.btnCalcinha.TabIndex = 1;
            this.btnCalcinha.Text = "SUTIÃ";
            this.btnCalcinha.UseVisualStyleBackColor = false;
            this.btnCalcinha.Click += new System.EventHandler(this.btnSutia_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.logotipo;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.button3.Location = new System.Drawing.Point(659, 49);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 63);
            this.button3.TabIndex = 2;
            this.button3.Text = "SAIR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.icons8_panties_60;
            this.pictureBox2.Location = new System.Drawing.Point(288, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 69);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Sistema_de_Peso.Properties.Resources.icons8_exit_60;
            this.pictureBox3.Location = new System.Drawing.Point(559, 49);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(93, 69);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Sistema_de_Peso.Properties.Resources.icons8_sutiã_80;
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 96);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.recortado;
            this.ClientSize = new System.Drawing.Size(826, 749);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCalcinha);
            this.Controls.Add(this.bntCalcinha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Peso";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntCalcinha;
        private System.Windows.Forms.Button btnCalcinha;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

