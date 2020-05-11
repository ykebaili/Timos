using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.win32.common;
using timos.data;
using sc2i.data;

namespace timos.coordonnees
{
	public partial class CControlEditionObjetAOccupation : UserControl, IControlALockEdition
	{
		private IObjetAOccupation m_objetEdite = null;
		private COccupationCoordonnees m_occupationAffiche = null;
		private COccupationCoordonnees m_occupationPropre = null;

		public CControlEditionObjetAOccupation()
		{
			InitializeComponent();
		}

		public CResultAErreur Init(IObjetAOccupation objet)
		{
			CResultAErreur  result = CResultAErreur.True;
			if (objet == null)
			{
				Visible = false;
				return result;
			}
			m_objetEdite = objet;
			m_panelHeritage.Visible = true;
			if (!objet.CanHeriteOccupationCoordonnees)
				m_radioHerite.Text = I.T( "No occupation|522");
			else
				m_radioHerite.Text = I.T( "Inherits occupation|527");

			m_cmbUnite.Init(
				typeof(CUniteCoordonnee),
				"Libelle",
				true);

			m_occupationPropre = objet.OccupationCoordonneesPropre;
			m_bIsInitializing = true;
			m_radioHerite.Checked = m_occupationPropre == null;
			m_radioPropre.Checked = m_occupationPropre != null;
			m_bIsInitializing = false;
			/*if (!objet.CanHeriteOccupationCoordonnees &&
				objet.OccupationCoordonneesPropre == null)
				m_radioPropre.Checked = true;*/

			COccupationCoordonnees occupation = objet.OccupationCoordonneeAppliquee;
			result = Init(occupation);

			return result;
		}

		private bool m_bIsInitializing = false;
		private CResultAErreur Init(COccupationCoordonnees occupation)
		{
			m_bIsInitializing = true;
			CResultAErreur result = CResultAErreur.True;
			m_occupationAffiche = occupation;
			if (occupation == null)
			{
				m_panelParametrage.Visible = false;
				m_radioHerite.Checked = true;
				m_bIsInitializing = false;
				return result;
			}

			m_panelParametrage.Visible = true;

			if (m_radioHerite.Checked)
			{
				m_gestionnaireModeEdition.SetModeEdition(m_panelParametrage, TypeModeEdition.Autonome);
				m_panelParametrage.LockEdition = true;
				if (!m_objetEdite.CanHeriteOccupationCoordonnees)
				{
					m_panelParametrage.Visible = false;
					m_bIsInitializing = false;
					return result;
				}
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition(m_panelParametrage, TypeModeEdition.EnableSurEdition);
				m_panelParametrage.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}


			m_cmbUnite.ElementSelectionne = occupation.Unite;
			m_txtNbUnites.IntValue = occupation.NbUnitesOccupees;

			m_bIsInitializing = false;

			return result;
			
		}

		//--------------------------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_objetEdite == null )
				return result;
			if (m_radioHerite.Checked && !((CObjetDonnee)m_objetEdite).IsNew())
			{
				if (m_objetEdite.OccupationCoordonneesPropre != null)
					m_objetEdite.OccupationCoordonneesPropre = null;
				return result;
			}

            m_occupationPropre = new COccupationCoordonnees();

			m_occupationPropre.Unite = (CUniteCoordonnee)m_cmbUnite.ElementSelectionne;
			if (m_txtNbUnites.IntValue == null)
			{
                m_txtNbUnites.IntValue = 1;
				/*result.EmpileErreur(I.T( "Occupation should be defined|519"));
				return result;*/
			}
			m_occupationPropre.NbUnitesOccupees = (int)m_txtNbUnites.IntValue;

			m_objetEdite.OccupationCoordonneesPropre = m_occupationPropre;

			return result;



		}

		//--------------------------------------------------------------------------
		private void m_radioPropre_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioPropre.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				m_occupationPropre = m_objetEdite.OccupationCoordonneesPropre;
				if (m_occupationPropre == null)
				{
					IObjetAOccupation donnateur = m_objetEdite.DonnateurOccupationCoordonneeHerite;
					if (donnateur != null)
						m_occupationPropre = donnateur.OccupationCoordonneesPropre;
					if ( m_occupationPropre == null )
						m_occupationPropre = new COccupationCoordonnees(0, null);
				}
				Init(m_occupationPropre);
				if (OnChangeOccupation != null)
					OnChangeOccupation(this, new EventArgs());
			}
		}

		//--------------------------------------------------------------------------
		private void m_radioHerite_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioHerite.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				IObjetAOccupation donnataire = m_objetEdite.DonnateurOccupationCoordonneeHerite;
				if (donnataire != null && m_objetEdite.CanHeriteOccupationCoordonnees)
					Init(donnataire.OccupationCoordonneesPropre);
				else
					Init((COccupationCoordonnees)null);
				if (OnChangeOccupation != null)
					OnChangeOccupation(this, new EventArgs());
			}
		}

		//--------------------------------------------------------------------------


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

		public event EventHandler OnChangeOccupation;
		//--------------------------------------------------------------------------
		private void m_cmbUnite_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if ( !m_bIsInitializing )
				if (OnChangeOccupation != null)
					OnChangeOccupation(this, new EventArgs());
		}

		private void m_txtNbUnites_TextChanged(object sender, EventArgs e)
		{
			if ( !m_bIsInitializing )
				if (OnChangeOccupation != null)
					OnChangeOccupation(this, new EventArgs());
		}

	}
}
