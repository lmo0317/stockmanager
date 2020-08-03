using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiwoomCode;

namespace KOASampleCS
{
	class LoggerUtil
	{
		public static System.Windows.Forms.ListBox lst조회;
		public static System.Windows.Forms.ListBox lst에러;
		public static System.Windows.Forms.ListBox lst일반;
		public static System.Windows.Forms.ListBox lst실시간;

		public static void Logger(Log type, string format, params Object[] args)
		{
			string message = String.Format(format, args);

			switch (type)
			{
				case Log.조회:
					lst조회.Items.Add(message);
					lst조회.SelectedIndex = lst조회.Items.Count - 1;
					break;
				case Log.에러:
					lst에러.Items.Add(message);
					lst에러.SelectedIndex = lst에러.Items.Count - 1;
					break;
				case Log.일반:
					lst일반.Items.Add(message);
					lst일반.SelectedIndex = lst일반.Items.Count - 1;
					break;
				case Log.실시간:
					lst실시간.Items.Add(message);
					lst실시간.SelectedIndex = lst실시간.Items.Count - 1;
					break;
				default:
					break;
			}
		}
	}
}
