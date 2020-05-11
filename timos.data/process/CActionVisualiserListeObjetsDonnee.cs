using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;

using sc2i.multitiers.client;
using sc2i.process;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionVisualiserListeObjetsDonnee.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionVisualiserListeObjetsDonnee : CAction
	{
		public const string c_idServiceVisualisationListeObjetsDonnee = "VISU_LISTE_ENTITES";

		private CFiltreDynamique m_filtreDynamique;

		private bool m_bAppliquerFiltreParDefaut = true;

		private C2iExpression m_expressionContexteFenetre = null;
		private C2iExpression m_expressionTitreFenetre = null;
	
		/// /////////////////////////////////////////////////////////
		public CActionVisualiserListeObjetsDonnee( CProcess process)
			:base(process)
		{
			m_filtreDynamique = null;
			Libelle = I.T("Display a list|413");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T("Display an object list|414"),
				I.T("Opens a window to display a list of objects|415"),
				typeof(CActionVisualiserListeObjetsDonnee),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		/// ////////////////////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable ( Hashtable table )
		{
		}

		
		/// /////////////////////////////////////////////////////////
		public bool AppliquerFiltreParDefaut
		{
			get
			{
				return m_bAppliquerFiltreParDefaut;
			}
			set
			{
				m_bAppliquerFiltreParDefaut = value;
			}
		}

		/// /////////////////////////////////////////////////////////
		public C2iExpression ExpressionContexteFenetre
		{
			get
			{
				return m_expressionContexteFenetre;
			}
			set
			{
				m_expressionContexteFenetre = value;
			}
		}


		/// /////////////////////////////////////////////////////////
		public C2iExpression ExpressionTitreFenetre
		{
			get
			{
				return m_expressionTitreFenetre;
			}
			set
			{
				m_expressionTitreFenetre = value;
			}
		}


		/// /////////////////////////////////////////////////////////
		public CFiltreDynamique Filtre
		{
			get
			{
				if ( m_filtreDynamique == null )
					m_filtreDynamique = new CFiltreDynamique(Process, Process.ContexteDonnee);
				return m_filtreDynamique;
			}
			set
			{
				m_filtreDynamique = value;
			}
		}

		/// /////////////////////////////////////////////////////////
		protected override CLienAction[] GetMyLiensSortantsPossibles()
		{
			CLienAction[] listeLiens = GetLiensSortantHorsErreur();
			bool bHasLienUtilisateurAbsent = false;
			bool bHasLienStd = false;
			foreach ( CLienAction lien in listeLiens )
			{
				if ( lien is CLienUtilisateurAbsent )
					bHasLienUtilisateurAbsent = true;
				else
					bHasLienStd = true;
			}

			ArrayList lst = new ArrayList();
			if ( !bHasLienStd )
				lst.Add ( new CLienAction ( Process ) );
			if ( !bHasLienUtilisateurAbsent )
				lst.Add ( new CLienUtilisateurAbsent ( Process ) );

			return ( CLienAction[] )lst.ToArray(typeof(CLienAction));
		}

		

		/// /////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 1;
			//1 ajout des contextes et titres de fenêtre
		}

		/// /////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize(C2iSerializer serializer)
		{
			CResultAErreur result = CResultAErreur.True;
			int nVersion = GetNumVersion();
			result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base .MySerialize(serializer);
			if ( !result )
				return result;

			I2iSerializable objet = m_filtreDynamique;
			result = serializer.TraiteObject ( ref objet, Process, Process.ContexteDonnee );
			if ( !result )
			{
                result.EmpileErreur(I.T("Error in filter serialization|416"));
				return result;
			}
			m_filtreDynamique = (CFiltreDynamique)objet;

			serializer.TraiteBool ( ref m_bAppliquerFiltreParDefaut ) ;

			if ( nVersion >= 1 )
			{
				objet = ExpressionContexteFenetre;
				result = serializer.TraiteObject ( ref objet );
				if ( !result )
					return result;
				ExpressionContexteFenetre =(C2iExpression)objet;

				objet = ExpressionTitreFenetre;
				result = serializer.TraiteObject ( ref objet );
				if ( !result )
					return result;
				ExpressionTitreFenetre = (C2iExpression)objet;
			}

			return result;
		}

		/// /////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
			if ( Filtre.TypeElements == null )
				result.EmpileErreur(I.T("The objects type of the list creating action isn't defined|417"));
			return result;
		}

		/// /////////////////////////////////////////////////////////
		protected override CResultAErreur ExecuteAction(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;

			//Si la session qui execute est une session de l'utilisateur associé à la branche,
			//Tente d'afficher le EditerElement sur cette session,
			//Sinon, enregistre une Intervention sur l'utilisateur
			CSessionClient sessionClient = CSessionClient.GetSessionForIdSession ( contexte.IdSession );
			if ( sessionClient != null )
			{
                //TESTDBKEYOK
				if ( sessionClient.GetInfoUtilisateur().KeyUtilisateur == contexte.Branche.KeyUtilisateur )
				{
					using (C2iSponsor sponsor = new C2iSponsor())
					{
						CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceVisualisationListeObjetsDonnee);
						if (service != null)
						{
							sponsor.Register(service);
							CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(Process);
							string strContexte = "";
							string strTitre = "";
							if (ExpressionContexteFenetre != null)
							{
								result = ExpressionContexteFenetre.Eval(ctxEval);
								if (!result)
									return result;
								if (result.Data != null)
									strContexte = result.Data.ToString();
							}
							if (ExpressionTitreFenetre != null)
							{
								result = ExpressionTitreFenetre.Eval(ctxEval);
								if (!result)
									return result;
								if (result.Data != null)
									strTitre = result.Data.ToString();
							}

							if (Filtre.TypeElements == null)
							{
								result.EmpileErreur(I.T("The object type is not defined|418"));
								return result;
							}
							CFiltreData filtre = null;
							if (m_filtreDynamique != null)
							{
								m_filtreDynamique.ContexteDonnee = contexte.ContexteDonnee;
								m_filtreDynamique.ElementAVariablesExterne = Process;

								result = m_filtreDynamique.GetFiltreData();
								if (!result)
								{
									result.EmpileErreur(I.T("Error while calculating the filter|419"));
									return result;
								}
								filtre = (CFiltreData)result.Data;
							}

							CParametreServiceVisuListeObjets parametre = new CParametreServiceVisuListeObjets(
								Filtre.TypeElements,
								filtre,
								m_bAppliquerFiltreParDefaut,
								strTitre,
								strContexte);
							if (result)
								result = service.RunService(parametre);
							//Fin du process
							result.Data = null;
							if (result)
							{
								foreach (CLienAction lien in this.GetLiensSortantHorsErreur())
									if (!(lien is CLienUtilisateurAbsent))
										result.Data = lien;
							}
							return result;
						}
					}
				}
			}
			//Utilisateur pas accessible
			foreach ( CLienAction lien in GetLiensSortantHorsErreur() )
			{
				if ( lien is CLienUtilisateurAbsent )
				{
					result.Data = lien;
					return result;
				}
			}
			return result;
		}
	}

	[Serializable]
	public class CParametreServiceVisuListeObjets
	{
		public readonly CFiltreData Filtre;
		public readonly bool AppliquerFiltreParDefaut;
		public readonly Type TypeElements;
		public readonly string TitreFenetre;
		public readonly string ContexteFenetre;

		public CParametreServiceVisuListeObjets()
		{
		}

		public CParametreServiceVisuListeObjets ( 
			Type typeElements,
			CFiltreData filtre,
			bool bAppliquerFiltreParDefaut,
			string strTitreFenetre,
			string strContexteFenetre)
		{
			TypeElements = typeElements;
			Filtre = filtre;
			AppliquerFiltreParDefaut = bAppliquerFiltreParDefaut;
			TitreFenetre = strTitreFenetre;
			ContexteFenetre = strContexteFenetre;
		}
	}
}
