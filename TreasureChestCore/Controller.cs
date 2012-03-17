using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChestCore
{
	public class Controller
	{
		public List<Session> Sessions { get { return _sessions; } }
		public List<Consumer> Consumers { get { return _consumers; } }
		public Inventory Inventory { get { return _inventory; } }

		private List<Session> _sessions;
		private List<Consumer> _consumers;
		private Inventory _inventory;

		public Controller(List<Session> sessions, List<Consumer> consumers, Inventory inventory)
		{
			_sessions = sessions;
			_consumers = consumers;
			_inventory = inventory;
		}

		public void AddItemToInventory(int count, string name, float price)
		{
			_inventory.Add(count, name, price);
		}

		public void AddItemToInventory(int count, string name, float price, int units)
		{
			_inventory.Add(count, name, price, units);
		}

		public Item GetItemFromInventory(string name)
		{
			return _inventory.Get(name);
		}

		public Item GetItemFromInventory(int index)
		{
			return _inventory.Get(index);
		}

		public void RemoveItemFromInventory(string name)
		{
			_inventory.Remove(name);
		}

		public int GetInventorySize()
		{
			return _inventory.Count();
		}

		public int CountInInventory(string name)
		{
			return _inventory.Count(name);
		}

		public void AddSession(Session session)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			Sessions.Add(session);
			Sessions.Sort();
		}

		public Session GetSession(DateTime dateTime)
		{
			foreach (Session session in Sessions)
			{
				if (session.Date.Year == dateTime.Year && session.Date.Month == dateTime.Month && session.Date.Day == dateTime.Day)
					return session;
			}

			return null;
		}

		public void RemoveSession(Session session)
		{
			Sessions.Remove(session);
		}

		public void AddConsumerToSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			session.Add(consumer);
		}

		public void RemoveConsumerFromSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			session.Remove(consumer);
		}

		public bool IsConsumerInSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			return session.Consumers.Contains(consumer);
		}

		public void AddItemToSession(Session session, Item item)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (item == null) throw new ArgumentNullException("Invalid item");
			session.ConsumedItems.Add(item);
		}

		public Item GetItemFromSession(Session session, int index)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			return session.ConsumedItems.Get(index);
		}

		public int GetConsumedItemsCount(Session session)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			return session.ConsumedItems.Count();
		}

		public void ConsumeItems(Session session, List<Item> items)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (items == null) throw new ArgumentNullException("Invalid item list");

			foreach (Item item in items)
			{
				Item consumed = _inventory.Consume(item);
				if (consumed == null) continue;

				session.ConsumedItems.Add(item);

				foreach (Consumer c in session.Consumers)
					c.Withdraw(item.UnitPrice / session.Consumers.Count);
			}
		}

		public void UnconsumeItems(Session session, List<Item> items)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (items == null) throw new ArgumentNullException("Invalid item list");

			foreach (Item item in items)
			{
				Item unconsumed = session.ConsumedItems.Consume(item);
				if (unconsumed == null) continue;

				_inventory.Add(item);

				foreach (Consumer c in session.Consumers)
					c.Deposit(item.UnitPrice / session.Consumers.Count);
			}
		}

		public void Deposit(Consumer consumer, float amount)
		{
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			consumer.Deposit(amount);
		}

		public void Deserialize()
		{
			Serializer.Deserialize(_sessions, _consumers, _inventory);
		}

		public void Serialize()
		{
			Serializer.Serialize(_sessions, _consumers, _inventory);
		}
	}
}
