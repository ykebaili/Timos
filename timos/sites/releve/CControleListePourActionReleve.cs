using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.common.memorydb;
using timos.data;

namespace timos.sites.releve
{
    public class CControleListePourActionReleve : CCustomizableListAvecNiveau
    {
        public IFiltreurTraitementsReleve FiltreurTraitements = null;
        //----------------------------------------------
        public CControleListePourActionReleve()
        {
            InitializeComponent();
            ItemControl = new CControlActionReleve();
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
        private bool ShouldAddItem(CTraitementReleveEquipement traitement)
        {
            return FiltreurTraitements == null || FiltreurTraitements.IsVisible(traitement);
        }

        //----------------------------------------------
        public void Init(IEnumerable<CTraitementReleveEquipement> traitements)
        {
            List<CItemInventaire> lstItems = new List<CItemInventaire>();
            foreach (CTraitementReleveEquipement traitement in traitements)
            {
                if (ShouldAddItem(traitement))
                {
                    CItemInventaire item = new CItemInventaire(null, traitement);
                    lstItems.Add(item);
                }
            }
            Items = lstItems.ToArray();
        }

        //----------------------------------------------
        public void OnExpand(CItemInventaire item)
        {
            if (item.ChildItems.Count() == 0)
            {
                AddChildren(item);
            }
        }

        //----------------------------------------------
        private void AddChildren(CItemInventaire item)
        {
            CTraitementReleveEquipement traitement = item.TraitementReleve;
            int nIndex = item.Index;
            foreach ( CTraitementReleveEquipement tFils in traitement.TraitementsFils )
            {
                if (ShouldAddItem(tFils))
                {
                    CItemInventaire itemFils = new CItemInventaire(item, tFils);
                    InsertItem(nIndex + 1, itemFils, false);
                    nIndex++;
                }
            }
            Refresh();
        }
    }
}
