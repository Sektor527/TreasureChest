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
	public partial class ConsumerControl : UserControl
	{
		public ConsumerControl(Controller controller)
		{
			_controller = controller;
			InitializeComponent();
		}

		public Consumer Consumer { get { return Tag as Consumer; } }
		public string ConsumerName { set { _checkbox.Text = value; } }
		public float Credit { set { _credit.Text = value.ToString("0.00"); _credit.ForeColor = value <= 0f ? Color.Red : Color.Black; } }
		public bool Selected { set { _checkbox.Checked = value; } get { return _checkbox.Checked; } }

		private void Deposit(object sender, EventArgs e)
		{
			_entryField.Visible = true;
			_depositValue.Text = "";
			_depositValue.Focus();
		}

		internal void UpdateCredit()
		{
			Credit = ((Consumer) Tag).Credit;
		}

		internal void UpdateName()
		{
			ConsumerName = ((Consumer) Tag).Name;
		}

		private Controller _controller;

		private void SubmitDeposit(object sender, EventArgs e)
		{
			float amount;
			if (!float.TryParse(_depositValue.Text, out amount)) return;

			_controller.Deposit((Consumer)Tag, amount);
			_entryField.Visible = false;
			Credit = ((Consumer)Tag).Credit;
		}

		private void CancelDeposit(object sender, EventArgs e)
		{
			_entryField.Visible = false;
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SubmitDeposit(sender, e);
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Escape)
			{
				CancelDeposit(sender, e);
				e.Handled = true;
			}
		}

		internal EventHandler CheckChanged;
		private void CheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (CheckChanged != null)
				CheckChanged(this, e);
		}
	}
}
