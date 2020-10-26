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
			this.showConditionForm = new System.Windows.Forms.Button();
			this.grp로그.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).BeginInit();
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
			this.grp로그.Size = new System.Drawing.Size(2199, 1126);
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
			this.stockDataGridView.Size = new System.Drawing.Size(2180, 1088);
			this.stockDataGridView.TabIndex = 27;
			this.stockDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.stockDataGridView_CellMouseClick);
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
			// AfterMarketStockListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2225, 1213);
			this.Controls.Add(this.showConditionForm);
			this.Controls.Add(this.getListForBuy);
			this.Controls.Add(this.grp로그);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AfterMarketStockListForm";
			this.Text = "EditStockListForm";
			this.grp로그.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grp로그;
		private System.Windows.Forms.DataGridView stockDataGridView;
		private System.Windows.Forms.Button getListForBuy;
		private System.Windows.Forms.Button showConditionForm;



	}
}