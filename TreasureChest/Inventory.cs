using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	struct Item
	{
		internal string Name;
		internal float UnitPrice;

		public override string ToString()
		{
			return Name;
		}
	}

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

		public void Add(Item item)
		{
			_inventory.Add(item);
			_inventory.Sort(new InventorySorter());
		}

		public Item Get(string name)
		{
			for (int i = 0; i < _inventory.Count; ++i)
			{
				if (_inventory[i].Name == name)
					return _inventory[i];
			}

			return new Item {Name = name, UnitPrice = 0f};
		}

		public Item Get(int index)
		{
			return _inventory[index];
		}

		public Item Consume(string name)
		{
			Item item = Get(name);
			_inventory.Remove(item);
			return item;
		}

		public Item Consume(int index)
		{
			Item item = Get(index);
			_inventory.Remove(item);
			return item;
		}

		public Item Consume(Item item)
		{
			if (!_inventory.Contains(item)) return new Item();

			_inventory.Remove(item);
			return item;
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