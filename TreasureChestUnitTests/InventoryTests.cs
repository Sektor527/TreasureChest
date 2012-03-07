using System;
using NUnit.Framework;
using TreasureChest;

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

		private bool AreEqualFloat(float expected, float actual)
		{
			float epsilon = 0.00005f;
			return Math.Abs(actual - expected) < epsilon;
		}
	}
}
