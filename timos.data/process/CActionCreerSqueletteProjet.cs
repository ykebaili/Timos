using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;
using timos.data;
using System.IO;
using sc2i.data.Excel;
using sc2i.process.workflow;
using timos.data.process.workflow;


namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionCreerSqueletteProjet : CActionLienSortantSimple
	{
		private C2iExpression m_formuleWorkflow = null;
        private C2iExpression m_formuleProjetParent = null;
        private C2iExpression m_formuleTypeEtapeDebut = null;

		/// /////////////////////////////////////////
		public CActionCreerSqueletteProjet( CProcess process )
			:base(process)
		{
			Libelle = I.T("Project squeleton|20145");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Project squeleton|20145"),
				I.T( "Create project, child projects with dependencies according to a workflow|20146"),
				typeof(CActionCreerSqueletteProjet),
				CGestionnaireActionsDisponibles.c_categorieMetier );
		}


		

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleWorkflow
		{ 
			get
			{
				return m_formuleWorkflow;
			}
			set
			{
				m_formuleWorkflow = value;
			}
		}

        /// ////////////////////////////////////////////////////////
        public C2iExpression FormuleProjetParent
        {
            get
            {
                return m_formuleProjetParent;
            }
            set
            {
                m_formuleProjetParent = value;
            }
        }

        /// ////////////////////////////////////////////////////////
        public C2iExpression FormuleTypeEtapeDebut
        {
            get
            {
                return m_formuleTypeEtapeDebut;
            }
            set
            {
                m_formuleTypeEtapeDebut = value;
            }
        }

        /// /////////////////////////////////////////
        private int GetNumVersion()
        {
            return 1;
        }
		
		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );

            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleWorkflow);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleProjetParent);
            if (nVersion >= 1 && result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleTypeEtapeDebut);
			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
			if ( m_formuleWorkflow == null || 
				!(m_formuleWorkflow.TypeDonnee.TypeDotNetNatif == typeof(CWorkflow)) ||
				m_formuleWorkflow.TypeDonnee.IsArrayOfTypeNatif)
				result.EmpileErreur(I.T("Invalid workflow formula|20147"));

            if (!(m_formuleProjetParent is C2iExpressionNull) && ( m_formuleProjetParent == null ||
                !(m_formuleProjetParent.TypeDonnee.TypeDotNetNatif == typeof(CProjet)) ||
                m_formuleProjetParent.TypeDonnee.IsArrayOfTypeNatif))
                result.EmpileErreur(I.T("Invalid project formula|20147"));

            if (m_formuleTypeEtapeDebut != null)
            {
                if (!(m_formuleTypeEtapeDebut is C2iExpressionNull) && (m_formuleTypeEtapeDebut == null ||
                    !(m_formuleTypeEtapeDebut.TypeDonnee.TypeDotNetNatif == typeof(CTypeEtapeWorkflow)) ||
                    m_formuleProjetParent.TypeDonnee.IsArrayOfTypeNatif))
                    result.EmpileErreur(I.T("Invalid Start step formula|20155"));
            }
            
			return result;
		}

		/// ////////////////////////////////////////////////////////
        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(Process);
            if (FormuleProjetParent == null)
            {
                result.EmpileErreur(I.T("Invalid project formula|20147"));
                return result;
            }
            result = FormuleProjetParent.Eval(ctxEval);
            if (!result)
                return result;
            CProjet projetParent = result.Data as CProjet;

            if (FormuleWorkflow == null)
            {
                result.EmpileErreur(I.T("Invalid workflow formula|20147"));
                return result;
            }
            result = FormuleWorkflow.Eval(ctxEval);
            if (!result)
                return result;
            CWorkflow workflow = result.Data as CWorkflow;

            if (workflow == null)
            {
                result.EmpileErreur(I.T("Invalid workflow|20149"));
                return result;
            }

            CTypeEtapeWorkflow typeEtapeDebut = null;
            if (FormuleTypeEtapeDebut != null)
            {
                result = FormuleTypeEtapeDebut.Eval(ctxEval);
                if (!result)
                {
                    result.EmpileErreur(I.T("Invalid Start step formula|20155"));
                    return result;
                }
                typeEtapeDebut = result.Data as CTypeEtapeWorkflow;
            }

            result = CGestionnaireProjetsDeWorkflow.CreateSqueletteProjetsInCurrentContext(
                workflow,
                typeEtapeDebut,
                projetParent);

            return result;
        }

		//-----------------------------------------------
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
            AddIdVariablesExpressionToHashtable(FormuleWorkflow, table);
            AddIdVariablesExpressionToHashtable(FormuleProjetParent, table);			
		}
	}
}
