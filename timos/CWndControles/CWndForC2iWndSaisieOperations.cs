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

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndSaisieOperations : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
		private CControleSaisiesOperations m_controleSaisieOperations = new CControleSaisiesOperations();
        

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndSaisieOperations), typeof(CWndForC2iWndSaisieOperations));
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
		private C2iWndSaisieOperations WndSaisieOperations
		{
			get
			{
				return WndAssociee as C2iWndSaisieOperations;

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
				return m_controleSaisieOperations.Maj_Champs();
			return CResultAErreur.True;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this, EditedElement);
            if(WndSaisieOperations.FormuleElement != null)
            {
                CResultAErreur resultExpression = WndSaisieOperations.FormuleElement.Eval(ctx);
                if( resultExpression)
                {
                    // Fraction ou Phase de Ticket
                    IElementAOperationsRealisees element = resultExpression.Data as IElementAOperationsRealisees;
                    if(element is CFractionIntervention || element is CPhaseTicket)
                    {
                        m_controleSaisieOperations.Init(element);
						m_controleSaisieOperations.PanelEnteteVisible = WndSaisieOperations.HeaderPanelVisible;
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
