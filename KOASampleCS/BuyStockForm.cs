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
	public partial class BuyStockForm : Form
	{
		public BuyStockForm()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			makeStockDataGridView();
			conditionChangeRate.Text = (Config.DEFAULT_CHANGE_RATE).ToString();
			conditionVolume.Text = (Config.DEFAULT_VOLUME).ToString();
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
		}

		private void makeStockDataGridView()
		{
			DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
			checkBoxColumn.HeaderText = "매수";
			checkBoxColumn.Name = "매수";
			
			stockDataGridView.Columns.Add(checkBoxColumn);
			stockDataGridView.Columns.Add("종목코드", "종목코드");
			stockDataGridView.Columns.Add("종목명", "종목명");
			stockDataGridView.Columns.Add("전일종가", "전일종가");
			stockDataGridView.Columns.Add("대비율", "대비율");
			stockDataGridView.Columns.Add("수량", "수량");
			stockDataGridView.Columns.Add("합계", "합계");
			stockDataGridView.Columns.Add("체결량", "체결량");

			stockDataGridView.Columns[0].Width = 40;
			stockDataGridView.Columns[3].DefaultCellStyle.Format = "#,###";
			stockDataGridView.Columns[5].DefaultCellStyle.Format = "#,###";
			stockDataGridView.Columns[6].DefaultCellStyle.Format = "#,###";
			stockDataGridView.Columns[7].DefaultCellStyle.Format = "#,###";
		}

		private void stockListAddToDataGridView(List<BuyStockData> buyStockDataList)
		{
			stockDataGridView.Rows.Clear();

			for (int i = 0; i < buyStockDataList.Count; i++)
			{
				String code = buyStockDataList[i].code;
				String name = buyStockDataList[i].name;
				String value = buyStockDataList[i].value.ToString("#,###");
				String changeRate = (buyStockDataList[i].changeRate * 100).ToString("+0.00");
				String count = buyStockDataList[i].count.ToString();
				String volume = buyStockDataList[i].volume.ToString("#,###");
				String totalValue = buyStockDataList[i].totalValue.ToString("#,###");
				bool isBuy = bool.Parse(buyStockDataList[i].isBuy.ToString());
				stockDataGridView.Rows.Add(isBuy, code, name, value, changeRate, count, totalValue, volume);
				stockDataGridView.Rows[i].Cells[4].Style.ForeColor = Color.Red;
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
			buyStockData.isBuy = ObjectUtil.SaftyParseBoolean(stockDataGridView.Rows[index].Cells[0].Value);
			buyStockData.code = stockDataGridView.Rows[index].Cells[1].Value.ToString();
			buyStockData.name = stockDataGridView.Rows[index].Cells[2].Value.ToString();
			buyStockData.value = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[3].Value);
			buyStockData.changeRate = ObjectUtil.SaftyParseFloat(stockDataGridView.Rows[index].Cells[4].Value);

			if(e.ColumnIndex == 5)
			{
				buyStockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[5].Value);
				buyStockData.totalValue = buyStockData.count * buyStockData.value;
				stockDataGridView.Rows[index].Cells[6].Value = buyStockData.totalValue;
			}
			else if(e.ColumnIndex == 6)
			{
				buyStockData.totalValue = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[6].Value);
				buyStockData.count = buyStockData.totalValue / buyStockData.value;
				stockDataGridView.Rows[index].Cells[5].Value = buyStockData.count;
			}
			else
			{
				if (stockDataGridView.Rows[index].Cells[5].Value != null)
				{
					buyStockData.count = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[5].Value);
				}

				if (stockDataGridView.Rows[index].Cells[6].Value != null)
				{
					buyStockData.totalValue = ObjectUtil.SaftyParseInt(stockDataGridView.Rows[index].Cells[6].Value);
				}
			}

			
			CoreManager.Instance.requestManager.updateBuySockDataList(index, buyStockData);
		}

		private void stockDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			updateBuyStockDataByCell(e);
		}

		private void BuyStockForm_Load(object sender, EventArgs e)
		{

		}

		private void conditionChangeRate_TextChanged(object sender, EventArgs e)
		{
			if (conditionChangeRate.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.changeRate = float.Parse(conditionChangeRate.Text);
		}

		private void reserveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = reserveCheckBox.Checked;
			CoreManager.Instance.orderManager.reserveOrderStock(isChecked, dateTimePicker.Value);
		}

		private void conditionVolume_TextChanged(object sender, EventArgs e)
		{
			if (conditionVolume.Text == "")
				return;

			CoreManager.Instance.requestManager.requestConditionData.volume = Int32.Parse(conditionVolume.Text);
		}
	}
}
