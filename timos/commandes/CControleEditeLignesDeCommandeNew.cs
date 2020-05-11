using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using timos.data.commandes;
using sc2i.common;
using sc2i.win32.common;
using timos.data;
using sc2i.data;
using timos.data.projet.besoin;

namespace timos.commandes
{
    public partial class CControleEditeLignesDeCommandeNew : UserControl, IControlALockEdition
    {
        private CCommande m_commande = null;

        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;
        private CControleEditeLigneCommandeNew m_controleLigne = null;

        public CControleEditeLignesDeCommandeNew()
        {
            InitializeComponent();

            m_controleLigne = new CControleEditeLigneCommandeNew();
            m_wndListeCommandes.ItemControl = m_controleLigne;
            m_controleLigne.OnDelete += new EventHandler(ctrl_OnDelete);
            m_controleLigne.OnLeaveLastControl += new CCustomizableListControl.OnLeaveLastControlEventHandler(ItemControl_OnLeaveLastControl);
        }

        

        
        //------------------------------------------------------------------
        public CDonneesActeurFournisseur FournisseurPourFiltre
        {
            get
            {
                return m_fournisseurPourFiltre;
            }
            set
            {
                m_fournisseurPourFiltre = value;
                if (m_controleLigne != null)
                    m_controleLigne.FournisseurPourFiltre = value;
            }
        }

        //------------------------------------------------------------------
        public void Init(CCommande commande)
        {
            m_commande = commande;
            List<CCustomizableItemLigneCommande> lstItems = new List<CCustomizableItemLigneCommande>();
            foreach (CLigneCommande ligne in m_commande.Lignes)
            {
                CCustomizableItemLigneCommande item = new CCustomizableItemLigneCommande(ligne);
                item.Tag = ligne;
                lstItems.Add(item);
            }
            m_wndListeCommandes.Items = lstItems.ToArray();
            m_wndListeCommandes.Refresh();
            m_wndListeCommandes.CurrentItemIndex = null;
       }



        //------------------------------------------------------------
        void ctrl_OnDelete(object sender, EventArgs e)
        {
            if (m_controleLigne.LigneCommande != null)
            {
                CLigneCommande ligne = m_controleLigne.LigneCommande;
                int nNumero = ligne.Numero;
                //RenumerotteLignes(nNumero, m_commande.Lignes.Count - 1, -1);
                CResultAErreur result = ligne.Delete(true);
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
                m_wndListeCommandes.RemoveItem(m_wndListeCommandes.CurrentItemIndex.Value, true);
                m_wndListeCommandes.Refresh();
            }
        }

        //------------------------------------------------------------
        private void m_lnkAddLine_LinkClicked(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CLigneCommande ligne = new CLigneCommande(m_commande.ContexteDonnee);
                ligne.CreateNewInCurrentContexte();
                ligne.Numero = m_commande.Lignes.Count;
                ligne.Commande = m_commande;
                CCustomizableItemLigneCommande item = new CCustomizableItemLigneCommande(ligne);
                m_wndListeCommandes.AddItem(item, false);
                m_wndListeCommandes.Refresh();
            }
        }

        //------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_wndListeCommandes.CurrentItemIndex != null)
                result = m_controleLigne.MajChamps();
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
                if (OnChangeLockEdition != null )
                    OnChangeLockEdition ( this, null );
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        //--------------------------------------------------------------------
        private bool ItemControl_OnLeaveLastControl(object sender, EventArgs args)
        {
            CControleEditeLigneCommandeNew ctrl = sender as CControleEditeLigneCommandeNew;
            if (ctrl != null)
            {
                //Regarde si le dernier item est vide
                if (m_wndListeCommandes.Items.Count() > 0 && !LockEdition && m_commande!= null)
                {
                    CCustomizableListItem item = m_wndListeCommandes.Items.ElementAt(m_wndListeCommandes.Items.Count() - 1);
                    CLigneCommande ligne = item != null ? item.Tag as CLigneCommande : null;
                    if ( ligne != null && ligne.ElementCommandé != null )
                    {
                        ligne = new CLigneCommande(m_commande.ContexteDonnee);
                        ligne.CreateNewInCurrentContexte();
                        ligne.Commande = m_commande;
                        ligne.Numero = m_wndListeCommandes.Items.Count();
                        item = new CCustomizableItemLigneCommande(ligne);
                        m_wndListeCommandes.AddItem(item, true);
                        m_wndListeCommandes.CurrentItemIndex = item.Index;
                        return true;
                    }

                }
            }
            return false;
        }

        private void m_picDragBesoin_DragEnter(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
            if (refObj != null)
            {
                CBesoin besoin = refObj.GetObjet(m_commande.ContexteDonnee) as CBesoin;
                if (besoin.DonneeBesoin is CDonneeBesoinTypeEquipement)
                    e.Effect = DragDropEffects.Link;
            }
        }

        private void m_picDragBesoin_DragDrop(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
            if (refObj != null)
            {
                CBesoin besoin = refObj.GetObjet(m_commande.ContexteDonnee) as CBesoin;
                CDonneeBesoinTypeEquipement besoinEqpt = besoin.DonneeBesoin as CDonneeBesoinTypeEquipement;
                if (besoinEqpt != null)
                {
                    e.Effect = DragDropEffects.Link;
                    CLigneCommande ligne = new CLigneCommande(m_commande.ContexteDonnee);
                    ligne.CreateNewInCurrentContexte();
                    ligne.Commande = m_commande;
                    ligne.TypeEquipement = besoinEqpt.GetTypeEquipement(m_commande.ContexteDonnee);
                    ligne.Quantite = besoinEqpt.Quantite;
                    ligne.Libelle = besoin.Libelle;
                    besoin = besoin.GetObjetInContexte(ligne.ContexteDonnee) as CBesoin;
                    besoin.AddSatisfaction(ligne, null);
                    CCustomizableItemLigneCommande item = new CCustomizableItemLigneCommande(ligne);
                    m_wndListeCommandes.AddItem(item, true);
                }
            }
        }

        
    }
}
