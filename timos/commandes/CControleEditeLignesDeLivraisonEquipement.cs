using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.commandes;
using System.Collections;
using sc2i.common;
using sc2i.win32.common;
using timos.data;
using sc2i.data;

namespace timos.commandes
{
    public partial class CControleEditeLignesDeLivraisonEquipement : UserControl, IControlALockEdition
    {
        private CLivraisonEquipement m_LivraisonEquipement = null;
        private IEmplacementEquipement m_lastPlace = null;
        private Stack<CControleEditeLigneLivraisonEquipement> m_controlesReserve = new Stack<CControleEditeLigneLivraisonEquipement>();
        private CControleEditeLigneLivraisonEquipement m_controleLignes = null;

        //------------------------------------------------------------------
        public CControleEditeLignesDeLivraisonEquipement()
        {
            InitializeComponent();
            m_controleLignes = new CControleEditeLigneLivraisonEquipement();
            m_extModeEdition.SetModeEdition(m_controleLignes, TypeModeEdition.EnableSurEdition);
            m_controleLignes.LockEdition = !m_extModeEdition.ModeEdition;
            m_wndListeLignes.ItemControl = m_controleLignes;
        }

        //------------------------------------------------------------------
        public void Init(CLivraisonEquipement LivraisonEquipement)
        {
            m_wndListeLignes.CancelEdit();
            m_LivraisonEquipement = LivraisonEquipement;
            m_cmbStatut.Init(
                typeof(CStatutEquipement),
                "Libelle",
                null,
                false);
            m_cmbTypeDestination.Init ( DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(IEmplacementEquipement)));
            if (m_lastPlace == null && LivraisonEquipement.Lignes.Count > 0)
            {
                foreach (CLigneLivraisonEquipement ligne in LivraisonEquipement.Lignes)
                {
                    if (ligne.Equipement != null)
                    {
                        m_lastPlace = ligne.Equipement.Emplacement;
                        m_cmbStatut.ElementSelectionne = ligne.Equipement.Statut;
                        break;
                    }
                }
            }
            if ( m_lastPlace != null )
            {
                m_cmbTypeDestination.TypeSelectionne = m_lastPlace.GetType();
                m_selectStock.ElementSelectionne = m_lastPlace as CObjetDonnee;
            }
            if (m_extModeEdition.ModeEdition && m_cmbTypeDestination.TypeSelectionne == null)
                m_cmbTypeDestination.TypeSelectionne = typeof(CStock);
            

            InitSelectEmplacement();
            
            List<CItemLigneLivraison> lstItems = new List<CItemLigneLivraison>();
            foreach (CLigneLivraisonEquipement ligne in m_LivraisonEquipement.Lignes)
            {
                CItemLigneLivraison item = new CItemLigneLivraison(ligne, ligne.LigneDeCommandeAssociee, ligne.LivraisonEquipement);
                lstItems.Add(item);
            }
            if (m_extModeEdition.ModeEdition)
            {
                //Création des éléments complémentaires
                if (m_LivraisonEquipement.Commande != null)
                {
                    foreach (CLigneCommande ligne in m_LivraisonEquipement.Commande.Lignes)
                    {
                        int nRestant = (int)ligne.Quantite - ligne.LignesLivraison.Count;
                        for (int n = 0; n < nRestant; n++)
                        {
                            CItemLigneLivraison item = new CItemLigneLivraison(null, ligne, m_LivraisonEquipement);
                            lstItems.Add(item);
                        }
                    }
                }
            }
            m_wndListeLignes.Items = lstItems.ToArray();
            m_wndListeLignes.Refresh();
        }

        //------------------------------------------------------------
        private void RenumerotteLignes(int nFrom, int nTo, int nInc)
        {
            foreach (CLigneLivraisonEquipement ligne in m_LivraisonEquipement.Lignes)
            {
                if (ligne.Numero >= nFrom && ligne.Numero <= nTo)
                    ligne.Numero += nInc;
            }
        }

        //------------------------------------------------------------
        private void m_lnkAddLine_LinkClicked(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CItemLigneLivraison item = new CItemLigneLivraison(null, null, m_LivraisonEquipement);
                m_wndListeLignes.AddItem(item, true);
                m_wndListeLignes.CurrentItemIndex = item.Index;
            }
        }

        //------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_controleLignes.MajChamps();
            foreach (CItemLigneLivraison item in m_wndListeLignes.Items)
            {
                result = item.MajChamps(m_cmbStatut.ElementSelectionne as CStatutEquipement,
                    m_selectStock.ElementSelectionne as IEmplacementEquipement);
                if (!result)
                    return result;
            }

            return result;
        }



        #region IControlALockEdition Membres

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
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_cmbTypeDestination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitSelectEmplacement();
        }

        private void InitSelectEmplacement()
        {
            IEmplacementEquipement place = m_selectStock.ElementSelectionne as IEmplacementEquipement;
            Type tp = m_cmbTypeDestination.TypeSelectionne;
            if (tp != null)
            {
                m_selectStock.Init(
                    tp,
                    "Libelle",
                    true);
            }
            if (place != null && place.GetType() == tp)
                m_selectStock.ElementSelectionne = place as CObjetDonnee;
        }

        private void m_selectStock_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            m_controleLignes.DefaultEmplacement = m_selectStock.ElementSelectionne as IEmplacementEquipement;
        }

        private void m_cmbStatut_SelectedValueChanged(object sender, EventArgs e)
        {
            m_controleLignes.DefaultStatus = m_cmbStatut.ElementSelectionne as CStatutEquipement;
        }
    }
}
