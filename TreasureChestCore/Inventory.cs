using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChestCore
{
	public class Item
	{
		public string Name;
		public float UnitPrice;

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

	public class Inventory
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

		internal void Add(int count, string name, float price)
		{
			if (count < 0) return;

			for (int i = 0; i < count; ++i)
				_inventory.Add(new Item() { Name = name, UnitPrice = price });

			_inventory.Sort(new InventorySorter());
		}

		internal void Add(int count, string name, float price, int units)
		{
			if (count < 0 || units < 0) return;

			for (int i = 0; i < count * units; ++i)
				_inventory.Add(new Item() { Name = name, UnitPrice = price / units });

			_inventory.Sort(new InventorySorter());
		}

		internal void Add(Item item)
		{
			_inventory.Add(item);
			_inventory.Sort(new InventorySorter());
		}

		internal Item Get(string name)
		{
			for (int i = 0; i < _inventory.Count; ++i)
			{
				if (_inventory[i].Name == name)
					return _inventory[i];
			}

			return null;
		}

		internal Item Get(int index)
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

		internal Item Consume(string name)
		{
			Item item = Get(name);
			_inventory.Remove(item);
			return item;
		}

		internal Item Consume(int index)
		{
			Item item = Get(index);
			_inventory.Remove(item);
			return item;
		}

		internal Item Consume(Item item)
		{
			if (!_inventory.Contains(item)) return null;

			_inventory.Remove(item);
			return item;
		}

		internal void Remove(string name)
		{
			Item item = GetCheapest(name);
			_inventory.Remove(item);
		}

		internal int Count()
		{
			return _inventory.Count;
		}

		internal int Count(string name)
		{
			int result = 0;
			foreach (Item item in _inventory)
				if (item.Name == name) result++;

			return result;
		}

		internal float Price(string name)
		{
			foreach (Item item in _inventory)
				if (item.Name == name) return item.UnitPrice;

			return 0f;
		}

		internal Dictionary<KeyValuePair<string, float>, int> GetStacks()
		{
			Dictionary<KeyValuePair<string, float>, int> stacks = new Dictionary<KeyValuePair<string, float>, int>();
			foreach (Item item in _inventory)
			{
				KeyValuePair<string, float> key = new KeyValuePair<string, float>(item.Name, item.UnitPrice);
				if (stacks.Keys.Contains(key))
					stacks[key]++;
				else
					stacks.Add(key, 1);
			}
			return stacks;
		}
	}
}