using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;	


using sc2i.common;
using timos.acteurs;

namespace timos.data
{
	public class CUtilEntreePlanning
	{
		public static bool Intersect ( IEntreePlanning elt, DateTime dtDebut, DateTime dtFin )
		{
			foreach (ITranchePlanning tranche in elt.Tranches)
				if (Intersect(tranche, dtDebut, dtFin))
					return true;
			return false;
		}

		public static bool Intersect(ITranchePlanning tranche, DateTime dtDebut, DateTime dtFin)
		{
			return tranche.DateDebut < dtFin &&
				tranche.DateFin > dtDebut;
		}


		public static string GetLibelleTypeRessource(Type tp)
		{
			if (tp == typeof(timos.acteurs.CActeur))
				return I.T("Operator|202");
			else if (tp == typeof(CRessourceMaterielle))
				return I.T("Resource|203");
			return DynamicClassAttribute.GetNomConvivial(tp);
		}

		public static System.Drawing.Color GetCouleurTypeRessource(Type type)
		{
			if (type == typeof(CActeur))
				return Color.FromArgb(255, 255, 255);
			if (type == typeof(CRessourceMaterielle))
				return Color.FromArgb(200, 200, 255);
			return Color.White;
		}
	}
}
