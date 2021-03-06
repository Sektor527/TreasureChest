﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using TreasureChestCore;

namespace TreasureChestUnitTests
{
	[TestFixture]
	public class InventoryTests
	{
		[Test]
		public void InventorySorting()
		{
			Inventory i = new Inventory();

			i.Add(1, "Lays Peper & Zout", 3.20f);
			i.Add(1, "Hopus", 2.40f, 2);

			Item item;

			item = i.Get(0);
			Assert.AreEqual("Hopus", item.Name);
			Assert.IsTrue(AreEqualFloat(1.20f, item.UnitPrice));

			item = i.Get(1);
			Assert.AreEqual("Hopus", item.Name);
			Assert.IsTrue(AreEqualFloat(1.20f, item.UnitPrice));

			item = i.Get(2);
			Assert.AreEqual("Lays Peper & Zout", item.Name);
			Assert.IsTrue(AreEqualFloat(3.20f, item.UnitPrice));
		}

		[Test]
		public void Counts()
		{
			Inventory i = new Inventory();

			i.Add(1, "Lays Peper & Zout", 3.20f);
			i.Add(1, "Hopus", 7.20f, 6);

			// Counts
			Assert.AreEqual(7, i.Count());
			Assert.AreEqual(1, i.Count("Lays Peper & Zout"));
			Assert.AreEqual(6, i.Count("Hopus"));

			// Non-existing Counts
			Assert.AreEqual(0, i.Count("Grimbergen kaas"));

			// Zero counts, units
			i.Add(0, "ZeroCount", 10);
			Assert.AreEqual(0, i.Count("ZeroCount"));

			i.Add(3, "ZeroUnits", 10, 0);
			Assert.AreEqual(0, i.Count("ZeroUnits"));

			i.Add(0, "BothZero", 10, 0);
			Assert.AreEqual(0, i.Count("BothZero"));

			// Negative counts, units
			i.Add(-1, "NegativeCount", 10);
			Assert.AreEqual(0, i.Count("NegativeCount"));

			i.Add(3, "NegativeUnits", 10, -1);
			Assert.AreEqual(0, i.Count("NegativeUnits"));

			i.Add(-1, "BothNegative", 10, -1);
			Assert.AreEqual(0, i.Count("BothNegative"));
		}

		[Test]
		public void Prices()
		{
			Inventory i = new Inventory();

			i.Add(1, "Lays Peper & Zout", 3.20f);
			i.Add(1, "Hopus", 7.20f, 6);

			// Prices
			Assert.IsTrue(AreEqualFloat(3.20f, i.Price("Lays Peper & Zout")));
			Assert.IsTrue(AreEqualFloat(1.20f, i.Price("Hopus")));

			// Non-existing Prices
			Assert.IsTrue(AreEqualFloat(0f, i.Price("Grimbergen kaas")));
		}

		[Test]
		public void HighestPricePerProduct()
		{
			Inventory i = new Inventory();

			i.Add(1, "Lays Peper & Zout", 3.20f);
			i.Add(1, "Lays Peper & Zout", 2.60f);
			
			Assert.IsTrue(AreEqualFloat(3.20f, i.Price("Lays Peper & Zout")));

			i.Add(2, "Hopus", 3.00f);
			i.Add(1, "Hopus", 4.00f);
			i.Add(3, "Hopus", 5.00f);

			Assert.IsTrue(AreEqualFloat(5.00f, i.Price("Hopus")));
		}

		[Test]
		public void Consume()
		{
			Inventory i = new Inventory();

			i.Add(2, "Hopus", 3.00f);
			i.Add(2, "Lays Peper & Zout", 3.20f);

			Item item1 = i.Consume("Hopus");
			Assert.AreEqual(3, i.Count());
			Assert.AreEqual("Hopus", item1.Name);

			Item item2 = i.Consume(0);
			Assert.AreEqual(2, i.Count());
			Assert.AreEqual("Hopus", item2.Name);

			Item item3 = i.Consume(i.Get("Lays Peper & Zout"));
			Assert.AreEqual(1, i.Count());
			Assert.AreEqual("Lays Peper & Zout", item3.Name);
		}

		[Test]
		public void Consume_InvalidItems()
		{
			Inventory i = new Inventory();
			i.Add(2, "Hopus", 3.00f);

			Item item1 = i.Consume("Wrong");
			Assert.IsNull(item1);
			Assert.AreEqual(2, i.Count());

			Item item2 = i.Consume(6);
			Assert.IsNull(item2);
			Assert.AreEqual(2, i.Count());

			Item item3 = i.Consume(new Item());
			Assert.IsNull(item3);
			Assert.AreEqual(2, i.Count());
		}

		[Test]
		public void RemoveFromInventory()
		{
			Inventory i = new Inventory();

			i.Add(1, "Lays Peper & Zout", 3.20f);
			i.Add(2, "Lays Peper & Zout", 3.30f);

			i.Remove("Lays Peper & Zout");
			Assert.AreEqual(2, i.Count());
			Assert.IsTrue(AreEqualFloat(3.30f, i.Price("Lays Peper & Zout")));

			i.Remove("Lays Peper & Zout");
			Assert.AreEqual(1, i.Count());
			Assert.IsTrue(AreEqualFloat(3.30f, i.Price("Lays Peper & Zout")));
		}

		[Test]
		public void ItemEqualityPrices()
		{
			Item item1 = new Item {Name = "Item", UnitPrice = 1.2f};
			Item item2 = new Item {Name = "Item", UnitPrice = 1.2f};
			Item item3 = new Item {Name = "Item", UnitPrice = 1.19f};

			Assert.AreEqual(item1, item1);
			Assert.AreEqual(item2, item2);
			Assert.AreEqual(item3, item3);

			Assert.AreEqual(item1, item2);
			Assert.AreEqual(item2, item1);

			Assert.AreNotEqual(item1, item3);
			Assert.AreNotEqual(item3, item1);

			Assert.AreNotEqual(item2, item3);
			Assert.AreNotEqual(item3, item2);
		}

		[Test]
		public void ItemEqualityNames()
		{
			Item item1 = new Item { Name = "Item", UnitPrice = 1f };
			Item item2 = new Item { Name = "Item", UnitPrice = 1f };
			Item item3 = new Item { Name = "Other item", UnitPrice = 1f };

			Assert.AreEqual(item1, item1);
			Assert.AreEqual(item2, item2);
			Assert.AreEqual(item3, item3);

			Assert.AreEqual(item1, item2);
			Assert.AreEqual(item2, item1);

			Assert.AreNotEqual(item1, item3);
			Assert.AreNotEqual(item3, item1);

			Assert.AreNotEqual(item2, item3);
			Assert.AreNotEqual(item3, item2);
		}

		[Test]
		public void ItemStacks()
		{
			Inventory i = new Inventory();
			Item item1a = new Item { Name = "Item1", UnitPrice = 1f }; i.Add(item1a);
			Item item1b = new Item { Name = "Item1", UnitPrice = 1f }; i.Add(item1b);
			Item item1c = new Item { Name = "Item1", UnitPrice = 1f }; i.Add(item1c);
			Item item2a = new Item { Name = "Item2", UnitPrice = 1f }; i.Add(item2a);
			Item item2b = new Item { Name = "Item2", UnitPrice = 1f }; i.Add(item2b);
			Item item3a = new Item { Name = "Item1", UnitPrice = 2f }; i.Add(item3a);
			Item item3b = new Item { Name = "Item1", UnitPrice = 2f }; i.Add(item3b);

			Dictionary<KeyValuePair<string, float>, int> stacks = i.GetStacks();

			Assert.AreEqual(3, stacks.Count);

			KeyValuePair<string, float> pair1 = new KeyValuePair<string, float>("Item1", 1f);
			Assert.Contains(pair1, stacks.Keys);
			Assert.AreEqual(3, stacks[pair1]);

			KeyValuePair<string, float> pair2 = new KeyValuePair<string, float>("Item2", 1f);
			Assert.Contains(pair2, stacks.Keys);
			Assert.AreEqual(2, stacks[pair2]);

			KeyValuePair<string, float> pair3 = new KeyValuePair<string, float>("Item1", 2f);
			Assert.Contains(pair3, stacks.Keys);
			Assert.AreEqual(2, stacks[pair3]);
		}

		private bool AreEqualFloat(float expected, float actual)
		{
			float epsilon = 0.00005f;
			return Math.Abs(actual - expected) < epsilon;
		}
	}
}
