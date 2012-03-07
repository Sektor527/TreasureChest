using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TreasureChest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			List<Session> sessions = new List<Session>();
			List<Consumer> consumers = new List<Consumer>();
			Inventory inventory = new Inventory();

			Serializer.Deserialize(sessions, consumers, inventory);

			consumers.Add(Consumer.Wim);
			consumers.Add(Consumer.Bart);
			consumers.Add(Consumer.Koen);
			consumers.Add(Consumer.Jo);
			consumers.Add(Consumer.Frederik);
			consumers.Add(Consumer.Christoph);
			consumers.Add(Consumer.Christof);

			Application.Run(new FormMain(sessions, consumers, inventory));

			Serializer.Serialize(sessions, consumers, inventory);
		}
	}
}
