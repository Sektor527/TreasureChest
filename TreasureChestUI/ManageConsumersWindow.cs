using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreasureChestCore;

namespace TreasureChestUI
{
	public partial class ManageConsumersWindow : Form
	{
		public ManageConsumersWindow(Controller controller)
		{
			_controller = controller;
			InitializeComponent();

			UpdateList();
		}

		private readonly Controller _controller;

		private void CloseClicked(object sender, EventArgs e)
		{
			Close();
		}

		private void ConsumerRenamed(object sender, LabelEditEventArgs e)
		{
			ListViewItem item = _list.Items[e.Item];
			Consumer consumer = item.Tag as Consumer;
			if (consumer == null) return;
			if (e.Label == null) return;

			consumer.Name = e.Label;
		}

		private void AddClicked(object sender, EventArgs e)
		{
			Consumer c = new Consumer("");
			_controller.Consumers.Add(c);
			UpdateList();
			ItemWithName("").BeginEdit();
		}

		private void RemoveClicked(object sender, EventArgs e)
		{
			ListViewItem item = _list.SelectedItems[0];
			if (item == null) return;

			Consumer consumer = item.Tag as Consumer;
			if (consumer == null) return;

			_controller.Consumers.Remove(consumer);
			UpdateList();
		}

		private void UpdateList()
		{
			_list.Items.Clear();
			foreach (Consumer c in _controller.Consumers)
			{
				_list.Items.Add(new ListViewItem(c.Name) { Tag = c });
			}
		}

		private ListViewItem ItemWithName(string name)
		{
			foreach (ListViewItem item in _list.Items)
			{
				if (item.Text == name)
					return item;
			}

			return null;
		}
	}
}
