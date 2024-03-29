﻿using System;
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
		//public static readonly Color COLORE_PANEL_TABELLA = Color.LightGray;
		//public static readonly Color COLORE_PANEL_TABELLA = Color.AliceBlue;
		public static readonly Color COLORE_PANEL_TABELLA = Color.FromArgb(225, 223, 180);
		//public static readonly Color COLORE_PANEL_TURNO = Color.FromArgb(163, 163, 163);
		public static readonly Color COLORE_PANEL_TURNO = Color.FromArgb(190, 147, 105);

		public static readonly int PEDINA_BIANCA = 1;
		public static readonly int PEDINA_NERA = 2;
		public static readonly int DAMA_BIANCA = 3;
		public static readonly int DAMA_NERA = 4;
		public static readonly int CELLA_VUOTA = 0;
		//public static readonly int TIPI_PEDINE = 4;
		public static readonly int NUM_GIOCATORI = 2;
		public static readonly int VAL_DIFFERENZA_DAME_PEDINE = 2;

		public static readonly Image IMG_PEDINA_BIANCA = Image.FromFile("pedinaDama1.png");
		public static readonly Image IMG_PEDINA_NERA = Image.FromFile("pedinaDama2.png");
		public static readonly Image IMG_DAMA_BIANCA = Image.FromFile("pedinaDama3.png");
		public static readonly Image IMG_DAMA_NERA = Image.FromFile("pedinaDama4.png");

	}
}
