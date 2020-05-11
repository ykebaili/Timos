using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.data;
using timos.data;

namespace timos
{
    public partial class CFormSelectObjetHierarchique : Form
    {
		Type m_typeObjets = null;
		CObjetHierarchique m_racine = null;
		List<CObjetHierarchique> m_listeChecked = null;

		Hashtable m_tableObjetToNode = new Hashtable();

        public CFormSelectObjetHierarchique()
        {
            InitializeComponent();
        }

        public static CObjetHierarchique SelectObjet( Type typeObjet, CObjetHierarchique racine )
        {
            CFormSelectObjetHierarchique form = new CFormSelectObjetHierarchique();
			form.m_racine = racine;
			form.m_typeObjets = typeObjet;
			CObjetHierarchique objetSel = null;
            if (form.ShowDialog() == DialogResult.OK)
            {
                TreeNode node = form.m_arbre.SelectedNode;
                if (node != null)
                {
					objetSel = (CObjetHierarchique)node.Tag;
                }
            }
			form.Dispose();
            return objetSel;
        }

		public static CObjetHierarchique[] SelectObjets(
			Type typeObjet, 
			CObjetHierarchique racine,
			CObjetHierarchique[] listeSelectionnees)
		{
			CFormSelectObjetHierarchique form = new CFormSelectObjetHierarchique();
			form.m_racine = racine;
			form.m_typeObjets = typeObjet;
			form.m_arbre.CheckBoxes = true;
			form.m_listeChecked = new List<CObjetHierarchique>(listeSelectionnees);
			CObjetHierarchique[] retour = null;
			if (form.ShowDialog() == DialogResult.OK)
			{
				retour = form.GetObjetsSelectionnes().ToArray();
			}
			form.Dispose();
			return retour;
		}

		//----------------------------------------------------------------------------
		private List<CObjetHierarchique> GetObjetsSelectionnes()
		{
			List<CObjetHierarchique> lst = new List<CObjetHierarchique>();
			AddCheckedNodes(m_arbre.Nodes, lst);
			return lst;
		}

		//----------------------------------------------------------------------------
		private void AddCheckedNodes(TreeNodeCollection nodes, List<CObjetHierarchique> lst)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
					lst.Add((CObjetHierarchique)node.Tag);
				AddCheckedNodes(node.Nodes, lst);
			}
		}
		//----------------------------------------------------------------------------
		private void CFormSelectObjetHierarchique_Load(object sender, EventArgs e)
        {
			CWin32Traducteur.Translate(this);
            CListeObjetsDonnees liste;
			if (m_racine == null)
			{
				liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, m_typeObjets);
				CObjetHierarchique objetTmp = (CObjetHierarchique)Activator.CreateInstance(m_typeObjets, new object[] { CSc2iWin32DataClient.ContexteCourant });
				liste.Filtre = new CFiltreData(objetTmp.ChampNiveau + "=@1", 0);
			}
			else
			{
				liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, m_typeObjets);
				liste.Filtre = new CFiltreData ( m_racine.GetChampId()+"=@1", m_racine.Id );
			}
				
            foreach (CObjetHierarchique objet in liste)
            {
				TreeNode node = CreateNode(objet);
                m_arbre.Nodes.Add(node);
				node.Expand();
            }

			if (m_listeChecked != null)
			{
				foreach (CObjetHierarchique objet in m_listeChecked)
				{
					TreeNode node = GetNode(objet);
					if (node != null)
					{
						node.Checked = true;
						node = node.Parent;
						while (node != null)
						{
							node.Expand();
							node = node.Parent;
						}
					}
				}
			}


        }

        //----------------------------------------------------------------------------
        private TreeNode CreateNode(CObjetHierarchique objet)
        {
            TreeNode node = new TreeNode(objet.Libelle);
            node.Tag = objet;
			m_tableObjetToNode[objet] = node;
			if ( m_listeChecked != null )
				if ( m_listeChecked.Contains ( objet ) )
					node.Checked = true;
            if (objet.ObjetsFils.Count != 0)
            {
                TreeNode dummy = new TreeNode("");
                dummy.Tag = null;
                node.Nodes.Add(dummy);
            }
            return node;
        }

		//----------------------------------------------------------------------------
		private TreeNode GetNode(CObjetHierarchique objet)
		{
			TreeNode node = (TreeNode)m_tableObjetToNode[objet];
			if (node != null)
				return node;
			node = CreateNode(objet);
			if (objet.ObjetParent == null)
			{
				m_arbre.Nodes.Add(node);
				node.Expand();
				return node;
			}
			TreeNode nodeParent = GetNode(objet);
			if (nodeParent != null)
			{
				nodeParent.Expand();
				return (TreeNode)m_tableObjetToNode[objet];
			}
			return null;
		}
				


        //----------------------------------------------------------------------------
        private void m_arbre_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count > 0 && node.Nodes[0].Tag == null)
            {
                //il faut reremplir ce noeud
                node.Nodes.Clear();
                CListeObjetsDonnees listeObjets = null;
                listeObjets = ((CObjetHierarchique)node.Tag).ObjetsFils;
                if (listeObjets != null)
                {
                    foreach (CObjetHierarchique objet in listeObjets)
                    {
                        TreeNode newNode = CreateNode(objet);
                        node.Nodes.Add(newNode);
                    }
                }
            }

        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_arbre.SelectedNode != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }


    }
}