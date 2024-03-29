﻿// Martucci Flavio - 5INF3
/*
 * 
 * Programma gioco dama in C# con l'utilizzo delle form.
 * Modalità di gioco:
 *		- Modalità di base multiplayer.
 *		- Modalità singleplayer (il computer sceglie una pedina in modo random e, 
 *			successivamente sceglie randomicamente una mossa tra le possibili della 
 *			pedina scelta in precedenza).
 *			La classe Computer si occupa di scegliere la mossa del pc.
 * Presente obbligo di mangiare (se è possibile mangiare una o più pedine è obbligatorio scegliere una tra quelle mosse).
 * Presente conteggio del tempo.
 * La classe GiocoDama gestisce il gioco scambiandosi informazioni con la classe FormGioco (parte grafica).
 * Presente barra in alto con il menu per tornare alla schermata principale o iniziare una nuova partita, 
 *		chiedendo conferma con le finestre di dialogo se è già in corso un'altra partita.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dama_form
{
	public partial class FormGioco : Form
	{
		Panel panelTabella;

		Panel panelInfoPartita;
		Panel panelTurnoPartita;
		TextBox textBoxTurnoGiocatore;
		TextBox textBoxTempoTrascorso;
		PictureBox boxPedinaTurnoGiocatore;

		Panel panelSceltaModalita;

		PanelCella[,] elencoCelle = new PanelCella[K.NUMERO_CELLE_LATO, K.NUMERO_CELLE_LATO];
		PictureBoxPedina[,] imgBoxPedine = new PictureBoxPedina[K.NUM_GIOCATORI, K.NUMERO_PEDINE_UTENTE];
		GiocoDama giocoDama;

		Computer computer;

		public FormGioco()
		{
			InitializeComponent();
			giocoDama = new GiocoDama();
		}
		private void bottoneGioca_Click(object sender, EventArgs e)
		{
			panelSchermataGioca.Visible = false;
			if (panelSceltaModalita == null) creaMenuSceltaModalita();
			panelSceltaModalita.Visible = true;
			tornaAlMenuToolStripMenuItem.Enabled = true;
		}
		public void ThreadMostraTempo()
		{
			while (giocoDama.getGiocoInCorso())
			{
				mostraTempoTrascorso();
				Thread.Sleep(1000);
			}
		}
		private void creaMenuSceltaModalita()
		{
			panelSceltaModalita = new Panel();
			panelSceltaModalita.Name = "panelSceltaModalita";
			panelSceltaModalita.BackColor = K.COLORE_PANEL_TABELLA;
			panelSceltaModalita.Dock = DockStyle.Fill;
			this.Controls.Add(panelSceltaModalita);

			TextBox textBox = new TextBox();
			textBox.Name = "textScegliModalita";
			textBox.BorderStyle = BorderStyle.None;
			textBox.BackColor = K.COLORE_PANEL_TABELLA;
			textBox.ReadOnly = true;
			textBox.Location = new System.Drawing.Point(0, 93);
			textBox.Size = new System.Drawing.Size(panelSceltaModalita.Width, 76);
			textBox.TextAlign = HorizontalAlignment.Center;
			textBox.Anchor = AnchorStyles.Top;
			textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
			textBox.Text = "Scegli la modalità";
			panelSceltaModalita.Controls.Add(textBox);

			Button bottoneModalitaSingoloGiocatore = new Button();
			bottoneModalitaSingoloGiocatore.Cursor = System.Windows.Forms.Cursors.Hand;
			bottoneModalitaSingoloGiocatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			bottoneModalitaSingoloGiocatore.Location = new System.Drawing.Point(240, 179);
			bottoneModalitaSingoloGiocatore.Name = "bottoneSingoloGiocatore";
			bottoneModalitaSingoloGiocatore.Size = new System.Drawing.Size(250, 80);
			bottoneModalitaSingoloGiocatore.Text = "Giocatore singolo";
			bottoneModalitaSingoloGiocatore.Anchor = AnchorStyles.Top;
			bottoneModalitaSingoloGiocatore.UseVisualStyleBackColor = true;
			bottoneModalitaSingoloGiocatore.Click += new System.EventHandler(this.bottoneSinglePlayer_Click);
			panelSceltaModalita.Controls.Add(bottoneModalitaSingoloGiocatore);

			Button bottoneModalitaMultigiocatore = new Button();
			bottoneModalitaMultigiocatore.Cursor = System.Windows.Forms.Cursors.Hand;
			bottoneModalitaMultigiocatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			bottoneModalitaMultigiocatore.Location = new System.Drawing.Point(240, 279);
			bottoneModalitaMultigiocatore.Name = "bottoneMultiGiocatore";
			bottoneModalitaMultigiocatore.Size = new System.Drawing.Size(250, 80);
			bottoneModalitaMultigiocatore.Text = "Multigiocatore";
			bottoneModalitaMultigiocatore.Anchor = AnchorStyles.Top;
			bottoneModalitaMultigiocatore.UseVisualStyleBackColor = true;
			bottoneModalitaMultigiocatore.Click += new System.EventHandler(this.bottoneMultiPlayer_Click);
			panelSceltaModalita.Controls.Add(bottoneModalitaMultigiocatore);
		}
		private void bottoneSinglePlayer_Click(object sender, EventArgs e)
		{
			computer = new Computer(giocoDama);
			panelSceltaModalita.Visible = false;
			giocoDama.iniziaPartita();
			creaTabellaGioco();
			creaCelleGioco();
			creaPedine();
			inserisciPedine();
			creaPanelInfoPartita();
			mostraTurnoCorrente();
			mostraTempoTrascorso();
			Thread t = new Thread(new ThreadStart(ThreadMostraTempo));
			t.Start();
		}
		private void bottoneMultiPlayer_Click(object sender, EventArgs e)
		{
			computer = null;
			panelSceltaModalita.Visible = false;
			giocoDama.iniziaPartita();
			creaTabellaGioco();
			creaCelleGioco();
			creaPedine();
			inserisciPedine();
			creaPanelInfoPartita();
			mostraTurnoCorrente();
			mostraTempoTrascorso();
			Thread t = new Thread(new ThreadStart(ThreadMostraTempo));
			t.Start();
		}

		// TABELLA GIOCO
		private void creaTabellaGioco()
		{
			panelTabella = new Panel();         // crea il panel che contiene la tabella di gioco
			panelTabella.Name = "panelTabella";
			panelTabella.BackColor = K.COLORE_PANEL_TABELLA;
			panelTabella.Location = new System.Drawing.Point(5, 30);
			panelTabella.Size = new System.Drawing.Size(504, 504);
			panelTabella.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			//panelTabella.Dock = DockStyle.Fill;
			this.Controls.Add(panelTabella);
		}
		private void creaCelleGioco()
		{
			int px;
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
					if (coloreCella) elencoCelle[r, c].BackColor = K.COLORE_CASELLE_BIANCHE;
					else elencoCelle[r, c].BackColor = K.COLORE_CASELLE_NERE;
					coloreCella = !coloreCella;
					elencoCelle[r, c].Location = new Point(px, py);
					elencoCelle[r, c].Size = new Size(K.DIMENSIONE_CELLA, K.DIMENSIONE_CELLA);
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
			for (int t = 0; t < K.NUM_GIOCATORI; t++)
			{
				for (int c = 0; c < K.NUMERO_PEDINE_UTENTE; c++)
				{
					imgBoxPedine[t, c] = new PictureBoxPedina();
					imgBoxPedine[t, c].SizeMode = PictureBoxSizeMode.StretchImage;
					imgBoxPedine[t, c].ClientSize = new Size(K.DIMENSIONE_CELLA, K.DIMENSIONE_CELLA);
					imgBoxPedine[t, c].Click += new System.EventHandler(this.mostraPossibiliMosse_Click);
					imgBoxPedine[t, c].Cursor = System.Windows.Forms.Cursors.Hand;
					imgBoxPedine[t, c].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pedinaMouseDown_Click);
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
					elencoCelle[r, c].pictureBoxPedina = null;         // TEST
					if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.PEDINA_NERA || matricePedine[r, c] == K.DAMA_BIANCA || matricePedine[r, c] == K.DAMA_NERA)
					{
						if (matricePedine[r, c] == K.PEDINA_BIANCA) t = 0;
						else if (matricePedine[r, c] == K.PEDINA_NERA) t = 1;
						else if (matricePedine[r, c] == K.DAMA_BIANCA) t = 0;
						else if (matricePedine[r, c] == K.DAMA_NERA) t = 1;
						assegnaTipoPedina(matricePedine[r, c], numPedineInserite[t]);
						imgBoxPedine[t, numPedineInserite[t]].r = r;
						imgBoxPedine[t, numPedineInserite[t]].c = c;
						elencoCelle[r, c].pictureBoxPedina = imgBoxPedine[t, numPedineInserite[t]];         // TEST
						this.elencoCelle[r, c].Controls.Add(imgBoxPedine[t, numPedineInserite[t]]);
						numPedineInserite[t]++;
					}
				}
			}
		}
		private void assegnaTipoPedina(int tipoPedina, int c)
		{
			if (tipoPedina == K.PEDINA_BIANCA)
			{
				imgBoxPedine[tipoPedina - 1, c].Image = K.IMG_PEDINA_BIANCA;
				imgBoxPedine[tipoPedina - 1, c].tipoPedina = K.PEDINA_BIANCA;
			}
			else if (tipoPedina == K.PEDINA_NERA)
			{
				imgBoxPedine[tipoPedina - 1, c].Image = K.IMG_PEDINA_NERA;
				imgBoxPedine[tipoPedina - 1, c].tipoPedina = K.PEDINA_NERA;
			}
			else if (tipoPedina == K.DAMA_BIANCA)
			{
				imgBoxPedine[tipoPedina - K.VAL_DIFFERENZA_DAME_PEDINE - 1, c].Image = K.IMG_DAMA_BIANCA;
				imgBoxPedine[tipoPedina - K.VAL_DIFFERENZA_DAME_PEDINE - 1, c].tipoPedina = K.DAMA_BIANCA;
			}
			else if (tipoPedina == K.DAMA_NERA)
			{
				imgBoxPedine[tipoPedina - K.VAL_DIFFERENZA_DAME_PEDINE - 1, c].Image = K.IMG_DAMA_NERA;
				imgBoxPedine[tipoPedina - K.VAL_DIFFERENZA_DAME_PEDINE - 1, c].tipoPedina = K.DAMA_NERA;
			}
		}

		// PANEL INFO PARTITA
		private void creaPanelInfoPartita()
		{
			panelInfoPartita = new Panel();
			panelInfoPartita.Name = "panelInfoParita";
			panelInfoPartita.BackColor = K.COLORE_PANEL_TABELLA;
			panelInfoPartita.Location = new System.Drawing.Point(515, 30);
			panelInfoPartita.Size = new System.Drawing.Size(200, 504);
			panelInfoPartita.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;
			this.Controls.Add(panelInfoPartita);
			creaBoxTempoTrascorso();
			creaPanelTurno();
			creaBoxTurnoCorrente();
		}
		private void creaPanelTurno()
		{
			panelTurnoPartita = new Panel();
			panelTurnoPartita.Name = "panelTurnoParita";
			panelTurnoPartita.BackColor = K.COLORE_PANEL_TURNO;
			panelTurnoPartita.Dock = DockStyle.Top;
			panelTurnoPartita.Location = new System.Drawing.Point(515, 30);
			panelTurnoPartita.Size = new System.Drawing.Size(200, 200);
			panelTurnoPartita.BorderStyle = BorderStyle.FixedSingle;
			panelTurnoPartita.Padding = new Padding(10);
			panelInfoPartita.Controls.Add(panelTurnoPartita);

			boxPedinaTurnoGiocatore = new PictureBox();
			boxPedinaTurnoGiocatore.Image = K.IMG_PEDINA_BIANCA;
			boxPedinaTurnoGiocatore.SizeMode = PictureBoxSizeMode.StretchImage;
			boxPedinaTurnoGiocatore.Location = new Point(55, 80);
			boxPedinaTurnoGiocatore.Size = new System.Drawing.Size(90, 90);
			panelTurnoPartita.Controls.Add(boxPedinaTurnoGiocatore);
		}
		// Box info
		private void creaBoxTurnoCorrente()
		{
			textBoxTurnoGiocatore = new TextBox();
			textBoxTurnoGiocatore.Name = "textInfo";
			textBoxTurnoGiocatore.Dock = DockStyle.Top;
			textBoxTurnoGiocatore.BorderStyle = BorderStyle.FixedSingle;
			textBoxTurnoGiocatore.ReadOnly = true;
			textBoxTurnoGiocatore.Multiline = true;
			textBoxTurnoGiocatore.BackColor = Color.FromArgb(250, 255, 204);
			textBoxTurnoGiocatore.WordWrap = true;
			textBoxTurnoGiocatore.Height = 55;
			textBoxTurnoGiocatore.TextAlign = HorizontalAlignment.Center;
			textBoxTurnoGiocatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
			panelTurnoPartita.Controls.Add(textBoxTurnoGiocatore);
		}
		private void mostraTurnoCorrente()
		{
			if (giocoDama.getGiocatoreCorrente() == 1) boxPedinaTurnoGiocatore.Image = K.IMG_PEDINA_BIANCA;
			else boxPedinaTurnoGiocatore.Image = K.IMG_PEDINA_NERA;
			textBoxTurnoGiocatore.Text = "Turno del giocatore " + giocoDama.getGiocatoreCorrente();
		}
		private void creaBoxTempoTrascorso()
		{
			textBoxTempoTrascorso = new TextBox();
			textBoxTempoTrascorso.Name = "textInfoTempoTrascorso";
			textBoxTempoTrascorso.Dock = DockStyle.Top;
			textBoxTempoTrascorso.BorderStyle = BorderStyle.FixedSingle;
			textBoxTempoTrascorso.BackColor = Color.FromArgb(250, 255, 204);
			textBoxTempoTrascorso.ReadOnly = true;
			textBoxTempoTrascorso.Multiline = true;
			textBoxTempoTrascorso.WordWrap = true;
			textBoxTempoTrascorso.Height = 65;
			textBoxTempoTrascorso.TextAlign = HorizontalAlignment.Center;
			textBoxTempoTrascorso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
			panelInfoPartita.Controls.Add(textBoxTempoTrascorso);
		}
		private void mostraTempoTrascorso()
		{
			CheckForIllegalCrossThreadCalls = false;
			textBoxTempoTrascorso.Text = "Tempo trascorso: " + giocoDama.getTempoTrascorso();
		}
		private void mostraStringaVittoria()
		{
			textBoxTurnoGiocatore.BackColor = Color.LightGreen;
			textBoxTurnoGiocatore.Text = "Ha vinto il giocatore " + giocoDama.getVincitore();
		}

		// Permettono al giocatore di effettuare mosse
		private void mostraPossibiliMosse_Click(object sender, EventArgs e)
		{
			rimuoviPrecedentiEvidenziati();
			int tipoPedina = ((PictureBoxPedina)sender).tipoPedina;
			if (tipoPedina == giocoDama.getGiocatoreCorrente() || tipoPedina - K.VAL_DIFFERENZA_DAME_PEDINE == giocoDama.getGiocatoreCorrente())
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
						elencoCelle[r, c].Cursor = System.Windows.Forms.Cursors.Hand;
						elencoCelle[r, c].MouseDown += new System.Windows.Forms.MouseEventHandler(this.mossaPossibileMouseDown_Click);
					}
				}
			}
		}
		private void pedinaMouseDown_Click(object sender, MouseEventArgs e)
		{
			((PictureBoxPedina)sender).BackColor = K.COLORE_CASELLA_CLICK_DOWN;
		}
		private void mossaPossibileMouseDown_Click(object sender, MouseEventArgs e)
		{
			((PanelCella)sender).BackColor = K.COLORE_CASELLA_SELEZIONATA_CLICK_DOWN;
		}

		private void eseguiMossaScelta(object sender, EventArgs e)
		{
			giocoDama.eseguiMossa(((PanelCella)sender).y, (((PanelCella)sender).x));    // Esegue la mossa aggiornando la matrice nella classe GiocoDama
			aggiornaPedine();
			mostraTurnoCorrente();
			if (!giocoDama.getGiocoInCorso()) mostraStringaVittoria();
			else if (giocoDama.getGiocatoreCorrente() == 2 && computer != null) // Se è in modalità single player fa eseguire la mossa al computer
			{
				Thread tPC = new Thread(new ThreadStart(computer.trovaEdEseguiMossa));  // Thread che permette di far aspettare il pc prima di scegliere la mossa, senza bloccare l'aggiornamento delle pedine della mossa precedente
				tPC.Start();
				tPC.Join();     // attende che il pc abbia effettuato la mossa
								//computer.trovaEdEseguiMossa();

				aggiornaPedine();
				mostraTurnoCorrente();
				if (!giocoDama.getGiocoInCorso()) mostraStringaVittoria();  // controlla se il gioco è ancora in corso o è terminato con la vittoria di un giocatore
			}
		}

		// Aggiorna pedine dopo la mossa
		private void aggiornaPedine()
		{
			//cancellaPedine();
			rimuoviPrecedentiEvidenziati();
			//inserisciPedine();
			
			EsitoMossa esitoMossa = giocoDama.getEsitoMossa();              // legge l'esito della mossa e mostra le modifiche nel tabellone
			elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina = elencoCelle[esitoMossa.rPrec, esitoMossa.cPrec].pictureBoxPedina;
			elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.r = esitoMossa.rNew;
			elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.c = esitoMossa.cNew;
			elencoCelle[esitoMossa.rNew, esitoMossa.cNew].Controls.Add(elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina);
			//elencoCelle[esitoMossa.rPrec, esitoMossa.cPrec].Controls.Clear();
			elencoCelle[esitoMossa.rPrec, esitoMossa.cPrec].pictureBoxPedina = null;
			if (esitoMossa.seMangiata)
			{
				elencoCelle[esitoMossa.rMangiata, esitoMossa.cMangiata].Controls.Clear();
				elencoCelle[esitoMossa.rMangiata, esitoMossa.cMangiata].pictureBoxPedina = null;
			}
			if (esitoMossa.seNuovaDama)
			{
				if (esitoMossa.giocatore == K.PEDINA_BIANCA)
				{
					elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.Image = K.IMG_DAMA_BIANCA;
					elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.tipoPedina = K.DAMA_BIANCA;
				}
				else
				{
					elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.Image = K.IMG_DAMA_NERA;
					elencoCelle[esitoMossa.rNew, esitoMossa.cNew].pictureBoxPedina.tipoPedina = K.DAMA_NERA;
				}
			}
		}
		/*private void cancellaPedine()
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					elencoCelle[r, c].Controls.Clear();
				}
			}
		}*/
		private void rimuoviPrecedentiEvidenziati()
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (elencoCelle[r, c].pictureBoxPedina != null) elencoCelle[r, c].pictureBoxPedina.BackColor = K.COLORE_CASELLE_NERE;   // Toglie la selezione alle pedine
					if (elencoCelle[r, c].BackColor == K.COLORE_CASELLA_MOSSA_POSSIBILE || elencoCelle[r, c].BackColor == K.COLORE_CASELLA_SELEZIONATA_CLICK_DOWN)
					{
						elencoCelle[r, c].BackColor = K.COLORE_CASELLE_NERE;
						elencoCelle[r, c].Click -= new System.EventHandler(this.eseguiMossaScelta);
						elencoCelle[r, c].Cursor = System.Windows.Forms.Cursors.Default;
						elencoCelle[r, c].MouseDown -= new System.Windows.Forms.MouseEventHandler(this.mossaPossibileMouseDown_Click);
					}
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
			public PictureBoxPedina pictureBoxPedina;
		}


		// --------------------------- FINESTRE DI DIALOGO ---------------------------
		// Finestra info dama
		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string message = "Gioco Dama sviluppato in C# con l'utilizzo delle form. \n\nSviluppato da Martucci Flavio, studente della 5INF3." +
				"\nAnno scolastico 2021/2022.";
			string caption = "Informazioni su Dama";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Information);
		}
		// Finestra di dialogo torna al menu
		private void tornaAlMenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string message = "Sicuro di voler abbandonare la partita e tornare al menu principale?";
			string caption = "Abbandonare la partita?";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				giocoDama.terminaPartita();
				this.Controls.Remove(panelTabella);
				this.Controls.Remove(panelInfoPartita);
				panelSchermataGioca.Visible = true;
				tornaAlMenuToolStripMenuItem.Enabled = false;
				panelSceltaModalita.Visible = false;
			}
		}
		// Finestra di dialofo nuova partita
		private void nuovaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (giocoDama.getGiocoInCorso())
			{
				string message = "Sicuro di voler abbandonare la partita in corso per iniziarne una nuova?";
				string caption = "Abbandonare la partita?";
				var result = MessageBox.Show(message, caption,
											 MessageBoxButtons.YesNo,
											 MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					giocoDama.terminaPartita();
					this.Controls.Remove(panelTabella);
					this.Controls.Remove(panelInfoPartita);
					tornaAlMenuToolStripMenuItem.Enabled = false;
					bottoneGioca_Click(null, null);
				}
			}
			else
			{
				giocoDama.terminaPartita();
				this.Controls.Remove(panelTabella);
				this.Controls.Remove(panelInfoPartita);
				tornaAlMenuToolStripMenuItem.Enabled = false;
				bottoneGioca_Click(null, null);
			}
		}
		// Finestra di conferma chiusura gioco
		private void FormGioco_FormClosing(object sender, FormClosingEventArgs e)
		{
			string message =
				"Sei sicuro di voler chiudere il gioco?";
			string caption = "Chiudere il gioco?";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Question);
			if (result == DialogResult.No)
			{
				e.Cancel = true;// cancel the closure of the form.
			}
			else
			{
				giocoDama.terminaPartita();
			}
		}
		private void apriIlSitoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://kaurgames2.altervista.org/index.html");
		}

	}


}
