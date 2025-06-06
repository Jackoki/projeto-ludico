namespace projeto_ludico.View.EscapeRoomsForms
{
    partial class EscapeRooms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscapeRooms));
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.boxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToOrderColumns = true;
            this.dataViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Location = new System.Drawing.Point(30, 90);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.Size = new System.Drawing.Size(725, 300);
            this.dataViewer.TabIndex = 0;
            this.dataViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewer_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar (Nome):";
            // 
            // boxSearch
            // 
            this.boxSearch.Location = new System.Drawing.Point(30, 50);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(413, 20);
            this.boxSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(449, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(530, 48);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Novo";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // EscapeRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.boxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EscapeRooms";
            this.Text = "Sistema - Lúdico UTFPR";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCreate;
    }
}