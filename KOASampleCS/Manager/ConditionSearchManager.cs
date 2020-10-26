using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace KOASampleCS
{
	class ConditionSearchManager
	{
		public List<ConditionInfo> conditionList { get; set; }
		public int selectedConditionIndex { get; set; }
		public int currentStockIndex = 0;

		public void OnReceiveConditionVer()
		{
			conditionList = new List<ConditionInfo>();
			string conditionNameList = CoreManager.Instance.apiModule.GetConditionNameList();
			string[] conditionNameArray = conditionNameList.Split(';');

			for(int i=0; i<conditionNameArray.Length; i++)
			{
				string[] conditionInfo = conditionNameArray[i].Split('^');
				if(conditionInfo.Length == 2)
				{
					conditionList.Add(new ConditionInfo()
					{
						number = Int32.Parse(conditionInfo[0].Trim()),
						name = conditionInfo[1].Trim()
					});
				}
			}

			CoreManager.Instance.formManager.conditionSearchForm.OnReceiveConditionVer();
		}

		public void OnReceiveTrData(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			int nCnt = CoreManager.Instance.apiModule.GetRepeatCnt(e.sTrCode, e.sRQName);

			for (int i = 0; i < nCnt; i++)
			{
				string _code = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();
				string _name = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
				string _price = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim();
				_price = StringUtil.GetRegularString(_price);

				string _chagnePrice = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "전일대비").Trim();
				string _chagneRate = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "등락율").Trim();
				string _volume = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "거래량").Trim();
				string _openPrice = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "시가").Trim();
				string _highPrice = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "고가").Trim();
				string _lowPrice = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, i, "저가").Trim();

				ConditionStockData stockItemInfo = new ConditionStockData()
				{
					code = _code,
					name = _name,
					price = _price,
					changePrice = _chagnePrice,
					changeRate = _chagneRate,
					volume = _volume,
					openPrice = _openPrice,
					highPrice = _highPrice,
					lowPrice = _lowPrice
				};

				conditionList[selectedConditionIndex].stockItemList.Add(stockItemInfo);
			}

			currentStockIndex = 0;
			CoreManager.Instance.formManager.conditionSearchForm.updateStockItemGridView();
			RequestAftermarketTrading(null);
		}

		public int compare(ConditionStockData left, ConditionStockData right)
		{
			return (int)(right.afterMarketChangeRate * 10000) - (int)(left.afterMarketChangeRate * 10000);
		}

		public void RequestAftermarketTrading(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			Debug.WriteLine("RequestAftermarketTrading");
			Debug.WriteLine(conditionList[selectedConditionIndex].stockItemList.Count);
			Debug.WriteLine(currentStockIndex);

			if(e != null)
			{
				string price = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, 0, "시간외단일가_현재가").Trim();
				float afterMarketChangeRate = float.Parse(CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, 0, "시간외단일가_등락률").Trim());
				conditionList[selectedConditionIndex].stockItemList[currentStockIndex].afterMarketPrice = price;
				conditionList[selectedConditionIndex].stockItemList[currentStockIndex].afterMarketChangeRate = afterMarketChangeRate;
				currentStockIndex++;
			}

			if (currentStockIndex >= conditionList[selectedConditionIndex].stockItemList.Count)
			{
				conditionList[selectedConditionIndex].stockItemList.Sort(compare);
				CoreManager.Instance.formManager.conditionSearchForm.updateStockItemGridView();
				return;
			}

			ConditionStockData stockItemInfo = conditionList[selectedConditionIndex].stockItemList[currentStockIndex];
			CoreManager.Instance.apiModule.SetInputValue("종목코드", stockItemInfo.code);
			CoreManager.Instance.apiModule.CommRqData("시간외단일가요청", "opt10087", 0, ScreenUtil.GetScrNum());
			Thread.Sleep(350);
		}
	}
}
