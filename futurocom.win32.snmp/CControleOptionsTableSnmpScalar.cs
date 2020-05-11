using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.easyquery;
using futurocom.snmp.easyquery;
using sc2i.common;
using sc2i.win32.common;

namespace futurocom.win32.snmp
{
    [AutoExec("Autoexec")]
    public partial class CControleOptionsTableSnmpScalar : UserControl, IControlOptionTableDefinition
    {
        private CTableDefinitionSnmpOfScalar m_table = null; 
        public CControleOptionsTableSnmpScalar()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        public static void Autoexec()
        {
            CAllocateurControleOptionTableDefinition.RegistrerControleOption(typeof(CTableDefinitionSnmpOfScalar), typeof(CControleOptionsTableSnmpScalar));
        }

        #region IControlOptionTableDefinition Membres

        public void FillFromTable(ITableDefinition table)
        {
            m_table = table as CTableDefinitionSnmpOfScalar;
            if (m_table != null)
                m_chkOptimiser.Checked = m_table.RemplissageOptimise;
        }

        public sc2i.common.CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_table != null)
                m_table.RemplissageOptimise = m_chkOptimiser.Checked;
            return result;
        }

        #endregion
    }
}
