using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreasureChestCore;

namespace TreasureChestUI
{
	public partial class MainWindow : Form
	{
		public MainWindow(Controller controller)
		{
			_controller = controller;

			InitializeComponent();

			_inventoryPanel.Controls.Add(new InventoryControl(_controller) { Dock = DockStyle.Fill });

			foreach (Consumer c in _controller.Consumers)
				_consumerPanel.Controls.Add(new ConsumerControl(_controller) { Name = c.Name, Credit = c.Credit, Tag = c });
		}

		private Controller _controller;
	}
}
