using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Controller
	{
		private List<Session> _sessions;
		private List<Consumer> _consumers;
		private Inventory _inventory;

		internal Controller(List<Session> sessions, List<Consumer> consumers, Inventory inventory)
		{
			_sessions = sessions;
			_consumers = consumers;
			_inventory = inventory;
		}

		internal void ConsumeItems(Session session, List<Item> items)
		{
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
			foreach (Item item in items)
			{
				Item unconsumed = session.ConsumedItems.Consume(item);
				if (unconsumed == null) continue;

				_inventory.Add(item);

				foreach (Consumer c in session.Consumers)
					c.Deposit(item.UnitPrice / session.Consumers.Count);
			}
		}
	}
}
