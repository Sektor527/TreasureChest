using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Item
	{
		internal string Name;
		internal float UnitPrice;

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (obj.GetType() != typeof(Item)) return false;

			return Name.Equals(((Item) obj).Name) && UnitPrice.Equals(((Item) obj).UnitPrice);
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

			return null;
		}

		public Item Get(int index)
		{
			if (index < 0 || index > _inventory.Count) return null;

			return _inventory[index];
		}

		private Item GetCheapest(string name)
		{
			for (int i = _inventory.Count - 1; i >= 0; --i)
			{
				if (_inventory[i].Name == name)
					return _inventory[i];
			}

			return null;
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
			if (!_inventory.Contains(item)) return null;

			_inventory.Remove(item);
			return item;
		}

		public void Remove(string name)
		{
			Item item = GetCheapest(name);
			_inventory.Remove(item);
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