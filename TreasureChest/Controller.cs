using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Controller
	{
		public List<Session> Sessions { get { return _sessions; } }
		public List<Consumer> Consumers { get { return _consumers; } }
		public Inventory Inventory { get { return _inventory; } }

		private List<Session> _sessions;
		private List<Consumer> _consumers;
		private Inventory _inventory;

		internal Controller(List<Session> sessions, List<Consumer> consumers, Inventory inventory)
		{
			_sessions = sessions;
			_consumers = consumers;
			_inventory = inventory;
		}

		internal void AddItemToInventory(int count, string name, float price)
		{
			_inventory.Add(count, name, price);
		}

		internal void AddItemToInventory(int count, string name, float price, int units)
		{
			_inventory.Add(count, name, price, units);
		}

		internal Item GetItemFromInventory(string name)
		{
			return _inventory.Get(name);
		}

		internal Item GetItemFromInventory(int index)
		{
			return _inventory.Get(index);
		}

		internal void RemoveItemFromInventory(string name)
		{
			_inventory.Remove(name);
		}

		internal int GetInventorySize()
		{
			return _inventory.Count();
		}

		internal int CountInInventory(string name)
		{
			return _inventory.Count(name);
		}

		internal void AddSession(Session session)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			Sessions.Add(session);
			Sessions.Sort();
		}

		internal void AddConsumerToSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			session.Add(consumer);
		}

		internal void RemoveConsumerFromSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			session.Remove(consumer);
		}

		internal bool IsConsumerInSession(Session session, Consumer consumer)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			return session.Consumers.Contains(consumer);
		}

		internal Item GetItemFromSession(Session session, int index)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			return session.ConsumedItems.Get(index);
		}

		internal int GetConsumedItemsCount(Session session)
		{
			if (session == null) throw new ArgumentNullException("Invalid session");
			return session.ConsumedItems.Count();
		}

		internal void ConsumeItems(Session session, List<Item> items)
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

		internal void UnconsumeItems(Session session, List<Item> items)
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

		internal void Deposit(Consumer consumer, float amount)
		{
			if (consumer == null) throw new ArgumentNullException("Invalid consumer");
			consumer.Deposit(amount);
		}
	}
}
