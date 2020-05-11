using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.common.memorydb;
using timos.data.projet.besoin;
using sc2i.data;
using sc2i.common;
using sc2i.win32.data.navigation;
using System.Threading;
using timos.data;

namespace timos.projet.besoin
{
    public partial class CControleListeBesoins : CCustomizableListAvecNiveau
    {
        private CPhaseSpecifications m_phaseSpecifications = null;

        private CControleBesoin m_controleConception = null;

        //--------------------------------------------------------------------
        public CControleListeBesoins()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                m_controleConception = new CControleBesoin();
                ItemControl = m_controleConception;
                m_controleConception.OnLeaveLastControl += new CCustomizableListControl.OnLeaveLastControlEventHandler(ItemControl_OnLeaveLastControl);
            }
        }

        //--------------------------------------------------------------------
        [Browsable(false)]
        public CPhaseSpecifications PhaseSpecifications
        {
            get
            {
                return m_phaseSpecifications;
            }
        }


        //--------------------------------------------------------------------
        [Browsable(false)]
        public override CCustomizableListControl ItemControl
        {
            get
            {
                return base.ItemControl;
            }
            set
            {
                base.ItemControl = value;
            }
        }

        //--------------------------------------------------------------------
        public CItemBesoin GetItem(CBesoin besoin)
        {
            if ( besoin == null )
                return null;
            foreach (CItemBesoin item in Items)
            {
                if (besoin.Equals(item.Besoin))
                    return item;
            }
            return null;
        }

        //--------------------------------------------------------------------
        public void RefreshBesoin(CBesoin besoin, bool bAvecFils)
        {
            CItemBesoin item = GetItem(besoin);
            if (item != null)
            {
                RefreshItem(item);
                if (bAvecFils)
                {
                    foreach (CBesoin fils in besoin.BesoinsFils)
                        RefreshBesoin(fils, true);
                }
            }
        }


        //--------------------------------------------------------------------
        private bool ItemControl_OnLeaveLastControl(object sender, EventArgs args)
        {
            if ( sender != null )
            {
                //Regarde si le dernier item est vide
                if (Items.Count() > 0 && !LockEdition && m_phaseSpecifications != null)
                {
                    CItemBesoin item = Items.ElementAt(Items.Count() - 1) as CItemBesoin;
                    if (item.Besoin != null && item.Besoin.Libelle.Trim().Length > 0)
                    {
                        CBesoin besoin = new CBesoin(m_phaseSpecifications.ContexteDonnee);
                        besoin.CreateNewInCurrentContexte();
                        if (m_phaseSpecifications.Projet != null && m_phaseSpecifications.Projet.TypeProjet != null)
                            besoin.TypeBesoinCode = m_phaseSpecifications.Projet.TypeProjet.CodeTypeBesoinParDefaut;
                        besoin.PhaseSpecifications = m_phaseSpecifications;
                        CItemBesoin prec = null;
                        if (Items.Count() > 0)
                        {
                            prec = GetVisibleItemBefore(Items.Count()) as CItemBesoin;
                            if (prec != null)
                            {
                                besoin.BesoinParent = prec.Besoin.BesoinParent;
                            }
                        }
                        item = new CItemBesoin(besoin, prec!=null?prec.ItemParent as CItemBesoin:null);
                        AddItem(item, true);
                        CurrentItemIndex = item.Index;
                        ItemControl.GetTabOrderedControlsList()[0].Focus();
                        return true;
                    }

                }
            }
            return false;
        }

        //--------------------------------------------------------------------
        public void Init(CPhaseSpecifications phaseSpecifications)
        {
            CancelEdit();
            CurrentItemIndex = null;
            Items = new CCustomizableListItem[0];
            m_phaseSpecifications = phaseSpecifications;

            if (m_phaseSpecifications != null)
            {
                List<CCustomizableListItem> items = new List<CCustomizableListItem>();
                CListeObjetsDonnees lstBesoins = m_phaseSpecifications.Besoins;
                lstBesoins.ReadDependances("BesoinsFils", "TypeProjet", "TypeEquipement", "TypeConsommable", "TypeOperation");
                CRelationBesoin_Satisfaction.PreloadBesoinsSatisfaits(lstBesoins);
                lstBesoins.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
                foreach (CBesoin besoin in lstBesoins)
                {
                    AddItemBesoinEtFils(null, besoin, items);
                }
                Items = items.ToArray();
            }
            m_panelResumeElementACout.Init(m_phaseSpecifications);
            Refresh();
        }

        //--------------------------------------------------------------------
        private void AddItemBesoinEtFils(CItemBesoin itemParent, CBesoin besoin, List<CCustomizableListItem> lstItems)
        {
            CItemBesoin item = new CItemBesoin(besoin, itemParent);
            lstItems.Add(item);
            foreach (CBesoin besoinFils in besoin.BesoinsFils)
                AddItemBesoinEtFils(item, besoinFils, lstItems);
        }

        //--------------------------------------------------------------------
        public Dictionary<CBesoin, Rectangle> GetPositionsBesoins()
        {
            Dictionary<CBesoin, Rectangle> dic = new Dictionary<CBesoin, Rectangle>();
            int nY = m_panelDessin.AutoScrollPosition.Y;
            foreach (CItemBesoin item in Items)
            {
                int nHeight = ItemControl.GetItemHeight(item);
                dic.Add(item.Besoin, new Rectangle(0, nY, m_panelDessin.Width, nHeight));

                nY += nHeight;
            }
            return dic;
        }

        //--------------------------------------------------------------------
        protected override void HighlightZoneItem(Point ptScreen)
        {
            if (m_nIdBesoinLinkingSatisfaction==null)
                base.HighlightZoneItem(ptScreen);
            else
            {
                Rectangle rct = GetItemRect(m_nIdBesoinLinkingSatisfaction.Value);
                if (rct != m_lastRectHighlight)
                {
                    HideHighlight();
                    Brush br = new SolidBrush(Color.FromArgb(64, 0, 255, 0));
                    Graphics g = m_panelDessin.CreateGraphics();
                    g.FillRectangle(br, rct);
                    g.Dispose();
                    br.Dispose();
                    m_lastRectHighlight = rct;
                }
                Point ptLocal = m_panelDessin.PointToScreen(new Point(rct.Left, rct.Top));
                ptLocal = m_panelDessin.PointToClient(new Point ( ptScreen.X - m_picFillBesoin.Width/2, ptLocal.Y) );
                m_picFillBesoin.Visible = true;
                m_picFillBesoin.Location = ptLocal;
            }
        }

        protected override void HideHighlight()
        {
            base.HideHighlight();
            m_picFillBesoin.Visible = false;
        }

        //--------------------------------------------------------------------
        private ISatisfactionBesoin m_satisfactionEnCoursDragDrop = null;
        private int? m_nIdBesoinLinkingSatisfaction = null;
        public override DragDropEffects GetDragDropEffect(DragEventArgs eventArgs)
        {
            m_nIdBesoinLinkingSatisfaction = null;
            IDataObject data = eventArgs.Data;
            DragDropEffects e = DragDropEffects.None;
            if ( !LockEdition )
                e = base.GetDragDropEffect(eventArgs);
            if (e != DragDropEffects.None)
                return e;
            if (m_phaseSpecifications == null)
                return e;
            
            if (m_satisfactionEnCoursDragDrop != null)
            {
                //Regarde si la satisfaction peut satisfaire le besoin sous la souris
                Point pt = m_panelDessin.PointToClient(new Point(eventArgs.X, eventArgs.Y));
                int? nItemIndex = GetItemIndexAtPosition(pt.Y);
                if (nItemIndex != null)
                {
                    CItemBesoin item = Items[nItemIndex.Value] as CItemBesoin;
                    if (item != null && item.Besoin != null &&
                        m_satisfactionEnCoursDragDrop.CanSatisfaire(item.Besoin))
                    {
                        m_nIdBesoinLinkingSatisfaction = item.Index;
                        return DragDropEffects.Link;
                    }
                }
                else
                {
                    CBesoin besoinDrag = m_satisfactionEnCoursDragDrop as CBesoin;
                    if (besoinDrag != null && besoinDrag.PhaseSpecifications != m_phaseSpecifications && !LockEdition)
                    {
                        return DragDropEffects.Copy;
                    }
                }
            }
           

            return e;
        }

        //--------------------------------------------------------------------
        protected override void m_panelDessin_DragEnter(object sender, DragEventArgs e)
        {
            m_satisfactionEnCoursDragDrop = null;
            e.Effect = DragDropEffects.None;
            if ( !LockEdition )
                base.m_panelDessin_DragEnter(sender, e);
            if (e.Effect == DragDropEffects.None)
            {
                CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refObj != null)
                {
                    m_satisfactionEnCoursDragDrop = refObj.GetObjet(m_phaseSpecifications.ContexteDonnee) as ISatisfactionBesoin;
                    if (m_satisfactionEnCoursDragDrop != null)
                    {
                        e.Effect = GetDragDropEffect(e);
                    }
                }
            }
        }


        //--------------------------------------------------------------------
        protected override void m_panelDessin_DragOver(object sender, DragEventArgs e)
        {
            if (!LockEdition)
                base.m_panelDessin_DragOver(sender, e);
            else
            {
                e.Effect = GetDragDropEffect(e);
                if (e.Effect == DragDropEffects.Link)
                    HighlightZoneItem(new Point(e.X, e.Y));
            }
        }
        
        //--------------------------------------------------------------------
        protected override void m_panelDessin_DragDrop(object sender, DragEventArgs e)
        {
            HideHighlight();
            DragDropEffects eff = GetDragDropEffect(e);
            if (eff == DragDropEffects.Move && !LockEdition)
                base.m_panelDessin_DragDrop(sender, e);
            if (eff == DragDropEffects.Link && m_nIdBesoinLinkingSatisfaction != null && m_satisfactionEnCoursDragDrop != null)
            {
                CItemBesoin item = Items[m_nIdBesoinLinkingSatisfaction.Value] as CItemBesoin;
                if (item != null && item.Besoin != null && m_satisfactionEnCoursDragDrop.CanSatisfaire(item.Besoin))
                {
                    if (CUtilElementACout.IsSourceDe(item.Besoin, m_satisfactionEnCoursDragDrop))
                    {
                        CFormAlerte.Afficher(I.T("Can not perform requested operation. @1 is a solution of @2|20675",
                            item.Besoin.Libelle,
                            m_satisfactionEnCoursDragDrop.LibelleSatisfactionComplet),EFormAlerteType.Exclamation);
                        return;
                    }
                    if (CFormAlerte.Afficher (I.T("@1 will be considered as a solution of @2. Continue ?|20631",
                        m_satisfactionEnCoursDragDrop.LibelleSatisfactionComplet, item.Besoin.Libelle),
                        EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                    {
                        CBesoin besoin = item.Besoin;
                        if (LockEdition)
                        {
                            besoin = item.Besoin;
                            besoin.BeginEdit();
                        }
                        besoin.AddSatisfaction(m_satisfactionEnCoursDragDrop, null);
                        if (LockEdition)
                        {
                            CResultAErreur result = besoin.CommitEdit();
                            if (!result)
                            {
                                CFormAlerte.Afficher(result.Erreur);
                                besoin.CancelEdit();
                            }
                        }
                        RefreshItem(item);
                        m_panelDessin.Invalidate();
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
            }
            else if (eff == DragDropEffects.Copy && m_phaseSpecifications != null && !LockEdition)
            {
                CBesoin besoinDrag  = m_satisfactionEnCoursDragDrop as CBesoin;
                if ( besoinDrag != null && besoinDrag.PhaseSpecifications != m_phaseSpecifications )
                {
                    CItemBesoin newItem = CreateSoluce(besoinDrag);
                    RenumerotteItems();
                    Refresh();
                }
            }
        }

        //---------------------------------------------------------------
        private CItemBesoin CreateSoluce(CBesoin besoinSolutionné)
        {
            CBesoin newBesoin = new CBesoin(m_phaseSpecifications.ContexteDonnee);
            newBesoin.CreateNewInCurrentContexte();
            newBesoin.PhaseSpecifications = m_phaseSpecifications;

            Dictionary<int, int> dicMap = newBesoin.CopyFromTemplate(besoinSolutionné);
            if (dicMap != null)
            {
                foreach (KeyValuePair<int, int> kv in dicMap)
                {
                    CBesoin bOriginal = new CBesoin(m_phaseSpecifications.ContexteDonnee);
                    if (bOriginal.ReadIfExists(kv.Key, false))
                    {
                        if (!bOriginal.HasChildren)
                        {
                            CBesoin bNew = new CBesoin(m_phaseSpecifications.ContexteDonnee);
                            if (bNew.ReadIfExists(kv.Value, false))
                            {
                                bOriginal.AddSatisfaction(bNew, null);
                            }
                        }
                    }
                }
            }
            CItemBesoin item = new CItemBesoin(newBesoin, null);
            AddItem(item, false);
            item.Index = Items.Count();
            AddItemsFils(item);

            return item;
        }

        //---------------------------------------------------------------
        internal void AddItemsFils(CItemBesoin itemParent)
        {
            CBesoin b = itemParent.Besoin;
            foreach (CBesoin fils in b.BesoinsFils)
            {
                CItemBesoin item = new CItemBesoin(fils, itemParent);
                item.Index = fils.Index;
                AddItem(item, false);
                AddItemsFils(item);
            }
        }

        //---------------------------------------------------------------
        private void CControleListeBesoins_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        //--------------------------------------------------
        protected override void RenumerotteItems()
        {
            base.RenumerotteItems();
            if (!LockEdition)
            {
                foreach (CItemBesoin item in Items)
                {
                    if ( item.Besoin != null && item.Besoin.IsValide() )
                        item.Besoin.Index = item.Index;
                }
            }
        }

        //--------------------------------------------------
        internal void Collapse(CItemBesoin item)
        {
            if (item == null || item.Besoin == null)
                return;
            int nNiveauSuivant = item.Besoin.Niveau + 1;
            item.SetIsCollapse (true );
            foreach (CItemBesoin child in GetItemsDependants(item))
            {
                if (child.Besoin != null)
                {
                    child.IsMasque = true;
                    RefreshItem(child);
                }
            }
            Refresh();
        }

        //--------------------------------------------------
        internal void Expand(CItemBesoin item)
        {
            if (item == null || item.Besoin == null)
                return;
            int nNiveauSuivant = item.Besoin.Niveau + 1;
            item.SetIsCollapse ( false );
            Dictionary<int, bool> dicMasquage = new Dictionary<int, bool>();
            dicMasquage[nNiveauSuivant] = false;
            RefreshItem(item);
            foreach (CItemBesoin child in GetItemsDependants(item))
            {
                child.IsMasque = dicMasquage[child.Besoin.Niveau];
                dicMasquage[child.Besoin.Niveau + 1] = child.IsCollapse;
                RefreshItem(child);
            }

            Refresh();
        }

        //--------------------------------------------------
        public override void RemoveItem(int nIndex, bool bRedraw)
        {
            if (nIndex >= 0 && nIndex < Items.Count())
            {
                CItemBesoin item = Items[nIndex] as CItemBesoin;
                if (item != null)
                {
                    CurrentItemIndex = null;
                    List<CCustomizableListItemANiveau> lstToDelete =  GetItemsDependants(item);
                    lstToDelete.Insert(0, item);
                    lstToDelete.Reverse();
                    foreach (CItemBesoin toDelete in lstToDelete)
                    {
                        CResultAErreur result = item.Besoin.Delete(true);
                        if (!result)
                            CFormAlerte.Afficher(result.Erreur);
                        else
                            base.RemoveItem(item.Index, false);
                    }
                    Refresh();
                }
            }
        }

        //--------------------------------------------------
        private bool m_bIsDispatchingCout = false;
        public void AfterTotalChanged(CBesoin besoin)
        {
            if (m_bIsDispatchingCout || besoin == null)
                return;
            m_bIsDispatchingCout = true;
            bool bHasDeps = false;
            foreach (CBesoin b in besoin.GetTousLesBesoinsDontLeCoutEstDépendantDeMonCout())
            {
                CUtilElementACout.OnChangeCout(b, false, false);
                CUtilElementACout.OnChangeCout(b, true, false);
                RefreshBesoin(b, false);
                bHasDeps = true;
            }
            m_panelResumeElementACout.Init(m_phaseSpecifications);
            if ( bHasDeps )
                m_panelDessin.Invalidate();
            m_bIsDispatchingCout = false;
        }

        //--------------------------------------------------
        private void m_pictureMap_Click(object sender, EventArgs e)
        {
            if (m_phaseSpecifications != null)
            {
                CFormEditionStandard frm = FindForm() as CFormEditionStandard;
                CFormMapBesoinsPopup.Show(frm, m_phaseSpecifications);
            }
        }

        private void CControleListeBesoins_Load(object sender, EventArgs e)
        {
            ModeAffichage = CTimosAppRegistre.ModeAffichageBesoins;            
        }

        //--------------------------------------------------
        public void InterditCout()
        {
            ModeAffichage = EModeAffichageBesoins.ModeSansCout;
            m_panelModes.Visible = false;
        }

        //--------------------------------------------------
        private void m_picExtraireListe_Click(object sender, EventArgs e)
        {
            CFormPhaseSpecificationsPopup.ShowPhase(m_phaseSpecifications);
        }

        //--------------------------------------------------
        private void m_btnAddBesoin_LinkClicked(object sender, EventArgs e)
        {
            if (m_phaseSpecifications != null && !LockEdition)
            {
                CBesoin besoin = new CBesoin(PhaseSpecifications.ContexteDonnee);
                besoin.CreateNewInCurrentContexte();
                besoin.PhaseSpecifications = PhaseSpecifications;
                if (m_phaseSpecifications.Projet != null && m_phaseSpecifications.Projet.TypeProjet != null)
                    besoin.TypeBesoinCode = m_phaseSpecifications.Projet.TypeProjet.CodeTypeBesoinParDefaut;
                       
                CItemBesoin item = new CItemBesoin(besoin, null);
                item.Tag = besoin;
                if (Items.Length > 0)
                {
                    CItemBesoin lastItem = Items[Items.Length - 1] as CItemBesoin;
                    if (lastItem != null && lastItem.Besoin != null)
                        besoin.BesoinParent = lastItem.Besoin.BesoinParent;
                }
                AddItem(item, true);
                CurrentItemIndex = item.Index;
            }
        }

        public override bool LockEdition
        {
            get
            {
                return base.LockEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                base.LockEdition = value;
                m_btnAddBesoin.Visible = !value;
            }
        }

        //--------------------------------------------------
        [Browsable(false)]
        private bool m_bIsSettingAffichage = false;
        public EModeAffichageBesoins ModeAffichage
        {
            get
            {
                if (m_controleConception != null)
                    return m_controleConception.ModeAffichage;
                return EModeAffichageBesoins.ModeSansCout;
            }
            set
            {
                if (m_controleConception != null && !m_bIsSettingAffichage)
                {
                    m_bIsSettingAffichage = true;
                    if (CurrentItemIndex != null)
                        MajChamps();
                    if (value != m_controleConception.ModeAffichage)
                    {
                        m_controleConception.ModeAffichage = value;
                        Refill();
                        CTimosAppRegistre.ModeAffichageBesoins = value;
                    }
                    m_btnModeConception.Checked = value == EModeAffichageBesoins.ModeConception;
                    m_btnModeSansCout.Checked = value == EModeAffichageBesoins.ModeSansCout;
                    m_btnModeSuivi.Checked = value == EModeAffichageBesoins.ModeSuivi;
                    m_bIsSettingAffichage = false;
                }
            }
        }

        //--------------------------------------------------
        private void UpdateModeAffichageFromBoutons()
        {
            if (m_btnModeSuivi.Checked)
                ModeAffichage = EModeAffichageBesoins.ModeSuivi;
            if (m_btnModeConception.Checked)
                ModeAffichage = EModeAffichageBesoins.ModeConception;
            if (m_btnModeSansCout.Checked)
                ModeAffichage = EModeAffichageBesoins.ModeSansCout;
        }

        //--------------------------------------------------
        private void m_btnModeSansCout_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeAffichageFromBoutons();

        }

        //--------------------------------------------------
        private void m_btnModeConception_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeAffichageFromBoutons();
        }

        //--------------------------------------------------
        private void m_btnModeSuivi_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeAffichageFromBoutons();
        }

        //--------------------------------------------------
        private void m_picRecalculer_Click(object sender, EventArgs e)
        {
            if (!LockEdition)
            {
                CFormProgressTimos.StartThreadWithProgress(I.T("Calculated costs|20706"),
                    new ThreadStart(RecalculeCouts), false);
                
            }
        }

        //--------------------------------------------------
        private void RecalculeCouts()
        {
            CProjet projet = m_phaseSpecifications.Projet;
            CFormProgressTimos.Indicateur.SetBornesSegment(0, 100);
            CFormProgressTimos.Indicateur.PushSegment(0, 50);
            CFormProgressTimos.Indicateur.SetBornesSegment(0, 100);
            CFormProgressTimos.Indicateur.PushLibelle(I.T("Calculated estimated costs|20707"));
            if (projet != null)
                projet.RecalcEstimatedCost(CFormProgression.Indicateur);
            else
                PhaseSpecifications.RecalcEstimatedCost(CFormProgressTimos.Indicateur);
            CFormProgressTimos.Indicateur.PopLibelle();
            CFormProgressTimos.Indicateur.PopSegment();
            CFormProgressTimos.Indicateur.PushSegment(50, 100);
            CFormProgressTimos.Indicateur.SetBornesSegment(0, 100);
            CFormProgressTimos.Indicateur.PushLibelle(I.T("Calculated actual costs|20708"));
            if (projet != null)
                projet.RecalcActualCost(CFormProgression.Indicateur);
            else
                PhaseSpecifications.RecalcActualCost(CFormProgressTimos.Indicateur);
            CFormProgressTimos.Indicateur.PopLibelle();
            CFormProgressTimos.Indicateur.PopSegment();
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        Refill();
                        m_panelResumeElementACout.Init(m_phaseSpecifications);
                    }
                    catch { }
                });
            }
            catch { }
            
        }
    }

    public class CItemBesoin : CCustomizableListItemANiveau
    {
        private bool m_bIsCollapse = false;

        //--------------------------------------------------
        public CItemBesoin(CBesoin besoin, CItemBesoin itemParent)
            :base(itemParent)
        {
            Tag = besoin;
        }
        //--------------------------------------------------
        public CBesoin Besoin
        {
            get
            {
                return Tag as CBesoin;
            }
            set
            {
                Tag = value;
            }
        }

        //--------------------------------------------------
        public override bool IsCollapse
        {
            get
            {
                return m_bIsCollapse;
            }
        }

        //--------------------------------------------------
        public void SetIsCollapse(bool bIsCollapse)
        {
            m_bIsCollapse = bIsCollapse;
        }

        //--------------------------------------------------
        public override Color? ColorInactive
        {
            get
            {
                if (Besoin != null && Besoin.IsValide())
                {
                    int nNiveau = Besoin.Niveau;
                    int nR = 255;
                    int nG = 255;
                    int nB = 255;
                    //réduction des couleurs suivant les niveaux :
                    /*0:1->5 : R et G
                     * 1:6->10 : R et B
                     * 2:11->15 : G et B
                     * 3:16->20 : R
                     * 4:21->25 : G
                     * 5:26->30 : B
                     * Au dela, reste blanc (ça permet de changer les couleurs sur 30 niveaux !
                     */
                    int nTranche = (nNiveau) / 5;
                    int nDec = ((nNiveau) % 5 + 1) * 25;
                    switch (nTranche)
                    {
                        case 0:
                            nR = 255 - nDec;
                            nG = 255 - nDec;
                            break;
                        case 1:
                            nR = 255 - nDec;
                            nB = 255 - nDec;
                            break;
                        case 2:
                            nG = 255 - nDec;
                            nB = 255 - nDec;
                            break;
                        case 3:
                            nR = 255 - nDec;
                            break;
                        case 4:
                            nG = 255 - nDec;
                            break;
                        case 5:
                            nB = 255 - nDec;
                            break;
                    }
                    return Color.FromArgb(nR, nG, nB);
                }
                return Color.White;
            }
        }

        //----------------------------------------------
        public override bool OnChangeParent(CCustomizableListItemANiveau item)
        {
            CItemBesoin b = item as CItemBesoin;
            if (Besoin != null && (b != null || item == null))
            {
                if (b != null)
                {
                    Besoin.BesoinParent = b.Besoin;
                    return Besoin.BesoinParent == b.Besoin;
                }
                else
                    Besoin.BesoinParent = null;
                return true;
            }
            return false;
        }

        //----------------------------------------------
        public override int Index
        {
            get
            {
                return base.Index;
            }
            set
            {
                base.Index = value;
                if (Besoin != null && Besoin.IsValide())
                    Besoin.Index = value;
            }
        }

        //----------------------------------------------
        public double CoutReel
        {
            get
            {
                double fCout = Besoin.CoutReel;
                foreach (CItemBesoin item in ChildItems)
                {
                    CImputationsCouts imputations = item.Besoin.GetImputationsAFaireSurUtilisateursDeCout();
                    if (imputations.GetCoutImputéeA(Besoin, true) == 0)
                        fCout += item.CoutReel;
                }
                return fCout;
            }
        }

        //----------------------------------------------
        public double CoutSaisi
        {
            get
            {
                if (ChildItems.Count() == 0)
                {
                    double? fTmp = Besoin.CoutSaisiTotalAvecRegroupement;
                    if (fTmp != null)
                        return fTmp.Value;
                    return 0;
                }
                else
                {
                    double fCout = 0;
                    foreach (CItemBesoin item in ChildItems)
                        fCout += item.CoutSaisi;
                    return fCout;
                }
            }
        }

        //----------------------------------------------
        public double CoutPrevisionnel
        {
            get
            {
                double fCout = Besoin.CoutPrevisionnel;
                foreach (CItemBesoin item in ChildItems)
                {
                    CImputationsCouts imputations = item.Besoin.GetImputationsAFaireSurUtilisateursDeCout();
                    if (imputations.GetCoutImputéeA(Besoin, false) == 0)
                        fCout += item.CoutReel;
                }
                return fCout;
            }
        }


    }
}
