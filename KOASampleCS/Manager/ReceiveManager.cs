using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiwoomCode;

namespace KOASampleCS
{
	class ReceiveManager
	{
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

		public void OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "주식주문")
			{
				string s원주문번호 = CoreManager.Instance.apiModule.GetCommData(e.sTrCode, "", 0, "").Trim();

				long n원주문번호 = 0;
				bool canConvert = long.TryParse(s원주문번호, out n원주문번호);

				//if (canConvert == true)
				//    txt원주문번호.Text = s원주문번호;
				//else
				//    Logger(Log.에러, "잘못된 원주문번호 입니다");

			}
			// OPT1001 : 주식기본정보
			else if (e.sRQName == "주식기본정보")
			{
				int nCnt = CoreManager.Instance.apiModule.GetRepeatCnt(e.sTrCode, e.sRQName);

				/*
                for (int i = 0; i < nCnt; i++)
                {
                    Logger(Log.조회, "{0} | 현재가:{1:N0} | 등락율:{2} | 거래량:{3:N0} ",
                        axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "종목명").Trim(),
                        Int32.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "현재가").Trim()),
                        axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "등락율").Trim(),
                        Int32.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "거래량").Trim()));
                }
				*/
				string code = CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, 0, "종목코드").Trim();
				long stockPrice = long.Parse(CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim().Replace("-", ""));
				long volume = long.Parse(CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim());
				long marketCapitalization = long.Parse(CoreManager.Instance.apiModule.GetCommData(e.sTrCode, e.sRQName, 0, "시가총액").Trim());
				//string upDownRate = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();
			}
			// OPT10081 : 주식일봉차트조회
			else if (e.sRQName == "주식일봉차트조회")
			{
				int nCnt = CoreManager.Instance.apiModule.GetRepeatCnt(e.sTrCode, e.sRQName);
				for (int i = 0; i < nCnt; i++)
				{
					LoggerUtil.Logger(Log.조회, "{0} | 현재가:{1:N0} | 거래량:{2:N0} | 시가:{3:N0} | 고가:{4:N0} | 저가:{5:N0} ",
						CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "일자").Trim(),
						Int32.Parse(CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "현재가").Trim()),
						Int32.Parse(CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "거래량").Trim()),
						Int32.Parse(CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "시가").Trim()),
						Int32.Parse(CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "고가").Trim()),
						Int32.Parse(CoreManager.Instance.apiModule.CommGetData(e.sTrCode, "", e.sRQName, i, "저가").Trim()));
				}
			}
		}
	}
}
