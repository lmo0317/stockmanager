using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOASampleCS
{
	public partial class AfterMarketBuyStockConditionForm : Form
	{
		public AfterMarketBuyStockConditionForm()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			conditionChangeRateMin.Text = (Config.DEFAULT_CHANGE_RATE_MIN).ToString();
			conditionChangeRateMax.Text = (Config.DEFAULT_CHANGE_RATE_MAX).ToString();

			conditionVolume.Text = (Config.DEFAULT_VOLUME).ToString();
			conditionTradingValue.Text = (Config.DEFAULT_TRADING_VALUE).ToString();
			conditionForeignPurchaseValue.Text = (Config.DEFAULT_FOREIGN_PURCHASE_VALUE).ToString();
			conditionInstitutionPurchaseValue.Text = (Config.DEFAULT_INSTITUTION_PURCHASE_VALUE).ToString();

			checkBoxForeign.Checked = Config.DEFAULT_POSITIVE_FOREIGN_PURCHASE;
			checkBoxInstitution.Checked = Config.DEFAULT_POSITIVE_INSTITUTION_PURCHASE;

			checkBoxAlert.Checked = true;
			checkBoxCaution.Checked = true;
			checkBoxRisk.Checked = true;
			checkBoxAdministrative.Checked = true;
		}

		private void conditionVolume_TextChanged(object sender, EventArgs e)
		{
			if (conditionVolume.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.volume = Int32.Parse(conditionVolume.Text);
		}

		private void conditionTradingValue_TextChanged(object sender, EventArgs e)
		{
			if (conditionTradingValue.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.tradingValue = Int64.Parse(conditionTradingValue.Text);
		}

		private void checkBoxForeign_CheckedChanged(object sender, EventArgs e)
		{
			bool isChcked = checkBoxForeign.Checked;
			CoreManager.Instance.requestManager.requestConditionData.positiveForeignPurchase = isChcked;
		}

		private void checkBoxInstitution_CheckedChanged(object sender, EventArgs e)
		{
			bool isChcked = checkBoxInstitution.Checked;
			CoreManager.Instance.requestManager.requestConditionData.positiveInstitutionPurchase = isChcked;
		}

		private void conditionForeignPurchaseValue_TextChanged(object sender, EventArgs e)
		{
			if (conditionForeignPurchaseValue.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.foreignPurchaseValue = Int32.Parse(conditionForeignPurchaseValue.Text);
		}

		private void conditionInstitutionPurchaseValue_TextChanged(object sender, EventArgs e)
		{
			if (conditionInstitutionPurchaseValue.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.institutionPurchaseValue = Int32.Parse(conditionInstitutionPurchaseValue.Text);
		}

		private void checkBoxAlert_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxAlert.Checked)
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Add(Enums.STOCK_STATE_ALERT);
			}
			else
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Remove(Enums.STOCK_STATE_ALERT);
			}
		}

		private void checkBoxRisk_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxRisk.Checked)
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Add(Enums.STOCK_STATE_RISK);
			}
			else
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Remove(Enums.STOCK_STATE_RISK);
			}
		}

		private void checkBoxCaution_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxCaution.Checked)
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Add(Enums.STOCK_STATE_CAUTION);
			}
			else
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Remove(Enums.STOCK_STATE_CAUTION);
			}
		}

		private void checkBoxAdministrative_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxAdministrative.Checked)
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Add(Enums.STOCK_STATE_ADMINISTRATIVE);
			}
			else
			{
				CoreManager.Instance.requestManager.requestConditionData.exceptionStockStateList.Remove(Enums.STOCK_STATE_ADMINISTRATIVE);
			}
		}

		private void conditionChangeRateMin_TextChanged(object sender, EventArgs e)
		{
			if (conditionChangeRateMin.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.changeRateMin = float.Parse(conditionChangeRateMin.Text);
		}

		private void conditionChangeRateMax_TextChanged(object sender, EventArgs e)
		{
			if (conditionChangeRateMax.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.changeRateMax = float.Parse(conditionChangeRateMax.Text);
		}
	}
}
