using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.securite;
using timos.securite;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using timos.acteurs;

namespace timos.Securite
{
    public partial class CPanelRestrictionsSpecifiques : UserControl, IControlALockEdition
    {
        private IElementARestrictionsSpecifiques m_elementARestrictions = null;
        private List<CGroupeRestrictionSurType> m_listeGroupesPossibles = new List<CGroupeRestrictionSurType>();
        private CRelationElement_RestrictionSpecifique m_relationEnCours = null;
        private bool m_bIsFillingArbreGroupes = false;


        public CPanelRestrictionsSpecifiques()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------
        public void Init(IElementARestrictionsSpecifiques element)
        {
            CGroupeRestrictionSurType groupeSel = null;
            if (m_wndListeGroupes.SelectedItems.Count > 0)
            {
                ListViewItem item = m_wndListeGroupes.SelectedItems[0];
                CRelationElement_RestrictionSpecifique rel = item.Tag as CRelationElement_RestrictionSpecifique;
                if (rel != null)
                    groupeSel = rel.GroupeRestriction;
            }
            m_lblLibelleElement.Text = element.DescriptionElement;
            m_elementARestrictions = element;
            m_panelDetailGroupe.Visible = false;
            CListeObjetDonneeGenerique<CGroupeRestrictionSurType> lstGroupes = new CListeObjetDonneeGenerique<CGroupeRestrictionSurType>(element.ContexteDonnee);
            m_listeGroupesPossibles.Clear();
            foreach (CGroupeRestrictionSurType groupe in lstGroupes)
            {
                CListeRestrictionsUtilisateurSurType lste = groupe.ListeRestrictions;
                CRestrictionUtilisateurSurType rest = lste.GetRestriction(element.GetType());
                if (rest.HasRestrictions)
                    m_listeGroupesPossibles.Add(groupe);
            }
            UpdateGroupesPossibles();
            m_wndListeGroupes.BeginUpdate();
            m_wndListeGroupes.Items.Clear();
            m_panelDetailGroupe.Visible = false;
            m_relationEnCours = null;
            foreach (CRelationElement_RestrictionSpecifique rel in element.ListeRestrictions)
            {
                ListViewItem item = CreateItem(rel);
                m_wndListeGroupes.Items.Add(item);
                if (rel.GroupeRestriction != null)
                    m_listeGroupesPossibles.Remove(rel.GroupeRestriction);
                if (rel.GroupeRestriction.Equals(groupeSel))
                    item.Selected = true;
            }
            m_wndListeGroupes.EndUpdate();
            
            
            m_arbreGroupes.BeginUpdate();
            m_arbreGroupes.Nodes.Clear();
            CListeObjetsDonnees lstGroupesActeurs = new CListeObjetsDonnees(m_elementARestrictions.ContexteDonnee, typeof(CGroupeActeur));
            foreach ( CGroupeActeur groupe in lstGroupesActeurs )
            {
                if ( groupe.RelationsGroupesNecessaires.Count == 0 )
                {
                    AddNodeGroupe ( groupe, m_arbreGroupes.Nodes );
                }
            }
            m_arbreGroupes.EndUpdate();
        }

        //----------------------------------------------------------------
        private void AddNodeGroupe ( CGroupeActeur groupe, TreeNodeCollection nodes )
        {
            TreeNode node = new TreeNode ( groupe.Nom );
            node.Tag = groupe;
            nodes.Add ( node );
            foreach ( CRelationGroupeActeurNecessite rel in groupe.RelationsGroupesNecessitants )
            {
                AddNodeGroupe ( rel.GroupeActeurNecessitant, node.Nodes );
            }
        }

        //----------------------------------------------------------------
        private ListViewItem CreateItem ( CRelationElement_RestrictionSpecifique rel )
        {
            ListViewItem item = new ListViewItem();
            item.Text = rel.GroupeRestriction != null ? rel.GroupeRestriction.Libelle:"?";
            item.Tag = rel;
            return item;
        }

        //----------------------------------------------------------------
        private void ValideGroupeEnCours()
        {
            if (m_relationEnCours == null || !m_extModeEdition.ModeEdition)
                return;
            if (m_btnAppliquerAToutLeMonde.Checked)
            {
                CListeObjetsDonnees lst = m_relationEnCours.Applications;
                CObjetDonneeAIdNumerique.Delete(lst, true);
            }
            else
            {
                m_wndListeActeurs.ApplyModifs();
                m_wndListeProfils.ApplyModifs();
            }
        }

        //----------------------------------------------------------------
        private void SetGroupeEnCours(CRelationElement_RestrictionSpecifique rel)
        {
            ValideGroupeEnCours();
            m_relationEnCours = rel;
            m_btnAppliquerAToutLeMonde.Checked = rel.Applications.Count == 0;
            m_btnAppliquerASelection.Checked = !m_btnAppliquerAToutLeMonde.Checked;

            if (m_relationEnCours == null)
            {
                m_panelDetailGroupe.Visible = false;
                return;
            }

            m_lblNomGroupe.Text = m_relationEnCours.GroupeRestriction.Libelle;
            CListeObjetsDonnees lstLiensActeurs = m_relationEnCours.Applications;
            lstLiensActeurs.Filtre = new CFiltreData(CActeur.c_champId + " is not null");
            m_wndListeActeurs.Init(
                new CListeObjetsDonnees(m_elementARestrictions.ContexteDonnee, typeof(CActeur)),
                lstLiensActeurs,
                m_relationEnCours,
                "RelationElement_Restriction",
                "Acteur");

            CListeObjetsDonnees lstLiensProfils = m_relationEnCours.Applications;
            lstLiensProfils.Filtre = new CFiltreData(CProfilUtilisateur.c_champId + " is not null");
            m_wndListeProfils.Init(
                new CListeObjetsDonnees(m_elementARestrictions.ContexteDonnee, typeof(CProfilUtilisateur)),
                lstLiensProfils,
                m_relationEnCours,
                "RelationElement_Restriction",
                "ProfilUtilisateur");

            CListeObjetsDonnees lstLiensGroupes = m_relationEnCours.Applications;
            lstLiensGroupes.Filtre = new CFiltreData(CGroupeActeur.c_champId + " is not null");
            m_arbreGroupes.BeginUpdate();
            m_bIsFillingArbreGroupes = true;
            UncheckNodes(m_arbreGroupes.Nodes);
            foreach (CRelationElement_RestrictionSpecifique_Application relGroupe in lstLiensGroupes)
                CheckNode(relGroupe.GroupeActeur, m_arbreGroupes.Nodes);
            m_arbreGroupes.EndUpdate();
            m_bIsFillingArbreGroupes = false;
            m_panelDetailGroupe.Visible = true;
        }

        //----------------------------------------------------------------
        private void UpdateGroupesPossibles()
        {
            m_cmbGroupeRestriction.ListDonnees = m_listeGroupesPossibles;
            m_cmbGroupeRestriction.ProprieteAffichee = "Libelle";
        }

        //----------------------------------------------------------------
        private void UncheckNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                UncheckNodes(node.Nodes);
            }
        }

        //----------------------------------------------------------------
        private void CheckNode(CGroupeActeur groupe, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.Equals(groupe))
                {
                    node.Checked = true;
                    TreeNode parent = node.Parent;
                    while (parent != null)
                    {
                        parent.Expand();
                        parent = parent.Parent;
                    }
                }
                else
                    node.Checked = false;
                CheckNode(groupe, node.Nodes);
            }
        }


        //----------------------------------------------------------------
        private void m_tabApplication_SelectionChanged(object sender, EventArgs e)
        {

        }

        #region IControlALockEdition Membres

        //----------------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }
        //----------------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        #endregion

        //----------------------------------------------------------------
        private void m_arbreGroupes_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_relationEnCours != null && m_extModeEdition.ModeEdition && !m_bIsFillingArbreGroupes)
            {
                if (e.Node.Checked && m_relationEnCours != null)
                {
                    m_elementARestrictions.AddRestrictionFor(m_relationEnCours.GroupeRestriction, e.Node.Tag as CGroupeActeur);
                }
                if (!e.Node.Checked && m_relationEnCours != null)
                {
                    m_elementARestrictions.RemoveRestrictionFor(m_relationEnCours.GroupeRestriction, e.Node.Tag as CGroupeActeur);
                }
            }
        }

        //----------------------------------------------------------------
        private void m_arbreGroupes_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition && !m_bIsFillingArbreGroupes)
                e.Cancel = true;
        }

        //----------------------------------------------------------------
        private void m_btnAppliquerAToutLeMonde_CheckedChanged(object sender, EventArgs e)
        {
            m_tabApplication.Visible = !m_btnAppliquerAToutLeMonde.Checked;
        }

        //----------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            ValideGroupeEnCours();
            return result;
        }

        //----------------------------------------------------------------
        private void m_lnkAddGroupeRestriction_LinkClicked(object sender, EventArgs e)
        {
            if (m_cmbGroupeRestriction.SelectedValue is CGroupeRestrictionSurType && m_extModeEdition.ModeEdition)
            {
                CRelationElement_RestrictionSpecifique rel = new CRelationElement_RestrictionSpecifique(m_elementARestrictions.ContexteDonnee);
                rel.CreateNewInCurrentContexte();
                rel.ElementLie = m_elementARestrictions as CObjetDonneeAIdNumerique;
                rel.GroupeRestriction = m_cmbGroupeRestriction.SelectedValue as CGroupeRestrictionSurType;
                ListViewItem item = CreateItem(rel);
                m_wndListeGroupes.Items.Add(item);
                item.Selected = true;
                m_listeGroupesPossibles.Remove(m_cmbGroupeRestriction.SelectedValue as CGroupeRestrictionSurType);
                UpdateGroupesPossibles();
            }

        }
    

        //----------------------------------------------------------------
        private void m_wndListeGroupes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListeGroupes.SelectedItems.Count == 1)
            {
                ListViewItem item = m_wndListeGroupes.SelectedItems[0];
                CRelationElement_RestrictionSpecifique rel = item.Tag as CRelationElement_RestrictionSpecifique;
                if (rel != null)
                    SetGroupeEnCours(rel);
            }
        }

        private void cWndLinkStd1_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeGroupes.SelectedItems.Count == 1 && m_extModeEdition.ModeEdition)
            {
                ListViewItem item = m_wndListeGroupes.SelectedItems[0];
                CRelationElement_RestrictionSpecifique rel = item.Tag as CRelationElement_RestrictionSpecifique;
                if (rel != null &&
                    MessageBox.Show(I.T("Remove restriction @1 ?|20544", rel.GroupeRestriction.Libelle),
                    I.T("Confirmation|20"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CResultAErreur result = rel.Delete(true);
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                    }
                    else
                    {
                        m_relationEnCours = null;
                        m_panelDetailGroupe.Visible = false;
                        m_wndListeGroupes.Items.Remove(item);
                    }
                }
            }
        }
    }
}
