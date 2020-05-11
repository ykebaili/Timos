using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.alarme;
using sc2i.win32.common;
using sc2i.common;
using futurocom.supervision;
using futurocom.snmp;
using futurocom.snmp.dynamic;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CFormEditeTrapHandler : Form
    {
        private CTrapHandler m_handler;
        private IBaseTypesAlarmes m_baseTypesAlarme = null;
        private IDefinition m_rootDefinition = null;

        public CFormEditeTrapHandler()
        {
            InitializeComponent();
        }

        public static bool EditeTrapHandler(
            CTrapHandler handler, 
            IBaseTypesAlarmes baseTypes,
            IDefinition rootDefinition)
        {
            CFormEditeTrapHandler form = new CFormEditeTrapHandler();
            form.m_handler = handler;
            form.m_baseTypesAlarme = baseTypes;
            form.m_rootDefinition = rootDefinition;
            bool bResult = form.ShowDialog() == DialogResult.OK;
            form.Dispose();
            return bResult;
        }

        private void CFormEditeTrapHandler_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelHandler.LockEdition = false;
            m_panelHandler.Init(m_handler, m_baseTypesAlarme, m_rootDefinition);
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = m_panelHandler.MajChamps();
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
