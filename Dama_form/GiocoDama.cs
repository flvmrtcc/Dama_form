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
		public GiocoDama()
		{
			matricePedine = new int[,]
			{
				{ K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0 },
				{ 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA },
				{ K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0, K.PEDINA_NERA, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA },
				{ K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0 },
				{ 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA, 0, K.PEDINA_BIANCA }
			};
			giocoInCorso = false;


		}

		// Evidenzia le possibili mosse
		public bool[,] getMatriceCelleDaEvidenziare(int r, int c)
		{
			bool[,] matriceCelleDaEvidenziare = new bool[K.NUMEROCELLELATO, K.NUMEROCELLELATO];
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
			for (int r = 0; r < K.NUMEROCELLELATO; r++)
			{
				for (int c = 0; c < K.NUMEROCELLELATO; c++)
				{
					matriceCelleDaEvidenziare[r, c] = false;
				}
			}
		}
		private void controllaMosseVersoNord(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			if (r > 0)
			{
				if (c > 0)
				{
					if (matricePedine[r - 1, c - 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r - 1, c - 1] = true;
					}
				}
				if (c < K.NUMEROCELLELATO - 1)
				{
					if (matricePedine[r - 1, c + 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r - 1, c + 1] = true;
					}
				}
			}
		}
		private void controllaMosseVersoSud(int r, int c, bool[,] matriceCelleDaEvidenziare)
		{
			if (r < K.NUMEROCELLELATO - 1)
			{
				if (c > 0)
				{
					if (matricePedine[r + 1, c - 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r + 1, c - 1] = true;
					}
				}
				if (c < K.NUMEROCELLELATO - 1)
				{
					if (matricePedine[r + 1, c + 1] == K.CELLA_VUOTA)
					{
						matriceCelleDaEvidenziare[r + 1, c + 1] = true;
					}
				}
			}
		}


		public int[,] getMatricePedine()
		{
			return matricePedine;
		}


	}
}
