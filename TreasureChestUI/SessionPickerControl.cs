using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreasureChestCore;

namespace TreasureChestUI
{
	public partial class SessionPickerControl : UserControl
	{
		internal event EventHandler DateChanged;

		public SessionPickerControl(Controller controller)
		{
			_controller = controller;
			InitializeComponent();
		}

		internal DateTime Value
		{
			get { return dateTimePicker1.Value.Date; }
			set { dateTimePicker1.Value = value.Date; }
		}

		internal Session SelectedSession
		{
			get { return _controller.GetSession(dateTimePicker1.Value); }
		}

		private void PreviousSessionClicked(object sender, EventArgs e)
		{
			Session previousSession = _controller.GetPreviousSession(Value);
			if (previousSession == null) return;

			Value = previousSession.Date;
		}

		private void NextSessionClicked(object sender, EventArgs e)
		{
			Session nextSession = _controller.GetNextSession(Value);
			if (nextSession == null) return;

			Value = nextSession.Date;
		}

		private void OnDateChanged(object sender, EventArgs e)
		{
			if (DateChanged != null)
				DateChanged(sender, e);
		}

		private readonly Controller _controller;
	}
}
