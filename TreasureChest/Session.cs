using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Session : IComparable<Session>
	{
		public DateTime Date { get; set; }
		public List<Consumer> Consumers { get; private set; }
		public Inventory ConsumedItems { get; private set; }

		public Session() : this(DateTime.Today) { }

		public Session(DateTime date)
		{
			Consumers = new List<Consumer>();
			ConsumedItems = new Inventory();
			Date = date;
		}

		public void Add(Consumer c)
		{
			if (Consumers.Contains(c)) return;

			Consumers.Add(c);
		}

		public void Remove(Consumer c)
		{
			if (!Consumers.Contains(c)) return;

			Consumers.Remove(c);
		}

		public void ConsumeFrom(Inventory i, string name)
		{
			Item item = i.Consume(name);
			ConsumedItems.Add(item);
		}

		public void UnconsumeTo(Inventory i, string name)
		{
			Item item = ConsumedItems.Consume(name);
			i.Add(item);
		}

		public override string ToString()
		{
			return Date.ToShortDateString();
		}

		public int CompareTo(Session other)
		{
			return Date.CompareTo(other.Date);
		}

		public override int GetHashCode()
		{
			return Date.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return GetHashCode() == obj.GetHashCode();
		}
	}
}
