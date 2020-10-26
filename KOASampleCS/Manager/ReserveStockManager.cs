using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using KiwoomCode;

namespace KOASampleCS
{
	class ReserveStockManager
	{
		private System.Windows.Forms.Timer reserverOrderStockTimer;
		private DateTime reserveTime;

		List<BuyStockData> reserveStockDataList = new List<BuyStockData>();
		private const string reserveStockDataListFile = "D:\\project\\stockmanager\\stockmanager\\KOASampleCS\\bin\\Debug\\reserveStockDataList.json"; 

		public ReserveStockManager()
		{
			reserverOrderStockTimer = new System.Windows.Forms.Timer();
			reserverOrderStockTimer.Interval = 200;
			reserverOrderStockTimer.Tick += new EventHandler(reserveOrderStockHandler);
			reserveTime = new DateTime();

			readReserveStockDataList();

			if(Config.isAutoStart)
			{
				DateTime time = new DateTime(
					Int32.Parse(DateTime.Now.ToString("yyyy")),
					Int32.Parse(DateTime.Now.ToString("MM")),
					Int32.Parse(DateTime.Now.ToString("dd")),
					Config.ORDER_TIME_HOUR,
					Config.ORDER_TIME_MINUTE,
					Config.ORDER_TIME_SECOND
				);
				reserveOrderStock(true, time);
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

		void reserveOrderStockHandler(object sender, EventArgs e)
		{
			TimeSpan spanTime = DateTime.Now.Subtract(reserveTime);
			if (spanTime.TotalSeconds >= 0)
			{
				if (CoreManager.Instance.accountManager.credit == null)
					return;

				CoreManager.Instance.orderManager.OrderEveryStock(reserveStockDataList);
				reserverOrderStockTimer.Stop();
			}
		}

		public void readReserveStockDataList()
		{
			LoggerUtil.Logger(Log.일반, "readReserveStockDataList");

			if (File.Exists(reserveStockDataListFile) == false)
			{
				LoggerUtil.Logger(Log.일반, "readReserveStockDataList 로딩 실패");
				return;
			}

			reserveStockDataList.Clear();

			string strValue = File.ReadAllText(reserveStockDataListFile);
			JArray stockDataList = JArray.Parse(strValue);
			foreach(JObject obj in stockDataList.Children<JObject>())
			{
				BuyStockData buyStockData = new BuyStockData();
				buyStockData.code = obj["code"].ToString();
				buyStockData.name = obj["name"].ToString();
				buyStockData.price = Int32.Parse(obj["price"].ToString());
				buyStockData.count = Int32.Parse(obj["count"].ToString());
				buyStockData.totalPrice = buyStockData.price * buyStockData.count;
				reserveStockDataList.Add(buyStockData);
			}
		}

		public void saveReserveStockDataList()
		{
			JArray stockList = new JArray();
			for (int i = 0; i < reserveStockDataList.Count; i++)
			{
				String code = reserveStockDataList[i].code;
				String name = reserveStockDataList[i].name;
				int price = reserveStockDataList[i].price;
				int count = reserveStockDataList[i].count;
				int totalPrice = reserveStockDataList[i].totalPrice;
				JObject stockInfo = new JObject(
					new JProperty("code", code),
					new JProperty("name", name),
					new JProperty("price", price),
					new JProperty("count", count)
				);

				stockList.Add(stockInfo);
			}

			File.WriteAllText(reserveStockDataListFile, stockList.ToString());
		}

		public void addReserveStockData(BuyStockData buyStockData)
		{
			buyStockData.count = Config.ORDER_TOTAL_AMOUNT / buyStockData.price;
			buyStockData.totalPrice = buyStockData.price * buyStockData.count;
			reserveStockDataList.Add(buyStockData);
		}

		public List<BuyStockData> getReserveStockDataList()
		{
			return reserveStockDataList;
		}

		public void updateReserveStockDataList(int index, BuyStockData buyStockData)
		{
			reserveStockDataList[index] = buyStockData;
		}
	}
}
