using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOASampleCS
{
	class ModuleManager
	{
		private AxKHOpenAPILib.AxKHOpenAPI _openApiModule;
		public AxKHOpenAPILib.AxKHOpenAPI openApiModule
		{
			get
			{
				return _openApiModule;
			}
			set
			{
				_openApiModule = value;
			}
		}
	}
}
