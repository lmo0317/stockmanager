using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KOASampleCS
{
	class CoreManager
	{
		private RequestManager _requestManager = null;
		public RequestManager requestManager
		{
			get
			{
				return _requestManager;
			}
		}

		private OrderManager _orderManager = null;
		public OrderManager orderManager
		{
			get
			{
				return _orderManager;
			}
		}

		private ModuleManager _moduleManager = null;
		public ModuleManager moduleManager
		{
			get
			{
				return _moduleManager;
			}
		}

		private AccountManager _accountManager = null;
		public AccountManager accountManager
		{
			get
			{
				return _accountManager;
			}
		}

		private ReceiveManager _receiveManager = null;
		public ReceiveManager receiveManager
		{
			get
			{
				return _receiveManager;
			}
		}

		private CoreManager()
		{
			_requestManager = new RequestManager();
			_orderManager = new OrderManager();
			_moduleManager = new ModuleManager();
			_accountManager = new AccountManager();
			_receiveManager = new ReceiveManager();
		}

		private static CoreManager _instance = null;
		public static CoreManager Instance
		{
			get
			{
				if(_instance == null) _instance = new CoreManager();
				return _instance;
			}
		}

		public AxKHOpenAPILib.AxKHOpenAPI apiModule
		{
			get
			{
				return _moduleManager.openApiModule;
			}
		}
	}
}
