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

			// Set up session picker
			_sessionPickerControl = new SessionPickerControl(_controller) { Dock = DockStyle.Fill, };
			_sessionPickerControl.DateChanged += DateChanged;
			_sessionPanel.Controls.Add(_sessionPickerControl, 0, 0);
			_sessionPanel.SetColumnSpan(_sessionPickerControl, 2);

			// Set up consumer list
			_consumersControl = new ConsumerListControl(_controller) { Dock = DockStyle.Fill };
			_consumersControl.SelectionChanged += ConsumersSelectionChanged;
			_sessionPanel.Controls.Add(_consumersControl, 0, 1);

			// Set up consumed items
			_consumedItemsControl = new ConsumedItemsControl(_controller) { Dock = DockStyle.Fill };
			_sessionPanel.Controls.Add(_consumedItemsControl, 1, 1);

			// Set up inventory
			_inventoryControl = new InventoryControl(_controller) {Dock = DockStyle.Fill};
			_inventoryPanel.Controls.Add(_inventoryControl);


			// Update UI
			_consumersControl.UpdateConsumers(SelectedSession);
			_consumedItemsControl.UpdateConsumedItems(SelectedSession);
			_inventoryControl.UpdateItems();
		}

		#region Event Handlers
		private void DateChanged(object sender, EventArgs e)
		{
			// Update UI
			_consumersControl.UpdateConsumers(SelectedSession);
			_consumedItemsControl.UpdateConsumedItems(SelectedSession);
		}

		private void ConsumeClicked(object sender, EventArgs e)
		{
			if (_inventoryControl.SelectedItems.Count == 0) return;

			if (SelectedSession == null)
				_controller.AddSession(new Session(_sessionPickerControl.Value));

			_controller.ConsumeItems(SelectedSession, _inventoryControl.SelectedItems);

			// Update UI
			_consumersControl.UpdateConsumers(SelectedSession);
			_consumedItemsControl.UpdateConsumedItems(SelectedSession);
			_inventoryControl.UpdateItems();
		}

		private void UnconsumeClicked(object sender, EventArgs e)
		{
			if (SelectedConsumedItems.Count == 0) return;

			_controller.UnconsumeItems(SelectedSession, SelectedConsumedItems);

			CheckRemoveSession();

			// Update UI
			_consumersControl.UpdateConsumers(SelectedSession);
			_consumedItemsControl.UpdateConsumedItems(SelectedSession);
			_inventoryControl.UpdateItems();
		}

		private void ConsumersSelectionChanged(Consumer consumer, bool isChecked)
		{
			if (!isChecked)
			{
				if (SelectedSession != null)
					_controller.RemoveConsumerFromSession(SelectedSession, consumer);
				CheckRemoveSession();
			}

			else
			{
				if (SelectedSession == null && CheckedConsumerCount > 0)
					_controller.AddSession(new Session(_sessionPickerControl.Value));

				_controller.AddConsumerToSession(SelectedSession, consumer);
			}

			_consumersControl.UpdateConsumers(SelectedSession);
		}
		#endregion

		private void CheckRemoveSession()
		{
			if (SelectedSession != null && _controller.GetConsumersCount(SelectedSession) == 0 && _controller.GetConsumedItemsCount(SelectedSession) == 0)
				_controller.RemoveSession(SelectedSession);
		}

		private Session SelectedSession
		{
			get { return _sessionPickerControl.SelectedSession; }
		}

		private int CheckedConsumerCount
		{
			get { return _consumersControl.CheckedConsumerCount; }
		}

		private List<Item> SelectedConsumedItems
		{
			get { return _consumedItemsControl.GetSelectedItems(_sessionPickerControl.SelectedSession); }
		}

		private readonly Controller _controller;
		private readonly InventoryControl _inventoryControl;
		private readonly ConsumerListControl _consumersControl;
		private readonly ConsumedItemsControl _consumedItemsControl;
		private readonly SessionPickerControl _sessionPickerControl;
	}
}
