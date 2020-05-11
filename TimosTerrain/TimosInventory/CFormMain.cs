using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common.memorydb;
using TimosInventory.data;
using sc2i.win32.common;
using TimosInventory.data.releve;
using sc2i.common;

namespace TimosInventory
{
    public partial class CFormMain : Form
    {
        public CFormMain()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        private void CFormMain_Load(object sender, EventArgs e)
        {
            InitListeSites();
            InitListeReleves();
#if !DEBUG
            m_btnDebugData.Visible = false;
#endif
        }

        private void InitListeSites()
        {
            DateTime? dt = CTimosInventoryRegistre.DateDonneesTimos;
            if (dt != null)
            {
                m_lblDateData.Text = I.T("Last data sync : @1|20048",dt.Value.ToShortDateString()+" "+
                    dt.Value.ToString("HH:mm"));
            }
            else
                m_lblDateData.Text = "";
            CMemoryDb db = CTimosInventoryDb.GetTimosDatas();
            CListeEntitesDeMemoryDb<CSite> lst = new CListeEntitesDeMemoryDb<CSite>(db);
            m_wndListeSites.BeginUpdate();
            m_wndListeSites.Items.Clear();
            lst.Filtre = new CFiltreMemoryDb(CSite.c_champIdSiteParent + " is null");
            lst.Sort = CSite.c_champLibelle;
            foreach (CSite site in lst)
            {
                ListViewItem item = new ListViewItem(site.Libelle);
                item.Tag = site;
                m_wndListeSites.Items.Add(item);
            }
            m_wndListeSites.EndUpdate();
        }

        private void InitListeReleves()
        {
            CMemoryDb db = CTimosInventoryDb.GetInventaireDatas();
            CListeEntitesDeMemoryDb<CReleveSite> lst = new CListeEntitesDeMemoryDb<CReleveSite>(db);
            m_wndListeReleves.BeginUpdate();
            m_wndListeReleves.Items.Clear();
            lst.Sort = CReleveSite.c_champDate;
            foreach (CReleveSite releve in lst)
            {
                CSite site = releve.Site;
                if (site != null)
                {
                    ListViewItem item = new ListViewItem(site.LibelleComplet);
                    item.Tag = releve;
                    item.Checked = true;
                    m_wndListeReleves.Items.Add(item);
                }
            }
            m_wndListeReleves.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CListeEntitesDeMemoryDb<CReleveSite> lstReleves = new CListeEntitesDeMemoryDb<CReleveSite>(CTimosInventoryDb.GetInventaireDatas());
            if (lstReleves.Count() > 0)
            {
                if (MessageBox.Show(
                    I.T("You have unsent surveys on your computer. It is recommanded to send all surveys before obtain data from Timos. Continue anyway ?|20049"),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            CFormPreparerBaseTravail form = new CFormPreparerBaseTravail();
            form.ShowDialog();
            form.Dispose();
            InitListeSites();
            InitListeReleves();
        }

        private void m_wndListeSites_ItemClick(ListViewItem item)
        {
            CSite site = item.Tag as CSite;
            if (site != null)
            {
                CFormDetailSite.ShowSite(site);
                InitListeReleves();
            }
        }

        private void m_btnDebugData_Click(object sender, EventArgs e)
        {
            CFormViewData.ViewData(CTimosInventoryDb.GetTimosDatas());
        }

        private void m_wndListeReleves_ItemClick(ListViewItem item)
        {
            CReleveSite rel = item.Tag as CReleveSite;
            if (rel != null && rel.Site != null)
                CFormReleveSite.StartReleve(rel.Site);
        }

        

        //-----------------------------------------------------------------
        private void UpdateLienTransmissionReleves()
        {
            int nNb = m_wndListeReleves.CheckedIndices.Count;
            if (nNb > 0)
            {
                m_lnkEnvoyerReleves.Text = I.T("Send @1 survey(s)|20037", nNb.ToString());
                m_lnkSupprimerReleves.Text = I.T("Delete @1 survey(s)|20039", nNb.ToString());
                m_panelTransmitReleves.Visible = true;
            }
            else
                m_panelTransmitReleves.Visible = false;
        }

        private void m_lnkEnvoyerReleves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            List<CReleveSite> lstReleves = new List<CReleveSite>();
            foreach (ListViewItem item in m_wndListeReleves.CheckedItems)
            {
                CReleveSite rel = item.Tag as CReleveSite;
                if (rel != null)
                    lstReleves.Add(rel);
            }
            List<CReleveSite> lstTransmitted = new List<CReleveSite>();
            CFormWaiting.DoWork((DoWorkDelegate)delegate(CFormWaiting waiter)
            {
                waiter.ReportProgress(I.T("Connecting to Timos|20009"));
                InventoryService.InventoryService service = new TimosInventory.InventoryService.InventoryService();
                service.Url = CTimosInventoryRegistre.TimosServiceURL;
                
                int nIdSession;
                try
                {
                    nIdSession = service.OpenSession();
                    
                    foreach (CReleveSite releve in lstReleves)
                        if (releve != null)
                        {
                            CMemoryDb db = new CMemoryDb();
                            db.EnforceConstraints = false;
                            db.ImporteObjet(releve, true, false);
                            waiter.ReportProgress(I.T("Send survey @1|20038",
                            releve.Site.Libelle));
                            bool bResult = service.SendSurvey(nIdSession, db);
                            if (bResult)
                                lstTransmitted.Add(releve);
                        }
                    foreach (CReleveSite releve in lstTransmitted)
                    {
                        releve.ClearRelevesEquipements();
                        releve.Delete();
                    }
                    service.CloseSession(nIdSession);
                    TimeSpan sp = DateTime.Now - dt;
                    Console.WriteLine("Transmission relevé : " + sp.TotalMilliseconds);
                }
                catch
                {
                    
                }
            });
            CTimosInventoryDb.SetDbInventaire(CTimosInventoryDb.GetInventaireDatas());
            if (lstTransmitted.Count != lstReleves.Count)
            {
                CFormAlerte.Afficher(I.T("Due to unknown error, Some surveys could not be send|20043"));
            }

                    
            InitListeReleves();
        }

        private void m_wndListeReleves_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateLienTransmissionReleves();

        }

        private void m_lnkSupprimerReleves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(I.T("Delete @1 survey(s)|20039", m_wndListeReleves.CheckedItems.Count.ToString() + " ?"),
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ListViewItem item in m_wndListeReleves.CheckedItems)
                {
                    CReleveSite rel = item.Tag as CReleveSite;
                    if (rel != null)
                    {
                        rel.ClearRelevesEquipements();
                        CResultAErreur result = rel.Delete();
                        if (!result)
                        {
                            CFormAlerte.Afficher(result.Erreur);
                            break;
                        }
                    }
                }
                CTimosInventoryDb.GetInventaireDatas().AcceptChanges();
                CTimosInventoryDb.SetDbInventaire(CTimosInventoryDb.GetInventaireDatas());
                InitListeReleves();
            }
        }

        private void m_chkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeReleves.Items)
                item.Checked = true;
        }

        private void m_btnCheckNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeReleves.Items)
                item.Checked = false;
        }

        //----------------------------------------------------------
        private void m_btnSettings_Click(object sender, EventArgs e)
        {
            CFormSetup.SetupApplication();
        }

        private void m_btnQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
