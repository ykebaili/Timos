using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.expression;
using sc2i.data.dynamic;

namespace timos.symbole
{
    public partial class CControlEditFormulePropriete : UserControl
    {
        private string m_strPropriete = "";
        public CControlEditFormulePropriete()
        {
            InitializeComponent();
        }

        public void Init(Type typeElement, string strPropriete, C2iExpression formule)
        {
            m_strPropriete = strPropriete;
            m_lblPropriete.Text = strPropriete;
            m_txtFormule.Formule = formule;
            m_txtFormule.Init(new CFournisseurPropDynStd(), typeElement);
        }

        public string Propriete
        {
            get
            {
                return m_strPropriete;
            }
        }

        public void Clear()
        {
            m_strPropriete = "";
            m_txtFormule.Formule = null;
        }

        public C2iExpression Formule
        {
            get
            {
                return m_txtFormule.Formule;
            }
        }

        


    }
}
