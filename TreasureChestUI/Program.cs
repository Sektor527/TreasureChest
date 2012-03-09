using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TreasureChestCore;

namespace TreasureChestUI
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

			Controller controller = new Controller(new List<Session>(), new List<Consumer>(), new Inventory());
			controller.Deserialize();
			Application.Run(new MainWindow(controller));
			controller.Serialize();
		}
	}
}
