using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using sc2i.data;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
    public partial class CExtenderFormEquipmentBoucles : CExtendeurFormEditionStandardTabPage
    {
        private CSpvEquip m_spvEquip = null;

        public CExtenderFormEquipmentBoucles()
        {
            InitializeComponent();
            Title = I.T("Alarm access loop wiring|101");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CEquipementLogique);
            }
        }

        protected CEquipementLogique EquipementLogique
        {
            get
            {
                return ObjetEdite as CEquipementLogique;
            }
        }


        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CEquipementLogique)
            {
                m_spvEquip = CSpvEquip.GetSpvEquipFromEquipement(ObjetEdite as CEquipementLogique) as CSpvEquip;
            }

            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            if (result && m_spvEquip != null)
            {
                m_PanelAlarmWiredPorts.InitFromListeObjets(
                m_spvEquip.AlarmesCablesBoucles,
                typeof(CSpvLienAccesAlarme),
                typeof(CFormEditionCablageAccesAlarmeBoucle),
                m_spvEquip,
                "SpvEquip");
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

