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

namespace timos.Equipement
{
	public partial class CPanelEquipementsDeEquipementLogique : UserControl, IControlALockEdition
	{
		private CEquipementLogique m_equipementLogique;
		private CEquipement m_equipement;

		public CPanelEquipementsDeEquipementLogique()
		{
			InitializeComponent();
		}

		//--------------------------------------------------
		public bool LockEdition
		{
			get
			{
				return !m_extModeEdition.ModeEdition;
			}
			set
			{
				m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
			}
		}
		public event EventHandler OnChangeLockEdition;

		private CEquipement Equipement
		{
			get
			{
				if (m_equipement != null && m_equipement.IsValide())
					return m_equipement;
				return null;
			}
		}

		private CEquipementLogique EquipementLogique
		{
			get
			{
				if (m_equipementLogique != null && m_equipementLogique.IsValide())
					return m_equipementLogique;
				return null;
			}
		}

		//--------------------------------------------------
		public CResultAErreur InitChamps(CEquipementLogique eqptLogique)
		{
			CResultAErreur result = CResultAErreur.True;
			m_equipementLogique = eqptLogique;
			CListeObjetsDonnees lstEquipements = eqptLogique.Equipements;
			if (lstEquipements.Count == 1)
				m_equipement = lstEquipements[0] as CEquipement;
			else
				m_equipement = null;

			
			m_panelMonoEquipement.Visible = Equipement != null;
			m_panelMonoEquipement.Dock = Equipement != null?DockStyle.Fill:DockStyle.None;
			m_panelListeEquipements.Visible = lstEquipements.Count > 1;
			m_panelListeEquipements.Dock = lstEquipements.Count > 1?DockStyle.Fill:DockStyle.None;
			m_lnkCreateNewEquipement.Visible = lstEquipements.Count == 0;
			

			if (Equipement != null)
			{
				result = m_extLinkField.FillDialogFromObjet(Equipement);
				if ( !result )
					return result;
				m_selectTypeEquipement.Init<CTypeEquipement>(
					"Libelle",
					false);
				m_selectTypeEquipement.ElementSelectionne = Equipement.TypeEquipement;
				m_panelFormulaire.ElementEdite = Equipement;
				m_cmbStatut.Init(typeof(CStatutEquipement), "Libelle", false);
				m_cmbStatut.ElementSelectionne = Equipement.Statut;
				m_panelOccupation.Init(Equipement);
				m_controleCoordonnee.Init(Equipement.ConteneurFilsACoordonnees, Equipement);
			}
			else
			{
				if (lstEquipements.Count > 1)
				{
					m_panelListeEquipements.InitFromListeObjets(
						EquipementLogique.Equipements,
						typeof(CEquipement),
						EquipementLogique,
						"EquipementLogique");
				}
			}
			return result;
		}

		//--------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (Equipement == null)
				return result;
			else
			{
				result = m_extLinkField.FillObjetFromDialog(Equipement);
				if (!result)
					return result;
				Equipement.TypeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
				result = m_panelFormulaire.MAJ_Champs();
				Equipement.Statut = m_cmbStatut.ElementSelectionne as CStatutEquipement;
				if (!result)
					return result;
				result = m_panelOccupation.MajChamps();
				if (!result)
					return result;
				Equipement.Coordonnee = m_controleCoordonnee.Coordonnee;
				
			}
			return result;
		}

		private void m_lnkDetailEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if ( Equipement != null )
				CTimosApp.Navigateur.AffichePage(new CFormEditionEquipement(Equipement));
		}

		//-----------------------------------------------------------------------
		private void m_lnkLinkToEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (EquipementLogique == null)
				return;
			if (EquipementLogique.Site == null)
			{
				CFormAlerte.Afficher(I.T("Select a site first|20080"));
				return;
			}

			CEquipement equipement = sc2i.win32.data.dynamic.CFormSelectUnObjetDonnee.SelectionRechercheRapide(
                I.T("Select equipement to link|20740"),
				typeof(CEquipement),
				new CFiltreData(CSite.c_champId + "=@1", EquipementLogique.Site.Id),
				"",
				"Libelle", "") as CEquipement;
			if (equipement != null)
			{
				equipement = EquipementLogique.ContexteDonnee.GetObjetInThisContexte(equipement) as CEquipement;
				equipement.EquipementLogique = EquipementLogique;
				InitChamps(EquipementLogique);
			}
			m_lnkCreateNewEquipement.Visible = EquipementLogique == null;
			InitChamps(EquipementLogique);
		}

		//-------------------------------------------------------
		private void m_lnkCreateNewEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if ( EquipementLogique == null )
				return;
			if (EquipementLogique.Equipements.Count != 0)
				return;
			if (Equipement != null | EquipementLogique == null)
				return;
			CEquipement equipement = new CEquipement(EquipementLogique.ContexteDonnee);
            equipement.CreateNewInCurrentContexte();
			equipement.EquipementLogique = EquipementLogique;
			InitChamps(EquipementLogique);

		}

		private void m_lnkSupprimerLien_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Equipement != null)
			{
				Equipement.EquipementLogique = null;
				InitChamps(EquipementLogique);
			}
		}

		//-------------------------------------------------------
		public void OnChangeTypeEquipementLogique(CEquipementLogique equipementLogique)
		{
			if (equipementLogique != null && equipementLogique.Equals(EquipementLogique))
			{
				if (Equipement != null && Equipement.IsNew())
				{
					m_selectTypeEquipement.ElementSelectionne = equipementLogique.TypeEquipement;
				}
			}
		}
	}
}
