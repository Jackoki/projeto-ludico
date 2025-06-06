namespace projeto_ludico
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eventsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.participantsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.participantsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.institutionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeJogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rpgMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escapeRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventsMenuItem,
            this.participantsMenu,
            this.gamesMenuItem,
            this.rpgMenuItem,
            this.escapeRoomsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eventsMenuItem
            // 
            this.eventsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventosToolStripMenuItem,
            this.locaisToolStripMenuItem});
            this.eventsMenuItem.Name = "eventsMenuItem";
            this.eventsMenuItem.Size = new System.Drawing.Size(60, 20);
            this.eventsMenuItem.Text = "Eventos";
            // 
            // eventosToolStripMenuItem
            // 
            this.eventosToolStripMenuItem.Name = "eventosToolStripMenuItem";
            this.eventosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eventosToolStripMenuItem.Text = "Eventos";
            // 
            // locaisToolStripMenuItem
            // 
            this.locaisToolStripMenuItem.Name = "locaisToolStripMenuItem";
            this.locaisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.locaisToolStripMenuItem.Text = "Locais";
            this.locaisToolStripMenuItem.Click += new System.EventHandler(this.locaisToolStripMenuItem_Click);
            // 
            // participantsMenu
            // 
            this.participantsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.participantsMenuItem,
            this.institutionsMenuItem});
            this.participantsMenu.Name = "participantsMenu";
            this.participantsMenu.Size = new System.Drawing.Size(87, 20);
            this.participantsMenu.Text = "Participantes";
            // 
            // participantsMenuItem
            // 
            this.participantsMenuItem.Name = "participantsMenuItem";
            this.participantsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.participantsMenuItem.Text = "Participantes";
            this.participantsMenuItem.Click += new System.EventHandler(this.participantsMenuItem_Click);
            // 
            // institutionsMenuItem
            // 
            this.institutionsMenuItem.Name = "institutionsMenuItem";
            this.institutionsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.institutionsMenuItem.Text = "Instituições";
            this.institutionsMenuItem.Click += new System.EventHandler(this.institutionsMenuItem_Click);
            // 
            // gamesMenuItem
            // 
            this.gamesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogosToolStripMenuItem,
            this.listaDeJogosToolStripMenuItem});
            this.gamesMenuItem.Name = "gamesMenuItem";
            this.gamesMenuItem.Size = new System.Drawing.Size(49, 20);
            this.gamesMenuItem.Text = "Jogos";
            this.gamesMenuItem.Click += new System.EventHandler(this.gamesMenuItem_Click);
            // 
            // jogosToolStripMenuItem
            // 
            this.jogosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.jogosToolStripMenuItem.Name = "jogosToolStripMenuItem";
            this.jogosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jogosToolStripMenuItem.Text = "Jogos";
            this.jogosToolStripMenuItem.Click += new System.EventHandler(this.jogosToolStripMenuItem_Click);
            // 
            // listaDeJogosToolStripMenuItem
            // 
            this.listaDeJogosToolStripMenuItem.Name = "listaDeJogosToolStripMenuItem";
            this.listaDeJogosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaDeJogosToolStripMenuItem.Text = "Lista de Jogos";
            this.listaDeJogosToolStripMenuItem.Click += new System.EventHandler(this.listaDeJogosToolStripMenuItem_Click);
            // 
            // rpgMenuItem
            // 
            this.rpgMenuItem.Name = "rpgMenuItem";
            this.rpgMenuItem.Size = new System.Drawing.Size(41, 20);
            this.rpgMenuItem.Text = "RPG";
            // 
            // escapeRoomsToolStripMenuItem
            // 
            this.escapeRoomsToolStripMenuItem.Name = "escapeRoomsToolStripMenuItem";
            this.escapeRoomsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.escapeRoomsToolStripMenuItem.Text = "Escape Rooms";
            // 
            // Home
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Sistema - Lúdico UTFPR";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eventsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem participantsMenu;
        private System.Windows.Forms.ToolStripMenuItem participantsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem institutionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rpgMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeJogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escapeRoomsToolStripMenuItem;
    }
}