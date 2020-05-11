using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.win32.data.navigation;

using spv.data;
using spv.data.ConsultationAlarmes;

namespace spv.win32
{
    public partial class CFormConsultationAlarmeGeree : CFormMaxiSansMenu, IFormNavigable
    {
        private CInfoAlarmeAffichee m_alarmInfo;
        private CContexteDonnee m_ctxDonnee;
        private CSpvAlarmGeree m_alarmeGeree; 

        public CFormConsultationAlarmeGeree()
        {
            InitializeComponent();
        }

        public CFormConsultationAlarmeGeree(CInfoAlarmeAffichee alarmInfo, CContexteDonnee ctx)
        {
            InitializeComponent();
            m_ctxDonnee = ctx;
            m_alarmeGeree = alarmInfo.AlarmeGeree.GetSpvAlarmGeree(m_ctxDonnee);
            Init();
        }

        #region IFormNavigable Membres

        public CResultAErreur Actualiser()
        {
            Refresh();
            return CResultAErreur.True;
        }

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable ctx = new CContexteFormNavigable(GetType());
            ctx["ALARMINFO"] = m_alarmInfo;
            return ctx;

        }

        public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            m_alarmInfo = contexte["ALARMINFO"] as CInfoAlarmeAffichee;
            if (m_alarmInfo == null)
            {
                result.EmpileErreur("No alarm info for this page");
            }
            m_ctxDonnee = CSc2iWin32DataClient.ContexteCourant;
            return result;
        }

        public bool QueryClose()
        {
            return true;
        }

        #endregion

        private void Init()
        {
            m_txtConfirmLength.Text = m_alarmeGeree.DureeMin.ToString();
            m_AlarmNb.Text = (m_alarmeGeree.AlarmgereeFreqNb==null) ? "" : m_alarmeGeree.AlarmgereeFreqNb.ToString();
            m_txtPerSec.Text = (m_alarmeGeree.AlarmgereeFreqPeriod==null) ? "" : m_alarmeGeree.AlarmgereeFreqPeriod.ToString();
            m_txtComments.Text = m_alarmeGeree.Comment;
            m_txtSeuilNom.Text = m_alarmeGeree.AlarmgereeSeuilNom;
            m_txtBottomLevel.Text = (m_alarmeGeree.SeuilBas==null)? "" : m_alarmeGeree.SeuilBas.ToString();
            m_txtTopLevel.Text = (m_alarmeGeree.SeuilHaut==null)? "" : m_alarmeGeree.SeuilHaut.ToString();
            m_txtOID.Text = m_alarmeGeree.Threshold_OID;
            m_txtActions.Text = m_alarmeGeree.Corrective_Action;

            m_chkAlarmLocal.Checked = m_alarmeGeree.AlarmgereeLocal;
            m_chkAcquitter.Checked = m_alarmeGeree.Alarmgeree_Acquitter;
            m_chkDisplay.Checked = m_alarmeGeree.AlarmgereeAfficher;
            m_chkSurveiller.Checked = m_alarmeGeree.AlarmgereeSurveiller;
            m_chkAutoMib.Checked = m_alarmeGeree.Automatic_MIB;
            m_chkActiveSon.Checked = m_alarmeGeree.AlarmgereeSon;

            List<IEnumALibelle> lstProtocol = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CProtocole)));
            m_cmbProtocol.Fill(lstProtocol, "Libelle", false);
            m_cmbProtocol.SelectedValue = m_alarmeGeree.AlarmgereeProtocol;

            List<IEnumALibelle> lstSon = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CTypeSon)));
            m_cmbTypeSon.Fill(lstSon, "Libelle", false);
            m_cmbTypeSon.SelectedValue = m_alarmeGeree.AlarmgereeTypeSon;

            List<IEnumALibelle> lstGrave = CGraviteAlarmeAvecMasquage.GetListGrave();
            m_cmbSeverity.Fill(lstGrave, "Libelle", false);
            m_cmbSeverity.SelectedValue = m_alarmeGeree.AlarmgereeGravite;

            List<IEnumALibelle> lstEvent = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CAlarmEvent)));
            m_cmbEventType.Fill(lstEvent, "Libelle", false);
            m_cmbEventType.SelectedValue = m_alarmeGeree.AlarmgereeEvent;

            InitCauses();
        }

        private void InitCauses()
        {
            CListeObjetsDonnees lstCausePossible = new CListeObjetsDonnees(m_ctxDonnee, typeof(CSpvCauseAlarme));
            CListeObjetsDonnees lstCauseSelected = m_alarmeGeree.Causes;
            m_panelSelectCauses.Init(lstCausePossible, lstCauseSelected, m_alarmeGeree,
                "SpvAlarmgeree", "Cause");
            m_panelSelectCauses.RemplirGrille();
        }

        private void CFormConsultationAlarmeGeree_Load(object sender, EventArgs e)
        {
            Navigateur.TitreFenetreEnCours = I.T("Managed alarm|10016");
        }

        private void m_lnkGererCauses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}