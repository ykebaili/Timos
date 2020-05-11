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
	public partial class CExtendeurFormEquipement : CExtendeurFormEditionStandardTabPage
	{
        private CSpvEquip m_spvEquip = null;
		public CExtendeurFormEquipement()
		{
			InitializeComponent();
            Title = I.T("Supervision|9");
		}

		public override Type TypeObjetEtendu
		{
			get
			{
                return typeof(CEquipementLogique);
			}
		}

        protected CEquipementLogique Equipement
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
                m_txtBoxIPAddress.Text = m_spvEquip.AdresseIP;
                m_txtBoxSnmpIndex.Text = m_spvEquip.IndexSnmp;
                m_txtBoxSnmpCommunity.Text = m_spvEquip.CommunauteSnmp;
                m_txtBoxEquiptTypeSnmpReference.Text = m_spvEquip.ReferenceSnmpTypeEquipement;
                m_txtBoxMediationEquipment.Text = m_spvEquip.EquipementDeMediation;
                m_chkToRediscover.Checked = m_spvEquip.ARedecouvrirPeriodiquement;
                m_chkToSurv.Checked = m_spvEquip.ASuperviser;
            }
            else
            {
                m_txtBoxIPAddress.Text = "";
                m_txtBoxSnmpIndex.Text = "";
                m_txtBoxSnmpCommunity.Text = "";
                m_txtBoxEquiptTypeSnmpReference.Text = "";
                m_txtBoxMediationEquipment.Text = "";
                m_chkToRediscover.Checked = false;
                m_chkToSurv.Checked = false;
            }

            return result;
        }

        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            if (Equipement != null && m_spvEquip == null && m_extModeEdition.ModeEdition)
            {
                m_spvEquip = CSpvEquip.GetSpvEquipFromEquipementAvecCreation(Equipement);
            }

            m_spvEquip.AdresseIP = m_txtBoxIPAddress.Text;
            m_spvEquip.IndexSnmp = m_txtBoxSnmpIndex.Text;
            m_spvEquip.CommunauteSnmp = m_txtBoxSnmpCommunity.Text;
            m_spvEquip.ReferenceSnmpTypeEquipement = m_txtBoxEquiptTypeSnmpReference.Text;
            m_spvEquip.EquipementDeMediation = m_txtBoxMediationEquipment.Text;
            m_spvEquip.ARedecouvrirPeriodiquement = m_chkToRediscover.Checked;
            m_spvEquip.ASuperviser = m_chkToSurv.Checked;

            return result;
        }
	}
}
