using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using sc2i.custom;
using sc2i.expression;
using sc2i.win32.data;
using sc2i.data.dynamic;
using sc2i.common;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkFormulaireCustom : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkAfficheFormulaireCustom m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        //--------------------------------------------------------------------------------------
        public CPanelEditeActionSurLinkFormulaireCustom()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Custom form|158"),
                typeof(CActionSur2iLinkAfficheFormulaireCustom),
                typeof(CPanelEditeActionSurLinkFormulaireCustom));
        }

        //--------------------------------------------------------------------------------------
        private void CPanelEditeActionSurLinkFormulaireCustom_Load(object sender, EventArgs e)
        {
            CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CFormulaire));
            listeFormulaires.Filtre = new CFiltreData(
                CFormulaire.c_champCodeRole + " is null ");
            if (m_objetPourSousProprietes != null && m_objetPourSousProprietes.TypeAnalyse != null)
            {
                listeFormulaires.Filtre.Filtre += " or " + CFormulaire.c_champTypeElementEdite + "=@1";
                listeFormulaires.Filtre.Parametres.Add(m_objetPourSousProprietes.TypeAnalyse.ToString());
            }
            m_cmbFormulaireCustom.Fill(listeFormulaires, "Libelle", true);
        }

        //--------------------------------------------------------------------------------------
        public void InitChamps(sc2i.formulaire.CActionSur2iLink action, sc2i.expression.CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkAfficheFormulaireCustom;
            if (m_actionEditee == null)
            {
                Visible = false;
                return;
            }
            m_objetPourSousProprietes = objetPourSousProprietes;
            Visible = true;
            CFormulaire formulaire = new CFormulaire(CSc2iWin32DataClient.ContexteCourant);
            if (formulaire.ReadIfExists(m_actionEditee.IdFormulaireInDb))
                m_cmbFormulaireCustom.SelectedValue = formulaire;
        }

        //--------------------------------------------------------------------------------------
        public sc2i.common.CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (!(m_cmbFormulaireCustom.SelectedValue is CFormulaire))
            {
                result.EmpileErreur(I.T("Please select a standard Frorm|10010"));
                return result;
            }
            m_actionEditee.IdFormulaireInDb = ((CFormulaire)m_cmbFormulaireCustom.SelectedValue).Id;
            return result;
        }
    }
}
