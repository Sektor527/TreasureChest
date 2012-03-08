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
		private Controller _controller;

		public FormSessions(Controller controller)
		{
			InitializeComponent();

			_controller = controller;

			foreach (Consumer c in _controller.Consumers)
			{
				CheckBox checkbox = new CheckBox();
				checkbox.Text = c.Name;
				checkbox.Tag = c;
				checkbox.CheckedChanged += OnConsumerCheckChanged;
				checkbox.Margin = new Padding(0);

				_consumersPanel.Controls.Add(checkbox);
			}
		}

		private void FormSessions_Load(object sender, EventArgs e)
		{
			foreach (Session s in _controller.Sessions)
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

			foreach (CheckBox checkbox in _consumersPanel.Controls)
			{
				Consumer c = checkbox.Tag as Consumer;
				if (c == null) continue; 

				checkbox.Checked = _controller.IsConsumerInSession(s, c);
			}

			dateTimePicker.Value = s.Date;

			lstConsumable.Items.Clear();
			lstConsumed.Items.Clear();

			for (int i = 0; i < _controller.GetInventorySize(); ++i)
			{
				Item item = _controller.GetItemFromInventory(i);
				lstConsumable.Items.Add(item);
			}

			for (int i = 0; i < _controller.GetConsumedItemsCount(s); ++i)
			{
				Item item = _controller.GetItemFromSession(s,i);
				lstConsumed.Items.Add(item);
			}
		}

		private void btnAddSession_Click(object sender, EventArgs e)
		{
			Session s = new Session();
			_controller.Sessions.Add(s);
			_controller.Sessions.Sort();
			lstSessions.Items.Insert(_controller.Sessions.IndexOf(s), s);
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

			_controller.Sessions.Sort();
			lstSessions.Items.Remove(s);
			lstSessions.Items.Insert(_controller.Sessions.IndexOf(s), s);
			lstSessions.SelectedItem = s;
		}

		private void btnDeleteSession_Click(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null) return;

			_controller.Sessions.Remove(s);
			lstSessions.Items.Remove(s);
		}

		private void OnConsumerCheckChanged(object sender, EventArgs e)
		{
			CheckBox checkbox = sender as CheckBox;
			if (checkbox == null) return;

			Session s = lstSessions.SelectedItem as Session;
			Consumer consumer = checkbox.Tag as Consumer;

			if (checkbox.Checked)
				_controller.AddConsumerToSession(s, consumer);
			else
				_controller.RemoveConsumerFromSession(s, consumer);
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

			_controller.ConsumeItems(s, selection);

			foreach (Item item in selection)
			{
				lstConsumable.Items.Remove(item);
				lstConsumed.Items.Add(item);
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

			_controller.UnconsumeItems(s, selection);

			foreach (Item item in selection)
			{
				lstConsumed.Items.Remove(item);
				lstConsumable.Items.Add(item);
			}
		}
	}
}
