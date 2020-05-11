using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.workflow;

using timos.data;
using timos.securite;
using timos.acteurs;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;

namespace timos
{
	public partial class CFormDeplacerEquipement : Form
	{
		private CEquipement m_equipement = null;

		//-------------------------------------------------------------------------
		private void CFormDeplacerEquipement_Load(object sender, EventArgs e)
		{
			m_initialise = false;

			sc2i.win32.common.CWin32Traducteur.Translate(this);
			m_selectSite.Init<CSite>(
				"Libelle",
				false);
			m_selectStock.Init<CStock>(
				"Libelle",
				false);
            m_selectActeur.Init<CActeur>(
                "IdentiteComplete",
                false);

			if (m_equipement.EmplacementSite != null)
			{

				m_radioSite.Checked = true;
				m_selectSite.Focus();
			}
			else if (m_equipement.EmplacementStock != null)
			{
				m_radioStock.Checked = true;
				m_selectStock.Focus();
			}
			else
			{
				m_radioActeur.Checked = true;
				m_selectActeur.Focus();
			}

			m_selectSite.ElementSelectionne = m_equipement.EmplacementSite;
			m_selectStock.ElementSelectionne = m_equipement.EmplacementStock;
			m_selectActeur.ElementSelectionne = m_equipement.EmplacementActeur;
            if (m_equipement.EmplacementSite != null)
                m_cmbEquipement.ElementSelectionne = m_equipement.EquipementContenant;
            else
                m_cmbEquipement.ElementSelectionne = null;
            if (m_equipement.EmplacementStock != null)
                m_cmbEquipementStock.ElementSelectionne = m_equipement.EquipementContenant;
            else
                m_cmbEquipementStock.ElementSelectionne = null;           


			m_dtMouvement.Value = DateTime.Now;

			CFiltreData filtre = new CFiltreDataAvance(CActeur.c_nomTable,
				"Has(" + CDonneesActeurUtilisateur.c_nomTable + "." +
				CDonneesActeurUtilisateur.c_champId + ")");
			m_selectUser.InitAvecFiltreDeBase<CActeur>("IdentiteComplete", filtre, false);
			CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(m_equipement.ContexteDonnee);
			if (user != null)
				m_selectUser.ElementSelectionne = user.Acteur;

		    InitComboEquipementParent(m_cmbEquipement);
            InitComboEquipementParent(m_cmbEquipementStock);

			m_initialise = true;

			ActualiserCoor();

            //S'il existe un mouvement en cours d'édition, remet l'info et la coordonnée
            foreach (CMouvementEquipement mvt in m_equipement.Mouvements)
            {
                if (mvt.IsNew() && mvt.MouvementSuivant == null)
                {
                    m_txtInfo.Text = mvt.Info;
                    m_dtMouvement.Value = mvt.DateMouvement;
                }
            }


		}


		//-------------------------------------------------
        private void InitComboEquipementParent(CComboBoxArbreObjetDonneesHierarchique combo)
		{
            CSite site = null;
            CStock stock = null;
            if (combo == m_cmbEquipement)
                site = m_selectSite.ElementSelectionne as CSite;
            if (combo == m_cmbEquipementStock)
                stock = m_selectStock.ElementSelectionne as CStock;
            combo.LockEdition = true;
			if (m_equipement.TypeEquipement != null)
			{
				//Récupère les équipements du site qui peuvent contenir cet équipement
				CTypeEquipement[] equips = m_equipement.TypeEquipement.TousLesTypesIncluants;
				string strIds = "";
				foreach (CTypeEquipement type in equips)
				{
					strIds += type.Id + ",";
				}
				if (strIds != "")
				{
					strIds = strIds.Substring(0, strIds.Length - 1);
					CFiltreData filtreRacine = null;
                    if (site != null)
                        filtreRacine = new CFiltreData(
                        CSite.c_champId + "=@1", site.Id);
                    else if (stock != null)
                        filtreRacine = new CFiltreData(
                            CStock.c_champId + "=@1", stock.Id);
                    else
                        filtreRacine = new CFiltreDataImpossible();
					CFiltreData filtre = new CFiltreData (
						CTypeEquipement.c_champId + " in (" + strIds + ") ");
                    filtre = CFiltreData.GetAndFiltre(filtreRacine, filtre);
                    combo.Init(typeof(CEquipement),
                        "EquipementsContenus",
                        CEquipement.c_champIdEquipementContenant,
                        "Libelle|"+CEquipement.c_strCleFormuleGlobaleLibelleEquipement,
                        filtre,
                        filtreRacine);
					combo.LockEdition = false;
				}
			}
		}

		//-------------------------------------------------------------------------
		public CFormDeplacerEquipement()
		{
			InitializeComponent();
			m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
		}

		//-------------------------------------------------------------------------
		public static bool DeplaceEquipement(CEquipement equipement)
		{
			CFormDeplacerEquipement form = new CFormDeplacerEquipement();
			form.m_equipement = equipement;
			bool bResult = false;
			if (form.ShowDialog() == DialogResult.OK)
			{
				bResult = true;
			}
			form.Dispose();
			return bResult;
		}

		//-------------------------------------------------------------------------
		private void m_radioSite_CheckedChanged(object sender, EventArgs e)
		{
			if (m_initialise)
				ActualiserCoor();
		}

		//-------------------------------------------------------------------------
		private void m_radioStock_CheckedChanged(object sender, EventArgs e)
		{
			if (m_initialise)
				ActualiserCoor();
		}

		//-------------------------------------------------------------------------
		private void m_txtSelectSite_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectSite.ElementSelectionne != null)
			{
				m_radioSite.Checked = true;
				InitComboEquipementParent(m_cmbEquipement);
				ActualiserCoor();
			}
		}

		//-------------------------------------------------------------------------
		private void m_selectStock_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectStock.ElementSelectionne != null)
			{
				m_radioStock.Checked = true;
                InitComboEquipementParent(m_cmbEquipementStock);
				ActualiserCoor();
			}
		}



		//----------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			IEmplacementEquipement emplacement = null;
			CEquipement equipementParent = null;
			if (m_radioSite.Checked)
			{
				emplacement = (CSite)m_selectSite.ElementSelectionne;
				equipementParent = (CEquipement)m_cmbEquipement.ElementSelectionne;
			}
            if (m_radioStock.Checked)
            {
                emplacement = (CStock)m_selectStock.ElementSelectionne;
                equipementParent = (CEquipement)m_cmbEquipementStock.ElementSelectionne;
            }
			if (m_radioActeur.Checked)
				emplacement = (CActeur)m_selectActeur.ElementSelectionne;

			CActeur acteur = (CActeur)m_selectUser.ElementSelectionne;

            //S'il existe un mouvement en édition, modifie ce mouvement
            CMouvementEquipement mouvement = null;
            foreach (CMouvementEquipement mouvext in m_equipement.Mouvements)
            {
                if (mouvext.IsNew() && mouvext.EmplacementDestination.Equals(emplacement))
                {
                    mouvement = mouvext;
                    break;
                }
            }
            if (mouvement != null)
            {
                mouvement.Info = m_txtInfo.Text;
                mouvement.DateMouvement = m_dtMouvement.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
                
                


			CResultAErreur result = m_equipement.DeplaceEquipementOptionPassage(
				m_txtInfo.Text,
				emplacement,
				equipementParent,
				m_panelCoordonnee.Visible?m_editCoordonnee.Coordonnee:null,
				null,
				acteur == null?null:acteur.Utilisateur,
				m_dtMouvement.Value,
                "",
                false,
                false);
			
			if (result.Result)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				if (!result)
					CFormAlerte.Afficher(result.Erreur);
			}
		}

		private void m_selectActeur_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectActeur.ElementSelectionne != null)
			{
				m_radioActeur.Checked = true;
				ActualiserCoor();
			}
		}

		private void m_cmbEquipement_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if(m_initialise)
				ActualiserCoor();
		}


		private bool m_initialise = false;
		private void ActualiserCoor()
		{
			object parent = null;
			if (m_radioActeur.Checked)
				parent = m_selectActeur.ElementSelectionne;
			if (m_radioSite.Checked)
			{
				parent = m_selectSite.ElementSelectionne;
				if (m_cmbEquipement.ElementSelectionne is CEquipement)
					parent = (CEquipement)m_cmbEquipement.ElementSelectionne;
			}
            if (m_radioStock.Checked)
            {
                parent = m_selectStock.ElementSelectionne;
                if (m_cmbEquipementStock.ElementSelectionne is CEquipement)
                    parent = (CEquipement)m_cmbEquipementStock.ElementSelectionne;
            }
			if (parent is IObjetAFilsACoordonnees && ((IObjetAFilsACoordonnees)parent).ParametrageCoordonneesApplique != null )
			{
				m_panelCoordonnee.Visible = true;
				m_editCoordonnee.Init((IObjetAFilsACoordonnees)parent, m_equipement);
				m_editCoordonnee.Coordonnee = m_equipement.Coordonnee;
			}
			else
				m_panelCoordonnee.Visible = false;


			/*if (m_initialise)
			{
				m_panCoor.Visible = true;
				if (m_radioActeur.Checked)
						m_panCoor.Visible = false;
				else if (m_radioSite.Checked)
				{
					if (m_cmbEquipement.ElementSelectionne != null)
						InitialiserCtrlCoor((IObjetAvecFilsAvecCoordonnees)m_cmbEquipement.ElementSelectionne);
					else if (m_selectSite.SelectedObject != null)
						InitialiserCtrlCoor((IObjetAvecFilsAvecCoordonnees)m_selectSite.SelectedObject);
					else
						m_panCoor.Visible = false;

				}
				else if (m_radioStock.Checked)
				{
					if (m_selectStock.SelectedObject != null)
						InitialiserCtrlCoor((IObjetAvecFilsAvecCoordonnees)m_selectStock.SelectedObject);
					else
						m_panCoor.Visible = false;
				}
				else
					m_panCoor.Visible = false;
			}

			if (m_panCoor.Visible)
				Height = 405;
			else
				Height = 280;*/
		}

        private void m_cmbEquipementStock_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_initialise)
                ActualiserCoor();

        }
	

	}
}