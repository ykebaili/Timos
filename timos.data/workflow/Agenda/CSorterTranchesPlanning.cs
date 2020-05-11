using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
	public class CSorterTranchesPlanning : IComparer <ITranchePlanning>
	{
		#region IComparer<ITranchePlanning> Membres

		public int Compare(ITranchePlanning x, ITranchePlanning y)
		{
			return x.DateDebut.CompareTo(y.DateDebut);			
		}

		#endregion
	}
}
