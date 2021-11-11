using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dama_form
{
	public static class K
	{
		public static readonly int DIMENSIONECELLA = 50;
		public static readonly int NUMEROCELLELATO = 8;
		public static readonly Color COLORE_CASELLE_NERE = Color.FromArgb(152, 118, 84);
		public static readonly Color COLORE_CASELLE_BIANCHE = Color.FromArgb(205, 203, 160);
		public static readonly Color COLORE_CASELLA_SELEZIONATA = Color.Gray;
		public static readonly Color COLORE_CASELLA_MOSSA_POSSIBILE = Color.Green;

		public static readonly int PEDINA_BIANCA = 1;
		public static readonly int PEDINA_NERA = 2;
		public static readonly int CELLA_VUOTA = 0;
	}
}
