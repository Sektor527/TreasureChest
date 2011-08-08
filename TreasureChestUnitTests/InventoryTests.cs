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
			i.Add(1, "Lays Peper & Zout", 3.20f);

			Item item1 = i.Consume("Hopus");
			Assert.AreEqual(2, i.Count());
			Assert.AreEqual("Hopus", item1.Name);

			Item item2 = i.Consume(0);
			Assert.AreEqual(1, i.Count());
			Assert.AreEqual("Hopus", item2.Name);
		}

		private bool AreEqualFloat(float expected, float actual)
		{
			float epsilon = 0.00005f;
			return Math.Abs(actual - expected) < epsilon;
		}
	}
}
