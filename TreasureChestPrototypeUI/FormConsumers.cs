using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TreasureChestCore;

namespace TreasureChest
{
	internal partial class FormConsumers : Form
	{
		Controller _controller;
		public FormConsumers(Controller controller)
		{	
			InitializeComponent();

			_controller = controller;

			foreach (Consumer c in controller.Consumers)
			{
				ConsumerCredit ctrl = new ConsumerCredit();
				ctrl.Tag = c;

				_consumerPanel.Controls.Add(ctrl);
			}
		}

		private void FormConsumers_Load(object sender, EventArgs e)
		{
			UpdateCredits();
		}

		private void Deposit(object sender, EventArgs e)
		{
			foreach (ConsumerCredit c in _consumerPanel.Controls)
			{
				Consumer consumer = c.Tag as Consumer;
				_controller.Deposit(consumer, c.Deposit);
			}

			UpdateCredits();
		}

		private void UpdateCredits()
		{
			foreach (ConsumerCredit c in _consumerPanel.Controls)
			{
				Consumer consumer = c.Tag as Consumer;
				if (consumer == null) continue;

				c.ConsumerName = consumer.Name;
				c.Credit = consumer.Credit;
				c.Deposit = 0f;
			}
		}
	}
}
