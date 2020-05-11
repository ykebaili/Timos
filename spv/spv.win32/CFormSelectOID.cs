using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.data;
using spv.data;
using sc2i.win32.data;

namespace spv.win32
{
    public partial class CFormSelectOID : Form
    {
        private CSpvMibVariable m_variableSel = null;
        public CFormSelectOID()
        {
            InitializeComponent();
        }

        private void CFormSelectOID_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            FillArbre();
        }

        private void FillArbre()
        {
            CListeObjetDonneeGenerique<CSpvFamilleMibmodule> lstFamilles = new CListeObjetDonneeGenerique<CSpvFamilleMibmodule>(CSc2iWin32DataClient.ContexteCourant);
            foreach (CSpvFamilleMibmodule famille in lstFamilles)
            {
                TreeNode node = new TreeNode();
                FillNode(node, famille);
                m_arbre.Nodes.Add(node);
            }
        }

        private void FillNode(TreeNode node, CObjetDonnee objet)
        {
            string strLibelle = "";
            if (objet.GetType() == typeof(CSpvFamilleMibmodule))
            {
                strLibelle = ((CSpvFamilleMibmodule)objet).Libelle;
                node.Nodes.Add("");
                node.BackColor = Color.LightGreen;
            }
            if (objet.GetType() == typeof(CSpvMibmodule))
            {
                node.Nodes.Add("");
                strLibelle = ((CSpvMibmodule)objet).NomModuleOfficiel;
                node.BackColor = Color.LightCyan;
            }
            if (objet.GetType() == typeof(CSpvMibTable))
            {
                strLibelle = ((CSpvMibTable)objet).NomObjetOfficiel;
                node.Nodes.Add("");
                node.BackColor = Color.LightGray;

            }
            if (objet.GetType() == typeof(CSpvMibVariable))
            {
                CSpvMibVariable variable = objet as CSpvMibVariable;
                strLibelle = variable.NomObjetOfficiel;
                node.BackColor = Color.White;
            }
            node.Text = strLibelle;
            node.Tag = objet;
        }

        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                node.Nodes.Clear();
                FillChilds(node);
            }
        }

        private void FillChilds(TreeNode nodeToFill)
        {
            CObjetDonnee objet = nodeToFill.Tag as CObjetDonnee;
            if (objet == null)
                return;
            CSpvFamilleMibmodule famille = objet as CSpvFamilleMibmodule;
            if (famille != null)
            {
                foreach (CSpvFamilleMibmodule sousFamille in famille.FamillesFilles)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, sousFamille);
                    nodeToFill.Nodes.Add(node);
                }
                foreach (CSpvMibmodule sousModule in famille.ModulesMIB)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, sousModule);
                    nodeToFill.Nodes.Add(node);
                }
            }
            CSpvMibmodule module = objet as CSpvMibmodule;
            if (module != null)
            {
                foreach (CSpvMibTable sousTable in module.Tables)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, sousTable);
                    nodeToFill.Nodes.Add(node);
                }
                foreach (CSpvMibVariable sousVariable in module.VariablesScalaires)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, sousVariable);
                    nodeToFill.Nodes.Add(node);
                }
            }

            CSpvMibTable table = objet as CSpvMibTable ;
            if (table != null)
            {
                foreach (CSpvMibVariable variable in table.Variables)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, variable);
                    nodeToFill.Nodes.Add(node);
                }
            }
            m_arbre.Sort();
        }

        public static CSpvMibVariable SelectVariable()
        {
            CFormSelectOID form = new CFormSelectOID();
            CSpvMibVariable retour = null;
            if (form.ShowDialog() == DialogResult.OK)
            {
                retour = form.m_variableSel;
            }
            form.Dispose();
            return retour;
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_arbre.SelectedNode == null)
                return;
            m_variableSel = m_arbre.SelectedNode.Tag as CSpvMibVariable;
            if (m_variableSel == null)
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
        
    }
}