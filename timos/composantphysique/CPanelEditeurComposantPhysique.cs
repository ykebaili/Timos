using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.expression;

using timos.data;
using timos.data.composantphysique;
using System.Reflection;
using timos.symbole;



namespace timos.composantphysique
{
    public partial class CPanelEditeurComposantPhysique : UserControl
    {
        private C2iComposant3D m_composantEdite = null;


        public CPanelEditeurComposantPhysique()
        {
            InitializeComponent();
        }


        public C2iComposant3D ComposantPhysiqueEdite
        {
            get
            {
                return m_composantEdite;
                    
            }
            set
            {
                MajFormules();
                m_editeurTopLeft.ComposantEdite = value;
                m_editeurTopRight.ComposantEdite = value;
                m_editeurBottomLeft.ComposantEdite = value;
                m_composantEdite = value;
                m_vue3D.Composant = value;
               
            }
        }


        public Type TypeEdite
        {
            get
            {
                return m_editeurTopLeft.TypeEdite;
                   
            }
            set
            {
                
                m_editeurTopLeft.TypeEdite = value;
            }
        }

        public void Init(C2iComposant3D composantPhysiqueEdite)
        {

            m_listeControles.AddAllLoadedAssemblies();


            m_listeControles.RefreshControls();

            ComposantPhysiqueEdite = composantPhysiqueEdite;
            if (composantPhysiqueEdite == null)
            {
                C2iComposant3DCube cube = new C2iComposant3DCube();
                cube.Size = new C3DSize(300, 300, 300);
                ComposantPhysiqueEdite = cube;

            }

            m_editeurTopLeft.Editeur = this;
            m_editeurBottomLeft.Editeur = this;
            m_editeurTopRight.Editeur = this;
            
            CFournisseurGeneriqueProprietesDynamiques fournisseurPropriete = new CFournisseurGeneriqueProprietesDynamiques();
            m_editeurTopLeft.FournisseurPropriete = fournisseurPropriete;
            m_editeurTopRight.FournisseurPropriete = fournisseurPropriete;
            m_editeurBottomLeft.FournisseurPropriete = fournisseurPropriete;

            
        }



        public void AjusterFond()
        {
            m_editeurTopLeft.AjusterFond();
        }

        public event EventHandler SelectionChanged;


        public C2iComposant3D ObjetSelectionne
        {
            get
            {
                if (m_editeurTopLeft.Selection.Count == 1)
                {
                    C2i3DEn2D obj = m_editeurTopLeft.Selection[0] as C2i3DEn2D;
                    if (obj != null)
                        return obj.Composant3D;
                }
                return null;
            }
        }

        private void MajFormules()
        {
            if (m_lastComposantPourFormules != null)
            {
                foreach (Control ctrl in m_panelFormules.Controls)
                {
                    CControlEditFormulePropriete ctrlFormule = ctrl as CControlEditFormulePropriete;
                    if (ctrlFormule != null)
                    {
                        m_lastComposantPourFormules.SetFormule(ctrlFormule.Propriete, ctrlFormule.Formule);
                    }
                }
            }
        }

        private C2iComposant3D m_lastComposantPourFormules = null;
        private void ActualiserPanel()
        {
            if (m_editeurTopLeft.Selection.Count == 0)
            {
                m_propertyGrid.SelectedObject = null;
            }
            else
            {
                if (m_editeurTopLeft.Selection.Count == 1)
                {
                    C2i3DEn2D compo = m_editeurTopLeft.Selection[0] as C2i3DEn2D;
                    m_propertyGrid.SelectedObject = compo.Composant3D;
                }
                else
                {
                    List<object> objs = new List<object>();
                    foreach (C2i3DEn2D element in m_editeurTopLeft.Selection)
                        objs.Add(element.Composant3D);
                    m_propertyGrid.SelectedObjects = objs.ToArray();
                }
            }
            MajFormules();
            m_lastComposantPourFormules = null;
            m_panelFormules.SuspendDrawing();
            foreach (Control ctrl in m_panelFormules.Controls)
            {
                ctrl.Visible = false;
                ctrl.Dispose();
            }
            m_panelFormules.Controls.Clear();
            if (m_editeurTopLeft.Selection.Count == 1)
            {
                C2i3DEn2D c2d = m_editeurTopLeft.Selection[0] as C2i3DEn2D;
                if (c2d != null)
                {
                    C2iComposant3D composant = c2d.Composant3D;
                    m_lastComposantPourFormules = composant;
                    Type tp = composant.GetType();
                    foreach (PropertyInfo propriete in tp.GetProperties())
                    {
                        if (propriete.GetCustomAttributes(typeof(CanBeDynamicAttribute), true).Length != 0)
                        {
                            C2iExpression formule = composant.GetFormule(propriete.Name);
                            CControlEditFormulePropriete ctrl = new CControlEditFormulePropriete();
                            ctrl.Parent = m_panelFormules;
                            ctrl.Dock = DockStyle.Top;
                            ctrl.BringToFront();
                            ctrl.Init(typeof(CTypeEquipement), propriete.Name, formule);
                        }
                    }
                }
            }
            m_panelFormules.ResumeDrawing();
        }

        private void m_propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            m_editeurTopLeft.Refresh();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (this.ComposantPhysiqueEdite == null)
            {
                CFormAlerte.Afficher(I.T("No symbol to save|30378"));  
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = I.T("3D object (*.3D)|*.3D|All files (*.*)|*.*|30376");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string strNomFichier = dlg.FileName;
                    CResultAErreur result = CSerializerObjetInFile.SaveToFile(ComposantPhysiqueEdite, C2iComposant3D.c_idFichier, strNomFichier);
                    if (!result)
                        CFormAlerte.Afficher(result);
                    else
                        CFormAlerte.Afficher(I.T("Save successful|30377"));
                }
            }
        }

        private void m_btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("3D objet (*.3D)|*.3D|All files (*.*)|*.*|30376");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CFormAlerte.Afficher(I.T("The current symbol will be replaced. Continue ?|30079"),
                    EFormAlerteType.Question) == DialogResult.No)
                    return;
                C2iComposant3D newComposantPhysique = new C2iComposant3DConteneurDock();
                            
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(newComposantPhysique, C2iComposant3D.c_idFichier, dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result);
                else
                {
                    ComposantPhysiqueEdite = newComposantPhysique;
                }
            }


        }

        private void m_btnModeSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeSelection.Checked)
            {   
                if (m_editeurTopLeft.ModeEdition != EModeEditeurComposantPhysique.Selection)
                {
                    m_editeurTopLeft.ModeEdition = EModeEditeurComposantPhysique.Selection;
                    m_editeurTopLeft.Focus();
                    Refresh();
                }
            }
        }

        private void m_btnModeZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeZoom.Checked)
            {
                if (m_editeurTopLeft.ModeEdition != EModeEditeurComposantPhysique.Zoom)
                {
                    m_editeurTopLeft.ModeEdition = EModeEditeurComposantPhysique.Zoom;
                    m_editeurTopLeft.Focus();
                    Refresh();
                }
            }
        }

        private void m_btnModeEditLine_CheckedChanged(object sender, EventArgs e)
        {
        }



        public void BoutonEditionLigneVisible(bool bVisible)
        {
            m_btnModeEditLine.Visible = bVisible;
        }


        public void SetBoutonSelection(bool bSelection)
        {
            m_btnModeSelection.Checked = bSelection;
        }

        private void m_btnFront_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Front;
        }

        private void m_btnLeft_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Left;
        }

        private void m_btnTop_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Top;
        }

        private void m_btnShowTop_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Rear;
        }

        private void m_btnRight_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Right;
        }

        private void m_btnBottom_Click(object sender, EventArgs e)
        {
            m_editeurTopLeft.VueAffichee = EFaceVueDynamique.Bottom;
        }

        private void editeur_DessinerEventHandler(CPanelEditionComposantPhysique panel, bool bElement, bool bSelection)
        {
            m_editeurTopLeft.DoMyDessin(bElement, bSelection);
            m_editeurTopRight.DoMyDessin(bElement, bSelection);
            m_editeurBottomLeft.DoMyDessin(bElement, bSelection);
            m_vue3D.Refresh3D();
        }

        private void m_editeurTopLeft_DessinerEventHandler(CPanelEditionComposantPhysique panel, bool bElement, bool bSelection)
        {

        }

        private bool m_bLockSelectionChanged = false;
        private void Editeur_SelectionChanged(object sender, EventArgs e)
        {
            if (sender == m_editeurTopLeft.Selection)
                ActualiserPanel();
            if (m_bLockSelectionChanged)
                return;
            m_bLockSelectionChanged = true;
            if (SelectionChanged != null)
                SelectionChanged(this, e);
            CSelectionElementsGraphiques selection = sender as CSelectionElementsGraphiques;

            if (m_editeurBottomLeft.Selection != sender)
                m_editeurBottomLeft.SetSelection ( selection );
            if (sender != m_editeurTopLeft.Selection)
                m_editeurTopLeft.SetSelection(selection);
            if (sender != m_editeurTopRight.Selection)
                m_editeurTopRight.SetSelection(selection);
            m_bLockSelectionChanged = false;
        }

        private void m_vue3D_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void m_chkModeRuntime_CheckedChanged(object sender, EventArgs e)
        {
            m_composantEdite.IsModeRuntime = m_chkModeRuntime.Checked;
        }
    }
}
