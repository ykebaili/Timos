using System;
using System.Collections;
using System.Collections.Generic;

namespace timos.data
{

	public class CColonneTableParametrable_PositionComparer : IComparer<CColonneTableParametrable>
	{
		public int Compare(CColonneTableParametrable x, CColonneTableParametrable y)
		{
			if (x.Position == y.Position)
				return 0;
			else if (x.Position > y.Position)
				return 1;
			else
				return -1;
		}
	}
}
