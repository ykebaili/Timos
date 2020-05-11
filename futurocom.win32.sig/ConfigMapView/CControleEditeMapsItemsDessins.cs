using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.sig;
using sc2i.win32.common.customizableList;
using sc2i.common;
using sc2i.win32.common;

namespace futurocom.win32.sig
{
    public partial class CControleEditeMapsItemsDessins : CCustomizableList
    {
        private CMapPointGenerator m_generator = null;
        public CControleEditeMapsItemsDessins()
        {
            InitializeComponent();
            ItemControl = new CControleEditeMapItemDessin();
            ((CControleEditeMapItemDessin)ItemControl).OnDeleteItem += new EventHandler(CControleEditeMapsItemsDessins_OnDeleteItem);
        }

        

        //-------------------------------------------------------
        public Type TypeEdite
        {
            set
            {
                if ( m_generator != null )
                    ((CControleEditeMapItemDessin)ItemControl).InitForMapPointGenerator(m_generator);
            }
        }

        //-------------------------------------------------------
        public void Init(CMapPointGenerator generator)
        {
            m_generator = generator;
            List<CCustomizableListItem> items = new List<CCustomizableListItem>();
            if (m_generator != null)
            {
                foreach (CMapItemDessin dessin in generator.ItemsDessin)
                {
                    CCustomizableListItem item = new CCustomizableListItem();
                    item.Tag = dessin;
                    items.Add(item);
                }
            }
            if ( generator != null )
                ((CControleEditeMapItemDessin)ItemControl).InitForMapPointGenerator(generator);
            Items = items.ToArray();
        }
        
        //-------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_generator != null)
            {
                if (CurrentItemIndex != null)
                    ItemControl.MajChamps();
                List<CMapItemDessin> lst = new List<CMapItemDessin>();
                foreach (CCustomizableListItem item in Items)
                {
                    CMapItemDessin dessin = item.Tag as CMapItemDessin;
                    if (dessin != null)
                    {
                        dessin.Index = item.Index;
                        lst.Add(dessin);
                    }
                }
                m_generator.ItemsDessin = lst.ToArray();
            }
            return result;
        }
                    


        //-----------------------------------------------------------------
        private void m_btnAddItem_LinkClicked(object sender, EventArgs e)
        {
            CMapItemDessin dessin = new CMapItemDessin(m_generator);
            CCustomizableListItem item = new CCustomizableListItem();
            item.Tag = dessin;
            AddItem(item, true);
            CurrentItemIndex = item.Index;
        }

        //-----------------------------------------------------------------
        public override bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                base.LockEdition = value;
            }
        }

        //-----------------------------------------------------------------
        void CControleEditeMapsItemsDessins_OnDeleteItem(object sender, EventArgs e)
        {
            CCustomizableListItem item = sender as CCustomizableListItem;
            if (item != null)
            {
                if (CFormAlerte.Afficher(I.T("Delete item ?|20006"),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                {
                    RemoveItem(item, true);
                }
            }
        }


    }
}
