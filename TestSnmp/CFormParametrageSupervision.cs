using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using futurocom.snmp.alarme;
using futurocom.supervision;
using sc2i.win32.common;

namespace TestSnmp
{
    public partial class CFormParametrageSupervision : Form
    {
        public CFormParametrageSupervision()
        {
            InitializeComponent();
        }

        public static void EditeSupervision()
        {
            CFormParametrageSupervision form = new CFormParametrageSupervision();
            form.m_panelSupervision.Init(
                CSnmpConnexion.DefaultInstance,
                CProjetMib.Instance.Mib.Tree.Root,
                        CBaseTypesAlarmes.Instance.BaseTraps,
                        CBaseTypesAlarmes.Instance);
            form.ShowDialog();
            form.Dispose();
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Base de test|*.basetestalrm|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CBaseTypesAlarmes.Load(dlg.FileName))
                {
                    m_panelSupervision.Init(
                        CSnmpConnexion.DefaultInstance,
                        CProjetMib.Instance.Mib.Tree.Root,
                        CBaseTypesAlarmes.Instance.BaseTraps,
                        CBaseTypesAlarmes.Instance);
                }
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Base de test|*.basetestalrm|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CBaseTypesAlarmes.Save(dlg.FileName);
            }
        }

        private void CFormParametrageSupervision_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }
    }
}
