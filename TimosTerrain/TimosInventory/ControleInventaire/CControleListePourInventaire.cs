using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.common.memorydb;
using TimosInventory.data;
using TimosInventory.data.releve;

namespace TimosInventory.ControleInventaire
{
    public class CControleListePourInventaire : CCustomizableListAvecNiveau
    {
        //----------------------------------------------
        public CControleListePourInventaire()
        {
            InitializeComponent();
            ItemControl = new CControlePourInventaire();
            CWin32Traducteur.Translate(ItemControl);
        }


        //----------------------------------------------
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CControlePourInventaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.Name = "CControlePourInventaire";
            this.ResumeLayout(false);
        }

        //----------------------------------------------
        public void Init(CReleveSite releve)
        {
            CListeEntitesDeMemoryDb<CReleveEquipement> lstEqpts = releve.RelevesEquipement;
            lstEqpts.Filtre = new CFiltreMemoryDb(CReleveEquipement.c_champIdContenant + " is null");
            lstEqpts.Sort = CEquipement.c_champCoordonnee;
            List<CItemInventaire> lstItems = new List<CItemInventaire>();
            foreach (CReleveEquipement relEq in lstEqpts)
            {
                CItemInventaire item = new CItemInventaire(null, relEq);
                lstItems.Add(item);
            }
            Items = lstItems.ToArray();
        }

        //----------------------------------------------
        public void OnExpand(CItemInventaire item)
        {
            if (item.HasChildren && item.ChildItems.Count() == 0)
            {
                AddChildren(item);
            }
        }

        //----------------------------------------------
        private void AddChildren(CItemInventaire item)
        {
            CReleveEquipement relEq = item.ReleveEquipement;
            int nIndex = item.Index;
            CListeEntitesDeMemoryDb<CReleveEquipement> lstFils = relEq.RelevesContenus;
            lstFils.Sort = CEquipement.c_champCoordonnee;
            foreach (CReleveEquipement fils in lstFils)
            {
                CItemInventaire itemFils = new CItemInventaire(item, fils);
                InsertItem(nIndex + 1, itemFils, false);
                nIndex++;
            }
            Refresh();
        }

        //----------------------------------------------
        public void AddChildren(CReleveEquipement releveFils, CItemInventaire itemParent)
        {
            if (itemParent != null)
            {
                OnExpand(itemParent);
                CItemInventaire item = new CItemInventaire(itemParent, releveFils);
                InsertItem(itemParent.Index + 1, item, true);
            }
            else
            {
                CItemInventaire item = new CItemInventaire(null, releveFils);
                AddItem(item, true);
            }
        }

        
    }
}
