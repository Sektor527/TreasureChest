namespace TreasureChest
{
	partial class FormInventory
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
			this.lstInventory = new System.Windows.Forms.ListView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtProductPrice = new System.Windows.Forms.TextBox();
			this.numProductCount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numProductCount)).BeginInit();
			this.SuspendLayout();
			// 
			// lstInventory
			// 
			this.lstInventory.Location = new System.Drawing.Point(12, 12);
			this.lstInventory.Name = "lstInventory";
			this.lstInventory.Size = new System.Drawing.Size(420, 284);
			this.lstInventory.TabIndex = 0;
			this.lstInventory.UseCompatibleStateImageBehavior = false;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 302);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(357, 302);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// txtProductName
			// 
			this.txtProductName.Location = new System.Drawing.Point(93, 304);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(144, 20);
			this.txtProductName.TabIndex = 3;
			// 
			// txtProductPrice
			// 
			this.txtProductPrice.Location = new System.Drawing.Point(243, 304);
			this.txtProductPrice.Name = "txtProductPrice";
			this.txtProductPrice.Size = new System.Drawing.Size(56, 20);
			this.txtProductPrice.TabIndex = 4;
			// 
			// numProductCount
			// 
			this.numProductCount.Location = new System.Drawing.Point(305, 305);
			this.numProductCount.Name = "numProductCount";
			this.numProductCount.Size = new System.Drawing.Size(46, 20);
			this.numProductCount.TabIndex = 5;
			// 
			// FormInventory
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 337);
			this.Controls.Add(this.numProductCount);
			this.Controls.Add(this.txtProductPrice);
			this.Controls.Add(this.txtProductName);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstInventory);
			this.Name = "FormInventory";
			this.Text = "FormInventory";
			((System.ComponentModel.ISupportInitialize)(this.numProductCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lstInventory;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.TextBox txtProductPrice;
		private System.Windows.Forms.NumericUpDown numProductCount;
	}
}