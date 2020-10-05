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
	public partial class ConditionSearchForm : Form
	{
		public static String NAME = "종목명";
		public static String PRICE = "현재가";
		public static String CHANGE_PRICE = "전일대비";
		public static String CHANGE_RATE = "등락률";
		public static String VOLUME = "거래량";
		public static String OPEN_PRICE = "시가";
		public static String HIGH_PRICE = "고가";
		public static String LOW_PRICE = "저가";
		public static String AFTER_MARKET_PRICE = "시간외가격";
		public static String AFTER_MARKET_CHANGE_RATE = "시간외등락률";

		private string[] menus = { NAME, PRICE, CHANGE_PRICE, CHANGE_RATE, VOLUME, OPEN_PRICE, HIGH_PRICE, LOW_PRICE, AFTER_MARKET_PRICE, AFTER_MARKET_CHANGE_RATE };

		public ConditionSearchForm()
		{
			InitializeComponent();
			makeStockItemGridView();
		}

		private int getMenuIndex(String menuName)
		{
			return Array.IndexOf(menus, menuName);
		}

		private void makeStockItemGridView()
		{
			for (int i = 0; i < menus.Length; i++)
			{
				stockItemGridView.Columns.Add(menus[i], menus[i]);
			}
		}

		private void btnConditionList_Click(object sender, EventArgs e)
		{
			int result = CoreManager.Instance.apiModule.GetConditionLoad();
		}

		public void OnReceiveConditionVer()
		{
			conditionGridView.DataSource = CoreManager.Instance.conditionSearchManager.conditionList;

			conditionGridView.Columns[0].Width = 60;
			conditionGridView.Columns[1].Width = 120;
		}

		private void conditionGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void conditionGridView_SelectionChanged(object sender, EventArgs e)
		{
			if (conditionGridView.SelectedCells.Count > 0 && conditionGridView.Focused)
			{
				int index = conditionGridView.SelectedCells[0].RowIndex;
				if (conditionGridView.ColumnCount == 2)
				{
					int result = CoreManager.Instance.apiModule.SendCondition(
									ScreenUtil.GetScrNum(),
									conditionGridView[1, index].Value.ToString(),
									int.Parse(conditionGridView[0, index].Value.ToString()), 0);

					CoreManager.Instance.conditionSearchManager.selectedConditionIndex = index;

					if(result > 0)
					{
						Console.WriteLine("조건검색 성공");
						CoreManager.Instance.conditionSearchManager.conditionList[index].stockItemList = new List<StockItemInfo>();
					}
					else
					{
						Console.WriteLine("조건검색 실패");
						updateStockItemGridView();
					}
				}
			}
		}

		public void updateStockItemGridView()
		{
			int index = CoreManager.Instance.conditionSearchManager.selectedConditionIndex;
			List<StockItemInfo> stockItemList = CoreManager.Instance.conditionSearchManager.conditionList[index].stockItemList;

			stockItemGridView.Rows.Clear();
			for (int i = 0; i < stockItemList.Count; i++)
			{
				StockItemInfo stockItemInfo = stockItemList[i];
				stockItemGridView.Rows.Add(
					stockItemInfo.name,
					stockItemInfo.price,
					stockItemInfo.changePrice,
					stockItemInfo.changeRate,
					stockItemInfo.volume,
					stockItemInfo.openPrice,
					stockItemInfo.highPrice,
					stockItemInfo.lowPrice,
					stockItemInfo.afterMarketPrice,
					stockItemInfo.afterMarketChangeRate
				);

				stockItemGridView.Rows[i].Cells[getMenuIndex(AFTER_MARKET_CHANGE_RATE)].Style.ForeColor = stockItemInfo.afterMarketChangeRate > 0 ? Color.Red : Color.Blue;
			}
		}
	}
}
