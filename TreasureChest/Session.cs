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

		public Session() : this(DateTime.Today) { }

		public Session(DateTime date)
		{
			Consumers = new List<Consumer>();
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

		public override string ToString()
		{
			return Date.ToShortDateString();
		}

		public int CompareTo(Session other)
		{
			return Date.CompareTo(other.Date);
		}
	}
}
