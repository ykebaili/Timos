using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{

	public class CColonneTableParametrable_ProrityComparer : IComparer<CColonneTableParametrable>
	{

		#region IComparer<CColonneTableParametrable> Membres

		public int Compare(CColonneTableParametrable x, CColonneTableParametrable y)
		{
			if (x.IsPrimaryKey && y.IsPrimaryKey)
			{
				if (x.PrimaryKeyPosition < x.PrimaryKeyPosition)
					return -1;
				if (x.PrimaryKeyPosition == x.PrimaryKeyPosition)
					return 0;
				else
					return 1;
			}
			else if (x.IsPrimaryKey && !y.IsPrimaryKey)
			{
				return -1;
			}
			else if (!x.IsPrimaryKey && y.IsPrimaryKey)
			{
				return 1;
			}
			else
			{
				if (x.AllowNull && !y.AllowNull)
				{
					return 1;
				}
				else if (!x.AllowNull && y.AllowNull)
				{
					return -1;
				}
				else
				{
					if (x.TypeDonneeInt == x.TypeDonneeInt)
						return 0;
					else if (x.TypeDonneeInt > x.TypeDonneeInt)
						return 1;
					else
						return -1;
				}
			}
		}

		#endregion
	}
	
}
