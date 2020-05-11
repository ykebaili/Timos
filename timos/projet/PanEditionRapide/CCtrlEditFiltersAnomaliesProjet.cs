using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.data.dynamic;

using timos.data;

namespace timos
{
	public partial class CCtrlEditFiltersAnomaliesProjet : UserControl
	{
		private CProjet m_projet;
		//------------------------------------------------
		public CCtrlEditFiltersAnomaliesProjet()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		private bool m_bInitialise = false;
		public void Init(CProjet projet)
		{
			m_bInitialise = false;
			m_projet = projet;
			m_chkBoucles.Checked = ((m_projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.Boucle) == ETypeAnomalieProjet.Boucle);
			m_chkContraintes.Checked = ((m_projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.NonRespectContrainteDate) == ETypeAnomalieProjet.NonRespectContrainteDate);
			m_chkPrePlannification.Checked = ((m_projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.PrePlanificationIncomplete) == ETypeAnomalieProjet.PrePlanificationIncomplete);
			m_chkPlannification.Checked = ((m_projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.PlanificationIncomplete) == ETypeAnomalieProjet.PlanificationIncomplete);
			m_chkInclurePrjsFils.Checked = m_projet.InclureAnomaliesProjetsFils;
			m_bInitialise = true;

		}

		private void m_chkPrePlannification_CheckedChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
			{
				//m_projet.BeginEdit();
				if (m_chkPrePlannification.Checked)
					m_projet.TypesAnomaliesFiltres |= ETypeAnomalieProjet.PrePlanificationIncomplete;
				else
					m_projet.TypesAnomaliesFiltres &= ~ETypeAnomalieProjet.PrePlanificationIncomplete;
				//m_projet.CommitEdit();
			}
		}

		private void m_chkPlannification_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				//m_projet.BeginEdit();
				if (m_chkPlannification.Checked)
					m_projet.TypesAnomaliesFiltres |= ETypeAnomalieProjet.PlanificationIncomplete;
				else
					m_projet.TypesAnomaliesFiltres &= ~ETypeAnomalieProjet.PlanificationIncomplete;
				//m_projet.CommitEdit();
			}
		}

		private void m_chkContraintes_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				//m_projet.BeginEdit();
				if (m_chkContraintes.Checked)
					m_projet.TypesAnomaliesFiltres |= ETypeAnomalieProjet.NonRespectContrainteDate;
				else
					m_projet.TypesAnomaliesFiltres &= ~ETypeAnomalieProjet.NonRespectContrainteDate;
				//m_projet.CommitEdit();
			}
		}

		private void m_chkBoucles_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				//m_projet.BeginEdit();
				if (m_chkBoucles.Checked)
					m_projet.TypesAnomaliesFiltres |= ETypeAnomalieProjet.Boucle;
				else
					m_projet.TypesAnomaliesFiltres &= ~ETypeAnomalieProjet.Boucle;
				//m_projet.CommitEdit();
			}
		}

		private void m_chkInclurePrjsFils_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				//m_projet.BeginEdit();
				m_projet.InclureAnomaliesProjetsFils = m_chkInclurePrjsFils.Checked;
				//m_projet.CommitEdit();
			}
		}


	}
}
