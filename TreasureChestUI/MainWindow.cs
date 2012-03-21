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
		}

		private void DateChanged(object sender, EventArgs e)
		{
			UpdateConsumers();
		}

		private void UpdateConsumers()
		{
			foreach (Control control in _consumerPanel.Controls)
			{
				ConsumerControl consumerControl = control as ConsumerControl;
				if (consumerControl == null) continue;

				consumerControl.Selected = SelectedSession != null && _controller.IsConsumerInSession(SelectedSession, consumerControl.Consumer);
			}
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
				CheckCreateSession();
				_controller.AddConsumerToSession(SelectedSession, control.Consumer);
			}
		}

		private void CheckCreateSession()
		{
			if (SelectedSession == null && CheckedConsumerCount > 0)
				_controller.AddSession(new Session(dateTimePicker1.Value));
		}

		private void CheckRemoveSession()
		{
			if (SelectedSession != null && CheckedConsumerCount == 0)
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

		private Controller _controller;
	}
}
