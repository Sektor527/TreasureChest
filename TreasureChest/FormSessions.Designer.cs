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
			this.chkConsumerWim = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkConsumerChristof = new System.Windows.Forms.CheckBox();
			this.chkConsumerChristoph = new System.Windows.Forms.CheckBox();
			this.chkConsumerFrederik = new System.Windows.Forms.CheckBox();
			this.chkConsumerKoen = new System.Windows.Forms.CheckBox();
			this.chkConsumerJo = new System.Windows.Forms.CheckBox();
			this.chkConsumerBart = new System.Windows.Forms.CheckBox();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstConsumed = new System.Windows.Forms.ListBox();
			this.lstConsumable = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			// chkConsumerWim
			// 
			this.chkConsumerWim.AutoSize = true;
			this.chkConsumerWim.Location = new System.Drawing.Point(6, 19);
			this.chkConsumerWim.Name = "chkConsumerWim";
			this.chkConsumerWim.Size = new System.Drawing.Size(47, 17);
			this.chkConsumerWim.TabIndex = 3;
			this.chkConsumerWim.Text = "Wim";
			this.chkConsumerWim.UseVisualStyleBackColor = true;
			this.chkConsumerWim.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkConsumerChristof);
			this.groupBox1.Controls.Add(this.chkConsumerChristoph);
			this.groupBox1.Controls.Add(this.chkConsumerFrederik);
			this.groupBox1.Controls.Add(this.chkConsumerKoen);
			this.groupBox1.Controls.Add(this.chkConsumerJo);
			this.groupBox1.Controls.Add(this.chkConsumerBart);
			this.groupBox1.Controls.Add(this.chkConsumerWim);
			this.groupBox1.Location = new System.Drawing.Point(114, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(101, 214);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Consumers";
			// 
			// chkConsumerChristof
			// 
			this.chkConsumerChristof.AutoSize = true;
			this.chkConsumerChristof.Location = new System.Drawing.Point(6, 157);
			this.chkConsumerChristof.Name = "chkConsumerChristof";
			this.chkConsumerChristof.Size = new System.Drawing.Size(61, 17);
			this.chkConsumerChristof.TabIndex = 9;
			this.chkConsumerChristof.Text = "Christof";
			this.chkConsumerChristof.UseVisualStyleBackColor = true;
			this.chkConsumerChristof.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// chkConsumerChristoph
			// 
			this.chkConsumerChristoph.AutoSize = true;
			this.chkConsumerChristoph.Location = new System.Drawing.Point(6, 134);
			this.chkConsumerChristoph.Name = "chkConsumerChristoph";
			this.chkConsumerChristoph.Size = new System.Drawing.Size(70, 17);
			this.chkConsumerChristoph.TabIndex = 8;
			this.chkConsumerChristoph.Text = "Christoph";
			this.chkConsumerChristoph.UseVisualStyleBackColor = true;
			this.chkConsumerChristoph.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// chkConsumerFrederik
			// 
			this.chkConsumerFrederik.AutoSize = true;
			this.chkConsumerFrederik.Location = new System.Drawing.Point(6, 111);
			this.chkConsumerFrederik.Name = "chkConsumerFrederik";
			this.chkConsumerFrederik.Size = new System.Drawing.Size(64, 17);
			this.chkConsumerFrederik.TabIndex = 7;
			this.chkConsumerFrederik.Text = "Frederik";
			this.chkConsumerFrederik.UseVisualStyleBackColor = true;
			this.chkConsumerFrederik.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// chkConsumerKoen
			// 
			this.chkConsumerKoen.AutoSize = true;
			this.chkConsumerKoen.Location = new System.Drawing.Point(6, 88);
			this.chkConsumerKoen.Name = "chkConsumerKoen";
			this.chkConsumerKoen.Size = new System.Drawing.Size(51, 17);
			this.chkConsumerKoen.TabIndex = 6;
			this.chkConsumerKoen.Text = "Koen";
			this.chkConsumerKoen.UseVisualStyleBackColor = true;
			this.chkConsumerKoen.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// chkConsumerJo
			// 
			this.chkConsumerJo.AutoSize = true;
			this.chkConsumerJo.Location = new System.Drawing.Point(6, 65);
			this.chkConsumerJo.Name = "chkConsumerJo";
			this.chkConsumerJo.Size = new System.Drawing.Size(37, 17);
			this.chkConsumerJo.TabIndex = 5;
			this.chkConsumerJo.Text = "Jo";
			this.chkConsumerJo.UseVisualStyleBackColor = true;
			this.chkConsumerJo.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
			// 
			// chkConsumerBart
			// 
			this.chkConsumerBart.AutoSize = true;
			this.chkConsumerBart.Location = new System.Drawing.Point(6, 42);
			this.chkConsumerBart.Name = "chkConsumerBart";
			this.chkConsumerBart.Size = new System.Drawing.Size(45, 17);
			this.chkConsumerBart.TabIndex = 4;
			this.chkConsumerBart.Text = "Bart";
			this.chkConsumerBart.UseVisualStyleBackColor = true;
			this.chkConsumerBart.CheckedChanged += new System.EventHandler(this.OnConsumerCheckChanged);
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
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.lstConsumable);
			this.groupBox2.Controls.Add(this.lstConsumed);
			this.groupBox2.Location = new System.Drawing.Point(221, 38);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(315, 214);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Inventory";
			// 
			// lstConsumed
			// 
			this.lstConsumed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstConsumed.FormattingEnabled = true;
			this.lstConsumed.Location = new System.Drawing.Point(6, 19);
			this.lstConsumed.Name = "lstConsumed";
			this.lstConsumed.Size = new System.Drawing.Size(120, 186);
			this.lstConsumed.TabIndex = 0;
			// 
			// lstConsumable
			// 
			this.lstConsumable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstConsumable.FormattingEnabled = true;
			this.lstConsumable.Location = new System.Drawing.Point(189, 19);
			this.lstConsumable.Name = "lstConsumable";
			this.lstConsumable.Size = new System.Drawing.Size(120, 186);
			this.lstConsumable.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(132, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(51, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "<<";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(132, 71);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(51, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = ">>";
			this.button2.UseVisualStyleBackColor = true;
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
			this.Name = "FormSessions";
			this.Text = "FormSessions";
			this.Load += new System.EventHandler(this.FormSessions_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstSessions;
		private System.Windows.Forms.Button btnAddSession;
		private System.Windows.Forms.Button btnDeleteSession;
		private System.Windows.Forms.CheckBox chkConsumerWim;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkConsumerChristof;
		private System.Windows.Forms.CheckBox chkConsumerChristoph;
		private System.Windows.Forms.CheckBox chkConsumerFrederik;
		private System.Windows.Forms.CheckBox chkConsumerKoen;
		private System.Windows.Forms.CheckBox chkConsumerJo;
		private System.Windows.Forms.CheckBox chkConsumerBart;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstConsumable;
		private System.Windows.Forms.ListBox lstConsumed;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}