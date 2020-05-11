using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using TimosInventory.data;
using TimosInventory.data.releve;

namespace TimosInventory.ControleInventaire
{
    public class CItemInventaire : CCustomizableListItemANiveau
    {
        private bool m_bIsCollapse = true;
        private bool m_bHasChildren = false;

        //-------------------------------------------------------
        public CItemInventaire(CItemInventaire itemParent, CReleveEquipement relEqpt)
            : base(itemParent)
        {
            Tag = relEqpt;
            m_bHasChildren = relEqpt.RelevesContenus.Count() > 0;
        }

        //-------------------------------------------------------
        public CReleveEquipement ReleveEquipement
        {
            get
            {
                return Tag as CReleveEquipement;
            }
        }

        //-------------------------------------------------------
        public bool HasChildren
        {
            get
            {
                return m_bHasChildren;
            }
        }

        //-------------------------------------------------------
        public override bool IsCollapse
        {
            get
            {
                return m_bIsCollapse && HasChildren ;
            }
        }

        //-------------------------------------------------------
        public void SetCollapse(bool bCollapse)
        {
            m_bIsCollapse = bCollapse;
            MasqueChildren(m_bIsCollapse);
        }

        //-------------------------------------------------------
        private void MasqueChildren(bool bMasquer)
        {
            foreach ( CItemInventaire iv in ChildItems )
            {
                iv.IsMasque = bMasquer || IsCollapse;
                iv.MasqueChildren(bMasquer || iv.IsCollapse);
            }
        }


        //-------------------------------------------------------
        public override bool OnChangeParent(CCustomizableListItemANiveau item)
        {
            return false;
        }

    }
}
