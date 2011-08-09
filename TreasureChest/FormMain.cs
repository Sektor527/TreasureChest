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
		private List<Session> _sessions;
		private Inventory _inventory;

		public FormMain(List<Session> sessions, Inventory inventory)
		{
			InitializeComponent();

			_sessions = sessions;
			_inventory = inventory;
		}

		private void btnSessions_Click(object sender, EventArgs e)
		{
			FormSessions form = new FormSessions(_sessions, _inventory);
			form.ShowDialog();
		}

		private void btnInventory_Click(object sender, EventArgs e)
		{
			FormInventory form = new FormInventory(_inventory);
			form.ShowDialog();
		}

		private void btnConsumers_Click(object sender, EventArgs e)
		{
			FormConsumers form = new FormConsumers();
			form.ShowDialog();
		}
	}
}
