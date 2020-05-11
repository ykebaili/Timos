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
    public partial class CExtendeurFormTypeLienReseau : CExtendeurFormEditionStandardTabPage
    {
        private CSpvTypliai m_spvTypeLiaison = null;

        public CExtendeurFormTypeLienReseau()
        {
            InitializeComponent();
            Title = I.T("Supervision|9");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CTypeLienReseau);
            }
        }

        protected CTypeLienReseau TypeLienReseau
        {
            get
            {
                return ObjetEdite as CTypeLienReseau;
            }
        }



        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CTypeLienReseau)
            {
                //m_spvTypeLiaison = CSpvTypliai.GetSpvTypliaiFromTypeLienReseau(ObjetEdite as CTypeLienReseau) as CSpvTypliai;
                m_spvTypeLiaison = CSpvTypliai.GetObjetSpvFromObjetTimos(ObjetEdite as CTypeLienReseau) as CSpvTypliai;
                m_chkSuperviser.Checked = m_spvTypeLiaison != null;
            }
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
            if (m_chkSuperviser.Checked)
            {
                if (m_spvTypeLiaison == null)
                {
                    result = CSpvTypliai.CanSupervise(TypeLienReseau);
                    if (!result)
                    {
                        m_chkSuperviser.Checked = false;
                        return result;
                    }
                    //m_spvTypeLiaison = CSpvTypliai.GetSpvTypliaiFromTypeLienReseauAvecCreation(TypeLienReseau);
                    m_spvTypeLiaison = CSpvTypliai.GetObjetSpvFromObjetTimosAvecCreation(TypeLienReseau);
                }
            }
            else
            {
                if (m_spvTypeLiaison != null)
                {
                    result = CResultAErreur.True;
                    using (CWaitCursor waiter = new CWaitCursor())
                    {
                        result = m_spvTypeLiaison.Delete(true);
                    }
                    if (!result)
                    {
                        m_chkSuperviser.Checked = true;
                        return result;
                    }
                    else
                        m_spvTypeLiaison = null;
                }
            }
            return result;
        }

        //--------------------------------------------------------------
        private void m_chkSuperviser_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}

