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
		public ReserveStockTradingForm()
		{
			InitializeComponent();
			Init();
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
		}

		private void reserveCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = reserveCheckBox.Checked;
			CoreManager.Instance.orderManager.reserveOrderStock(isChecked, dateTimePicker.Value);
		}
	}
}
