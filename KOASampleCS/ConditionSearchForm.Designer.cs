namespace KOASampleCS
{
	partial class ConditionSearchForm
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
			this.btnConditionList = new System.Windows.Forms.Button();
			this.conditionGridView = new System.Windows.Forms.DataGridView();
			this.stockItemGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.conditionGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stockItemGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// btnConditionList
			// 
			this.btnConditionList.Location = new System.Drawing.Point(13, 13);
			this.btnConditionList.Name = "btnConditionList";
			this.btnConditionList.Size = new System.Drawing.Size(157, 42);
			this.btnConditionList.TabIndex = 0;
			this.btnConditionList.Text = "조건식 불러오기";
			this.btnConditionList.UseVisualStyleBackColor = true;
			this.btnConditionList.Click += new System.EventHandler(this.btnConditionList_Click);
			// 
			// conditionGridView
			// 
			this.conditionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.conditionGridView.Location = new System.Drawing.Point(13, 62);
			this.conditionGridView.Name = "conditionGridView";
			this.conditionGridView.RowTemplate.Height = 30;
			this.conditionGridView.Size = new System.Drawing.Size(306, 1070);
			this.conditionGridView.TabIndex = 1;
			this.conditionGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.conditionGridView_RowEnter);
			this.conditionGridView.SelectionChanged += new System.EventHandler(this.conditionGridView_SelectionChanged);
			// 
			// stockItemGridView
			// 
			this.stockItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.stockItemGridView.Location = new System.Drawing.Point(325, 62);
			this.stockItemGridView.Name = "stockItemGridView";
			this.stockItemGridView.RowTemplate.Height = 30;
			this.stockItemGridView.Size = new System.Drawing.Size(1622, 1070);
			this.stockItemGridView.TabIndex = 2;
			this.stockItemGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.stockItemGridView_CellMouseClick);
			// 
			// ConditionSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1959, 1144);
			this.Controls.Add(this.stockItemGridView);
			this.Controls.Add(this.conditionGridView);
			this.Controls.Add(this.btnConditionList);
			this.Name = "ConditionSearchForm";
			this.Text = "ConditionSearchForm";
			((System.ComponentModel.ISupportInitialize)(this.conditionGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stockItemGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnConditionList;
		private System.Windows.Forms.DataGridView conditionGridView;
		private System.Windows.Forms.DataGridView stockItemGridView;
	}
}