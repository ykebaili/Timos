using System;
using System.Collections.Generic;
using System.Text;
using sc2i.win32.common;
using sc2i.formulaire.win32;
using sc2i.formulaire.win32.controles2iWnd;
using sc2i.win32.data.dynamic.controlesFor2iWnd;
using timos.data;
using sc2i.formulaire;
using System.Windows.Forms;
using sc2i.expression;
using sc2i.common;
using timos;
using timos.data.C2iWndComposants;
using sc2i.common.Restrictions;
using timos.interventions.preventives;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndSaisieOperationsPrevisionnelles : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
        private CEditeurOperationsPreventives m_controleSaisieOperations = new CEditeurOperationsPreventives();
        

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndSaisieOperationsPrevisionnelles), typeof(CWndForC2iWndSaisieOperationsPrevisionnelles));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndSaisieOperations == null)
				return;
			CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndSaisieOperations, m_controleSaisieOperations);
			parent.Controls.Add(m_controleSaisieOperations);


        }

		//-------------------------------------
		private C2iWndSaisieOperationsPrevisionnelles WndSaisieOperations
		{
			get
			{
				return WndAssociee as C2iWndSaisieOperationsPrevisionnelles;

			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_controleSaisieOperations;
			}
		}

		//---------------------------------------------------------------
		protected override void OnChangeElementEdite(object element)
		{
			UpdateValeursCalculees();
		}


		//---------------------------------------------------------------
		protected override CResultAErreur MyMajChamps(bool bControlerLesValeursAvantValidation)
		{
			if ( m_controleSaisieOperations != null )
				return m_controleSaisieOperations.MajChamps();
			return CResultAErreur.True;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this,EditedElement);
            if(WndSaisieOperations.FormuleElement != null)
            {
                CResultAErreur resultExpression = WndSaisieOperations.FormuleElement.Eval(ctx);
                if( resultExpression)
                {
                    // Fraction ou Phase de Ticket
                    IElementAOperationPrevisionnelle element = resultExpression.Data as IElementAOperationPrevisionnelle;
                    if(element is CIntervention)
                    {
                        m_controleSaisieOperations.Init(element);
                    }
                }
            }

		}


		//---------------------------------------------
        protected override void MyAppliqueRestriction(
            CRestrictionUtilisateurSurType restrictionSurObjetEdite,
            CListeRestrictionsUtilisateurSurType restrictions,
            IGestionnaireReadOnlySysteme gestionnaireReadOnly)
		{

        }
	}
}
