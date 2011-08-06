using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Inventory
	{
		private class InventorySorter : IComparer<Item>
		{
			public int Compare(Item x, Item y)
			{
				if (x.Name.CompareTo(y.Name) != 0)
					return x.Name.CompareTo(y.Name);

				return -x.UnitPrice.CompareTo(y.UnitPrice);
			}
		}

		private struct Item
		{
			internal string Name;
			internal float UnitPrice;
		}

		private readonly List<Item> _inventory = new List<Item>();

		public void Add(int count, string name, float price)
		{
			for (int i = 0; i < count; ++i)
				_inventory.Add(new Item() { Name = name, UnitPrice = price });

			_inventory.Sort(new InventorySorter());
		}

		public void Add(int count, string name, float price, int units)
		{
			for (int i = 0; i < count * units; ++i)
				_inventory.Add(new Item() { Name = name, UnitPrice = price / units });

			_inventory.Sort(new InventorySorter());
		}

		public void Get(int index, out string name, out float price)
		{
			name = _inventory[index].Name;
			price = _inventory[index].UnitPrice;
		}

		public int Count()
		{
			return _inventory.Count;
		}

		public int Count(string name)
		{
			int result = 0;
			foreach (Item item in _inventory)
				if (item.Name == name) result++;

			return result;
		}

		public float Price(string name)
		{
			foreach (Item item in _inventory)
				if (item.Name == name) return item.UnitPrice;

			return 0f;
		}
	}
}