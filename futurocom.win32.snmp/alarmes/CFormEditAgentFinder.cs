using futurocom.snmp;
using futurocom.snmp.alarme;
using futurocom.supervision;
using sc2i.common;
using sc2i.win32.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CFormEditAgentFinder : Form
    {
        private CAgentFinderFromKey m_agentFinder;
        private IBaseTypesAlarmes m_baseTypesAlarme = null;
        private IDefinition m_rootDefinition = null;

        public CFormEditAgentFinder()
        {
            InitializeComponent();
        }

        public static bool EditeAgentFinder(
            CAgentFinderFromKey agentFinder,
            IBaseTypesAlarmes baseTypes,
            IDefinition rootDefinition)
        {
            CFormEditAgentFinder form = new CFormEditAgentFinder();
            form.m_agentFinder = agentFinder;
            form.m_baseTypesAlarme = baseTypes;
            form.m_rootDefinition = rootDefinition;
            bool bResult = form.ShowDialog() == DialogResult.OK;
            form.Dispose();
            return bResult;
        }

        private void CFormEditAgentFinder_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelAgentFinder.LockEdition = false;
            m_panelAgentFinder.Init(m_agentFinder, m_baseTypesAlarme, m_rootDefinition);
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = m_panelAgentFinder.MajChamps();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
