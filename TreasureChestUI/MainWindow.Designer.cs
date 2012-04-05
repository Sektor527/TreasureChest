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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._inventoryPanel = new System.Windows.Forms.Panel();
			this.btnUnconsume = new System.Windows.Forms.Button();
			this.btnConsume = new System.Windows.Forms.Button();
			this._sessionPanel = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._sessionPanel);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 327);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Session";
			// 
			// _inventoryPanel
			// 
			this._inventoryPanel.Location = new System.Drawing.Point(469, 56);
			this._inventoryPanel.Name = "_inventoryPanel";
			this._inventoryPanel.Size = new System.Drawing.Size(246, 277);
			this._inventoryPanel.TabIndex = 2;
			// 
			// btnUnconsume
			// 
			this.btnUnconsume.Location = new System.Drawing.Point(412, 174);
			this.btnUnconsume.Name = "btnUnconsume";
			this.btnUnconsume.Size = new System.Drawing.Size(51, 23);
			this.btnUnconsume.TabIndex = 1;
			this.btnUnconsume.Text = ">>";
			this.btnUnconsume.UseVisualStyleBackColor = true;
			this.btnUnconsume.Click += new System.EventHandler(this.UnconsumeClicked);
			// 
			// btnConsume
			// 
			this.btnConsume.Location = new System.Drawing.Point(412, 145);
			this.btnConsume.Name = "btnConsume";
			this.btnConsume.Size = new System.Drawing.Size(51, 23);
			this.btnConsume.TabIndex = 0;
			this.btnConsume.Text = "<<";
			this.btnConsume.UseVisualStyleBackColor = true;
			this.btnConsume.Click += new System.EventHandler(this.ConsumeClicked);
			// 
			// _sessionPanel
			// 
			this._sessionPanel.ColumnCount = 2;
			this._sessionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._sessionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._sessionPanel.Location = new System.Drawing.Point(6, 19);
			this._sessionPanel.Name = "_sessionPanel";
			this._sessionPanel.RowCount = 2;
			this._sessionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933775F));
			this._sessionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.06622F));
			this._sessionPanel.Size = new System.Drawing.Size(388, 302);
			this._sessionPanel.TabIndex = 3;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 344);
			this.Controls.Add(this._inventoryPanel);
			this.Controls.Add(this.btnUnconsume);
			this.Controls.Add(this.btnConsume);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Treasure Chest - v2.0";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel _inventoryPanel;
		private System.Windows.Forms.Button btnUnconsume;
		private System.Windows.Forms.Button btnConsume;
		private System.Windows.Forms.TableLayoutPanel _sessionPanel;
	}
}

