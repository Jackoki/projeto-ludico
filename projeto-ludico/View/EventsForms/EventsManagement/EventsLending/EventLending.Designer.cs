namespace projeto_ludico.View.EventsForms.EventsManagement
{
    partial class EventLending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLending));
            this.textBoxSearchGame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchGame = new System.Windows.Forms.Button();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchParticipant = new System.Windows.Forms.TextBox();
            this.btnSearchParticipant = new System.Windows.Forms.Button();
            this.comboBoxParticipant = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSearchGame
            // 
            this.textBoxSearchGame.Location = new System.Drawing.Point(12, 33);
            this.textBoxSearchGame.Name = "textBoxSearchGame";
            this.textBoxSearchGame.Size = new System.Drawing.Size(444, 20);
            this.textBoxSearchGame.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pesquisar jogo por Código ou Nome:";
            // 
            // btnSearchGame
            // 
            this.btnSearchGame.Location = new System.Drawing.Point(465, 33);
            this.btnSearchGame.Name = "btnSearchGame";
            this.btnSearchGame.Size = new System.Drawing.Size(197, 20);
            this.btnSearchGame.TabIndex = 8;
            this.btnSearchGame.Text = "Pesquisar";
            this.btnSearchGame.UseVisualStyleBackColor = true;
            this.btnSearchGame.Click += new System.EventHandler(this.btnSearchGame_Click);
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(12, 92);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(444, 21);
            this.comboBoxGame.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Participante do Empréstimo (Nome, Código ou CPF):";
            // 
            // textBoxSearchParticipant
            // 
            this.textBoxSearchParticipant.Location = new System.Drawing.Point(15, 175);
            this.textBoxSearchParticipant.Name = "textBoxSearchParticipant";
            this.textBoxSearchParticipant.Size = new System.Drawing.Size(444, 20);
            this.textBoxSearchParticipant.TabIndex = 11;
            // 
            // btnSearchParticipant
            // 
            this.btnSearchParticipant.Location = new System.Drawing.Point(465, 175);
            this.btnSearchParticipant.Name = "btnSearchParticipant";
            this.btnSearchParticipant.Size = new System.Drawing.Size(197, 21);
            this.btnSearchParticipant.TabIndex = 12;
            this.btnSearchParticipant.Text = "Pesquisar";
            this.btnSearchParticipant.UseVisualStyleBackColor = true;
            this.btnSearchParticipant.Click += new System.EventHandler(this.btnSearchParticipant_Click);
            // 
            // comboBoxParticipant
            // 
            this.comboBoxParticipant.FormattingEnabled = true;
            this.comboBoxParticipant.Location = new System.Drawing.Point(15, 235);
            this.comboBoxParticipant.Name = "comboBoxParticipant";
            this.comboBoxParticipant.Size = new System.Drawing.Size(444, 21);
            this.comboBoxParticipant.TabIndex = 13;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(15, 316);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(656, 32);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Emprestar";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // EventLending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 373);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.comboBoxParticipant);
            this.Controls.Add(this.btnSearchParticipant);
            this.Controls.Add(this.textBoxSearchParticipant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGame);
            this.Controls.Add(this.btnSearchGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSearchGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventLending";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchGame;
        private System.Windows.Forms.ComboBox comboBoxGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchParticipant;
        private System.Windows.Forms.Button btnSearchParticipant;
        private System.Windows.Forms.ComboBox comboBoxParticipant;
        private System.Windows.Forms.Button btnRegister;
    }
}