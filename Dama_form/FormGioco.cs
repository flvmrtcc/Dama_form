using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dama_form
{
	public partial class FormGioco : Form
	{
		public FormGioco()
		{
			InitializeComponent();
		}
		private void bottoneGioca_Click(object sender, EventArgs e)
		{
			bottoneGioca.Visible = false;
			titoloGioco.Visible = false;
			creaTabellaGioco();
		}

		private void creaTabellaGioco()
		{
			panelTabella.BackColor = Color.Blue;


		}
		private System.Windows.Forms.Panel panelTabella;

		private class PanelTest : Panel
		{
			private int x;
			private int y;
		}


	}
}
