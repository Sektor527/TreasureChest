using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureChest
{
	partial class FormSessions : Form
	{
		private List<Session> _sessions;

		public FormSessions(List<Session> sessions)
		{
			InitializeComponent();

			_sessions = sessions;
			_sessions.Sort();
		}

		private void FormSessions_Load(object sender, EventArgs e)
		{
			foreach (Session s in _sessions)
				lstSessions.Items.Add(s);

			UpdateSessionData();
		}

		private void UpdateSessionData()
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null)
			{
				groupBox1.Enabled = false;
				dateTimePicker.Enabled = false;
				return;
			}

			groupBox1.Enabled = true;
			dateTimePicker.Enabled = true;

			chkConsumerWim.Checked = s.Consumers.Contains(Consumer.Wim);
			chkConsumerBart.Checked = s.Consumers.Contains(Consumer.Bart);
			chkConsumerJo.Checked = s.Consumers.Contains(Consumer.Jo);
			chkConsumerKoen.Checked = s.Consumers.Contains(Consumer.Koen);
			chkConsumerFrederik.Checked = s.Consumers.Contains(Consumer.Frederik);
			chkConsumerChristoph.Checked = s.Consumers.Contains(Consumer.Christoph);
			chkConsumerChristof.Checked = s.Consumers.Contains(Consumer.Christof);

			dateTimePicker.Value = s.Date;
		}

		private void btnAddSession_Click(object sender, EventArgs e)
		{
			Session s = new Session();
			_sessions.Add(s);
			_sessions.Sort();
			lstSessions.Items.Insert(_sessions.IndexOf(s), s);
			lstSessions.SelectedItem = s;
		}

		private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSessionData();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null) return;

			s.Date = dateTimePicker.Value;

			_sessions.Sort();
			lstSessions.Items.Remove(s);
			lstSessions.Items.Insert(_sessions.IndexOf(s), s);
			lstSessions.SelectedItem = s;
		}

		private void btnDeleteSession_Click(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if (s == null) return;

			_sessions.Remove(s);
			lstSessions.Items.Remove(s);
		}

		private void OnConsumerCheckChanged(object sender, EventArgs e)
		{
			Session s = lstSessions.SelectedItem as Session;

			if ((sender as CheckBox).Checked)
			{
				if (sender == chkConsumerWim) s.Add(Consumer.Wim);
				if (sender == chkConsumerBart) s.Add(Consumer.Bart);
				if (sender == chkConsumerJo) s.Add(Consumer.Jo);
				if (sender == chkConsumerKoen) s.Add(Consumer.Koen);
				if (sender == chkConsumerChristof) s.Add(Consumer.Christof);
				if (sender == chkConsumerChristoph) s.Add(Consumer.Christoph);
				if (sender == chkConsumerFrederik) s.Add(Consumer.Frederik);
			}
			else
			{
				if (sender == chkConsumerWim) s.Remove(Consumer.Wim);
				if (sender == chkConsumerBart) s.Remove(Consumer.Bart);
				if (sender == chkConsumerJo) s.Remove(Consumer.Jo);
				if (sender == chkConsumerKoen) s.Remove(Consumer.Koen);
				if (sender == chkConsumerChristof) s.Remove(Consumer.Christof);
				if (sender == chkConsumerChristoph) s.Remove(Consumer.Christoph);
				if (sender == chkConsumerFrederik) s.Remove(Consumer.Frederik);
			}
		}
	}
}
