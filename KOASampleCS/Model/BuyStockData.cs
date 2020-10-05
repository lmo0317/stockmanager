using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class BuyStockData
	{
		public BuyStockData()
		{
			foreignPurchaseVolume = 0;
			institutionPurchaseVolume = 0;
		}

		//beforeDay : 어제
		//afterMarket : 장후
		//regualrMarket : 장중
		
		public bool isBuy;
		public String code;
		public String name;
		public String stockState;

		//구매 수량
		public int count;

		//전체 구매 가격
		public int totalPrcie;
		
		//전일
		public float beforeDayChangeRate;
		public int beforeDayVolume;
		public int beforeDayPrice;
		
		//장중
		public float regularChangeRate;
		public int regularVolume;
		public int regularPrice;
		public int regularOpeningPrice;
		public float regularOpeningChangeRate;
	
		//장후
		public float afterMarketChangeRate;
		public Int64 afterMarketVolume;
		public Int64 afterMarketPrice;
		public Int64 afterMarketTradingValue;
		

		//외인 기관 거래
		public int foreignPurchaseVolume;
		public int institutionPurchaseVolume;
	}
}
