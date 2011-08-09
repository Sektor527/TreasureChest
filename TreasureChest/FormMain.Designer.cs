namespace TreasureChest
{
	partial class FormMain
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
			this.btnSessions = new System.Windows.Forms.Button();
			this.btnInventory = new System.Windows.Forms.Button();
			this.btnConsumers = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSessions
			// 
			this.btnSessions.Location = new System.Drawing.Point(105, 150);
			this.btnSessions.Name = "btnSessions";
			this.btnSessions.Size = new System.Drawing.Size(75, 23);
			this.btnSessions.TabIndex = 0;
			this.btnSessions.Text = "Sessions";
			this.btnSessions.UseVisualStyleBackColor = true;
			this.btnSessions.Click += new System.EventHandler(this.btnSessions_Click);
			// 
			// btnInventory
			// 
			this.btnInventory.Location = new System.Drawing.Point(105, 121);
			this.btnInventory.Name = "btnInventory";
			this.btnInventory.Size = new System.Drawing.Size(75, 23);
			this.btnInventory.TabIndex = 1;
			this.btnInventory.Text = "Inventory";
			this.btnInventory.UseVisualStyleBackColor = true;
			this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
			// 
			// btnConsumers
			// 
			this.btnConsumers.Location = new System.Drawing.Point(105, 92);
			this.btnConsumers.Name = "btnConsumers";
			this.btnConsumers.Size = new System.Drawing.Size(75, 23);
			this.btnConsumers.TabIndex = 2;
			this.btnConsumers.Text = "Consumers";
			this.btnConsumers.UseVisualStyleBackColor = true;
			this.btnConsumers.Click += new System.EventHandler(this.btnConsumers_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.btnConsumers);
			this.Controls.Add(this.btnInventory);
			this.Controls.Add(this.btnSessions);
			this.Name = "FormMain";
			this.Text = "Treasure Chest";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSessions;
		private System.Windows.Forms.Button btnInventory;
		private System.Windows.Forms.Button btnConsumers;
	}
}

