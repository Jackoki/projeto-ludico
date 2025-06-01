namespace projeto_ludico.View.BoardGamesForms
{
    partial class BoardGamesEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardGamesEdit));
            this.btnRemoveBarCode = new System.Windows.Forms.Button();
            this.btnRemoveName = new System.Windows.Forms.Button();
            this.btnAddNome = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNomeAlternativo = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAddBarCode = new System.Windows.Forms.Button();
            this.lbCodigosBarras = new System.Windows.Forms.ListBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbAlternateNames = new System.Windows.Forms.ListBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtQtdMin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQtdMax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtTempoJogo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveBarCode
            // 
            this.btnRemoveBarCode.Location = new System.Drawing.Point(580, 217);
            this.btnRemoveBarCode.Name = "btnRemoveBarCode";
            this.btnRemoveBarCode.Size = new System.Drawing.Size(40, 23);
            this.btnRemoveBarCode.TabIndex = 73;
            this.btnRemoveBarCode.Text = "-";
            this.btnRemoveBarCode.UseVisualStyleBackColor = true;
            this.btnRemoveBarCode.Click += new System.EventHandler(this.btnRemoveBarCode_Click);
            // 
            // btnRemoveName
            // 
            this.btnRemoveName.Location = new System.Drawing.Point(287, 104);
            this.btnRemoveName.Name = "btnRemoveName";
            this.btnRemoveName.Size = new System.Drawing.Size(40, 23);
            this.btnRemoveName.TabIndex = 72;
            this.btnRemoveName.Text = "-";
            this.btnRemoveName.UseVisualStyleBackColor = true;
            this.btnRemoveName.Click += new System.EventHandler(this.btnRemoveName_Click);
            // 
            // btnAddNome
            // 
            this.btnAddNome.Location = new System.Drawing.Point(241, 104);
            this.btnAddNome.Name = "btnAddNome";
            this.btnAddNome.Size = new System.Drawing.Size(40, 23);
            this.btnAddNome.TabIndex = 71;
            this.btnAddNome.Text = "+";
            this.btnAddNome.UseVisualStyleBackColor = true;
            this.btnAddNome.Click += new System.EventHandler(this.btnAddNome_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.Location = new System.Drawing.Point(510, 444);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNomeAlternativo
            // 
            this.txtNomeAlternativo.Location = new System.Drawing.Point(21, 106);
            this.txtNomeAlternativo.Name = "txtNomeAlternativo";
            this.txtNomeAlternativo.Size = new System.Drawing.Size(214, 20);
            this.txtNomeAlternativo.TabIndex = 70;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(421, 444);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 51;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAddBarCode
            // 
            this.btnAddBarCode.Location = new System.Drawing.Point(537, 217);
            this.btnAddBarCode.Name = "btnAddBarCode";
            this.btnAddBarCode.Size = new System.Drawing.Size(40, 23);
            this.btnAddBarCode.TabIndex = 69;
            this.btnAddBarCode.Text = "+";
            this.btnAddBarCode.UseVisualStyleBackColor = true;
            this.btnAddBarCode.Click += new System.EventHandler(this.btnAddBarCode_Click);
            // 
            // lbCodigosBarras
            // 
            this.lbCodigosBarras.FormattingEnabled = true;
            this.lbCodigosBarras.Location = new System.Drawing.Point(336, 246);
            this.lbCodigosBarras.Name = "lbCodigosBarras";
            this.lbCodigosBarras.Size = new System.Drawing.Size(284, 173);
            this.lbCodigosBarras.TabIndex = 68;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(336, 219);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(195, 20);
            this.txtCodigoBarras.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Códigos de Barras";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Nome";
            // 
            // lbAlternateNames
            // 
            this.lbAlternateNames.FormattingEnabled = true;
            this.lbAlternateNames.Location = new System.Drawing.Point(21, 132);
            this.lbAlternateNames.Name = "lbAlternateNames";
            this.lbAlternateNames.Size = new System.Drawing.Size(306, 69);
            this.lbAlternateNames.TabIndex = 65;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(21, 63);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(306, 20);
            this.txtNome.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Nomes Alternativos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(333, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Qtd. Mín. de jogadores";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(21, 229);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(306, 197);
            this.txtDescricao.TabIndex = 54;
            // 
            // txtQtdMin
            // 
            this.txtQtdMin.Location = new System.Drawing.Point(336, 180);
            this.txtQtdMin.Name = "txtQtdMin";
            this.txtQtdMin.Size = new System.Drawing.Size(284, 20);
            this.txtQtdMin.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Descrição";
            // 
            // txtQtdMax
            // 
            this.txtQtdMax.Location = new System.Drawing.Point(336, 141);
            this.txtQtdMax.Name = "txtQtdMax";
            this.txtQtdMax.Size = new System.Drawing.Size(284, 20);
            this.txtQtdMax.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(333, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Ano de publicação";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(333, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Qtd. Máx. de jogadores";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(336, 63);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(284, 20);
            this.txtAno.TabIndex = 57;
            // 
            // txtTempoJogo
            // 
            this.txtTempoJogo.Location = new System.Drawing.Point(336, 102);
            this.txtTempoJogo.Name = "txtTempoJogo";
            this.txtTempoJogo.Size = new System.Drawing.Size(284, 20);
            this.txtTempoJogo.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(333, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Tempo de jogo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Informações";
            // 
            // BoardGamesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 515);
            this.Controls.Add(this.btnRemoveBarCode);
            this.Controls.Add(this.btnRemoveName);
            this.Controls.Add(this.btnAddNome);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNomeAlternativo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAddBarCode);
            this.Controls.Add(this.lbCodigosBarras);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbAlternateNames);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtQtdMin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtQtdMax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtTempoJogo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoardGamesEdit";
            this.Text = "Sistema - Lúdico UTFPR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveBarCode;
        private System.Windows.Forms.Button btnRemoveName;
        private System.Windows.Forms.Button btnAddNome;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNomeAlternativo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAddBarCode;
        private System.Windows.Forms.ListBox lbCodigosBarras;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbAlternateNames;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtQtdMin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtQtdMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtTempoJogo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
    }
}