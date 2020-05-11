using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosInventory.data;
using sc2i.win32.common;
using sc2i.common.memorydb;

namespace TimosInventory
{
    public partial class CFormDetailSite : Form
    {
        private CSite m_site = null;
        public CFormDetailSite()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        public static void ShowSite(CSite site)
        {
            CFormDetailSite form = new CFormDetailSite();
            form.Init(site);
            form.ShowDialog();
            form.Dispose();
        }

        private void Init(CSite site)
        {
            m_site = site;
            m_lblNomSite.Text = m_site.Libelle;
            FillListeChildSite();
            FillEquipements();
        }

        private void FillListeChildSite()
        {
            m_wndListeSites.BeginUpdate();
            m_wndListeSites.Items.Clear();
            if (m_site.SiteParent != null)
            {
                ListViewItem item = new ListViewItem("...");
                item.Tag = m_site.SiteParent;
                m_wndListeSites.Items.Add(item);
            }
            foreach (CSite site in m_site.SitesFils)
            {
                ListViewItem item = new ListViewItem(site.Libelle);
                item.Tag = site;
                m_wndListeSites.Items.Add(item);
            }
            m_wndListeSites.EndUpdate();
        }

        private void FillEquipements()
        {
            m_arbreEquipements.BeginUpdate();
            m_arbreEquipements.Nodes.Clear();
            CListeEntitesDeMemoryDb<CEquipement> lstEqts = m_site.Equipements;
            lstEqts.Sort = CEquipement.c_champCoordonnee;
            lstEqts.Filtre = new CFiltreMemoryDb(CEquipement.c_champIdEquipementContenant + " is null");
            lstEqts.Sort = CEquipement.c_champCoordonnee + ", " + CTypeEquipement.c_champId;
            List<TreeNode> lstNodes = new List<TreeNode>();
            foreach (CEquipement eqpt in lstEqts)
            {
                TreeNode node = CreateNodeEquipement(eqpt);
                lstNodes.Add(node);
            }
            m_arbreEquipements.Nodes.AddRange(lstNodes.ToArray());
            m_arbreEquipements.EndUpdate();

        }

        private TreeNode CreateNodeEquipement(CEquipement eqpt)
        {
            CParametrageSystemeCoordonnees sc = eqpt.ParametrageCoordonneesApplique;
            TreeNode node = new TreeNode(eqpt.Coordonnee+" "+eqpt.TypeEquipement.Libelle + " " + eqpt.NumeroSerie);
            node.Tag = eqpt;
            if (eqpt.EquipementsContenus.Count() > 0)
            {
                TreeNode dummy = new TreeNode();
                node.Nodes.Add(dummy);
            }
            return node;
        }



       
        private void CFormDetailSite_Load(object sender, EventArgs e)
        {

        }

        private void m_wndListeSites_Click(object sender, EventArgs e)
        {
            ListView wndListe = sender as ListView;
            if (wndListe == null)
                return;
            if (wndListe.SelectedItems.Count == 1)
            {
                ListViewItem item = m_wndListeSites.SelectedItems[0];
                CSite site = item.Tag as CSite;
                if (site != null)
                    Init(site);
            }
        }

        private void m_arbreEquipements_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                CEquipement eqpt = e.Node.Tag as CEquipement;
                List<TreeNode> lstNodes = new List<TreeNode>();
                CListeEntitesDeMemoryDb<CEquipement> eqpts = eqpt.EquipementsContenus;
                eqpts.Sort = CEquipement.c_champCoordonnee;
                foreach (CEquipement fils in eqpts)
                {
                    TreeNode node = CreateNodeEquipement(fils);
                    lstNodes.Add(node);
                }
                e.Node.Nodes.AddRange(lstNodes.ToArray());
            }
        }

        private void m_btnStartSurvey_Click(object sender, EventArgs e)
        {
            CFormReleveSite.StartReleve(m_site);
        }

        private void m_btnQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
