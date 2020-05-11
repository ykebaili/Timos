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

namespace spv.win32
{
    public partial class CExtenderFormTypeqSnmpTables : CExtendeurFormEditionStandardTabPage
    {
        private CSpvTypeq m_spvTypeq = null;

        public CExtenderFormTypeqSnmpTables()
        {
            InitializeComponent();
            Title = I.T("Snmp Tables|50007");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CTypeEquipement);
            }
        }

        protected CTypeEquipement TypeEquipement
        {
            get
            {
                return ObjetEdite as CTypeEquipement;
            }
        }


        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CTypeEquipement)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(ObjetEdite as CTypeEquipement) as CSpvTypeq;
            }

            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            
            if (result && m_spvTypeq != null)
            {
                m_PanelTypeSnmpTables.InitFromListeObjets(
                m_spvTypeq.SousFamillesSnmpIncluses,
                typeof(CSpvTypeqinc),
                typeof(CFormEditionTableSnmp),
                m_spvTypeq,
                "TypeEquipementEnglobant");
            }

            return result;
        }//MyInitChamps()


        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            return result;
        }//MyMajChamps()
    }
}

