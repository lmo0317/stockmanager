using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace KOASampleCS
{
	class StringUtil
	{
		public static string GetRegularString(string value)
		{
			return Regex.Replace(value, @"[^a-zA-Z0-9가-힣_]", "", RegexOptions.Singleline);
		}
	}
}
