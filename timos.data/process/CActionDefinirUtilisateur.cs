using System;
using System.Drawing;

using System.Collections;

using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.multitiers.client;

using timos.acteurs;
using timos.securite;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionDefinirUtilisateur : CActionLienSortantSimple
	{
		private C2iExpression m_expressionUtilisateur = null;

		/// /////////////////////////////////////////
		public CActionDefinirUtilisateur( CProcess process )
			:base(process)
		{
			Libelle = I.T("Define the user ssociated with an action|377");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
                I.T("Define the user ssociated with an action|377"),
				I.T( "Indicate the user associated with an action. This user will receive the notifications and other information from the action|378"),
				typeof(CActionDefinirUtilisateur),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			AddIdVariablesExpressionToHashtable ( ExpressionUtilisateur, table );
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

			I2iSerializable exp = (m_expressionUtilisateur);
			result = serializer.TraiteObject ( ref exp );
			m_expressionUtilisateur = (C2iExpression)exp;
		
			return result;
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression ExpressionUtilisateur
		{
			get
			{
				return m_expressionUtilisateur;
			}
			set
			{
				m_expressionUtilisateur = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_expressionUtilisateur == null )
			{
				result.EmpileErreur(I.T("User Id formula is null|379"));
				return result;
			}
			if ( m_expressionUtilisateur.TypeDonnee.TypeDotNetNatif!= typeof(int))
				result.EmpileErreur(I.T("The id formula must return an integer number|380"));

			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression ( Process );
			result = ExpressionUtilisateur.Eval ( contexteEval );
            
			if ( !result )
				return result;
			else
			{
                CDbKey keyUtilisateur = null;
				try
				{
                    //TESTDBKEYOK
					int nId = Convert.ToInt32 ( result.Data );
                    keyUtilisateur = CDbKey.GetNewDbKeyOnIdAUtiliserPourCeuxQuiNeGerentPasLeDbKey(nId);
				}
				catch
				{
                    //TESTDBKEYTODO
                    if (result.Data != null)
                        keyUtilisateur = CDbKey.CreateFromStringValue(result.Data.ToString());
                    else
                    {
                        result.EmpileErreur(I.T("The user expression doesn't return an integer number|381"));
                        return result;
                    }
				}
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( contexte.ContexteDonnee );
				if ( !user.ReadIfExists ( keyUtilisateur ) )
				{
					result.EmpileErreur(I.T("The user @1 doesn't exist|382",keyUtilisateur.StringValue));
					return result;
				}
				contexte.Branche.KeyUtilisateur = keyUtilisateur;
				CSessionClient session = CSessionClient.GetSessionForIdSession(contexte.ContexteDonnee.IdSession);
				if (session != null)
					session.ChangeUtilisateur(keyUtilisateur);  
				
			}
			return result;
		}
	}
}
