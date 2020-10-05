namespace KOASampleCS
{
	partial class AfterMarketBuyStockConditionForm
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
			this.conditionInstitutionPurchaseValue = new System.Windows.Forms.TextBox();
			this.conditionForeignPurchaseValue = new System.Windows.Forms.TextBox();
			this.checkBoxInstitution = new System.Windows.Forms.CheckBox();
			this.checkBoxForeign = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.conditionChangeRateMax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.conditionVolume = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.conditionChangeRateMin = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBoxAdministrative = new System.Windows.Forms.CheckBox();
			this.checkBoxCaution = new System.Windows.Forms.CheckBox();
			this.checkBoxRisk = new System.Windows.Forms.CheckBox();
			this.checkBoxAlert = new System.Windows.Forms.CheckBox();
			this.conditionTradingValue = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// conditionInstitutionPurchaseValue
			// 
			this.conditionInstitutionPurchaseValue.Location = new System.Drawing.Point(164, 64);
			this.conditionInstitutionPurchaseValue.Margin = new System.Windows.Forms.Padding(4);
			this.conditionInstitutionPurchaseValue.Name = "conditionInstitutionPurchaseValue";
			this.conditionInstitutionPurchaseValue.Size = new System.Drawing.Size(215, 28);
			this.conditionInstitutionPurchaseValue.TabIndex = 45;
			this.conditionInstitutionPurchaseValue.TextChanged += new System.EventHandler(this.conditionInstitutionPurchaseValue_TextChanged);
			// 
			// conditionForeignPurchaseValue
			// 
			this.conditionForeignPurchaseValue.Location = new System.Drawing.Point(164, 28);
			this.conditionForeignPurchaseValue.Margin = new System.Windows.Forms.Padding(4);
			this.conditionForeignPurchaseValue.Name = "conditionForeignPurchaseValue";
			this.conditionForeignPurchaseValue.Size = new System.Drawing.Size(215, 28);
			this.conditionForeignPurchaseValue.TabIndex = 44;
			this.conditionForeignPurchaseValue.TextChanged += new System.EventHandler(this.conditionForeignPurchaseValue_TextChanged);
			// 
			// checkBoxInstitution
			// 
			this.checkBoxInstitution.AutoSize = true;
			this.checkBoxInstitution.Location = new System.Drawing.Point(9, 64);
			this.checkBoxInstitution.Name = "checkBoxInstitution";
			this.checkBoxInstitution.Size = new System.Drawing.Size(130, 22);
			this.checkBoxInstitution.TabIndex = 43;
			this.checkBoxInstitution.Text = "기관 양매수";
			this.checkBoxInstitution.UseVisualStyleBackColor = true;
			this.checkBoxInstitution.CheckedChanged += new System.EventHandler(this.checkBoxInstitution_CheckedChanged);
			// 
			// checkBoxForeign
			// 
			this.checkBoxForeign.AutoSize = true;
			this.checkBoxForeign.Location = new System.Drawing.Point(9, 28);
			this.checkBoxForeign.Name = "checkBoxForeign";
			this.checkBoxForeign.Size = new System.Drawing.Size(148, 22);
			this.checkBoxForeign.TabIndex = 42;
			this.checkBoxForeign.Text = "외국인 양매수";
			this.checkBoxForeign.UseVisualStyleBackColor = true;
			this.checkBoxForeign.CheckedChanged += new System.EventHandler(this.checkBoxForeign_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.conditionTradingValue);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.conditionChangeRateMax);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.conditionVolume);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.conditionChangeRateMin);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(662, 211);
			this.groupBox1.TabIndex = 48;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "조건1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(431, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 18);
			this.label4.TabIndex = 48;
			this.label4.Text = "이하";
			// 
			// conditionChangeRateMax
			// 
			this.conditionChangeRateMax.Location = new System.Drawing.Point(301, 31);
			this.conditionChangeRateMax.Margin = new System.Windows.Forms.Padding(4);
			this.conditionChangeRateMax.Name = "conditionChangeRateMax";
			this.conditionChangeRateMax.Size = new System.Drawing.Size(123, 28);
			this.conditionChangeRateMax.TabIndex = 47;
			this.conditionChangeRateMax.TextChanged += new System.EventHandler(this.conditionChangeRateMax_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(219, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 18);
			this.label1.TabIndex = 46;
			this.label1.Text = "이상";
			// 
			// conditionVolume
			// 
			this.conditionVolume.Location = new System.Drawing.Point(89, 70);
			this.conditionVolume.Margin = new System.Windows.Forms.Padding(4);
			this.conditionVolume.Name = "conditionVolume";
			this.conditionVolume.Size = new System.Drawing.Size(215, 28);
			this.conditionVolume.TabIndex = 45;
			this.conditionVolume.TextChanged += new System.EventHandler(this.conditionVolume_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 70);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 18);
			this.label2.TabIndex = 44;
			this.label2.Text = "체결량";
			// 
			// conditionChangeRateMin
			// 
			this.conditionChangeRateMin.Location = new System.Drawing.Point(89, 28);
			this.conditionChangeRateMin.Margin = new System.Windows.Forms.Padding(4);
			this.conditionChangeRateMin.Name = "conditionChangeRateMin";
			this.conditionChangeRateMin.Size = new System.Drawing.Size(123, 28);
			this.conditionChangeRateMin.TabIndex = 43;
			this.conditionChangeRateMin.TextChanged += new System.EventHandler(this.conditionChangeRateMin_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 28);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 18);
			this.label3.TabIndex = 42;
			this.label3.Text = "대비율";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.conditionForeignPurchaseValue);
			this.groupBox2.Controls.Add(this.checkBoxForeign);
			this.groupBox2.Controls.Add(this.checkBoxInstitution);
			this.groupBox2.Controls.Add(this.conditionInstitutionPurchaseValue);
			this.groupBox2.Location = new System.Drawing.Point(12, 230);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(662, 110);
			this.groupBox2.TabIndex = 49;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "수급";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBoxAdministrative);
			this.groupBox3.Controls.Add(this.checkBoxCaution);
			this.groupBox3.Controls.Add(this.checkBoxRisk);
			this.groupBox3.Controls.Add(this.checkBoxAlert);
			this.groupBox3.Location = new System.Drawing.Point(12, 347);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(662, 238);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "제외";
			// 
			// checkBoxAdministrative
			// 
			this.checkBoxAdministrative.AutoSize = true;
			this.checkBoxAdministrative.Location = new System.Drawing.Point(6, 111);
			this.checkBoxAdministrative.Name = "checkBoxAdministrative";
			this.checkBoxAdministrative.Size = new System.Drawing.Size(106, 22);
			this.checkBoxAdministrative.TabIndex = 46;
			this.checkBoxAdministrative.Text = "관리종목";
			this.checkBoxAdministrative.UseVisualStyleBackColor = true;
			this.checkBoxAdministrative.CheckedChanged += new System.EventHandler(this.checkBoxAdministrative_CheckedChanged);
			// 
			// checkBoxCaution
			// 
			this.checkBoxCaution.AutoSize = true;
			this.checkBoxCaution.Location = new System.Drawing.Point(6, 83);
			this.checkBoxCaution.Name = "checkBoxCaution";
			this.checkBoxCaution.Size = new System.Drawing.Size(106, 22);
			this.checkBoxCaution.TabIndex = 45;
			this.checkBoxCaution.Text = "투자주의";
			this.checkBoxCaution.UseVisualStyleBackColor = true;
			this.checkBoxCaution.CheckedChanged += new System.EventHandler(this.checkBoxCaution_CheckedChanged);
			// 
			// checkBoxRisk
			// 
			this.checkBoxRisk.AutoSize = true;
			this.checkBoxRisk.Location = new System.Drawing.Point(9, 55);
			this.checkBoxRisk.Name = "checkBoxRisk";
			this.checkBoxRisk.Size = new System.Drawing.Size(106, 22);
			this.checkBoxRisk.TabIndex = 44;
			this.checkBoxRisk.Text = "투자위험";
			this.checkBoxRisk.UseVisualStyleBackColor = true;
			this.checkBoxRisk.CheckedChanged += new System.EventHandler(this.checkBoxRisk_CheckedChanged);
			// 
			// checkBoxAlert
			// 
			this.checkBoxAlert.AutoSize = true;
			this.checkBoxAlert.Location = new System.Drawing.Point(9, 27);
			this.checkBoxAlert.Name = "checkBoxAlert";
			this.checkBoxAlert.Size = new System.Drawing.Size(106, 22);
			this.checkBoxAlert.TabIndex = 43;
			this.checkBoxAlert.Text = "투자경고";
			this.checkBoxAlert.UseVisualStyleBackColor = true;
			this.checkBoxAlert.CheckedChanged += new System.EventHandler(this.checkBoxAlert_CheckedChanged);
			// 
			// conditionTradingValue
			// 
			this.conditionTradingValue.Location = new System.Drawing.Point(89, 106);
			this.conditionTradingValue.Margin = new System.Windows.Forms.Padding(4);
			this.conditionTradingValue.Name = "conditionTradingValue";
			this.conditionTradingValue.Size = new System.Drawing.Size(215, 28);
			this.conditionTradingValue.TabIndex = 50;
			this.conditionTradingValue.TextChanged += new System.EventHandler(this.conditionTradingValue_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 106);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 18);
			this.label5.TabIndex = 49;
			this.label5.Text = "거래대금";
			// 
			// AfterMarketBuyStockConditionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 1371);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AfterMarketBuyStockConditionForm";
			this.Text = "AfterMarketBuyStockCondition";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox conditionInstitutionPurchaseValue;
		private System.Windows.Forms.TextBox conditionForeignPurchaseValue;
		private System.Windows.Forms.CheckBox checkBoxInstitution;
		private System.Windows.Forms.CheckBox checkBoxForeign;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox conditionVolume;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox conditionChangeRateMin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBoxCaution;
		private System.Windows.Forms.CheckBox checkBoxRisk;
		private System.Windows.Forms.CheckBox checkBoxAlert;
		private System.Windows.Forms.CheckBox checkBoxAdministrative;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox conditionChangeRateMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox conditionTradingValue;
		private System.Windows.Forms.Label label5;
	}
}