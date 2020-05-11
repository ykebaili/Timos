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
using sc2i.win32.common.customizableList;

namespace timos.commandes
{
    public partial class CControleEditeValorisations : UserControl, IControlALockEdition
    {
        private CLotValorisation m_lotValorisation;
        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;

        public CControleEditeValorisations()
        {
            InitializeComponent();
            CControleEditeValorisationEquipement ctrl = new CControleEditeValorisationEquipement();
            m_listeLignes.ItemControl = ctrl;
            m_extModeEdition.SetModeEdition(ctrl, TypeModeEdition.EnableSurEdition);
            ctrl.OnDelete += new EventHandler(ctrl_OnDelete);
            ctrl.OnAddLigne += new EventHandler(ctrl_OnAddLine);
            ctrl.OnLeaveLastControl += new CCustomizableListControl.OnLeaveLastControlEventHandler(ItemControl_OnLeaveLastControl);
        }

        //------------------------------------------------------------------
        public void Init(CLotValorisation lot)
        {
            m_listeLignes.CancelEdit();
            m_lotValorisation = lot;
            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            foreach (CValorisationElement ligne in m_lotValorisation.Valorisations)
            {
                CCustomizableListItem item = new CCustomizableListItem();
                item.Tag = ligne;
                lstItems.Add(item);
            }
            m_listeLignes.Items = lstItems.ToArray();
            m_listeLignes.Refresh();
        }


        //------------------------------------------------------------
        void ctrl_OnDelete(object sender, EventArgs e)
        {
            CControleEditeValorisationEquipement ctrl = sender as CControleEditeValorisationEquipement;
            if (ctrl == null)
                return;

            CValorisationElement ligne = ctrl.CurrentItem != null ? ctrl.CurrentItem.Tag as CValorisationElement : null ;
            if (ligne != null)
            {
                CResultAErreur result = ligne.Delete(true);
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
            }
            m_listeLignes.RemoveItem(ctrl.CurrentItem, true);
            m_listeLignes.CurrentItemIndex = m_listeLignes.CurrentItemIndex;
        }

        //------------------------------------------------------------
        void ctrl_OnAddLine(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CCustomizableListItem item = new CCustomizableListItem();
                CValorisationElement valo = new CValorisationElement(m_lotValorisation.ContexteDonnee);
                valo.CreateNewInCurrentContexte();
                valo.LotValorisation = m_lotValorisation;
                item.Tag = valo;
                m_listeLignes.AddItem(item, true);
                m_listeLignes.CurrentItemIndex = item.Index;
            }
        }

        private void m_lnkAddLine_LinkClicked(object sender, EventArgs e)
        {
            ctrl_OnAddLine(sender, e);
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_listeLignes.ItemControl.MajChamps();
            foreach (CCustomizableListItem item in m_listeLignes.Items)
            {
                CValorisationElement valo = item.Tag as CValorisationElement;
                if (valo != null)
                {
                    if (valo.ElementValorisé == null)
                    {
                        m_listeLignes.RemoveItem(item, false);
                        valo.Delete(true);
                    }
                    
                }
            }
            m_listeLignes.Refresh();
            /*foreach (CControleEditeValorisationEquipement ctrl in ControlesValorisation)
            {
                result = ctrl.MajChamps();
                if (!result)
                    return result;
            }*/
            return result;
        }

        //--------------------------------------------------------------------
        private bool ItemControl_OnLeaveLastControl(object sender, EventArgs args)
        {
            CControleEditeValorisationEquipement ctrl = sender as CControleEditeValorisationEquipement;
            if (ctrl != null)
            {
                //Regarde si le dernier item est vide
                if ( m_listeLignes.Items.Count() > 0 && !LockEdition && m_lotValorisation != null)
                {
                    CCustomizableListItem item = m_listeLignes.Items.ElementAt(m_listeLignes.Items.Count() - 1);
                    CValorisationElement ligne = item != null ? item.Tag as CValorisationElement : null;
                    if (ligne != null && ligne.ElementValorisé != null)
                    {
                        ligne = new CValorisationElement(m_lotValorisation.ContexteDonnee);
                        ligne.CreateNewInCurrentContexte();
                        ligne.LotValorisation = m_lotValorisation;
                        item = new CCustomizableListItem();
                        item.Tag = ligne;
                        m_listeLignes.AddItem(item, true);
                        m_listeLignes.CurrentItemIndex = item.Index;
                        return true;
                    }

                }
            }
            return false;
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
    }
}
