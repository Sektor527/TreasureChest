using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using TreasureChestCore;

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

			Controller controller = new Controller(sessions, consumers, inventory);

			controller.Deserialize();

			Application.Run(new FormMain(controller));

			controller.Serialize();
		}
	}
}
