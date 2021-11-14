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
		private int vincitore;

		private bool obbligoMangiare;

		private EsitoMossa esitoMossa = new EsitoMossa();

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
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.PEDINA_BIANCA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.PEDINA_NERA,   K.CELLA_VUOTA,   K.CELLA_VUOTA,   K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.CELLA_VUOTA, K.CELLA_VUOTA,   K.DAMA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA },
				{ K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA   },
				{ K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA, K.CELLA_VUOTA,   K.PEDINA_BIANCA }
			};
			giocoInCorso = false;
			obbligoMangiare = false;
			vincitore = 0;
			giocatoreCorrente = K.PEDINA_BIANCA;

		}

		internal void iniziaPartita()
		{
			giocoInCorso = true;
		}

		// Evidenzia le possibili mosse
		public bool[,] getMatriceCelleDaEvidenziare(int r, int c)
		{
			bool[,] matriceCelleDaEvidenziare = new bool[K.NUMERO_CELLE_LATO, K.NUMERO_CELLE_LATO];
			if (giocoInCorso)
			{
				rSelezionata = r;
				cSelezionata = c;
				inizializzaMatriceCelleDaEvidenziare(matriceCelleDaEvidenziare);
				if (matricePedine[r, c] == K.PEDINA_BIANCA)
				{
					controllaMosseVersoNord(r, c, matriceCelleDaEvidenziare);
				}
				else if (matricePedine[r, c] == K.PEDINA_NERA)
				{
					controllaMosseVersoSud(r, c, matriceCelleDaEvidenziare);
				}
				else if (matricePedine[r, c] == K.DAMA_BIANCA || matricePedine[r, c] == K.DAMA_NERA)
				{
					controllaMosseVersoNord(r, c, matriceCelleDaEvidenziare);
					controllaMosseVersoSud(r, c, matriceCelleDaEvidenziare);
				}
			}
			return matriceCelleDaEvidenziare;
		}
		private void inizializzaMatriceCelleDaEvidenziare(bool[,] matriceCelleDaEvidenziare)
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++) matriceCelleDaEvidenziare[r, c] = false;
			}
		}
		private void controllaMosseVersoNord(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.DAMA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r - 1 >= 0)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r - 1, c - 1] == K.CELLA_VUOTA && !obbligoMangiare)
					{
						matriceCelleDaEvidenziare[r - 1, c - 1] = true;
					}
					else if (c - 2 >= 0 && r - 2 >= 0)
					{
						if ((matricePedine[r - 1, c - 1] == giocatoreAvversario || matricePedine[r - 1, c - 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r - 2, c - 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r - 2, c - 2] = true;
					}
				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r - 1, c + 1] == K.CELLA_VUOTA && !obbligoMangiare)
					{
						matriceCelleDaEvidenziare[r - 1, c + 1] = true;
					}
					else if (c + 2 < K.NUMERO_CELLE_LATO && r - 2 >= 0)
					{
						if ((matricePedine[r - 1, c + 1] == giocatoreAvversario || matricePedine[r - 1, c + 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r - 2, c + 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r - 2, c + 2] = true;
					}
				}
			}
		}
		private void controllaMosseVersoSud(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.DAMA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r + 1 < K.NUMERO_CELLE_LATO)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r + 1, c - 1] == K.CELLA_VUOTA && !obbligoMangiare)
					{
						matriceCelleDaEvidenziare[r + 1, c - 1] = true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c - 2 >= 0)
					{
						if ((matricePedine[r + 1, c - 1] == giocatoreAvversario || matricePedine[r + 1, c - 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r + 2, c - 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r + 2, c - 2] = true;
					}

				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r + 1, c + 1] == K.CELLA_VUOTA && !obbligoMangiare)
					{
						matriceCelleDaEvidenziare[r + 1, c + 1] = true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c + 2 < K.NUMERO_CELLE_LATO)
					{
						if ((matricePedine[r + 1, c + 1] == giocatoreAvversario || matricePedine[r + 1, c + 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r + 2, c + 2] == K.CELLA_VUOTA)
							matriceCelleDaEvidenziare[r + 2, c + 2] = true;
					}
				}
			}
		}

		// Controlla se il giocatore puo mangiare
		private bool seGiocatoreDeveMangiare()
		{
			bool[,] matriceMosse;
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matricePedine[r, c] == giocatoreCorrente || matricePedine[r, c] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreCorrente)
					{
						matriceMosse = getMatriceCelleDaEvidenziare(r, c);
						if (controllaSePuoMangiare(r, c, matriceMosse)) return true;
					}
				}
			}
			return false;
		}
		private bool controllaSePuoMangiare(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			for (int r0 = 0; r0 < K.NUMERO_CELLE_LATO; r0++)
			{
				for (int c0 = 0; c0 < K.NUMERO_CELLE_LATO; c0++)
				{
					if (matriceCelleDaEvidenziare[r0, c0])
					{
						if (Math.Abs(r0 - r) == 2 && Math.Abs(c0 - c) == 2) return true;
					}
				}
			}
			return false;
		}

		// Esegui mossa scelta
		public void eseguiMossa(int r, int c)
		{
			if (giocoInCorso)
			{
				esitoMossa.rPrec = rSelezionata;
				esitoMossa.cPrec = cSelezionata;
				esitoMossa.rNew = r;
				esitoMossa.cNew = c;
				if (Math.Abs(rSelezionata - r) == 1 && Math.Abs(cSelezionata - c) == 1)
				{
					matricePedine[r, c] = matricePedine[rSelezionata, cSelezionata];
					matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
					esitoMossa.seMangiata = false;
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
							salvaPosizionePedinaMangiata(rSelezionata - 1, cSelezionata - 1);
						}
						else
						{
							matricePedine[rSelezionata - 2, cSelezionata + 2] = matricePedine[rSelezionata, cSelezionata];
							matricePedine[rSelezionata - 1, cSelezionata + 1] = K.CELLA_VUOTA;
							matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
							salvaPosizionePedinaMangiata(rSelezionata - 1, cSelezionata + 1);
						}
					}
					else
					{
						if (cSelezionata - c > 0)
						{
							matricePedine[rSelezionata + 2, cSelezionata - 2] = matricePedine[rSelezionata, cSelezionata];
							matricePedine[rSelezionata + 1, cSelezionata - 1] = K.CELLA_VUOTA;
							matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
							salvaPosizionePedinaMangiata(rSelezionata + 1, cSelezionata - 1);
						}
						else
						{
							matricePedine[rSelezionata + 2, cSelezionata + 2] = matricePedine[rSelezionata, cSelezionata];
							matricePedine[rSelezionata + 1, cSelezionata + 1] = K.CELLA_VUOTA;
							matricePedine[rSelezionata, cSelezionata] = K.CELLA_VUOTA;
							salvaPosizionePedinaMangiata(rSelezionata + 1, cSelezionata + 1);
						}
					}
				}
				controllaPossibiliDame();
				cambiaGiocatoreCorrente();
				controllaPossibileVittoria();
				if (giocoInCorso && !seDisponibiliMosse())
				{
					giocoInCorso = false;
					cambiaGiocatoreCorrente();
					vincitore = giocatoreCorrente;
				}
			}
		}
		private void salvaPosizionePedinaMangiata(int rMangiata, int cMangiata)
		{
			esitoMossa.seMangiata = true;
			esitoMossa.rMangiata = rMangiata;
			esitoMossa.cMangiata = cMangiata;
		}
		private void cambiaGiocatoreCorrente()
		{
			if (giocatoreCorrente == K.PEDINA_BIANCA) giocatoreCorrente = K.PEDINA_NERA;
			else giocatoreCorrente = K.PEDINA_BIANCA;
			obbligoMangiare = false;
			obbligoMangiare = seGiocatoreDeveMangiare();
		}

		// Controlla se una pedina deve diventare dama
		private void controllaPossibiliDame()
		{
			int r;
			if (giocatoreCorrente == K.PEDINA_BIANCA) r = 0;
			else r = K.NUMERO_CELLE_LATO - 1;
			for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
			{
				if (matricePedine[r, c] == giocatoreCorrente) matricePedine[r, c] += K.VAL_DIFFERENZA_DAME_PEDINE;
			}
		}

		// Controlla se il giocatore ha vinto
		private void controllaPossibileVittoria()
		{
			if (controllaSePedineRimanenti() == false)
			{
				cambiaGiocatoreCorrente();
				vincitore = giocatoreCorrente;
				giocoInCorso = false;
			}
		}
		private bool controllaSePedineRimanenti()
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matricePedine[r, c] == giocatoreCorrente || (matricePedine[r, c] - K.VAL_DIFFERENZA_DAME_PEDINE) == giocatoreCorrente) return true;
				}
			}
			return false;
		}

		// Controlla se sono disponibili ancora mosse per il giocatore corrente
		private bool seDisponibiliMosse()
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matricePedine[r, c] == giocatoreCorrente)
					{
						if (giocatoreCorrente == K.PEDINA_BIANCA)
						{
							if (controllaSePossibiliMosseVersoNord(r, c) == true) return true;
						}
						else if (giocatoreCorrente == K.PEDINA_NERA)
						{
							if (controllaSePossibiliMosseVersoSud(r, c) == true) return true;
						}
					}
					else if (matricePedine[r, c] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreCorrente)
					{
						if (controllaSePossibiliMosseVersoNord(r, c) == true) return true;
						if (controllaSePossibiliMosseVersoSud(r, c) == true) return true;
					}
				}
			}
			return false;
		}
		private bool controllaSePossibiliMosseVersoNord(int r, int c)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.DAMA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r - 1 >= 0)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r - 1, c - 1] == K.CELLA_VUOTA)
					{
						return true;
					}
					else if (c - 2 >= 0 && r - 2 >= 0)
					{
						if ((matricePedine[r - 1, c - 1] == giocatoreAvversario || matricePedine[r - 1, c - 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r - 2, c - 2] == K.CELLA_VUOTA)
							return true;

					}
				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r - 1, c + 1] == K.CELLA_VUOTA)
					{
						return true;
					}
					else if (c + 2 < K.NUMERO_CELLE_LATO && r - 2 >= 0)
					{
						if ((matricePedine[r - 1, c + 1] == giocatoreAvversario || matricePedine[r - 1, c + 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r - 2, c + 2] == K.CELLA_VUOTA)
							return true;
					}
				}
			}
			return false;
		}
		private bool controllaSePossibiliMosseVersoSud(int r, int c)
		{
			int giocatoreAvversario;
			if (matricePedine[r, c] == K.PEDINA_BIANCA || matricePedine[r, c] == K.DAMA_BIANCA) giocatoreAvversario = K.PEDINA_NERA;
			else giocatoreAvversario = K.PEDINA_BIANCA;
			if (r + 1 < K.NUMERO_CELLE_LATO)
			{
				if (c - 1 >= 0)
				{
					if (matricePedine[r + 1, c - 1] == K.CELLA_VUOTA)
					{
						return true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c - 2 >= 0)
					{
						if ((matricePedine[r + 1, c - 1] == giocatoreAvversario || matricePedine[r + 1, c - 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r + 2, c - 2] == K.CELLA_VUOTA)
							return true;
					}

				}
				if (c + 1 < K.NUMERO_CELLE_LATO)
				{
					if (matricePedine[r + 1, c + 1] == K.CELLA_VUOTA)
					{
						return true;
					}
					else if (r + 2 < K.NUMERO_CELLE_LATO && c + 2 < K.NUMERO_CELLE_LATO)
					{
						if ((matricePedine[r + 1, c + 1] == giocatoreAvversario || matricePedine[r + 1, c + 1] - K.VAL_DIFFERENZA_DAME_PEDINE == giocatoreAvversario) && matricePedine[r + 2, c + 2] == K.CELLA_VUOTA)
							return true;
					}
				}
			}
			return false;
		}

		// Metodi get
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

		public bool getGiocoInCorso()
		{
			return giocoInCorso;
		}
		public int getVincitore()
		{
			return vincitore;
		}

		public EsitoMossa getEsitoMossa()
		{
			return esitoMossa;
		}
		
	}

	public class EsitoMossa
	{
		public int rPrec;
		public int cPrec;
		public int rNew;
		public int cNew;
		public int rMangiata;
		public int cMangiata;
		public bool seMangiata;
	}

}
