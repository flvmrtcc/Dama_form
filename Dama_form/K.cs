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
		public static readonly int DIMENSIONE_CELLA = 60;
		public static readonly int NUMERO_CELLE_LATO = 8;
		public static readonly int NUMERO_PEDINE_UTENTE = 12;

		public static readonly Color COLORE_CASELLE_NERE = Color.FromArgb(152, 118, 84);
		public static readonly Color COLORE_CASELLE_BIANCHE = Color.FromArgb(205, 203, 160);
		public static readonly Color COLORE_CASELLA_SELEZIONATA = Color.DarkGray;
		public static readonly Color COLORE_CASELLA_MOSSA_POSSIBILE = Color.Green;
		public static readonly Color COLORE_CASELLA_CLICK_DOWN = Color.Gray;
		public static readonly Color COLORE_CASELLA_SELEZIONATA_CLICK_DOWN = Color.DarkGreen;
		public static readonly Color COLORE_PANEL_TABELLA = Color.LightGray;

		public static readonly int PEDINA_BIANCA = 1;
		public static readonly int PEDINA_NERA = 2;
		public static readonly int DAMA_BIANCA = 3;
		public static readonly int DAMA_NERA = 4;
		public static readonly int CELLA_VUOTA = 0;
		public static readonly int TIPI_PEDINE = 4;
		public static readonly int VAL_DIFFERENZA_DAME_PEDINE = 2;
	}
}
