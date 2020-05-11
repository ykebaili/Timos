using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using futurocom.snmp.Mib;
using futurocom.snmp;

namespace TestSnmp
{
    public partial class CFormMib : Form
    {
        public CFormMib()
        {
            InitializeComponent();
            Reinit();
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Mib project|*.mibprj|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CProjetMib.Load(dlg.FileName))
                    Reinit();
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Mib project|*.mibprj|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CResultAErreur result = CProjetMib.Save(dlg.FileName);
                if ( !result )
                    MessageBox.Show(result.Erreur.ToString() );
            }
        }

        private void Reinit()
        {
            CProjetMib.Instance.ReloadMibs();
            ObjectRegistryBase laBase = CProjetMib.Instance.Mib;
            if (laBase != null)
                m_mibBrowser.Init(laBase.Tree.Root, CSnmpConnexion.DefaultInstance);
            m_wndListeModules.Items.Clear();
            foreach (string strModule in CProjetMib.Instance.LoadedModules)
                m_wndListeModules.Items.Add(strModule);
            foreach (string strModule in CProjetMib.Instance.MissingModules)
                m_wndListeModules.Items.Add("?" + strModule + "?");
        }

        private void m_btnAddModule_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Fichier mib|*.mib|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CProjetMib.Instance.AddString(dlg.FileName);
                Reinit();
            }
        }
    }
}
