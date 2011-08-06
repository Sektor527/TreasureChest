using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureChest
{
	internal partial class FormInventory : Form
	{
		private Inventory _inventory;

		public FormInventory(Inventory inventory)
		{
			InitializeComponent();

			_inventory = inventory;
		}

		private void FormInventory_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < _inventory.Count(); ++i)
				AddListViewItem(i);

			lstInventory.Columns[0].Width = -1;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// Update list
			int lastCount = _inventory.Count();

			_inventory.Add(1, txtProductName.Text, float.Parse(txtProductPrice.Text, CultureInfo.InvariantCulture), (int)numProductCount.Value);

			int newCount = _inventory.Count();

			for (int i = lastCount; i < newCount; ++i)
				AddListViewItem(i);

			lstInventory.Columns[0].Width = -1;

			// Rest fields
			txtProductName.Text = "";
			txtProductPrice.Text = "";
			numProductCount.Value = 1;

			txtProductName.Focus();
		}

		private void AddListViewItem(int index)
		{
			string name;
			float price;

			_inventory.Get(index, out name, out price);

			ListViewItem item = new ListViewItem(new string[] { name, price.ToString(CultureInfo.InvariantCulture) });
			lstInventory.Items.Add(item);
		}
	}
}
