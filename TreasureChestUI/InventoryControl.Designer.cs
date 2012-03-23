namespace TreasureChestUI
{
	partial class InventoryControl
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
			this._deleteInventory = new System.Windows.Forms.Button();
			this.numProductCount = new System.Windows.Forms.NumericUpDown();
			this.txtProductPrice = new System.Windows.Forms.TextBox();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this._addInventory = new System.Windows.Forms.Button();
			this.lstInventory = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.numProductCount)).BeginInit();
			this.SuspendLayout();
			// 
			// _deleteInventory
			// 
			this._deleteInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._deleteInventory.Location = new System.Drawing.Point(293, 289);
			this._deleteInventory.Name = "_deleteInventory";
			this._deleteInventory.Size = new System.Drawing.Size(23, 23);
			this._deleteInventory.TabIndex = 5;
			this._deleteInventory.Text = "-";
			this._deleteInventory.UseVisualStyleBackColor = true;
			this._deleteInventory.Click += new System.EventHandler(this.DeleteItem);
			// 
			// numProductCount
			// 
			this.numProductCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numProductCount.Location = new System.Drawing.Point(212, 290);
			this.numProductCount.Name = "numProductCount";
			this.numProductCount.Size = new System.Drawing.Size(46, 20);
			this.numProductCount.TabIndex = 3;
			this.numProductCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// txtProductPrice
			// 
			this.txtProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductPrice.Location = new System.Drawing.Point(150, 290);
			this.txtProductPrice.Name = "txtProductPrice";
			this.txtProductPrice.Size = new System.Drawing.Size(56, 20);
			this.txtProductPrice.TabIndex = 2;
			// 
			// txtProductName
			// 
			this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductName.Location = new System.Drawing.Point(0, 289);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(144, 20);
			this.txtProductName.TabIndex = 1;
			// 
			// _addInventory
			// 
			this._addInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._addInventory.Location = new System.Drawing.Point(264, 289);
			this._addInventory.Name = "_addInventory";
			this._addInventory.Size = new System.Drawing.Size(23, 23);
			this._addInventory.TabIndex = 4;
			this._addInventory.Text = "+";
			this._addInventory.UseVisualStyleBackColor = true;
			this._addInventory.Click += new System.EventHandler(this.AddItem);
			// 
			// lstInventory
			// 
			this.lstInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lstInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lstInventory.FullRowSelect = true;
			this.lstInventory.GridLines = true;
			this.lstInventory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstInventory.Location = new System.Drawing.Point(0, 0);
			this.lstInventory.Name = "lstInventory";
			this.lstInventory.Size = new System.Drawing.Size(316, 284);
			this.lstInventory.TabIndex = 0;
			this.lstInventory.UseCompatibleStateImageBehavior = false;
			this.lstInventory.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 25;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 25;
			// 
			// InventoryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._deleteInventory);
			this.Controls.Add(this.numProductCount);
			this.Controls.Add(this.txtProductPrice);
			this.Controls.Add(this.txtProductName);
			this.Controls.Add(this._addInventory);
			this.Controls.Add(this.lstInventory);
			this.Name = "InventoryControl";
			this.Size = new System.Drawing.Size(318, 315);
			this.Load += new System.EventHandler(this.LoadWindow);
			((System.ComponentModel.ISupportInitialize)(this.numProductCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _deleteInventory;
		private System.Windows.Forms.NumericUpDown numProductCount;
		private System.Windows.Forms.TextBox txtProductPrice;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.Button _addInventory;
		private System.Windows.Forms.ListView lstInventory;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}
