using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;

namespace TimosWebApp
{
    public partial class CControlVariableValeur : UserControl
    {
        private CCoupleVariableValeur m_coupleVarVal;

        public CControlVariableValeur()
        {
            InitializeComponent();
        }

        public CCoupleVariableValeur CoupleVariableValeur
        {
            get
            {
                return m_coupleVarVal;
            }
        }


        public void Init(CCoupleVariableValeur couple)
        {
            if (couple == null)
                return;

            m_coupleVarVal = couple;
            m_lblNomVariable.Text = m_coupleVarVal.Variable.Name;
            m_txtValeur.Text = couple.Valeur;
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            m_coupleVarVal.Valeur = m_txtValeur.Text;

            return result;
        }

    }
}
