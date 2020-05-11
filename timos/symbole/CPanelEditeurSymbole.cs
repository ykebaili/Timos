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

namespace timos
{
    public partial class CPanelEditeurSymbole : UserControl
    {



        public CPanelEditeurSymbole()
        {
            InitializeComponent();

            //MyInit();
                                   
        }


        public C2iSymbole SymboleEdite
        {
            get
            {
                return (C2iSymbole)m_panelEditionSymbole.ObjetEdite;
                    
            }
            set
            {
                m_panelEditionSymbole.ObjetEdite = value;
               
            }
        }


        public Type TypeEdite
        {
            get
            {
                return m_panelEditionSymbole.TypeEdite;
                   
            }
            set
            {
                
                m_panelEditionSymbole.TypeEdite = value;
              
                if (SymboleEdite != null)
                    SymboleEdite.SetTargetType(value);
            }
        }


        public CPanelEditionObjetGraphique Editeur
        {
            get
            {
                return m_panelEditionSymbole;

            }
        }

        public void Init(C2iSymbole symboleEdite, Type typeEdite,bool bEditPorts)
        {

            if (bEditPorts)
            {
                m_listeControles.Visible = false;
                m_propertyGrid.Visible = false;
                m_panelEditionSymbole.NoClipboard = true;
                m_panelEditionSymbole.NoDelete = true;
                m_panelEditionSymbole.NoDoubleClick = true;
                m_panelEditionSymbole.NoMenu = true;
                m_btnSave.Visible=false;
                m_btnOpen.Visible = false;
                
            }
            else
            {
                m_listeControles.AddAllLoadedAssemblies();
            }
           
            m_listeControles.RefreshControls();

            if(symboleEdite == null)
            {
                C2iSymbole symbFond = new C2iSymbole();
               System.Drawing.Size size = new Size(300, 300);
               symbFond.Size = size;
               symbFond.BackColor = Color.Transparent;

                              
            
               m_panelEditionSymbole.ObjetEdite = symbFond;
               m_panelEditionSymbole.TypeEdite = typeEdite;

              }
            else
            {
                
                SymboleEdite = symboleEdite;
                TypeEdite = typeEdite;

            }
            m_panelEditionSymbole.Editeur = this;
            if (bEditPorts)
                SymboleEdite.ForeColor = Color.Black;
            CFournisseurGeneriqueProprietesDynamiques fournisseurPropriete = new CFournisseurGeneriqueProprietesDynamiques();
            m_panelEditionSymbole.FournisseurPropriete = fournisseurPropriete;
                         
        }



        public void AjusterFond()
        {
            m_panelEditionSymbole.AjusterFond();
        }

        public event EventHandler SelectionChanged;

        private void m_panelEditionSymbole_SelectionChanged(object sender, EventArgs e)
        {
            ActualiserPanel();
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        public C2iSymbole ObjetSelectionne
        {
            get
            {
                if (m_panelEditionSymbole.Selection.Count == 1)
                    return m_panelEditionSymbole.Selection[0] as C2iSymbole;
                return null;
            }
        }


        private void ActualiserPanel()
        {
          

            if (m_panelEditionSymbole.Selection.Count == 0)
            {
                m_propertyGrid.SelectedObject = null;
            }
            else
            {
                if (m_panelEditionSymbole.Selection.Count == 1)
                {
                    m_propertyGrid.SelectedObject = m_panelEditionSymbole.Selection[0];
                }
                else
                {
                    List<object> objs = new List<object>();
                    foreach (C2iSymbole elements in m_panelEditionSymbole.Selection)
                        objs.Add(elements);
                    m_propertyGrid.SelectedObjects = objs.ToArray();
                }
            }
        }

        private void m_propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            m_panelEditionSymbole.Refresh();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (this.SymboleEdite == null)
            {
                CFormAlerte.Afficher(I.T("No symbol to save|30378"));  
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = I.T("Symbol (*.2iSymbol)|*.2iSymbol|All files (*.*)|*.*|30376");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string strNomFichier = dlg.FileName;
                    CResultAErreur result = CSerializerObjetInFile.SaveToFile(SymboleEdite, C2iSymbole.c_idFichier, strNomFichier);
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
            dlg.Filter = I.T("Symbol (*.2iSymbol)|*.2iSymbol|All files (*.*)|*.*|30376");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CFormAlerte.Afficher(I.T("The current symbol will be replaced. Continue ?|30379"),
                    EFormAlerteType.Question) == DialogResult.No)
                    return;
                C2iSymbole newSymbole = new C2iSymbole();
                            
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(newSymbole, C2iSymbole.c_idFichier, dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result);
                else
                {
                    SymboleEdite = newSymbole;
                }
            }


        }

        private void m_btnModeSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (m_bEnableEventCheckedChange && m_btnModeSelection.Checked)
            {   
                if (m_panelEditionSymbole.ModeEdition != EModeEditeurSymbole.Selection)
                {
                    m_panelEditionSymbole.ModeEdition = EModeEditeurSymbole.Selection;
                    m_panelEditionSymbole.Focus();
                    Refresh();
                }
            }
        }

        private void m_btnModeZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (m_bEnableEventCheckedChange && m_btnModeZoom.Checked)
            {
                if (m_panelEditionSymbole.ModeEdition != EModeEditeurSymbole.Zoom)
                {
                    m_panelEditionSymbole.ModeEdition = EModeEditeurSymbole.Zoom;
                    m_panelEditionSymbole.Focus();
                    Refresh();
                }
            }
        }

        private void m_btnModeEditLine_CheckedChanged(object sender, EventArgs e)
        {
            if (m_bEnableEventCheckedChange && m_btnModeEditLine.Checked)
            {
                if (m_panelEditionSymbole.ModeEdition != EModeEditeurSymbole.EditionLigne &&
                    m_panelEditionSymbole.ModeEdition != EModeEditeurSymbole.EditionModificationPoint)
                {
                    if (m_panelEditionSymbole.Selection.Count == 1 &&
                        typeof(C2iSymboleLigne).IsAssignableFrom(m_panelEditionSymbole.Selection[0].GetType()))
                    {
                        m_panelEditionSymbole.EditeLine((C2iSymboleLigne)m_panelEditionSymbole.Selection[0]);
                    }
                }
            }
        }



        public void BoutonEditionLigneVisible(bool bVisible)
        {
            m_btnModeEditLine.Visible = bVisible;
        }


        public void SetBoutonSelection(bool bSelection)
        {
            m_btnModeSelection.Checked = bSelection;
        }

        private bool m_bEnableEventCheckedChange = true;
        private void m_panelEditionSymbole_OnChangeModeEdition(object sender, EventArgs e)
        {
            m_bEnableEventCheckedChange = false;
            if (m_panelEditionSymbole.ModeEdition == EModeEditeurSymbole.Selection)
                m_btnModeSelection.Checked = true;

            m_bEnableEventCheckedChange = true;
        }
    }
}
