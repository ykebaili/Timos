using System;
using System.Linq;
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
using sc2i.documents;
using timos.Properties;
using sc2i.data;
using timos.CWndControles;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForC2iWndDocumentsGed : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
        private CControleDocumentsGed m_controleGed = new CControleDocumentsGed();
        private IFournisseurProprietesDynamiques m_fournisseurProprietes = null;

        //---------------------------------------------------------------
        public CWndForC2iWndDocumentsGed()
        {
            ImageList lst = new ImageList();
        }

		//---------------------------------------------------------------
		public static void Autoexec()
		{
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndDocumentsGed), typeof(CWndForC2iWndDocumentsGed));
		}

		//---------------------------------------------------------------
		protected override void MyCreateControle(
			CCreateur2iFormulaireV2 createur,
			C2iWnd wnd, 
			Control parent, 
			IFournisseurProprietesDynamiques fournisseurProprietes)
		{

            if (WndDocuments == null)
				return;
            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndDocuments, m_controleGed);
            m_fournisseurProprietes = fournisseurProprietes;
			parent.Controls.Add(m_controleGed);
        }

		//-------------------------------------
		private C2iWndDocumentsGed WndDocuments
		{
			get
			{
                return WndAssociee as C2iWndDocumentsGed;

			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_controleGed;
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

            CResultAErreur result = m_controleGed.MajChamps();
			return CResultAErreur.True;
		}

		//-----------------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(EditedElement);
            

            if (WndDocuments != null)
            {
                m_controleGed.Init(WndDocuments, EditedElement as CObjetDonnee, m_fournisseurProprietes);
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
