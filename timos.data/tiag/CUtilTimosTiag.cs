using System;
using System.Collections.Generic;
using System.Text;
using sc2i.multitiers.client;
using timos.data.tiag;
using tiag.client;
using System.Data;
using sc2i.common;
using System.Reflection;
using sc2i.data;

namespace timos.data.tiag
{
	/// <summary>
	/// Classe utilitaire TIAG, commune au service web et à Tiag par remoting
	/// </summary>
    [AutoExec("Autoexec")]
	public class CUtilTimosTiag : IDisposable
	{
		private CModificateurElementsTiag m_modificateurElements = null;
		private CSessionClient m_sessionClient;

		private static Dictionary<int, CUtilTimosTiag> m_tableUtilsParSession = new Dictionary<int,CUtilTimosTiag>();

		//--------------------------------------------
		private CUtilTimosTiag(CSessionClient session)
		{
			m_sessionClient = session;
		}

        //--------------------------------------------
        public static void Autoexec()
        {
            CAssociationTiag.ExternalSetValeursCles = new CAssociationTiag.ExternalSetValeursClesDelegate(SetParentViaPropriete);
        }

        //--------------------------------------------
        public static bool SetParentViaPropriete ( CAssociationTiag associationTiag, object obj, object[] valeursCles)
        {
            if ( valeursCles.Length != 1 )
                return false;
            CObjetDonnee objet = obj as CObjetDonnee;
            if ( objet == null )
                return false;
            PropertyInfo info = objet.GetType().GetProperty ( associationTiag.Propriete);
            if ( info != null )
            {
                MethodInfo method = info.GetSetMethod();
                if ( method != null )
                {
                    CObjetDonnee parent = Activator.CreateInstance ( associationTiag.TypeParent, new object[]{objet.ContexteDonnee}) as CObjetDonnee;
                    if (parent.ReadIfExists(valeursCles))
                    {
                        method.Invoke ( obj, new object[]{parent} );
                        return true;
                    }
                }
            }
            return false;
        }



		//------------------------------------------------
		public string  DescriptifObjetAttacheASession
		{
            get { return I.T("TIAG modifier|30061"); }
		}

		//------------------------------------------------
		public void  OnCloseSession()
		{
			try
			{
				m_tableUtilsParSession.Remove ( m_sessionClient.IdSession );
				if (m_modificateurElements != null)
					m_modificateurElements.Dispose();
				m_modificateurElements = null;
				Dispose();
			}
			catch{}
		}

		//------------------------------------------------
		public static CUtilTimosTiag GetUtilTiagForSession ( int nIdSession )
		{
			CUtilTimosTiag util = null;
			if ( !m_tableUtilsParSession.TryGetValue ( nIdSession, out util ))
			{
				util = new CUtilTimosTiag ( CSessionClient.GetSessionForIdSession ( nIdSession ) );
				m_tableUtilsParSession[nIdSession] = util;
			}
			return util;
		}

		
		//--------------------------------------------
		public CSessionClient Session
		{
			get
			{
				return m_sessionClient;
			}
		}

		//--------------------------------------------
		public void Dispose()
		{
			if ( ModificateurElements != null )
			{
				ModificateurElements.Dispose();
				m_modificateurElements = null;
			}
		}

	
		//--------------------------------------------
		private CModificateurElementsTiag ModificateurElements
		{
			get
			{
				if (m_modificateurElements == null)
					m_modificateurElements = new CModificateurElementsTiag(Session.IdSession);
				return m_modificateurElements;
			}
		}

		//--------------------------------------------
		public CResultDataSet GetStructureDonnees()
		{
			CUtilClientTiag.Init(true);
			CResultDataSet  result = CUtilClientTiag.GetDataSetStructure();
			return result;
		}

		//--------------------------------------------
		public CResultDataSet ChangeData ( DataSet donnees )
		{
			CResultDataSet result = CUtilClientTiag.ChangeData(ModificateurElements, donnees);
			if (result)
			{
				CResultAErreur resErreur = ModificateurElements.ContexteDonnee.SaveAll(true);
				//Maintenant, il faut changer les ids des éléments mappés qui ont bougé
				if ( resErreur )
					resErreur = ModificateurElements.DefinitNouvellesCles(donnees);

				if (!resErreur)
					result.EmpileErreur(CodeErreur.AppliErreur, CModificateurElementsTiag.c_strServerKey, resErreur.Erreur.ToString(), null, null, 0);
				else
					result = new CResultDataSet(donnees);
			}

			return result;
		}

		//--------------------------------------------
		public CResultDataSet GetEntityFromSearch(string strType, string[] strChampsRecherche, object[] valeursRecherche)
		{
			CResultDataSet result = CUtilClientTiag.GetElementsDataSet(ModificateurElements, strType, strChampsRecherche, valeursRecherche);
			return result;
		}

		//--------------------------------------------
		public CResultDataSet GetKeysEntityFromSearch(string strType, string[] strChamps, object[] valeurs)
		{
			CResultDataSet result = CUtilClientTiag.GetKeysEntityFromSearch(ModificateurElements, strType, strChamps, valeurs);
			return result;
		}

		//--------------------------------------------
		public CResultDataSet GetEntityFromKeys(string strType, object[] keys)
		{
			CResultDataSet result = CUtilClientTiag.GetElementDataSet(ModificateurElements, strType, keys);
			
			return result;
		}

		//--------------------------------------------
		public DataSet ExistEntity(string strType, object[] keys)
		{
			CResultDataSet result = new CResultDataSet();
			bool bOk = CUtilClientTiag.ExistElement(ModificateurElements, strType, keys);
			result.Data = bOk;
			return result;
			/*result = GetEntityFromKeys(strType, keys);
			if (result)
			{
				DataSet ds = (DataSet)result;
				if (ds.Tables.Contains(strType))
				{
					result.Data = ds.Tables[strType].Rows.Count != 0;
				}
				else
					result.Data = false;
			}
			return result;*/
		}

		//--------------------------------------------
		public DataSet BeginTrans()
		{
			CResultAErreur result = Session.BeginTrans();
			CResultDataSet resultDS = new CResultDataSet();
			if (!result)
			{
				resultDS.EmpileErreur( CodeErreur.AppliErreur, CModificateurElementsTiag.c_strServerKey, result.Erreur.ToString(), null, null, 0 );
			}
			return resultDS;
		}

		//--------------------------------------------
		public DataSet CommitTrans()
		{
			CResultAErreur result = Session.CommitTrans();
			CResultDataSet resultDS = new CResultDataSet();
			if (!result)
			{
				resultDS.EmpileErreur(CodeErreur.AppliErreur, CModificateurElementsTiag.c_strServerKey, result.Erreur.ToString(), null, null, 0);
			}
			return resultDS;
		}

		//--------------------------------------------
		public DataSet RollbackTrans()
		{
			CResultAErreur result = Session.RollbackTrans();
			CResultDataSet resultDS = new CResultDataSet();
			if (!result)
			{
				resultDS.EmpileErreur(CodeErreur.AppliErreur, CModificateurElementsTiag.c_strServerKey, result.Erreur.ToString(), null, null, 0);
			}
			return resultDS;
		}



		//---------------------------------------------------------------------------------
		public DataSet SetParametre(string strNomParametre, string strValeurParametre)
		{
			return ModificateurElements.SetParametre(strNomParametre, strValeurParametre);
		}

		public DataSet GetParametersDescription()
		{
			CResultDataSet result = new CResultDataSet();
			result.Data = CModificateurElementsTiag.c_paramDesc;
			return result;
			
		}

	}
}
