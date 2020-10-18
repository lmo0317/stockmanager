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
		private System.Windows.Forms.Timer reserverOrderStockTimer;
		private DateTime reserveTime;
		private bool isCloseMarket = false;
		private bool canBuyBeforeMarket = false;
		List<StockData> reserveStockDataList = new List<StockData>();

		public void OnReceiveMsg(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			//[505217] 장종료되었습니다.
			//[505182] 장개시전입니다.
			//[571566] 주문불가능한종목입니다.
			//[107179] 장개시전 시간외 매수주문이 완료되었습니다.
			//[571489] 장이 열리지않는 날입니다.
			if (e.sRQName == "주식주문")
			{
				if (e.sMsg.Contains("107179"))
				{
					canBuyBeforeMarket = true;
				}
				else if (e.sMsg.Contains("505217") || e.sMsg.Contains("571489"))
				{
					isCloseMarket = true;
				}
			}
		}

		public OrderManager()
		{
			reserverOrderStockTimer = new System.Windows.Forms.Timer();
			reserverOrderStockTimer.Interval = 200;
			reserverOrderStockTimer.Tick += new EventHandler(reserveOrderStockHandler);
			reserveTime = new DateTime();
		}

		public void reserveOrderStock(bool isStart, DateTime time)
		{
			if (isStart)
			{
				reserveTime = time;
				reserverOrderStockTimer.Start();
			}
			else
			{
				reserverOrderStockTimer.Stop();
			}
		}

		void reserveOrderStockHandler(object sender, EventArgs e)
		{
			TimeSpan spanTime = DateTime.Now.Subtract(reserveTime);
			if(spanTime.TotalSeconds >= 0)
			{
				if (CoreManager.Instance.accountManager.credit == null)
					return;

				OrderEveryStock();
				reserverOrderStockTimer.Stop();
			}
		}

		public void OrderEveryStock()
		{
			List<StockData> stockDataList = CoreManager.Instance.requestManager.getStockDataList();

			if (stockDataList.Count == 0)
				return;

			for (int i = 0; i < stockDataList.Count; i++)
			{
				OrderStock(stockDataList[i], KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE);
				Thread.Sleep(250);
			}
		}

		public void OrderStock(StockData stockData, String orderType)
		{
			String code = stockData.code;
			int regularPrice = stockData.regularPrice;
			int count = stockData.count;
			bool isBuy = stockData.isBuy;

			if(isBuy == false)
			{
				return;
			}

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
				LoggerUtil.Logger(Log.일반, "주문이 전송 되었습니다");
			}
			else
			{
				LoggerUtil.Logger(Log.에러, "주문이 전송 실패 하였습니다. [에러] : " + lRet);
			}
		}
	}
}
