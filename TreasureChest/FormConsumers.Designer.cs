namespace TreasureChest
{
	partial class FormConsumers
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
			this.btnDeposit = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this._consumerPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// btnDeposit
			// 
			this.btnDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeposit.Location = new System.Drawing.Point(9, 308);
			this.btnDeposit.Name = "btnDeposit";
			this.btnDeposit.Size = new System.Drawing.Size(75, 23);
			this.btnDeposit.TabIndex = 7;
			this.btnDeposit.Text = "Deposit";
			this.btnDeposit.UseVisualStyleBackColor = true;
			this.btnDeposit.Click += new System.EventHandler(this.Deposit);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(285, 308);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// _consumerPanel
			// 
			this._consumerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._consumerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._consumerPanel.Location = new System.Drawing.Point(9, 9);
			this._consumerPanel.Name = "_consumerPanel";
			this._consumerPanel.Size = new System.Drawing.Size(354, 293);
			this._consumerPanel.TabIndex = 23;
			// 
			// FormConsumers
			// 
			this.AcceptButton = this.btnDeposit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(372, 343);
			this.Controls.Add(this._consumerPanel);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDeposit);
			this.Name = "FormConsumers";
			this.Text = "FormConsumers";
			this.Load += new System.EventHandler(this.FormConsumers_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnDeposit;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.FlowLayoutPanel _consumerPanel;
	}
}