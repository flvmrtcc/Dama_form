
namespace Dama_form
{
	partial class FormGioco
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGioco));
			this.titoloGioco = new System.Windows.Forms.TextBox();
			this.bottoneGioca = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tornaAlMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuovaPartitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kaurgamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.apriIlSitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelSchermataGioca = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.panelSchermataGioca.SuspendLayout();
			this.SuspendLayout();
			// 
			// titoloGioco
			// 
			this.titoloGioco.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.titoloGioco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(223)))), ((int)(((byte)(180)))));
			this.titoloGioco.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.titoloGioco.CausesValidation = false;
			this.titoloGioco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.titoloGioco.Cursor = System.Windows.Forms.Cursors.Default;
			this.titoloGioco.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titoloGioco.Location = new System.Drawing.Point(20, 63);
			this.titoloGioco.Name = "titoloGioco";
			this.titoloGioco.ReadOnly = true;
			this.titoloGioco.Size = new System.Drawing.Size(920, 76);
			this.titoloGioco.TabIndex = 0;
			this.titoloGioco.TabStop = false;
			this.titoloGioco.Text = "DAMA";
			this.titoloGioco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.titoloGioco.WordWrap = false;
			// 
			// bottoneGioca
			// 
			this.bottoneGioca.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.bottoneGioca.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bottoneGioca.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bottoneGioca.Location = new System.Drawing.Point(382, 256);
			this.bottoneGioca.Name = "bottoneGioca";
			this.bottoneGioca.Size = new System.Drawing.Size(200, 80);
			this.bottoneGioca.TabIndex = 1;
			this.bottoneGioca.Text = "GIOCA";
			this.bottoneGioca.UseVisualStyleBackColor = true;
			this.bottoneGioca.Click += new System.EventHandler(this.bottoneGioca_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.kaurgamesToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(962, 28);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tornaAlMenuToolStripMenuItem,
            this.nuovaPartitaToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
			this.fileToolStripMenuItem.Text = "Menu";
			// 
			// tornaAlMenuToolStripMenuItem
			// 
			this.tornaAlMenuToolStripMenuItem.Enabled = false;
			this.tornaAlMenuToolStripMenuItem.Name = "tornaAlMenuToolStripMenuItem";
			this.tornaAlMenuToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
			this.tornaAlMenuToolStripMenuItem.Text = "Torna al menu";
			this.tornaAlMenuToolStripMenuItem.Click += new System.EventHandler(this.tornaAlMenuToolStripMenuItem_Click);
			// 
			// nuovaPartitaToolStripMenuItem
			// 
			this.nuovaPartitaToolStripMenuItem.Name = "nuovaPartitaToolStripMenuItem";
			this.nuovaPartitaToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
			this.nuovaPartitaToolStripMenuItem.Text = "Nuova partita";
			this.nuovaPartitaToolStripMenuItem.Click += new System.EventHandler(this.nuovaPartitaToolStripMenuItem_Click);
			// 
			// kaurgamesToolStripMenuItem
			// 
			this.kaurgamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriIlSitoToolStripMenuItem});
			this.kaurgamesToolStripMenuItem.Name = "kaurgamesToolStripMenuItem";
			this.kaurgamesToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
			this.kaurgamesToolStripMenuItem.Text = "Kaurgames";
			// 
			// apriIlSitoToolStripMenuItem
			// 
			this.apriIlSitoToolStripMenuItem.Name = "apriIlSitoToolStripMenuItem";
			this.apriIlSitoToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
			this.apriIlSitoToolStripMenuItem.Text = "Apri il sito";
			this.apriIlSitoToolStripMenuItem.Click += new System.EventHandler(this.apriIlSitoToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 24);
			this.toolStripMenuItem1.Text = "?";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
			this.infoToolStripMenuItem.Text = "Informazioni su Dama";
			this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
			// 
			// panelSchermataGioca
			// 
			this.panelSchermataGioca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(223)))), ((int)(((byte)(180)))));
			this.panelSchermataGioca.Controls.Add(this.titoloGioco);
			this.panelSchermataGioca.Controls.Add(this.bottoneGioca);
			this.panelSchermataGioca.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSchermataGioca.Location = new System.Drawing.Point(0, 28);
			this.panelSchermataGioca.Name = "panelSchermataGioca";
			this.panelSchermataGioca.Size = new System.Drawing.Size(962, 625);
			this.panelSchermataGioca.TabIndex = 3;
			// 
			// FormGioco
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(213)))), ((int)(((byte)(170)))));
			this.ClientSize = new System.Drawing.Size(962, 653);
			this.Controls.Add(this.panelSchermataGioca);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(980, 700);
			this.Name = "FormGioco";
			this.Text = "Dama";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGioco_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelSchermataGioca.ResumeLayout(false);
			this.panelSchermataGioca.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox titoloGioco;
		private System.Windows.Forms.Button bottoneGioca;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tornaAlMenuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuovaPartitaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kaurgamesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem apriIlSitoToolStripMenuItem;
		private System.Windows.Forms.Panel panelSchermataGioca;
	}
}

