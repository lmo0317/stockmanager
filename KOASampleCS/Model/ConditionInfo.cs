using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class ConditionInfo
	{
		public int number { get; set; }
		public string name { get; set; }
		public bool registered = false;

		public List<StockItemInfo> stockItemList;
	}
}
