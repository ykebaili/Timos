using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.symbole.dynamique;
using sc2i.common;
using sc2i.win32.common;

namespace timos.Reseau
{
    public partial class CPanelResumeParametreSchemaDynamique : UserControl,
        IControlALockEdition
    {
        private Type m_typeElement = null;
        CParametreRepresentationSymbole m_parametreSymbole = null;
        public CPanelResumeParametreSchemaDynamique()
        {
            InitializeComponent();
        }

        public void Init(CParametreRepresentationSymbole parametreSymbole,
            Type typeElement)
        {
            m_parametreSymbole = parametreSymbole;
            m_typeElement = typeElement;
            m_lblTypeElement.Text = DynamicClassAttribute.GetNomConvivial(typeElement);
            if ( m_parametreSymbole != null )
                m_controleDessin.InitSymbole(m_parametreSymbole.Symbole);
        }

        public CParametreRepresentationSymbole Parametre
        {
            get
            {
                return m_parametreSymbole;
            }
        }

        public Type TypeElement
        {
            get
            {
                return m_typeElement;
            }
        }

        private void cWndLinkStd1_LinkClicked(object sender, EventArgs e)
        {
            m_parametreSymbole = CFormEditCParametreRepresentationSymbole.EditeParametre(m_typeElement, m_parametreSymbole);
        }


        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

    }
}
