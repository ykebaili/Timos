using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;
using timos.Controles.MemoObjets;
using timos.Parametrage.ModulesParametrage;
using timos.Controles.notifications;
using timos.projet.besoin;

namespace timos
{
	/// <summary>
	/// Description résumée de CTimosAppRegistre.
	/// </summary>
	public class CTimosAppRegistre : C2iMultitiersClientRegistre
	{
		public CTimosAppRegistre()
		{
		}

		public static string GetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			return new CTimosAppRegistre().GetValue(strKey, strRubrique, strDefaut);
		}
		public static void SetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			new CTimosAppRegistre().SetValue(strKey, strRubrique, strDefaut);
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


		public static string NomServeur
		{
			get
			{
				string strValRegistre = GetValueRegistre("General", "factoryurl", "");
				strValRegistre = strValRegistre.ToLower();
				int nIdxStart = strValRegistre.IndexOf("tcp://");
				if (nIdxStart != -1)
				{
					nIdxStart += 6;
					int nIdxEnd = strValRegistre.IndexOf(":8160");
					if (nIdxEnd != -1)
						return strValRegistre.Substring(nIdxStart, nIdxEnd - nIdxStart);
				}
				return "";
			}
			set
			{

				if(value != null)
					SetValueRegistre("General", "factoryurl", "tcp://" + value + ":8160");
			}
		}


		/// //////////////////////////////////////////////////
		public string NomImprimanteLocale
		{
			get
			{
				return GetValue("Preferences","Imprimante locale","");
			}
			set
			{
				SetValue ( "Preferences","Imprimante locale", value );
			}
		}

		/// //////////////////////////////////////////////////
		public string NomImprimanteReseau
		{
			get
			{
				return GetValue("Preferences","Imprimante réseau","");
			}
			set
			{
				SetValue ( "Preferences","Imprimante réseau", value );
			}
		}

		/// //////////////////////////////////////////////////
		public bool GetIsVueListeForFormListeGroupe ( Type tp )
		{
			return GetValue("Preferences\\ListeGroupes", tp.ToString(),"1")=="1";
		}

		/// //////////////////////////////////////////////////
		public void SetIsVueListeForFormListeGroupe ( Type tp, bool bVueListe )
		{
			SetValue("Preferences\\ListeGroupes", tp.ToString(), bVueListe?"1":"0");
		}

		/// //////////////////////////////////////////////////
		public string[] RepertoiresImages
		{
			get
			{
				string strVal = GetValue ( "Preferences","Images","");
				ArrayList lst = new ArrayList();
				foreach ( string strRep in strVal.Split(';') )
				{
					if ( strRep.Trim() !=  "" )
						lst.Add ( strRep );
				}
				return (string[])lst.ToArray(typeof(string));
			}
			set
			{
				string strVal = "";
				foreach ( string strRep in value )
					strVal += strRep+";";
				if ( strVal.Length > 0 )
					strVal = strVal.Substring(0, strVal.Length-1);
				SetValue("Preferences","Images",strVal);
			}
		}


		public string GetDataPostit ( int nIdPostit )
		{
			return GetValue( "Postit", nIdPostit.ToString(), "");
		}

		public void SetDataPostit ( int nIdPostit, string strData )
		{
			SetValue ( "Postit", nIdPostit.ToString(), strData );
		}

		public int LastIdProfilEchangeEquipement
		{
			get
			{
				return GetIntValue("Preferences", "Last profil Replacement equipment", -1);
			}
			set
			{
				SetValue("Preferences", "Last profil Replacement equipement", value.ToString());
			}
		}

        public int GetLastIdConsultationHierarchiqueInSchema(Type typeSource)
        {
            string strTypeSource = "";
            if ( typeSource != null )
                strTypeSource = typeSource.ToString();
            return GetIntValue("Preferences", "Last Hierarchical used in schema"+strTypeSource, -1);
        }

        public void SetLastIdConsultationHierarchiqueInSchema ( Type typeSource, int nId)
        {
            string strTypeSource = "";
            if ( typeSource != null )
                strTypeSource = typeSource.ToString();
            
            SetValue("Preferences", "Last Hierarchical used in schema"+strTypeSource, nId.ToString());
        }

        public int GetLastIdConsultationHierarchiqueForGED(Type typeSource)
        {
            string strTypeSource = "";
            if (typeSource != null)
                strTypeSource = typeSource.ToString();
            return GetIntValue("Preferences", "Last Hierarchical used in EDM" + strTypeSource, -1);
        }

        public void SetLastIdConsultationHierarchiqueForGED(Type typeSource, int nId)
        {
            string strTypeSource = "";
            if (typeSource != null)
                strTypeSource = typeSource.ToString();

            SetValue("Preferences", "Last Hierarchical used in EDM" + strTypeSource, nId.ToString());
        }

		//OPTIONS
		public bool OptionsGraphiques_FonduActif
		{
			get
			{
				return bool.Parse(GetValue("Options\\Graphiques\\Fondu","Actif", false.ToString()));
			}
			set
			{
				sc2i.win32.common.CEffetFonduPourFormManager.EffetActif = value;
				SetValue("Options\\Graphiques\\Fondu", "Actif", value.ToString());
			}
		}


        // Options du designer de formulaires
		public string GetDataProfilDesigner(string strKey)
		{
			return GetValue("Preferences\\Designer", strKey, "");
		}

		public void SetDataProfilDesigner(string strKey, string strData)
		{
			SetValue("Preferences\\Designer", strKey, strData);
		}

        // Options du Gantt
        public string GetDataParametreGantt(string strKey)
        {
            return GetValue("Preferences\\Gantt", strKey, "");
        }

        public void SetDataParametreGantt(string strKey, string strData)
        {
            SetValue("Preferences\\Gantt", strKey, strData);
        }


        public bool ReadMemoUser(ref System.Collections.Generic.List<global::timos.Controles.MemoObjets.CMemoObjets.CReferenceObjetDonneeAvecLibelle> lst)
        {
            lst = new System.Collections.Generic.List<CMemoObjets.CReferenceObjetDonneeAvecLibelle>();
            string strValue = GetValue("Preferences", "UserMemo", "");
            if (strValue.Trim() == "")
                return false;
            CStringSerializer ser = new CStringSerializer(strValue, ModeSerialisation.Lecture);
            return ser.TraiteListe<CMemoObjets.CReferenceObjetDonneeAvecLibelle>(lst);
        }

        public void SaveMemoUser(ref System.Collections.Generic.List<CMemoObjets.CReferenceObjetDonneeAvecLibelle> lst)
        {
            CStringSerializer ser = new CStringSerializer(ModeSerialisation.Ecriture);
            if ( ser.TraiteListe<CMemoObjets.CReferenceObjetDonneeAvecLibelle>(lst) )
                SetValue ( "Preferences","UserMemo",ser.String);
        }

        public static void SaveParametreVisuModulesParametrage(CParametreVisuModuleParametrage parametre)
        {
            CStringSerializer ser = new CStringSerializer(ModeSerialisation.Ecriture);
            if (parametre.Serialize(ser))
                new CTimosAppRegistre().SetValue("Preferences", "module view", ser.String);
        }

        public static CParametreVisuModuleParametrage GetParametreVisuModulesParametrage()
        {
            string strVal = new CTimosAppRegistre().GetValue("Preferences", "module view", "");
            if (strVal == "")
                return null;
            CParametreVisuModuleParametrage parametre = new CParametreVisuModuleParametrage();
            CStringSerializer ser = new CStringSerializer(strVal, ModeSerialisation.Lecture);
            if (parametre.Serialize(ser))
                return parametre;
            return null;
        }

        public static void SaveParametreNotifications(CParametresNotification parametre)
        {
            CStringSerializer ser = new CStringSerializer(ModeSerialisation.Ecriture);
            if (parametre.Serialize(ser))
                new CTimosAppRegistre().SetValue("Preferences", "Notifications setup", ser.String);
        }

        public static void FillParametreNotifications(CParametresNotification parametre)
        {
            string strVal = new CTimosAppRegistre().GetValue("Preferences", "Notifications setup", "");
            if (strVal == "")
                return ;
            CStringSerializer ser = new CStringSerializer(strVal, ModeSerialisation.Lecture);
            parametre.Serialize(ser);
        }

        //-------------------------------------------------------------------
        public static void AddRecentConfigPlanning(string strFichier)
        {
            new CTimosAppRegistre().AddRecent("Preferences", "recent planning conf", strFichier, 6);
        }

        //-------------------------------------------------------------------
        public static void RemoveRecentConfigPlanning(string strFichier)
        {
            new CTimosAppRegistre().RemoveRecent("Preferences", "recent planning conf", strFichier);
        }

        //-------------------------------------------------------------------
        public static string[] GetRecentsConfigPlanning()
        {
            return new CTimosAppRegistre().GetRecents("Preferences", "recent planning conf");
        }

        //-------------------------------------------------------------------
        public static EModeAffichageBesoins ModeAffichageBesoins
        {
            get
            {
                try
                {
                    return (EModeAffichageBesoins)new CTimosAppRegistre().GetIntValue("Preferences", "Need display mode", (int)EModeAffichageBesoins.ModeSansCout);
                }
                catch { }
                return EModeAffichageBesoins.ModeSansCout;
            }
            set
            {
                new CTimosAppRegistre().SetValue("Preferences", "Need display mode", ((int)value).ToString());
            }
        }

        
    }
}
