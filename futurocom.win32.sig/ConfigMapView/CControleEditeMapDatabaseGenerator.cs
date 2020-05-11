using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.sig;
using sc2i.expression;
using sc2i.win32.data.dynamic;
using sc2i.common;
using System.Reflection;
using sc2i.formulaire;
using sc2i.data.dynamic;

namespace futurocom.win32.sig
{
    public partial class CControleEditeMapDatabaseGenerator : UserControl, IControlALockEdition
    {
        private CMapDatabaseGenerator m_mapDatabaseGenerator = null;
        private IControleEditeMapItem m_editeurActif = null;
        private Dictionary<Type, IControleEditeMapItem> m_dicControlesAlloues = new Dictionary<Type, IControleEditeMapItem>();

        //----------------------------------------------------------
        public CControleEditeMapDatabaseGenerator()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------
        public CMapDatabaseGenerator MapGeneratorEdite
        {
            get
            {
                return m_mapDatabaseGenerator;
            }
        }

        //----------------------------------------------------------
        public void InitChamps(CMapDatabaseGenerator generator)
        {
            m_mapDatabaseGenerator = generator;
            if (m_mapDatabaseGenerator == null)
            {
                m_tabControl.Visible = false;
                return;
            }
            m_tabControl.Visible = true;
            m_panelFormulaire.Init(typeof(CMapDatabaseGenerator),
                m_mapDatabaseGenerator,
                m_mapDatabaseGenerator.Formulaire,
                m_mapDatabaseGenerator);
            m_editeurActif = null;
            foreach (Control ctrl in m_panelEditeGenerator.Controls)
                ctrl.Visible = false;
            m_selectTypeSource.TypeSelectionne = generator.TypeSource;

            FillListeGenerators();
            RefillListeVariables();
        }


        //----------------------------------------------------------
        private void m_wndListeItems_SizeChanged(object sender, EventArgs e)
        {
            if (m_wndListeItems.Columns.Count > 0)
                m_wndListeItems.Columns[0].Width = ClientSize.Width - 15;
        }

        //----------------------------------------------------------
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
                    OnChangeLockEdition(this, new EventArgs());
            }
        }


        public event EventHandler OnChangeLockEdition;


        //----------------------------------------------------------------------------------------
        private void m_lnkVariables_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormSelectVariableDynamiqueAInterfaceUtilisateur.EditeVariables(m_mapDatabaseGenerator);
        }


        //----------------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_mapDatabaseGenerator != null)
            {
                m_mapDatabaseGenerator.TypeSource = m_selectTypeSource.TypeSelectionne;
                if (m_editeurActif != null)
                    result = m_editeurActif.MajChamps();
                if (!result)
                    return result;
                List<IMapItemGenerator> generators = new List<IMapItemGenerator>();
                foreach (ListViewItem item in m_wndListeItems.Items)
                {
                    IMapItemGenerator gen = item.Tag as IMapItemGenerator;
                    if (gen != null)
                        generators.Add(gen);
                }
                m_mapDatabaseGenerator.ItemsGenerators = generators.ToArray();
                m_mapDatabaseGenerator.Formulaire = m_panelFormulaire.WndEditee as C2iWndFenetre;
            }
            return CResultAErreur.True;
        }

        //--------------------------------------------------------------------------
        private void m_wndAddItemGenerator_LinkClicked(object sender, EventArgs e)
        {
            if (m_menuNewItem.Items.Count == 0)
            {
                foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
                {
                    foreach (Type tp in ass.GetTypes())
                    {
                        if (typeof(IMapItemGenerator).IsAssignableFrom(tp) && !tp.IsAbstract)
                        {
                            IMapItemGenerator gen = (IMapItemGenerator)Activator.CreateInstance(tp, new object[0]);
                            ToolStripMenuItem itemAddGen = new ToolStripMenuItem(gen.GeneratorName);
                            itemAddGen.Tag = tp;
                            itemAddGen.Click += new EventHandler(itemAddGen_Click);
                            m_menuNewItem.Items.Add(itemAddGen);
                        }
                    }
                }
            }
            if (m_menuNewItem.Items.Count == 1)
            {
                AddGenerator(m_menuNewItem.Items[0].Tag as Type);
            }
            else
                m_menuNewItem.Show(m_wndAddItemGenerator, new Point(0, m_wndAddItemGenerator.Height));
        }

        //------------------------------------------------------------
        void itemAddGen_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Type tpGen = item != null?item.Tag as Type: null;
            if (tpGen != null)
                AddGenerator(tpGen);
        }

        //--------------------------------------------------------------------------
        private void AddGenerator(Type tpGenerator)
        {
            if (tpGenerator == null)
                return;
            IMapItemGenerator gen = (IMapItemGenerator)Activator.CreateInstance(tpGenerator, new object[0]);
            gen.Generator = m_mapDatabaseGenerator;
            ListViewItem item = new ListViewItem("");
            FillItemGenerator(item, gen);
            m_wndListeItems.Items.Add(item);
            item.Selected = true;
        }

        //--------------------------------------------------------------------------
        private void FillItemGenerator(ListViewItem item, IMapItemGenerator generator)
        {
            item.Text = generator.Libelle;
            item.Tag = generator;
        }

        //--------------------------------------------------------------------------
        private void m_wndListeItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListeItems.SelectedItems.Count == 1)
            {
                ListViewItem item = m_wndListeItems.SelectedItems[0];
                EditeItemGenerator(item.Tag as IMapItemGenerator);
            }
        }

        //--------------------------------------------------------------------------
        private void FillListeGenerators()
        {
            m_wndListeItems.BeginUpdate();
            m_wndListeItems.Items.Clear();
            if (m_mapDatabaseGenerator != null)
            {

                foreach (IMapItemGenerator generator in m_mapDatabaseGenerator.ItemsGenerators)
                {
                    ListViewItem item = new ListViewItem();
                    FillItemGenerator(item, generator);
                    m_wndListeItems.Items.Add(item);
                }
            }
            m_wndListeItems.EndUpdate();
        }

        //--------------------------------------------------------------------------
        private void UpdateItemsGenerator()
        {
            foreach (ListViewItem item in m_wndListeItems.Items)
            {
                FillItemGenerator(item, (IMapItemGenerator)item.Tag);
            }
        }

        //--------------------------------------------------------------------------
        private void EditeItemGenerator(IMapItemGenerator generator)
        {
            try
            {
                m_panelEditeGenerator.SuspendDrawing();
                m_panelCopierColler.Visible = false;
                if (m_editeurActif != null)
                {
                    m_editeurActif.MajChamps();
                    UpdateItemsGenerator();
                }
                m_editeurActif = null;
                foreach (Control ctrlToHide in m_panelEditeGenerator.Controls)
                    ctrlToHide.Visible = false;
                if (generator == null)
                    return;
                IControleEditeMapItem ctrl = null;
                if (!m_dicControlesAlloues.TryGetValue(generator.GetType(), out ctrl))
                {
                    ctrl = CAllocateurInterfaceMapItemGenerator.GetNewControle(generator);
                    if (ctrl != null)
                    {
                        CWin32Traducteur.Translate(ctrl);
                        m_panelEditeGenerator.Controls.Add(ctrl as Control);
                        ((Control)ctrl).Dock = DockStyle.Fill;
                        m_dicControlesAlloues.Add(generator.GetType(), ctrl);
                    }
                }
                if (ctrl != null)
                {
                    m_panelCopierColler.Visible = true;
                    ((Control)ctrl).Visible = true;
                    ((IControlALockEdition)ctrl).LockEdition = LockEdition;
                    ctrl.InitChamps(generator);
                    m_editeurActif = ctrl;
                }
            }
            finally
            {
                m_panelEditeGenerator.ResumeDrawing();
            }
        }

        //--------------------------------------------------------------------------
        private void CControleEditeMapDatabaseGenerator_Load(object sender, EventArgs e)
        {
            m_selectTypeSource.Init();
        }

        //--------------------------------------------------------------------------
        private void m_wndRemoveItemMapGenerator_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeItems.SelectedItems.Count == 1)
            {
                if (CFormAlerte.Afficher(I.T("Remove selected item ?|10004"), EFormAlerteBoutons.OkAbandonner, EFormAlerteType.Question) == DialogResult.OK)
                {
                    EditeItemGenerator(null);
                    ListViewItem item = m_wndListeItems.SelectedItems[0];
                    IMapItemGenerator genToRemove = item.Tag as IMapItemGenerator;
                    if (genToRemove != null)
                    {
                        m_wndListeItems.Items.Remove(item);
                    }
                }
            }
        }

        //--------------------------------------------------------------------------
        private void m_btnAjouterChamp_LinkClicked(object sender, EventArgs e)
        {
            m_menuNewVariable.Show(m_btnAjouterChamp, new Point(0, m_btnAjouterChamp.Height));
        }

        //--------------------------------------------------------------------------
        private void m_menuVariableSaisie_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueSaisie variable = new CVariableDynamiqueSaisie(m_mapDatabaseGenerator);
            if (EditeVariable(variable))
            {
                m_mapDatabaseGenerator.AddVariable(variable);
                RefillListeVariables();
            }
        }

        //--------------------------------------------------------------------------
        private void m_menuVariableCalculée_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueCalculee variable = new CVariableDynamiqueCalculee(m_mapDatabaseGenerator);
            if (EditeVariable(variable))
            {
                m_mapDatabaseGenerator.AddVariable(variable);
                RefillListeVariables();
            }
        }

        //--------------------------------------------------------------------------
        private void m_menuVariableSelection_Click(object sender, EventArgs e)
        {
            CVariableDynamiqueSelectionObjetDonnee variable = new CVariableDynamiqueSelectionObjetDonnee(m_mapDatabaseGenerator);
            if (EditeVariable(variable))
            {
                m_mapDatabaseGenerator.AddVariable(variable);
                RefillListeVariables();
            }
        }

        //-------------------------------------------------------------------------
        private bool EditeVariable(CVariableDynamique variable)
        {
            if (variable == null)
                return false;
            bool bRetour = true;
            if (variable is CVariableDynamiqueSaisie)
                bRetour = CFormEditVariableDynamiqueSaisie.EditeVariable((CVariableDynamiqueSaisie)variable, m_mapDatabaseGenerator);
            else if (variable is CVariableDynamiqueCalculee)
                bRetour = CFormEditVariableFiltreCalculee.EditeVariable((CVariableDynamiqueCalculee)variable, m_mapDatabaseGenerator);
            else if (variable is CVariableDynamiqueSelectionObjetDonnee)
                bRetour = CFormEditVariableDynamiqueSelectionObjetDonnee.EditeVariable((CVariableDynamiqueSelectionObjetDonnee)variable);
            else if (variable is CVariableDynamiqueListeObjets)
                bRetour = CFormEditVariableDynamiqueListeObjets.EditeVariable((CVariableDynamiqueListeObjets)variable, m_mapDatabaseGenerator);
            else
                bRetour = false;
            return bRetour;
        }

        //-------------------------------------------------------------------------
        private void RefillListeVariables()
        {
            if (m_mapDatabaseGenerator == null)
                return;
            int nItem = -1;
            if (m_wndListeVariables.SelectedIndices.Count != 0)
                nItem = m_wndListeVariables.SelectedIndices[0];
            m_wndListeVariables.Remplir(m_mapDatabaseGenerator.ListeVariables);
            try
            {
                m_wndListeVariables.Items[nItem].Selected = true;
            }
            catch { }
        }

        //-------------------------------------------------------------------------
        private void m_btnModifierChamp_LinkClicked(object sender, EventArgs e)
        {
            if (EditeVariable(VariableSelectionnee))
            {
                RefillListeVariables();
            }
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

        private void m_btnSupprimerChamp_LinkClicked(object sender, EventArgs e)
        {
            CVariableDynamique variable = VariableSelectionnee;
            if (m_mapDatabaseGenerator.IsVariableUtilisee(variable))
            {
                CFormAlerte.Afficher(I.T("Impossible to delete this variabe because it is used|10005"), EFormAlerteType.Erreur);
                return;
            }
            m_mapDatabaseGenerator.RemoveVariable(variable);
            RefillListeVariables();

        }

        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            if (m_editeurActif != null && m_editeurActif.CurrentGenerator != null)
            {
                IMapItemGenerator generator = m_editeurActif.CurrentGenerator;
                CResultAErreur result = CSerializerObjetInClipBoard.Copy(generator, generator.GetType().ToString());
                if (!result)
                {
                    CFormAlerte.Afficher(result);
                }
            }
        }

        private void m_btnPaste_Click(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition &&  m_editeurActif != null && m_editeurActif.CurrentGenerator != null)
            {
                IMapItemGenerator generator = m_editeurActif.CurrentGenerator;
                I2iSerializable pasted = null;
                CResultAErreur result = CSerializerObjetInClipBoard.Paste(ref pasted, generator.GetType().ToString());
                if (!result)
                {
                    CFormAlerte.Afficher(result);
                }
                else
                {
                    if (MessageBox.Show(I.T("Replace current setup ?|20049"),
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Trouve l'item
                        foreach ( ListViewItem item in m_wndListeItems.Items )
                        {
                            if ( item.Tag == generator )
                            {
                                IMapItemGenerator newGenerator = (IMapItemGenerator)pasted;
                                newGenerator.Generator = m_mapDatabaseGenerator;
                                
                                FillItemGenerator(item, newGenerator);
                                m_editeurActif.InitChamps(newGenerator);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void m_btnOpen_Click(object sender, EventArgs e)
        {

        }


    }
}
