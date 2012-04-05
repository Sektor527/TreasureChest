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
	public partial class ConsumedItemsControl : UserControl
	{
		public ConsumedItemsControl(Controller controller)
		{
			_controller = controller;
			InitializeComponent();
		}

		internal void UpdateConsumedItems(Session session)
		{
			lstConsumed.Items.Clear();
			if (session == null)
			{
				_consumedTotal.Text = String.Format("Cost: --");
				return;
			}

			float totalCost = 0f;

			for (int i = 0; i < _controller.GetConsumedItemsCount(session); ++i)
			{
				Item item = _controller.GetItemFromSession(session, i);
				lstConsumed.Items.Add(item);
				totalCost += item.UnitPrice;
			}

			_consumedTotal.Text = String.Format("Cost: {0}", totalCost.ToString("#.##"));
		}

		internal List<Item> SelectedItems
		{
		  get { return lstConsumed.SelectedItems.OfType<Item>().ToList(); }
		}

		private Controller _controller;
	}
}
