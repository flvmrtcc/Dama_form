using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dama_form
{
	public partial class FormGioco : Form
	{
		Panel panelTabella;
		PanelCella[,] elencoCelle = new PanelCella[K.NUMEROCELLELATO, K.NUMEROCELLELATO];
		GiocoDama giocoDama;
		public FormGioco()
		{
			InitializeComponent();
			giocoDama = new GiocoDama();
		}
		private void bottoneGioca_Click(object sender, EventArgs e)
		{
			bottoneGioca.Visible = false;
			titoloGioco.Visible = false;
			panelTabella = new Panel();         // crea il panel che contiene la tabella di gioco
			creaTabellaGioco();
			this.panelTabella.Controls.Clear();
			creaCelleGioco();
			inserisciPedine();
		}

		private void creaTabellaGioco()
		{
			panelTabella.Name = "panelTabella";
			panelTabella.BackColor = Color.Gray;
			panelTabella.Location = new System.Drawing.Point(10, 10);
			panelTabella.Size = new System.Drawing.Size(565, 425);
			panelTabella.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.Controls.Add(panelTabella);
		}
		private void creaCelleGioco()
		{
			//elencoCelle = new PanelCella[8, 8];
			int px = 10;
			int py = 10;
			bool coloreCella = false;
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				px = 10;
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					elencoCelle[r, c] = new PanelCella();
					elencoCelle[r, c].Name = "panel" + r + "-" + c;
					elencoCelle[r, c].x = c;
					elencoCelle[r, c].y = r;
					if (coloreCella)
					{
						elencoCelle[r, c].BackColor = Color.FromArgb(205, 203, 160);
					}
					else
					{
						elencoCelle[r, c].BackColor = Color.FromArgb(152, 118, 84);
					}
					coloreCella = !coloreCella;
					elencoCelle[r, c].Location = new System.Drawing.Point(px, py);
					elencoCelle[r, c].Size = new System.Drawing.Size(K.DIMENSIONECELLA, K.DIMENSIONECELLA);

					this.panelTabella.Controls.Add(elencoCelle[r, c]);
					px += K.DIMENSIONECELLA;
				}
				py += K.DIMENSIONECELLA;
				coloreCella = !coloreCella;
			}
		}

		private void inserisciPedine()
		{
			PictureBox imgBoxTest;
			int[,] matricePedine = giocoDama.getMatricePedine();
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					if (matricePedine[r, c] == 1)
					{
						imgBoxTest = new PictureBox();
						imgBoxTest.Image = Image.FromFile("pedinaDama1.png");
						imgBoxTest.SizeMode = PictureBoxSizeMode.StretchImage;
						imgBoxTest.ClientSize = new Size(K.DIMENSIONECELLA, K.DIMENSIONECELLA);
						this.elencoCelle[r, c].Controls.Add(imgBoxTest);
					}
					else if (matricePedine[r, c] == 2)
					{
						imgBoxTest = new PictureBox();
						imgBoxTest.Image = Image.FromFile("pedinaDama2.png");
						imgBoxTest.SizeMode = PictureBoxSizeMode.StretchImage;
						imgBoxTest.ClientSize = new Size(K.DIMENSIONECELLA, K.DIMENSIONECELLA);
						this.elencoCelle[r, c].Controls.Add(imgBoxTest);
					}
				}
			}


		}



		private class PanelCella : Panel
		{
			public int x;
			public int y;
		}
	}


}
