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
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace KOASampleCS
{
	public partial class AfterMarketStockListForm : Form
	{
		public static Dictionary<String, String> mapStockStateCodeToString = new Dictionary<String, String>();
		
		public static String CODE = "종목코드";
		public static String NAME = "종목명";
		public static String STOCK_STATE = "상태";
		public static String AFTER_MARKET_PRICE = "시간외가격";
		public static String AFTER_MARKET_CHANGE_RATE = "시간외대비율";
		public static String AFTER_MARKET_VOLUME = "시간외체결량";
		public static String AFTER_MARKET_TRADING_VALUE = "시간외거래대금";

		public static String REGULAR_OPENING_PRICE = "시가";
		public static String REGULAR_OPENING_CHANGE_RATE = "시가대비율";
		public static String REGULAR_PRICE = "장중가격";
		public static String REGULAR_CHANGE_RATE = "장중대비율";
		public static String REGULAR_VOLUME = "장중체결량";

		public static String FOREIGN_PURCHASE = "외국인";
		public static String INSTITUTION_PURCHASE = "기관";

		private string[] menus = { CODE, NAME, STOCK_STATE,
										AFTER_MARKET_PRICE, AFTER_MARKET_CHANGE_RATE, AFTER_MARKET_VOLUME, AFTER_MARKET_TRADING_VALUE,
										REGULAR_OPENING_PRICE, REGULAR_OPENING_CHANGE_RATE, REGULAR_PRICE, REGULAR_CHANGE_RATE, REGULAR_VOLUME };

		private void makeStockStateMap()
		{
			mapStockStateCodeToString.Add(Enums.STOCK_STATE_NONE, "정상");
			mapStockStateCodeToString.Add(Enums.STOCK_STATE_ALERT, "투자경고");
			mapStockStateCodeToString.Add(Enums.STOCK_STATE_CAUTION, "투자주의");
			mapStockStateCodeToString.Add(Enums.STOCK_STATE_RISK, "투자위험");
			mapStockStateCodeToString.Add(Enums.STOCK_STATE_ADMINISTRATIVE, "관리종목");
		}

		private int getMenuIndex(String menuName)
		{
			return Array.IndexOf(menus, menuName);
		}

		public AfterMarketStockListForm()
		{
			InitializeComponent();
			makeStockStateMap();
			Init();
		}

		private void Init()
		{
			makeStockDataGridView();
		}

		private void makeStockDataGridView()
		{
			for (int i = 0; i < menus.Length; i++)
			{
				stockDataGridView.Columns.Add(menus[i], menus[i]);
			}
			stockDataGridView.Columns[getMenuIndex(AFTER_MARKET_TRADING_VALUE)].Width = 120;
		}

		private void stockListAddToDataGridView(List<AfterMarketStockData> stockDataList)
		{
			stockDataGridView.Rows.Clear();

			for (int i = 0; i < stockDataList.Count; i++)
			{
				String code = stockDataList[i].code;
				String name = stockDataList[i].name;
				String stockState = stockDataList[i].stockState;
				stockState = mapStockStateCodeToString.ContainsKey(stockState) ? mapStockStateCodeToString[stockState] : "";

				String regularOpeningPrice = stockDataList[i].regularOpeningPrice.ToString("#,###");
				String regularOpeningChangeRate = (stockDataList[i].regularOpeningChangeRate * 100).ToString("0.00");
				String regularChangeRate = (stockDataList[i].regularChangeRate * 100).ToString("0.00");
				String regularVolume = stockDataList[i].regularVolume.ToString("#,###");
				String regularPrice = stockDataList[i].regularPrice.ToString("#,###");

				String afterMarketChangeRate = (stockDataList[i].afterMarketChangeRate * 100).ToString("0.00");
				String afterMarketVolume = stockDataList[i].afterMarketVolume.ToString("#,###");
				String afterMarketPrice = stockDataList[i].afterMarketPrice.ToString("#,###");
				String afterMarketTradingValue = (stockDataList[i].afterMarketTradingValue).ToString("#,###");

				String beforeDayChangeRate = (stockDataList[i].beforeDayChangeRate * 100).ToString("0.00");
				String beforeDayVolume = stockDataList[i].beforeDayVolume.ToString("#,###");
				String beforeDayPrice = stockDataList[i].beforeDayPrice.ToString("#,###");

				String foreignPurchaseVolume = stockDataList[i].foreignPurchaseVolume.ToString("#,###");
				String institutionPurchaseVolume = stockDataList[i].institutionPurchaseVolume.ToString("#,###");

				bool isBuy = bool.Parse(stockDataList[i].isBuy.ToString());
				if (foreignPurchaseVolume == "") foreignPurchaseVolume = "0";
				if (institutionPurchaseVolume == "") institutionPurchaseVolume = "0";

				stockDataGridView.Rows.Add(code, name, stockState,
												afterMarketPrice, afterMarketChangeRate, afterMarketVolume, afterMarketTradingValue,
												regularOpeningPrice, regularOpeningChangeRate, regularPrice, regularChangeRate, regularVolume);

				stockDataGridView.Rows[i].Cells[getMenuIndex(REGULAR_OPENING_CHANGE_RATE)].Style.ForeColor = stockDataList[i].regularOpeningChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(REGULAR_CHANGE_RATE)].Style.ForeColor = stockDataList[i].regularChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(AFTER_MARKET_CHANGE_RATE)].Style.ForeColor = stockDataList[i].afterMarketChangeRate > 0 ? Color.Red : Color.Blue;
				//stockDataGridView.Rows[i].Cells[getMenuIndex(FOREIGN_PURCHASE)].Style.ForeColor = stockDataList[i].foreignPurchaseVolume > 0 ? Color.Red : Color.Blue;
				//stockDataGridView.Rows[i].Cells[getMenuIndex(INSTITUTION_PURCHASE)].Style.ForeColor = stockDataList[i].institutionPurchaseVolume > 0 ? Color.Red : Color.Blue;
			}
		}

		private void getListForBuy_Click(object sender, EventArgs e)
		{
			List<AfterMarketStockData> stockDataList = CoreManager.Instance.requestManager.requestAfterMarketStockList();
			stockListAddToDataGridView(stockDataList);
		}

		private void buyBeforeHoursClosing_Click(object sender, EventArgs e)
		{
			//CoreManager.Instance.orderManager.OrderEveryStock();
		}

		private void updateStockDataByCell(DataGridViewCellEventArgs e)
		{
			/*
			StockData stockData = new StockData();
			int index = e.RowIndex;
			stockData.isBuy = ObjectUtil.SaftyParseBoolean(stockDataGridView.Rows[index].Cells[getMenuIndex(CHECKBOX)].Value);
			stockData.code = stockDataGridView.Rows[index].Cells[getMenuIndex(CODE)].Value.ToString();
			stockData.name = stockDataGridView.Rows[index].Cells[getMenuIndex(NAME)].Value.ToString();
			stockData.regularPrice = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(AFTER_MARKET_PRICE)].Value);
			stockData.afterMarketChangeRate = ObjectUtil.SaftyParseFloat(stockDataGridView.Rows[index].Cells[getMenuIndex(AFTER_MARKET_CHANGE_RATE)].Value);

			if (e.ColumnIndex == getMenuIndex(COUNT))
			{
				stockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				stockData.totalPrcie = stockData.count * stockData.regularPrice;
				stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value = stockData.totalPrcie;
			}
			else if (e.ColumnIndex == getMenuIndex(TOTAL_VALUE))
			{
				stockData.totalPrcie = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value);
				stockData.count = stockData.totalPrcie / stockData.regularPrice;
				stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value = stockData.count;
			}
			else
			{
				if (stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value != null)
				{
					stockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				}

				if (stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value != null)
				{
					stockData.totalPrcie = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value);
				}
			}
			
			CoreManager.Instance.requestManager.updateBuySockDataList(index, stockData);
			*/
		}

		private void stockDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			updateStockDataByCell(e);
		}

		private void showConditionForm_Click(object sender, EventArgs e)
		{
			AfterMarketStockListConditionForm afterMarketStockListConditionForm = new AfterMarketStockListConditionForm();
			afterMarketStockListConditionForm.Show();
		}

		private void stockDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.ColumnIndex != -1)
			{
				ContextMenuStrip menu = new ContextMenuStrip();
				menu.Items.Add("예약주문추가", null, new EventHandler(addOrderReserveHandler));
				stockDataGridView.CurrentCell = stockDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				Point pt = stockDataGridView.PointToClient(Control.MousePosition);
				menu.Show(stockDataGridView, pt.X, pt.Y);
			}
		}

		private void addOrderReserveHandler(object sender, EventArgs e)
		{
			int index = CoreManager.Instance.conditionSearchManager.selectedConditionIndex;

			AfterMarketStockData stockData = CoreManager.Instance.requestManager.getStockDataList()[stockDataGridView.CurrentCell.RowIndex];
			BuyStockData buyStockData = new BuyStockData();
			buyStockData.code = stockData.code;
			buyStockData.name = stockData.name;
			buyStockData.price = stockData.beforeDayPrice;
			CoreManager.Instance.reserveStockManager.addReserveStockData(buyStockData);
		}
	}
}
