using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dama_form
{
	public class GiocoDama
	{
		private int[,] matricePedine;
		private bool giocoInCorso;
		private int rSelezionata;
		private int cSelezionata;
		private int giocatoreCorrente;
		public GiocoDama()
		{
			//matricePedine = new int[,]
			//{
			//	{ K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA   },
			//	{ K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA   },
			//	{ K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA   },
			//	{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
			//	{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
			//	{ K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA },
			//	{ K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA   },
			//	{ K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA }
			//};
			matricePedine = new int[,]
			{
				{ K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA   },
				{ K.PEDINA_NERA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.PEDINA_BIANCA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA },
				{ K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA }
			};
			giocoInCorso = false;
			giocatoreCorrente = K.PEDINA_BIANCA;

		}

		// Evidenzia le possibili mosse
		public bool[,] getMatriceCelleDaEvidenziare(int r, int c)
		{
			rSelezionata = r;
			cSelezionata = c;
			bool[,] matriceCelleDaEvidenziare = new bool[K.NUMERO_CELLE_LATO, K.NUMERO_CELLE_LATO];
			inizializzaMatriceCelleDaEvidenziare(matriceCelleDaEvidenziare);
			if (matricePedine[r, c] == K.PEDINA_BIANCA)
			{
				controllaMosseVersoNord(r, c, matriceCelleDaEvidenziare);
			}
			else if (matricePedine[r, c] == K.PEDINA_NERA)
			{
				controllaMosseVersoSud(r, c, matriceCelleDaEvidenziare);
			}
			return matriceCelleDaEvidenziare;
		}
		private void inizializzaMatriceCelleDaEvidenziare(bool[,] matriceCelleDaEvidenziare)
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					matriceCelleDaEvidenziare[r, c] = false;
				}
			}
		}
		private void controllaMosseVersoNord(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r - 1 >= 0)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r - 1, c - 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r - 1, c - 1] = true;
					}
					else if (c - 2 >= 0 && r - 2 >= 0)
					{
						if (matricePedine[r - 1, c - 1] == giocatoreAvversario && matricePedine[r - 2, c - 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r - 2, c - 2] = true;

					}
				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r - 1, c + 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r - 1, c + 1] = true;
					}
					else if (c + 2 < K.NUMERO_CELLE_LATO && r - 2 >= 0)
					{
						if (matricePedine[r - 1, c + 1] == giocatoreAvversario && matricePedine[r - 2, c + 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r - 2, c + 2] = true;
					}
				}
			}
		}
		private void controllaMosseVersoSud(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r + 1 < K.NUMERO_CELLE_LATO)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r + 1, c - 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r + 1, c - 1] = true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c - 2 >= 0)
					{
						if (matricePedine[r + 1, c - 1] == giocatoreAvversario && matricePedine[r + 2, c - 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r + 2, c - 2] = true;
					}

				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r + 1, c + 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r + 1, c + 1] = true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c + 2 < K.NUMERO_CELLE_LATO)
					{
						if (matricePedine[r + 1, c + 1] == giocatoreAvversario && matricePedine[r + 2, c + 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r + 2, c + 2] = true;
					}
				}
			}
		}

		// Esegui mossa scelta
		public void eseguiMossa(int r, int c)
		{
			if (Math.Abs(rSelezionata - r) == 1 && Math.Abs(cSelezionata - c) == 1)
			{
				matricePedine[r, c] = matricePedine[rSelezionata, cSelezionata];
				matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
			}
			else
			{
				if (rSelezionata - r > 0)
				{
					if (cSelezionata - c > 0)
					{
						matricePedine[rSelezionata - 2, cSelezionata - 2] = matricePedine[rSelezionata, cSelezionata];
						matricePedine[rSelezionata - 1, cSelezionata - 1] = K.CELLA_VUOTA;
						matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
					}
					else
					{
						matricePedine[rSelezionata - 2, cSelezionata + 2] = matricePedine[rSelezionata, cSelezionata];
						matricePedine[rSelezionata - 1, cSelezionata + 1] = K.CELLA_VUOTA;
						matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
					}
				}
				else
				{
					if (cSelezionata - c > 0)
					{
						matricePedine[rSelezionata + 2, cSelezionata - 2] = matricePedine[rSelezionata, cSelezionata];
						matricePedine[rSelezionata + 1, cSelezionata - 1] = K.CELLA_VUOTA;
						matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
					}
					else
					{
						matricePedine[rSelezionata + 2, cSelezionata + 2] = matricePedine[rSelezionata, cSelezionata];
						matricePedine[rSelezionata + 1, cSelezionata + 1] = K.CELLA_VUOTA;
						matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
					}
				}
			}
			cambiaGiocatoreCorrente();
		}
		private void cambiaGiocatoreCorrente()
		{
			if (giocatoreCorrente == K.PEDINA_BIANCA) giocatoreCorrente = K.PEDINA_NERA;
			else giocatoreCorrente = K.PEDINA_BIANCA;
		}

		public int getRSelezionata()
		{
			return rSelezionata;
		}
		public int getCSelezionata()
		{
			return cSelezionata;
		}
		public int getGiocatoreCorrente()
		{
			return giocatoreCorrente;
		}
		public int[,] getMatricePedine()
		{
			return matricePedine;
		}


	}
}
