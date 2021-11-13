
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
			this.SuspendLayout();
			// 
			// titoloGioco
			// 
			this.titoloGioco.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.titoloGioco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.titoloGioco.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.titoloGioco.CausesValidation = false;
			this.titoloGioco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.titoloGioco.Cursor = System.Windows.Forms.Cursors.Default;
			this.titoloGioco.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titoloGioco.Location = new System.Drawing.Point(335, 64);
			this.titoloGioco.Name = "titoloGioco";
			this.titoloGioco.ReadOnly = true;
			this.titoloGioco.Size = new System.Drawing.Size(265, 76);
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
			this.bottoneGioca.Location = new System.Drawing.Point(369, 244);
			this.bottoneGioca.Name = "bottoneGioca";
			this.bottoneGioca.Size = new System.Drawing.Size(200, 80);
			this.bottoneGioca.TabIndex = 1;
			this.bottoneGioca.Text = "GIOCA";
			this.bottoneGioca.UseVisualStyleBackColor = true;
			this.bottoneGioca.Click += new System.EventHandler(this.bottoneGioca_Click);
			// 
			// FormGioco
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(932, 653);
			this.Controls.Add(this.bottoneGioca);
			this.Controls.Add(this.titoloGioco);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(950, 700);
			this.Name = "FormGioco";
			this.Text = "Dama";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox titoloGioco;
		private System.Windows.Forms.Button bottoneGioca;
	}
}

