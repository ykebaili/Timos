using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using sc2i.common;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.data.dynamic;

using sc2i.win32.data.navigation;
using sc2i.expression;
using sc2i.multitiers.client;
using sc2i.win32.data;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.data;
using timos.client;
using futurocom.snmp;
using sc2i.data.dynamic.inspiration;

namespace timos
{
	[AutoExec("Autoexec")]
	public class CTimosApp
	{

		private static CSessionClient m_sessionClient;
        private static CSnmpConnexion m_defaultSnmpConnexion;

		//---------------------------------------------------
		public static CInfoLicenceUserProfil InfoProfilLicence
		{
			get
			{
				if (SessionClient != null)
				{
					object o = SessionClient.GetPropriete(CInfoLicenceUserProfil.c_nomIdentification);
					if (o != null)
						return (CInfoLicenceUserProfil)o;
				}
				return null;
			}
		}

		//---------------------------------------------------
		public static CConfigModulesTimos ConfigurationModules
		{
			get
			{
				if (SessionClient != null)
				{
					object o = SessionClient.GetPropriete(CConfigModulesTimos.c_nomIdentification);
					if (o != null)
						return (CConfigModulesTimos)o;
				}
				return null;
			}
		}

        //---------------------------------------------------
        public static CSnmpConnexion DefaultSnmpConnexion
        {
            get
            {
                if (m_defaultSnmpConnexion == null)
                    m_defaultSnmpConnexion = new CSnmpConnexion();
                return m_defaultSnmpConnexion;
            }
        }


		//-----------------------------------------------------------------
		public static void Autoexec()
		{
			CInfoStructureDynamique.GetDonneeDynamiqueStringSurchargee += new CInfoStructureDynamique.GetDonneeDynamiqueStringDelegate(CConvertisseurInfoStructureDynamiqueToDefinitionChamp.GetDonneeDynamiqueString);
			CInfoStructureDynamique.GetStructureSurchargee += new CInfoStructureDynamique.GetStructureDelegate(CConvertisseurInfoStructureDynamiqueToDefinitionChamp.GetStructure);
            CInfoStructureDynamique.GetProprieteDotNetSurchargee += new CInfoStructureDynamique.GetProprieteDotNetDelegate(CConvertisseurInfoStructureDynamiqueToDefinitionChamp.GetProprieteDotNetFromProprieteStructureDynamique);
		}

		//-----------------------------------------------------------------
		/// </summary>
		public static CFormNavigateur Navigateur
		{
			get
			{
				return CSc2iWin32DataNavigation.Navigateur;
			}
		}

		//-----------------------------------------------------------------
		public static CSessionClient SessionClient
		{
			get
			{
				return m_sessionClient;
			}
			set
			{
				m_sessionClient = value;
				if ( value != null )
				{
					CTimosAppRegistre reg = new CTimosAppRegistre();
					m_sessionClient.ConfigurationsImpression.NomImprimanteSurClient = reg.NomImprimanteLocale;
					m_sessionClient.ConfigurationsImpression.NomImprimanteSurServeur = reg.NomImprimanteReseau;
                    CFournisseurInspirationObjetDonnee.Init(value.IdSession);
				}
			}
		}
			
		//-----------------------------------------------------------------
		public static string Titre
		{
			get
			{
				return Navigateur.TitreFenetreEnCours;
			}
			set
			{
				Navigateur.TitreFenetreEnCours = value;
			}
		}

		//-----------------------------------------------------------------
		private static CFournisseurPropDynStd m_fournisseur = null;

		//-----------------------------------------------------------------
		private static Hashtable m_tableSerializeToDefinition = new Hashtable();
		
		
		
	}
}
