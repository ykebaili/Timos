using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using timos.data;


using sc2i.win32.common;
using sc2i.common;
using sc2i.workflow;
using sc2i.process.workflow.gels;

namespace timos.interventions
{
	public partial class CFormGelerIntervention : CFloatingFormBase
	{

		//-------------------------------------------
		private IElementGelable m_elementGelable = null;
		private EventHandler m_handlerOnGeler = null;
		private bool m_bModeGeler = true;
		private bool m_bModif = false;
		private CGel m_gel = null;
		//-------------------------------------------
		public CFormGelerIntervention()
		{
			InitializeComponent();
		}

		//-------------------------------------------
		public static void Geler(IElementGelable eltGelable, EventHandler onGelerEventHandler)
		{
			CFormGelerIntervention form = new CFormGelerIntervention();
			form.m_elementGelable = eltGelable;
			form.m_handlerOnGeler = onGelerEventHandler;
			form.m_bModeGeler = true;
			form.m_bModif = false;
            form.Show();
		}
		public static void ModificationGeler(CGel gel, EventHandler onDegelerEventHandler)
		{
			CFormGelerIntervention form = new CFormGelerIntervention();
			form.m_gel = gel;
			form.m_handlerOnGeler = onDegelerEventHandler;
			form.m_bModeGeler = true;
			form.m_bModif = true;
			form.Show();
		}
		//-------------------------------------------
		public static void Degeler(IElementGelable eltGelable, EventHandler onDegelerEventHandler)
		{
			CFormGelerIntervention form = new CFormGelerIntervention();
			form.m_elementGelable = eltGelable;
			form.m_gel = (CGel)eltGelable.Gels[eltGelable.Gels.Count - 1];
			form.m_handlerOnGeler = onDegelerEventHandler;
			form.m_bModeGeler = false;
			form.m_bModif = false;
			form.Show();
		}
		public static void ModificationDegeler(CGel gel, EventHandler onDegelerEventHandler)
		{
			CFormGelerIntervention form = new CFormGelerIntervention();
			form.m_handlerOnGeler = onDegelerEventHandler;
			form.m_gel = gel;
			form.m_bModeGeler = false;
			form.m_bModif = true;
			form.Show();
		}

		//-------------------------------------------
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			Hide();
		}

		//-------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
            if (m_bModeGeler && !(m_cmbCause.ElementSelectionne is CCauseGel))
            {
                CFormAlerte.Afficher(I.T("Select a cause of freezing|1373"), EFormAlerteType.Exclamation);
                return;
            }
            CResultAErreur result = CResultAErreur.True;
			if (m_bModeGeler)
			{
				//Si on est en modif on test
				if(m_bModif && (m_gel.DateFin < m_dtGel.Value))
					result.EmpileErreur(I.T("The freezing start date cannot be after the freezing end date|1378"));

				//On regarde si la date de début ne rentre pas en conflit avec le gel précédant
				//foreach (CGel g in m_gel.ElementGelable.Gels)
				//    if (g.Id != m_gel.Id && g.DateFin < m_gel.DateDebut && g.DateFin > m_dtGel.Value)
				//    {
				//        MessageBox.Show(I.T("Impossible because the last freeze finish after the start date indicated|1382"));	
				//        return;
				//    }
			}
			else
			{
				if (m_gel.DateDebut > m_dtGel.Value)
					result.EmpileErreur(I.T("The freezing start date cannot be after the freezing end date|1378"));

				//On regarde si la date de fin ne rentre pas en conflit avec le gel suivant
				//foreach(CGel g in m_gel.ElementGelable.Gels)
				//    if(g.Id != m_gel.Id && g.DateDebut > m_gel.DateFin && g.DateDebut < m_dtGel.Value)
				//    {
				//        MessageBox.Show(I.T("Impossible because the next freeze begin before the end date indicated|1381"));
				//        return;
				//    }
			}
			if (result)
			{
				if (m_bModeGeler)
				{
					if (m_bModif)
						result = SElementGelable.ModifGeler(m_gel, m_dtGel.Value, (CCauseGel)m_cmbCause.ElementSelectionne, m_txtInfo.Text);
					else
						result = m_elementGelable.Geler(m_dtGel.Value, (CCauseGel)m_cmbCause.ElementSelectionne, m_txtInfo.Text);
				}
				else
				{
					if(m_bModif)
						result = SElementGelable.ModifDegeler(m_gel, m_dtGel.Value, m_txtInfo.Text);
					else
						result = m_elementGelable.Degeler(m_dtGel.Value, m_txtInfo.Text);
				}
			}

			if (!result)
			{
				if(m_bModeGeler && !m_bModif)
					result.EmpileErreur(I.T("Freezing impossible|1374"));
				else if(!m_bModeGeler && !m_bModif)
					result.EmpileErreur(I.T("Impossible unfreezing|1388"));
				else
					result.EmpileErreur(I.T("Modification impossible|1379"));

				CFormAlerte.Afficher(result.Erreur);
			}
			else
			{
				if (m_handlerOnGeler != null)
					m_handlerOnGeler(this, new EventArgs());
			}

            Hide();
		}

		private void CFormGelerIntervention_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
			m_lblTitre.Text = m_bModeGeler ? I.T("Freeze|1375") : I.T("Unfreeze|1386");
			m_lblFreezeDate.Text = m_bModeGeler ? I.T("Freezing Start|603") : I.T("Freezing End|1387");
			m_lblInfoFreez.Text = m_bModeGeler ? I.T("Freezing information|605") : I.T("Unfreezing information|1380");
			m_panCause.Visible = m_bModeGeler;
			m_cmbCause.Init(typeof(CCauseGel), "Libelle", true);
			m_cmbCause.LockEdition = !m_bModeGeler;
			if (m_gel == null)
				m_dtGel.Value = DateTime.Now;
			else
			{
				if (m_bModeGeler)
				{
					m_dtGel.Value = m_gel.DateDebut;
					m_cmbCause.ElementSelectionne = m_gel.CauseGel;
					m_txtInfo.Text = m_gel.InfosDebutGel;
				}
				else
				{
					if(m_gel.DateFin != null)
						m_dtGel.Value = m_gel.DateFin.Value;
					m_txtInfo.Text = m_gel.InfosFinGel;
				}
			}
		}
	}
}
