using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.workflow;
using sc2i.win32.data.dynamic;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.common;

namespace timos
{
    public partial class CPanelResumeSousDossier : UserControl ,IControlALockEdition
    {
        private CCreateur2iFormulaireObjetDonnee m_createur = null;
        private CFormulaire m_formulaireAffiche = null;
        private CDossierSuivi m_dossier = null;
        public CPanelResumeSousDossier()
        {
            InitializeComponent();
        }

        //------------------------------------------------
        private void CPanelResumeSousDossier_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

        //------------------------------------------------
        public void Init(CDossierSuivi sousDossier)
        {
            if ( m_createur == null )
                m_createur = new CCreateur2iFormulaireObjetDonnee ( sousDossier.ContexteDonnee.IdSession );
            m_dossier = sousDossier;
            if ( sousDossier.TypeDossier.FormulaireResume == null )
            {
                m_formulaireAffiche = null;
                m_panelFormulaire.Visible = false;
                return;
            }
            m_panelFormulaire.Visible = true;
            if (m_formulaireAffiche == null || m_formulaireAffiche != sousDossier.TypeDossier.FormulaireResume)
            {
                m_formulaireAffiche = sousDossier.TypeDossier.FormulaireResume;
                foreach (Control ctrl in m_panelFormulaire.Controls)
                {
                    ctrl.Visible = false;
                    ctrl.Dispose();
                }
                m_panelFormulaire.Controls.Clear();
                m_createur.CreateControlePrincipalEtChilds(m_panelFormulaire, m_formulaireAffiche.Formulaire,
                    new CFournisseurGeneriqueProprietesDynamiques());
            }
            m_createur.ElementEdite = sousDossier;
        }

        //------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_formulaireAffiche == null || m_createur == null)
                return result;
            m_createur.ControleValeursAvantValidation = true;
            result = m_createur.MAJ_Champs();
            return result;
        }

        #region IControlALockEdition Membres

        //------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
                if (m_createur != null)
                    m_createur.LockEdition = LockEdition;
            }
        }

        //------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        #endregion

        //------------------------------------------------
        private void m_lnkDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormEditionDossierSuivi form = new CFormEditionDossierSuivi(m_dossier);
            CTimosApp.Navigateur.AffichePage(form);
        }
    }
}
