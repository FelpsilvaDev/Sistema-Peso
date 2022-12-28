namespace Sistema_de_medidas
{
    partial class SUTIA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUTIA));
            this.btnAnexar = new System.Windows.Forms.Button();
            this.gridMedidas = new System.Windows.Forms.DataGridView();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIQUIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMBALAGEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOJO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.txtLiquido = new System.Windows.Forms.TextBox();
            this.txtEmbalagem = new System.Windows.Forms.TextBox();
            this.txtBojo = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBruto = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnexar
            // 
            this.btnAnexar.BackColor = System.Drawing.Color.Transparent;
            this.btnAnexar.Location = new System.Drawing.Point(208, 102);
            this.btnAnexar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(153, 44);
            this.btnAnexar.TabIndex = 0;
            this.btnAnexar.Text = "Anexar";
            this.btnAnexar.UseVisualStyleBackColor = false;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // gridMedidas
            // 
            this.gridMedidas.AllowUserToAddRows = false;
            this.gridMedidas.AllowUserToDeleteRows = false;
            this.gridMedidas.AllowUserToOrderColumns = true;
            this.gridMedidas.BackgroundColor = System.Drawing.Color.Snow;
            this.gridMedidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMedidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKU,
            this.LIQUIDO,
            this.EMBALAGEM,
            this.BOJO,
            this.BRUTO});
            this.gridMedidas.GridColor = System.Drawing.SystemColors.HighlightText;
            this.gridMedidas.Location = new System.Drawing.Point(13, 171);
            this.gridMedidas.Margin = new System.Windows.Forms.Padding(4);
            this.gridMedidas.Name = "gridMedidas";
            this.gridMedidas.ReadOnly = true;
            this.gridMedidas.RowHeadersWidth = 51;
            this.gridMedidas.Size = new System.Drawing.Size(957, 512);
            this.gridMedidas.TabIndex = 1;
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "colunaskus";
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            this.SKU.ReadOnly = true;
            this.SKU.Width = 150;
            // 
            // LIQUIDO
            // 
            this.LIQUIDO.DataPropertyName = "colunaLiquido";
            this.LIQUIDO.HeaderText = "PESO LIQUIDO";
            this.LIQUIDO.MinimumWidth = 6;
            this.LIQUIDO.Name = "LIQUIDO";
            this.LIQUIDO.ReadOnly = true;
            this.LIQUIDO.Width = 125;
            // 
            // EMBALAGEM
            // 
            this.EMBALAGEM.DataPropertyName = "colunaembalagem";
            this.EMBALAGEM.HeaderText = "PESO EMBALAGEM";
            this.EMBALAGEM.MinimumWidth = 6;
            this.EMBALAGEM.Name = "EMBALAGEM";
            this.EMBALAGEM.ReadOnly = true;
            this.EMBALAGEM.Width = 125;
            // 
            // BOJO
            // 
            this.BOJO.DataPropertyName = "colunabojo";
            this.BOJO.HeaderText = "TAMANHO BOJO";
            this.BOJO.MinimumWidth = 6;
            this.BOJO.Name = "BOJO";
            this.BOJO.ReadOnly = true;
            this.BOJO.Width = 125;
            // 
            // BRUTO
            // 
            this.BRUTO.DataPropertyName = "colunabruto";
            this.BRUTO.HeaderText = "PESO BRUTO (TOTAL)";
            this.BRUTO.MinimumWidth = 6;
            this.BRUTO.Name = "BRUTO";
            this.BRUTO.ReadOnly = true;
            this.BRUTO.Width = 125;
            // 
            // txtSku
            // 
            this.txtSku.Location = new System.Drawing.Point(43, 65);
            this.txtSku.Margin = new System.Windows.Forms.Padding(4);
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(159, 22);
            this.txtSku.TabIndex = 2;
            // 
            // txtLiquido
            // 
            this.txtLiquido.Location = new System.Drawing.Point(208, 65);
            this.txtLiquido.Margin = new System.Windows.Forms.Padding(4);
            this.txtLiquido.Name = "txtLiquido";
            this.txtLiquido.Size = new System.Drawing.Size(185, 22);
            this.txtLiquido.TabIndex = 3;
            // 
            // txtEmbalagem
            // 
            this.txtEmbalagem.Location = new System.Drawing.Point(400, 65);
            this.txtEmbalagem.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmbalagem.Name = "txtEmbalagem";
            this.txtEmbalagem.Size = new System.Drawing.Size(215, 22);
            this.txtEmbalagem.TabIndex = 4;
            // 
            // txtBojo
            // 
            this.txtBojo.Location = new System.Drawing.Point(621, 65);
            this.txtBojo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBojo.Name = "txtBojo";
            this.txtBojo.Size = new System.Drawing.Size(165, 22);
            this.txtBojo.TabIndex = 5;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(43, 102);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(153, 44);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "SKU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.label2.Location = new System.Drawing.Point(204, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "PESO LIQUIDO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.label3.Location = new System.Drawing.Point(396, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "PESO EMBALAGEM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.label4.Location = new System.Drawing.Point(617, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "TAMANHO BOJO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.label5.Location = new System.Drawing.Point(829, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "PESO BRUTO";
            // 
            // lblBruto
            // 
            this.lblBruto.AutoSize = true;
            this.lblBruto.BackColor = System.Drawing.Color.Transparent;
            this.lblBruto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBruto.Location = new System.Drawing.Point(884, 64);
            this.lblBruto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBruto.Name = "lblBruto";
            this.lblBruto.Size = new System.Drawing.Size(0, 23);
            this.lblBruto.TabIndex = 13;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.Location = new System.Drawing.Point(400, 102);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(181, 44);
            this.btnExportar.TabIndex = 14;
            this.btnExportar.Text = "Exportar Para Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.Location = new System.Drawing.Point(609, 102);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(112, 44);
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // SUTIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistema_de_Peso.Properties.Resources.teste;
            this.ClientSize = new System.Drawing.Size(1026, 706);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblBruto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtBojo);
            this.Controls.Add(this.txtEmbalagem);
            this.Controls.Add(this.txtLiquido);
            this.Controls.Add(this.txtSku);
            this.Controls.Add(this.gridMedidas);
            this.Controls.Add(this.btnAnexar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SUTIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUTIÃ";
            ((System.ComponentModel.ISupportInitialize)(this.gridMedidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnexar;
        private System.Windows.Forms.DataGridView gridMedidas;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.TextBox txtLiquido;
        private System.Windows.Forms.TextBox txtEmbalagem;
        private System.Windows.Forms.TextBox txtBojo;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIQUIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMBALAGEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOJO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRUTO;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVoltar;
    }
}