namespace projeto_ludico.View.EscapeRoomsForms
{
    partial class EscapeRoomsCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscapeRoomsCreate));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxInstitution = new System.Windows.Forms.ComboBox();
            this.btnInstitution = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 64);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(341, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Informações";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(15, 123);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(341, 20);
            this.textBoxDescription.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Evento";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 19;
            // 
            // comboBoxInstitution
            // 
            this.comboBoxInstitution.Location = new System.Drawing.Point(0, 0);
            this.comboBoxInstitution.Name = "comboBoxInstitution";
            this.comboBoxInstitution.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstitution.TabIndex = 0;
            // 
            // btnInstitution
            // 
            this.btnInstitution.Location = new System.Drawing.Point(0, 0);
            this.btnInstitution.Name = "btnInstitution";
            this.btnInstitution.Size = new System.Drawing.Size(75, 23);
            this.btnInstitution.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(190, 320);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Salvar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(281, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxEvents
            // 
            this.comboBoxEvents.FormattingEnabled = true;
            this.comboBoxEvents.Location = new System.Drawing.Point(15, 186);
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEvents.TabIndex = 20;
            // 
            // EscapeRoomsCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.comboBoxEvents);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EscapeRoomsCreate";
            this.Text = "Sistema - Lúdico UTFPR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxInstitution;
        private System.Windows.Forms.Button btnInstitution;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBoxEvents;
    }
}