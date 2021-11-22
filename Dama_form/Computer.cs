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
			Thread.Sleep(1000);     // Attende un secondo prima di effettuare la mossa
			int rNew = 0;
			int cNew = 0;

			int[,] matricePedine = giocoDama.getMatricePedine();
			bool pedinaScelta = false;
			bool[,] matriceCelleDaEvidenziare = null;

			var rand = new Random();
			int numPedinaScelto = rand.Next(0, numeroPedineConMosse());
			int numPedineTrovate = 0;
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)   // Trova la mossa casuale scelta
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
								if (numPedineTrovate == numPedinaScelto)
								{
									pedinaScelta = true;
									giocoDama.setRSelezionata(r);
									giocoDama.setCSelezionata(c);
								}
								numPedineTrovate++;
							}
						}
					}
				}
			}


			// Sceglie una mossa della pedina a caso
			int numMossePedinaPossibili = numeroMossePedina(matriceCelleDaEvidenziare);
			int numScelto = rand.Next(0, numMossePedinaPossibili);
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matriceCelleDaEvidenziare[r, c])
					{
						if (numScelto == 0)
						{
							rNew = r;
							cNew = c;
						}
						numScelto--;
					}
				}
			}
			giocoDama.eseguiMossa(rNew, cNew);

		}

		// TROVA IL NUMERO DI PEDINE CON MOSSE
		private int numeroPedineConMosse()      // Conta quante pedine possono muoversi
		{
			int[,] matricePedine = giocoDama.getMatricePedine();
			bool[,] matriceCelleDaEvidenziare = null;
			int num = 0;
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (giocoDama.getGiocatoreCorrente() == matricePedine[r, c] || giocoDama.getGiocatoreCorrente() == matricePedine[r, c] - K.VAL_DIFFERENZA_DAME_PEDINE)
					{
						matriceCelleDaEvidenziare = giocoDama.getMatriceCelleDaEvidenziare(r, c);
						if (controllaSePresenteMossa(matriceCelleDaEvidenziare))
							num++;
					}
				}
			}
			return num;
		}

		private bool controllaSePresenteMossa(bool[,] matriceCelleDaEvidenziare)    // Controlla se sono disponibili mosse per quella pedina
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

		private int numeroMossePedina(bool[,] matriceCelleDaEvidenziare)    // Conta quante mosse può fare la pedina
		{
			int numeroMosse = 0;
			for (int r = 0; r < K.NUMERO_CELLE_LATO; r++)
			{
				for (int c = 0; c < K.NUMERO_CELLE_LATO; c++)
				{
					if (matriceCelleDaEvidenziare[r, c]) numeroMosse++;
				}
			}
			return numeroMosse;
		}

	}
}
