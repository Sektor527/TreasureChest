using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureChest
{
	internal partial class ConsumerCredit : UserControl
	{
		public ConsumerCredit()
		{
			InitializeComponent();
		}

		internal string ConsumerName
		{
			set
			{
				_name.Text = value;
			}
		}

		internal float Deposit
		{
			get
			{
				float amount;
				if (float.TryParse(_deposit.Text, out amount))
					return amount;

				return 0f;
			}
			
			set
			{
				_deposit.Text = value == 0f ? "" : value.ToString(CultureInfo.CurrentUICulture);
			}
		}

		internal float Credit
		{
			set 
			{ 
				_credit.Text = value.ToString(CultureInfo.CurrentUICulture);
				_credit.ForeColor = value <= 0 ? Color.Red : Color.Black;
			}
		}
	}
}
