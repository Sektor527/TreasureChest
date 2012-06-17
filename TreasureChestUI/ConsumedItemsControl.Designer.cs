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
			this.lstConsumed = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
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
			this.lstConsumed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lstConsumed.FullRowSelect = true;
			this.lstConsumed.GridLines = true;
			this.lstConsumed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstConsumed.Location = new System.Drawing.Point(0, 0);
			this.lstConsumed.Name = "lstConsumed";
			this.lstConsumed.Size = new System.Drawing.Size(187, 247);
			this.lstConsumed.TabIndex = 8;
			this.lstConsumed.UseCompatibleStateImageBehavior = false;
			this.lstConsumed.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 25;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 25;
			// 
			// ConsumedItemsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lstConsumed);
			this.Controls.Add(this._consumedTotal);
			this.Name = "ConsumedItemsControl";
			this.Size = new System.Drawing.Size(187, 269);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label _consumedTotal;
		private System.Windows.Forms.ListView lstConsumed;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}
