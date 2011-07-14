using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureChest
{
	class Session
	{
		public List<Consumer> Consumers { get; private set; }
	
		public Session()
		{
			Consumers = new List<Consumer>();
		}

		public void Add(Consumer c)
		{
			if (Consumers.Contains(c)) return;

			Consumers.Add(c);
		}
	}
}
