namespace TreasureChestUI
{
	partial class ConsumerControl
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
			this._checkbox = new System.Windows.Forms.CheckBox();
			this._credit = new System.Windows.Forms.Label();
			this._deposit = new System.Windows.Forms.Button();
			this._entryField = new System.Windows.Forms.Panel();
			this._cancel = new System.Windows.Forms.Button();
			this._submit = new System.Windows.Forms.Button();
			this._depositValue = new System.Windows.Forms.TextBox();
			this._entryField.SuspendLayout();
			this.SuspendLayout();
			// 
			// _checkbox
			// 
			this._checkbox.AutoSize = true;
			this._checkbox.Location = new System.Drawing.Point(0, 0);
			this._checkbox.Margin = new System.Windows.Forms.Padding(0);
			this._checkbox.Name = "_checkbox";
			this._checkbox.Size = new System.Drawing.Size(80, 17);
			this._checkbox.TabIndex = 0;
			this._checkbox.Text = "checkBox1";
			this._checkbox.UseVisualStyleBackColor = true;
			this._checkbox.CheckedChanged += new System.EventHandler(this.CheckboxCheckedChanged);
			// 
			// _credit
			// 
			this._credit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._credit.AutoSize = true;
			this._credit.Location = new System.Drawing.Point(90, 1);
			this._credit.Margin = new System.Windows.Forms.Padding(0);
			this._credit.Name = "_credit";
			this._credit.Size = new System.Drawing.Size(35, 13);
			this._credit.TabIndex = 1;
			this._credit.Text = "label1";
			// 
			// _deposit
			// 
			this._deposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._deposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._deposit.Location = new System.Drawing.Point(146, 0);
			this._deposit.Margin = new System.Windows.Forms.Padding(0);
			this._deposit.Name = "_deposit";
			this._deposit.Size = new System.Drawing.Size(23, 17);
			this._deposit.TabIndex = 2;
			this._deposit.Text = "$";
			this._deposit.UseVisualStyleBackColor = true;
			this._deposit.Click += new System.EventHandler(this.Deposit);
			// 
			// _entryField
			// 
			this._entryField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._entryField.Controls.Add(this._cancel);
			this._entryField.Controls.Add(this._submit);
			this._entryField.Controls.Add(this._depositValue);
			this._entryField.Location = new System.Drawing.Point(0, 0);
			this._entryField.Margin = new System.Windows.Forms.Padding(0);
			this._entryField.Name = "_entryField";
			this._entryField.Size = new System.Drawing.Size(169, 16);
			this._entryField.TabIndex = 3;
			this._entryField.Visible = false;
			// 
			// _cancel
			// 
			this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cancel.Location = new System.Drawing.Point(146, 0);
			this._cancel.Margin = new System.Windows.Forms.Padding(0);
			this._cancel.Name = "_cancel";
			this._cancel.Size = new System.Drawing.Size(22, 16);
			this._cancel.TabIndex = 2;
			this._cancel.Text = "x";
			this._cancel.UseVisualStyleBackColor = true;
			this._cancel.Click += new System.EventHandler(this.CancelDeposit);
			// 
			// _submit
			// 
			this._submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._submit.Location = new System.Drawing.Point(125, 0);
			this._submit.Margin = new System.Windows.Forms.Padding(0);
			this._submit.Name = "_submit";
			this._submit.Size = new System.Drawing.Size(22, 16);
			this._submit.TabIndex = 1;
			this._submit.Text = "+";
			this._submit.UseVisualStyleBackColor = true;
			this._submit.Click += new System.EventHandler(this.SubmitDeposit);
			// 
			// _depositValue
			// 
			this._depositValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this._depositValue.Location = new System.Drawing.Point(0, 0);
			this._depositValue.Margin = new System.Windows.Forms.Padding(0);
			this._depositValue.Name = "_depositValue";
			this._depositValue.Size = new System.Drawing.Size(125, 20);
			this._depositValue.TabIndex = 0;
			this._depositValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
			// 
			// ConsumerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._entryField);
			this.Controls.Add(this._deposit);
			this.Controls.Add(this._credit);
			this.Controls.Add(this._checkbox);
			this.ConsumerName = "ConsumerControl";
			this.Size = new System.Drawing.Size(169, 16);
			this._entryField.ResumeLayout(false);
			this._entryField.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox _checkbox;
		private System.Windows.Forms.Label _credit;
		private System.Windows.Forms.Button _deposit;
		private System.Windows.Forms.Panel _entryField;
		private System.Windows.Forms.Button _cancel;
		private System.Windows.Forms.Button _submit;
		private System.Windows.Forms.TextBox _depositValue;
	}
}
