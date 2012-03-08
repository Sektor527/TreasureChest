using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureChest
{
	partial class FormMain : Form
	{
		private Controller _controller;

		public FormMain(Controller controller)
		{
			InitializeComponent();

			_controller = controller;
		}

		private void btnSessions_Click(object sender, EventArgs e)
		{
			FormSessions form = new FormSessions(_controller);
			form.ShowDialog();
		}

		private void btnInventory_Click(object sender, EventArgs e)
		{
			FormInventory form = new FormInventory(_controller);
			form.ShowDialog();
		}

		private void btnConsumers_Click(object sender, EventArgs e)
		{
			FormConsumers form = new FormConsumers(_controller);
			form.ShowDialog();
		}
	}
}
