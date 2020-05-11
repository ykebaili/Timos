using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data;

using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.drawing;

namespace timos
{
	public partial class CPanEditWndProjetBrique : UserControl, IControlALockEdition, IEditeurWndElementDeProjet
	{
		private CProjet m_projet = null;
		public event EventHandler ProprieteModifiee;

		private bool m_bInitialise = false;

		//------------------------------------------------
		public CPanEditWndProjetBrique()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public bool HasElementValide
		{
			get
			{
				return m_projet != null && m_projet.IsValide();
			}
		}

		//------------------------------------------------
		public void Init(I2iObjetGraphique wndObjet)
		{
			if (!(wndObjet is CWndProjetBrique))
			{
				m_projet = null;
				return;
			}
			m_bInitialise = false;
			m_projet = ((CWndProjetBrique)wndObjet).Projet;
			m_ctrlState.Init(m_projet);


			RemplitDialog();
		}

		private void RemplitDialog()
		{
			CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeProjet));
			m_selectTypeProjet.Init(typeof(CFormListeTypeProjet), "Libelle", filtre, true);
			m_selectTypeProjet.ElementSelectionne = Projet.TypeProjet;
			m_selectTypeProjet.LockEdition = true;

			m_extLinkField.FillDialogFromObjet(Projet);


			if (Projet.DateDebutPlanifiee != null)
				m_dtpDateDebut.Value = new CDateTimeEx((DateTime)Projet.DateDebutPlanifiee);
			else
				m_dtpDateDebut.Value = null;

			if (Projet.DateFinPlanifiee != null)
				m_dtpDateFin.Value = new CDateTimeEx((DateTime)Projet.DateFinPlanifiee);
			else
				m_dtpDateFin.Value = null;

			MAJAnomalies();
			m_bInitialise = true;
		}
		

		private void MAJAnomalies()
		{
			m_ctrlAnomalies.Init(m_projet);
			m_panAno.Visible = m_ctrlAnomalies.HasAnomalies;
		}

		public CProjet Projet
		{
			get
			{
				return m_projet;
			}
		}

		public CResultAErreur MAJChamps()
		{
			if (!LockEdition)
			{
				m_projet.DateDebutPlanifiee = m_dtpDateDebut.Value != null ? (DateTime?)m_dtpDateDebut.Value.DateTimeValue : null;
				m_projet.DateFinPlanifiee = m_dtpDateFin.Value != null ? (DateTime?)m_dtpDateFin.Value.DateTimeValue : null;


				return m_extLinkField.FillObjetFromDialog(m_projet);
			}
			return CResultAErreur.True;
		}

		private void m_selectTypeProjet_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectTypeProjet.ElementSelectionne != null)
				Projet.TypeProjet = (CTypeProjet)m_selectTypeProjet.ElementSelectionne;
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
				OnClickProprietes(m_projet, null);
			RemplitDialog();
		}

		private void m_dtpDateDebut_OnValueChange(object sender, EventArgs e)
		{

			if (m_bInitialise)
			{
				if (m_projet.DateDebutPlanifiee == null && m_dtpDateDebut.Value != null)
				{
					m_bInitialise = false;
					m_dtpDateDebut.Value = new CDateTimeEx(DateTime.Now);
					m_bInitialise = true;
				}

				m_projet.DateDebutPlanifiee = m_dtpDateDebut.Value != null ? (DateTime?)m_dtpDateDebut.Value.DateTimeValue : null;
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
				MAJAnomalies();
			}
		}

		private void m_dtpDateFin_OnValueChange(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				if (m_projet.DateFinPlanifiee == null && m_dtpDateFin.Value != null)
				{
					m_bInitialise = false;
					m_dtpDateFin.Value = new CDateTimeEx(DateTime.Now.AddDays(1));
					m_bInitialise = true;
				}

				m_projet.DateFinPlanifiee = m_dtpDateFin.Value != null ? (DateTime?)m_dtpDateFin.Value.DateTimeValue : null;
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
				MAJAnomalies();
			}
		}
	}
}
