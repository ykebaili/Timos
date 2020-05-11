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

namespace timos
{
	public partial class CControleEditionOptionsControleCoordonnees : UserControl, IControlALockEdition
	{

		private IObjetAOptionsDeControleDeCoordonnees m_objetEdite = null;

		private EOptionControleCoordonnees? m_lastOptionAffichee = null;
		

		//------------------------------------------------------------------
		public CControleEditionOptionsControleCoordonnees()
		{
			InitializeComponent();
		}

		//------------------------------------------------------------------
		public CResultAErreur Init(IObjetAOptionsDeControleDeCoordonnees objet)
		{
			CResultAErreur  result = CResultAErreur.True;
			if (objet == null)
			{
				Visible = false;
				return result;
			}
			m_objetEdite = objet;

			if (objet.CanHeriteOptionsControleCoordonnees)
				m_radioHerite.Text = I.T( "Inherit control options|515");
			else
				m_radioHerite.Text = I.T( "No control options|523");
			m_panelHeritage.Visible = true;

			EOptionControleCoordonnees? option = objet.OptionsControleCoordonneesPropre;
			m_radioHerite.Checked = option == null;
			m_radioPropre.Checked = option != null;

			option = objet.OptionsControleCoordonneesApplique;

			InitOptionsDisponibles(objet.OptionsDisponibles);

			result = Init(option);

			return result;
		}


		private void InitOptionsDisponibles(EOptionControleCoordonnees? ops)
		{
			m_chkIgnorerDispo.Visible = false;
			m_chkIgnorerOccupation.Visible = false;
			m_chkNonObligatoire.Visible = false;
			m_chkPasDeTestUnite.Visible = false;
            m_chkIgnoreEquipements.Visible = false;
            m_chkIgnoreStocks.Visible = false;
            m_chkIgnoreSites.Visible = false;


			if (ops == null)
			{
				m_chkIgnorerDispo.Visible = true;
				m_chkIgnorerOccupation.Visible = true;
				m_chkNonObligatoire.Visible = true;
				m_chkPasDeTestUnite.Visible = true;
                m_chkIgnoreStocks.Visible = true;
                m_chkIgnoreEquipements.Visible = true;
                m_chkIgnoreSites.Visible = true;
				return;
			}

			if ((ops & EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees) == EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees)
					m_chkNonObligatoire.Visible = true;
			if ((ops & EOptionControleCoordonnees.IgnorerLesUnites) == EOptionControleCoordonnees.IgnorerLesUnites)
				m_chkPasDeTestUnite.Visible = true;
			if ((ops & EOptionControleCoordonnees.IgnorerLoccupation) == EOptionControleCoordonnees.IgnorerLoccupation)
				m_chkIgnorerOccupation.Visible = true;
			if ((ops & EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee) == EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee)
				m_chkIgnorerDispo.Visible = true;
            if ((ops & EOptionControleCoordonnees.IgnorerLesSites) == EOptionControleCoordonnees.IgnorerLesSites)
                m_chkIgnoreSites.Visible = true;
            if ((ops & EOptionControleCoordonnees.IgnorerLesStocks) == EOptionControleCoordonnees.IgnorerLesStocks)
                m_chkIgnoreStocks.Visible = true;
            if ((ops & EOptionControleCoordonnees.IgnorerLesEquipements) == EOptionControleCoordonnees.IgnorerLesEquipements)
                m_chkIgnoreEquipements.Visible = true;
			
		}

		private bool m_bIsInitializing = false;
		private CResultAErreur Init(EOptionControleCoordonnees? option)
		{
			CResultAErreur result = CResultAErreur.True;
			if (option == null)
			{
				m_panelParametrage.Visible = false;
				m_radioHerite.Checked = true;
				m_bIsInitializing = false;
				return result;
			}
			m_lastOptionAffichee = option;

			m_panelParametrage.Visible = true;

			if (m_radioHerite.Checked)
			{
				
				m_gestionnaireModeEdition.SetModeEdition(m_panelParametrage, TypeModeEdition.Autonome);
				m_panelParametrage.LockEdition = true;
				if (!m_objetEdite.CanHeriteOptionsControleCoordonnees)
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

			if (option == null)
				m_panelParametrage.Visible = false;
			else
			{
				m_panelParametrage.Visible = true;
				m_chkNonObligatoire.Checked = (option & EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees) == EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees;
				m_chkIgnorerDispo.Checked = (option & EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee) == EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee;
				m_chkIgnorerOccupation.Checked = (option & EOptionControleCoordonnees.IgnorerLoccupation) == EOptionControleCoordonnees.IgnorerLoccupation;
				m_chkPasDeTestUnite.Checked = (option & EOptionControleCoordonnees.IgnorerLesUnites) == EOptionControleCoordonnees.IgnorerLesUnites;
                m_chkIgnoreEquipements.Checked = (option & EOptionControleCoordonnees.IgnorerLesEquipements) == EOptionControleCoordonnees.IgnorerLesEquipements;
                m_chkIgnoreSites.Checked = (option & EOptionControleCoordonnees.IgnorerLesSites) == EOptionControleCoordonnees.IgnorerLesSites;
                m_chkIgnoreStocks.Checked = (option & EOptionControleCoordonnees.IgnorerLesStocks) == EOptionControleCoordonnees.IgnorerLesStocks;
			}

			
			return result;
			
		}

		//--------------------------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_objetEdite == null )
				return result;
			if (m_radioHerite.Checked)
			{
				m_objetEdite.OptionsControleCoordonneesPropre = null;
				return result;
			}

			EOptionControleCoordonnees option = EOptionControleCoordonnees.TousControles;
			if (m_chkNonObligatoire.Checked)
				option |= EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees;
			if (m_chkPasDeTestUnite.Checked)
				option |= EOptionControleCoordonnees.IgnorerLesUnites;
			if (m_chkIgnorerOccupation.Checked)
				option |= EOptionControleCoordonnees.IgnorerLoccupation;
			if (m_chkIgnorerDispo.Checked)
				option |= EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee;
            if (m_chkIgnoreEquipements.Checked)
                option |= EOptionControleCoordonnees.IgnorerLesEquipements;
            if (m_chkIgnoreSites.Checked)
                option |= EOptionControleCoordonnees.IgnorerLesSites;
            if (m_chkIgnoreStocks.Checked)
                option |= EOptionControleCoordonnees.IgnorerLesStocks;

			m_objetEdite.OptionsControleCoordonneesPropre = option;


			return result;



		}

		//--------------------------------------------------------------------------
		private void m_radioPropre_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioPropre.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				
				EOptionControleCoordonnees option = EOptionControleCoordonnees.TousControles;
				if (m_lastOptionAffichee != null)
					option = (EOptionControleCoordonnees)m_lastOptionAffichee;
				IObjetAOptionsDeControleDeCoordonnees donnateur = m_objetEdite.DonnateurOptionsControleCoordonneesHerite;
				if (donnateur != null && donnateur.OptionsControleCoordonneesPropre != null)
					option = (EOptionControleCoordonnees)donnateur.OptionsControleCoordonneesPropre;
				Init(option);
			}
		}

		//--------------------------------------------------------------------------
		private void m_radioHerite_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioHerite.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				IObjetAOptionsDeControleDeCoordonnees donnataire = m_objetEdite.DonnateurOptionsControleCoordonneesHerite;
				if (donnataire != null && m_objetEdite.CanHeriteOptionsControleCoordonnees)
					Init(donnataire.OptionsControleCoordonneesPropre);
				else
					Init((EOptionControleCoordonnees?)null);
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


	}
}
