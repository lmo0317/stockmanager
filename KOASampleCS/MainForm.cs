/************************************************************
  샘플버전 : 1.0.0.0 ( 2015.01.23 )
  샘플제작 : (주)에스비씨엔 / sbcn.co.kr/ ZooATS.com
  샘플환경 : Visual Studio 2013 / C# 5.0
  샘플문의 : support@zooats.com / john@sbcn.co.kr
  전    화 : 02-719-5500 / 070-7777-6555
************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiwoomCode;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;
using System.IO;

namespace KOASampleCS
{
    public partial class MainForm : Form
    {
        // 실시간 연결 종료
        private void DisconnectAllRealData()
        {
            for( int i = ScreenUtil.scrNum; i > 5000; i-- )
            {
                axKHOpenAPI.DisconnectRealData(i.ToString());
            }

			ScreenUtil.scrNum = 5000;
        }

        public MainForm()
        {
            InitializeComponent();
			Init();
        }

		private void Init()
		{
			LoggerUtil.lst실시간 = lst실시간;
			LoggerUtil.lst조회 = lst조회;
			LoggerUtil.lst에러 = lst에러;
			LoggerUtil.lst일반 = lst일반;
			CoreManager.Instance.moduleManager.openApiModule = axKHOpenAPI;

			//if (Config.isAutoStart)
			//{
			//	axKHOpenAPI.CommConnect();
			//	시간외주문ToolStripMenuItem_Click(null, null);
			//}
		}

        // 로그를 출력합니다.
        public void Logger(Log type, string format, params Object[] args)
        {
			LoggerUtil.Logger(type, format, args);
        }

        // 로그인 창을 엽니다.
        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.CommConnect() == 0)
            {
                Logger(Log.일반, "로그인창 열기 성공");
            }
            else
            {
                Logger(Log.에러, "로그인창 열기 실패");
            }
        }

        // 샘플 프로그램을 종료 합니다.
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 로그아웃
        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectAllRealData();
            axKHOpenAPI.CommTerminate();
            Logger(Log.일반, "로그아웃");
        }

        // 접속상태확인
        private void 접속상태ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                Logger(Log.일반, "Open API 연결 : 미연결");
            }
            else
            {
                Logger(Log.일반, "Open API 연결 : 연결중");
            }
        }

        private void axKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (Error.IsError(e.nErrCode))
            {
                Logger(Log.일반, "[로그인 처리결과] " + Error.GetErrorMessage());
				계좌조회ToolStripMenuItem_Click(null, null);
            }
            else
            {
                Logger(Log.에러, "[로그인 처리결과] " + Error.GetErrorMessage());
            }

			CoreManager.Instance.receiveManager.OnEventConnect(sender, e);
        }

		private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveTrData(sender, e);
		}

		private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveRealData(sender, e);
		}

		private void axKHOpenAPI_OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveMsg(sender, e);
		}

		private void axKHOpenAPI_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveChejanData(sender, e);
		}

		private void axKHOpenAPI_OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveConditionVer(sender, e);
		}

		private void axKHOpenAPI_OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
		{
			CoreManager.Instance.receiveManager.OnReceiveTrCondition(sender, e);
		}

        private void 계좌조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = axKHOpenAPI.GetLoginInfo("USER_ID");
            String name = axKHOpenAPI.GetLoginInfo("USER_NAME");
            string[] arr계좌 = axKHOpenAPI.GetLoginInfo("ACCNO").Split(';');
            cbo계좌.Items.AddRange(arr계좌);
            cbo계좌.SelectedIndex = 0;
        }

		private void cbo계좌_SelectedIndexChanged(object sender, EventArgs e)
		{
			CoreManager.Instance.accountManager.credit = cbo계좌.Items[cbo계좌.SelectedIndex].ToString();
		}
		
		private void 조건식조회ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConditionSearchForm conditionSearchForm = new ConditionSearchForm();
			CoreManager.Instance.formManager.conditionSearchForm = conditionSearchForm;
			conditionSearchForm.Show();
		}

		private void 시간외주문ToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			AfterMarketBuyStockForm buyStockForm = new AfterMarketBuyStockForm();
			buyStockForm.Show();
		}
    }
}
