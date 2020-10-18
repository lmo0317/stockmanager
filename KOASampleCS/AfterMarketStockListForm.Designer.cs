namespace KOASampleCS
{
	partial class AfterMarketStockListForm
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
			this.getListForBuy = new System.Windows.Forms.Button();
			this.checkBoxDetail = new System.Windows.Forms.CheckBox();
			this.showConditionForm = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grp로그.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grp로그
			// 
			this.grp로그.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp로그.Controls.Add(this.stockDataGridView);
			this.grp로그.Location = new System.Drawing.Point(17, 18);
			this.grp로그.Margin = new System.Windows.Forms.Padding(4);
			this.grp로그.Name = "grp로그";
			this.grp로그.Padding = new System.Windows.Forms.Padding(4);
			this.grp로그.Size = new System.Drawing.Size(2199, 994);
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
			this.stockDataGridView.Location = new System.Drawing.Point(10, 30);
			this.stockDataGridView.Margin = new System.Windows.Forms.Padding(4);
			this.stockDataGridView.Name = "stockDataGridView";
			this.stockDataGridView.RowTemplate.Height = 23;
			this.stockDataGridView.Size = new System.Drawing.Size(2180, 956);
			this.stockDataGridView.TabIndex = 27;
			this.stockDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockDataGridView_CellValueChanged);
			// 
			// getListForBuy
			// 
			this.getListForBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.getListForBuy.Location = new System.Drawing.Point(11, 1152);
			this.getListForBuy.Margin = new System.Windows.Forms.Padding(4);
			this.getListForBuy.Name = "getListForBuy";
			this.getListForBuy.Size = new System.Drawing.Size(311, 46);
			this.getListForBuy.TabIndex = 27;
			this.getListForBuy.Text = "갱신";
			this.getListForBuy.UseVisualStyleBackColor = true;
			this.getListForBuy.Click += new System.EventHandler(this.getListForBuy_Click);
			// 
			// checkBoxDetail
			// 
			this.checkBoxDetail.AutoSize = true;
			this.checkBoxDetail.Location = new System.Drawing.Point(6, 32);
			this.checkBoxDetail.Name = "checkBoxDetail";
			this.checkBoxDetail.Size = new System.Drawing.Size(130, 22);
			this.checkBoxDetail.TabIndex = 38;
			this.checkBoxDetail.Text = "자세히 보기";
			this.checkBoxDetail.UseVisualStyleBackColor = true;
			this.checkBoxDetail.CheckedChanged += new System.EventHandler(this.checkBoxDetail_CheckedChanged);
			// 
			// showConditionForm
			// 
			this.showConditionForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.showConditionForm.Location = new System.Drawing.Point(330, 1155);
			this.showConditionForm.Margin = new System.Windows.Forms.Padding(4);
			this.showConditionForm.Name = "showConditionForm";
			this.showConditionForm.Size = new System.Drawing.Size(314, 45);
			this.showConditionForm.TabIndex = 30;
			this.showConditionForm.Text = "조건 수정";
			this.showConditionForm.UseVisualStyleBackColor = true;
			this.showConditionForm.Click += new System.EventHandler(this.showConditionForm_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.checkBoxDetail);
			this.groupBox1.Location = new System.Drawing.Point(17, 1021);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(534, 124);
			this.groupBox1.TabIndex = 39;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "보기";
			// 
			// AfterMarketStockListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2225, 1213);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.showConditionForm);
			this.Controls.Add(this.getListForBuy);
			this.Controls.Add(this.grp로그);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AfterMarketStockListForm";
			this.Text = "EditStockListForm";
			this.grp로그.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grp로그;
		private System.Windows.Forms.DataGridView stockDataGridView;
		private System.Windows.Forms.Button getListForBuy;
		private System.Windows.Forms.Button showConditionForm;
		private System.Windows.Forms.CheckBox checkBoxDetail;
		private System.Windows.Forms.GroupBox groupBox1;



	}
}