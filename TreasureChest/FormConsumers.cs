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
	internal partial class FormConsumers : Form
	{
		private List<Consumer> _consumers;
		public FormConsumers(List<Consumer> consumers)
		{
			InitializeComponent();

			_consumers = consumers;
		}

		private void FormConsumers_Load(object sender, EventArgs e)
		{
			UpdateCredits();
		}

		private void btnDeposit_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtWim.Text))
			{
				float amount;
				if (float.TryParse(txtWim.Text, out amount))
					Consumer.Wim.Deposit(amount);
				txtWim.Text = "";
			}

			if (!string.IsNullOrEmpty(txtBart.Text))
			{
				float amount;
				if (float.TryParse(txtBart.Text, out amount))
					Consumer.Bart.Deposit(amount);
				txtBart.Text = "";
			}

			if (!string.IsNullOrEmpty(txtJo.Text))
			{
				float amount;
				if (float.TryParse(txtJo.Text, out amount))
					Consumer.Jo.Deposit(amount);
				txtJo.Text = "";
			}

			if (!string.IsNullOrEmpty(txtKoen.Text))
			{
				float amount;
				if (float.TryParse(txtKoen.Text, out amount))
					Consumer.Koen.Deposit(amount);
				txtKoen.Text = "";
			}

			if (!string.IsNullOrEmpty(txtFrederik.Text))
			{
				float amount;
				if (float.TryParse(txtFrederik.Text, out amount))
					Consumer.Frederik.Deposit(amount);
				txtFrederik.Text = "";
			}

			if (!string.IsNullOrEmpty(txtChristoph.Text))
			{
				float amount;
				if (float.TryParse(txtChristoph.Text, out amount))
					Consumer.Christoph.Deposit(amount);
				txtChristoph.Text = "";
			}

			if (!string.IsNullOrEmpty(txtChristof.Text))
			{
				float amount;
				if (float.TryParse(txtChristof.Text, out amount))
					Consumer.Christof.Deposit(amount);
				txtChristof.Text = "";
			}

			UpdateCredits();
		}

		private void UpdateCredits()
		{
			lblWim.Text = Consumer.Wim.Credit.ToString();
			lblWim.ForeColor = Consumer.Wim.Credit <= 0 ? Color.Red : Color.Black;

			lblBart.Text = Consumer.Bart.Credit.ToString();
			lblBart.ForeColor = Consumer.Bart.Credit <= 0 ? Color.Red : Color.Black;

			lblJo.Text = Consumer.Jo.Credit.ToString();
			lblJo.ForeColor = Consumer.Jo.Credit <= 0 ? Color.Red : Color.Black;

			lblKoen.Text = Consumer.Koen.Credit.ToString();
			lblKoen.ForeColor = Consumer.Koen.Credit <= 0 ? Color.Red : Color.Black;

			lblFrederik.Text = Consumer.Frederik.Credit.ToString();
			lblFrederik.ForeColor = Consumer.Frederik.Credit <= 0 ? Color.Red : Color.Black;

			lblChristoph.Text = Consumer.Christoph.Credit.ToString();
			lblChristoph.ForeColor = Consumer.Christoph.Credit <= 0 ? Color.Red : Color.Black;

			lblChristof.Text = Consumer.Christof.Credit.ToString();
			lblChristof.ForeColor = Consumer.Christof.Credit <= 0 ? Color.Red : Color.Black;
		}
	}
}
