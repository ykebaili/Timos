using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic.Macro;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using System.Collections;
using sc2i.data;
using timos.General;

namespace timos.macro
{
    public partial class CFormGestionDesMacros : Form
    {
        //------------------------------------------------
        public CFormGestionDesMacros()
        {
            InitializeComponent();
        }

        //------------------------------------------------
        public static void ShowMacros()
        {
            CFormGestionDesMacros frm = new CFormGestionDesMacros();
            frm.ShowDialog();
            frm.Dispose();
        }

        //------------------------------------------------
        private void CFormGestionDesMacros_Load(object sender, EventArgs e)
        {
            FillListe();
        }

        //------------------------------------------------
        private void FillListe()
        {
            m_wndListeMacros.BeginUpdate();
            m_wndListeMacros.Items.Clear();
            foreach (CMacro macro in CListeMacros.Macros)
            {
                ListViewItem item = new ListViewItem(macro.Libelle);
                item.Tag = macro;
                m_wndListeMacros.Items.Add(item);
            }
            m_wndListeMacros.EndUpdate();
        }

        //------------------------------------------------
        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "#Macro|*.FutMacro|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CMacro macro = new CMacro();
                macro.ContexteDonnee = CSc2iWin32DataClient.ContexteCourant;
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(macro, "MACRO", dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
                else
                {
                    CListeMacros.AddMacro(macro);
                    FillListe();
                }
            }
        }

        //------------------------------------------------
        private void m_lnkAdd_LinkClicked(object sender, EventArgs e)
        {
            foreach (IDisposable dis in new ArrayList(m_menuAdd.Items))
            {
                dis.Dispose();
            }
            m_menuAdd.Items.Clear();
            CListeObjetDonneeGenerique<CVersionDonnees> lst = new CListeObjetDonneeGenerique<CVersionDonnees>(CSc2iWin32DataClient.ContexteCourant);
            lst.Filtre = new CFiltreData(CVersionDonnees.c_champTypeVersion + "=@1",
                (int)CTypeVersion.TypeVersion.Previsionnelle);
            foreach (CVersionDonnees version in lst)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(version.Libelle);
                item.Tag = version;
                item.Click += new EventHandler(item_Click);
                m_menuAdd.Items.Add(item);
            }
            if (m_menuAdd.Items.Count > 0)
            {
                m_menuAdd.Show(m_lnkAdd, new Point(0, m_lnkAdd.Height));
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CVersionDonnees version = item != null ? item.Tag as CVersionDonnees : null;
            if (version != null)
            {
                CResultAErreurType<CMacro> res = CMacro.FromVersion(version);
                bool bAdd = res;
                if (!res)
                {
                    if (CFormAlerte.Afficher(res.Erreur) == DialogResult.Ignore)
                        bAdd = true;
                }
                if (bAdd)
                {
                    CListeMacros.AddMacro(res.DataType);
                    FillListe();
                }
            }
        }

        private void m_lnkEdit_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeMacros.SelectedItems.Count == 1)
            {
                ListViewItem item = m_wndListeMacros.SelectedItems[0];
                CMacro macro = item.Tag as CMacro;
                if (macro != null)
                {
                    CFormEditionMacro.EditeMacro(macro);
                    FillListe();
                }
            }

        }

        private void m_lnkRemove_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeMacros.SelectedItems.Count == 1)
            {
                CMacro macro = m_wndListeMacros.SelectedItems[0].Tag as CMacro;
                if (macro != null &&
                    MessageBox.Show(I.T("#Supprimer la macro @1?", macro.Libelle),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CListeMacros.RemoveMacro(macro);
                    FillListe();
                }
            }
        }

        //------------------------------------------------
        
    }
}
