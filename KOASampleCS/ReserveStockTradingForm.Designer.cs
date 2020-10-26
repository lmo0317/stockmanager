namespace KOASampleCS
{
	partial class ReserveStockTradingForm
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.reserveCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBuy = new System.Windows.Forms.Button();
			this.reserveStockDataGridView = new System.Windows.Forms.DataGridView();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reserveStockDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dateTimePicker);
			this.groupBox2.Controls.Add(this.reserveCheckBox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(13, 824);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(1236, 117);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "예약";
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(78, 18);
			this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(284, 28);
			this.dateTimePicker.TabIndex = 30;
			// 
			// reserveCheckBox
			// 
			this.reserveCheckBox.AutoSize = true;
			this.reserveCheckBox.Location = new System.Drawing.Point(8, 70);
			this.reserveCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.reserveCheckBox.Name = "reserveCheckBox";
			this.reserveCheckBox.Size = new System.Drawing.Size(112, 22);
			this.reserveCheckBox.TabIndex = 0;
			this.reserveCheckBox.Text = "예약 주문";
			this.reserveCheckBox.UseVisualStyleBackColor = true;
			this.reserveCheckBox.CheckedChanged += new System.EventHandler(this.reserveCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 18);
			this.label1.TabIndex = 28;
			this.label1.Text = "시간 : ";
			// 
			// btnBuy
			// 
			this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBuy.Location = new System.Drawing.Point(13, 949);
			this.btnBuy.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuy.Name = "btnBuy";
			this.btnBuy.Size = new System.Drawing.Size(314, 45);
			this.btnBuy.TabIndex = 30;
			this.btnBuy.Text = "전체 주문";
			this.btnBuy.UseVisualStyleBackColor = true;
			this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
			// 
			// reserveStockDataGridView
			// 
			this.reserveStockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.reserveStockDataGridView.Location = new System.Drawing.Point(13, 13);
			this.reserveStockDataGridView.Name = "reserveStockDataGridView";
			this.reserveStockDataGridView.RowTemplate.Height = 30;
			this.reserveStockDataGridView.Size = new System.Drawing.Size(1225, 804);
			this.reserveStockDataGridView.TabIndex = 32;
			this.reserveStockDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.reserveStockDataGridView_CellValueChanged);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUpdate.Location = new System.Drawing.Point(335, 949);
			this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(314, 45);
			this.btnUpdate.TabIndex = 33;
			this.btnUpdate.Text = "갱신";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.Location = new System.Drawing.Point(657, 949);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(314, 45);
			this.btnSave.TabIndex = 34;
			this.btnSave.Text = "저장";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ReserveStockTradingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 1007);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.reserveStockDataGridView);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnBuy);
			this.Name = "ReserveStockTradingForm";
			this.Text = "ReserveStockTradingForm";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reserveStockDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.CheckBox reserveCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuy;
		private System.Windows.Forms.DataGridView reserveStockDataGridView;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnSave;
	}
}