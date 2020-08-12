using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace KOASampleCS
{
	class RequestManager
	{
		const String MARKET_KOSDAQ = "KOSDAQ";
		const String MARKET_KOSPI = "KOSPI";
		String[] marketList = new String[] { MARKET_KOSPI, MARKET_KOSDAQ };
		int[] stockBuyCount = new int[] { 20, 20 };

		const int STOCK_COUNT = 5;
		const int TIME_OUT = 30 * 1000;
		String urlForCookie = "https://finance.daum.net/domestic/after_hours?market=KOSPI";		

		List<BuyStockData> buyStockDataList = new List<BuyStockData>();
		public RequestConditionData requestConditionData = new RequestConditionData();


		private String GetAfterHourSpacURL(int count, String market)
		{
			return "https://finance.daum.net/api/trend/after_hours_spac?page=1&perPage=" + count.ToString() + 
					"&fieldName=changeRate&order=desc&market=" + market + "&type=CHANGE_RISE&pagination=true";
		}

		public List<BuyStockData> getBuyStockDataList()
		{
			return buyStockDataList;
		}

		public void updateBuySockDataList(int index, BuyStockData buyStockData)
		{
			buyStockDataList[index] = buyStockData;
		}

		private CookieCollection getCookies()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlForCookie);
			request.Method = "GET";
			request.Timeout = TIME_OUT;
			using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
			{
				return resp.Cookies;
			}
		}

		public List<BuyStockData> requestAfterHourSpac()
		{
			buyStockDataList.Clear();
			CookieCollection cookies = getCookies();

			for(int i=0;i<marketList.Length; i++)
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetAfterHourSpacURL(stockBuyCount[i], marketList[i]));
				request.CookieContainer = new CookieContainer();
				request.CookieContainer.Add(cookies);
				request.Referer = "https://finance.daum.net/domestic/after_hours";

				using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
				{
					HttpStatusCode status = resp.StatusCode;
					Stream respStream = resp.GetResponseStream();
					using (StreamReader sr = new StreamReader(respStream))
					{
						String responseText = sr.ReadToEnd();
						JObject obj = JObject.Parse(responseText);
						JArray stocks = JArray.Parse(obj["data"].ToString());
						AddBuyStockDataList(stocks);						
					}
				}
			}

			return buyStockDataList;
		}

        public int compare(BuyStockData left, BuyStockData right)
        {
            return (int)(right.changeRate * 100) - (int)(left.changeRate * 100);
        }

		private void AddBuyStockDataList(JArray stocks)
		{
			for (int i = 0; i < stocks.Count; i++)
			{
				String code = stocks[i]["symbolCode"].ToString().Substring(1, 6);
				String name = stocks[i]["name"].ToString();
				int value = Int32.Parse(stocks[i]["regularHoursTradePrice"].ToString());
				float changeRate = float.Parse(stocks[i]["changeRate"].ToString());
				int volume = Int32.Parse(stocks[i]["accTradeVolume"].ToString());
				int count = Config.ORDER_TOTAL_AMOUNT / value;

				if(changeRate < (requestConditionData.changeRate/100))
					continue;

				if(volume < requestConditionData.volume)
					continue;

                if (name.Contains("선물"))
                    continue;

				BuyStockData buyStockData = new BuyStockData();
				buyStockData.code = code;
				buyStockData.name = name;
				buyStockData.value = value;
				buyStockData.count = count;
				buyStockData.totalValue = value * count;
				buyStockData.changeRate = changeRate;
				buyStockData.volume = volume;
				buyStockData.isBuy = Config.DEFAULT_ORDER_CHECK;
				buyStockDataList.Add(buyStockData);
				requestStockInfo(code);
			}

            buyStockDataList.Sort(compare);
		}

		private void requestStockInfo(String code)
		{
			CoreManager.Instance.apiModule.SetInputValue("종목코드", code);
			int nRet = CoreManager.Instance.apiModule.CommRqData("주식기본정보", "OPT10001", 0, ScreenUtil.GetScrNum());
		}
	}
}
