using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.win32.common;

using timos.data;
using sc2i.formulaire;

namespace timos
{
    public abstract partial class CWndListeObjetsHierarchiques : UserControl
    {
        private TreeNode m_lastNode = null;
        private CObjetHierarchique m_objetRacine = null;

        private CGestionnaireAjoutModifSuppObjetDonnee m_gestionnaireArbre;

        private bool m_bModeListe = true;


        public CWndListeObjetsHierarchiques()
        {
            InitializeComponent();
        }

        private void m_panelVueListe_Paint(object sender, PaintEventArgs e)
        {

        }

		public abstract Type GetTypeElements();
		public abstract Type GetTypeFormEdition();

        public void Init(CObjetHierarchique objetRacine)
        {
            m_gestionnaireArbre = new CGestionnaireAjoutModifSuppObjetDonnee(GetTypeElements(), GetTypeFormEdition());
            m_gestionnaireArbre.OnNewObjetDonnee += new OnNewObjetDonneeEventHandler(AfterCreateObjet);
            m_objetRacine = objetRacine;
            if (m_objetRacine != null)
                panel1.Visible = false;

            UpdateVisibiliteControles();

            RefreshListe();
            RefreshArbre();
        }

        //--------------------------------------------------
        private void UpdateVisibiliteControles()
        {
            m_panelVueListe.Visible = m_bModeListe;
            m_panelArbre.Visible = !m_bModeListe;
            m_chkVueArbre.Checked = !m_bModeListe;
            m_chkVueListe.Checked = m_bModeListe;
            m_panelVueListe.Dock = DockStyle.Fill;
            m_panelArbre.Dock = DockStyle.Fill;
            m_panelVueListe.SendToBack();
            m_panelArbre.SendToBack();

        }

        //--------------------------------------------------
        protected void RefreshListe()
        {

            int nNiveau = Math.Max(1, m_numUpNiveau.IntValue);

            CFiltreData filtre;
            CObjetDonneeAIdNumeriqueAuto root = null;
            string strChampConteneur="";
			CListeObjetsDonnees liste = null;

            if (m_objetRacine == null)
            {
				CContexteDonnee contexteDonnee = sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant;
				filtre = new CFiltreData(
                GetChampNiveau() + "<= @2",
                nNiveau-1);
                strChampConteneur = "Projet";
				liste = new CListeObjetsDonnees(
					contexteDonnee, GetTypeElements(), filtre);

            }
            else
            {
				liste = m_objetRacine.ObjetsFils;
            }

            
            
            m_panelListeTests.InitFromListeObjets(
                liste,
                GetTypeElements(),
                GetTypeFormEdition(),
                root,
                strChampConteneur);

        }

        //----------------------------------------------------------------------------
        private void m_btnGoNiveau_Click(object sender, EventArgs e)
        {
            RefreshListe();
        }

		//--------------------------------------------------
		private string GetChampNiveau()
		{
			CContexteDonnee contexteDonnee = sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant;
			CObjetHierarchique objet = (CObjetHierarchique)Activator.CreateInstance(GetTypeElements(), new object[] { contexteDonnee });
			string strChampNiveau = objet.ChampNiveau;
			return strChampNiveau;
		}

        //--------------------------------------------------
        private void RefreshArbre()
        {
            m_arbre.Nodes.Clear();
            if (m_objetRacine == null)
            {
				CListeObjetsDonnees liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, GetTypeElements());
				liste.Filtre = new CFiltreData(GetChampNiveau() + "=@1", 0);
				foreach (CObjetHierarchique objet in liste)
				{
					TreeNode node = CreateNode(objet);
					m_arbre.Nodes.Add(node);
				}
            }
            else
            {
                TreeNode root = CreateNode(m_objetRacine);
                m_arbre.Nodes.Add(root);
            }
            m_arbre.Nodes[0].Expand();
        }

        //----------------------------------------------------------------------------
        private TreeNode CreateNode(CObjetHierarchique objet)
        {
			TreeNode node = new TreeNode(objet.Libelle);
            node.Tag = objet;
            if (objet.ObjetsFils.Count != 0)
            {
                TreeNode dummy = new TreeNode("");
                dummy.Tag = null;
                node.Nodes.Add(dummy);
            }
            return node;
        }

        //----------------------------------------------------------------------------
        private void m_btnAjouter_LinkClicked(object sender, EventArgs e)
        {
            m_gestionnaireArbre.Ajouter(null, null);
        }


        //----------------------------------------------------------------------------
        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if ( node.Nodes.Count > 0 && node.Nodes[0].Tag == null )
            {
                //il faut reremplir ce noeud
                node.Nodes.Clear();
				CListeObjetsDonnees listeFils = null;
                if (node.Tag is CObjetHierarchique)
                    listeFils = ((CObjetHierarchique)node.Tag).ObjetsFils;
				if (listeFils != null)
                {
                    foreach ( CObjetHierarchique objet in listeFils )
                    {
                        TreeNode newNode = CreateNode ( objet );
                        node.Nodes.Add ( newNode );
                    }
                }
            }

        }

        private void m_chkVueArbre_CheckedChanged(object sender, EventArgs e)
        {
            m_bModeListe = !m_chkVueArbre.Checked;
            UpdateVisibiliteControles();
        }

        private void m_chkVueListe_CheckedChanged(object sender, EventArgs e)
        {
            m_bModeListe = m_chkVueListe.Checked;
            UpdateVisibiliteControles();
        }

		public event ObjetDonneeEventHandler AfterCreateObjetEvent;

        private void AfterCreateObjet ( object sender, CObjetDonnee args, ref bool bCancel )
        {
			if (m_lastNode != null)
			{
				CObjetHierarchique objet = (CObjetHierarchique)args;
				if (m_lastNode.Tag is CObjetHierarchique)
					objet.ObjetParent = (CObjetHierarchique)m_lastNode.Tag;
			}
			if (AfterCreateObjetEvent != null)
			{
				CObjetDonneeEventArgs objArgs = new CObjetDonneeEventArgs((CObjetDonnee)args);
				AfterCreateObjetEvent(this, objArgs);
			}
        }

        private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_lastNode = m_arbre.SelectedNode;
        }

        private void m_btnDetail_LinkClicked(object sender, EventArgs e)
        {
            EditeSelection();
        }

        private void EditeSelection()
        {
            if (m_lastNode != null)
            {
				CListeObjetsDonnees liste = null;
				if (m_bModeListe)
					liste = m_panelListeTests.ListeObjets;
				m_gestionnaireArbre.Modifier((CObjetDonneeAIdNumeriqueAuto)m_lastNode.Tag, liste, null);
            }
        }

        private void m_btnSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if (m_lastNode.Tag != null)
            {
                if (m_lastNode.Tag is CObjetHierarchique)
                {
                    if (CFormAlerte.Afficher(
						I.T("Delete selected element and all its childs ?|109"),
                        EFormAlerteType.Question) == DialogResult.Yes)
                    {
						CObjetHierarchique objet = (CObjetHierarchique)m_lastNode.Tag;
                        ArrayList lst = new ArrayList();
                        lst.Add(objet);
                        CResultAErreur result = m_gestionnaireArbre.Supprimer(lst);
                        if (!result)
                            CFormAlerte.Afficher(result.Erreur);
                        else
                        {
                            m_lastNode.Remove();
                            RefreshListe();
                        }
                    }
                }
            }
        }

        private void m_arbre_DoubleClick(object sender, EventArgs e)
        {
            EditeSelection();
        }
       

    }

       
}
