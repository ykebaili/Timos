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
using timos.data;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionImprimerModeleTexte : CAction
	{
		public static string c_idServiceClientImprimerModeleTexte = "ACTION_IMPRIMER_MODELE_TEXTE";

		private C2iExpression m_expressionElementSource = null;
        private C2iExpression m_formuleParametresImpression = null;
        private int m_nIdModeleAImprimer = -1;


		[Serializable]
		public class CParametreImpressionModeleTexte
		{
			public readonly CReferenceObjetDonnee ReferenceObjet;
            public readonly int IdModeleTexte;
            public readonly string ParametresImpression;
			
            public CParametreImpressionModeleTexte(
                CReferenceObjetDonnee reference, 
                int nIdModele,
                string strParametresImpression )
			{
				ReferenceObjet = reference;
				IdModeleTexte = nIdModele;
                ParametresImpression = strParametresImpression;
                
			}
		}

		/// /////////////////////////////////////////
		public CActionImprimerModeleTexte( CProcess process )
			:base(process)
		{
			Libelle = I.T("Print text model|20038");
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
                I.T("Print text model|20038"),
				I.T("Print a text document using a text model and a source element|20039"),
				typeof(CActionImprimerModeleTexte),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			AddIdVariablesExpressionToHashtable ( m_expressionElementSource, table );
		}

		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
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

			I2iSerializable objet = (I2iSerializable)m_expressionElementSource;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_expressionElementSource = (C2iExpression )objet;

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleParametresImpression);


            serializer.TraiteInt(ref m_nIdModeleAImprimer);
			return result;
		}

        /// /////////////////////////////////////////
        public override Image GetImage()
        {
            return Resource.printer;
        }


		/// /////////////////////////////////////////
		public C2iExpression FormuleElementAEditer
		{
			get
			{
				return m_expressionElementSource;
			}
			set
			{
				m_expressionElementSource = value;
			}
		}

        /// /////////////////////////////////////////
        public C2iExpression FormuleParametresImpression
        {
            get
            {
                return m_formuleParametresImpression;
            }
            set
            {
                m_formuleParametresImpression = value;
            }
        }

        /// /////////////////////////////////////////
        public int? IdModeleAEditer
        {
            get
            {
                if (m_nIdModeleAImprimer < 0)
                    return null;
                return m_nIdModeleAImprimer;
            }
            set
            {
                if (value == null)
                    m_nIdModeleAImprimer = -1;
                else
                    m_nIdModeleAImprimer = value.Value;
            }
        }


		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;

			if (m_expressionElementSource == null )
				result.EmpileErreur(I.T( "Incorrect formula for Edited element|385"));
			if ( !(m_expressionElementSource.TypeDonnee.TypeDotNetNatif.IsSubclassOf(typeof(CObjetDonnee) ) ) ||
				m_expressionElementSource.TypeDonnee.IsArrayOfTypeNatif )
				result.EmpileErreur(I.T("The edited element formula must return an entity|386"));
            if (m_formuleParametresImpression == null ||
                !typeof(string).IsAssignableFrom(m_formuleParametresImpression.TypeDonnee.TypeDotNetNatif))
                result.EmpileErreur(I.T("Print setup formula is not correct|20041"));
            if (m_nIdModeleAImprimer < 0)
                result.EmpileErreur(I.T("The text modele must be selected|20040"));
			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur ExecuteAction(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			//Si la session qui execute est une session de l'utilisateur associé à la branche,
			//Tente d'ImprimerModeleTexte sur cette session,

            CSessionClient sessionClient = CSessionClient.GetSessionForIdSession ( contexte.IdSession );
			if ( sessionClient != null )
			{
                //TESTDBKEYOK
                if (sessionClient.GetInfoUtilisateur().KeyUtilisateur == contexte.Branche.KeyUtilisateur)
				{
					using (C2iSponsor sponsor = new C2iSponsor())
					{

						CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceClientImprimerModeleTexte);
						if (service != null)
						{
							sponsor.Register(service);
							//Evalue l'élément à éditer
							CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(Process);
							if (m_expressionElementSource == null)
							{
								result.EmpileErreur(I.T("Incorrect formula for Edited element|385"));
								return result;
							}
							result = m_expressionElementSource.Eval(contexteEval);
                            if (!result)
                                return result;
                            CObjetDonnee objet = result.Data as CObjetDonnee;

                            if (m_formuleParametresImpression == null)
                            {
                                result.EmpileErreur(I.T("Print setup formula is not correct|20041"));
                                return result;
                            }
                            result = m_formuleParametresImpression.Eval(contexteEval);
                            if (!result || !(result.Data is string))
                            {
                                result.EmpileErreur(I.T("Print setup formula is not correct|20041"));
                                return result;
                            }
                            string strParametresImpression = result.Data.ToString();

							result = service.RunService(
                                new CParametreImpressionModeleTexte(
                                    new CReferenceObjetDonnee(objet),
                                    m_nIdModeleAImprimer,
                                    strParametresImpression ));

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
			ArrayList lst = new ArrayList();
			if ( !bHasLienStd )
				lst.Add ( new CLienAction ( Process ) );
			if ( !bHasLienUtilisateurAbsent )
				lst.Add ( new CLienUtilisateurAbsent ( Process ) );

			return ( CLienAction[] )lst.ToArray(typeof(CLienAction));
		}




	}
}
