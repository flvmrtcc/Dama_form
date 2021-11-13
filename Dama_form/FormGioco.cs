// Martucci Flavio - 5INF3

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

		Panel panelInfoPartita;
		TextBox textBoxTurnoGiocatore;

		PanelCella[,] elencoCelle = new PanelCella[K.NUMERO_CELLE_LATO, K.NUMERO_CELLE_LATO];
		PictureBoxPedina[,] imgBoxPedine = new PictureBoxPedina[2, K.NUMERO_PEDINE_UTENTE];
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
			creaTabellaGioco();
			//this.panelTabella.Controls.Clear();
			creaCelleGioco();
			creaPedine();
			inserisciPedine();
			creaPanelInfoPartita();
			creaBoxTurnoCorrente();
			mostraTurnoCorrente();
		}
		private void creaTabellaGioco()
		{
			panelTabella = new Panel();         // crea il panel che contiene la tabella di gioco
			panelTabella.Name = "panelTabella";
			panelTabella.BackColor = Color.Gray;
			panelTabella.Location = new System.Drawing.Point(5, 5);
			panelTabella.Size = new System.Drawing.Size(504, 504);
			panelTabella.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			//panelTabella.Dock = DockStyle.Fill;
			this.Controls.Add(panelTabella);
		}
		private void creaPanelInfoPartita()
		{
			panelInfoPartita = new Panel();
			panelInfoPartita.Name = "panelInfoParita";
			panelInfoPartita.BackColor = Color.LightGray;
			panelInfoPartita.Location = new System.Drawing.Point(515, 5);
			panelInfoPartita.Size = new System.Drawing.Size(170, 504);
			panelInfoPartita.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;
			this.Controls.Add(panelInfoPartita);
		}
		private void creaCelleGioco()
		{
			int px = 10;
			int py = 10;
			bool coloreCella = false;
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				px = 10;
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
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
					elencoCelle[r, c].Size = new System.Drawing.Size(K.DIMENSIONE_CELLA, K.DIMENSIONE_CELLA);
					elencoCelle[r, c].Anchor = AnchorStyles.Top;
					this.panelTabella.Controls.Add(elencoCelle[r, c]);
					px += K.DIMENSIONE_CELLA;
				}
				py += K.DIMENSIONE_CELLA;
				coloreCella = !coloreCella;
			}
		}
		private void creaPedine()
		{
			for (int t = 0; t < 2; t++)
			{
				for (int c = 0; c < K.NUMERO_PEDINE_UTENTE; c++)
				{
					imgBoxPedine[t, c] = new PictureBoxPedina();
					if (t == 0)
					{
						imgBoxPedine[t, c].Image = Image.FromFile("pedinaDama1.png");
						imgBoxPedine[t, c].tipoPedina = K.PEDINA_BIANCA;
					}
					else
					{
						imgBoxPedine[t, c].Image = Image.FromFile("pedinaDama2.png");
						imgBoxPedine[t, c].tipoPedina = K.PEDINA_NERA;
					}
					imgBoxPedine[t, c].SizeMode = PictureBoxSizeMode.StretchImage;
					imgBoxPedine[t, c].ClientSize = new Size(K.DIMENSIONE_CELLA, K.DIMENSIONE_CELLA);
					imgBoxPedine[t, c].Click += new System.EventHandler(this.mostraPossibiliMosse_Click);
				}
			}
		}
		private void inserisciPedine()
		{
			int t = 0;
			int[] numPedineInserite = new int[] { 0, 0 };
			int[,] matricePedine = giocoDama.getMatricePedine();
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.PEDINA_NERA)
					{
						if (matricePedine[r, c] == K.PEDINA_BIANCA) t = 0;
						else if (matricePedine[r, c] == K.PEDINA_NERA) t = 1;
						imgBoxPedine[t, numPedineInserite[t]].r = r;
						imgBoxPedine[t, numPedineInserite[t]].c = c;
						this.elencoCelle[r, c].Controls.Add(imgBoxPedine[t, numPedineInserite[t]]);
						numPedineInserite[t]++;
					}
				}
			}
		}
		private void mostraPossibiliMosse_Click(object sender, EventArgs e)
		{
			rimuoviPrecedentiEvidenziati();
			if (((PictureBoxPedina)sender).tipoPedina == giocoDama.getGiocatoreCorrente())
			{
				((PictureBoxPedina)sender).BackColor = K.COLORE_CASELLA_SELEZIONATA;
				int r = ((PictureBoxPedina)sender).r;
				int c = ((PictureBoxPedina)sender).c;
				evidenziaPossibiliMosse(giocoDama.getMatriceCelleDaEvidenziare(r, c));
			}
		}

		private void evidenziaPossibiliMosse(bool[,] matriceDaEvidenziare)
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matriceDaEvidenziare[r, c])
					{
						elencoCelle[r, c].BackColor = K.COLORE_CASELLA_MOSSA_POSSIBILE;
						elencoCelle[r, c].Click += new System.EventHandler(this.eseguiMossaScelta);
					}
				}
			}
		}

		private void eseguiMossaScelta(object sender, EventArgs e)
		{
			giocoDama.eseguiMossa(((PanelCella)sender).y, (((PanelCella)sender).x));
			aggiornaPedine();
			mostraTurnoCorrente();
		}

		private void creaBoxTurnoCorrente()
		{
			textBoxTurnoGiocatore = new TextBox();
			textBoxTurnoGiocatore.Name = "textInfo";
			textBoxTurnoGiocatore.Dock = DockStyle.Top;
			//textBoxTurnoGiocatore.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBoxTurnoGiocatore.BorderStyle = BorderStyle.FixedSingle;
			textBoxTurnoGiocatore.ReadOnly = true;
			textBoxTurnoGiocatore.Multiline = true;
			textBoxTurnoGiocatore.WordWrap = true;
			textBoxTurnoGiocatore.Height = 55;
			textBoxTurnoGiocatore.TextAlign = HorizontalAlignment.Center;
			textBoxTurnoGiocatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
			panelInfoPartita.Controls.Add(textBoxTurnoGiocatore);
		}
		private void mostraTurnoCorrente()
		{
			textBoxTurnoGiocatore.Text = "Turno del giocatore " + giocoDama.getGiocatoreCorrente();
		}

		private void aggiornaPedine()
		{
			cancellaPedine();
			rimuoviPrecedentiEvidenziati();
			inserisciPedine();
		}
		private void cancellaPedine()
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					elencoCelle[r, c].Controls.Clear();
				}
			}
		}

		private void rimuoviPrecedentiEvidenziati()
		{
			for (int t = 0; t < 2; t++)
			{
				for (int c = 0; c < K.NUMERO_PEDINE_UTENTE; c++)
				{
					if (imgBoxPedine[t, c] != null) imgBoxPedine[t, c].BackColor = K.COLORE_CASELLE_NERE;
				}
			}
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (elencoCelle[r, c].BackColor == K.COLORE_CASELLA_MOSSA_POSSIBILE) elencoCelle[r, c].BackColor = K.COLORE_CASELLE_NERE;
					elencoCelle[r, c].Click -= new System.EventHandler(this.eseguiMossaScelta);
				}
			}
		}

		private class PictureBoxPedina : PictureBox
		{
			public int r;
			public int c;
			public int tipoPedina;
		}
		private class PanelCella : Panel
		{
			public int y;
			public int x;
		}
	}


}
