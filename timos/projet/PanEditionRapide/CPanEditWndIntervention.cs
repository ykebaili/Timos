using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.data.dynamic;
using sc2i.drawing;

using timos.data;

namespace timos
{
	public partial class CPanEditWndIntervention : UserControl, IControlALockEdition, IEditeurWndElementDeProjet
	{
		private CIntervention m_intervention = null;
		public event EventHandler ProprieteModifiee;

		private bool m_bInitialise = false;

		//------------------------------------------------
		public CPanEditWndIntervention()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public bool HasElementValide
		{
			get
			{
				return m_intervention != null && m_intervention.IsValide();
			}
		}

		//------------------------------------------------
		public void Init(I2iObjetGraphique elementAEditer)
		{
			if (!(elementAEditer is CWndIntervention))
			{
				m_intervention = null;
				return;
			}
			m_bInitialise = false;
			
			m_intervention = ((CWndIntervention)elementAEditer).Intervention;
			m_ctrlState.Init(m_intervention);
			RemplitDialog();
		}

		//---------------------------------------------------
		private void RemplitDialog()
		{
			CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeIntervention));
			m_selectTypeInter.Init(typeof(CFormListeTypeIntervention), "Libelle", filtre, true);
			m_selectTypeInter.ElementSelectionne = m_intervention.TypeIntervention;
			m_selectTypeInter.LockEdition = true;
			
			m_extLinkField.FillDialogFromObjet(Intervention);


			if (Intervention.DateDebutPrePlanifiee != null)
				m_dtpDateDebutPre.Value = new CDateTimeEx((DateTime)Intervention.DateDebutPrePlanifiee);
			else
				m_dtpDateDebutPre.Value = null;

			if (Intervention.DateFinPrePlanifiee != null)
				m_dtpDateFinPre.Value = new CDateTimeEx((DateTime)Intervention.DateFinPrePlanifiee);
			else
				m_dtpDateFinPre.Value = null;


			m_lblDateStart.Text = Intervention.DateDebutPlanifiee != null ? Intervention.DateDebutPlanifiee.Value.ToShortDateString() : I.T("None|148");
			m_lblDateEnd.Text = Intervention.DateDebutPlanifiee != null ? Intervention.DateFinPlanifiee.Value.ToShortDateString() : I.T("None|148");


			//m_dtpDateDebutPre.Format = DateTimePickerFormat.Short;
			//m_dtpDateFinPre.Format = DateTimePickerFormat.Short;
			MAJAnomalies();
			m_bInitialise = true;

		}


		private void MAJAnomalies()
		{
			m_ctrlAnomalies.Init(m_intervention);
			m_panAno.Visible = m_ctrlAnomalies.HasAnomalies;
		}
	
		
		private CIntervention Intervention
		{
			get
			{
				return m_intervention;
			}
		}

		public CResultAErreur MAJChamps()
		{
			if (!LockEdition && m_intervention != null)
			{
				m_intervention.DateDebutPrePlanifiee = m_dtpDateDebutPre.Value != null ? (DateTime?)m_dtpDateDebutPre.Value.DateTimeValue : null;
				m_intervention.DateFinPrePlanifiee = m_dtpDateFinPre.Value != null ? (DateTime?)m_dtpDateFinPre.Value.DateTimeValue : null;

				return m_extLinkField.FillObjetFromDialog(m_intervention);
			}
			else
				return CResultAErreur.True;
		}

		#region IControlALockEdition Membres

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
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		public event EventHandler OnClickProprietes;

		private void m_btnProprietes_Click(object sender, EventArgs e)
		{
			if (OnClickProprietes != null)
				OnClickProprietes(m_intervention, null);
			RemplitDialog();
		}

		private void m_dtpDateDebut_OnValueChange(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				if (m_intervention.DateDebutPrePlanifiee == null && m_dtpDateDebutPre.Value != null)
				{
					m_bInitialise = false;
					m_dtpDateDebutPre.Value = new CDateTimeEx(DateTime.Now);
					m_bInitialise = true;
				}

				m_intervention.DateDebutPrePlanifiee = m_dtpDateDebutPre.Value != null ? (DateTime?)m_dtpDateDebutPre.Value.DateTimeValue : null;
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
				MAJAnomalies();
			}
		}

		private void m_dtpDateFin_OnValueChange(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				if (m_intervention.DateFinPrePlanifiee == null && m_dtpDateFinPre.Value != null)
				{
					m_bInitialise = false;
					m_dtpDateFinPre.Value = new CDateTimeEx(DateTime.Now.AddDays(1));
					m_bInitialise = true;
				}

				m_intervention.DateFinPrePlanifiee = m_dtpDateFinPre.Value != null ? (DateTime?)m_dtpDateFinPre.Value.DateTimeValue : null;
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
				MAJAnomalies();
			}
		}

	}
}
