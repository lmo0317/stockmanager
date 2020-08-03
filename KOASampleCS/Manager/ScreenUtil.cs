using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class ScreenUtil
	{
		public static int scrNum = 5000;

		public static string GetScrNum()
		{
			if (scrNum < 9999)
				scrNum++;
			else
				scrNum = 5000;

			return scrNum.ToString();
		}
	}
}
