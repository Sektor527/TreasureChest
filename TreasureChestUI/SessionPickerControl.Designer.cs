namespace TreasureChestUI
{
	partial class SessionPickerControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Button _nextSession;
			System.Windows.Forms.Button _previousSession;
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			_nextSession = new System.Windows.Forms.Button();
			_previousSession = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _nextSession
			// 
			_nextSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			_nextSession.Location = new System.Drawing.Point(264, 1);
			_nextSession.Name = "_nextSession";
			_nextSession.Size = new System.Drawing.Size(27, 20);
			_nextSession.TabIndex = 5;
			_nextSession.Text = ">>";
			_nextSession.UseVisualStyleBackColor = true;
			_nextSession.Click += new System.EventHandler(this.NextSessionClicked);
			// 
			// _previousSession
			// 
			_previousSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			_previousSession.Location = new System.Drawing.Point(231, 1);
			_previousSession.Name = "_previousSession";
			_previousSession.Size = new System.Drawing.Size(27, 20);
			_previousSession.TabIndex = 4;
			_previousSession.Text = "<<";
			_previousSession.UseVisualStyleBackColor = true;
			_previousSession.Click += new System.EventHandler(this.PreviousSessionClicked);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(225, 20);
			this.dateTimePicker1.TabIndex = 3;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.OnDateChanged);
			// 
			// SessionPickerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(_nextSession);
			this.Controls.Add(_previousSession);
			this.Name = "SessionPickerControl";
			this.Size = new System.Drawing.Size(291, 21);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}
