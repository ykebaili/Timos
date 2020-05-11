using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using sc2i.workflow;

namespace timos.Parametrage.sequences
{
    public class CControleValeursSequence : CCustomizableList
    {
        private CSequenceNumerotation m_sequence = null;

        //--------------------------------------------------------------
        public CControleValeursSequence()
        {
            ItemControl = new CControleValeurSequence();
        }

        //--------------------------------------------------------------
        public void Init(CSequenceNumerotation sequence)
        {
            CurrentItemIndex = null;
            Items = new CCustomizableListItem[0];

            m_sequence = sequence;

            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            if (m_sequence != null)
            {
                foreach (CValeurSequenceNumerotation valeur in sequence.Valeurs)
                {
                    CCustomizableListItem item = new CCustomizableListItem();
                    item.Tag = valeur;
                    lstItems.Add(item);
                }
            }
            lstItems.Sort((x, y) => ((CValeurSequenceNumerotation)x.Tag).Cle.CompareTo(
                ((CValeurSequenceNumerotation)y.Tag).Cle));
            Items = lstItems.ToArray();
            Refill();
        }

    }
}
