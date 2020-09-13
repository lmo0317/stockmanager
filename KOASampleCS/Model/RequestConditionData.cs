using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class RequestConditionData
	{
		public RequestConditionData()
		{

		}

		public float changeRate;
		public int volume;
		public bool positiveForeignPurchase;
		public bool positiveInstitutionPurchase;
		public int foreignPurchaseValue;
		public int institutionPurchaseValue;
		public List<String> exceptionStockNameList = new List<String>();
		public List<String> exceptionStockStateList = new List<String>();
	}
}
