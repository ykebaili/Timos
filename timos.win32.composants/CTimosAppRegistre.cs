using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.workflow;
using sc2i.win32.data;
using timos.data.projet.gantt;
using timos.data;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CTimosAppRegistre.
	/// </summary>
	public class CTimosAppRegistre : C2iMultitiersClientRegistre
	{
		public CTimosAppRegistre()
		{
		}


		public static string ClePrincipale
		{
			get
			{
				return "Software\\Futurocom\\timos\\";
			}
		}

		protected override string GetClePrincipale()
		{
			return ClePrincipale;
		}

		protected override bool IsLocalMachine()
		{
			return false;
		}

		private static string GetCleModeleTexte(string strContexte, Type tp)
		{
			return strContexte + "_" + tp.ToString();
		}

		public static void SetModeleTexteForType(CModeleTexte modele, string strContexte, Type tp)
		{
			new CTimosAppRegistre().SetValue("Text models", GetCleModeleTexte(strContexte, tp), (modele==null?-1:modele.Id).ToString());	
		}

		public static CModeleTexte GetModeleTexteForType(string strContexte, Type tp)
		{
			int nId = new CTimosAppRegistre().GetIntValue("Text models", GetCleModeleTexte(strContexte, tp), -1);
			if (nId > 0)
			{
				CModeleTexte modele = new CModeleTexte(CSc2iWin32DataClient.ContexteCourant);
				if (modele.ReadIfExists(nId))
					return modele;
			}
			return null;
		}

        public static CParametreTriGantt GetParametreTriGantt(IElementDeGantt eltGantt)
        {
            if (eltGantt == null)
                return null;
            string strCle = "Gantt sort";
            strCle += "-" + eltGantt.GanttBarId;
            string strSer = new CTimosAppRegistre().GetValue("preferences\\Gantt", strCle, "");
            if (strSer != "")
            {
                CStringSerializer serializer = new CStringSerializer(strSer, ModeSerialisation.Lecture);
                CParametreTriGantt tri = null;
                try
                {
                    if (serializer.TraiteObject<CParametreTriGantt>(ref tri))
                        return tri;
                }
                catch { }
            }
            return null;

        }

        public static void SetParametreTriGantt(IElementDeGantt eltGantt, CParametreTriGantt parametre)
        {
            if (eltGantt == null)
                return;
            string strCle = "Gantt sort";
            strCle += "-" + eltGantt.GanttBarId;
            string strSer = "";
            if (parametre != null)
            {
                CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
                if (serializer.TraiteObject<CParametreTriGantt>(ref parametre))
                    strSer = serializer.String;
            }
            new CTimosAppRegistre().SetValue("preferences\\Gantt", strCle, strSer);

        }

       

	}
}
