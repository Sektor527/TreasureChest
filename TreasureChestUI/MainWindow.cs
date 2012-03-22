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
	public partial class MainWindow : Form
	{
		public MainWindow(Controller controller)
		{
			_controller = controller;

			InitializeComponent();

			_inventoryPanel.Controls.Add(new InventoryControl(_controller) { Dock = DockStyle.Fill });

			foreach (Consumer c in _controller.Consumers)
			{
				ConsumerControl consumerControl = new ConsumerControl(_controller) {Name = c.Name, Credit = c.Credit, Tag = c};
				_consumerPanel.Controls.Add(consumerControl);
				consumerControl.CheckChanged += ConsumerCheckChanged;
			}

			UpdateConsumers();
			UpdateConsumedItems();
			UpdateInventory();
		}

		private void DateChanged(object sender, EventArgs e)
		{
			UpdateConsumers();
			UpdateConsumedItems();
			UpdateInventory();
		}

		private void Consume(object sender, EventArgs e)
		{
			InventoryControl inventory = _inventoryPanel.Controls[0] as InventoryControl;
			if (inventory == null) return;
			if (inventory.SelectedItems.Count == 0) return;

			if (SelectedSession == null)
				_controller.AddSession(new Session(dateTimePicker1.Value));

			_controller.ConsumeItems(SelectedSession, inventory.SelectedItems);

			UpdateConsumers();
			UpdateConsumedItems();
			UpdateInventory();
		}

		private void Unconsume(object sender, EventArgs e)
		{
			InventoryControl inventory = _inventoryPanel.Controls[0] as InventoryControl;
			if (inventory == null) return;
			if (SelectedConsumedItems.Count == 0) return;

			_controller.UnconsumeItems(SelectedSession, SelectedConsumedItems);

			CheckRemoveSession();

			UpdateConsumers();
			UpdateConsumedItems();
			UpdateInventory();
		}

		private void UpdateConsumers()
		{
			foreach (Control control in _consumerPanel.Controls)
			{
				ConsumerControl consumerControl = control as ConsumerControl;
				if (consumerControl == null) continue;

				consumerControl.Selected = SelectedSession != null && _controller.IsConsumerInSession(SelectedSession, consumerControl.Consumer);
				consumerControl.UpdateCredit();
			}
		}

		private void UpdateConsumedItems()
		{
			lstConsumed.Items.Clear();
			if (SelectedSession == null) return;

			for (int i = 0; i < _controller.GetConsumedItemsCount(SelectedSession); ++i)
			{
				lstConsumed.Items.Add(_controller.GetItemFromSession(SelectedSession, i));
			}
		}

		private void UpdateInventory()
		{
			InventoryControl inventory = _inventoryPanel.Controls[0] as InventoryControl;
			if (inventory == null) return;

			inventory.UpdateItems();
		}

		private void ConsumerCheckChanged(object sender, EventArgs eventArgs)
		{
			ConsumerControl control = sender as ConsumerControl;
			if (control == null) return;

			if (!control.Selected)
			{
				if (SelectedSession != null)
					_controller.RemoveConsumerFromSession(SelectedSession, control.Consumer);
				CheckRemoveSession();
			}

			else
			{
				if (SelectedSession == null && CheckedConsumerCount > 0)
					_controller.AddSession(new Session(dateTimePicker1.Value));

				_controller.AddConsumerToSession(SelectedSession, control.Consumer);
			}

			UpdateConsumers();
		}

		private void CheckRemoveSession()
		{
			if (SelectedSession != null && _controller.GetConsumersCount(SelectedSession) == 0 && _controller.GetConsumedItemsCount(SelectedSession) == 0)
				_controller.RemoveSession(SelectedSession);
		}

		private Session SelectedSession
		{
			get { return _controller.GetSession(dateTimePicker1.Value); }
		}

		private int CheckedConsumerCount
		{
			get { return _consumerPanel.Controls.OfType<ConsumerControl>().Count(consumerControl => consumerControl.Selected); }
		}

		private List<Item> SelectedConsumedItems
		{
			get { return lstConsumed.SelectedItems.OfType<Item>().ToList(); }
		}

		private Controller _controller;
	}
}
