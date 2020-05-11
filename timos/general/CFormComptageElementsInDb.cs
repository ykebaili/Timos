using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.common;

namespace timos.General
{
    public partial class CFormComptageElementsInDb : Form
    {
        public CFormComptageElementsInDb()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);

        }

        private void CFormComptageElementsInDb_Load(object sender, EventArgs e)
        {
            Init();
        }

        public static void ShowInfos()
        {
            using (CFormComptageElementsInDb frm = new CFormComptageElementsInDb())
            {
                frm.ShowDialog();
            }
        }

        public void Init()
        {
            List<CInfoTypeElementInDb> lst = CCompteurElementsInDb.GetInfosInDatabase(CSessionClient.GetSessionUnique().IdSession);
            lst.Sort((x, y) => x.LibelleTypeElement.CompareTo(y.LibelleTypeElement));
            m_wndListe.BeginUpdate();
            m_wndListe.Items.Clear();
            foreach (CInfoTypeElementInDb info in lst)
            {
                ListViewItem item = new ListViewItem(info.LibelleTypeElement);
                item.SubItems.Add(info.NbElements.ToString());
                item.SubItems.Add(info.NbElementsSupprimes.ToString());
                item.SubItems.Add(info.NbElementsPrevisionnels.ToString());
                m_wndListe.Items.Add(item);
            }
            m_wndListe.EndUpdate();
        }

        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder bl = new StringBuilder();
            bl.Append("Item\tActive\tDeleted\tPrevisionnal");
            bl.Append(Environment.NewLine);
            foreach (ListViewItem item in m_wndListe.Items)
            {
                foreach (ListViewItem.ListViewSubItem sb in item.SubItems)
                {
                    bl.Append(sb.Text);
                    bl.Append("\t");
                }
                bl.Append(Environment.NewLine);
            }
            Clipboard.SetText(bl.ToString());
            MessageBox.Show("Data have been copied to clipboard|20880");
        }

    }
}
