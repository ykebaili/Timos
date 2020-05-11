using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;

using timos.data;

namespace timos
{
    public partial class CControlEditElementATrancheHoraire : UserControl, IControlALockEdition
    {
        private IElementATrancheHoraire m_elementEdite = null;

        public IElementATrancheHoraire ElementEdite
        {
            get
            {
                return m_elementEdite;
            }
        }
        

        //---------------------------------------------------------------------------------------------
        public CControlEditElementATrancheHoraire()
        {
            InitializeComponent();
        }


        //-------------------------------------------------------------------------
        // Le premier paramètre est l'élément pricipal pour l'édition des tranches horaires
        // Le deuxième paramètre est l'élement secondaire pour l'édition du Type d'occupation Horaire
        // Le deuxième paramètre peut être égal au premier
        public CResultAErreur InitChamps(IElementATrancheHoraire elementATranche)
        {
            CResultAErreur result = CResultAErreur.True;
            
            m_elementEdite = elementATranche;

            m_panelEditionTranche.Visible = false;
            
            m_gestionnaireEditionTranches.ObjetEdite = m_elementEdite.TranchesHorairesListe;

            // Init combo sélection type d'occcupation horaire
			CListeObjetsDonnees listeOccupations = new CListeObjetsDonnees(m_elementEdite.ContexteDonnee, typeof(CTypeOccupationHoraire));
			listeOccupations.Filtre = new CFiltreData(CTypeOccupationHoraire.c_champSurCalendrier + "=@1", true);
            m_cmbxSelectTypeOccupationH.Init(listeOccupations, "Libelle", true);
            m_cmbxSelectTypeOccupationH.NullAutorise = true;
            m_cmbxSelectTypeOccupationH.TextNull = "Default";
            m_cmbxSelectTypeOccupationH.ElementSelectionne = m_elementEdite.TypeOccupationHoraire;

            m_cmbxSelectTypeOccupationHpourTranche.Init(listeOccupations, "Libelle", true);
            m_cmbxSelectTypeOccupationHpourTranche.NullAutorise = true;
            m_cmbxSelectTypeOccupationHpourTranche.TextNull = "Default";


            // Init la liste des tranches
            m_listViewTranches.Items.Clear();
            foreach (CHoraireJournalier_Tranche tranche in m_elementEdite.TranchesHorairesListe)
            {
                ListViewItem item = new ListViewItem();
                m_listViewTranches.Items.Add(item);
                m_listViewTranches.UpdateItemWithObject(item, tranche);
            }
            foreach (ListViewItem itemSel in m_listViewTranches.Items)
                itemSel.Selected = false;

            

            return result;
        }


        //-------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True; ;

            m_elementEdite.TypeOccupationHoraire = (CTypeOccupationHoraire)m_cmbxSelectTypeOccupationH.ElementSelectionne;
            if (result)
                result = m_gestionnaireEditionTranches.ValideModifs();

            return result;
        }

        //---------------------------------------------------------------------------------------------
        private void m_gestionnaireEditionTranches_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_panelEditionTranche.Visible = false;
                return;
            }
            m_panelEditionTranche.Visible = true;

            CHoraireJournalier_Tranche tranche = (CHoraireJournalier_Tranche)args.Objet;

            int heure = (int)tranche.HeureDebut / 60;
            int minute = tranche.HeureDebut % 60;
            DateTime heureDebut = new DateTime(2000, 1, 1, heure, minute, 0);
            m_timePickerHeureDebut.Value = heureDebut;

            heure = (int)tranche.HeureFin / 60;
            minute = tranche.HeureFin % 60;
            DateTime heureFin = new DateTime(2000, 1, 1, heure, minute, 0);
            m_timePickerHeureFin.Value = heureFin;

            m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne = tranche.TypeOccupationHoraire;
        }

        //---------------------------------------------------------------------------------------------
        private void m_gestionnaireEditionTranches_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null  && args.Objet.IsValide())
            {
                CHoraireJournalier_Tranche tranche = (CHoraireJournalier_Tranche)args.Objet;

                DateTime heureDebut = m_timePickerHeureDebut.Value;
                tranche.HeureDebut = heureDebut.Hour * 60 + heureDebut.Minute;

                DateTime heureFin = m_timePickerHeureFin.Value;
                tranche.HeureFin = heureFin.Hour * 60 + heureFin.Minute;

                tranche.TypeOccupationHoraire = (CTypeOccupationHoraire) m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne;
                CResultAErreur result = tranche.VerifieDonnees(true);
                args.Result = result;
            }
        }

        //---------------------------------------------------------------------------------------------
        private void m_lnkAjouterTranche_LinkClicked(object sender, EventArgs e)
        {
            m_gestionnaireEditionTranches.ValideModifs();

            CHoraireJournalier_Tranche tranche = new CHoraireJournalier_Tranche(m_elementEdite.ContexteDonnee);
            tranche.CreateNewInCurrentContexte();
            tranche.ElementAtrancheHoraireParent = m_elementEdite;
            // Recherche la dernière fin de tranche
            int derniereHeureDeFin = 0;
            foreach (CHoraireJournalier_Tranche trancheTmp in m_elementEdite.TranchesHorairesListe)
            {
                if (trancheTmp.HeureFin > derniereHeureDeFin)
                    derniereHeureDeFin = trancheTmp.HeureFin;
            }
            tranche.HeureDebut = derniereHeureDeFin;
            tranche.HeureFin = tranche.HeureDebut < (22*60)?tranche.HeureDebut+120:0;

            // Ajoute à la liste
            ListViewItem item = new ListViewItem();
            m_listViewTranches.Items.Add(item);
            m_listViewTranches.UpdateItemWithObject(item, tranche);
            item.Selected = true;

        }

        //---------------------------------------------------------------------------------------------
        private void m_lnkSupprimerTranche_LinkClicked(object sender, EventArgs e)
        {
            if (m_listViewTranches.SelectedItems.Count != 1)
                return;

            CHoraireJournalier_Tranche trancheToRemove =
                (CHoraireJournalier_Tranche)m_listViewTranches.SelectedItems[0].Tag;

            CResultAErreur result = trancheToRemove.Delete();
            if (m_listViewTranches.SelectedItems.Count == 1)
            {
                if (m_listViewTranches.SelectedItems[0] != null)
                    m_listViewTranches.SelectedItems[0].Remove();
            }
        }



        //---------------------------------------------------------------------------------------------
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

                if(OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
