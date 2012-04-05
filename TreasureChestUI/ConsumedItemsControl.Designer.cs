namespace TreasureChestUI
{
	partial class ConsumedItemsControl
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
			this._consumedTotal = new System.Windows.Forms.Label();
			this.lstConsumed = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// _consumedTotal
			// 
			this._consumedTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._consumedTotal.Location = new System.Drawing.Point(-3, 250);
			this._consumedTotal.Name = "_consumedTotal";
			this._consumedTotal.Size = new System.Drawing.Size(186, 15);
			this._consumedTotal.TabIndex = 7;
			this._consumedTotal.Text = "Cost:";
			this._consumedTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lstConsumed
			// 
			this.lstConsumed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstConsumed.FormattingEnabled = true;
			this.lstConsumed.IntegralHeight = false;
			this.lstConsumed.Location = new System.Drawing.Point(0, 0);
			this.lstConsumed.Name = "lstConsumed";
			this.lstConsumed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstConsumed.Size = new System.Drawing.Size(186, 247);
			this.lstConsumed.TabIndex = 6;
			// 
			// ConsumedItemsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._consumedTotal);
			this.Controls.Add(this.lstConsumed);
			this.Name = "ConsumedItemsControl";
			this.Size = new System.Drawing.Size(187, 269);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label _consumedTotal;
		private System.Windows.Forms.ListBox lstConsumed;
	}
}
