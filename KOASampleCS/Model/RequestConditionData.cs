using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class RequestConditionData
	{
		public RequestConditionData()
		{
			changeRateMin = Config.DEFAULT_CHANGE_RATE_MIN;
			changeRateMax = Config.DEFAULT_CHANGE_RATE_MAX;
			volume = Config.DEFAULT_VOLUME;
			tradingValue = Config.DEFAULT_TRADING_VALUE;
			foreignPurchaseValue = Config.DEFAULT_FOREIGN_PURCHASE_VALUE;
			institutionPurchaseValue = Config.DEFAULT_INSTITUTION_PURCHASE_VALUE;
			positiveForeignPurchase = Config.DEFAULT_POSITIVE_FOREIGN_PURCHASE;
			positiveInstitutionPurchase = Config.DEFAULT_POSITIVE_INSTITUTION_PURCHASE;
			
			exceptionStockStateList.Add(Enums.STOCK_STATE_ALERT);
			exceptionStockStateList.Add(Enums.STOCK_STATE_CAUTION);
			exceptionStockStateList.Add(Enums.STOCK_STATE_RISK);
			exceptionStockStateList.Add(Enums.STOCK_STATE_ADMINISTRATIVE);

			exceptionStockNameList.Add("선물");
			exceptionStockNameList.Add("셀트리온");
		}

		public float changeRateMin;
		public float changeRateMax;
		public int volume;
		public Int64 tradingValue;
		public bool positiveForeignPurchase;
		public bool positiveInstitutionPurchase;
		public int foreignPurchaseValue;
		public int institutionPurchaseValue;
		public List<String> exceptionStockNameList = new List<String>();
		public List<String> exceptionStockStateList = new List<String>();
	}
}
