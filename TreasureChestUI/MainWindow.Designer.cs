namespace TreasureChestUI
{
	partial class MainWindow
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this._consumerPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._consumerPanel);
			this.groupBox1.Location = new System.Drawing.Point(584, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 409);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Consumers";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(79, 36);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(225, 20);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(329, 36);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(27, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "<<";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(362, 37);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(27, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = ">>";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// _consumerPanel
			// 
			this._consumerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._consumerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this._consumerPanel.Location = new System.Drawing.Point(3, 16);
			this._consumerPanel.Name = "_consumerPanel";
			this._consumerPanel.Size = new System.Drawing.Size(178, 390);
			this._consumerPanel.TabIndex = 0;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 437);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainWindow";
			this.Text = "Treasure Chest - v2.0";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.FlowLayoutPanel _consumerPanel;
	}
}

