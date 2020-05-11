using System;
using System.Drawing;
using System.Collections;

using sc2i.common;
using sc2i.expression;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.drawing;
using sc2i.multitiers.client;
using sc2i.process;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionEditerElement : CAction
	{
		public static string c_idServiceClientEditerElement = "ACTION_EDITER_ELEMENT";

		private C2iExpression m_expressionElementAEditer = null;
        private C2iExpression m_expressionCodeFormulaire = null;
        private bool m_bDansNavigateurPrincipal = false;
        private bool m_bDansNouvelOnglet = false;


		[Serializable]
		public class CParametreEditionElement
		{
            public readonly int IdSession;
			public readonly CReferenceObjetDonnee ReferenceObjet;
            public readonly bool DansNavigateurPrincipal;
            public readonly bool DansNouvelOnglet;
            public readonly string CodeFormulaire;
            public readonly int? IdVersionAForcer;
			
            public CParametreEditionElement(
                int nIdSession,
                CReferenceObjetDonnee reference, 
                bool bDansNavigateurPrincipal, 
                bool bDansNouvelOnglet, 
                string strCodeFormulaire,
                int? nIdVersionAForcer)
			{
                IdSession = nIdSession;
				ReferenceObjet = reference;
				DansNavigateurPrincipal = bDansNavigateurPrincipal;
                DansNouvelOnglet = bDansNouvelOnglet;
                CodeFormulaire = strCodeFormulaire;
                IdVersionAForcer = nIdVersionAForcer;
			}
		}

		/// /////////////////////////////////////////
		public CActionEditerElement( CProcess process )
			:base(process)
		{
			Libelle = I.T("Edit an element|383");
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Edit an element|383"),
				I.T("Display an element and allows the user to edit it. The action must be the last action of the process|384"),
				typeof(CActionEditerElement),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			AddIdVariablesExpressionToHashtable ( m_expressionElementAEditer, table );
		}

		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 2;
			//1 : ajout de DansNavigateurPrincipal
            //2 : Ajout de l'option "Dans Nouvel onglet" et ajout du "code du formulaire d'édition"
		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );
			if ( !result )
				return result;

			I2iSerializable objet = (I2iSerializable)m_expressionElementAEditer;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_expressionElementAEditer = (C2iExpression )objet;

			if (nVersion > 0)
				serializer.TraiteBool(ref m_bDansNavigateurPrincipal);

            if (nVersion > 1)
            {
                serializer.TraiteBool(ref m_bDansNouvelOnglet);
                result = serializer.TraiteObject<C2iExpression>(ref m_expressionCodeFormulaire);
                if (!result)
                    return result;
            }
			return result;
		}

		/// <summary>
		/// Indique que l'élément sera édité dans le navigateur principal
		/// </summary>
		public bool DansNavigateurPrincipal
		{
			get
			{
				return m_bDansNavigateurPrincipal;
			}
			set
			{
				m_bDansNavigateurPrincipal = value;
			}
		}


        public bool DansNouvelOnglet
        {
            get { return m_bDansNouvelOnglet; }
            set { m_bDansNouvelOnglet = value; }
        }


		/// /////////////////////////////////////////
		public C2iExpression FormuleElementAEditer
		{
			get
			{
				return m_expressionElementAEditer;
			}
			set
			{
				m_expressionElementAEditer = value;
			}
		}


        public C2iExpression ExpressionCodeFormulaire
        {
            get { return m_expressionCodeFormulaire; }
            set { m_expressionCodeFormulaire = value; }
        }



		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;

			if (m_expressionElementAEditer == null )
				result.EmpileErreur(I.T( "Incorrect formula for Edited element|385"));
			if ( !(m_expressionElementAEditer.TypeDonnee.TypeDotNetNatif.IsSubclassOf(typeof(CObjetDonnee) ) ) ||
				m_expressionElementAEditer.TypeDonnee.IsArrayOfTypeNatif )
				result.EmpileErreur(I.T("The edited element formula must return an entity|386"));
            if (m_expressionCodeFormulaire != null &&
                m_expressionCodeFormulaire.TypeDonnee.TypeDotNetNatif != typeof(string))
                result.EmpileErreur(I.T("Form Code formula must return a string|10000"));
			return result;
		}

		/// ////////////////////////////////////////////////////////
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

						CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceClientEditerElement);
						if (service != null)
						{
							sponsor.Register(service);
							//Evalue l'élément à éditer
							CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(Process);
							if (m_expressionElementAEditer == null)
							{
								result.EmpileErreur(I.T("Incorrect formula for Edited element|385"));
								return result;
							}
							result = m_expressionElementAEditer.Eval(contexteEval);
                            if (!result)
                                return result;
                            CObjetDonnee objet = result.Data as CObjetDonnee;

                            string strCodeFormulaire = "";
                            if (m_expressionCodeFormulaire != null)
                            {
                                result = m_expressionCodeFormulaire.Eval(contexteEval);
                                if (!result)
                                    return result;
                                strCodeFormulaire = result.Data as string;
                            }

							result = service.RunService(
                                new CParametreEditionElement(
                                    contexte.IdSession,
                                    new CReferenceObjetDonnee(objet),
                                    DansNavigateurPrincipal,
                                    DansNouvelOnglet,
                                    strCodeFormulaire,
                                    contexte.ContexteDonnee.IdVersionDeTravail));
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

		/// ///////////////////////////////////////////////
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			base.MyDraw(ctx);
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
			if (DansNavigateurPrincipal)//Si dans navigateur principal, on est forcement en sortie de process
				bHasLienStd = true;

			ArrayList lst = new ArrayList();
			if ( !bHasLienStd )
				lst.Add ( new CLienAction ( Process ) );
			if ( !bHasLienUtilisateurAbsent )
				lst.Add ( new CLienUtilisateurAbsent ( Process ) );

			return ( CLienAction[] )lst.ToArray(typeof(CLienAction));
		}




	}
}
