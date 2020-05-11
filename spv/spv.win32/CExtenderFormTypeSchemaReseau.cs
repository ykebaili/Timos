using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;
using sc2i.win32.common;

namespace spv.win32
{
    public partial class CExtendeurFormTypeSchemaReseau : CExtendeurFormEditionStandardTabPage
    {
        //private CSpvTypeService m_spvTypeService = null;

        public CExtendeurFormTypeSchemaReseau()
        {
            InitializeComponent();
            Title = I.T("Supervision|9");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CTypeSchemaReseau);
            }
        }

        protected CTypeSchemaReseau TypeSchemaReseau
        {
            get
            {
                return ObjetEdite as CTypeSchemaReseau;
            }
        }



        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            /*
            if (ObjetEdite is CTypeSchemaReseau)
            {
                m_spvTypeService = CSpvTypeService.GetObjetSpvFromObjetTimos(ObjetEdite as CTypeSchemaReseau);
                m_chkSuperviser.Checked = m_spvTypeService != null;
            }*/
            m_chkSuperviser.Checked = true;
            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            return result;
        }//MyInitChamps()

        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;
            /*
            if (m_chkSuperviser.Checked)
            {
                if (m_spvTypeService == null)
                {
                    result = CSpvTypeService.CanSupervise(TypeSchemaReseau);
                    if (!result)
                    {
                        m_chkSuperviser.Checked = false;
                        return result;
                    }
                    m_spvTypeService = CSpvTypeService.GetObjetSpvFromObjetTimosAvecCreation(TypeSchemaReseau);
                }
            }
            else
            {
                if (m_spvTypeService != null)
                {
                    result = CResultAErreur.True;
                    using (CWaitCursor waiter = new CWaitCursor())
                    {
                        result = m_spvTypeService.Delete();
                    }
                    if (!result)
                    {
                        m_chkSuperviser.Checked = true;
                        return result;
                    }
                    else
                        m_spvTypeService = null;
                }
            }*/
            return result;
        }

        //--------------------------------------------------------------
        private void m_chkSuperviser_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}

