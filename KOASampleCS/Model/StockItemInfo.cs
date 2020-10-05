using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class StockItemInfo
	{
		public string code { get; set; }
		public string name { get; set; }
		public string price { get; set; }
		public string changePrice { get; set; } //전일대비
		public string changeRate { get; set; } //등락률
		public string volume { get; set; } //거래량
		public string openPrice { get; set; }
		public string highPrice { get; set; }
		public string lowPrice { get; set; }
		public string afterMarketPrice { get; set; }
		public float afterMarketChangeRate { get; set; }
	}
}
