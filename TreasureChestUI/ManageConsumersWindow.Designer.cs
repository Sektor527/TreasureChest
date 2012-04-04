namespace TreasureChestUI
{
	partial class ManageConsumersWindow
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
			System.Windows.Forms.Button _close;
			_close = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _close
			// 
			_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_close.Location = new System.Drawing.Point(197, 227);
			_close.Name = "_close";
			_close.Size = new System.Drawing.Size(75, 23);
			_close.TabIndex = 1;
			_close.Text = "Close";
			_close.UseVisualStyleBackColor = true;
			_close.Click += new System.EventHandler(this.CloseClicked);
			// 
			// ManageConsumersWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = _close;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(_close);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageConsumersWindow";
			this.Text = "Manage Consumers";
			this.ResumeLayout(false);

		}

		#endregion

	}
}