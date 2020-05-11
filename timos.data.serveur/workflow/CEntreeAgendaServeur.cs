using System;
using System.Collections;
using System.Data;
using System.Threading;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.multitiers.server;


namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e de Class1.
	/// </summary>
	[AutoExec("Autoexec", AutoExecAttribute.BackGroundService)]
	public class CEntreeAgendaServeur : CObjetServeurAvecBlob
	{
		private static int m_nEcartTimer = 1000*60*10;//Toutes les 10 minutes
		private static Timer m_timer = null;
		/// //////////////////////////////////////////////////
#if PDA
		public CEntreeAgendaServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CEntreeAgendaServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			if ( m_timer == null )
				m_timer = new Timer ( new TimerCallback ( OnTimerGestionAuto ), null, m_nEcartTimer, m_nEcartTimer );
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CEntreeAgenda.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CEntreeAgenda);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CEntreeAgenda entree = (CEntreeAgenda)objet;
				if ( entree.Libelle == "" )
					result.EmpileErreur(I.T("Diary entry label cannot be empty|311"));

				if ( entree.DateDebut > entree.DateFin )
					result.EmpileErreur(I.T("Inconsistent date or time values|312"));

				CRelationEntreeAgenda_ChampCustomServeur relServeur = new CRelationEntreeAgenda_ChampCustomServeur(IdSession);
				foreach ( CRelationEntreeAgenda_ChampCustom rel in CNettoyeurValeursChamps.RelationsChampsNormales(entree) )
				{
					CResultAErreur resultTmp = relServeur.VerifieDonnees(rel);
					if ( !resultTmp )
					{
						result.Erreur.EmpileErreurs(resultTmp.Erreur);
						result.SetFalse();
					}
				}

				Hashtable m_tableRelationsToElements = new Hashtable();
				foreach ( CRelationEntreeAgenda_ElementAAgenda relElement in entree.RelationsElementsAgenda )
					m_tableRelationsToElements[relElement.RelationTypeEntree_TypeElement.Id] = true;
				foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relType in entree.TypeEntree.RelationsTypeElementsAAgenda )
					if ( relType.Obligatoire && m_tableRelationsToElements[relType.Id] == null )
					{
						result.EmpileErreur(I.T("Associated element @1 must be defined|313",relType.Libelle));
					}

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Diary netry data error|310"));
			}
			return result;
				
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			DataTable table = contexte.Tables[GetNomTable()];
			if ( table == null )
				return result;
			ArrayList lstRows = new ArrayList(table.Rows);
			foreach ( DataRow row in lstRows )
			{
				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
				{
					CEntreeAgenda entree = new CEntreeAgenda ( row );
					if ( entree.DateFin < entree.DateDebut )
						entree.DateFin = entree.DateDebut.AddMinutes(1);
					if ( entree.SansHoraire )
					{
						entree.DateDebut = entree.DateDebut.Date;
						entree.DateFin = entree.DateFin.Date.AddDays(1).AddMinutes(-1);
					}
				}
			}
			return result;
		}


		/// ///////////////////////////////////////////////////
		/// <summary>
		/// Gestion automatique de l'ÃƒÆ’Ã‚Â©tat des entrÃƒÆ’Ã‚Â©es d'agenda
		/// </summary>
		/// <param name="state"></param>
		private static bool m_bGestionAutoEnCours = false;
		public static void OnTimerGestionAuto( object state )
		{
			if (m_bGestionAutoEnCours )
				return;
			try
			{
				m_bGestionAutoEnCours = true;
				CSessionClient session = CSessionClient.CreateInstance();
				CResultAErreur result = session.OpenSession(new CAuthentificationSessionServer(),
					I.T("Automatic management of the diary states|314"),
					ETypeApplicationCliente.Service );
				if ( !result )
				{
					result.EmpileErreur (I.T("Error in the automatic management of expiration dates: Impossible to open a session|315"));
					C2iEventLog.WriteErreur ( result.Erreur.ToString() );
					return;
				}
				try
				{
					using ( CContexteDonnee contexte = new CContexteDonnee ( session.IdSession, true, false ) )
					{
						DateTime dt = DateTime.Now;
						CListeObjetsDonnees liste = new CListeObjetsDonnees ( contexte, typeof(CEntreeAgenda) );
						liste.Filtre = new CFiltreData ( 
							CEntreeAgenda.c_champEtatAutomatique+"=@1 and "+
							CEntreeAgenda.c_champEtat+"<>@2 and "+CEntreeAgenda.c_champEtat+"<>@3 and ("+
							"("+
							CEntreeAgenda.c_champDateDebut +"< @4 and "+
							CEntreeAgenda.c_champDateFin+">@4 and "+
							CEntreeAgenda.c_champEtat+"<>@5) or ("+
							CEntreeAgenda.c_champDateFin +"<@4 and "+
							CEntreeAgenda.c_champEtat+"<@6) )",
							true,
							(int)EtatEntreeAgenda.Info,
							(int)EtatEntreeAgenda.Annulee,
                            //dt.ToString("dd/MM/yyyy HH:mm:00"),
                            dt,
							(int)EtatEntreeAgenda.EnCours,
							(int)EtatEntreeAgenda.Terminee );
						foreach ( CEntreeAgenda entree in liste )
						{
							entree.EtatAuto = false;
							if ( entree.DateDebut < dt && entree.DateFin > dt )
								entree.CodeEtatInt = (int)EtatEntreeAgenda.EnCours;
							if ( entree.DateFin < dt )
								entree.CodeEtatInt = (int)EtatEntreeAgenda.Terminee;
							entree.EtatAuto = true;
						}
						result = contexte.SaveAll(true);
						if ( !result )
						{
                            result.EmpileErreur(I.T("AError in the automatic management of expiration dates:Error during backup operation|316"));
							C2iEventLog.WriteErreur ( result.Erreur.ToString() );
							return;
						}
					}
				}
				finally
				{
					session.CloseSession();
				}
			}
			finally
			{
				m_bGestionAutoEnCours = false;
			}
		}

	}
}
