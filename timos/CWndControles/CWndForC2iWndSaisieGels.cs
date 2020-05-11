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
using timos.interventions;
using sc2i.common.Restrictions;
using sc2i.process.workflow.gels;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndSaisieGels : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
		private CPanelInfoGel m_panelInfoGel = new CPanelInfoGel();
        

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndSaisieGels), typeof(CWndForC2iWndSaisieGels));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndSaisieGels == null)
				return;
            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndSaisieGels, m_panelInfoGel);
			parent.Controls.Add(m_panelInfoGel);
        }

		private C2iWndSaisieGels WndSaisieGels
		{
			get
			{
				return WndAssociee as C2iWndSaisieGels;
			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_panelInfoGel;
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
            CResultAErreur result = CResultAErreur.True;
            return result;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this, EditedElement);
            if(WndSaisieGels != null && WndSaisieGels.FormuleElement != null)
            {
                CResultAErreur resultExpression = WndSaisieGels.FormuleElement.Eval(ctx);
                if( resultExpression)
                {
                    // Intervention ou Phase de Ticket
                    IElementGelable element = resultExpression.Data as IElementGelable;
                    if(element is CIntervention|| element is CPhaseTicket)
                    {
                        m_panelInfoGel.Init(element);
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
