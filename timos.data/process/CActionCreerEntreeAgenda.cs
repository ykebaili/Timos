using System;
using System.Drawing;

using System.Collections;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionCreerEntreeAgenda : CActionFonction
	{
		private CParametreEntreeAgenda m_parametre = new CParametreEntreeAgenda();
		

		/// /////////////////////////////////////////
		public CActionCreerEntreeAgenda( CProcess process )
			:base(process)
		{
			Libelle = I.T("Diary entry creation|374");
			VariableRetourCanBeNull = true;
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Diary entry creation|374"),
				I.T("Creates a diary entry and associate it with various elements|375"),
				typeof(CActionCreerEntreeAgenda),
				CGestionnaireActionsDisponibles.c_categorieMetier );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
		}

		/// /////////////////////////////////////////////////////////
		public override CTypeResultatExpression TypeResultat
		{
			get
			{
				return new CTypeResultatExpression(
					typeof(CEntreeAgenda),
					false );
			}
		}


		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			base.AddIdVariablesNecessairesInHashtable ( table );
			AddIdVariablesExpressionToHashtable ( Parametre.FormuleCommentaires, table );
			AddIdVariablesExpressionToHashtable ( Parametre.FormuleDateDebut, table );
			AddIdVariablesExpressionToHashtable ( Parametre.FormuleDateFin, table );
			AddIdVariablesExpressionToHashtable ( Parametre.FormuleLibelle, table );
			foreach ( CParametreRelationEntreeAgenda_ChampCustom rel in Parametre.ParametresChamps )
				AddIdVariablesExpressionToHashtable ( rel.FormuleValeur, table );
			foreach ( CParametreRelationEntreeAgenda_TypeElement rel in Parametre.ParametresTypesElements )
				AddIdVariablesExpressionToHashtable ( rel.FormuleLien, table );
		}

		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// /////////////////////////////////////////
		public CParametreEntreeAgenda Parametre
		{
			get
			{
				return m_parametre;
			}
			set
			{
				m_parametre = value;
			}
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

			bool bHasHadObjetContexte = false;
			if ( serializer.GetObjetAttache ( typeof(CContexteDonnee) )==null )
			{
				bHasHadObjetContexte = true;
				serializer.AttacheObjet ( typeof(CContexteDonnee), Process.ContexteDonnee );
			}

			I2iSerializable objet = m_parametre;
			result = serializer.TraiteObject ( ref objet );
			m_parametre = (CParametreEntreeAgenda)objet;

			if ( !result )
				return result;
			if ( bHasHadObjetContexte )
				serializer.DetacheObjet ( typeof(CContexteDonnee), Process.ContexteDonnee );
			return result;
		}

		

		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();

			if ( m_parametre == null )
			{
				result.EmpileErreur(I.T( "Entry parameter isn't defined|376"));
				return result;
			}
			result=  m_parametre.VerifieDonnees();


			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;

			result = Parametre.CreateEntree ( contexte.ContexteDonnee,
				new CContexteEvaluationExpression ( Process ) );
			if ( !result )
				return result;
			if ( VariableResultat != null )
				Process.SetValeurChamp ( VariableResultat, result.Data );
			result.Data = null;
			CLienAction[] liens = GetLiensSortantHorsErreur();
			if ( liens.Length > 0 )
				result.Data = liens[0];
			return result;
		}
	}
}
