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
		}

		private Controller _controller;
	}
}
