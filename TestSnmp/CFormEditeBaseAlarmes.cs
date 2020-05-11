using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision;
using sc2i.common;
using sc2i.win32.common;

namespace TestSnmp
{
    public partial class CFormEditeBaseAlarmes : Form
    {
        public CFormEditeBaseAlarmes()
        {
            InitializeComponent();
        }

        private void CFormEditeBaseAlarmes_Load(object sender, EventArgs e)
        {
            InitArbre();
        }

        private void InitArbre()
        {
            CTreeViewNodeKeeper keeper = new CTreeViewNodeKeeper( m_arbreAlarmes);
            CBaseTypesAlarmes laBase = CBaseTypesAlarmes.Instance;
            m_arbreAlarmes.Nodes.Clear();
            foreach (ITypeAlarme type in from tp in laBase.TypesAlarmes where tp.TypeParent == null select tp)
            {
                TreeNode node = new TreeNode();
                FillNode(node, type);
                m_arbreAlarmes.Nodes.Add(node);
            }
            keeper.Apply(m_arbreAlarmes);
        }

        private void FillNode(TreeNode node, ITypeAlarme type)
        {
            node.Text = type.Libelle;
            node.Tag = type;
            if (type.TypesFils.Count() > 0 && node.Nodes.Count == 0)
            {
                node.Nodes.Add(new TreeNode());
            }

        }

        private void m_lnkAddType_LinkClicked(object sender, EventArgs e)
        {
            CTestTypeAlarme type = new CTestTypeAlarme();
            if (CFormEditeTypeAlarme.EditeTypeAlarme(type))
            {
                CBaseTypesAlarmes.Instance.AddTypeAlarme(type);
                InitArbre();
            }
        }

        private void m_lnkRemoveType_LinkClicked(object sender, EventArgs e)
        {
            if (m_arbreAlarmes.SelectedNode != null)
            {
                CTestTypeAlarme type = m_arbreAlarmes.SelectedNode.Tag as CTestTypeAlarme;
                if (type != null)
                {
                    type.TypeParent = null;
                    CBaseTypesAlarmes.Instance.RemoveTypeAlarme(type);
                    InitArbre();
                }

            }
        }

        private void m_wndListeTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Base de test|*.basetestalrm|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CBaseTypesAlarmes.Load(dlg.FileName))
                    InitArbre();
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Base de test|*.basetestalrm|Tous fichiers|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CBaseTypesAlarmes.Save(dlg.FileName))
                    InitArbre();
            }
        }

        //---------------------------------------------------------------
        private void m_arbreAlarmes_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null && e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                ITypeAlarme typeAlarme = e.Node.Tag as ITypeAlarme;
                if (typeAlarme != null)
                {
                    foreach (ITypeAlarme typeFils in typeAlarme.TypesFils)
                    {
                        TreeNode node = new TreeNode();
                        FillNode(node, typeFils);
                        e.Node.Nodes.Add(node);
                    }
                }
            }
        }

        private void m_arbreAlarmes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            m_arbreAlarmes.SelectedNode = e.Item as TreeNode;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void m_arbreAlarmes_DragOver(object sender, DragEventArgs e)
        {
            TreeNode node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (node != null && node.Tag is ITypeAlarme)
            {
                ITypeAlarme typeMoved = node.Tag as ITypeAlarme;
                if (typeMoved != null)
                {
                    Point pt = m_arbreAlarmes.PointToClient(new Point(e.X, e.Y));
                    TreeNode nodeDest = m_arbreAlarmes.GetNodeAt(pt);
                    if (nodeDest != null && nodeDest.Tag is ITypeAlarme)
                    {
                        ITypeAlarme type = nodeDest.Tag as ITypeAlarme;
                        bool bOk = true;
                        while (type != null)
                        {
                            if (type == typeMoved)
                                bOk = false;
                            type = type.TypeParent;
                        }
                        if (bOk)
                            e.Effect = DragDropEffects.Move;
                    }
                    if (nodeDest == null)
                        e.Effect = DragDropEffects.Move;

                }
            }
        }

        private void m_arbreAlarmes_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (node != null && node.Tag is ITypeAlarme)
            {
                ITypeAlarme typeMoved = node.Tag as ITypeAlarme;
                if (typeMoved != null)
                {
                    Point pt = m_arbreAlarmes.PointToClient(new Point(e.X, e.Y));
                    TreeNode nodeDest = m_arbreAlarmes.GetNodeAt(pt);
                    if (nodeDest != null && nodeDest.Tag is ITypeAlarme)
                    {
                        ITypeAlarme type = nodeDest.Tag as ITypeAlarme;
                        bool bOk = true;
                        while (type != null)
                        {
                            if (type == typeMoved)
                                bOk = false;
                            type = type.TypeParent;
                        }
                        if (bOk)
                        {
                            typeMoved.TypeParent = nodeDest.Tag as ITypeAlarme;
                            e.Effect = DragDropEffects.Move;
                            InitArbre();
                        }
                    }
                    if (nodeDest== null)
                    {
                        typeMoved.TypeParent = null;
                        e.Effect = DragDropEffects.Move;
                        InitArbre();
                    }
                }
            }
                     
        }

        private void m_arbreAlarmes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ( e.Node != null && e.Node.Tag is ITypeAlarme )
            {
                CTestTypeAlarme type = e.Node.Tag as CTestTypeAlarme;
                if (type != null)
                {
                    if (CFormEditeTypeAlarme.EditeTypeAlarme(type))
                    {
                        FillNode(e.Node, type);
                    }
                }
            }
        }


    }
}
