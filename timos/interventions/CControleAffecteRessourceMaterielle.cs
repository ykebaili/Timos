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
using sc2i.win32.common;
using timos.win32.composants;

namespace timos.interventions
{
	public partial class CControleAffecteRessourceMaterielle : UserControl, IControlALockEdition
	{
		private CContrainte m_contrainte = null;
		private CRessourceMaterielle m_ressourceMaterielle = null;
		private CIntervention m_tache = null;

		//---------------------------------------------------
		public CControleAffecteRessourceMaterielle()
		{
			InitializeComponent();
			m_txtSelectRessourceMaterielle.Init<CRessourceMaterielle>("Libelle", false);
		}

		//-------------------------------------------------------------------------------------
		public CResultAErreur Init(
			CContrainte contrainte, 
			CRessourceMaterielle ressourceMaterielle,
			CIntervention tache)
		{
			CResultAErreur result = CResultAErreur.True;
			m_contrainte = contrainte;
			m_ressourceMaterielle = ressourceMaterielle;
			m_tache = tache;
			m_lblContrainte.Text = contrainte.Libelle;
			m_txtSelectRessourceMaterielle.ElementSelectionne = m_ressourceMaterielle;
			return result;
		}

		//-------------------------------------------------------------------------------------
		public CContrainte Contrainte
		{
			get
			{
				return m_contrainte;
			}
		}

		//-------------------------------------------------------------------------------------
		public CRessourceMaterielle RessourceMaterielle
		{
			get
			{
				return m_ressourceMaterielle;
			}
		}

		//-------------------------------------------------------------------------------------
		private void m_lnkAffectationRapide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormChercheRessource.FindRessource(m_tache, m_contrainte, new SetRessourceEventHandler(OnSelectRessource));
		}

		//-------------------------------------------------------------------------------------
		private void OnSelectRessource(object sender, CRessourceMaterielle ressource)
		{
			if (ressource != null)
				m_txtSelectRessourceMaterielle.ElementSelectionne = ressource;
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

		//-------------------------------------------------------------------------------------
		private void m_txtSelectRessourceMaterielle_ElementSelectionneChanged(object sender, EventArgs e)
		{
			m_tache.AssocieRessourceMatérielle(m_contrainte, (CRessourceMaterielle)m_txtSelectRessourceMaterielle.ElementSelectionne);
		}

        private void CControleAffecteRessourceMaterielle_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }
	}
}
