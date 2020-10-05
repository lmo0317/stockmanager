using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiwoomCode;
using System.Diagnostics;
using System.Threading;

namespace KOASampleCS
{
	class ReceiveManager
	{
		public void OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
		{
			
		}

		public void OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
		{
			CoreManager.Instance.conditionSearchManager.OnReceiveConditionVer();			
		}

		public void OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			if (e.sGubun == "0")
			{
				LoggerUtil.Logger(Log.실시간, "구분 : 주문체결통보");
				LoggerUtil.Logger(Log.실시간, "주문/체결시간 : " + CoreManager.Instance.apiModule.GetChejanData(908));
				LoggerUtil.Logger(Log.실시간, "종목명 : " + CoreManager.Instance.apiModule.GetChejanData(302));
				LoggerUtil.Logger(Log.실시간, "주문수량 : " + CoreManager.Instance.apiModule.GetChejanData(900));
				LoggerUtil.Logger(Log.실시간, "주문가격 : " + CoreManager.Instance.apiModule.GetChejanData(901));
				LoggerUtil.Logger(Log.실시간, "체결수량 : " + CoreManager.Instance.apiModule.GetChejanData(911));
				LoggerUtil.Logger(Log.실시간, "체결가격 : " + CoreManager.Instance.apiModule.GetChejanData(910));
				LoggerUtil.Logger(Log.실시간, "=======================================");
			}
			else if (e.sGubun == "1")
			{
				LoggerUtil.Logger(Log.실시간, "구분 : 잔고통보");
			}
			else if (e.sGubun == "3")
			{
				LoggerUtil.Logger(Log.실시간, "구분 : 특이신호");
			}
		}

		public void OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			LoggerUtil.Logger(Log.조회, "===================================================");
			LoggerUtil.Logger(Log.조회, "화면번호:{0} | RQName:{1} | TRCode:{2} | 메세지:{3}", e.sScrNo, e.sRQName, e.sTrCode, e.sMsg);
			CoreManager.Instance.orderManager.OnReceiveMsg(e);
		}

		public void OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			LoggerUtil.Logger(Log.실시간, "종목코드 : {0} | RealType : {1} | RealData : {2}", e.sRealKey, e.sRealType, e.sRealData);

			if (e.sRealType == "주식시세")
			{
				LoggerUtil.Logger(Log.실시간, "종목코드 : {0} | 현재가 : {1:C} | 등락율 : {2} | 누적거래량 : {3:N0} ",
						e.sRealKey,
						Int32.Parse(CoreManager.Instance.apiModule.GetCommRealData(e.sRealType, 10).Trim()),
						CoreManager.Instance.apiModule.GetCommRealData(e.sRealType, 12).Trim(),
						Int32.Parse(CoreManager.Instance.apiModule.GetCommRealData(e.sRealType, 13).Trim()));
			}
		}

		public void OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
		{
			String codeList = e.strCodeList.Trim();
			if(codeList.Length > 0)
			{
				codeList = codeList.Remove(codeList.Length - 1);
			}

			int nCodeCount = codeList.Trim().Split(';').Length;

			if(e.nNext == 2)
			{
				CoreManager.Instance.apiModule.SendCondition(e.sScrNo, e.strConditionName, e.nIndex, 2);
			}

			CoreManager.Instance.apiModule.CommKwRqData(codeList, 0, nCodeCount, 0, "관심종목정보", ScreenUtil.GetScrNum());
		}

		public void OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if(e.sRQName == "관심종목정보")
			{
				CoreManager.Instance.conditionSearchManager.OnReceiveTrData(e);
			}
			else if(e.sRQName == "시간외단일가요청")
			{
				CoreManager.Instance.conditionSearchManager.RequestAftermarketTrading(e);
			}
		}
	}
}
