using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreasureChestCore;

namespace TreasureChestUI
{
	public partial class ConsumerListControl : UserControl
	{
		internal delegate void SelectionChangedDelegate(Consumer consumer, bool isChecked);
		internal event SelectionChangedDelegate SelectionChanged;

		public ConsumerListControl(Controller controller)
		{
			_controller = controller;
			InitializeComponent();
			AddRemoveConsumers();
		}

		internal void UpdateConsumers(Session session)
		{
			_session = session;

			foreach (Control control in _consumerPanel.Controls)
			{
				ConsumerControl consumerControl = control as ConsumerControl;
				if (consumerControl == null) continue;

				consumerControl.Selected = session != null && _controller.IsConsumerInSession(session, consumerControl.Consumer);
				consumerControl.UpdateCredit();
				consumerControl.UpdateName();
			}
		}

		internal int CheckedConsumerCount
		{
			get { return _consumerPanel.Controls.OfType<ConsumerControl>().Count(consumerControl => consumerControl.Selected); }
		}

		private void AddRemoveConsumers()
		{
			_consumerPanel.Controls.Clear();
			foreach (Consumer c in _controller.Consumers)
			{
				ConsumerControl consumerControl = new ConsumerControl(_controller) { ConsumerName = c.Name, Credit = c.Credit, Tag = c };
				_consumerPanel.Controls.Add(consumerControl);
				consumerControl.CheckChanged += ConsumerCheckChanged;
			}
		}

		private void ConsumerCheckChanged(object sender, EventArgs eventArgs)
		{
			if (SelectionChanged == null) return;

			ConsumerControl control = sender as ConsumerControl;
			if (control == null) return;

			SelectionChanged(control.Consumer, control.Selected);
		}

		private void ManageConsumers(object sender, EventArgs e)
		{
			var window = new ManageConsumersWindow(_controller);
			window.ShowDialog();
			AddRemoveConsumers();
			UpdateConsumers(_session);
		}

		private Controller _controller;
		private Session _session;
	}
}
