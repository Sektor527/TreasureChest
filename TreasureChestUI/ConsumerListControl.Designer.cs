namespace TreasureChestUI
{
	partial class ConsumerListControl
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
			this._manageConsumers = new System.Windows.Forms.Button();
			this._consumerPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// _manageConsumers
			// 
			this._manageConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._manageConsumers.Location = new System.Drawing.Point(0, 253);
			this._manageConsumers.Name = "_manageConsumers";
			this._manageConsumers.Size = new System.Drawing.Size(196, 23);
			this._manageConsumers.TabIndex = 5;
			this._manageConsumers.Text = "Manage Consumers";
			this._manageConsumers.UseVisualStyleBackColor = true;
			this._manageConsumers.Click += new System.EventHandler(this.ManageConsumers);
			// 
			// _consumerPanel
			// 
			this._consumerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._consumerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._consumerPanel.Location = new System.Drawing.Point(0, 0);
			this._consumerPanel.Name = "_consumerPanel";
			this._consumerPanel.Size = new System.Drawing.Size(196, 247);
			this._consumerPanel.TabIndex = 4;
			// 
			// ConsumerListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._manageConsumers);
			this.Controls.Add(this._consumerPanel);
			this.Name = "ConsumerListControl";
			this.Size = new System.Drawing.Size(197, 275);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _manageConsumers;
		private System.Windows.Forms.FlowLayoutPanel _consumerPanel;
	}
}
