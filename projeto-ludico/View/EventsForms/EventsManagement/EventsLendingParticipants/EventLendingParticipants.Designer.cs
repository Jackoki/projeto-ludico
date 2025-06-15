namespace projeto_ludico.View.EventsForms.EventsManagement
{
    partial class EventLendingParticipants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLendingParticipants));
            this.checkBoxGames = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxGames
            // 
            this.checkBoxGames.AutoSize = true;
            this.checkBoxGames.Location = new System.Drawing.Point(12, 32);
            this.checkBoxGames.Name = "checkBoxGames";
            this.checkBoxGames.Size = new System.Drawing.Size(143, 17);
            this.checkBoxGames.TabIndex = 0;
            this.checkBoxGames.Text = "Mostrar jogos devolvidos";
            this.checkBoxGames.UseVisualStyleBackColor = true;
            this.checkBoxGames.CheckedChanged += new System.EventHandler(this.checkBoxGames_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade de Jogos Emprestados:";
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToOrderColumns = true;
            this.dataViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Location = new System.Drawing.Point(12, 67);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.Size = new System.Drawing.Size(632, 339);
            this.dataViewer.TabIndex = 2;
            this.dataViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewer_CellContentClick);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(610, 36);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 13);
            this.labelCount.TabIndex = 3;
            // 
            // EventLendingParticipants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 428);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.dataViewer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxGames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventLendingParticipants";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataViewer;
        private System.Windows.Forms.Label labelCount;
    }
}