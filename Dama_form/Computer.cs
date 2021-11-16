using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dama_form
{
	public class Computer
	{
		GiocoDama giocoDama;

		public Computer(GiocoDama giocoDama)
		{
			this.giocoDama = giocoDama;
		}

		public void trovaEdEseguiMossa()
		{
			Thread.Sleep(1000);
			int rNew = 0;
			int cNew = 0;

			int[,] matricePedine = giocoDama.getMatricePedine();
			bool pedinaScelta = false;
			bool mossaTrovata = false;
			bool[,] matriceCelleDaEvidenziare = null;

			for (int r = K.NUMERO_CELLE_LATO - 1; r >= 0; r--)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (!pedinaScelta)
					{
						if (matricePedine[r, c] == giocoDama.getGiocatoreCorrente() || matricePedine[r, c] - K.VAL_DIFFERENZA_DAME_PEDINE == giocoDama.getGiocatoreCorrente())
						{
							matriceCelleDaEvidenziare = giocoDama.getMatriceCelleDaEvidenziare(r, c);
							if (controllaSePresenteMossa(matriceCelleDaEvidenziare))
							{
								pedinaScelta = true;
								giocoDama.setRSelezionata(r);
								giocoDama.setCSelezionata(c);
							}
						}
					}
				}
			}

			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (!mossaTrovata)
						if (matriceCelleDaEvidenziare[r, c])
						{
							mossaTrovata = true;
							rNew = r;
							cNew = c;
						}
				}
			}
			giocoDama.eseguiMossa(rNew, cNew);

		}

		public bool controllaSePresenteMossa(bool[,] matriceCelleDaEvidenziare)
		{
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matriceCelleDaEvidenziare[r, c]) return true;
				}
			}
			return false;
		}

	}
}
