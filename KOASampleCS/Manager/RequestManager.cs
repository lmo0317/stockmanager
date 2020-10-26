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
		int[] stockBuyCount = new int[] { 100, 100 };

		const int STOCK_COUNT = 5;
		const int TIME_OUT = 30 * 1000;
		String urlForCookie = "https://finance.daum.net/domestic/after_hours?market=KOSPI";		

		List<AfterMarketStockData> stockDataList = new List<AfterMarketStockData>();
		public RequestConditionData requestConditionData = new RequestConditionData();


		private String getAfterHourSpacURL(int count, String market)
		{
			return "https://finance.daum.net/api/trend/after_hours_spac?page=1&perPage=" + count.ToString() + 
					"&fieldName=changeRate&order=desc&market=" + market + "&type=CHANGE_RISE&pagination=true";
		}

		private String getStockInvestorDaysURL(String code)
		{
			return "https://finance.daum.net/api/investor/days?perPage=5&symbolCode=" + "A" + code;
		}

		private String getStockSummaryURL(String code)
		{
			return "https://finance.daum.net/api/quotes/" + "A" + code + "?summary=false&changeStatistics=true";
		}

		public List<AfterMarketStockData> getStockDataList()
		{
			return stockDataList;
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

		public List<AfterMarketStockData> requestAfterMarketStockList()
		{
			stockDataList.Clear();
			CookieCollection cookies = getCookies();

			for(int i=0;i<marketList.Length; i++)
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getAfterHourSpacURL(stockBuyCount[i], marketList[i]));
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
						AddStockDataList(stocks);
					}
				}
			}
			stockDataList.Sort(compare);
			return stockDataList;
		}

        public int compare(AfterMarketStockData left, AfterMarketStockData right)
        {
			return (int)(left.afterMarketChangeRate * 10000) - (int)(right.afterMarketChangeRate * 10000);
        }

		private bool isExceptionStockName(String name)
		{
			for(int i=0; i<requestConditionData.exceptionStockNameList.Count; i++)
			{
				if(name.Contains(requestConditionData.exceptionStockNameList[i]))
				{
					return true;
				}
			}

			return false;
		}

		private bool checkSupplyAndDemand(float changeRate, int foreignPurchaseVolume, int institutionPurchaseVolume)
		{
			if (changeRate >= 0.06)
				return true;

			if (requestConditionData.positiveForeignPurchase && foreignPurchaseVolume < requestConditionData.foreignPurchaseValue)
				return false;

			if (requestConditionData.positiveInstitutionPurchase && institutionPurchaseVolume < requestConditionData.institutionPurchaseValue)
				return false;

			return true;
		}

		private void AddStockDataList(JArray stocks)
		{
			for (int i = 0; i < stocks.Count; i++)
			{
				bool isRise = false;
				String change = "";
				String code = stocks[i]["symbolCode"].ToString().Substring(1, 6);
				String name = stocks[i]["name"].ToString();

				if (isExceptionStockName(name))
					continue;

				float afterMarketChangeRate = float.Parse(stocks[i]["changeRate"].ToString());
				Int64 afterMarketVolume = Int64.Parse(stocks[i]["accTradeVolume"].ToString());
				Int64 afterMarketPrice = Int64.Parse(stocks[i]["tradePrice"].ToString());
				Int64 afterMarketTradingValue = afterMarketVolume * afterMarketPrice;

				if (afterMarketChangeRate < (requestConditionData.changeRateMin / 100))
					continue;

				if (afterMarketChangeRate > (requestConditionData.changeRateMax / 100))
					continue;

				if (afterMarketVolume < requestConditionData.volume)
					continue;

				if (afterMarketTradingValue < requestConditionData.tradingValue)
					continue;

				JArray investorDays = requestStockInvestorDays(code); //기관, 외국인 거래
				if (investorDays == null)
					continue;

				change = investorDays[0]["change"].ToString();
				isRise = change == "RISE" || change == "UPPER_LIMIT" ? true : false;
				int beforeDayChangePrice = Int32.Parse(investorDays[0]["changePrice"].ToString()) * (isRise ? 1 : -1);
				int beforeDayVolume = Int32.Parse(investorDays[0]["accTradeVolume"].ToString());
				int beforeDayPrice = Int32.Parse(investorDays[0]["tradePrice"].ToString());
				float beforeDayChangeRate = beforeDayChangePrice / (float)(beforeDayPrice - beforeDayChangePrice);
				int foreignPurchaseVolume = Int32.Parse(investorDays[0]["foreignStraightPurchaseVolume"].ToString());
				int institutionPurchaseVolume = Int32.Parse(investorDays[0]["institutionStraightPurchaseVolume"].ToString());

				if (checkSupplyAndDemand(afterMarketChangeRate, foreignPurchaseVolume, institutionPurchaseVolume) == false)
					continue;
				
				JObject stockSummary = requestStockSummary(code);
				if (stockSummary == null)
					continue;
				
				change = stockSummary["change"].ToString();
				isRise = change == "RISE" || change == "UPPER_LIMIT" ? true : false;
				float regularChangeRate = float.Parse(stockSummary["changeRate"].ToString()) * (isRise ? 1 : -1);
				int regularVolume = Int32.Parse(stockSummary["accTradeVolume"].ToString());
				int regularPrice = Int32.Parse(stockSummary["tradePrice"].ToString());
				int regularOpeningPrice = Int32.Parse(stockSummary["openingPrice"].ToString());
				int count = Config.ORDER_TOTAL_AMOUNT / regularPrice;
				String stockState = stockSummary["stockState"]["marketWarning"].ToString();
				Boolean isAdministrativeIssue = Boolean.Parse(stockSummary["stockState"]["isAdministrativeIssue"].ToString());
				if (isAdministrativeIssue)
				{
					stockState = Enums.STOCK_STATE_ADMINISTRATIVE;
				}

				if (requestConditionData.exceptionStockStateList.Contains(stockState))
					continue;

				AfterMarketStockData stockData = new AfterMarketStockData();
				stockData.code = code;
				stockData.name = name;
				stockData.stockState = stockState;
				stockData.isBuy = Config.DEFAULT_ORDER_CHECK;

				stockData.regularChangeRate = regularChangeRate;
				stockData.regularVolume = regularVolume;
				stockData.regularPrice = regularPrice;
				stockData.regularOpeningPrice = regularOpeningPrice;
				stockData.regularOpeningChangeRate = (float)(regularOpeningPrice - beforeDayPrice) / beforeDayPrice;

				stockData.afterMarketChangeRate = afterMarketChangeRate;
				stockData.afterMarketVolume = afterMarketVolume;
				stockData.afterMarketPrice = afterMarketPrice;
				stockData.afterMarketTradingValue = afterMarketTradingValue;

				stockData.beforeDayChangeRate = beforeDayChangeRate;
				stockData.beforeDayVolume = beforeDayVolume;
				stockData.beforeDayPrice = beforeDayPrice;

				stockData.foreignPurchaseVolume = foreignPurchaseVolume;
				stockData.institutionPurchaseVolume = institutionPurchaseVolume;

				stockDataList.Add(stockData);
			}
		}

		private JArray requestStockInvestorDays(String code)
		{
			CookieCollection cookies = getCookies();
			String stockInvestorDaysUrl = getStockInvestorDaysURL(code);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(stockInvestorDaysUrl);
			request.CookieContainer = new CookieContainer();
			request.CookieContainer.Add(cookies);
			request.Referer = "https://finance.daum.net/quotes/A005930";

			using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
			{
				HttpStatusCode status = resp.StatusCode;
				Stream respStream = resp.GetResponseStream();
				using (StreamReader sr = new StreamReader(respStream))
				{
					try
					{
						String responseText = sr.ReadToEnd();
						JObject obj = JObject.Parse(responseText);
						return JArray.Parse(obj["data"].ToString());
					}
					catch
					{
						return null;
					}
				}
			}
		}

		private JObject requestStockSummary(String code)
		{
			CookieCollection cookies = getCookies();
			String stockSummaryURL = getStockSummaryURL(code);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(stockSummaryURL);
			request.CookieContainer = new CookieContainer();
			request.CookieContainer.Add(cookies);
			request.Referer = "https://finance.daum.net/quotes/A005930";

			using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
			{
				HttpStatusCode status = resp.StatusCode;
				Stream respStream = resp.GetResponseStream();
				using (StreamReader sr = new StreamReader(respStream))
				{
					try
					{
						String responseText = sr.ReadToEnd();
						return JObject.Parse(responseText);
					}
					catch
					{
						return null;
					}
				}
			}
		}
	}
}
