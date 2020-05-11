using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.common;

using timos.data;
using timos.securite;
using timos.acteurs;
using timos.coordonnees;

namespace timos
{
	public partial class CFormRemplacerEquipement : System.Windows.Forms.Form
	{
		private COperation m_operation;

		//-------------------------------------------------------------------------
		private void CFormRemplacerEquipement_Load(object sender, EventArgs e)
        {
			m_initialise = false;

			m_dtRemplacement.Value = DateTime.Now;

			CWin32Traducteur.Translate(this);

			m_selectSite.Init<CSite>(
				"Libelle",false);
			m_selectStock.Init<CStock>(
				"Libelle",false);
			m_selectActeur.Init<CActeur>(
				"IdentiteComplete",
				false);

            InitSelectTypeEquipementRemplace();
            InitSelectEquipementRemplace();
            InitSelectEquipementRemplacant();
            InitProfilPreFiltreEquipementRemplacant();

            m_ctrlFindCoordonnee.Visible = false;

			m_panelSearchReplaced.Visible = true;
			m_panelSerialReplaced.Visible = false;

			CListeObjetsDonnees listeInter = m_operation.FractionIntervention.Intervention.RelationsIntervenants;
			if ( listeInter.Count > 0 )
				m_selectActeur.ElementSelectionne = ((CIntervention_Intervenant)listeInter[0]).Intervenant;
			m_radioActeur.Checked = true;

			CRemplacementEquipement remplacement = m_operation.RemplacementAssocie;
			if ( remplacement != null )
			{
                m_selectTypeEquipementRemplace.ElementSelectionne = remplacement.TypeEquipementRemplace;
                m_selectEquipementRemplace.ElementSelectionne = remplacement.EquipementRemplace;
                m_selectEquipementRemplacant.ElementSelectionne = remplacement.EquipementDeRemplacement;
				
                m_selectActeur.ElementSelectionne = remplacement.EmplacementActeur;
				m_selectStock.ElementSelectionne = remplacement.EmplacementStock;
				m_selectSite.ElementSelectionne = remplacement.EmplacementSite;
				if (remplacement.MouvementDuRemplace != null)
					m_dtRemplacement.Value = remplacement.MouvementDuRemplace.DateMouvement;
				else
					if (remplacement.Operation != null && remplacement.Operation.FractionIntervention.DateDebut != null)
						m_dtRemplacement.Value = (DateTime)remplacement.Operation.FractionIntervention.DateDebut;

				IEmplacementEquipement emplacement = remplacement.EmplacementDestination;
				m_radioActeur.Checked = emplacement is CActeur;
				m_radioSite.Checked = emplacement is CSite;
				m_radioStock.Checked = emplacement is CStock;
				m_txtInfo.Text = remplacement.Info;

				m_txtSerialNumber.Text = remplacement.NumSerieRemplace;

				LockEditionMouvement(true);

			}

			m_initialise = true;
		}



		private void LockEditionMouvement(bool bloquer)
		{
			m_dtRemplacement.LockEdition = bloquer;
			m_txtInfo.Enabled = !bloquer;
			m_selectEquipementRemplace.LockEdition = bloquer;
			m_selectTypeEquipementRemplace.LockEdition = bloquer;
			m_selectEquipementRemplacant.LockEdition = bloquer;

			m_cmbSelectProfil.LockEdition = bloquer;

			m_btnOk.Visible = !bloquer;

			m_ctrlFindCoordonnee.LockEdition = bloquer;
			m_lnkCoordonnee.Enabled = !bloquer;

			m_radioActeur.Enabled = !bloquer;
			m_radioSite.Enabled = !bloquer;
			m_radioStock.Enabled = !bloquer;

			m_selectActeur.LockEdition = bloquer;
			m_selectSite.LockEdition = bloquer;
			m_selectStock.LockEdition = bloquer;
			m_txtSerialNumber.LockEdition = bloquer;
			
		}

        //-------------------------------------------------------------------------
		private bool m_bIsInitProfils = false;
		private void InitProfilPreFiltreEquipementRemplacant()
        {
			m_bIsInitProfils = true;
            CFiltreData filtre = new CFiltreData(
                CProfilElement.c_champTypeSource + " =@1 and " +
                CProfilElement.c_champTypeElements + " =@2",
                typeof(CIntervention).ToString(),
                typeof(CEquipement).ToString());
            
            m_cmbSelectProfil.Init(
				typeof(CProfilElement),
				filtre,
                "Libelle",                
                false);
			int nId = new CTimosAppRegistre().LastIdProfilEchangeEquipement;
			m_bIsInitProfils = false;
			if (nId >= 0)
			{
				CProfilElement profil = new CProfilElement(m_operation.ContexteDonnee);
				if (profil.ReadIfExists(nId))

					m_cmbSelectProfil.ElementSelectionne = profil;
			}

        }

        //-------------------------------------------------------------------------
        private void InitSelectTypeEquipementRemplace()
        {
            CSite site = (CSite)m_operation.FractionIntervention.Intervention.ElementAIntervention;
            CListeObjetsDonnees listeEqpt = site.Equipements;
            m_selectTypeEquipementRemplace.Init<CTypeEquipement>(
                "Libelle", 
                true);
        }
        //-------------------------------------------------------------------------
        private void InitSelectEquipementRemplace()
        {
            CFiltreData filtre = new CFiltreData(CSite.c_champId + "=@1",
                m_operation.FractionIntervention.Intervention.ElementAIntervention.Id);

            CTypeEquipement tpEqpt = null;
            if (m_operation.RemplacementAssocie != null)
                tpEqpt = m_operation.RemplacementAssocie.TypeEquipementRemplace;
            if (tpEqpt == null)
                tpEqpt = (CTypeEquipement) m_selectTypeEquipementRemplace.ElementSelectionne;

            if (tpEqpt != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreData(CTypeEquipement.c_champId + "=@1",
                    tpEqpt.Id));
            }
            
            m_selectEquipementRemplace.InitAvecFiltreDeBase<CEquipement>("Libelle", filtre, true);
        }
        //-------------------------------------------------------------------------
        private void InitSelectEquipementRemplacant()
        {
            CFiltreData filtre = null;
            CTypeEquipement[] listeRemplacants = new CTypeEquipement[0];

            CTypeEquipement tpEqpt = null;
            if (m_operation.RemplacementAssocie != null)
                tpEqpt = m_operation.RemplacementAssocie.TypeEquipementRemplace;
            if (tpEqpt == null)
                tpEqpt = (CTypeEquipement)m_selectTypeEquipementRemplace.ElementSelectionne;

            if (tpEqpt != null)
            {
                listeRemplacants = tpEqpt.TousLesTypesRemplacants;
            }
            else
            {
                CEquipement equip = null;
                if (m_operation.RemplacementAssocie != null)
                    equip = m_operation.RemplacementAssocie.EquipementRemplace;
                if (equip == null)
                    equip = (CEquipement)m_selectEquipementRemplace.ElementSelectionne;

                if (equip != null)
                {
					tpEqpt = equip.TypeEquipement;
                    listeRemplacants = equip.TypeEquipement.TousLesTypesRemplacants;
                    filtre = CFiltreData.GetAndFiltre(filtre,
                        new CFiltreData(CEquipement.c_champId + " <> @1", equip.Id));
						
                }
            }

            if (listeRemplacants.Length > 0)
            {
				string strIdTypeEqpt = "";
				
                for (int i = 0; i < listeRemplacants.Length; i++)
                {
                    strIdTypeEqpt += listeRemplacants[i].Id + ",";
                }
                if (strIdTypeEqpt.Length > 0)
                {
                    strIdTypeEqpt = strIdTypeEqpt.Substring(0, strIdTypeEqpt.Length - 1);
                    filtre = CFiltreData.GetAndFiltre(filtre,
                        new CFiltreData(CTypeEquipement.c_champId + " in (" + strIdTypeEqpt + ")"));
                }
            }

            // Utilisation du profil pour pré-filtrer les équipements
            CProfilElement profil = (CProfilElement)m_cmbSelectProfil.ElementSelectionne;
            if (profil != null)
            {
                string strIdEqptInProfile = "";
                CFiltreData filtreTmp = null;
                CResultAErreur result = profil.GetIdsElementsForSource(m_operation.FractionIntervention.Intervention, null, ref filtreTmp);

                if (result && result.Data is int[])
                {
                    int[] listIdEquip = (int[])result.Data;
                    for (int i = 0; i < listIdEquip.Length; i++)
                    {
                        strIdEqptInProfile += listIdEquip[i] + ",";
                    }
                    if (strIdEqptInProfile.Length > 0)
                    {
                        strIdEqptInProfile = strIdEqptInProfile.Substring(0, strIdEqptInProfile.Length - 1);
                        filtre = CFiltreData.GetAndFiltre(
                            filtre,
                            new CFiltreData(CEquipement.c_champId + " in (" + strIdEqptInProfile + ")"));
                    }
                }
            }

			if(m_selectEquipementRemplace.ElementSelectionne != null && m_selectEquipementRemplace.ElementSelectionne is CEquipement)
				filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CEquipement.c_champId + " <> @1", ((CEquipement)m_selectEquipementRemplace.ElementSelectionne).Id));

            m_selectEquipementRemplacant.InitAvecFiltreDeBase<CEquipement>("Libelle", filtre, true);
        }

        		
		//-------------------------------------------------------------------------
		public CFormRemplacerEquipement()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public static bool RemplaceEquipement(COperation operation, bool bEnEdition)
		{
			CFormRemplacerEquipement form = new CFormRemplacerEquipement();
			if (operation == null)
			{
				CFormAlerte.Afficher(I.T("Impossible to display the replacement windows while the operation has not been created|30184"), EFormAlerteType.Erreur);
				return false;
			}
            if (operation.FractionIntervention == null)
            {
                CFormAlerte.Afficher(I.T( "It is impossible to replace an equipment without Operation|1155"), EFormAlerteType.Erreur);
                return false;
            }
			if (!(operation.FractionIntervention.Intervention.ElementAIntervention is CSite))
			{
				CFormAlerte.Afficher(I.T("Impossible to perform a replacement on an intervention not linked to the site|30185"), EFormAlerteType.Erreur);
				return false;
			}
			form.m_operation = operation;
			form.m_gestionnaireModeEdition.ModeEdition = bEnEdition;
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
				ActualiserCoor();
			}
		}

		//-------------------------------------------------------------------------
		private void m_selectStock_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectStock.ElementSelectionne != null)
			{
				m_radioStock.Checked = true;
				ActualiserCoor();
			}
		}



		//----------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
            CResultAErreur result = CResultAErreur.True;

			IEmplacementEquipement emplacement = null;
			if (m_radioSite.Checked)
				emplacement = (CSite)m_selectSite.ElementSelectionne;
			if (m_radioStock.Checked)
				emplacement = (CStock)m_selectStock.ElementSelectionne;
			if (m_radioActeur.Checked)
				emplacement = (CActeur)m_selectActeur.ElementSelectionne;

            CTypeEquipement typeEquipementRemplace = (CTypeEquipement)m_selectTypeEquipementRemplace.ElementSelectionne;
			CEquipement equipementRemplace = (CEquipement)m_selectEquipementRemplace.ElementSelectionne;
			CEquipement equipementRemplacant = (CEquipement)m_selectEquipementRemplacant.ElementSelectionne;


            CRemplacementEquipement remplacement = m_operation.RemplacementAssocie;
            bool bNewRemplacement = remplacement == null;
            if (remplacement == null)
            {
                remplacement = new CRemplacementEquipement(m_operation.ContexteDonnee);
                remplacement.CreateNewInCurrentContexte();
            }

			//Indique une gestion par dotation, donc pas d'équipement remplacé
			bool bIsDotation = equipementRemplacant != null && equipementRemplacant.IsDotationApplique;

			if (!bIsDotation)
			{
				if (typeEquipementRemplace == null && equipementRemplace == null)
				{
					CFormAlerte.Afficher(I.T("Select a replaced equipement or equipement type|30186"), EFormAlerteType.Exclamation);
					return;
				}
			}

            remplacement.TypeEquipementRemplace = typeEquipementRemplace;
            remplacement.EquipementRemplace = equipementRemplace;
			if (remplacement.EquipementRemplace != null)
				remplacement.NumSerieRemplace = remplacement.EquipementRemplace.NumSerie;
			else
			{
				if (bIsDotation)
					remplacement.NumSerieRemplace = m_txtSerialNumber.Text;
				else
					remplacement.NumSerieRemplace = equipementRemplace != null ? equipementRemplace.NumSerie : "";
			}
            remplacement.EquipementDeRemplacement = equipementRemplacant;
            remplacement.EmplacementDestination = emplacement;
            remplacement.Info = m_txtInfo.Text;
            remplacement.Operation = m_operation;

			if ( equipementRemplace != null || bIsDotation )
                result = remplacement.DoRemplacementInCurrentContexte(m_dtRemplacement.Value);

            if (result.Result)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else if (!result)
			{
				remplacement.CancelCreate();
				CFormAlerte.Afficher(result.Erreur);
			}
		}

        //-------------------------------------------------------------------------------------------
        private void m_selectActeur_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectActeur.ElementSelectionne != null)
			{
				m_radioActeur.Checked = true;
				ActualiserCoor();
			}
		}

        //-------------------------------------------------------------------------------------------
        private void m_cmbEquipement_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if(m_initialise)
				ActualiserCoor();
		}


		private bool m_initialise = false;
        //-------------------------------------------------------------------------------------------
        private void ActualiserCoor()
		{
			object parent = null;
			if (m_radioActeur.Checked)
				parent = m_selectActeur.ElementSelectionne;
			if (m_radioSite.Checked)
			{
				parent = m_selectSite.ElementSelectionne;
			}
			if (m_radioStock.Checked)
				parent = m_selectStock.ElementSelectionne;
		}

        //-------------------------------------------------------------------------------------------
        private void m_btnAnnulerCeRemplacement_Click(object sender, EventArgs e)
		{
			if (m_operation.RemplacementAssocie != null)
			{
				CRemplacementEquipement rpl = m_operation.RemplacementAssocie;
				CResultAErreur result = rpl.AnnuleRemplacement();
				if (result)
					result = rpl.Delete();
				if (!result)
					CFormAlerte.Afficher(result.Erreur);
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
            
		}

        //-------------------------------------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //-------------------------------------------------------------------------------------------
        private void m_lnkCoordonnee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_ctrlFindCoordonnee.Visible = !m_ctrlFindCoordonnee.Visible;
            if (m_ctrlFindCoordonnee.Visible)
            {
                m_ctrlFindCoordonnee.Init(m_operation.ContexteDonnee, (CSite) m_operation.FractionIntervention.Intervention.ElementAIntervention, EObjetACoordonnee.Equipement);
                string coordSiteLie = ((CSite)m_operation.FractionIntervention.Intervention.ElementAIntervention).CoordonneeComplete;
                m_ctrlFindCoordonnee.CoordonneeDeBase = coordSiteLie;
            }
        }

        //-------------------------------------------------------------------------------------------
        private void m_selectTypeEquipementRemplace_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_operation.RemplacementAssocie != null)
                m_operation.RemplacementAssocie.TypeEquipementRemplace = (CTypeEquipement)m_selectTypeEquipementRemplace.ElementSelectionne;
            InitSelectEquipementRemplace();
            InitSelectEquipementRemplacant();
        }

        //-------------------------------------------------------------------------------------------
        private void m_selectEquipementRemplace_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_operation.RemplacementAssocie != null)
                m_operation.RemplacementAssocie.EquipementRemplace = (CEquipement)m_selectEquipementRemplace.ElementSelectionne;
            
            InitSelectEquipementRemplacant();
        }

        //-------------------------------------------------------------------------------------------
        private void m_ctrlFindCoordonnee_OnButonSearcheClick(object sender, EventArgs e)
        {
            List<IObjetACoordonnees> listeEquipementsTrouves = m_ctrlFindCoordonnee.GetResultatsRecherche();

            if (listeEquipementsTrouves != null && listeEquipementsTrouves.Count > 0)
                m_selectEquipementRemplace.ElementSelectionne = (CEquipement)listeEquipementsTrouves[0];  
        }

        //-------------------------------------------------------------------------------------------
        private void m_selectEquipementRemplacant_ElementSelectionneChanged(object sender, EventArgs e)
        {
            CEquipement eqpt = (CEquipement)m_selectEquipementRemplacant.ElementSelectionne;

            if (eqpt != null && eqpt.IsDotationApplique)
            {
                m_panelSerialReplaced.Visible = true;
				m_panelSearchReplaced.Visible = false;
            }
            else
            {
				m_panelSerialReplaced.Visible = false;
				m_panelSearchReplaced.Visible = true;
            }
            
        }


		//-------------------------------------------------------------------------
		private void m_cmbSelectProfil_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!m_bIsInitProfils)
			{
				CProfilElement profil = (CProfilElement)m_cmbSelectProfil.ElementSelectionne;
				if (profil != null)
					new CTimosAppRegistre().LastIdProfilEchangeEquipement = profil.Id;
				else
					new CTimosAppRegistre().LastIdProfilEchangeEquipement = -1;
				InitSelectEquipementRemplacant();
			}
		}


	}
}