using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOASampleCS
{
	public partial class ReserveStockTradingForm : Form
	{
		public static String CODE = "종목코드";
		public static String NAME = "종목명";
		public static String PRICE = "금액";
		public static String COUNT = "수량";
		public static String TOTAL_PRICE = "총매매금액";

		private string[] menus = { CODE, NAME, PRICE, COUNT, TOTAL_PRICE};

		public ReserveStockTradingForm()
		{
			InitializeComponent();
			Init();
		}

		private int getMenuIndex(String menuName)
		{
			return Array.IndexOf(menus, menuName);
		}

		private void Init()
		{
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
			makeStockDataGridView();
			updateStockDataGridView();
		}

		private void reserveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = reserveCheckBox.Checked;
			CoreManager.Instance.reserveStockManager.reserveOrderStock(isChecked, dateTimePicker.Value);
		}

		private void makeStockDataGridView()
		{
			for (int i = 0; i < menus.Length; i++)
			{
				reserveStockDataGridView.Columns.Add(menus[i], menus[i]);
			}
		}

		private void updateStockDataGridView()
		{
			List<BuyStockData> reserveStockDataList = CoreManager.Instance.reserveStockManager.getReserveStockDataList();

			reserveStockDataGridView.Rows.Clear();

			for (int i = 0; i < reserveStockDataList.Count; i++)
			{
				String code = reserveStockDataList[i].code;
				String name = reserveStockDataList[i].name;
				String price = reserveStockDataList[i].price.ToString("#,###");
				String count = reserveStockDataList[i].count.ToString();
				String totalPrice = reserveStockDataList[i].totalPrice.ToString("#,###");

				reserveStockDataGridView.Rows.Add(code, name, price, count, totalPrice);
			}
		}

		private void btnBuy_Click(object sender, EventArgs e)
		{
			List<BuyStockData> buyStockDataList = CoreManager.Instance.reserveStockManager.getReserveStockDataList();
			CoreManager.Instance.orderManager.OrderEveryStock(buyStockDataList);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			updateStockDataGridView();
		}

		private void reserveStockDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			updateStockDataByCell(e);
		}

		private void updateStockDataByCell(DataGridViewCellEventArgs e)
		{
			BuyStockData buyStockData = new BuyStockData();
			int index = e.RowIndex;
			buyStockData.code = reserveStockDataGridView.Rows[index].Cells[getMenuIndex(CODE)].Value.ToString();
			buyStockData.name = reserveStockDataGridView.Rows[index].Cells[getMenuIndex(NAME)].Value.ToString();
			buyStockData.price = ObjectUtil.SaftyParseInt(reserveStockDataGridView.Rows[index].Cells[getMenuIndex(PRICE)].Value.ToString());

			if (e.ColumnIndex == getMenuIndex(COUNT))
			{
				buyStockData.count = ObjectUtil.SaftyParseInt(reserveStockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				buyStockData.totalPrice = buyStockData.count * buyStockData.price;
				reserveStockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_PRICE)].Value = buyStockData.totalPrice;
			}
			else if (e.ColumnIndex == getMenuIndex(TOTAL_PRICE))
			{
				buyStockData.totalPrice = ObjectUtil.SaftyParseInt(reserveStockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_PRICE)].Value);
				buyStockData.count = buyStockData.totalPrice / buyStockData.price;
				reserveStockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value = buyStockData.count;
			}
			else
			{
				if (reserveStockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value != null)
				{
					buyStockData.count = ObjectUtil.SaftyParseInt(reserveStockDataGridView.Rows[index].Cells[getMenuIndex(COUNT)].Value);
				}

				if (reserveStockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_PRICE)].Value != null)
				{
					buyStockData.totalPrice = ObjectUtil.SaftyParseInt(reserveStockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_PRICE)].Value);
				}
			}

			reserveStockDataGridView.Rows[index].Cells[getMenuIndex(TOTAL_PRICE)].Value = buyStockData.totalPrice.ToString("#,###");
			CoreManager.Instance.reserveStockManager.updateReserveStockDataList(index, buyStockData);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			CoreManager.Instance.reserveStockManager.saveReserveStockDataList();
		}
	}
}
