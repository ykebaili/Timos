using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.win32.common.customizableList;
using sc2i.win32.common;
using sc2i.common.unites;
using System.Reflection;
using timos.data.projet.besoin;
using timos.Properties;
using System.Collections;
using sc2i.data;
using sc2i.win32.data;
using timos.General;
using sc2i.process;
using sc2i.win32.data.navigation;
using timos.Controles;
using timos.projet.besoin.editeur;

namespace timos.projet.besoin
{
    public partial class CControleBesoin : CCustomizableListControl
    {
        //private CPhaseSpecifications m_phaseShowSatisfait = null;
        public const int WM_SYSKEYUP = 0x105;
        private CControleQuantite m_controleQuantite = null;

        private CListeObjetDonneeGenerique<CPhaseSpecifications> m_listeTemplates = null;

        private class CStockEditeurs
        {
            private Dictionary<ETypeEditeurBesoin, Dictionary<Type, IEditeurDonneeBesoin>> m_dic = new Dictionary<ETypeEditeurBesoin, Dictionary<Type, IEditeurDonneeBesoin>>();

            public IEditeurDonneeBesoin GetEditeur(ETypeEditeurBesoin kindEditeur, Type typeDonnee)
            {
                Dictionary<Type, IEditeurDonneeBesoin> dic = null;
                if (m_dic.TryGetValue(kindEditeur, out dic))
                {
                    IEditeurDonneeBesoin editeur = null;
                    if (dic.TryGetValue(typeDonnee, out editeur))
                        return editeur;
                }
                return null;
            }

            public void SetEditeur(ETypeEditeurBesoin kindEditeur, Type typeDonnee, IEditeurDonneeBesoin editeur)
            {
                Dictionary<Type, IEditeurDonneeBesoin> dic = null;
                if (!m_dic.TryGetValue(kindEditeur, out dic))
                {
                    dic = new Dictionary<Type, IEditeurDonneeBesoin>();
                    m_dic[kindEditeur] = dic;
                }
                dic[typeDonnee] = editeur;
            }
        }

        //Stocke les éditeurs de cout alloués pour ne pas avoir à les réallouer à chaque appel
        private CStockEditeurs m_editeursAlloues = new CStockEditeurs();

        private Dictionary<ETypeEditeurBesoin, IEditeurDonneeBesoin> m_dicEditeursEnCours = new Dictionary<ETypeEditeurBesoin, IEditeurDonneeBesoin>();

        private int m_nDefaultHeight = 0;

        private EModeAffichageBesoins m_modeAffichage = EModeAffichageBesoins.ModeConception;

        //-----------------------------------------------------------------------
        public CControleBesoin()
            : base()
        {
            InitializeComponent();
            m_nDefaultHeight = m_panelCentral.Height;
            m_controleQuantite = new CControleQuantite();
            m_controleQuantite.OnDeleteQuantite += new EventHandler(m_controleQuantite_OnDeleteQuantite);
            m_controleQuantite.DataChanged += new EventHandler(m_controleQuantite_DataChanged);
            m_controleQuantite.QuantiteChanged += new EventHandler(m_controleQuantite_QuantiteChanged);
            m_wndListeQuantites.ItemControl = m_controleQuantite;

            m_listeTemplates = null;
            if (!DesignMode)
                UpdateMenuTypeCalculCout();

        }

        //-----------------------------------------------------------------------
        void m_controleQuantite_QuantiteChanged(object sender, EventArgs e)
        {
            if (Besoin != null)
            {
                foreach (CBesoin besoin in Besoin.GetTousLesBesoinsDontLeCoutDependDeMesQuantites())
                    ((CControleListeBesoins)AssociatedListControl).RefreshBesoin(besoin, false);
            }
        }

        
        //-----------------------------------------------------------------------
        public EModeAffichageBesoins ModeAffichage
        {
            get
            {
                return m_modeAffichage;
            }
            set
            {
                m_modeAffichage = value;
            }
        }

        //-----------------------------------------------------------------------
        private void UpdateVisibiliteCout()
        {
            bool bAfficheCout = m_modeAffichage == EModeAffichageBesoins.ModeConception;
            m_panelCoutTotal.Visible = bAfficheCout;
            m_panelDetailCout.Visible = bAfficheCout;
            m_panelTotalTotal.Visible = bAfficheCout;
            if (ModeAffichage != EModeAffichageBesoins.ModeSansCout)
            {
                m_panelCentral.Dock = DockStyle.Left;
                m_panelRegroupement.Dock = DockStyle.Left;
            }
            else
            {
                m_panelCentral.Dock = DockStyle.Fill;
                m_panelRegroupement.Dock = DockStyle.Right;
            }
            m_panelSuivi.Width = 690;
            m_panelSuivi.Visible = m_modeAffichage == EModeAffichageBesoins.ModeSuivi;
        }

        //-----------------------------------------------------------------------
        void m_controleQuantite_DataChanged(object sender, EventArgs e)
        {
            HasChange = true;
        }

        //-----------------------------------------------
        private IEditeurDonneeBesoin GetEditeur(ETypeEditeurBesoin kindEditeur, IDonneeBesoin calcul, CBesoin besoin)
        {
            IEditeurDonneeBesoin editeur = null;
                
            if (calcul != null)
            {
                editeur = m_editeursAlloues.GetEditeur(kindEditeur, calcul.GetType());
                if (editeur == null)
                {
                    editeur = CAllocateurEditeurDonneeBesoin.GetEditeurDonnee(calcul, kindEditeur);
                    if (editeur != null)
                    {
                        editeur.OnCoutChanged += new EventHandler(editeur_OnCoutChanged);
                        ((Control)editeur).Visible = false;
                        ((Control)editeur).TabStop = false;
                        editeur.OnDataChanged += new EventHandler(editeur_OnDataChanged);
                        switch (kindEditeur)
                        {
                            case ETypeEditeurBesoin.EditeurCout:
                                m_panelDetailCout.Controls.Add((Control)editeur);
                                ((Control)editeur).Dock = DockStyle.Fill;
                                break;
                            case ETypeEditeurBesoin.EditeurDonnees:
                                m_panelEditeurData.Controls.Add((Control)editeur);
                                ((Control)editeur).Dock = DockStyle.Top;
                                break;
                        }
                        editeur.LockEdition = LockEdition;
                        m_extModeEdition.SetModeEdition(editeur, TypeModeEdition.EnableSurEdition);

                    }
                    m_editeursAlloues.SetEditeur(kindEditeur, calcul.GetType(), editeur);
                }
            }
            return editeur;
        }

        //-----------------------------------------------
        private IEditeurDonneeBesoin GetEditeurEnCours(ETypeEditeurBesoin kindEditeur)
        {
            IEditeurDonneeBesoin editeur = null;
            if (m_dicEditeursEnCours.TryGetValue(kindEditeur, out editeur))
                return editeur;
            return null;
        }

        //-----------------------------------------------
        void editeur_OnDataChanged(object sender, EventArgs e)
        {
            HasChange = true;
        }

        //-----------------------------------------------
        public string LibelleBesoin
        {
            get
            {
                return m_txtLibelle.Text;
            }
            set
            {
                m_txtLibelle.Text = value;
            }
        }

        //-----------------------------------------------
        void editeur_OnCoutChanged(object sender, EventArgs e)
        {
            IEditeurDonneeBesoin editeurCout = GetEditeurEnCours(ETypeEditeurBesoin.EditeurCout);
            if ( editeurCout != null && 
                editeurCout != sender )
            {
                editeurCout.RefreshFromExternalChangeOnDonnee();
            }
            //Recalcul Coût global
            RefreshCoutTotal();
        }



        //-----------------------------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return false;
            }
        }


        //-----------------------------------------------------------------------
        public CBesoin Besoin
        {
            get
            {
                return CurrentItem != null ? CurrentItem.Tag as CBesoin : null;
            }
        }

        /*//-----------------------------------------------------------------------
        public CPhaseSpecifications PhaseDeSatisfaction
        {
            get
            {
                return m_phaseShowSatisfait;
            }
            set
            {
                m_phaseShowSatisfait = value;
            }
        }*/


       //-----------------------------------------------------------------------
        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            m_txtLibelle.TextAlign = HorizontalAlignment.Left;
            CResultAErreur result = base.MyInitChamps(item);
            m_btnDelete.Visible = m_extModeEdition.ModeEdition;
            foreach (IEditeurDonneeBesoin editeur in m_dicEditeursEnCours.Values)
            {
                if (editeur != null)
                    ((Control)editeur).Visible = false;
            }
            m_dicEditeursEnCours.Clear();

            if (item != null && Besoin != null && Besoin.IsValide())
            {
                Color c = item.ColorInactive.Value;
                c = Color.FromArgb((int)(c.R * 0.9), (int)(c.G * 0.9), (int)(c.B * 0.9));
                m_panelFiletBas.BackColor = c;
                m_panelFiletTop.BackColor = c;
                m_panelFiletGauche.BackColor = c;

                CItemBesoin itemBesoin = item as CItemBesoin;
                CBesoin besoin = item.Tag as CBesoin;
                if (besoin != null && !item.IsMasque)
                {
                    UpdateMarge();
                    m_txtLibelle.Text = besoin.Libelle;
                    if (besoin.HasSatisfactions)
                        m_picBoxSatisfait.Image = Resources.puzzlePlein20;
                    else
                        m_picBoxSatisfait.Image = Resources.alerte;
                    if (!besoin.HasChildren)
                        m_iconPlusMoins.Image = null;
                    else
                    {
                        m_iconPlusMoins.Image = itemBesoin.IsCollapse ?
                            timos.Properties.Resources.miniplus :
                            timos.Properties.Resources.minimoins;
                    }
                    UpdateVisuInfo();

                    m_lblIndex.Text = item.Index.ToString().PadLeft(3, '0');

                    m_wndListeQuantites.Init(Besoin);
                    CBesoinQuantite[] qtesPossibles = besoin.QuantitesParentes;
                    if (qtesPossibles.Count() > 0)
                    {
                        m_panelRegroupement.Visible = true;
                        m_cmbRegroupement.Fill(qtesPossibles, "Libelle", true);
                        m_cmbRegroupement.SelectedValue = besoin.RegroupementQuantite;
                    }
                    else
                        m_panelRegroupement.Visible = false;

                    ModifContrôleCout();
                    UpdateVisibiliteCout();

                    CalcHeight();

                    if (IsCreatingImage)
                    {
                        m_wndListeQuantites.CurrentItemIndex = null;
                        m_controleQuantite.BringToFront();
                    }
                    else
                        m_wndListeQuantites.CurrentItemIndex = m_wndListeQuantites.CurrentItemIndex;
                    m_panelFiletTop.BackColor = CurrentItem.ColorInactive.Value;
                    m_ctrlSatisfaction.Init(besoin, !LockEdition);
                }
            }
            m_bIsInitializing = false;
            return result;
        }

        //-----------------------------------------------------------------------
        private void UpdateVisuInfo()
        {
            if (Besoin.Commentaires.Trim().Length > 0)
                m_picBoxInfo.Image = Resources.Information;
            else
                m_picBoxInfo.Image = Resources.informationTrans;
        }

        //-----------------------------------------------------------------------
        private void UpdateMarge()
        {
            if (CurrentItem != null)
            {
                CBesoin besoin = CurrentItem.Tag as CBesoin;
                m_picMarge.Width = besoin.Niveau * 10;
            }
        }

        //-----------------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (CurrentItem != null)
            {
                CBesoin besoin = CurrentItem.Tag as CBesoin;
                if (besoin != null)
                    besoin.Libelle = m_txtLibelle.Text;
                m_wndListeQuantites.MajChamps();
                if (m_panelRegroupement.Visible)
                    besoin.RegroupementQuantite = m_cmbRegroupement.SelectedValue as CBesoinQuantite;

                IDonneeBesoin donnee = null;
                foreach (IEditeurDonneeBesoin editeur in m_dicEditeursEnCours.Values)
                {
                    if (editeur != null && result)
                    {
                        result = editeur.MajChamps();
                        if (donnee == null)
                            donnee = editeur.DonneeBesoin;
                    }
                }
                if (result)
                    besoin.DonneeBesoin = donnee;

                ((CControleListeBesoins)AssociatedListControl).AfterTotalChanged(Besoin);
                besoin.Index = CurrentItem.Index;
                CurrentItem.Height = Height;
            }
            return result;
        }

        //-----------------------------------------------------------------------
        private void m_imageTache_DragDrop(object sender, DragEventArgs e)
        {

        }


        //-----------------------------------------------------------------------
        private Point? m_ptMouseDownTache = null;
        private void m_imageTache_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_ptMouseDownTache = new Point(e.X, e.Y);
                m_imageBesoin.Capture = true;
            }
        }

        //-----------------------------------------------------------------------
        private bool m_bHasDrag = false;
        private void m_imageTache_MouseMove(object sender, MouseEventArgs e)
        {
            m_bHasDrag = false;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && m_ptMouseDownTache != null)
            {
                Point pt = new Point(Math.Abs(e.X - m_ptMouseDownTache.Value.X),
                    Math.Abs(e.Y - m_ptMouseDownTache.Value.Y));
                if (pt.X > 4 || pt.Y > 4)
                {
                    CItemBesoin item = CurrentItem as CItemBesoin;
                    StartDragDrop(
                        new Point(e.X, e.Y),
                        DragDropEffects.Move | DragDropEffects.Link | DragDropEffects.Copy,
                        new CDonneeAdditionnelleDragDrop(typeof(sc2i.data.CReferenceObjetDonnee), new sc2i.data.CReferenceObjetDonnee(Besoin))
                        );
                    m_bHasDrag = true;
                    CBesoin besoin = item.Besoin;
                    ((CControleListeBesoins)AssociatedListControl).RefreshBesoin(besoin, true);
                    besoin = besoin.BesoinParent;
                    while (besoin != null)
                    {
                        ((CControleListeBesoins)AssociatedListControl).RefreshBesoin(besoin, false);
                        besoin = besoin.BesoinParent;
                    }
                    AssociatedListControl.Refresh();
                }
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_SYSKEYUP)
            {
                Keys key = (Keys)m.WParam;
                if (key == Keys.Left)
                {
                    CControleListeBesoins ctrl = AssociatedListControl as CControleListeBesoins;
                    if (ctrl != null)
                    {
                        ctrl.DecrementeNiveau(CurrentItem as CItemBesoin);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }
                if (key == Keys.Right)
                {
                    CControleListeBesoins ctrl = AssociatedListControl as CControleListeBesoins;
                    if (ctrl != null)
                    {
                        ctrl.IncrementeNiveau(CurrentItem as CItemBesoin);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }
            }
            if (m.Msg == 0x100)
            {
                Keys key = (Keys)m.WParam;
                if ( (Control.ModifierKeys & Keys.Control ) == Keys.Control )
                {
                    Type tp = null;
                    if ( key.ToString().Length == 1  && m_dicShortKeysToTypeBesoin.TryGetValue ( key.ToString().ToUpper()[0], out tp ))
                    {
                        ChangeTypeBesoin(tp);
                        return true;
                    }
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        private void m_iconPlusMoins_Click(object sender, EventArgs e)
        {
            CItemBesoin item = CurrentItem as CItemBesoin;
            if (item != null)
            {
                if (item.IsCollapse)
                    ((CControleListeBesoins)AssociatedListControl).Expand(item);
                else
                    ((CControleListeBesoins)AssociatedListControl).Collapse(item);
            }
        }

        //--------------------------------------------------------
        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CControleListeBesoins ctrlListe = AssociatedListControl as CControleListeBesoins;
                if (ctrlListe != null && CurrentItem != null)
                {
                    CItemBesoin item = CurrentItem as CItemBesoin;
                    if (item != null)
                    {
                        if (MessageBox.Show("Supprimer l'élément " +
                            item.Besoin.Libelle + " ?", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            ctrlListe.RemoveItem(CurrentItem, true);
                    }
                }
            }
        }

        //--------------------------------------------------------
        void m_controleQuantite_OnDeleteQuantite(object sender, EventArgs e)
        {
            int? nItem = m_wndListeQuantites.CurrentItemIndex;
            if (nItem != null)
            {
                CCustomizableListItem item = m_wndListeQuantites.Items[nItem.Value];
                CBesoinQuantite qte = item.Tag as CBesoinQuantite;
                if (qte != null)
                {
                    foreach (CBesoin besoin in Besoin.GetTousLesBesoinsDontLeCoutDependDeMesQuantites())
                        ((CControleListeBesoins)AssociatedListControl).RefreshBesoin(besoin, false);
                    CResultAErreur result = qte.Delete();
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                        return;
                    }
                    m_wndListeQuantites.RemoveItem(item, false);
                    CalcHeight();

                    Refresh();
                }
            }
        }

        //--------------------------------------------------------
        private void CalcHeight()
        {
            int nHeight = m_panelHeader.Height + m_controleQuantite.Height *
                m_wndListeQuantites.Items.Count() + m_panelFiletTop.Height + m_panelFiletBas.Height;
            if (m_wndListeQuantites.Items.Count() > 0)
            {
                nHeight += 2;
                m_panelDetails.Visible = true;
            }
            else
                m_panelDetails.Visible = false;
            if (CurrentItem != null)
                CurrentItem.Height = nHeight;
            nHeight += m_panelEditeurData.Height;
            Height = nHeight;
        }

        //--------------------------------------------------------
        private void m_btnMenuQuantite_Click(object sender, EventArgs e)
        {
            CItemBesoin item = CurrentItem as CItemBesoin;
            if (item != null)
            {
                if (m_controleQuantite.CurrentItem != null)
                    m_controleQuantite.MajChamps();
                CBesoinQuantite qte = new CBesoinQuantite(item.Besoin.ContexteDonnee);
                qte.CreateNewInCurrentContexte();
                qte.Besoin = item.Besoin;
                CCustomizableListItem newItem = new CCustomizableListItem();
                newItem.Tag = qte;
                m_wndListeQuantites.AddItem(newItem, false);
                CalcHeight();
                m_wndListeQuantites.CurrentItemIndex = m_wndListeQuantites.Items.Count() - 1;
            }
        }

        //--------------------------------------------------------
        private void RefreshCoutTotal()
        {
            double? dOld = m_txtCoutTotal.DoubleValue;
            IEditeurDonneeBesoin editeurCout = GetEditeurEnCours(ETypeEditeurBesoin.EditeurCout);
            if (Besoin != null && editeurCout != null && editeurCout.DonneeBesoin != null)
            {
                m_txtCoutTotal.DoubleValue = editeurCout.DonneeBesoin.CalculeCout(Besoin);
            }
            else if (Besoin != null)
            {
                m_txtCoutTotal.DoubleValue = Besoin.CoutSaisiTotalSansRegroupement;
            }
            else
            {
                m_txtCoutTotal.DoubleValue = null;
                m_txtTotalTotal.DoubleValue = null;
            }
            if (Besoin != null)
            {
                CBesoinQuantite q = Besoin.RegroupementQuantite;
                m_panelTotalTotal.Visible = q != null;
                if (q != null)
                {
                    m_txtTotalTotal.DoubleValue = m_txtCoutTotal.DoubleValue * q.Quantite;
                }
                else
                    m_txtTotalTotal.DoubleValue = m_txtCoutTotal.DoubleValue;
            }
            else
                m_panelTotalTotal.Visible = false;

            if (!m_bIsInitializing)//ChangementDeValeurTotale
                ((CControleListeBesoins)AssociatedListControl).AfterTotalChanged(Besoin);
        }



        //-------------------------------------------------------------------
        private Dictionary<char, Type> m_dicShortKeysToTypeBesoin = new Dictionary<char, Type>();
        private void UpdateMenuTypeCalculCout()
        {
            if (DesignMode)
                return;
            if (m_menuTypeDeBesoin.DropDownItems.Count == 0)
            {
                //Crée les items
                //trouve les types implémentant ICalculCoutBesoin
                List<Type> lstTypes = new List<Type>();
                foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
                {
                    foreach (Type tp in ass.GetTypes())
                    {
                        if (typeof(IDonneeBesoin).IsAssignableFrom(tp) &&
                            !tp.IsAbstract)
                        {
                            lstTypes.Add(tp);
                        }
                    }
                }
                foreach (Type tp in lstTypes)
                {
                    try
                    {
                        IDonneeBesoin c = Activator.CreateInstance(tp, new object[0]) as IDonneeBesoin;
                        ToolStripMenuItem itemTypeCalcul = new ToolStripMenuItem(c.LibelleStatique);
                        if (c.ShortKey != null)
                        {
                            m_dicShortKeysToTypeBesoin[c.ShortKey.Value] = tp;
                            string strLib = c.LibelleStatique;
                            int nIndex = c.LibelleStatique.ToUpper().IndexOf(c.ShortKey.Value.ToString().ToUpper());
                            if (nIndex >= 0)
                                strLib = strLib.Insert(nIndex, "&");
                            itemTypeCalcul.Text = strLib;
                        }                        
                        itemTypeCalcul.Tag = c;
                        itemTypeCalcul.Image = CTypeDonneeBesoin.GetImage(c.TypeDonnee);
                        m_menuTypeDeBesoin.DropDownItems.Add(itemTypeCalcul);
                        itemTypeCalcul.Click += new EventHandler(itemTypeCalcul_Click);
                    }
                    catch { }
                }
            }

            m_menuTypeDeBesoin.Enabled = !LockEdition;

            //Met à jour les actions
            CUtilMenuActionSurElement.InitMenuActions(Besoin, m_menuActions.DropDownItems,
                new MenuActionEventHandler(OnActionSurBesoin));


            CBesoin besoin = Besoin;
            if (besoin != null)
            {
                foreach (ToolStripMenuItem item in m_menuTypeDeBesoin.DropDownItems)
                {
                    IDonneeBesoin c = item.Tag as IDonneeBesoin;
                    if (c != null)
                        item.Visible = c.CanApplyOn(besoin);
                }
            }
        }

        //-------------------------------------------------------------
        private void OnActionSurBesoin(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetCible)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!LockEdition)
            {
                MajChamps();
                IDeclencheurActionManuelle declencheurManuel = declencheur as IDeclencheurActionManuelle;
                if (declencheurManuel != null)
                {
                    // Déclancher ici l'évenement manuelle sur Client
                    result = declencheurManuel.EnregistreDeclenchementEvenementSurClient(
                        objetCible,
                        new CInfoDeclencheurProcess(TypeEvenement.Manuel),
                        null);
                }
                else
                    MessageBox.Show(I.T("Can not start this action|20673"));
            }
            else
            {
                result = CFormExecuteProcess.RunEvent(declencheur, objetCible, false);
            }
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                if (AssociatedListControl != null)
                    AssociatedListControl.Refill();
            }
        }

        //-------------------------------------------------------------
        private void ModifContrôleCout()
        {
            foreach (IEditeurDonneeBesoin editeurTmp in m_dicEditeursEnCours.Values)
            {
                if (editeurTmp != null)
                    ((Control)editeurTmp).Visible = false;
            }
            m_dicEditeursEnCours.Clear();
            IEditeurDonneeBesoin editeur = null;
            
            if (Besoin != null)
            {
                IDonneeBesoin donnee = Besoin.DonneeBesoin;
                IEnumerable<CItemBesoin> lstBesoins = from i in AssociatedListControl.Items select i as CItemBesoin;
                foreach (ETypeEditeurBesoin kind in Enum.GetValues(typeof(ETypeEditeurBesoin)))
                {
                    if (kind == ETypeEditeurBesoin.EditeurCout)
                    {
                        switch (ModeAffichage)
                        {
                            case EModeAffichageBesoins.ModeSansCout:
                                editeur = null;
                                break;
                            case EModeAffichageBesoins.ModeConception:
                                editeur = GetEditeur(kind, donnee, Besoin);
                                break;
                            case EModeAffichageBesoins.ModeSuivi:
                                editeur = m_panelSuivi;
                                break;
                            default:
                                editeur = null;
                                break;
                        }
                    }
                    else
                        editeur = GetEditeur(kind, donnee, Besoin);
                    if (editeur != null)
                    {
                        editeur.Init(donnee, Besoin, CurrentItem as CItemBesoin, lstBesoins);
                        ((Control)editeur).Visible = true;
                        m_dicEditeursEnCours[kind] = editeur;

                    }
                }
                m_imageBesoin.Image = CTypeDonneeBesoin.GetImage((ETypeDonneeBesoin)Besoin.TypeBesoinCode);
            }
            editeur = GetEditeurEnCours(ETypeEditeurBesoin.EditeurDonnees);
            if (editeur != null)
                m_panelEditeurData.Height = ((Control)editeur).Height;
            else
                m_panelEditeurData.Height = 0;
           
            CalcHeight();
            RefreshCoutTotal();
        }

        //-------------------------------------------------------------
        void itemTypeCalcul_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null && item.Tag is IDonneeBesoin && Besoin != null)
            {
                Type tp = item.Tag.GetType();
                ChangeTypeBesoin(tp);
            }
        }

        //-------------------------------------------------------------
        private void ChangeTypeBesoin(Type nouveauType)
        {
            if (!LockEdition && (
                Besoin.DonneeBesoin == null ||
                Besoin.DonneeBesoin.GetType() != nouveauType))
            {
                IDonneeBesoin oldBesoin = Besoin.DonneeBesoin;
                IDonneeBesoin c = Activator.CreateInstance(nouveauType, new object[0]) as IDonneeBesoin;
                if (c != null && c.CanApplyOn(Besoin))
                {
                    if (oldBesoin != null && Besoin != null)
                        c.InitFrom(Besoin, oldBesoin);
                    Besoin.DonneeBesoin = c;
                    ModifContrôleCout();
                }
            }
        }


        //-------------------------------------------------------------------
        private void m_imageTache_MouseClick_1(object sender, MouseEventArgs e)
        {
            //if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                
            }

        }

        //-------------------------------------------------------------------
        private void m_imageBesoin_MouseUp(object sender, MouseEventArgs e)
        {
            m_imageBesoin.Capture = false;
            if (Besoin != null)
            {
                UpdateMenuTypeCalculCout();
                m_menuTypeBesoin.Show(m_imageBesoin, new Point(0, m_imageBesoin.Height));
            }
        }

        //-------------------------------------------------------------------
        private void m_cmbRegroupement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                MajChamps();
                ((CControleListeBesoins)AssociatedListControl).AfterTotalChanged(Besoin);
            }
        }

        //-------------------------------------------------------------------
        private void m_txtLibelle_TextChanged(object sender, EventArgs e)
        {
            if (!IsCreatingImage)
            {
                if (Besoin != null && m_txtLibelle.Text != Besoin.Libelle)
                    HasChange = true;
                if (m_txtLibelle.AutoCompleteCustomSource.Contains(m_txtLibelle.Text) &&
                    Besoin != null && Besoin.IsNew() && !Besoin.HasChildren)
                {
                    m_toolTip.Show(I.T("Hit Enter to apply template|20674"),
                        m_txtLibelle, new Point(0, m_txtLibelle.Height), 3000);
                }
                else
                    m_toolTip.SetToolTip(m_txtLibelle, "");
            }
        }

        private void m_cmbRegroupement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Besoin != null && m_cmbRegroupement.SelectedValue != Besoin.RegroupementQuantite)
                HasChange = true;
        }

        private void m_picBoxSatisfait_Click(object sender, EventArgs e)
        {
           
        }

        private bool m_bIsMenuDeleteSatisfaction = false;
        private void ShowMenuSatisfaction(bool bDelete)
        {
            m_bIsMenuDeleteSatisfaction = bDelete && m_extModeEdition.ModeEdition;
            foreach (ToolStripItem item in new ArrayList(m_menuSatisfactions.Items))
            {
                if (item is CObjetDonneeMenuItem)
                {
                    m_menuSatisfactions.Items.Remove(item);
                    item.Dispose();
                }
            }
            if (Besoin == null)
                return;
            foreach (CRelationBesoin_Satisfaction r in Besoin.RelationsSatisfactions)
            {
                ISatisfactionBesoin sat = r.Satisfaction;
                if (sat != null)
                {
                    CObjetDonneeMenuItem menuSatisfaction = new CObjetDonneeMenuItem(
                        sat as CObjetDonnee,
                        sat.ObjetPourEditionElementACout,
                        sat.LibelleSatisfactionComplet,
                        false);
                    if (m_bIsMenuDeleteSatisfaction)
                    {
                        menuSatisfaction.Image = Resources.delete;
                    }
                    else
                        menuSatisfaction.Image = Resources.PuzzleMal20;
                    menuSatisfaction.Click += new EventHandler(menuSatisfaction_Click);
                    m_menuSatisfactions.Items.Add(menuSatisfaction);
                }
            }

            m_menuSatisfactions.Show(m_picBoxSatisfait, new Point(0, m_picBoxSatisfait.Height));
        }

        //------------------------------------------------------------
        void menuSatisfaction_Click(object sender, EventArgs e)
        {
            CObjetDonneeMenuItem item = sender as CObjetDonneeMenuItem;
            ISatisfactionBesoin satisfaction = item != null ? item.ObjetDragDrop as ISatisfactionBesoin : null;
            if (satisfaction != null)
            {
                if (m_bIsMenuDeleteSatisfaction && m_extModeEdition.ModeEdition)
                {
                    if (MessageBox.Show(I.T("Remove @1 from satisfactions list .|20637",
                        satisfaction.LibelleSatisfactionComplet), "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Besoin.RemoveSatisfaction(satisfaction);
                        InitChamps(CurrentItem);
                    }
                }
                else
                {
                    CObjetDonnee objet = satisfaction.ObjetPourEditionElementACout.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant);
                    CTimosApp.Navigateur.EditeElement(objet, false, "");
                }
            }
        }

        //------------------------------------------------------------
        public override int? MinWidth
        {
            get
            {
                switch (m_modeAffichage)
                {
                    case EModeAffichageBesoins.ModeSansCout:
                        return 200;
                    case EModeAffichageBesoins.ModeConception:
                        return 900;
                    case EModeAffichageBesoins.ModeSuivi:
                        return 700;
                }
                return 200;
            }
        }

        //------------------------------------------------------------
        private void m_menuSatisfactions_Opening(object sender, CancelEventArgs e)
        {

        }

        //------------------------------------------------------------
        private void displayMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CFormEditionStdTimos frm = FindForm() as CFormEditionStdTimos;
            if (frm != null && Besoin != null)
                CFormMapBesoinsPopup.Show(frm, Besoin);
        }

        private void m_picBoxSatisfait_MouseUp(object sender, MouseEventArgs e)
        {
            if (Besoin != null && Besoin.HasSatisfactions)
                ShowMenuSatisfaction(e.Button == MouseButtons.Right);

        }

        //-------------------------------------------------------------
        private bool m_bIsEntering = false;
        private void m_txtLibelle_Enter(object sender, EventArgs e)
        {
            if (!m_bIsEntering)
            {
                m_bIsEntering = true;
                if (m_listeTemplates == null && m_extModeEdition.ModeEdition && Besoin != null)
                {
                    m_txtLibelle.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    m_listeTemplates = new CListeObjetDonneeGenerique<CPhaseSpecifications>(Besoin.ContexteDonnee,
                        new CFiltreData(CPhaseSpecifications.c_champUseAsTemplate + "=@1", true));
                    m_listeTemplates.AssureLectureFaite();
                    m_listeTemplates.InterditLectureInDB = true;
                    m_txtLibelle.AutoCompleteMode = AutoCompleteMode.Suggest;
                    m_txtLibelle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    foreach (CPhaseSpecifications phase in m_listeTemplates)
                    {
                        m_txtLibelle.AutoCompleteCustomSource.Add(phase.Libelle);
                    }
                }
                if (Besoin != null && Besoin.IsValide() && Besoin.IsNew() && m_extModeEdition.ModeEdition)
                {
                    m_txtLibelle.AutoCompleteMode = AutoCompleteMode.Suggest;
                }
                else
                    m_txtLibelle.AutoCompleteMode = AutoCompleteMode.None;
                m_bIsEntering = false;
            }
            
        }

        //-------------------------------------------------------------
        private void m_txtLibelle_Validated(object sender, EventArgs e)
        {
            /*if (Besoin != null && Besoin.IsNew() && m_listeTemplates != null && 
                Besoin.BesoinsFils.Count == 0 && !m_bIsEntering && !m_bIsInitializing && m_extModeEdition.ModeEdition)
            {
                m_listeTemplates.Filtre = new CFiltreData(CPhaseSpecifications.c_champLibelle + "=@1 and " +
                    CPhaseSpecifications.c_champUseAsTemplate + "=@2",
                    m_txtLibelle.Text,
                    true);
                if (m_listeTemplates.Count > 0)
                {
                    Besoin.Libelle = m_txtLibelle.Text;
                    Besoin.ApplyTemplate(m_listeTemplates[0] as CPhaseSpecifications);
                    ((CControleListeBesoins)AssociatedListControl).AddItemsFils((CItemBesoin)CurrentItem);
                    MyInitChamps(CurrentItem);
                    int? nItem = AssociatedListControl.CurrentItemIndex;
                    AssociatedListControl.CurrentItemIndex = nItem;
                    AssociatedListControl.Refresh();
                }
            }*/
        }

        //-------------------------------------------------------------
        private void ImplementeTemplate()
        {
            using (CWaitCursor waiter = new CWaitCursor())
            {
                m_toolTip.SetToolTip(m_txtLibelle, "");
                if (Besoin != null && Besoin.IsNew() && m_listeTemplates != null &&
                    !Besoin.HasChildren && !m_bIsEntering && !m_bIsInitializing && m_extModeEdition.ModeEdition)
                {
                    m_listeTemplates.Filtre = new CFiltreData(CPhaseSpecifications.c_champLibelle + "=@1 and " +
                        CPhaseSpecifications.c_champUseAsTemplate + "=@2",
                        m_txtLibelle.Text,
                        true);
                    if (m_listeTemplates.Count > 0)
                    {
                        Besoin.Libelle = m_txtLibelle.Text;
                        Besoin.ApplyTemplate(m_listeTemplates[0] as CPhaseSpecifications);
                        ((CControleListeBesoins)AssociatedListControl).AddItemsFils((CItemBesoin)CurrentItem);
                        MyInitChamps(CurrentItem);
                        int? nItem = AssociatedListControl.CurrentItemIndex;
                        AssociatedListControl.CurrentItemIndex = nItem;
                        AssociatedListControl.Refresh();
                    }
                }
            }
        }

        private void m_txtLibelle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ImplementeTemplate();
                
        }

        private void m_imageBesoin_Click(object sender, EventArgs e)
        {

        }

        private void m_picBoxInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Besoin != null)
            {
                if (m_toolTip.GetToolTip(m_picBoxInfo) != Besoin.Commentaires)
                    m_toolTip.SetToolTip(m_picBoxInfo, Besoin.Commentaires);
            }
            else
                m_toolTip.SetToolTip(m_picBoxInfo, "");
        }

        private void m_picBoxInfo_Click(object sender, EventArgs e)
        {
            if (Besoin != null)
            {
                string strComment = CFormCommentairesSurBesoin.GetText(
                    I.T("Comment on @1|20688", Besoin.Libelle),
                    Besoin.Commentaires,
                    LockEdition);
                if ( !LockEdition )
                    Besoin.Commentaires = strComment;
                UpdateVisuInfo();
            }

        }

        //-------------------------------------------------------------
    }
}
    

       