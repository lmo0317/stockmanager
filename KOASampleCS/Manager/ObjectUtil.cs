using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class ObjectUtil
	{
		public static int SaftyParseInt(object value)
		{
			if (value == null)
				return 0;

			return Int32.Parse(value.ToString().Trim().Replace(",", ""));
		}

		public static float SaftyParseFloat(object value)
		{
			if (value == null)
				return 0.0f;

			return float.Parse(value.ToString().Trim().Replace(",", ""));
		}

		public static bool SaftyParseBoolean(object value)
		{
			if (value == null)
				return false;

			return bool.Parse(value.ToString().Trim().Replace(",", ""));
		}
	}
}
