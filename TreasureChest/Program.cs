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
			Inventory inventory = new Inventory();

			Serializer.Deserialize(sessions, inventory);

			Application.Run(new FormMain(sessions, inventory));

			Serializer.Serialize(sessions, inventory);
		}
	}
}
