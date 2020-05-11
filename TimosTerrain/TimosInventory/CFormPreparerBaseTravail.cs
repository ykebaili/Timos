using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.common.memorydb;
using TimosInventory.data;
using sc2i.win32.common;
using System.Threading;

namespace TimosInventory
{
    public partial class CFormPreparerBaseTravail : Form
    {
        private static CMemoryDb m_dbDeconnectee = null;

        public CFormPreparerBaseTravail()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        private void m_btnConnect_Click(object sender, EventArgs e)
        {
            using (CWaitCursor waiter = new CWaitCursor())
            {
                CFormWaiting.DoWork(new DoWorkDelegate(RecupereListeSites));
            }
        }


        //-------------------------------------------------------------------
        private void RecupereListeSites(CFormWaiting waiter)
        {
            try
            {
                waiter.ReportProgress (I.T("Connecting to Timos|20009"));
                InventoryService.InventoryService service = new TimosInventory.InventoryService.InventoryService();
                service.Url = CTimosInventoryRegistre.TimosServiceURL;
                int nIdSession = service.OpenSession();
                if (nIdSession < 0)
                {
                    waiter.ShowError(I.T("Can not open distant session|20001"));
                    return;
                }
                waiter.ReportProgress(I.T("Import site list...|20010"));
                DataSet ds = service.GetReferencesSites(nIdSession);
                service.CloseSession(nIdSession);
                CMemoryDb db = CMemoryDb.FromDataSet(ds);
                m_dbDeconnectee = db;
                UpdateArbre(waiter);
            }
            catch (Exception e)
            {
                waiter.ShowError(I.T("Error while transfering data|20008"));
                return;
            }
            finally
            {
            }
        }

        //-------------------------------------------------------------------
        public void UpdateArbre(CFormWaiting waiter)
        {
            if (m_dbDeconnectee == null)
            {
                RecupereListeSites(waiter);
            }
            if (m_dbDeconnectee == null)
                return;
            waiter.ReportProgress(I.T("Loading data...|20012"));
            CListeEntitesDeMemoryDb<CSite> lstSites = new CListeEntitesDeMemoryDb<CSite>(m_dbDeconnectee);
            lstSites.Filtre = new CFiltreMemoryDb(CSite.c_champIdSiteParent + " is null");
            lstSites.Sort = CSite.c_champLibelle;
            Invoke((MethodInvoker)delegate
            {
                m_arbreSites.BeginUpdate();
                m_arbreSites.Nodes.Clear();
            });
            List<TreeNode> lstNodes = new List<TreeNode>();
            foreach (CSite site in lstSites)
            {
                TreeNode node = CreateNodeSite(site);
                lstNodes.Add(node);
            }
            Invoke((MethodInvoker)delegate
            {
                m_arbreSites.Nodes.AddRange(lstNodes.ToArray());
                m_arbreSites.EndUpdate();
            });

        }

        //-------------------------------------------------------------------
        private TreeNode CreateNodeSite(CSite site)
        {
            TreeNode node = new TreeNode(site.Libelle);
            node.ImageIndex = 0;
            node.Tag = site;
            if (site.SitesFils.Count() > 0)
            {
                TreeNode dummy = new TreeNode();
                node.Nodes.Add(dummy);
            }
            return node;
        }

        //-------------------------------------------------------------------
        private void m_arbreSites_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                CSite site = e.Node.Tag as CSite;
                if (site != null)
                {
                    foreach (CSite siteFils in site.SitesFils)
                    {
                        TreeNode childNode = CreateNodeSite(siteFils);
                        e.Node.Nodes.Add(childNode);
                    }
                }
            }
        }

        //-------------------------------------------------------------------
        private List<TreeNode> CheckedNodes()
        {
            List<TreeNode> lstNodes = new List<TreeNode>();
            FillCheckedNodes ( lstNodes, m_arbreSites.Nodes );
            return lstNodes;
        }

        //-------------------------------------------------------------------
        private void FillCheckedNodes(List<TreeNode> lstNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    lstNodes.Add(node);
                else
                    FillCheckedNodes(lstNodes, node.Nodes);
            }
        }


        //-------------------------------------------------------------------
        private void UpdateListeSelectionnés()
        {
            m_wndListeSelectionnes.BeginUpdate();
            m_wndListeSelectionnes.Items.Clear();
            foreach (TreeNode node in CheckedNodes())
            {
                CSite site = node.Tag as CSite;
                if (site != null)
                {
                    ListViewItem item = new ListViewItem(site.Libelle);
                    item.Tag = site;
                    item.ImageIndex = 0;
                    item.StateImageIndex = 0;
                    m_wndListeSelectionnes.Items.Add(item);
                }
            }
            m_wndListeSelectionnes.EndUpdate();
        }

        //-------------------------------------------------------------------
        private void m_arbreSites_AfterCheck(object sender, TreeViewEventArgs e)
        {
            UpdateListeSelectionnés();
        }

        //-------------------------------------------------------------------
        private void m_arbreSites_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!e.Node.Checked && e.Node.Parent != null)
            {
                e.Cancel = true;
                e.Node.Parent.Checked = true;
            }
        }

        //-------------------------------------------------------------------
        private void m_btnCreerBase_Click(object sender, EventArgs e)
        {
            bool bMajOk = false;
            CFormWaiting.DoWork((DoWorkDelegate)delegate(CFormWaiting waiter)
            {
                List<int> lstIds = new List<int>();
                foreach (TreeNode node in CheckedNodes())
                {
                    CSite site = node.Tag as CSite;
                    if (site != null && site.IdTimos != null)
                        lstIds.Add(site.IdTimos.Value);
                }
                if (lstIds.Count == 0)
                {
                    waiter.ShowError(I.T("You should select sites you want to import|20004"));
                    return;
                }
                try
                {
                    waiter.ReportProgress( I.T("Connecting to Timos|20009"));
                    InventoryService.InventoryService service = new TimosInventory.InventoryService.InventoryService();
                    service.Url = CTimosInventoryRegistre.TimosServiceURL;
                    int nIdSession = service.OpenSession();
                    if (nIdSession < 0)
                    {
                        waiter.ShowError(I.T("Can not open distant session|20001"));
                        return;
                    }
                    
                    DateTime dt = DateTime.Now;
                    waiter.ReportProgress(I.T("Updating configuration data|20015"));
                    DataSet ds = service.GetBaseConfig(nIdSession);
                    
                    CMemoryDb db = CMemoryDb.FromDataSet(ds);

                    waiter.ReportProgress(I.T("Importing @1 site(s)|20011", lstIds.Count.ToString()));
                    ds = service.GetSites(nIdSession, lstIds.ToArray());

                    db.EnforceConstraints = false;
                    ds.EnforceConstraints = false;

                    CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CSite.c_nomTable],
                        db);
                    CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CParametrageSystemeCoordonnees.c_nomTable],
                        db);
                    CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CParametrageNiveau.c_nomTable], db);

                    CListeEntitesDeMemoryDb<CSite> lstSites = new CListeEntitesDeMemoryDb<CSite>(db);
                    foreach (CSite site in lstSites)
                    {
                        if (site.IdTimos != null)
                        {
                            waiter.ReportProgress(I.T("Import site @1 details|20016", site.Libelle));
                            ds = service.GetEquipments(nIdSession, site.IdTimos.Value);
                            CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CEquipement.c_nomTable],
                                db);
                            CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CParametrageSystemeCoordonnees.c_nomTable],
                        db);
                            CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CParametrageNiveau.c_nomTable], db);
                            CImporteurDataTimos.IntegreTableDepuisTimos(ds.Tables[CRelationEquipementChampCustom.c_nomTable],
                                db);
                        }
                    }
                    
                    db.EnforceConstraints = true;
                    
                    service.CloseSession(nIdSession);
                    TimeSpan sp = DateTime.Now - dt;
                    Console.WriteLine("Récupère sites : " + sp.TotalMilliseconds);
                    
                    CTimosInventoryDb.SetDbTimos(db);
                    CTimosInventoryRegistre.DateDonneesTimos = DateTime.Now;
                    bMajOk = true;
                }
                catch (Exception ex)
                {
                    waiter.ShowError(ex.ToString());
                    return;
                }
                finally
                {
                }
            });
            if (bMajOk)
                Close();
        }

        private void AsyncUpdateArbre()
        {
            while (!IsHandleCreated)
                System.Threading.Thread.Sleep(100);
            this.Invoke((MethodInvoker)delegate
            {
                Refresh();
                CFormWaiting.DoWork(new DoWorkDelegate(UpdateArbre));
            });
        }

        //------------------------------------------
        private void CFormPreparerBaseTravail_Load(object sender, EventArgs e)
        {
            Refresh();
            CFormWaiting.DoWork(new DoWorkDelegate(UpdateArbre));
        }

        private void m_btnConnect_Click_1(object sender, EventArgs e)
        {
            CFormWaiting.DoWork(new DoWorkDelegate(RecupereListeSites));
        }

        private void m_btnQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
