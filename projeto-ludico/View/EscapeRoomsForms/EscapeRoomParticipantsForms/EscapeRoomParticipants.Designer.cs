﻿namespace projeto_ludico.View.EscapeRoomsForms
{
    partial class EscapeRoomsParticipants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscapeRoomsParticipants));
            this.dataViewerList = new System.Windows.Forms.DataGridView();
            this.dataViewerParticipants = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewerList
            // 
            this.dataViewerList.AllowUserToAddRows = false;
            this.dataViewerList.AllowUserToDeleteRows = false;
            this.dataViewerList.AllowUserToOrderColumns = true;
            this.dataViewerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewerList.Location = new System.Drawing.Point(10, 384);
            this.dataViewerList.Name = "dataViewerList";
            this.dataViewerList.ReadOnly = true;
            this.dataViewerList.Size = new System.Drawing.Size(689, 176);
            this.dataViewerList.TabIndex = 5;
            this.dataViewerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewerList_CellContentClick);
            // 
            // dataViewerParticipants
            // 
            this.dataViewerParticipants.AllowUserToAddRows = false;
            this.dataViewerParticipants.AllowUserToDeleteRows = false;
            this.dataViewerParticipants.AllowUserToOrderColumns = true;
            this.dataViewerParticipants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewerParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewerParticipants.Location = new System.Drawing.Point(10, 72);
            this.dataViewerParticipants.Name = "dataViewerParticipants";
            this.dataViewerParticipants.ReadOnly = true;
            this.dataViewerParticipants.Size = new System.Drawing.Size(689, 232);
            this.dataViewerParticipants.TabIndex = 6;
            this.dataViewerParticipants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewerGames_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Participantes do Escape Room:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Participantes Disponíveis para Adicionar:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(428, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(271, 20);
            this.txtSearch.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pesquisar";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(624, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EscapeRoomsParticipants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 628);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataViewerParticipants);
            this.Controls.Add(this.dataViewerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EscapeRoomsParticipants";
            this.Text = "Sistema - Lúdico UTFPR";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataViewerList;
        private System.Windows.Forms.DataGridView dataViewerParticipants;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
    }
}