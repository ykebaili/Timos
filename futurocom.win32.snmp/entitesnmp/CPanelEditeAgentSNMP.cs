using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.entitesnmp;
using futurocom.snmp;
using sc2i.common;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CPanelEditeAgentSNMP : UserControl
    {
        private CAgentSnmpPourSupervision m_agent = null;


        public CPanelEditeAgentSNMP()
        {
            InitializeComponent();
        }

        public void Init(CAgentSnmpPourSupervision agent)
        {
            m_agent = agent;
            InitChamps();
        }

        public void InitChamps()
        {
            m_txtAgentIP.Text = m_agent.Ip;
            m_txtCommunaute.Text = m_agent.Communaute;
            m_txtPort.IntValue = m_agent.SnmpPort;
            m_cmbVersion.Items.Clear();
            foreach (VersionCode code in Enum.GetValues(typeof(VersionCode)))
                m_cmbVersion.Items.Add(code);
            m_cmbVersion.SelectedItem = m_agent.SnmpVersion;

            FillEntites();
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_agent.Ip = m_txtAgentIP.Text;
            m_agent.Communaute = m_txtCommunaute.Text;
            m_agent.SnmpPort = m_txtPort.IntValue == null ? 0 : m_txtPort.IntValue.Value;
            if (m_cmbVersion.SelectedItem is VersionCode)
                m_agent.SnmpVersion = (VersionCode)m_cmbVersion.SelectedItem;
            return result;
        }

        private void FillEntites()
        {
            m_tabControl.TabPages.Clear();

            if (m_agent.TypeAgent == null)
                return;
            foreach (CTypeEntiteSnmpPourSupervision typeEntite in m_agent.TypeAgent.TypesEntites)
            {
                Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage();
                page.Title = typeEntite.Libelle;
                m_tabControl.TabPages.Add(page);
            }

        }

        private void m_txtPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
