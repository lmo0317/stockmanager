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

		public void OnReceiveMsg(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			if (e.sRQName == "주식주문")
			{	
				isOpenMarket = !e.sMsg.Contains("[505217]");
			}
		}

		public OrderManager()
		{
			reserverOrderStockTimer = new System.Windows.Forms.Timer();
			reserverOrderStockTimer.Interval = 200;
			reserverOrderStockTimer.Tick += new EventHandler(reserveOrderStockHandler);

			reserveTime = new DateTime();
		}

		void reserveOrderStockHandler(object sender, EventArgs e)
		{
			TimeSpan spanTime = DateTime.Now.Subtract(reserveTime);
			if(spanTime.TotalSeconds >= 0)
			{
				if (CoreManager.Instance.accountManager.credit == null)
					return;

				if(OrderEveryStock())
					reserverOrderStockTimer.Stop();
			}
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

		public bool OrderEveryStock()
		{
			List<BuyStockData> buyStockDataList = CoreManager.Instance.requestManager.getBuyStockDataList();
			for (int i = 1; i < buyStockDataList.Count; i++)
			{
				OrderStock(buyStockDataList[i], KOABiddingType.BEFORE_MARKET_EXTRA_TIME_CLOSING_PRICE);
				Thread.Sleep(250);
			}

			return true;
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
