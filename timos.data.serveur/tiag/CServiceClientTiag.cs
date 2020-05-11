using System;
using System.Collections.Generic;
using System.Text;
using tiag.client;
using sc2i.common;
using sc2i.multitiers.client;
using timos.data.tiag;
using System.Data;
using System.Threading;
using System.Collections;

namespace timos.data.serveur.tiag
{
	class CServiceClientTiag : MarshalByRefObject, IServiceClientTiag
	{
		private class CInfoSessionTiag
		{
			private CSessionClient m_sessionClient = null;
			private int m_nIdSession = -1;
			private DateTime m_dateTimeSuppression;

			private static Dictionary<int, CInfoSessionTiag> m_listeSessions = new Dictionary<int, CInfoSessionTiag>();

			private static Timer m_timer = null;


			//---------------------------------------------------
			protected CInfoSessionTiag(CSessionClient session)
			{
				m_dateTimeSuppression = DateTime.Now.AddMinutes(10);
				m_listeSessions[session.IdSession] = this;
				m_nIdSession = session.IdSession;
				if (m_timer == null)
				{
					m_timer = new Timer(new TimerCallback(OnNettoieSessions), null, 60000, 60000);
				}
			}

			//---------------------------------------------------
			public static void OnCreateSession(CSessionClient session)
			{
				CInfoSessionTiag info = new CInfoSessionTiag(session);
			}

			//---------------------------------------------------
			public DateTime DateSuppression
			{
				get
				{
					return m_dateTimeSuppression;
				}
			}

			//---------------------------------------------------
			public CSessionClient SessionClient
			{
				get
				{
					return m_sessionClient;
				}
			}

			//---------------------------------------------------
			public static void RenouvelleSession ( int nIdSession )
			{
				CInfoSessionTiag info = null;
				if ( m_listeSessions.TryGetValue ( nIdSession, out info ) )
				{
					info.m_dateTimeSuppression = DateTime.Now.AddMinutes(10);
				}
			}

			//---------------------------------------------------
			private static void OnNettoieSessions(object state)
			{
				List<CInfoSessionTiag> listeToDelete = new List<CInfoSessionTiag>();
				ArrayList lst = new ArrayList(m_listeSessions.Values);
				foreach (CInfoSessionTiag info in lst)
					if (info.DateSuppression < DateTime.Now)
						listeToDelete.Add(info);
				foreach (CInfoSessionTiag info in listeToDelete)
					StaticCloseSession(info);
			}

			//---------------------------------------------------
			private static void StaticCloseSession(CInfoSessionTiag info)
			{
				try
				{
					info.SessionClient.CloseSession();
				}
				catch
				{
				}
				if (m_listeSessions.ContainsValue(info))
					m_listeSessions.Remove(info.m_nIdSession);
			}

			//---------------------------------------------------
			public static void OnCloseSession(int nIdSession)
			{
				if (m_listeSessions.ContainsKey(nIdSession))
					m_listeSessions.Remove(nIdSession);
			}
		}


		//---------------------------------------------------------------------------
		private CSessionClient GetSession ( int nIdSession, CResultDataSet result )
		{
			CSessionClient session = CSessionClient.GetSessionForIdSession ( nIdSession );
			if ( session == null )
				result.EmpileErreur(					
					CodeErreur.AppliErreur, 
					CModificateurElementsTiag.c_strServerKey,
					I.T("Unknown session @1|20000", nIdSession.ToString() ),
					"",
					null,
					(int)Gravite.Indeterminee
					);
			CInfoSessionTiag.RenouvelleSession(nIdSession);
					
			return session;
		}

		//---------------------------------------------------------------------------
		private CResultDataSet GetResultDS ( CResultAErreur result )
		{
			CResultDataSet res = new CResultDataSet();
			foreach ( IErreur erreur in result.Erreur.Erreurs )
				res.EmpileErreur (
					CodeErreur.AppliErreur, 
					CModificateurElementsTiag.c_strServerKey,
					erreur.Message,
					"",
					null,
					(int)Gravite.Indeterminee
					);
			return res;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet BeginTrans(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			CResultDataSet result = new CResultDataSet();
			CResultAErreur resErreur = new CResultAErreur();
			CSessionClient session = GetSession ( nIdSession, result );
			if ( session == null )
				return result;
			resErreur = session.BeginTrans ( );
			if ( !resErreur )
				return GetResultDS ( resErreur );
			return result;
				
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet ChangeData(int nIdSession, System.Data.DataSet Donnees)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).ChangeData(Donnees);
			
		}

		//---------------------------------------------------------------------------
		public void CloseSession(int nIdSession)
		{
			CInfoSessionTiag.OnCloseSession(nIdSession);
			CResultDataSet result = new CResultDataSet();
			CUtilTimosTiag util = CUtilTimosTiag.GetUtilTiagForSession(nIdSession);
			if (util != null)
				util.OnCloseSession();
			CSessionClient session = GetSession(nIdSession, result);
			if ( session != null )
				session.CloseSession();
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet CommitTrans(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			CResultDataSet result = new CResultDataSet();
			CResultAErreur resErreur = new CResultAErreur();
			CSessionClient session = GetSession(nIdSession, result);
			if (session == null)
				return result;
			resErreur = session.CommitTrans();
			if (!resErreur)
				return GetResultDS(resErreur);
			return result;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet ExistEntity(int nIdSession, string strType, object[] keys)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).ExistEntity(strType, keys);
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetDataStructure(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).GetStructureDonnees();
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetEntityFromKeys(int nIdSession, string strType, object[] keys)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).GetEntityFromKeys(strType, keys);
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetEntityFromSearch(int nIdSession, string strType, string[] strChampsRecherche, object[] valeursRecherche)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).GetEntityFromSearch(strType, strChampsRecherche, valeursRecherche);
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetKeysEntityFromSearch(int nIdSession, string strType, string[] strChamps, object[] valeurs)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).GetKeysEntityFromSearch(strType, strChamps, valeurs);
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetParametersDescription(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).GetParametersDescription();
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetServerDesc(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			CResultDataSet result = new CResultDataSet(new DataSet());
			result.Data = "This server makes the different objects managed by TIMOS/SMT availiable";
			return result;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet GetServerKey(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			CResultDataSet result = new CResultDataSet(new DataSet());
			result.Data = CModificateurElementsTiag.c_strServerKey;
			return result;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet OpenSession()
		{
			CSessionClient session = CSessionClient.CreateInstance();
			CResultAErreur result = session.OpenSession ( new CAuthentificationSessionSousSession(0), "Tiag", ETypeApplicationCliente.Service );
			if ( !result )
				return GetResultDS ( result );
			CResultDataSet resDS = new CResultDataSet();
			CInfoSessionTiag.OnCreateSession(session);
			resDS.Data = session.IdSession;
			return resDS;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet RollbackTrans(int nIdSession)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			CResultDataSet result = new CResultDataSet();
			CResultAErreur resErreur = new CResultAErreur();
			CSessionClient session = GetSession(nIdSession, result);
			if (session == null)
				return result;
			resErreur = session.BeginTrans();
			if (!resErreur)
				return GetResultDS(resErreur);
			return result;
		}

		//---------------------------------------------------------------------------
		public System.Data.DataSet SetParametre(int nIdSession, string strNomParametre, string strValeurParametre)
		{
			CInfoSessionTiag.RenouvelleSession(nIdSession);
			return CUtilTimosTiag.GetUtilTiagForSession(nIdSession).SetParametre ( strNomParametre, strValeurParametre );
		}
	}
}
