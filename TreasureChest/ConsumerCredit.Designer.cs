namespace TreasureChest
{
	partial class ConsumerCredit
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
			this._deposit = new System.Windows.Forms.TextBox();
			this._name = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this._credit = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _deposit
			// 
			this._deposit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._deposit.Location = new System.Drawing.Point(67, 0);
			this._deposit.Margin = new System.Windows.Forms.Padding(0);
			this._deposit.Name = "_deposit";
			this._deposit.Size = new System.Drawing.Size(190, 20);
			this._deposit.TabIndex = 0;
			// 
			// _name
			// 
			this._name.AutoSize = true;
			this._name.Dock = System.Windows.Forms.DockStyle.Fill;
			this._name.Location = new System.Drawing.Point(0, 0);
			this._name.Margin = new System.Windows.Forms.Padding(0);
			this._name.Name = "_name";
			this._name.Size = new System.Drawing.Size(67, 21);
			this._name.TabIndex = 1;
			this._name.Text = "Name";
			this._name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.07004F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.92996F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.tableLayoutPanel1.Controls.Add(this._name, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._deposit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this._credit, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 21);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// _credit
			// 
			this._credit.AutoSize = true;
			this._credit.Dock = System.Windows.Forms.DockStyle.Fill;
			this._credit.Location = new System.Drawing.Point(257, 0);
			this._credit.Margin = new System.Windows.Forms.Padding(0);
			this._credit.Name = "_credit";
			this._credit.Size = new System.Drawing.Size(84, 21);
			this._credit.TabIndex = 2;
			this._credit.Text = "label2";
			this._credit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConsumerCredit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ConsumerCredit";
			this.Size = new System.Drawing.Size(341, 21);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox _deposit;
		private System.Windows.Forms.Label _name;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label _credit;
	}
}
