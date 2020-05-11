using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using sc2i.common;
using timos.acteurs;
using timos.data;
using sc2i.win32.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common.unites;
using sc2i.common.unites.standard;
using sc2i.win32.data.dynamic;
using sc2i.data.dynamic;
using sc2i.workflow;
using System.Collections;
using sc2i.win32.data.navigation;
using System.Runtime.InteropServices;
using timos.interventions.crintervention;
using sc2i.formulaire.win32.editor;

namespace timos.interventions.preventives
{
    public partial class CEditeurUneOperationPreventive : CCustomizableListControl
    {
        private bool m_bAvecActeur = true;


        private Dictionary<object, List<CTypeOperation>> m_dicObjetToTypesOperations = new Dictionary<object, List<CTypeOperation>>();
        private Dictionary<string, CTypeOperation> m_dicTypesOperationsEnCours = null;

        private Dictionary<int, CPanelFormulaireSurElement> m_dicFormulaireToPanelControles = new Dictionary<int, CPanelFormulaireSurElement>();

        private CPanelFormulaireSurElement m_panelFormulaireEnCours = null;


        //--------------------------------------------
        public CEditeurUneOperationPreventive()
        {
            InitializeComponent();
            IUnite unite = CGestionnaireUnites.GetUnite (CClasseUniteTemps.c_idH);
            m_txtDuree.DefaultFormat = unite.LibelleCourt;
            m_txtDuree.UseValueFormat = false;
        }

        //--------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        //----------------------------------------------------------------------------
        public COperation Operation
        {
            get
            {
                return CurrentItem != null ? CurrentItem.Tag as COperation : null;
            }
        }

        //----------------------------------------------------------------------------
        public CTypeOperation TypeOperationParente
        {
            get
            {
                CCustomizableListAvecNiveau lst = AssociatedListControl as CCustomizableListAvecNiveau;
                if (lst == null)
                    return null;
                CCustomizableListItemANiveau item = lst.GetParent(CurrentItem as CCustomizableListItemANiveau);
                if (item != null)
                {
                    COperation operation = item.Tag as COperation;
                    if (operation != null)
                        return operation.TypeOperation;
                }
                return null;
            }
        }

        //----------------------------------------------------------------------------
        public IElementAOperationPrevisionnelle ElementAOperations
        {
            get
            {
                return ((CEditeurOperationsPreventives)AssociatedListControl).ElementAOperations;
            }
        }

        //----------------------------------------------------------------------------
        private class CLockerArbres { }

        //----------------------------------------------------------------------------
        private List<CTypeOperation> TypesOperationsPossibles
        {
            get
            {
                lock (typeof(CLockerArbres) )
                {
                    CCustomizableListItemANiveau item = CurrentItem as CCustomizableListItemANiveau;
                    if ( item == null || !m_extModeEdition.ModeEdition)
                        return null;
                    
                    CIntervention intervention = ElementAOperations as CIntervention;
                    CTypeOperation typeParent = TypeOperationParente;
                    if ( item.Niveau > 0 && typeParent == null )
                        return null;


                    object objParent = typeParent;
                    
                    if (typeParent == null)
                    {
                        if ( intervention != null )
                        {
                            objParent = intervention.TypeIntervention;
                        }
                    }
                    
                    List<CTypeOperation> lstOperations = null;
                   
                    //Si le dico contient des objets supprimés, c'est qu'il n'est plus bon
                    foreach (CObjetDonnee objet in m_dicObjetToTypesOperations.Keys)
                    {
                        if (!objet.IsValide())
                        {
                            m_dicObjetToTypesOperations.Clear();
                            break;
                        }
                    }
                    if (objParent == null)
                        objParent = DBNull.Value;

                    if ( !m_dicObjetToTypesOperations.TryGetValue ( objParent, out lstOperations ) )
                    {
                        lstOperations = new List<CTypeOperation>();
                        CListeObjetsDonnees liste;
                        if (typeParent != null)
                            liste = typeParent.TypesOperationsFilles;
                        else
                        {
                            liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CTypeOperation));
                            if (objParent is CTypeIntervention)
                            {
                                // Filtre les types d'opérations possibles en fonction du type d'Intervention
                                liste.Filtre = new CFiltreDataAvance(
                                   CTypeOperation.c_nomTable,
                                   CTypeIntervention_TypeOperation.c_nomTable + "." +
                                   CTypeIntervention.c_champId + "= @1 and " +
                                   CTypeOperation.c_champNiveau + " = @2",
                                   ((CTypeIntervention)objParent).Id,
                                   0);
                            }
                            else
                            {
                                // Filtre les types d'opérations possibles en fonction du type de Phase
                                liste.Filtre = new CFiltreData(
                                   CTypeOperation.c_champIdOperationParente + " is null");

                            }
                        }
                        foreach (CTypeOperation typeOp in liste)
                        {
                            lstOperations.Add(typeOp);
                        }
                        m_dicObjetToTypesOperations[objParent] = lstOperations;
                    }
                    return lstOperations;
                }
            }
        }

        //--------------------------------------------
        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            CResultAErreur result = base.MyInitChamps(item);

            CItemOperation itemOp = item as CItemOperation;
            if (itemOp != null && itemOp.Operation != null)
            {
                m_txtCommentaire.Text = itemOp.Operation.Commentaires;
                UpdateVisiDates(itemOp.Operation.TypeOperation);
                m_cmbTypeOperation.Visible = !LockEdition && !IsCreatingImage;
                m_lblTypeOperation.Width = m_cmbTypeOperation.Width;
                m_lblTypeOperation.Visible = LockEdition || IsCreatingImage;
                if (!IsCreatingImage)
                {
                    m_dicTypesOperationsEnCours = new Dictionary<string, CTypeOperation>();
                    List<CTypeOperation> lstTypes = TypesOperationsPossibles;
                    AutoCompleteStringCollection lstVals = new AutoCompleteStringCollection();
                    if (lstTypes != null)
                    {
                        foreach (CTypeOperation type in lstTypes)
                        {
                            m_dicTypesOperationsEnCours[type.Libelle.ToUpper()] = type;
                            lstVals.Add(type.Libelle);
                            if (type.Code.Length > 0 && !m_dicObjetToTypesOperations.ContainsKey(type.Code))
                            {
                                m_dicTypesOperationsEnCours[type.Code.ToUpper()] = type;
                                lstVals.Add(type.Code);
                            }
                        }
                    }
                    m_cmbTypeOperation.Items.Clear();
                    foreach (string strVal in lstVals)
                        m_cmbTypeOperation.Items.Add(strVal);
                }
                InitSelectEquipement();

                SetTypeOperation(itemOp.Operation.TypeOperation);
                if (itemOp.Operation.Duree != null)
                    m_txtDuree.UnitValue = new CValeurUnite(itemOp.Operation.Duree.Value, CClasseUniteTemps.c_idH);
                else
                    m_txtDuree.UnitValue = null;
                m_txtCommentaire.Text = itemOp.Operation.Commentaires;

                if (itemOp.Operation.TypeEquipement != null)
                    m_txtSelectEquipementLie.ElementSelectionne = itemOp.Operation.TypeEquipement;
                UpdateMarge();
                UpdateAlerte();
            }
            m_bIsInitializing = false;
            return result;
        }


        //----------------------------------------------------
        private void UpdateAlerte()
        {
            if ( Operation == null || !Operation.VerifieCoherenceHierarchique())
                m_picBoxWarning.Visible = true;
            else
                m_picBoxWarning.Visible = false;
            m_picBoxAddLine.Visible = !m_picBoxWarning.Visible;
        }
        

        private void UpdateMarge()
        {
            CCustomizableListItemANiveau itemOp = CurrentItem as CCustomizableListItemANiveau;
            if (itemOp.Niveau == 0)
                m_panelMarge.Visible = false;
            else
            {
                m_panelMarge.Width = itemOp.Niveau * 15;
                m_panelMarge.Visible = true;
            }
        }

        private void CalcHeight()
        {
            int nHeight = m_panelOperation.Height +
                    (m_panelLieEquipement.Visible?m_panelLieEquipement.Height:0)+
                    (m_panelFormulaireEnCours != null?m_panelFormulaire.Height:0);
            if (nHeight != Height)
                Height = nHeight;
        }
                

        //--------------------------------------------
        private void InitFormulaire( CFormulaire formulaire )
        {
            m_panelFormulaire.SuspendDrawing();
            int nIdFormulaire = formulaire != null?formulaire.Id:-1;
            foreach (KeyValuePair<int, CPanelFormulaireSurElement> kv in m_dicFormulaireToPanelControles)
            {
                if (kv.Key != nIdFormulaire)
                    kv.Value.Visible = false;
            }
            m_panelFormulaireEnCours = null;
            if (formulaire != null)
            {
                CPanelFormulaireSurElement panel = null;
                if (!m_dicFormulaireToPanelControles.TryGetValue(nIdFormulaire, out panel))
                {
                    panel = new CPanelFormulaireSurElement();
                    m_panelFormulaire.Controls.Add(panel);
                    panel.Dock = DockStyle.Fill;
                    m_dicFormulaireToPanelControles[nIdFormulaire] = panel;
                }
                if (panel.ElementEdite != Operation)
                {
                    panel.InitPanel(formulaire.Formulaire, Operation);
                }
                panel.Visible = true;
                panel.LockEdition = LockEdition;
                panel.Size = formulaire.Formulaire.Size;
                panel.AutoSize = formulaire.Formulaire.AutoSize;
                panel.AutoScroll = !formulaire.Formulaire.AutoSize;
                m_panelFormulaire.Height = panel.Height+3;
                m_panelFormulaireEnCours = panel;
                
            }
            m_panelFormulaire.ResumeDrawing();
        }

        //--------------------------------------------
        private void SetTypeOperation(CTypeOperation typeOperation)
        {
            bool bOldInitializing = m_bIsInitializing;
            if (typeOperation == null)
            {
                m_lblCode.Text = "";
                m_cmbTypeOperation.Text = "";
                m_lblTypeOperation.Text = "";
                m_panelLieEquipement.Visible = false;
                InitFormulaire(null);
                CalcHeight();
                UpdateAlerte();
            }
            else
            {
                if (Operation != null && !LockEdition)
                    Operation.TypeOperation = typeOperation;
                m_lblCode.Text = typeOperation.Code;
                if (!LockEdition && !IsCreatingImage)
                {
                    m_cmbTypeOperation.Visible = true;
                    m_lblTypeOperation.Visible = false;
                    m_cmbTypeOperation.Text = typeOperation.Libelle;
                    m_cmbTypeOperation.SelectedItem = typeOperation.Libelle;
                    m_cmbTypeOperation.LockEdition = LockEdition;
                    if (!LockEdition)
                    {
                        if (!Operation.IsNew() && typeOperation.VerrouillerLeTypeApresCreation)
                            m_cmbTypeOperation.LockEdition = true;
                    }
                }
                else
                {
                    m_lblTypeOperation.Text = typeOperation.Libelle;
                    m_cmbTypeOperation.Visible = false;
                    m_lblTypeOperation.Visible = true;
                }
                m_panelLieEquipement.Visible = typeOperation.IsLieeAEquipement;
                m_btnPoubelle.Visible = Operation.IsNew() || !typeOperation.InterditSuppressionApresCreation;

                

                UpdateVisiDates(typeOperation);
                InitFormulaire(typeOperation.FormulaireOpPrevisionnelle);
                CalcHeight();
                UpdateAlerte();
            }
            m_bIsInitializing = bOldInitializing;
        }


        //--------------------------------------------
        public override bool HasChange
        {
            get
            {
                if (m_panelFormulaireEnCours != null)
                    return true;//On ne peut pas savoir ! donc on considère que ça a tout
                                //le temps changé
                return base.HasChange;
            }
            set
            {
                base.HasChange = value;
            }
        }

        //--------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result =  base.MyMajChamps();
            if (!result)
                return result;
            COperation op = Operation;
            if (op != null)
            {
                //Le type d'opération est déjà affecté
                if (m_panelLieEquipement.Visible)
                    op.Equipement = m_txtSelectEquipementLie.ElementSelectionne as CEquipement;
                if (m_txtDuree.Visible)
                {
                    if (m_txtDuree.UnitValue != null)
                    {
                        CValeurUnite vu = m_txtDuree.UnitValue.ConvertTo(CClasseUniteTemps.c_idH);
                        op.Duree = vu.Valeur;
                    }
                    else
                        op.Duree = null;
                }
                op.Commentaires = m_txtCommentaire.Text;

                if (m_panelFormulaireEnCours != null)
                    m_panelFormulaireEnCours.AffecteValeursToElement();
            }
            return result;
                    

        }


        //--------------------------------------------
        private void InitZoneChoixTypeOperation(CTypeOperation typeOperation)
        {
            
        }

        //--------------------------------------------
        private void UpdateVisiDates(CTypeOperation typeOperation)
        {
            if (typeOperation == null)
                return;
            m_txtDuree.Visible = typeOperation.SaisieDureeAppliquee && !typeOperation.SaisieDureeParDateFin;
        }

        //----------------------------------------------------------------------------------------
        void InitSelectEquipement()
        {
            if (!IsCreatingImage)
            {
                CFiltreData filtre = null;

                if (Operation != null && Operation.TypeEquipement != null)
                {
                    filtre = CFiltreData.GetAndFiltre(filtre,
                        new CFiltreData(
                            CTypeEquipement.c_champId + " = @1",
                            Operation.TypeEquipement.Id));
                }

                CIntervention intervention = ElementAOperations as CIntervention;

                if (intervention != null &&
                    intervention.ElementAIntervention != null)
                {
                    filtre = CFiltreData.GetAndFiltre(filtre,
                            new CFiltreData(
                                CSite.c_champId + "=@1",
                                intervention.ElementAIntervention.Id));
                }

                m_txtSelectEquipementLie.InitAvecFiltreDeBase<CEquipement>(
                    "Libelle",
                    filtre,
                    true);
            }
        }

        /*//-------------------------------------------------------------------------
        private void m_txtTypeOperation_Validated(object sender, EventArgs e)
        {
            SetTypeOperationFromTextBox();
        }

        //-------------------------------------------------------------------------
        private void m_txtTypeOperation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetTypeOperationFromTextBox();
        }*/

        /*//-------------------------------------------------------------------------
        private void SetTypeOperationFromTextBox()
        {
            if (Operation == m_operationWhenEnterInZoneTypeOperation && m_bHasTextTypeOperationChange)
            {
                if (!m_bIsInitializing)
                    HasChange = true;
                string strText = m_txtTypeOperation.Text.ToUpper();
                if (m_dicTypesOperationsEnCours != null)
                {
                    CTypeOperation typeOperation = null;
                    if (m_dicTypesOperationsEnCours.TryGetValue(strText, out typeOperation))
                    {
                        SetTypeOperation(typeOperation);
                    }
                }
            }
        }*/

        //-------------------------------------------------------------------------
        private COperation m_operationWhenEnterInZoneTypeOperation = null;
        private void m_txtTypeOperation_Enter(object sender, EventArgs e)
        {
            m_operationWhenEnterInZoneTypeOperation = Operation;
            m_bHasTextTypeOperationChange = false;
        }


        //-------------------------------------------------------------------------
        private bool m_bHasTextTypeOperationChange = false;
        private void m_txtTypeOperation_TextChanged(object sender, EventArgs e)
        {
            if ( !m_bIsInitializing )
                m_bHasTextTypeOperationChange = true;

        }

        //-------------------------------------------------------------------------
        private void m_controlSaisie_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }


        public const int WM_SYSKEYUP = 0x105;
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_SYSKEYUP && CurrentItem is CCustomizableListItemANiveau)
            {
                Keys key = (Keys)m.WParam;
                if (key == Keys.Left)
                {
                    CEditeurOperationsPreventives ctrl = AssociatedListControl as CEditeurOperationsPreventives;
                    if (ctrl != null)
                    {
                        ctrl.DecrementeNiveau(CurrentItem as CItemOperation);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }
                if (key == Keys.Right)
                {
                    CEditeurOperationsPreventives ctrl = AssociatedListControl as CEditeurOperationsPreventives;
                    if (ctrl != null)
                    {
                        ctrl.IncrementeNiveau(CurrentItem as CItemOperation);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }

            }
            return base.ProcessKeyPreview(ref m);
        }

        private void m_cmbTypeOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
            SetTypeOperationFromCombo();

        }

        //----------------------------------------------------
        private void SetTypeOperationFromCombo()
        {
            string strText = m_cmbTypeOperation.Text.ToUpper();
            if (m_cmbTypeOperation.SelectedItem != null)
                strText = m_cmbTypeOperation.SelectedItem.ToString().ToUpper();

            if (m_dicTypesOperationsEnCours != null)
            {
                CTypeOperation typeOperation = null;
                if (m_dicTypesOperationsEnCours.TryGetValue(strText, out typeOperation))
                {
                    SetTypeOperation(typeOperation);
                }
            }
        }

        //----------------------------------------------------
        private bool m_bComboTextChanged = false;
        private void m_cmbTypeOperation_TextChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                HasChange = true;
                m_bComboTextChanged = true;
            }
        }

        private void m_cmbTypeOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                HasChange = true;
                m_bComboTextChanged = true;
            }
        }

        //----------------------------------------------------
        public override int GetItemHeight(CCustomizableListItem item)
        {
            if (item.IsMasque)
                return 0;
            if (item.Height != null)
                return item.Height.Value;
            int nHeight = m_panelOperation.Height;
            COperation op = item.Tag as COperation;

            CTypeOperation typeOp = op != null ? op.TypeOperation : null;
            if (typeOp != null)
            {
                if (typeOp.FormulaireCompteRendu != null)
                    nHeight += typeOp.FormulaireCompteRendu.Formulaire.Height;
                if (typeOp.IsLieeAEquipement)
                    nHeight += m_panelLieEquipement.Height;
                item.Height = nHeight;
            }
            else
                nHeight = m_panelOperation.Height;
            return nHeight;
        }


        //----------------------------------------------------
        private void m_cmbTypeOperation_Leave(object sender, EventArgs e)
        {
            if (m_operationSurEnterDropDown != null && m_operationSurEnterDropDown.IsValide() && m_operationSurEnterDropDown == Operation &&
                m_bComboTextChanged)
            {
                SetTypeOperationFromCombo();
            }
        }
        
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        public const int CB_SHOWDROPDOWN = 0x14F;


        private void m_cmbTypeOperation_KeyUp(object sender, KeyEventArgs e)
        {
            AutoDropDown();
        }

        private COperation m_operationSurEnterDropDown = null;
        private void m_cmbTypeOperation_Enter(object sender, EventArgs e)
        {
            //AutoDropDown();
            m_operationSurEnterDropDown = Operation;
        }

        private void AutoDropDown()
        {
            if (Operation != null && !LockEdition)
            {
                bool bDropDown = true;
                if (Operation.TypeOperation != null && Operation.TypeOperation.Libelle == m_cmbTypeOperation.Text)
                    bDropDown = false;
                if (bDropDown)
                    SendMessage(m_cmbTypeOperation.Handle.ToInt32(), CB_SHOWDROPDOWN, 1, IntPtr.Zero);
            }
        }


        //---------------------------------------------------------------------------
        private Point? m_ptStartDrag = null;
        private void m_picOperation_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left )
            {
                m_ptStartDrag = new Point(e.X, e.Y);
                m_picOperation.Capture = true;
            }
        }

        //---------------------------------------------------------------------------
        private void m_picOperation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_ptStartDrag != null)
            {
                if (Math.Abs(e.X - m_ptStartDrag.Value.X) > 3 || Math.Abs(e.Y - m_ptStartDrag.Value.Y) > 3)
                {
                    StartDragDrop ( 
                        new Point ( e.X, e.Y ),
                        DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Link,
                        new CDonneeAdditionnelleDragDrop (typeof(CReferenceObjetDonnee),  new CReferenceObjetDonnee(Operation))
                        );
                }
            }
        }

        //---------------------------------------------------------------------------
        private void m_picOperation_MouseUp(object sender, MouseEventArgs e)
        {
            m_ptStartDrag = null;
            m_picOperation.Capture = false;
        }

        //---------------------------------------------------------------------------
        private void m_btnPoubelle_Click(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CEditeurOperationsPreventives ctrlListe = AssociatedListControl as CEditeurOperationsPreventives;
                if (ctrlListe != null && CurrentItem != null)
                {
                    CItemOperation item = CurrentItem as CItemOperation;
                    if (item != null && item.Operation !=null)
                    {
                        if (CFormAlerte.Afficher(I.T("Delete operation @1|20679", Operation.Libelle),
                            EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                            ctrlListe.RemoveItem(CurrentItem, true);
                    }
                }
            }
        }

        private void m_picBoxAddLine_Click(object sender, EventArgs e)
        {
            Control parent = Parent;
            while (parent != null && !(parent is CEditeurOperationsPreventives))
                parent = parent.Parent;
            CEditeurOperationsPreventives editeur = parent as CEditeurOperationsPreventives;
            if (editeur != null)
                editeur.AddOperationALaFin();
        }

        
        

        
    }
}

