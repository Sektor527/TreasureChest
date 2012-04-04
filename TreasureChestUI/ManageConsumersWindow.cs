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
	public partial class ManageConsumersWindow : Form
	{
		public ManageConsumersWindow(Controller controller)
		{
			_controller = controller;
			InitializeComponent();

			foreach (Consumer c in _controller.Consumers)
			{
				_list.Items.Add(new ListViewItem(c.Name) {Tag = c});
			}
		}

		private readonly Controller _controller;

		private void CloseClicked(object sender, EventArgs e)
		{
			Close();
		}
	}
}
