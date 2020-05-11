using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using timos.acteurs;
using sc2i.data;
using sc2i.common;

namespace timos.interventions
{
    public partial class CControleAffecteIntervenantsDeProfil : UserControl, IControlALockEdition
    {
        private CTypeIntervention_ProfilIntervenant m_relationProfil = null;
        private CIntervention m_intervention = null;
        private CControleAffecteUnIntervenantDeProfil m_controlItem = null;

        public CControleAffecteIntervenantsDeProfil()
        {
            InitializeComponent();
            m_controlItem = new CControleAffecteUnIntervenantDeProfil();
            m_controlItem.BackColor = BackColor;
            m_wndListeIntervenants.ItemControl = m_controlItem;
            m_extModeEdition.SetModeEdition ( m_controlItem, TypeModeEdition.EnableSurEdition );
        }

        public void InitChamps(CIntervention intervention,
            CTypeIntervention_ProfilIntervenant relProfil)
        {
            m_intervention = intervention;
            m_relationProfil = relProfil;
            m_lblProfil.Text = relProfil.Libelle;
            m_lnkAdd.Visible = relProfil.IsMultiple;
            m_controlItem.InitIntervention(intervention, relProfil);
            RefillListe();
        }

        //---------------------------------------------------------------------------
        private void RefillListe()
        {
            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            if (m_intervention != null && m_relationProfil != null)
            {
                CListeObjetsDonnees lstRels = m_intervention.GetRelationsIntervenants(m_relationProfil);
                foreach (CIntervention_Intervenant rel in lstRels)
                {
                    CCustomizableListItem item = new CCustomizableListItem();
                    item.Tag = rel;
                    lstItems.Add(item);
                }
            }
            if (m_extModeEdition.ModeEdition && lstItems.Count == 0 &&
                !m_relationProfil.IsMultiple)
            {
                CCustomizableListItem item = new CCustomizableListItem();
                lstItems.Add(item);
            }
            m_wndListeIntervenants.Items = lstItems.ToArray();
            AutoHeight();
        }

        //---------------------------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                RefillListe();
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        //--------------------------------------------------------------------
        private void m_lnkAdd_LinkClicked(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition && m_relationProfil.IsMultiple)
            {
                CCustomizableListItem item = new CCustomizableListItem();
                m_wndListeIntervenants.AddItem(item, true);
                AutoHeight();
            }
        }

        //--------------------------------------------------------------------
        public void AutoHeight()
        {
            int nHeight = Math.Max(m_controlItem.Height, m_wndListeIntervenants.Items.Count() * m_controlItem.Height);
            Height = nHeight;
        }



        //--------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_extModeEdition.ModeEdition)
            {
                result = m_wndListeIntervenants.MajChamps();
                if (!result)
                    return result;
                if (m_intervention != null && m_relationProfil != null)
                {
                    m_controlItem.CancelEdit();
                    //Supprime les vides
                    CListeObjetsDonnees lst = m_intervention.GetRelationsIntervenants(m_relationProfil);
                    foreach (CIntervention_Intervenant rel in lst.ToArrayList())
                    {
                        if (rel.Intervenant == null)
                        {
                            rel.Delete(true);
                        }
                    }
                }
            }
            
            
            return result;
        }
    }
}
