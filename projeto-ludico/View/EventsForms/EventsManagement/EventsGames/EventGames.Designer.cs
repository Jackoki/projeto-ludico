namespace projeto_ludico.View.EventsForms.EventsManagement
{
    partial class EventGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventGames));
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxParticipant = new System.Windows.Forms.ComboBox();
            this.comboBoxBoardGame = new System.Windows.Forms.ComboBox();
            this.textBoxGame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.comboBoxLists = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToOrderColumns = true;
            this.dataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Location = new System.Drawing.Point(15, 311);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.Size = new System.Drawing.Size(528, 211);
            this.dataViewer.TabIndex = 1;
            this.dataViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewer_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quem Trouxe?";
            // 
            // comboBoxParticipant
            // 
            this.comboBoxParticipant.FormattingEnabled = true;
            this.comboBoxParticipant.Location = new System.Drawing.Point(15, 101);
            this.comboBoxParticipant.Name = "comboBoxParticipant";
            this.comboBoxParticipant.Size = new System.Drawing.Size(384, 21);
            this.comboBoxParticipant.TabIndex = 3;
            this.comboBoxParticipant.Click += new System.EventHandler(this.UpdateComboBoxParticipants);
            // 
            // comboBoxBoardGame
            // 
            this.comboBoxBoardGame.FormattingEnabled = true;
            this.comboBoxBoardGame.Location = new System.Drawing.Point(15, 51);
            this.comboBoxBoardGame.Name = "comboBoxBoardGame";
            this.comboBoxBoardGame.Size = new System.Drawing.Size(384, 21);
            this.comboBoxBoardGame.TabIndex = 4;
            // 
            // textBoxGame
            // 
            this.textBoxGame.Location = new System.Drawing.Point(15, 25);
            this.textBoxGame.Name = "textBoxGame";
            this.textBoxGame.Size = new System.Drawing.Size(384, 20);
            this.textBoxGame.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pesquisar jogo por Código ou Nome:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(405, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Detalhes:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(15, 150);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(384, 54);
            this.txtDescricao.TabIndex = 29;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(15, 219);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(154, 23);
            this.btnRegister.TabIndex = 30;
            this.btnRegister.Text = "Inserir Jogo";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // comboBoxLists
            // 
            this.comboBoxLists.FormattingEnabled = true;
            this.comboBoxLists.Location = new System.Drawing.Point(15, 282);
            this.comboBoxLists.Name = "comboBoxLists";
            this.comboBoxLists.Size = new System.Drawing.Size(384, 21);
            this.comboBoxLists.TabIndex = 31;
            this.comboBoxLists.Click += new System.EventHandler(this.UpdateComboBoxLists);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Inserir jogos da lista:";
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(405, 282);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(138, 23);
            this.btnList.TabIndex = 34;
            this.btnList.Text = "Inserir Lista";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // EventGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 555);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxLists);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGame);
            this.Controls.Add(this.comboBoxBoardGame);
            this.Controls.Add(this.comboBoxParticipant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventGames";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxParticipant;
        private System.Windows.Forms.ComboBox comboBoxBoardGame;
        private System.Windows.Forms.TextBox textBoxGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox comboBoxLists;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnList;
    }
}