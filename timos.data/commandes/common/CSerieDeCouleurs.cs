using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace timos.data
{
	public class CSerieDeCouleurs
	{
		

		//Retourne une couleur de la série
		public static Color GetCouleur(int nIndex)
		{
			Random rnd = new Random(0);
			Array lst = Enum.GetValues ( typeof(KnownColor) );
            List<KnownColor> lstColors = new List<KnownColor>((KnownColor[])Enum.GetValues(typeof(KnownColor)));
            lstColors.Remove(KnownColor.White);
            lstColors.Remove(KnownColor.Black);
            lstColors.Remove(KnownColor.Transparent);
            nIndex = nIndex % lstColors.Count;
			if (nIndex < 0) nIndex = -nIndex;

			//Désorganise la série
            int nBase = lstColors.Count / 13;
			nIndex = (nIndex % 13) * nBase + (nIndex - nIndex%13) % nBase;
            nIndex = nIndex % lstColors.Count;
            return Color.FromKnownColor((KnownColor)lstColors[nIndex]);

		}


	}
}
