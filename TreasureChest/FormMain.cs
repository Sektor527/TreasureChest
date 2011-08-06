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

		public FormMain(List<Session> sessions)
		{
			InitializeComponent();

			_sessions = sessions;
		}

		private void btnSessions_Click(object sender, EventArgs e)
		{
			FormSessions form = new FormSessions(ref _sessions);
			form.ShowDialog();
		}

		private void btnInventory_Click(object sender, EventArgs e)
		{
			FormInventory form = new FormInventory();
			form.ShowDialog();
		}
	}
}
