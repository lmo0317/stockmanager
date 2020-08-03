namespace KOASampleCS
{
	partial class BuyStockForm
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
			this.grp로그 = new System.Windows.Forms.GroupBox();
			this.stockDataGridView = new System.Windows.Forms.DataGridView();
			this.buyBeforeHoursClosing = new System.Windows.Forms.Button();
			this.getListForBuy = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.conditionChangeRate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.reserveCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.conditionVolume = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grp로그.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// grp로그
			// 
			this.grp로그.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp로그.Controls.Add(this.stockDataGridView);
			this.grp로그.Location = new System.Drawing.Point(12, 12);
			this.grp로그.Name = "grp로그";
			this.grp로그.Size = new System.Drawing.Size(1115, 347);
			this.grp로그.TabIndex = 25;
			this.grp로그.TabStop = false;
			this.grp로그.Text = "종목 리스트";
			// 
			// stockDataGridView
			// 
			this.stockDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.stockDataGridView.Location = new System.Drawing.Point(7, 20);
			this.stockDataGridView.Name = "stockDataGridView";
			this.stockDataGridView.RowTemplate.Height = 23;
			this.stockDataGridView.Size = new System.Drawing.Size(1102, 321);
			this.stockDataGridView.TabIndex = 27;
			this.stockDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockDataGridView_CellValueChanged);
			// 
			// buyBeforeHoursClosing
			// 
			this.buyBeforeHoursClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buyBeforeHoursClosing.Location = new System.Drawing.Point(232, 649);
			this.buyBeforeHoursClosing.Name = "buyBeforeHoursClosing";
			this.buyBeforeHoursClosing.Size = new System.Drawing.Size(220, 30);
			this.buyBeforeHoursClosing.TabIndex = 26;
			this.buyBeforeHoursClosing.Text = "장전 시간외 주문";
			this.buyBeforeHoursClosing.UseVisualStyleBackColor = true;
			this.buyBeforeHoursClosing.Click += new System.EventHandler(this.buyBeforeHoursClosing_Click);
			// 
			// getListForBuy
			// 
			this.getListForBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.getListForBuy.Location = new System.Drawing.Point(8, 649);
			this.getListForBuy.Name = "getListForBuy";
			this.getListForBuy.Size = new System.Drawing.Size(218, 31);
			this.getListForBuy.TabIndex = 27;
			this.getListForBuy.Text = "리스트 로딩";
			this.getListForBuy.UseVisualStyleBackColor = true;
			this.getListForBuy.Click += new System.EventHandler(this.getListForBuy_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.conditionVolume);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.conditionChangeRate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(12, 365);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1115, 118);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "조건";
			// 
			// conditionChangeRate
			// 
			this.conditionChangeRate.Location = new System.Drawing.Point(66, 26);
			this.conditionChangeRate.Name = "conditionChangeRate";
			this.conditionChangeRate.Size = new System.Drawing.Size(152, 21);
			this.conditionChangeRate.TabIndex = 27;
			this.conditionChangeRate.TextChanged += new System.EventHandler(this.conditionChangeRate_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 26;
			this.label3.Text = "대비율 : ";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dateTimePicker);
			this.groupBox2.Controls.Add(this.reserveCheckBox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(12, 489);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1115, 118);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "예약";
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(53, 46);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker.TabIndex = 30;
			// 
			// reserveCheckBox
			// 
			this.reserveCheckBox.AutoSize = true;
			this.reserveCheckBox.Location = new System.Drawing.Point(8, 21);
			this.reserveCheckBox.Name = "reserveCheckBox";
			this.reserveCheckBox.Size = new System.Drawing.Size(76, 16);
			this.reserveCheckBox.TabIndex = 0;
			this.reserveCheckBox.Text = "예약 주문";
			this.reserveCheckBox.UseVisualStyleBackColor = true;
			this.reserveCheckBox.CheckedChanged += new System.EventHandler(this.reserveCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 28;
			this.label1.Text = "시간 : ";
			// 
			// conditionVolume
			// 
			this.conditionVolume.Location = new System.Drawing.Point(66, 70);
			this.conditionVolume.Name = "conditionVolume";
			this.conditionVolume.Size = new System.Drawing.Size(152, 21);
			this.conditionVolume.TabIndex = 29;
			this.conditionVolume.TextChanged += new System.EventHandler(this.conditionVolume_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 28;
			this.label2.Text = "체결량 : ";
			// 
			// BuyStockForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1133, 690);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buyBeforeHoursClosing);
			this.Controls.Add(this.getListForBuy);
			this.Controls.Add(this.grp로그);
			this.Name = "BuyStockForm";
			this.Text = "EditStockListForm";
			this.Load += new System.EventHandler(this.BuyStockForm_Load);
			this.grp로그.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grp로그;
		private System.Windows.Forms.DataGridView stockDataGridView;
		private System.Windows.Forms.Button buyBeforeHoursClosing;
		private System.Windows.Forms.Button getListForBuy;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox conditionChangeRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.CheckBox reserveCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox conditionVolume;
		private System.Windows.Forms.Label label2;



	}
}