namespace TreasureChest
{
	partial class FormSessions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstSessions = new System.Windows.Forms.ListBox();
			this.btnAddSession = new System.Windows.Forms.Button();
			this.btnDeleteSession = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._consumersPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnUnconsume = new System.Windows.Forms.Button();
			this.btnConsume = new System.Windows.Forms.Button();
			this.lstConsumable = new System.Windows.Forms.ListBox();
			this.lstConsumed = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstSessions
			// 
			this.lstSessions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstSessions.FormattingEnabled = true;
			this.lstSessions.IntegralHeight = false;
			this.lstSessions.Location = new System.Drawing.Point(12, 12);
			this.lstSessions.Name = "lstSessions";
			this.lstSessions.Size = new System.Drawing.Size(96, 182);
			this.lstSessions.TabIndex = 0;
			this.lstSessions.SelectedIndexChanged += new System.EventHandler(this.lstSessions_SelectedIndexChanged);
			// 
			// btnAddSession
			// 
			this.btnAddSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddSession.Location = new System.Drawing.Point(12, 200);
			this.btnAddSession.Name = "btnAddSession";
			this.btnAddSession.Size = new System.Drawing.Size(96, 23);
			this.btnAddSession.TabIndex = 1;
			this.btnAddSession.Text = "Add";
			this.btnAddSession.UseVisualStyleBackColor = true;
			this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
			// 
			// btnDeleteSession
			// 
			this.btnDeleteSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeleteSession.Location = new System.Drawing.Point(12, 229);
			this.btnDeleteSession.Name = "btnDeleteSession";
			this.btnDeleteSession.Size = new System.Drawing.Size(96, 23);
			this.btnDeleteSession.TabIndex = 2;
			this.btnDeleteSession.Text = "Delete";
			this.btnDeleteSession.UseVisualStyleBackColor = true;
			this.btnDeleteSession.Click += new System.EventHandler(this.btnDeleteSession_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._consumersPanel);
			this.groupBox1.Location = new System.Drawing.Point(114, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(101, 214);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Consumers";
			// 
			// _consumersPanel
			// 
			this._consumersPanel.Location = new System.Drawing.Point(8, 18);
			this._consumersPanel.Margin = new System.Windows.Forms.Padding(0);
			this._consumersPanel.Name = "_consumersPanel";
			this._consumersPanel.Size = new System.Drawing.Size(86, 187);
			this._consumersPanel.TabIndex = 10;
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(114, 12);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(422, 20);
			this.dateTimePicker.TabIndex = 5;
			this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnUnconsume);
			this.groupBox2.Controls.Add(this.btnConsume);
			this.groupBox2.Controls.Add(this.lstConsumable);
			this.groupBox2.Controls.Add(this.lstConsumed);
			this.groupBox2.Location = new System.Drawing.Point(221, 38);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(315, 214);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Inventory";
			// 
			// btnUnconsume
			// 
			this.btnUnconsume.Location = new System.Drawing.Point(132, 71);
			this.btnUnconsume.Name = "btnUnconsume";
			this.btnUnconsume.Size = new System.Drawing.Size(51, 23);
			this.btnUnconsume.TabIndex = 3;
			this.btnUnconsume.Text = ">>";
			this.btnUnconsume.UseVisualStyleBackColor = true;
			this.btnUnconsume.Click += new System.EventHandler(this.btnUnconsume_Click);
			// 
			// btnConsume
			// 
			this.btnConsume.Location = new System.Drawing.Point(132, 42);
			this.btnConsume.Name = "btnConsume";
			this.btnConsume.Size = new System.Drawing.Size(51, 23);
			this.btnConsume.TabIndex = 2;
			this.btnConsume.Text = "<<";
			this.btnConsume.UseVisualStyleBackColor = true;
			this.btnConsume.Click += new System.EventHandler(this.btnConsume_Click);
			// 
			// lstConsumable
			// 
			this.lstConsumable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstConsumable.FormattingEnabled = true;
			this.lstConsumable.Location = new System.Drawing.Point(189, 19);
			this.lstConsumable.Name = "lstConsumable";
			this.lstConsumable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstConsumable.Size = new System.Drawing.Size(120, 186);
			this.lstConsumable.TabIndex = 1;
			// 
			// lstConsumed
			// 
			this.lstConsumed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstConsumed.FormattingEnabled = true;
			this.lstConsumed.Location = new System.Drawing.Point(6, 19);
			this.lstConsumed.Name = "lstConsumed";
			this.lstConsumed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstConsumed.Size = new System.Drawing.Size(120, 186);
			this.lstConsumed.TabIndex = 0;
			// 
			// FormSessions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 264);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAddSession);
			this.Controls.Add(this.lstSessions);
			this.Controls.Add(this.btnDeleteSession);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormSessions";
			this.Text = "FormSessions";
			this.Load += new System.EventHandler(this.FormSessions_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstSessions;
		private System.Windows.Forms.Button btnAddSession;
		private System.Windows.Forms.Button btnDeleteSession;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstConsumable;
		private System.Windows.Forms.ListBox lstConsumed;
		private System.Windows.Forms.Button btnUnconsume;
		private System.Windows.Forms.Button btnConsume;
		private System.Windows.Forms.FlowLayoutPanel _consumersPanel;
	}
}