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

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndAffecteIntervenants : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
        private CPanelAffecteIntervenants m_panelIntervenants = new CPanelAffecteIntervenants();
        

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndAffecteIntervenants), typeof(CWndForC2iWndAffecteIntervenants));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndAffecteIntervenants == null)
				return;
            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndAffecteIntervenants, m_panelIntervenants);
			parent.Controls.Add(m_panelIntervenants);
        }

		private C2iWndAffecteIntervenants WndAffecteIntervenants
		{
			get
			{
				return WndAssociee as C2iWndAffecteIntervenants;
			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_panelIntervenants;
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
            if ( m_panelIntervenants     != null )
                result = m_panelIntervenants.MajChamps();
            return result;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this, EditedElement);
            if(WndAffecteIntervenants != null && WndAffecteIntervenants.FormuleElement != null)
            {
                CResultAErreur resultExpression = WndAffecteIntervenants.FormuleElement.Eval(ctx);
                if( resultExpression)
                {
                    // Intervention
                    CIntervention element = resultExpression.Data as CIntervention;
                    if(element != null)
                    {
                        if (!LockEdition)
                            element.RecalcProfilsIntervenantsInCurrentContext(false);
                        m_panelIntervenants.Init(element);
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
