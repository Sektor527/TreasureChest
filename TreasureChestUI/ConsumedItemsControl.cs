using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
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

			AddListViewItems(session);

			float totalCost = 0f;

			for (int i = 0; i < _controller.GetConsumedItemsCount(session); ++i)
			{
				Item item = _controller.GetItemFromSession(session, i);
				totalCost += item.UnitPrice;
			}

			_consumedTotal.Text = String.Format("Cost: {0}", totalCost.ToString("#.00"));
		}

		private void AddListViewItems(Session session)
		{
			Dictionary<KeyValuePair<string, float>, int> stacks = _controller.GetStacksFromSession(session);
			foreach (KeyValuePair<string, float> item in stacks.Keys)
			{
				ListViewItem lvitem = new ListViewItem(new string[] { stacks[item].ToString(CultureInfo.InvariantCulture), item.Key, item.Value.ToString(CultureInfo.InvariantCulture) });
				lstConsumed.Items.Add(lvitem);
			}

			lstConsumed.Columns[0].Width = -1;
			lstConsumed.Columns[1].Width = -1;
		}

		internal List<Item> GetSelectedItems(Session session)
		{
			List<Item> result = new List<Item>();
			foreach (ListViewItem listViewItem in lstConsumed.SelectedItems)
			{
				result.Add(_controller.GetItemFromSession(session, listViewItem.SubItems[1].Text));
			}
			return result;
		}

		private Controller _controller;
	}
}
