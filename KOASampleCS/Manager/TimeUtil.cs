using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS.Manager
{
	class TimeUtil
	{
		public static String GetCurrentYear()
		{
			return DateTime.Now.ToString("yyyy");
		}

		public static String GetCurrentMonth()
		{
			return DateTime.Now.ToString("MM");
		}

		public static String GetCurrentDay()
		{
			return DateTime.Now.ToString("dd");
		}

		public static String GetCurrentHour()
		{
			return DateTime.Now.ToString("hh");
		}

		public static String GetCurrentMinute()
		{
			return DateTime.Now.ToString("mm");
		}

		public static String GetCurrentSecond()
		{
			return DateTime.Now.ToString("ss");
		}
	}
}
