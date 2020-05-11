using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using timos.securite;
using sc2i.common;

namespace timos.Securite.DroitsEdition
{
    public partial class CEditeurDroitsTypeEdition : CCustomizableList
    {
        public CEditeurDroitsTypeEdition()
        {
            InitializeComponent();
            ItemControl = new CEditeurDroitTypeEdition();
        }

        //------------------------------------------------------------------------
        public void Init(CDroitEditionType droit)
        {

            List<CCustomizableListItem> items = new List<CCustomizableListItem>();
            CParametreDroitEditionType parametre = droit.ParametreDroits;
            if (droit.TypeElements != null)
            {
                m_picType.Image = DynamicClassAttribute.GetImage(droit.TypeElements);
                m_lblType.Text = DynamicClassAttribute.GetNomConvivial(droit.TypeElements);
                ((CEditeurDroitTypeEdition)ItemControl).TypeObjets = droit.TypeElements;
                foreach (CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions couple in parametre.CouplesFormuleGroupe)
                {
                    CCustomizableListItem item = new CCustomizableListItem();
                    item.Tag = CCloner2iSerializable.Clone(couple) as CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions;
                    items.Add(item);
                }
            }
            Items = items.ToArray();
            Refill();
        }

        //------------------------------------------------------------------------
        public CResultAErreurType<CParametreDroitEditionType> GetParametre()
        {
            CResultAErreurType<CParametreDroitEditionType> result = new CResultAErreurType<CParametreDroitEditionType>();
            CResultAErreur resTmp = ItemControl.MajChamps();
            if (resTmp && CurrentItemIndex != null)
                resTmp = ItemControl.MajChamps();
            if (!resTmp)
            {
                result.EmpileErreur(resTmp.Erreur);
                return result;
            }
            
            

            CParametreDroitEditionType parametre = new CParametreDroitEditionType();
            foreach (CCustomizableListItem item in Items)
            {
                CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions couple = item.Tag as CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions;
                if (couple != null)
                    parametre.AddFormule(couple);
            }
            resTmp = parametre.VerifieDonnees();
            if (!resTmp)
                result.EmpileErreur(resTmp.Erreur);
            else
                result.DataType = parametre;
            return result;
        }

        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            CCustomizableListItem item = new CCustomizableListItem();
            CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions couple = new CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions();
            item.Tag = couple;
            AddItem(item, true);
        }

        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if(CurrentItemIndex != null)
                RemoveItem(CurrentItemIndex.Value, true);
        }

    }
}
