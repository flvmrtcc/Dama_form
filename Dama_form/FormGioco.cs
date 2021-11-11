﻿// Martucci Flavio - 5INF3

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
		PictureBoxPedina[,] imgBoxPedine = new PictureBoxPedina[K.NUMEROCELLELATO, K.NUMEROCELLELATO];
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
						elencoCelle[r, c].BackColor = K.COLORE_CASELLE_BIANCHE;
					}
					else
					{
						elencoCelle[r, c].BackColor = K.COLORE_CASELLE_NERE;
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
			int[,] matricePedine = giocoDama.getMatricePedine();
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.PEDINA_NERA)
					{
						imgBoxPedine[r, c] = new PictureBoxPedina();
						if (matricePedine[r, c] == K.PEDINA_BIANCA)
						{
							imgBoxPedine[r, c].Image = Image.FromFile("pedinaDama1.png");
						}
						else
						{
							imgBoxPedine[r, c].Image = Image.FromFile("pedinaDama2.png");
						}
						imgBoxPedine[r, c].SizeMode = PictureBoxSizeMode.StretchImage;
						imgBoxPedine[r, c].ClientSize = new Size(K.DIMENSIONECELLA, K.DIMENSIONECELLA);
						imgBoxPedine[r, c].Click += new System.EventHandler(this.mostraPossibiliMosse_Click);
						imgBoxPedine[r, c].r = r; 
						imgBoxPedine[r, c].c = c; 
						this.elencoCelle[r, c].Controls.Add(imgBoxPedine[r, c]);
					}
				}
			}
		}
		private void mostraPossibiliMosse_Click(object sender, EventArgs e)
		{
			rimuoviPrecedentiEvidenziati();
			((PictureBoxPedina)sender).BackColor = K.COLORE_CASELLA_SELEZIONATA;
			int r = ((PictureBoxPedina)sender).r;
			int c = ((PictureBoxPedina)sender).c;
			evidenziaPossibiliMosse(giocoDama.getMatriceCelleDaEvidenziare(r, c));
		}

		private void evidenziaPossibiliMosse(bool[,] matriceDaEvidenziare)
		{
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					if (matriceDaEvidenziare[r, c]) elencoCelle[r, c].BackColor = K.COLORE_CASELLA_MOSSA_POSSIBILE;
				}
			}
		}

		private void rimuoviPrecedentiEvidenziati()
		{
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					if (imgBoxPedine[r, c] != null) imgBoxPedine[r, c].BackColor = K.COLORE_CASELLE_NERE;
					if (elencoCelle[r, c].BackColor == K.COLORE_CASELLA_MOSSA_POSSIBILE) elencoCelle[r, c].BackColor = K.COLORE_CASELLE_NERE;
				}
			}
		}

		private class PictureBoxPedina : PictureBox
		{
			public int r;
			public int c;
		}
		private class PanelCella : Panel
		{
			public int y;
			public int x;
		}
	}


}
