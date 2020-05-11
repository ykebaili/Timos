using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.data;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
    public partial class CExtenderFormEquipmentPorts : CExtendeurFormEditionStandardTabPage
    {
        private CSpvEquip m_spvEquip = null;

        public CExtenderFormEquipmentPorts()
        {
            InitializeComponent();
            Title = I.T("Ports|50010");
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
                m_PanelAlarmPorts.InitFromListeObjets(
                m_spvEquip.AlarmesCablesBouclesAndTrap,
                typeof(CSpvLienAccesAlarme),
                typeof(CFormEditionAccesAlarmeEquipement),
                m_spvEquip,
                "SpvEquip");
                /*
                m_PanelTransmissionPorts.InitFromListeObjets(
                m_spvEquip.AccesTransmission,
                typeof(CSpvAccesTrans),
                typeof(CFormEditionAccesTrans),
                m_spvEquip,
                "SpvEquip");*/
            }

            return result;
        }//MyInitChamps()


        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            return result;
        }

        private void m_buttonStartAlarm_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvLienAccesAlarme spvLien = (CSpvLienAccesAlarme) m_PanelAlarmPorts.ElementSelectionne;
            if (spvLien != null)
            {
                result = spvLien.ProvoquerAlarme();
                if (!result)
                    CFormAlerte.Afficher(result); 
            }

        }//MyMajChamps()
    }
}

