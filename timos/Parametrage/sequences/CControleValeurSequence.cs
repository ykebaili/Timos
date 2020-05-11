using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using sc2i.workflow;
using sc2i.common;

namespace timos.Parametrage.sequences
{
    public partial class CControleValeurSequence : CCustomizableListControl
    {
        private CValeurSequenceNumerotation m_valeur = null;

        public CControleValeurSequence()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            CResultAErreur result = base.MyInitChamps(item);
            if (result && item != null)
            {
                CValeurSequenceNumerotation val = item.Tag as CValeurSequenceNumerotation;
                if (val != null && val.IsValide())
                {
                    m_txtLastVal.IntValue = val.DerniereValeur;
                    m_lblCle.Text = val.Cle;
                }
            }
            else
            {
                m_txtLastVal.IntValue = null;
                m_lblCle.Text = "";
            }
            m_bIsInitializing = false;
            return result;
        }

        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (result && CurrentItem != null)
            {
                CValeurSequenceNumerotation valeur = CurrentItem.Tag as CValeurSequenceNumerotation;
                if (valeur != null && m_txtLastVal.IntValue != null)
                    valeur.DerniereValeur = m_txtLastVal.IntValue.Value;
            }
            return result;
        }

        private void m_txtLastVal_TextChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }
    }
}
