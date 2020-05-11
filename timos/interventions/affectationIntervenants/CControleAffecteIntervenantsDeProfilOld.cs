using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data;
using sc2i.common;
using sc2i.data;
using timos.acteurs;
using sc2i.win32.common;
using timos.win32.composants;

namespace timos.interventions
{
	public partial class CControleAffecteIntervenantsDeProfilOld : UserControl, IControlALockEdition
	{
		private CTypeIntervention_ProfilIntervenant m_profil = null;
		private CActeur m_intervenant = null;
		private CIntervention m_intervention = null;

		public CControleAffecteIntervenantsDeProfilOld()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------------------
		public CResultAErreur Init(
			CIntervention intervention, 
			CTypeIntervention_ProfilIntervenant profil,
			CActeur acteur)
		{
			CResultAErreur result = CResultAErreur.True;
			m_profil = profil;
			m_intervention = intervention;
			m_intervenant = acteur;
			m_lblProfil.Text = profil.Libelle;

            // Init la la TextBoxSelectionne avec le filtre par défaut des Intervenants et un filtre rapide
            CFiltreData filtre = null;
            if (m_intervention != null && m_intervention.TypeIntervention != null && m_intervention.TypeIntervention.FiltreDynamiqueIntervenants != null)
            {
                result = m_intervention.TypeIntervention.FiltreDynamiqueIntervenants.GetFiltreData();
                if(result)
                {
                    filtre = result.Data as CFiltreData;
                }
            }
            m_txtSelectIntervenant.InitAvecFiltreDeBase<CActeur>("IdentiteComplete", filtre, true);

			m_txtSelectIntervenant.ElementSelectionne = m_intervenant;
			
            return result;
		}

		//-------------------------------------------------------------------------------------
		public CTypeIntervention_ProfilIntervenant Profil
		{
			get
			{
				return m_profil;
			}
		}

		//-------------------------------------------------------------------------------------
		public CActeur Intervenant
		{
			get
			{
				return m_intervenant;
			}
		}

		//-------------------------------------------------------------------------------------
		private void m_lnkAffectationRapide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormChercheIntervenant.FindIntervenant(
				m_intervention,
				m_profil,
				new SetIntervenantEventHandler(OnSelectIntervenant));
		}

		//-------------------------------------------------------------------------------------
		private void OnSelectIntervenant(object sender, CActeur acteur)
		{
			m_txtSelectIntervenant.ElementSelectionne = acteur;
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

		private void m_txtSelectIntervenant_Load(object sender, EventArgs e)
		{

		}

		//-------------------------------------------------------------------------------------
		private void m_txtSelectIntervenant_ElementSelectionneChanged(object sender, EventArgs e)
		{
			m_intervention.AssocieActeur(m_profil, (CActeur)m_txtSelectIntervenant.ElementSelectionne);
		}

        //-------------------------------------------------------------------------------
        private void CControleAffecteIntervenant_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }
	}
}
