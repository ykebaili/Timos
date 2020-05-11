using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using sc2i.common.memorydb;
using TimosInventory.data;

namespace TimosInventory
{
    public partial class CFormSetup : Form
    {
        public CFormSetup()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------
        private void CFormSetup_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_txtURL.Text = CTimosInventoryRegistre.TimosServiceURL;
           /* CListeEntitesDeMemoryDb<CChampCustom> lst = new CListeEntitesDeMemoryDb<CChampCustom>(CTimosInventoryDb.GetTimosDatas());
            lst.Filtre = new CFiltreMemoryDb(CChampCustom.c_champCodeRole + "=@1",
                CEquipement.c_roleChampCustom);
            HashSet<string> setSels = new HashSet<string>();
            foreach (string nId in CTimosInventoryRegistre.IdChampsReleve)
                setSels.Add(nId);
            m_wndListeChamps.BeginUpdate();
            foreach (CChampCustom champ in lst)
            {
                ListViewItem item = new ListViewItem(champ.Nom);
                item.Tag = champ;
                item.Checked = setSels.Contains(champ.Id);
                m_wndListeChamps.Items.Add(item);
            }
            m_wndListeChamps.EndUpdate();*/
        }

        //---------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_txtURL.Text != CTimosInventoryRegistre.TimosServiceURL)
            {
                InventoryService.InventoryService service = new TimosInventory.InventoryService.InventoryService();
                bool bOk = false;
                string strErrorMes = "";

                CFormWaiting.DoWork((DoWorkDelegate)delegate(CFormWaiting waiter)
                {
                    try
                    {
                        waiter.ReportProgress(I.T("Trying URL|20054"));
                        service.Url = m_txtURL.Text;
                        int nId = service.OpenSession();
                        service.CloseSession(nId);
                        bOk = true;
                    }
                    catch (Exception ex)
                    {
                        strErrorMes = ex.ToString();
                    }
                });
                if (!bOk &&
                MessageBox.Show(I.T("Can not connect to URL. Change settings anyway ?(@1)|20053", strErrorMes),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                CTimosInventoryRegistre.TimosServiceURL = m_txtURL.Text;
            }
            /*List<string> lstIdsChamps = new List<string>();
            foreach (ListViewItem item in m_wndListeChamps.CheckedItems)
            {
                CChampCustom champ = item.Tag as CChampCustom;
                if (champ != null)
                    lstIdsChamps.Add(champ.Id);
            }
            CTimosInventoryRegistre.IdChampsReleve = lstIdsChamps.ToArray();*/
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static void SetupApplication()
        {
            CFormSetup frm = new CFormSetup();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
