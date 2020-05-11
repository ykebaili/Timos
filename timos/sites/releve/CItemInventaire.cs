using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using timos.data;

namespace timos.sites.releve
{
    public class CItemInventaire : CCustomizableListItemANiveau
    {
        private bool m_bIsCollapse = true;
        private bool m_bIsInfoVisible = false;

        //-------------------------------------------------------
        public CItemInventaire(CItemInventaire itemParent, CTraitementReleveEquipement traitement)
            :base(itemParent)
        {
            Tag = traitement;
        }

        //-------------------------------------------------------
        public CTraitementReleveEquipement TraitementReleve
        {
            get
            {
                return Tag as CTraitementReleveEquipement;
            }
        }
        
        //-------------------------------------------------------
        /// <summary>
        /// Indique si on voit les commentaires ou l'info ligne
        /// </summary>
        public bool InfoLigneVisible
        {
            get
            {
                return m_bIsInfoVisible;
            }
            set
            {
                m_bIsInfoVisible = value;
            }
        }

        

        //-------------------------------------------------------
        public override bool IsCollapse
        {
            get { return m_bIsCollapse; }
        }

        //-------------------------------------------------------
        public void SetCollapse(bool bCollapse)
        {
            m_bIsCollapse = bCollapse;
            MasqueChildren(m_bIsCollapse);
        }

        //-------------------------------------------------------
        public void MasqueChildren(bool bMasquer)
        {
            foreach (CItemInventaire iv in ChildItems)
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
