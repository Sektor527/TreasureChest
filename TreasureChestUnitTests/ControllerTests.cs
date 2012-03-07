using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TreasureChest;

namespace TreasureChestUnitTests
{
	[TestFixture]
	class ControllerTests
	{
		Controller _controller;
		List<Session> _sessions;
		List<Consumer> _consumers;
		Inventory _inventory;

		Consumer wim, bart, koen;

		[SetUp]
		public void SetUp()
		{
			_sessions = new List<Session>();
			_consumers = new List<Consumer>();
			_inventory = new Inventory();
			_controller = new Controller(_sessions, _consumers, _inventory);

			wim = new Consumer("wim");
			wim.Credit = 10;
			bart = new Consumer("bart");
			bart.Credit = 5;
			koen = new Consumer("koen");
			koen.Credit = 7.5f;

			Session session = new Session();
			session.Consumers.Add(wim);
			session.Consumers.Add(bart);

			_sessions.Add(session);

			_inventory.Add(1, "cola", 30f, 6);
			_inventory.Add(3, "chips", 3f);
		}

		[Test]
		public void ConsumeItems()
		{
			List<Item> consumedItems = new List<Item>();
			consumedItems.Add(_inventory.Get("chips"));
			consumedItems.Add(_inventory.Get("cola"));

			_controller.ConsumeItems(_sessions[0], consumedItems);

			// Items transferred
			Assert.AreEqual(7, _inventory.Count());
			Assert.AreEqual(2, _sessions[0].ConsumedItems.Count());

			// Credits reduced
			Assert.AreEqual(6, wim.Credit);
			Assert.AreEqual(1, bart.Credit);

			// Credits unchanged
			Assert.AreEqual(7.5f, koen.Credit);
		}

		[Test]
		public void ConsumeItems_ItemsNotInInventory()
		{
			List<Item> bogusItems = new List<Item>();
			bogusItems.Add(new Item());

			_controller.ConsumeItems(_sessions[0], bogusItems);

			Assert.AreEqual(9, _inventory.Count());
			Assert.AreEqual(0, _sessions[0].ConsumedItems.Count());
		}

		[Test]
		public void UnconsumeItems()
		{
			_sessions[0].ConsumedItems.Add(new Item {Name = "Something", UnitPrice = 1f});
			_sessions[0].ConsumedItems.Add(new Item {Name = "Whatever", UnitPrice = 2f});

			List<Item> unconsumedItems = new List<Item>();
			unconsumedItems.Add(_sessions[0].ConsumedItems.Get(0));
			unconsumedItems.Add(_sessions[0].ConsumedItems.Get(1));

			_controller.UnconsumeItems(_sessions[0], unconsumedItems);

			// Items transferred
			Assert.AreEqual(11, _inventory.Count());
			Assert.AreEqual(0, _sessions[0].ConsumedItems.Count());

			// Credits refunded
			Assert.AreEqual(11.5f, wim.Credit);
			Assert.AreEqual(6.5, bart.Credit);

			// Credits unchanged
			Assert.AreEqual(7.5, koen.Credit);
		}

		[Test]
		public void UnconsumeItems_ItemsNotInSession()
		{
			_sessions[0].ConsumedItems.Add(new Item { Name = "Something", UnitPrice = 1f });
			_sessions[0].ConsumedItems.Add(new Item { Name = "Whatever", UnitPrice = 2f });

			List<Item> unconsumedItems = new List<Item>();
			unconsumedItems.Add(new Item());

			_controller.UnconsumeItems(_sessions[0], unconsumedItems);

			Assert.AreEqual(9, _inventory.Count());
			Assert.AreEqual(2, _sessions[0].ConsumedItems.Count());
		}
	}
}
