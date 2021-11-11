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
				{ 2, 0, 2, 0, 2, 0, 2, 0 },
				{ 0, 2, 0, 2, 0, 2, 0, 2 },
				{ 2, 0, 2, 0, 2, 0, 2, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 1, 0, 1, 0, 1, 0, 1 },
				{ 1, 0, 1, 0, 1, 0, 1, 0 },
				{ 0, 1, 0, 1, 0, 1, 0, 1 }
			};
			giocoInCorso = false;


		}

		public int[,] getMatricePedine()
		{
			return matricePedine;
		}


	}
}
