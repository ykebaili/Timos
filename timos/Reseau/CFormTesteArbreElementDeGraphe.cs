using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.reseau.arbre_operationnel;

namespace timos.Reseau
{
    public partial class CFormTesteArbreElementDeGraphe : Form
    {
        public CFormTesteArbreElementDeGraphe()
        {
            InitializeComponent();
        }

        public void Init(CArbreOperationnel arbre)
        {
            m_arbre.Nodes.Clear();
            CreateNode(arbre.ElementRacine, m_arbre.Nodes);
        }

        private void CreateNode ( CElementDeArbreOperationnel element, TreeNodeCollection nodes )
        {
            
            TreeNode node = new TreeNode();
            FillNode ( node, element );
            nodes.Add ( node );
            foreach ( CElementDeArbreOperationnel elt in element.Fils )
            {
                CreateNode ( elt, node.Nodes );
            }
        }

        private void FillNode(TreeNode node, CElementDeArbreOperationnel element)
        {
            string strText = element.ToString().Split('\n')[0] + " ";
            if (element.ElementParent != null)
            {
                strText += "(" + element.ElementParent.ToString().Split('\n')[0] + ")";
            }
            strText += (element.CoeffOperationnel).ToString("0.##%");
            node.Text = strText;
            node.Tag = element;
        }

        private void ChangeCoefOperationnel(TreeNode node, double value)
        {
            CElementDeArbreOperationnel elt = node.Tag as CElementDeArbreOperationnel;
            if (elt != null)
            {
                elt.SetCoeffOperationnel(value);
            }
            if (elt.ElementParent != null)
            {
                elt.ElementParent.RecalculeCoefOperationnelFromChilds();
            }
            while (node != null)
            {
                FillNode(node, node.Tag as CElementDeArbreOperationnel);
                node = node.Parent;
            }
        }

        private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfficheNode(e.Node);
        }

        private TreeNode m_nodeAffiche = null;
        private void AfficheNode(TreeNode node)
        {

            CElementDeArbreOperationnel elt = node.Tag as CElementDeArbreOperationnel;
            if (elt == null)
            {
                m_panelDroite.Visible = false;
                return;
            }
            m_panelDroite.Visible = true;
            m_lblNode.Text = elt.ToString();
            m_txtCoeff.DoubleValue = elt.CoeffOperationnel;
            m_nodeAffiche = node;
        }

        private void m_btnAppliquer_Click(object sender, EventArgs e)
        {
            if (m_nodeAffiche != null && m_txtCoeff.DoubleValue != null)
            {
                ChangeCoefOperationnel(m_nodeAffiche, m_txtCoeff.DoubleValue.Value);
            }
        }

        public static void AfficheArbre(CArbreOperationnel arbre)
        {
            CFormTesteArbreElementDeGraphe form = new CFormTesteArbreElementDeGraphe();
            form.Init(arbre);
            form.ShowDialog();
            form.Dispose();
        }





    }
}
