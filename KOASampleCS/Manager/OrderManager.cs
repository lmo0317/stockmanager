using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiwoomCode;
using System.Diagnostics;
using System.Threading;
using KiwoomCode;

namespace KOASampleCS
{
	class OrderManager
	{
		private System.Windows.Forms.Timer reserverOrderStockTimer;
		private DateTime reserveTime;
		private bool isOpenMarket = false;
		private bool canBuyBeforeMarket = false;

		public void OnReceiveMsg(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
            //[505182] 장개시전입니다.
            //[571566] 주문불가능한종목입니다.
            //[107179] 장개시전 시간외 매수주문이 완료되었습니다.

			if (e.sRQName == "주식주문")
			{
                if (canBuyBeforeMarket == false)
                {
                    canBuyBeforeMarket = e.sMsg.Contains("[107179]");
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

				//시간외 거래가 가능한지 확인한다.
				if (canBuyBeforeMarket)
				{
					//시간외 거래가 가능하면 리스트(1~n)개의 종목을 구매한다.
					OrderEveryStock();
					reserverOrderStockTimer.Stop();
				}
				else
				{
					//시간외 거래가 가능하지 않다면 0번째 종목을 구매해봐서 거래가 가능한지 확인한다.
					checkCanBuyBeforeMarket();
					Thread.Sleep(500);
				}
			}
		}

		public void checkCanBuyBeforeMarket()
		{
			List<BuyStockData> buyStockDataList = CoreManager.Instance.requestManager.getBuyStockDataList();

			if (buyStockDataList.Count == 0)
				return;

			OrderStock(buyStockDataList[0], KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE);
		}

		public void OrderEveryStock()
		{
			List<BuyStockData> buyStockDataList = CoreManager.Instance.requestManager.getBuyStockDataList();

			if (buyStockDataList.Count == 0)
				return;
			
			for (int i = 1; i < buyStockDataList.Count; i++)
			{
				OrderStock(buyStockDataList[i], KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE);
				Thread.Sleep(250);
			}
		}

		public void OrderStock(BuyStockData buyStockData, String orderType)
		{
			String code = buyStockData.code;
			int value = buyStockData.value;
			int count = buyStockData.count;
			bool isBuy = buyStockData.isBuy;

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
				value = 0;
			}

			// =================================================
			// 주식주문
			int lRet = CoreManager.Instance.apiModule.SendOrder(
						"주식주문",
						ScreenUtil.GetScrNum(), 
						CoreManager.Instance.accountManager.credit, 
						1,
						code, 
						count, 
						value, 
						orderType, 
						"");

			Debug.WriteLine("<< 주문 >> {0} {1} {2}",code, count, value);

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
