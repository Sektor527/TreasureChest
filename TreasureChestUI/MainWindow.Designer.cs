namespace TreasureChestUI
{
	partial class MainWindow
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
			System.Windows.Forms.Button _nextSession;
			System.Windows.Forms.Button _previousSession;
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._consumerPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.lstConsumed = new System.Windows.Forms.ListBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this._inventoryPanel = new System.Windows.Forms.Panel();
			this.btnUnconsume = new System.Windows.Forms.Button();
			this.btnConsume = new System.Windows.Forms.Button();
			this._manageConsumers = new System.Windows.Forms.Button();
			_nextSession = new System.Windows.Forms.Button();
			_previousSession = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _nextSession
			// 
			_nextSession.Location = new System.Drawing.Point(270, 17);
			_nextSession.Name = "_nextSession";
			_nextSession.Size = new System.Drawing.Size(27, 20);
			_nextSession.TabIndex = 2;
			_nextSession.Text = ">>";
			_nextSession.UseVisualStyleBackColor = true;
			_nextSession.Click += new System.EventHandler(this.NextSessionClicked);
			// 
			// _previousSession
			// 
			_previousSession.Location = new System.Drawing.Point(237, 17);
			_previousSession.Name = "_previousSession";
			_previousSession.Size = new System.Drawing.Size(27, 20);
			_previousSession.TabIndex = 1;
			_previousSession.Text = "<<";
			_previousSession.UseVisualStyleBackColor = true;
			_previousSession.Click += new System.EventHandler(this.PreviousSessionClicked);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._consumerPanel);
			this.groupBox1.Controls.Add(this.lstConsumed);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(_nextSession);
			this.groupBox1.Controls.Add(_previousSession);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 323);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Session";
			// 
			// _consumerPanel
			// 
			this._consumerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._consumerPanel.Location = new System.Drawing.Point(6, 44);
			this._consumerPanel.Name = "_consumerPanel";
			this._consumerPanel.Size = new System.Drawing.Size(196, 273);
			this._consumerPanel.TabIndex = 3;
			// 
			// lstConsumed
			// 
			this.lstConsumed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstConsumed.FormattingEnabled = true;
			this.lstConsumed.IntegralHeight = false;
			this.lstConsumed.Location = new System.Drawing.Point(208, 44);
			this.lstConsumed.Name = "lstConsumed";
			this.lstConsumed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstConsumed.Size = new System.Drawing.Size(186, 273);
			this.lstConsumed.TabIndex = 4;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(6, 16);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(225, 20);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateChanged);
			// 
			// _inventoryPanel
			// 
			this._inventoryPanel.Location = new System.Drawing.Point(469, 56);
			this._inventoryPanel.Name = "_inventoryPanel";
			this._inventoryPanel.Size = new System.Drawing.Size(246, 303);
			this._inventoryPanel.TabIndex = 2;
			// 
			// btnUnconsume
			// 
			this.btnUnconsume.Location = new System.Drawing.Point(412, 174);
			this.btnUnconsume.Name = "btnUnconsume";
			this.btnUnconsume.Size = new System.Drawing.Size(51, 23);
			this.btnUnconsume.TabIndex = 1;
			this.btnUnconsume.Text = ">>";
			this.btnUnconsume.UseVisualStyleBackColor = true;
			this.btnUnconsume.Click += new System.EventHandler(this.UnconsumeClicked);
			// 
			// btnConsume
			// 
			this.btnConsume.Location = new System.Drawing.Point(412, 145);
			this.btnConsume.Name = "btnConsume";
			this.btnConsume.Size = new System.Drawing.Size(51, 23);
			this.btnConsume.TabIndex = 0;
			this.btnConsume.Text = "<<";
			this.btnConsume.UseVisualStyleBackColor = true;
			this.btnConsume.Click += new System.EventHandler(this.ConsumeClicked);
			// 
			// _manageConsumers
			// 
			this._manageConsumers.Location = new System.Drawing.Point(18, 336);
			this._manageConsumers.Name = "_manageConsumers";
			this._manageConsumers.Size = new System.Drawing.Size(196, 23);
			this._manageConsumers.TabIndex = 3;
			this._manageConsumers.Text = "Manage Consumers";
			this._manageConsumers.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 367);
			this.Controls.Add(this._manageConsumers);
			this.Controls.Add(this._inventoryPanel);
			this.Controls.Add(this.btnUnconsume);
			this.Controls.Add(this.btnConsume);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Treasure Chest - v2.0";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.FlowLayoutPanel _consumerPanel;
		private System.Windows.Forms.Panel _inventoryPanel;
		private System.Windows.Forms.Button btnUnconsume;
		private System.Windows.Forms.Button btnConsume;
		private System.Windows.Forms.ListBox lstConsumed;
		private System.Windows.Forms.Button _manageConsumers;
	}
}

