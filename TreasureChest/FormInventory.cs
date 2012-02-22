﻿using System;
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
			_inventory.Add(1, txtProductName.Text, float.Parse(txtProductPrice.Text, CultureInfo.InvariantCulture), (int)numProductCount.Value);

			// Update interface
			lstInventory.Items.Clear();
			for (int i = 0; i < _inventory.Count(); ++i)
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
			Item item = _inventory.Get(index);

			ListViewItem lvitem = new ListViewItem(new string[] { item.Name, item.UnitPrice.ToString(CultureInfo.InvariantCulture) });
			lstInventory.Items.Add(lvitem);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
		}
	}
}
