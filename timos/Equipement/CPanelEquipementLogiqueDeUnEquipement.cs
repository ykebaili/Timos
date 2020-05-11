using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using timos.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;

namespace timos.Equipement
{
	public partial class CPanelEquipementLogiqueDeUnEquipement : UserControl, IControlALockEdition
	{
		private CEquipement m_equipement;
		private CEquipementLogique m_equipementLogique = null;

		public CPanelEquipementLogiqueDeUnEquipement()
		{
			InitializeComponent();
		}

		private void CPanelEquipementLogiqueDeUnEquipement_Load(object sender, EventArgs e)
		{

		}

		private CEquipementLogique EquipementLogique
		{
			get
			{
				if (m_equipementLogique != null)
				{
					if (m_equipementLogique.IsValide())
						return m_equipementLogique;
				}
				return null;
			}
		}

		private CEquipement Equipement
		{
			get
			{
				if (m_equipement != null && m_equipement.IsValide())
					return m_equipement;
				return null;
			}
		}
		//-----------------------------------------------------
		public CResultAErreur InitChamps(CEquipement equipement)
		{
			CResultAErreur result = CResultAErreur.True;
			if (equipement == null)
				return result;
			m_equipement = equipement;
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				if (m_equipement.IsNew() && m_equipement.TypeEquipement != null &&
					m_equipement.TypeEquipement.CreationAutomatiqueEquipementLogique &&
					m_equipement.TypeEquipement != null)
				{
					//m_equipement.CreateEquipementLogiqueAutomatiqueInContexte();
				}
			}
			m_equipementLogique = m_equipement.EquipementLogique;
			if (EquipementLogique == null)
			{
				m_panelDonnees.Visible = false;
			}
			else
			{
				m_panelDonnees.Visible = true;
				m_extLinkField.FillDialogFromObjet(EquipementLogique);
				m_selectTypeEquipement.Init<CTypeEquipement>(
						"Libelle",
                        false);
				m_selectTypeEquipement.ElementSelectionne = EquipementLogique.TypeEquipement;
				m_panelFormulaire.ElementEdite = EquipementLogique;
			}
			m_lnkCreateNewLogique.Visible = EquipementLogique == null;

			return CResultAErreur.True;
		}

		//-----------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (EquipementLogique != null && !LockEdition && Equipement != null)
			{
				result = m_extLinkField.FillObjetFromDialog(EquipementLogique);
				EquipementLogique.TypeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
				result += m_panelFormulaire.MAJ_Champs();
				if (EquipementLogique.Site == null && Equipement.EmplacementSite != null)
					EquipementLogique.Site = Equipement.EmplacementSite;
			}
			return result;
		}

		//-----------------------------------------------------
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
		void m_lnkLinkToLogique_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (Equipement == null)
				return;

			if (Equipement.EmplacementSite == null)
			{
				CFormAlerte.Afficher(I.T("Equipment should be in a site|20081"));
				return;
			}

			CEquipementLogique eqptLogique = CFormSelectUnObjetDonnee.SelectionRechercheRapide(
                I.T("Select logical equipment to link|20733"),
				typeof(CEquipementLogique),
				new CFiltreData(CSite.c_champId + "=@1", Equipement.EmplacementSite.Id),
				"",
				"Libelle", "") as CEquipementLogique;
			if (eqptLogique != null)
			{
				Equipement.EquipementLogique = eqptLogique;
				InitChamps(Equipement);
			}
			m_lnkCreateNewLogique.Visible = EquipementLogique == null;
		}

		void m_lnkCreateNewLogique_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (EquipementLogique != null || Equipement == null)
				return;
			Equipement.CreateEquipementLogiqueAutomatiqueInContexte();
			InitChamps(Equipement);
		}

		private void m_lnkDetailLogique_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (EquipementLogique != null)
				CTimosApp.Navigateur.AffichePage(new CFormEditionEquipementLogique(EquipementLogique));
		}

		private void m_lnkUnlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Equipement != null)
			{
				Equipement.EquipementLogique = null;
				InitChamps(Equipement);
			}
		}



		public void OnChangeTypeEquipementPhysique(CEquipement equipement)
		{
			if (equipement != null && equipement.Equals(Equipement))
			{
				if (EquipementLogique != null && EquipementLogique.IsNew())
				{
					m_selectTypeEquipement.ElementSelectionne = equipement.TypeEquipement;
				}
			}
		}
	}
}
