using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using spv.data;
using sc2i.data;
using timos.data;

namespace spv.win32
{
    public partial class CFormTestSpvGraph : Form
    {
        private CSpvSchemaReseau m_spvSchema = null;
        public CFormTestSpvGraph()
        {
            InitializeComponent();
        }

        public static void ShowArbreSpv(CSpvSchemaReseau spvSchema)
        {
            CFormTestSpvGraph form = new CFormTestSpvGraph();
            form.m_spvSchema = spvSchema;
            form.ShowDialog();
            form.Dispose();
        }

        //-------------------------------------------------------------
        private void CFormTestSpvGraph_Load(object sender, EventArgs e)
        {
            m_arbre.Nodes.Clear();
            CListeObjetsDonnees lst = m_spvSchema.ElementsDeGraphe;
            CSpvElementDeGraphe elt = new CSpvElementDeGraphe(m_spvSchema.ContexteDonnee);
            if (!elt.ReadIfExists(new CFiltreData(CSpvElementDeGraphe.c_champSensReseau + "=@1 and " +
                CSpvElementDeGraphe.c_champParentId + " is null",
                (int)ESensAllerRetourLienReseau.Forward)))
                return;
            elt = elt.GetElementDuBonType();
            if (elt != null)
            {
                TreeNode node = CreateNode(elt);
                m_arbre.Nodes.Add(node);
            }
        }

        private TreeNode CreateNode(CSpvElementDeGraphe elt)
        {
            TreeNode node = new TreeNode(elt.GetStringDebugDescription());
            node.Tag = elt;
            if (elt.ElementsFils.Count > 0)
                node.Nodes.Add(new TreeNode(""));
            return node;
        }

        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
            {
                node.Nodes.Clear();
                CSpvElementDeGraphe elt = node.Tag as CSpvElementDeGraphe;
                foreach (CSpvElementDeGraphe eltFils in elt.ElementsFils)
                {
                    TreeNode nodeFils = CreateNode(eltFils);
                    node.Nodes.Add(nodeFils);
                }
            }
        }
            
    }
}
