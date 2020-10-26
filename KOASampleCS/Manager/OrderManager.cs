using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using KiwoomCode;

namespace KOASampleCS
{
	class OrderManager
	{
		public void OnReceiveMsg(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			
		}

		public OrderManager()
		{

		}

		public void OrderEveryStock(List<BuyStockData> buyStockDataList)
		{
			if (buyStockDataList.Count == 0)
				return;

			for (int i = 0; i < buyStockDataList.Count; i++)
			{
				OrderStock(buyStockDataList[i], KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE);
				Thread.Sleep(250);
			}
		}

		public void OrderStock(BuyStockData buyStockData, String orderType)
		{
			String code = buyStockData.code;
			int regularPrice = buyStockData.price;
			int count = buyStockData.count;

			if (CoreManager.Instance.accountManager.credit == null || CoreManager.Instance.accountManager.credit.Length != 10)
			{
				LoggerUtil.Logger(Log.에러, "계좌번호 10자리를 입력해 주세요");
				return;
			}

			
			if (code.Length != 6)
			{
				LoggerUtil.Logger(Log.에러, "종목코드 6자리를 입력해 주세요");
				return;
			}

			if (count < 1)
			{
				LoggerUtil.Logger(Log.에러, "주문수량이 1보다 작습니다");
				return;
			}

			if (orderType == KOABiddingType.MARKET_PRICE || orderType == KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE)
			{
				regularPrice = 0;
			}

			int lRet = CoreManager.Instance.apiModule.SendOrder(
						"주식주문",
						ScreenUtil.GetScrNum(), 
						CoreManager.Instance.accountManager.credit, 
						1,
						code, 
						count,
						regularPrice, 
						orderType, 
						"");

			Debug.WriteLine("<< 주문 >> {0} {1} {2}", code, count, regularPrice);

			if (lRet == 0)
			{
				LoggerUtil.Logger(Log.일반, "주문이 전송 되었습니다 - " + buyStockData.name);
			}
			else
			{
				LoggerUtil.Logger(Log.에러, "주문이 전송 실패 하였습니다. [에러] : " + lRet);
			}
		}
	}
}
