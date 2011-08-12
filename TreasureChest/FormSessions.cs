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
	partial class FormSessions : Form
	{
		private List<Session> _sessions;
		private Inventory _stash;

		public FormSessions(List<Session> sessions, Inventory stash)
		{
			InitializeComponent();

			_sessions = sessions;
			_sessions.Sort();

			_stash = stash;
		}

		private void FormSessions_Load(object sender, EventArgs e)
		{
			foreach (Session s in _sessions)
				lstSessions.Items.Add(s);

			UpdateSessionData();
		}

		private void UpdateSessionData()
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null)
			{
				groupBox1.Enabled = false;
				groupBox2.Enabled = false;
				dateTimePicker.Enabled = false;
				return;
			}

			groupBox1.Enabled = true;
			groupBox2.Enabled = true;
			dateTimePicker.Enabled = true;

			chkConsumerWim.Checked = s.Consumers.Contains(Consumer.Wim);
			chkConsumerBart.Checked = s.Consumers.Contains(Consumer.Bart);
			chkConsumerJo.Checked = s.Consumers.Contains(Consumer.Jo);
			chkConsumerKoen.Checked = s.Consumers.Contains(Consumer.Koen);
			chkConsumerFrederik.Checked = s.Consumers.Contains(Consumer.Frederik);
			chkConsumerChristoph.Checked = s.Consumers.Contains(Consumer.Christoph);
			chkConsumerChristof.Checked = s.Consumers.Contains(Consumer.Christof);

			dateTimePicker.Value = s.Date;

			lstConsumable.Items.Clear();
			lstConsumed.Items.Clear();

			for (int i = 0; i < _stash.Count(); ++i)
			{
				Item item = _stash.Get(i);
				lstConsumable.Items.Add(item);
			}

			for (int i = 0; i < s.ConsumedItems.Count(); ++i)
			{
				Item item = s.ConsumedItems.Get(i);
				lstConsumed.Items.Add(item);
			}
		}

		private void btnAddSession_Click(object sender, EventArgs e)
		{
			Session s = new Session();
			_sessions.Add(s);
			_sessions.Sort();
			lstSessions.Items.Insert(_sessions.IndexOf(s), s);
			lstSessions.SelectedItem = s;
		}

		private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSessionData();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null) return;

			s.Date = dateTimePicker.Value;

			_sessions.Sort();
			lstSessions.Items.Remove(s);
			lstSessions.Items.Insert(_sessions.IndexOf(s), s);
			lstSessions.SelectedItem = s;
		}

		private void btnDeleteSession_Click(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null) return;

			_sessions.Remove(s);
			lstSessions.Items.Remove(s);
		}

		private void OnConsumerCheckChanged(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if ((sender as CheckBox).Checked)
			{
				if (sender == chkConsumerWim) s.Add(Consumer.Wim);
				if (sender == chkConsumerBart) s.Add(Consumer.Bart);
				if (sender == chkConsumerJo) s.Add(Consumer.Jo);
				if (sender == chkConsumerKoen) s.Add(Consumer.Koen);
				if (sender == chkConsumerChristof) s.Add(Consumer.Christof);
				if (sender == chkConsumerChristoph) s.Add(Consumer.Christoph);
				if (sender == chkConsumerFrederik) s.Add(Consumer.Frederik);
			}
			else
			{
				if (sender == chkConsumerWim) s.Remove(Consumer.Wim);
				if (sender == chkConsumerBart) s.Remove(Consumer.Bart);
				if (sender == chkConsumerJo) s.Remove(Consumer.Jo);
				if (sender == chkConsumerKoen) s.Remove(Consumer.Koen);
				if (sender == chkConsumerChristof) s.Remove(Consumer.Christof);
				if (sender == chkConsumerChristoph) s.Remove(Consumer.Christoph);
				if (sender == chkConsumerFrederik) s.Remove(Consumer.Frederik);
			}
		}

		private void btnConsume_Click(object sender, EventArgs e)
		{
			if (lstConsumable.SelectedItems.Count == 0) return;

			Session s = lstSessions.SelectedItem as Session;

			List<Item> selection = new List<Item>();
			foreach (var selected in lstConsumable.SelectedItems)
			{
				selection.Add((Item) selected);
			}

			foreach (Item item in selection)
			{
				_stash.Consume(item);
				lstConsumable.Items.Remove(item);

				s.ConsumedItems.Add(item);
				lstConsumed.Items.Add(item);

				foreach (Consumer c in s.Consumers)
					c.Withdraw(item.UnitPrice / s.Consumers.Count);
			}
		}

		private void btnUnconsume_Click(object sender, EventArgs e)
		{
			if (lstConsumed.SelectedItems.Count == 0) return;

			Session s = lstSessions.SelectedItem as Session;

			List<Item> selection = new List<Item>();
			foreach (var selected in lstConsumed.SelectedItems)
			{
				selection.Add((Item)selected);
			}

			foreach (Item item in selection)
			{
				s.ConsumedItems.Consume(item);
				lstConsumed.Items.Remove(item);

				_stash.Add(item);
				lstConsumable.Items.Add(item);

				foreach (Consumer c in s.Consumers)
					c.Deposit(item.UnitPrice / s.Consumers.Count);
			}
		}
	}
}
