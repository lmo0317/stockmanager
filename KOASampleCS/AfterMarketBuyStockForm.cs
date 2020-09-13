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
	public partial class AfterMarketBuyStockForm : Form
	{
		AfterMarketBuyStockConditionForm afterMarketBuyStockConditionForm = new AfterMarketBuyStockConditionForm();
		public static Dictionary<String, String> mapStockStateCodeToString = new Dictionary<String, String>();
		
		public static String CHECKBOX = "CHECKBOX";
		public static String CODE = "종목코드";
		public static String NAME = "종목명";
		public static String STOCK_STATE = "상태";
		public static String COUNT = "수량";
		public static String TOTAL_VALUE = "합계";
		public static String AFTER_MARKET_PRICE = "시간외가격";
		public static String AFTER_MARKET_CHANGE_RATE = "시간외대비율";
		public static String AFTER_MARKET_VOLUME = "시간외체결량";
		
		public static String BEFORE_DAY_PRICE = "전일가격";
		public static String BEFORE_DAY_CHANGE_RATE = "전일대비율";
		public static String BEFORE_DAY_VOLUME = "전일체결량";

		public static String REGULAR_OPENING_PRICE = "시가";
		public static String REGULAR_OPENING_CHANGE_RATE = "시가대비율";
		public static String REGULAR_PRICE = "장중가격";
		public static String REGULAR_CHANGE_RATE = "장중대비율";
		public static String REGULAR_VOLUME = "장중체결량";

		public static String FOREIGN_PURCHASE = "외국인";
		public static String INSTITUTION_PURCHASE = "기관";

		private string[] menus = { CHECKBOX, CODE, NAME, STOCK_STATE, COUNT, TOTAL_VALUE, 
										AFTER_MARKET_PRICE, AFTER_MARKET_CHANGE_RATE, AFTER_MARKET_VOLUME,
										BEFORE_DAY_PRICE, BEFORE_DAY_CHANGE_RATE, BEFORE_DAY_VOLUME,
										REGULAR_OPENING_PRICE, REGULAR_OPENING_CHANGE_RATE, REGULAR_PRICE, REGULAR_CHANGE_RATE, REGULAR_VOLUME,										
										FOREIGN_PURCHASE, INSTITUTION_PURCHASE };

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

		public AfterMarketBuyStockForm()
		{
			InitializeComponent();
			makeStockStateMap();
			Init();
		}

		private void Init()
		{
			makeStockDataGridView();
			
			dateTimePicker.Format = DateTimePickerFormat.Custom;
			dateTimePicker.ShowUpDown = true;
			dateTimePicker.CustomFormat = "HH시 mm분 ss초";

			DateTime dateTime = new DateTime(
				Int32.Parse(DateTime.Now.ToString("yyyy")), 
				Int32.Parse(DateTime.Now.ToString("MM")), 
				Int32.Parse(DateTime.Now.ToString("dd")), 
				Config.ORDER_TIME_HOUR,
				Config.ORDER_TIME_MINUTE,
				Config.ORDER_TIME_SECOND
			);

			dateTimePicker.Value = dateTime;

			if (Config.isAutoStart)
			{
				reserveCheckBox.Checked = true;
				getListForBuy_Click(null, null);
			}

			makeStockDataGridViewDetail(false);
			checkBoxDetail.Checked = false;
		}

		private void makeStockDataGridView()
		{
			DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
			checkBoxColumn.HeaderText = "매수";
			checkBoxColumn.Name = "매수";
			
			stockDataGridView.Columns.Add(checkBoxColumn);
			for (int i = 1; i < menus.Length; i++)
			{
				stockDataGridView.Columns.Add(menus[i], menus[i]);
			}

			stockDataGridView.Columns[getMenuIndex(CHECKBOX)].Width = 40;

			stockDataGridView.Columns[1].Visible = false;
		}

		private void stockListAddToDataGridView(List<BuyStockData> buyStockDataList)
		{
			stockDataGridView.Rows.Clear();

			for (int i = 0; i < buyStockDataList.Count; i++)
			{
				String code = buyStockDataList[i].code;
				String name = buyStockDataList[i].name;
				String stockState = buyStockDataList[i].stockState;
				stockState = mapStockStateCodeToString.ContainsKey(stockState) ? mapStockStateCodeToString[stockState] : "";
				String count = buyStockDataList[i].count.ToString();
				String totalPrcie = buyStockDataList[i].totalPrcie.ToString("#,###");

				String regularOpeningPrice = buyStockDataList[i].regularOpeningPrice.ToString("#,###");
				String regularOpeningChangeRate = (buyStockDataList[i].regularOpeningChangeRate * 100).ToString("0.00");
				String regularChangeRate = (buyStockDataList[i].regularChangeRate * 100).ToString("0.00");
				String regularVolume = buyStockDataList[i].regularVolume.ToString("#,###");
				String regularPrice = buyStockDataList[i].regularPrice.ToString("#,###");

				String afterMarketChangeRate = (buyStockDataList[i].afterMarketChangeRate * 100).ToString("0.00");
				String afterMarketVolume = buyStockDataList[i].afterMarketVolume.ToString("#,###");
				String afterMarketPrice = buyStockDataList[i].afterMarketPrice.ToString("#,###");

				String beforeDayChangeRate = (buyStockDataList[i].beforeDayChangeRate * 100).ToString("0.00");
				String beforeDayVolume = buyStockDataList[i].beforeDayVolume.ToString("#,###");
				String beforeDayPrice = buyStockDataList[i].beforeDayPrice.ToString("#,###");

				String foreignPurchaseVolume = buyStockDataList[i].foreignPurchaseVolume.ToString("#,###");
				String institutionPurchaseVolume = buyStockDataList[i].institutionPurchaseVolume.ToString("#,###");
				
				bool isBuy = bool.Parse(buyStockDataList[i].isBuy.ToString());
				if (foreignPurchaseVolume == "") foreignPurchaseVolume = "0";
				if (institutionPurchaseVolume == "") institutionPurchaseVolume = "0";

				stockDataGridView.Rows.Add(isBuy, code, name, stockState, count, totalPrcie,
												afterMarketPrice, afterMarketChangeRate, afterMarketVolume,
												beforeDayPrice, beforeDayChangeRate, beforeDayVolume,
												regularOpeningPrice, regularOpeningChangeRate, regularPrice, regularChangeRate, regularVolume,
												foreignPurchaseVolume, institutionPurchaseVolume);

				stockDataGridView.Rows[i].Cells[getMenuIndex(BEFORE_DAY_CHANGE_RATE)].Style.ForeColor = buyStockDataList[i].beforeDayChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(REGULAR_OPENING_CHANGE_RATE)].Style.ForeColor = buyStockDataList[i].regularOpeningChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(REGULAR_CHANGE_RATE)].Style.ForeColor = buyStockDataList[i].regularChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(AFTER_MARKET_CHANGE_RATE)].Style.ForeColor = buyStockDataList[i].afterMarketChangeRate > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(FOREIGN_PURCHASE)].Style.ForeColor = buyStockDataList[i].foreignPurchaseVolume > 0 ? Color.Red : Color.Blue;
				stockDataGridView.Rows[i].Cells[getMenuIndex(INSTITUTION_PURCHASE)].Style.ForeColor = buyStockDataList[i].institutionPurchaseVolume > 0 ? Color.Red : Color.Blue;
			}
		}

		private void getListForBuy_Click(object sender, EventArgs e)
		{
			List<BuyStockData> buyStockDataList = CoreManager.Instance.requestManager.requestAfterHourSpac();
			stockListAddToDataGridView(buyStockDataList);
		}

		private void buyBeforeHoursClosing_Click(object sender, EventArgs e)
		{
			CoreManager.Instance.orderManager.OrderEveryStock();
		}

		private void updateBuyStockDataByCell(DataGridViewCellEventArgs e)
		{
			BuyStockData buyStockData = new BuyStockData();
			int index = e.RowIndex;
			buyStockData.isBuy = ObjectUtil.SaftyParseBoolean(stockDataGridView.Rows[index].Cells[getMenuIndex(CHECKBOX)].Value);
			buyStockData.code = stockDataGridView.Rows[index].Cells[getMenuIndex(CODE)].Value.ToString();
			buyStockData.name = stockDataGridView.Rows[index].Cells[getMenuIndex(NAME)].Value.ToString();
			buyStockData.regularPrice = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(AFTER_MARKET_PRICE)].Value);
			buyStockData.afterMarketChangeRate = ObjectUtil.SaftyParseFloat(stockDataGridView.Rows[index].Cells[getMenuIndex(AFTER_MARKET_CHANGE_RATE)].Value);

			if (e.ColumnIndex == getMenuIndex(COUNT))
			{
				buyStockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				buyStockData.totalPrcie = buyStockData.count * buyStockData.regularPrice;
				stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value = buyStockData.totalPrcie;
			}
			else if (e.ColumnIndex == getMenuIndex(TOTAL_VALUE))
			{
				buyStockData.totalPrcie = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value);
				buyStockData.count = buyStockData.totalPrcie / buyStockData.regularPrice;
				stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value = buyStockData.count;
			}
			else
			{
				if (stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value != null)
				{
					buyStockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				}

				if (stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value != null)
				{
					buyStockData.totalPrcie = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_VALUE)].Value);
				}
			}

			
			CoreManager.Instance.requestManager.updateBuySockDataList(index, buyStockData);
		}

		private void BuyStockForm_Load(object sender, EventArgs e)
		{

		}

		private void stockDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			updateBuyStockDataByCell(e);
		}

		private void reserveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = reserveCheckBox.Checked;
			CoreManager.Instance.orderManager.reserveOrderStock(isChecked, dateTimePicker.Value);
		}

		private void checkBoxDetail_CheckedChanged(object sender, EventArgs e)
		{
			bool isChcked = checkBoxDetail.Checked;
			makeStockDataGridViewDetail(isChcked);
		}

		private void showConditionForm_Click(object sender, EventArgs e)
		{
			afterMarketBuyStockConditionForm.Show();
		}

		private void makeStockDataGridViewDetail(bool isDetail)
		{
			if (isDetail)
			{
				for (int i = 1; i < menus.Length; i++)
				{
					stockDataGridView.Columns[i].Visible = true;
				}
			}
			else
			{
				stockDataGridView.Columns[getMenuIndex(CODE)].Visible = false;
				stockDataGridView.Columns[getMenuIndex(BEFORE_DAY_PRICE)].Visible = false;
				stockDataGridView.Columns[getMenuIndex(BEFORE_DAY_CHANGE_RATE)].Visible = false;
				stockDataGridView.Columns[getMenuIndex(BEFORE_DAY_VOLUME)].Visible = false;
			}
		}
	}
}
