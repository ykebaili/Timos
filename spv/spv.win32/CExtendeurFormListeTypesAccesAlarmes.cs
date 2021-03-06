using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
	public partial class CExtendeurFormListeTypeAccesAlarmes : CExtendeurFormEditionStandardTabPage
	{
        private CSpvTypeq m_spvTypeq=null;

        public CExtendeurFormListeTypeAccesAlarmes()
		{
			InitializeComponent();
            Title = I.T("Supervision|9");
		}

		public override Type TypeObjetEtendu
		{
			get
			{
				return typeof(CTypeEquipement);
			}
		}

        

		public override sc2i.common.CResultAErreur MyInitChamps()
		{
			CResultAErreur result = base.MyInitChamps();
			if (!result)
				return result;

			if (ObjetEdite is CTypeEquipement)
			{
				m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(ObjetEdite as CTypeEquipement) as CSpvTypeq;
			}

            /*
            if (m_spvTypeq != null)
			{
                //m_gridSiteSPV.SelectedObject = m_spvSite;
				//m_gridSiteSPV.Visible = true;
			}
			else
				//m_gridSiteSPV.Visible = false; 
             * */
            
			return result;
        }//MyInitChamps()

        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            if (m_spvTypeq != null)
            {
            /*  m_spvSite.SiteDomaineIP = c2iTextBoxDomainIP.Text;
                m_spvSite.SiteCmnte = c2iTextBoxCommunity.Text;
                m_spvSite.  = c2iTextBoxMediation.Text;*/
            }

            return result;
        }//MyMajChamps()
	}
}
