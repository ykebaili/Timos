using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.customizableList;
using timos.data;

namespace timos.interventions.crintervention
{
    public class CSaisieOperationItem : CCustomizableListItem
    {
        private int m_nNiveau = 0;
        
        //------------------------------------------
        public COperation Operation
        {
            get
            {
                return Tag as COperation;
            }
            set
            {
                Tag = value;
            }
        }

        //------------------------------------------
        public int Niveau
        {
            get
            {
                return m_nNiveau;
            }
            set
            {
                m_nNiveau = value;
            }
        }



    }
}
