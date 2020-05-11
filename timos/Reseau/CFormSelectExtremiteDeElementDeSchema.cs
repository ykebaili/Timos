using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.workflow;
using timos.data;
using System.Collections;
using sc2i.common;

namespace timos.Reseau
{
    public partial class CFormSelectExtremiteDeElementDeSchema : CFloatingFormBase
    {
        private IElementDeSchemaReseau m_elementDeSchemaRacine = null;
        private IElementALiensReseau m_elementSelectionne = null;
        private IEtapeLienReseau[] m_etapes = null;

        public CFormSelectExtremiteDeElementDeSchema()
        {
            InitializeComponent();
        }

        private void CFormSelectExtremiteDeElementDeSchema_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            FillArbre();
        }

        /// <summary>
        /// Sélectionne une extremité pour l'objet de schéma demandé.
        /// </summary>
        /// <param name="objetDeSchema"></param>
        /// <returns></returns>
        public static IElementALiensReseau SelectExtremite(IElementDeSchemaReseau eltDeSchema, ref IEtapeLienReseau[] etapes)
        {
            if ( eltDeSchema == null )
                return null;
            IEtapeLienReseau etape = eltDeSchema as IEtapeLienReseau;
            IElementALiensReseau eltALien = eltDeSchema as IElementALiensReseau;
            if (etape == null)
                return eltALien;
            IElementALiensReseau[] elementsPossibles = etape.ElementsALiensContenus;
            IEtapeLienReseau[] etapesPossibles = etape.EtapesContenues;
            if (elementsPossibles.Length == 0 && etapesPossibles.Length == 0)
                return eltALien;
            if (eltALien == null && elementsPossibles.Length == 1 && etapesPossibles.Length == 0)
            {
                etapes = new IEtapeLienReseau[] { etape };
                return elementsPossibles[0];
            }
            CFormSelectExtremiteDeElementDeSchema form = new CFormSelectExtremiteDeElementDeSchema();
            form.m_elementDeSchemaRacine = eltDeSchema;
            eltALien = null;
            form.Location = Cursor.Position;
            if (form.ShowDialog() == DialogResult.OK)
            {
                eltALien = form.m_elementSelectionne;
                etapes = form.m_etapes;
            }
            form.Dispose();
            return eltALien;
        }

        private void FillArbre()
        {
            m_arbre.Nodes.Clear();
            TreeNode nodeRacine = CreateNode(m_elementDeSchemaRacine, m_arbre.Nodes);
            nodeRacine.Expand();
            m_arbre.SelectedNode = nodeRacine;
        }

        private TreeNode CreateNode(object element, TreeNodeCollection nodes)
        {
            TreeNode node = null;
            IElementALiensReseau eltALien = element as IElementALiensReseau;
            if (eltALien != null)
            {
                node = new TreeNode(eltALien.Libelle);
                node.Tag = eltALien;
            }
            IEtapeLienReseau etape = element as IEtapeLienReseau;
            if (etape != null)
            {
                if (node == null)
                {
                    node = new TreeNode(etape.Libelle);
                    node.Tag = etape;
                    node.BackColor = Color.LightCyan;
                }
            } 
            if (node == null)
                return null;
            nodes.Add(node);
            if (etape != null)
            {
                TreeNode dummy = new TreeNode("");
                dummy.Tag = null;
                node.Nodes.Add(dummy);
            }
            return node;
        }

        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
            {
                node.Nodes.Clear();
                IEtapeLienReseau etape = node.Tag as IEtapeLienReseau;
                if (etape != null)
                {
                    //Trie les éléments par type
                    Dictionary<Type, ArrayList> dicParType = new Dictionary<Type, ArrayList>();
                    foreach (IElementALiensReseau elt in etape.ElementsALiensContenus)
                    {
                        ArrayList lst = null;
                        if (!dicParType.TryGetValue(elt.GetType(), out lst))
                        {
                            lst = new ArrayList();
                            dicParType[elt.GetType()] = lst;
                        }
                        if (!lst.Contains(elt))
                            lst.Add(elt);
                    }
                    foreach (IEtapeLienReseau etapeFille in etape.EtapesContenues)
                    {
                        ArrayList lst = null;
                        if (!dicParType.TryGetValue(etapeFille.GetType(), out lst))
                        {
                            lst = new ArrayList();
                            dicParType[etapeFille.GetType()] = lst;
                        }
                        if (!lst.Contains(etapeFille))
                            lst.Add(etapeFille);
                    }
                    foreach (KeyValuePair<Type, ArrayList> paire in dicParType)
                    {
                        TreeNode nodeType = new TreeNode(DynamicClassAttribute.GetNomConvivial(paire.Key));
                        nodeType.Tag = paire.Key;
                        foreach (object element in paire.Value)
                            CreateNode(element, nodeType.Nodes);
                        nodeType.BackColor = Color.LightYellow;
                        node.Nodes.Add(nodeType);
                    }
                }
            }
        }

        //----------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if ( m_arbre.SelectedNode.Tag == null )
                return;
            m_elementSelectionne = m_arbre.SelectedNode.Tag as IElementALiensReseau;
            TreeNode parent = m_arbre.SelectedNode.Parent;
            List<IEtapeLienReseau> lstEtapes = new List<IEtapeLienReseau>();
            while (parent != null)
            {
                IEtapeLienReseau etape = parent.Tag as IEtapeLienReseau;
                if (etape != null)
                    lstEtapes.Insert(0, etape);
                parent = parent.Parent;
            }
            m_etapes = lstEtapes.ToArray();
            if (m_elementSelectionne != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //----------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }




    }
}