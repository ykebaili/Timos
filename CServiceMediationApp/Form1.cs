using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision;
using futurocom.snmp.mediation;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.Proxy;
using futurocom.snmp;

namespace CServiceMediationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_dataGrid.DataSource = null;
            m_dataGrid.DataSource = CServiceMediation.GetDefaultInstance().Configuration.DataBase;

        }

        private void FillBuilder ( StringBuilder bl, CLocalTypeAlarme ta, int nTab )
        {
            bl.Append("\t\t\t\t\t\t\t\t\t\t\t\t".Substring(0, nTab ));
            bl.AppendLine ( ta.Libelle );
            foreach ( CLocalTypeAlarme tpFils in ta.TypesFils )
                FillBuilder ( bl, tpFils, nTab+1);
        }

        private void m_btnConfiguration_Click(object sender, EventArgs e)
        {
            CSnmpProxyConfiguration config = CSnmpProxyConfiguration.GetInstance();

            if (config != null)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.AppendLine("My SNMP Configuration is :");

                foreach (CSnmpProxy proxy in config.ListeProxy)
                {
                    sBuilder.Append("\t");
                    sBuilder.AppendLine(proxy.NomProxy);

                    foreach (CPlageIP plage in proxy.PlagesIP)
                    {
                        sBuilder.Append("\t\t");
                        sBuilder.AppendLine(plage.ModeleIpString + "/" + plage.Mask.ToString());
                    }
                }

                MessageBox.Show(sBuilder.ToString());

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*StringBuilder bl = new StringBuilder();
            foreach (CAgentSnmpPourSupervision agent in CServiceMediation.GetDefaultInstance().Configuration.Agents)
            {
                bl.AppendLine(agent.Ip);
            }

             MessageBox.Show(bl.ToString());*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*StringBuilder bl = new StringBuilder();
            foreach (CTypeAgentPourSupervision tAgent in CServiceMediation.GetDefaultInstance().Configuration.TypesAgents)
            {
                bl.AppendLine(tAgent.Id);
            }

            MessageBox.Show(bl.ToString());*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CSnmpProxyConfiguration.GetInstance().MiseAJour(true);
            CServiceMediation.GetDefaultInstance().Configuration.MettreAJour(true, true);
        }
    }
}
