using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class Config
	{
		//주문 시간
		public static int ORDER_TIME_HOUR = 8;
		public static int ORDER_TIME_MINUTE = 29;
		public static int ORDER_TIME_SECOND = 56;
		
		//주문양
		public static int ORDER_TOTAL_AMOUNT = 500000;
		
		//검색 조건
		public static float DEFAULT_CHANGE_RATE_MIN = 2.0f;
		public static float DEFAULT_CHANGE_RATE_MAX = 10.0f;
		public static int DEFAULT_VOLUME = 1000;
		public static int DEFAULT_TRADING_VALUE = 100000000;

		//기관, 외인 매수
		public static bool DEFAULT_POSITIVE_FOREIGN_PURCHASE = false;
		public static bool DEFAULT_POSITIVE_INSTITUTION_PURCHASE = false;
		public static int DEFAULT_FOREIGN_PURCHASE_VALUE = 0;
		public static int DEFAULT_INSTITUTION_PURCHASE_VALUE = 0;

		//예약 주문
		public static bool DEFAULT_ORDER_CHECK = true;
		
		public static bool isAutoStart = false;
	}
}
