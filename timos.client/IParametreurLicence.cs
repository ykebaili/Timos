using System;
using System.Collections.Generic;
using System.Text;

using Lys.Applications.Timos.Smt;

namespace timos.client
{
#if DEBUG

	public partial interface IParametreurLicence
	{
		void ReinitialiserRestrictions(CConfigModulesTimos config);
	}
#endif
}
