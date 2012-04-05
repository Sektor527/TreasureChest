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
	public partial class InventoryControl : UserControl
	{
		public InventoryControl(Controller controller)
		{
			_controller = controller;
			InitializeComponent();

			UpdateItems();
		}

		public List<Item> SelectedItems
		{
			get
			{
				List<Item> result = new List<Item>();
				foreach (ListViewItem listViewItem in lstInventory.SelectedItems)
				{
					result.Add(_controller.GetItemFromInventory(listViewItem.SubItems[0].Text));
				}
				return result;
			}
		}

		public void UpdateItems()
		{
			lstInventory.Items.Clear();

			for (int i = 0; i < _controller.GetInventorySize(); ++i)
				AddListViewItem(i);

			lstInventory.Columns[0].Width = -1;
			lstInventory.Columns[1].Width = -1;
		}

		private void AddItem(object sender, EventArgs e)
		{
			// Update list
			_controller.AddItemToInventory(1, txtProductName.Text, float.Parse(txtProductPrice.Text, CultureInfo.InvariantCulture), (int)numProductCount.Value);

			// Update interface
			UpdateItems();

			// Reset fields
			txtProductName.Text = "";
			txtProductPrice.Text = "";
			numProductCount.Value = 1;

			txtProductName.Focus();
		}

		private void AddListViewItem(int index)
		{
			Item item = _controller.GetItemFromInventory(index);

			ListViewItem lvitem = new ListViewItem(new string[] { item.Name, item.UnitPrice.ToString(CultureInfo.InvariantCulture) });
			lstInventory.Items.Add(lvitem);
		}

		private void DeleteItem(object sender, EventArgs e)
		{
			// Update list
			foreach (ListViewItem item in lstInventory.SelectedItems)
				_controller.RemoveItemFromInventory(item.Text);

			// Update interface
			UpdateItems();

			lstInventory.Focus();
		}

		private Controller _controller;
	}
}
