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
using timos.acteurs;
using sc2i.common.Restrictions;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndSaisieActivitesActeur : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
        private CControleSaisieDesActivitesActeur m_controleSaisieActivites = new CControleSaisieDesActivitesActeur();

        DateTime m_dateDebut = DateTime.Now.AddDays(-7).Date;
        DateTime m_dateFin = DateTime.Now.Date;

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndSaisieDesActivitesActeur), typeof(CWndForC2iWndSaisieActivitesActeur));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndSaisieActivites == null)
				return;

            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this, EditedElement); 
            CResultAErreur resultExpression;
            if (WndSaisieActivites.InitialStartDate != null)
            {
                resultExpression = WndSaisieActivites.InitialStartDate.Eval(ctx);
                if (resultExpression.Data is DateTime)
                    m_dateDebut = (DateTime)resultExpression.Data;
            }
            if (WndSaisieActivites.InitialEndDate != null)
            {
                resultExpression = WndSaisieActivites.InitialEndDate.Eval(ctx);
                m_dateFin = DateTime.Now.Date;
                if (resultExpression.Data is DateTime)
                    m_dateFin = (DateTime)resultExpression.Data;
            }

            m_controleSaisieActivites.OnChangeDates += new EventHandler(m_controleSaisieActivites_OnChangeDates);
			CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndSaisieActivites, m_controleSaisieActivites);
			parent.Controls.Add(m_controleSaisieActivites);

        }

        //--------------------------------------------------------------------------
        // Evenement de changement des dates de saisie
        void m_controleSaisieActivites_OnChangeDates(object sender, EventArgs e)
        {
            m_dateDebut = m_controleSaisieActivites.DateDebut;
            m_dateFin = m_controleSaisieActivites.DateFin;
            CUtilControlesWnd.DeclencheEvenement(C2iWndSaisieDesActivitesActeur.c_strIdEvenementChangeDates, this);
        }

		//--------------------------------------------------------------------------
        private C2iWndSaisieDesActivitesActeur WndSaisieActivites
		{
			get
			{
                return WndAssociee as C2iWndSaisieDesActivitesActeur;
			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_controleSaisieActivites;
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
			if ( m_controleSaisieActivites != null )
				return m_controleSaisieActivites.Maj_Champs();
			return CResultAErreur.True;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = CUtilControlesWnd.GetContexteEval(this, EditedElement);
            if(WndSaisieActivites.ElementFormula != null)
            {
                CResultAErreur resultExpression = WndSaisieActivites.ElementFormula.Eval(ctx);
                if( resultExpression)
                {
                    // C'est un Acteur
                    CActeur acteur = resultExpression.Data as CActeur;
                    if(acteur != null)
                    {
                        m_controleSaisieActivites.Init(acteur, m_dateDebut, m_dateFin);
						
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
