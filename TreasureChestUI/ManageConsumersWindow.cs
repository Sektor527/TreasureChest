using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureChestUI
{
	public partial class ManageConsumersWindow : Form
	{
		public ManageConsumersWindow()
		{
			InitializeComponent();
		}

		private void CloseClicked(object sender, EventArgs e)
		{
			Close();
		}
	}
}
