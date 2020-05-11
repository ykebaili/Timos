using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic.Macro;

using sc2i.win32.common;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using sc2i.win32.data;
using sc2i.expression;

namespace timos.macro
{
    public partial class CControleEditeMacro : UserControl, IControlALockEdition
    {
        private static Dictionary<Type, Type> m_dicTypesEditeurs = new Dictionary<Type, Type>();


        public static void RegisterEditeur(Type typeElementDeMacro, Type typeEditeur)
        {
            m_dicTypesEditeurs[typeElementDeMacro] = typeEditeur; ;
        }

        private static Type GetTypeEditeur(Type typeElementDeMacro)
        {
            Type tp = null;
            m_dicTypesEditeurs.TryGetValue(typeElementDeMacro, out tp);
            return tp;
        }

        private CMacro m_macro;
        private IEditeurElementDeMacro m_editeurEnCours = null;


        public CControleEditeMacro()
        {
            InitializeComponent();
        }

        public void Init(CMacro macro)
        {
            m_macro = macro;
            m_txtNomMacro.Text = m_macro.Libelle;
            FillArbre();
            RefillListeVariables();
            m_panelFormulaire.Init(typeof(CMacro), m_macro, m_macro.Formulaire, m_macro);
        }

        //-------------------------------------------------------------------------
        private void RefillListeVariables()
        {
            if (m_macro == null)
                return;
            int nItem = -1;
            if (m_wndListeVariables.SelectedIndices.Count != 0)
                nItem = m_wndListeVariables.SelectedIndices[0];
            m_wndListeVariables.Remplir(m_macro.ListeVariables);
            try
            {
                m_wndListeVariables.Items[nItem].Selected = true;
            }
            catch { }
            foreach (ListViewItem item in m_wndListeVariables.Items)
            {
                CVariableDynamique variable = item.Tag as CVariableDynamique;
                if (variable.IdVariable == m_macro.IdVariableTargetElement)
                    item.BackColor = Color.LightGreen;
            }
        }

        //----------------------------------------------------------------------------------------
        private void FillArbre()
        {
            m_arbreModifications.BeginUpdate();
            m_arbreModifications.SuspendDrawing();
            m_arbreModifications.Nodes.Clear();

            if (m_macro != null)
            {
                foreach (CMacroObjet mo in m_macro.Objets)
                {
                    TreeNode node = new TreeNode(mo.DesignationObjet);
                    FillNode(node, mo);
                    m_arbreModifications.Nodes.Add(node);
                }
            }

            m_arbreModifications.ResumeDrawing();
            m_arbreModifications.EndUpdate();
        }

        //----------------------------------------------------------------------------------------
        private void FillNode(TreeNode node, CMacroObjet mo)
        {
            node.Text = mo.DesignationObjet;
            node.Tag = mo;
            int nIndexImage = 0;
            switch (mo.TypeOperation.Code)
            {
                case sc2i.data.CTypeOperationSurObjet.TypeOperation.Ajout:
                    nIndexImage = 1;
                    break;
                case sc2i.data.CTypeOperationSurObjet.TypeOperation.Aucune:
                    nIndexImage = 0;
                    break;
                case sc2i.data.CTypeOperationSurObjet.TypeOperation.Modification:
                    nIndexImage = 3;
                    break;
                case sc2i.data.CTypeOperationSurObjet.TypeOperation.Suppression:
                    nIndexImage = 2;
                    break;
            }
            node.ImageIndex = nIndexImage;
            node.SelectedImageIndex = nIndexImage;
            if (node.Nodes.Count == 0 && mo.Valeurs.Count() > 0)
            {
                TreeNode dummy = new TreeNode("");
                dummy.Tag = DBNull.Value;
                node.Nodes.Add(dummy);
            }
        }

        //----------------------------------------------------------------------------------------
        private void m_arbreModifications_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            CMacroObjet mo = node.Tag as CMacroObjet;
            if (mo != null && node.Nodes.Count == 1 && node.Nodes[0].Tag == DBNull.Value)
            {
                m_arbreModifications.BeginUpdate();
                node.Nodes.Clear();
                foreach (CMacroObjetValeur valeur in mo.Valeurs)
                {
                    TreeNode nodeValeur = new TreeNode();
                    FillNode(nodeValeur, valeur);
                    node.Nodes.Add(nodeValeur);
                }
                m_arbreModifications.EndUpdate();
            }
        }

        //----------------------------------------------------------------------------------------
        private void FillNode(TreeNode node, CMacroObjetValeur valeur)
        {
            node.Text = valeur.Champ.Nom;
            node.Tag = valeur;
            node.ImageIndex = 3;
            node.SelectedImageIndex = 3;
        }

        private void m_arbreModifications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_editeurEnCours != null)
            {
                CResultAErreur result = m_editeurEnCours.MajChamps();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
                ((Control)m_editeurEnCours).Visible = false;
                ((Control)m_editeurEnCours).Parent.Controls.Remove ( (Control)m_editeurEnCours);
                ((Control)m_editeurEnCours).Dispose();
                
            }
            m_editeurEnCours = null;
            object obj = e.Node.Tag;
            if ( obj != null )
            {
                Type tp = null;
                if ( m_dicTypesEditeurs.TryGetValue ( obj.GetType(), out tp ))
                {
                    if ( tp != null )
                    {
                        IEditeurElementDeMacro editeur = Activator.CreateInstance ( tp, new object[0] ) as IEditeurElementDeMacro;
                        if ( editeur != null )
                        {
                            Control ctrl = editeur as Control;
                            m_panelEditeModif.SuspendDrawing();
                            m_panelEditeModif.Controls.Add ( ctrl );
                            ctrl.Dock = DockStyle.Fill;
                            m_editeurEnCours = editeur;
                            m_panelEditeModif.ResumeDrawing();
                            editeur.InitChamps(obj);
                        }
                    }
                }
            }
        }

        private void m_btnAjouterChamp_LinkClicked(object sender, EventArgs e)
        {
            m_menuNewVariable.Show(m_btnAjouterChamp, new Point(0, m_btnAjouterChamp.Height));
        }

        private void m_btnModifierChamp_LinkClicked(object sender, EventArgs e)
        {
            if (EditeVariable(VariableSelectionnee))
            {
                RefillListeVariables();
            }
        }

        private void m_btnSupprimerChamp_LinkClicked(object sender, EventArgs e)
        {
            CVariableDynamique variable = VariableSelectionnee;
            if (m_macro.IsVariableUtilisee(variable))
            {
                CFormAlerte.Afficher(I.T("Impossible to delete this variabe because it is used|264"), EFormAlerteType.Erreur);
                return;
            }
            m_macro.RemoveVariable(variable);
            RefillListeVariables();
        }

        //-------------------------------------------------------------------------
        private CVariableDynamique VariableSelectionnee
        {
            get
            {
                if (m_wndListeVariables.SelectedItems.Count == 0)
                    return null;
                return (CVariableDynamique)m_wndListeVariables.SelectedItems[0].Tag;
            }
        }

        //-------------------------------------------------------------------------
        private bool EditeVariable(CVariableDynamique variable)
        {
            if (variable == null)
                return false;
            if (!m_extModeEdition.ModeEdition)
                return false;
            bool bRetour = true;
            if (variable is CVariableDynamiqueSaisie)
                bRetour = CFormEditVariableDynamiqueSaisie.EditeVariable((CVariableDynamiqueSaisie)variable, m_macro);
            else if (variable is CVariableDynamiqueCalculee)
                bRetour = CFormEditVariableFiltreCalculee.EditeVariable((CVariableDynamiqueCalculee)variable, m_macro);
            else if (variable is CVariableDynamiqueSelectionObjetDonnee)
                bRetour = CFormEditVariableDynamiqueSelectionObjetDonnee.EditeVariable((CVariableDynamiqueSelectionObjetDonnee)variable);
            else if (variable is CVariableDynamiqueListeObjets)
                bRetour = CFormEditVariableDynamiqueListeObjets.EditeVariable((CVariableDynamiqueListeObjets)variable, m_macro);
            else
                bRetour = false;
            if (bRetour)
                m_macro.OnChangeVariable(variable);
            return bRetour;
        }

        private void m_wndListeVariables_DoubleClick(object sender, EventArgs e)
        {
            if (EditeVariable(VariableSelectionnee))
                RefillListeVariables();
        }

        private void m_menuVariableSaisie_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueSaisie variable = new CVariableDynamiqueSaisie(m_macro);
            if (EditeVariable(variable))
            {
                m_macro.AddVariable(variable);
                RefillListeVariables();
            }
        }

        private void m_menuNewVariableCalculée_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueCalculee variable = new CVariableDynamiqueCalculee(m_macro);
            if (EditeVariable(variable))
            {
                m_macro.AddVariable(variable);
                RefillListeVariables();
            }
        }

        private void m_menuNewVariableSelection_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueSelectionObjetDonnee variable = new CVariableDynamiqueSelectionObjetDonnee(m_macro);
            if (EditeVariable(variable))
            {
                m_macro.AddVariable(variable);
                RefillListeVariables();
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "#Macro|*.FutMacro|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CResultAErreur result = CSerializerObjetInFile.SaveToFile(m_macro, "MACRO", dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "#Macro|*.FutMacro|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CMacro macro = new CMacro();
                macro.ContexteDonnee = CSc2iWin32DataClient.ContexteCourant;
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(macro, "MACRO", dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
                else
                    Init(macro);
            }
        }


        
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

        public event EventHandler OnChangeLockEdition;

        private void m_tablControl_SelectionChanged(object sender, EventArgs e)
        {
            if (m_tablControl.SelectedTab == m_pageVariables)
                RefillListeVariables();
        }

        private void m_wndListeVariables_MouseUp(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            if (e.Button == MouseButtons.Right)
            {
                if (VariableSelectionnee != null)
                {
                    m_macro.VariableCible = VariableSelectionnee;
                    RefillListeVariables();
                }
            }
        }

        private void m_txtNomMacro_TextChanged(object sender, EventArgs e)
        {
            if (m_macro != null)
                m_macro.Libelle = m_txtNomMacro.Text;
        }

    }

    public interface IEditeurElementDeMacro
    {
        void InitChamps ( object obj );
        CResultAErreur MajChamps();
    }
}
