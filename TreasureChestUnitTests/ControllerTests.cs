using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TreasureChestCore;

namespace TreasureChestUnitTests
{
	[TestFixture]
	class ControllerTests
	{
		Controller _controller;

		[SetUp]
		public void SetUp()
		{
			_controller = new Controller(new List<Session>(), new List<Consumer>(), new Inventory());
		}

		[Test]
		public void AddSession_Sort()
		{
			_controller.AddSession(new Session(new DateTime(2000, 1, 1)));
			_controller.AddSession(new Session(new DateTime(1999, 1, 1)));
			_controller.AddSession(new Session(new DateTime(1999, 6, 1)));
			_controller.AddSession(new Session(new DateTime(2001, 1, 1)));

			Assert.Less(_controller.Sessions[0].Date, _controller.Sessions[1].Date);
			Assert.Less(_controller.Sessions[1].Date, _controller.Sessions[2].Date);
			Assert.Less(_controller.Sessions[2].Date, _controller.Sessions[3].Date);
		}

		[Test]
		public void GetSession()
		{
			Session session = new Session(new DateTime(1982, 3, 16));
			_controller.AddSession(session);

			Assert.AreEqual(session, _controller.GetSession(new DateTime(1982, 3, 16)));
			Assert.AreEqual(session, _controller.GetSession(new DateTime(1982, 3, 16, 3, 33, 33)));
			Assert.IsNull(_controller.GetSession(new DateTime(1979, 4, 27)));
		}

		[Test]
		public void ConsumeItems()
		{
			Consumer wim, bart, koen;
			wim = new Consumer("wim") { Credit = 10 };
			bart = new Consumer("bart") { Credit = 5 };
			koen = new Consumer("koen") { Credit = 7.5f };

			Session session = new Session();
			_controller.AddSession(session);
			_controller.AddConsumerToSession(session, wim);
			_controller.AddConsumerToSession(session, bart);

			_controller.AddItemToInventory(1, "cola", 30f, 6);
			_controller.AddItemToInventory(3, "chips", 3f);

			List<Item> consumedItems = new List<Item>();
			consumedItems.Add(_controller.GetItemFromInventory("chips"));
			consumedItems.Add(_controller.GetItemFromInventory("cola"));
			
			_controller.ConsumeItems(session, consumedItems);

			// Items transferred
			Assert.AreEqual(7, _controller.GetInventorySize());
			Assert.AreEqual(2, _controller.GetConsumedItemsCount(session));

			// Credits reduced
			Assert.AreEqual(6, wim.Credit);
			Assert.AreEqual(1, bart.Credit);

			// Credits unchanged
			Assert.AreEqual(7.5f, koen.Credit);
		}

		[Test]
		public void ConsumeItems_ItemsNotInInventory()
		{
			Consumer wim, bart, koen;
			wim = new Consumer("wim") { Credit = 10 };
			bart = new Consumer("bart") { Credit = 5 };
			koen = new Consumer("koen") { Credit = 7.5f };

			Session session = new Session();
			_controller.AddSession(session);
			_controller.AddConsumerToSession(session, wim);
			_controller.AddConsumerToSession(session, bart);

			_controller.AddItemToInventory(1, "cola", 30f, 6);
			_controller.AddItemToInventory(3, "chips", 3f);
			
			List<Item> bogusItems = new List<Item>();
			bogusItems.Add(new Item());

			_controller.ConsumeItems(session, bogusItems);

			Assert.AreEqual(9, _controller.GetInventorySize());
			Assert.AreEqual(0, _controller.GetConsumedItemsCount(session));
		}

		[Test]
		public void UnconsumeItems()
		{
			Consumer wim, bart, koen;
			wim = new Consumer("wim") { Credit = 10 };
			bart = new Consumer("bart") { Credit = 5 };
			koen = new Consumer("koen") { Credit = 7.5f };

			Session session = new Session();
			_controller.AddSession(session);
			_controller.AddConsumerToSession(session, wim);
			_controller.AddConsumerToSession(session, bart);

			_controller.AddItemToSession(session, new Item { Name = "Something", UnitPrice = 1f });
			_controller.AddItemToSession(session, new Item { Name = "Whatever", UnitPrice = 2f });

			List<Item> unconsumedItems = new List<Item>();
			unconsumedItems.Add(_controller.GetItemFromSession(session, 0));
			unconsumedItems.Add(_controller.GetItemFromSession(session, 1));

			_controller.UnconsumeItems(session, unconsumedItems);

			// Items transferred
			Assert.AreEqual(2, _controller.GetInventorySize());
			Assert.AreEqual(0, _controller.GetConsumedItemsCount(session));

			// Credits refunded
			Assert.AreEqual(11.5f, wim.Credit);
			Assert.AreEqual(6.5, bart.Credit);

			// Credits unchanged
			Assert.AreEqual(7.5, koen.Credit);
		}

		[Test]
		public void UnconsumeItems_ItemsNotInSession()
		{
			Session session = new Session();
			_controller.AddSession(session);

			_controller.AddItemToSession(session, new Item { Name = "Something", UnitPrice = 1f });
			_controller.AddItemToSession(session, new Item { Name = "Whatever", UnitPrice = 2f });

			List<Item> unconsumedItems = new List<Item>();
			unconsumedItems.Add(new Item());

			_controller.UnconsumeItems(session, unconsumedItems);

			Assert.AreEqual(0, _controller.GetInventorySize());
			Assert.AreEqual(2, _controller.GetConsumedItemsCount(session));
		}
	}
}
