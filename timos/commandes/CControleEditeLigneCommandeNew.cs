using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using sc2i.common;
using timos.data.commandes;
using timos.data;
using sc2i.data;
using System.Windows.Forms;
using System.Drawing;
using timos.projet.besoin;
using sc2i.win32.data.dynamic;
using timos.data.equipement.consommables;

namespace timos.commandes
{
    public class CControleEditeLigneCommandeNew : CCustomizableListControl
    {
        private System.Windows.Forms.Panel m_panelData;
        private sc2i.win32.common.C2iTextBox m_txtTexte;
        private sc2i.win32.common.C2iTextBox m_txtReference;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtQte;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectReference;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeEquipement;
        private System.Windows.Forms.PictureBox m_btnPoubelle;
        private System.Windows.Forms.PictureBox m_pictOrderLine;
        private CControlePourResumeSatisfaction m_ctrlBesoin;


        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;

        //-------------------------------------------------------------
        public CControleEditeLigneCommandeNew()
            : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeLigneCommandeNew));
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_txtTexte = new sc2i.win32.common.C2iTextBox();
            this.m_txtReference = new sc2i.win32.common.C2iTextBox();
            this.m_txtQte = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtSelectReference = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_selectTypeEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_pictOrderLine = new System.Windows.Forms.PictureBox();
            this.m_ctrlBesoin = new timos.projet.besoin.CControlePourResumeSatisfaction();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictOrderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelData
            // 
            this.m_panelData.Controls.Add(this.m_txtTexte);
            this.m_panelData.Controls.Add(this.m_txtReference);
            this.m_panelData.Controls.Add(this.m_txtQte);
            this.m_panelData.Controls.Add(this.m_txtSelectReference);
            this.m_panelData.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelData.Controls.Add(this.m_pictOrderLine);
            this.m_panelData.Controls.Add(this.m_ctrlBesoin);
            this.m_panelData.Controls.Add(this.m_btnPoubelle);
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelData.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(786, 20);
            this.m_panelData.TabIndex = 3;
            // 
            // m_txtTexte
            // 
            this.m_txtTexte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTexte.EmptyText = "";
            this.m_txtTexte.Location = new System.Drawing.Point(475, 0);
            this.m_txtTexte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTexte.Name = "m_txtTexte";
            this.m_txtTexte.Size = new System.Drawing.Size(108, 20);
            this.m_txtTexte.TabIndex = 2;
            this.m_txtTexte.TextChanged += new System.EventHandler(this.m_txtQte_TextChanged);
            // 
            // m_txtReference
            // 
            this.m_txtReference.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtReference.EmptyText = "";
            this.m_txtReference.Location = new System.Drawing.Point(583, 0);
            this.m_txtReference.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtReference.Name = "m_txtReference";
            this.m_txtReference.Size = new System.Drawing.Size(101, 20);
            this.m_txtReference.TabIndex = 3;
            this.m_txtReference.TextChanged += new System.EventHandler(this.m_txtQte_TextChanged);
            // 
            // m_txtQte
            // 
            this.m_txtQte.Arrondi = 4;
            this.m_txtQte.DecimalAutorise = true;
            this.m_txtQte.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtQte.DoubleValue = null;
            this.m_txtQte.EmptyText = "";
            this.m_txtQte.IntValue = null;
            this.m_txtQte.Location = new System.Drawing.Point(684, 0);
            this.m_txtQte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtQte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtQte.Name = "m_txtQte";
            this.m_txtQte.NullAutorise = true;
            this.m_txtQte.SelectAllOnEnter = true;
            this.m_txtQte.SeparateurMilliers = "";
            this.m_txtQte.Size = new System.Drawing.Size(66, 20);
            this.m_txtQte.TabIndex = 4;
            this.m_txtQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtQte.TextChanged += new System.EventHandler(this.m_txtQte_TextChanged);
            // 
            // m_txtSelectReference
            // 
            this.m_txtSelectReference.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtSelectReference.ElementSelectionne = null;
            this.m_txtSelectReference.FonctionTextNull = null;
            this.m_txtSelectReference.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectReference.Location = new System.Drawing.Point(268, 0);
            this.m_txtSelectReference.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectReference.Name = "m_txtSelectReference";
            this.m_txtSelectReference.SelectedObject = null;
            this.m_txtSelectReference.SelectionLength = 0;
            this.m_txtSelectReference.SelectionStart = 0;
            this.m_txtSelectReference.Size = new System.Drawing.Size(207, 20);
            this.m_txtSelectReference.SpecificImage = null;
            this.m_txtSelectReference.TabIndex = 1;
            this.m_txtSelectReference.TextNull = "";
            this.m_txtSelectReference.UseIntellisense = true;
            this.m_txtSelectReference.OnSelectedObjectChanged += new System.EventHandler(this.m_txtSelectReference_OnSelectedObjectChanged);
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(22, 0);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.SelectionLength = 0;
            this.m_selectTypeEquipement.SelectionStart = 0;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(246, 20);
            this.m_selectTypeEquipement.SpecificImage = null;
            this.m_selectTypeEquipement.TabIndex = 0;
            this.m_selectTypeEquipement.TextNull = "";
            this.m_selectTypeEquipement.UseIntellisense = true;
            this.m_selectTypeEquipement.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypeEquipement_OnSelectedObjectChanged);
            // 
            // m_pictOrderLine
            // 
            this.m_pictOrderLine.BackColor = System.Drawing.Color.White;
            this.m_pictOrderLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_pictOrderLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pictOrderLine.Image = global::timos.Properties.Resources.order_line;
            this.m_pictOrderLine.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_pictOrderLine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pictOrderLine.Name = "m_pictOrderLine";
            this.m_pictOrderLine.Size = new System.Drawing.Size(22, 20);
            this.m_pictOrderLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictOrderLine.TabIndex = 8;
            this.m_pictOrderLine.TabStop = false;
            this.m_pictOrderLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_imageLigne_MouseMove);
            this.m_pictOrderLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_imageLigne_MouseDown);
            this.m_pictOrderLine.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_pictOrderLine_DragEnter);
            // 
            // m_ctrlBesoin
            // 
            this.m_ctrlBesoin.AllowDrop = true;
            this.m_ctrlBesoin.BackColor = System.Drawing.Color.White;
            this.m_ctrlBesoin.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctrlBesoin.Location = new System.Drawing.Point(750, 0);
            this.m_extModeEdition.SetModeEdition(this.m_ctrlBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_ctrlBesoin.Name = "m_ctrlBesoin";
            this.m_ctrlBesoin.Size = new System.Drawing.Size(20, 20);
            this.m_ctrlBesoin.TabIndex = 9;
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(770, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 20);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 7;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // CControleEditeLigneCommandeNew
            // 
            this.Controls.Add(this.m_panelData);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLigneCommandeNew";
            this.Size = new System.Drawing.Size(786, 21);
            this.m_panelData.ResumeLayout(false);
            this.m_panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictOrderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            this.ResumeLayout(false);

        }


        //-------------------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        //-------------------------------------------------------------
        public CLigneCommande LigneCommande
        {
            get
            {
                return CurrentItem != null ? CurrentItem.Tag as CLigneCommande : null;
            }
        }

        //-------------------------------------------------------------
        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            try
            {
                CResultAErreur result = base.MyInitChamps(item);
                CLigneCommande ligne = item != null ? item.Tag as CLigneCommande : null;
                if (ligne != null)
                {
                    InitSelectTypeEquipement(m_fournisseurPourFiltre);
                    m_selectTypeEquipement.ElementSelectionne = (CObjetDonnee)ligne.ElementCommandé;
                    InitSelectReference();
                    m_txtSelectReference.ElementSelectionne = (CObjetDonnee)ligne.ReferenceCommandée;
                    m_txtReference.Text = ligne.Reference;
                    m_txtTexte.Text = ligne.Libelle;
                    m_txtQte.DoubleValue = ligne.Quantite;
                    m_ctrlBesoin.Init(ligne, m_extModeEdition.ModeEdition);
                }
                return result;
            }
            finally
            {
                m_bIsInitializing = false;
            }
        }

        //-----------------------------------------------
        private CDonneesActeurFournisseur m_lastFournisseurFiltre = null;
        private void InitSelectTypeEquipement(
            CDonneesActeurFournisseur fournisseur )
        {
            CFiltreData filtreEquipement = null;
            CFiltreData filtreConsommable = null;
            if (fournisseur != null)
            {
                filtreEquipement = new CFiltreDataAvance(CTypeEquipement.c_nomTable,
                    CRelationTypeEquipement_Fournisseurs.c_nomTable + "." +
                    CDonneesActeurFournisseur.c_champId + "=@1", fournisseur.Id);
                filtreConsommable = new CFiltreDataAvance(CTypeConsommable.c_nomTable,
                    CConditionnementConsommable.c_nomTable + "." +
                    CDonneesActeurFournisseur.c_champId + "=@1",
                    fournisseur.Id);
            }


            m_selectTypeEquipement.InitMultiple(
                new CConfigTextBoxFiltreRapide[]{
                            new CConfigTextBoxFiltreRapide(
                                typeof(CTypeEquipement),
                                filtreEquipement,
                                "Libelle"),
                                new CConfigTextBoxFiltreRapide ( 
                                    typeof(CTypeConsommable),
                                    filtreConsommable,
                                    "Libelle")},
                            fournisseur != m_lastFournisseurFiltre);
            m_lastFournisseurFiltre = fournisseur;
        }

        //-------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            CLigneCommande ligne = LigneCommande;
            if (result && ligne != null)
            {
                if (!ligne.IsValide())
                    return result;
                IElementCommandable eltCommandé = m_selectTypeEquipement.ElementSelectionne as IElementCommandable;
                if ( eltCommandé == null )
                {
                        result.EmpileErreur(I.T("Invalid equipment or consumable type on line @1|20401", (ligne.Numero + 1).ToString()));
                        m_selectTypeEquipement.Focus();
                }
                if (m_txtQte.DoubleValue == null)
                {
                    result.EmpileErreur(I.T("Invalid quantity on line @1|20402", (ligne.Numero + 1).ToString()));
                    m_txtQte.Focus();
                }
                if (!result)
                    return result;
                ligne.ElementCommandé = eltCommandé;
                ligne.ReferenceCommandée = m_txtSelectReference.ElementSelectionne as IReferenceElementCommandable;
                ligne.Libelle = m_txtTexte.Text;
                ligne.Quantite = m_txtQte.DoubleValue.Value;
                ligne.Reference = m_txtReference.Text;
            }
            return result;
        }


        //-------------------------------------------------------------
        public CDonneesActeurFournisseur FournisseurPourFiltre
        {
            get
            {
                return m_fournisseurPourFiltre;
            }
            set
            {
                m_fournisseurPourFiltre = value;
                InitSelectTypeEquipement(value);
InitSelectReference();
            }
        }

        //-------------------------------------------------------------
        private bool m_bIsInitReference = false;
        private void InitSelectReference()
        {
            IReferenceElementCommandable lastRel = m_txtSelectReference.ElementSelectionne as IReferenceElementCommandable;
            IElementCommandable eltCom = m_selectTypeEquipement.ElementSelectionne as IElementCommandable;
            CFiltreData filtreEquipement = null;
            CFiltreData filtreConsommable = null;
            
            CTypeEquipement typeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            if (typeEquipement != null)
            {
                filtreEquipement = CFiltreData.GetAndFiltre(filtreEquipement,
                     new CFiltreData(CTypeEquipement.c_champId + "=@1",
                         typeEquipement.Id));
            }
            else if (m_fournisseurPourFiltre != null)
            {
                filtreEquipement = CFiltreData.GetAndFiltre(filtreEquipement,
                    new CFiltreData(CDonneesActeurFournisseur.c_champId + "=@1",
                        m_fournisseurPourFiltre.Id));
            }

            CTypeConsommable typeConsommable = m_selectTypeEquipement.ElementSelectionne as CTypeConsommable;
            if (typeConsommable != null)
            {
                filtreConsommable = CFiltreData.GetAndFiltre(filtreConsommable,
                    new CFiltreData(CTypeConsommable.c_champId + "=@1",
                        typeConsommable.Id));
            }
            else if (m_fournisseurPourFiltre != null)
            {
                filtreConsommable = CFiltreData.GetAndFiltre(filtreConsommable,
                    new CFiltreData(CDonneesActeurFournisseur.c_champId + "=@1",
                        m_fournisseurPourFiltre.Id));
            }

            if (typeEquipement != null)
            {
                m_txtSelectReference.InitAvecFiltreDeBase(
                    typeof(CRelationTypeEquipement_Fournisseurs),
                    "Libelle",
                    filtreEquipement,
                    true);
            }
            else
                if (typeConsommable != null)
                {
                    m_txtSelectReference.InitAvecFiltreDeBase(
                    typeof(CConditionnementConsommable),
                    "Libelle",
                    filtreConsommable,
                    true);
                }
                else
                {
                    m_txtSelectReference.InitMultiple(
                        new CConfigTextBoxFiltreRapide[]{
                    new CConfigTextBoxFiltreRapide(
                        typeof(CRelationTypeEquipement_Fournisseurs),
                        filtreEquipement,
                        "Libelle"),
                        new CConfigTextBoxFiltreRapide(
                            typeof(CConditionnementConsommable),
                            filtreConsommable,
                            "Libelle")}, true);
                }


            
            if (lastRel != null && eltCom == null && lastRel.ElementCommandable == eltCom )
                m_txtSelectReference.ElementSelectionne = (CObjetDonnee)lastRel;
        }


        //--------------------------------------------------------------------------------------
        private void m_txtSelectReference_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            IReferenceElementCommandable rel = m_txtSelectReference.ElementSelectionne as IReferenceElementCommandable;
            if (rel != null)
                m_selectTypeEquipement.ElementSelectionne = rel.ElementCommandable as CObjetDonnee;
            InitSelectReference();
            if (rel != null && rel.Reference.Trim() != "")
                m_txtReference.Text = rel.Reference;
            if (!m_bIsInitializing)
                HasChange = true;
        }

        //--------------------------------------------------------------------------------------
        private void m_selectTypeEquipement_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                IReferenceElementCommandable rel = m_txtSelectReference.ElementSelectionne as IReferenceElementCommandable;
                InitSelectReference();
                if (rel != null && !rel.ElementCommandable.Equals(m_selectTypeEquipement.ElementSelectionne))
                    m_selectTypeEquipement.ElementSelectionne = rel.ElementCommandable as CObjetDonnee;
                IElementCommandable eltCom = m_selectTypeEquipement.ElementSelectionne as IElementCommandable;
                if (eltCom != null)
                    m_txtTexte.Text = eltCom.Libelle;
            }
            if (!m_bIsInitializing)
                HasChange = true;
        }

        //--------------------------------------------------------------------------------------
        private void m_txtQte_TextChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }


        //--------------------------------------------------------------------------------------
        public event EventHandler OnDelete;

        private void m_btnPoubelle_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
                OnDelete(this, null);
        }

        //-----------------------------------------------------------------------
        private Point? m_ptMouseDownLigne = null;
        private void m_imageLigne_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_ptMouseDownLigne = new Point(e.X, e.Y);
            }
        }

        //-----------------------------------------------------------------------
        private bool m_bHasDrag = false;
        private void m_imageLigne_MouseMove(object sender, MouseEventArgs e)
        {
            m_bHasDrag = false;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && m_ptMouseDownLigne != null &&
                LigneCommande != null)
            {
                Point pt = new Point(Math.Abs(e.X - m_ptMouseDownLigne.Value.X),
                    Math.Abs(e.Y - m_ptMouseDownLigne.Value.Y));
                if (pt.X > 4 || pt.Y > 4)
                {
                    StartDragDrop(
                        new Point(e.X, e.Y),
                        DragDropEffects.Move | DragDropEffects.Link,
                        new CDonneeAdditionnelleDragDrop(typeof(CReferenceObjetDonnee), new CReferenceObjetDonnee(LigneCommande))
                        );
                    m_bHasDrag = true;
                }
            }
        }

        private void m_pictOrderLine_DragEnter(object sender, DragEventArgs e)
        {

        }

        public override int? MinWidth
        {
            get
            {
                return 750;
            }
        }
    }


    //-------------------------------------------------------------
    public class CCustomizableItemLigneCommande : CCustomizableListItem
    {
        //-------------------------------------------------------------
        public CCustomizableItemLigneCommande(CLigneCommande ligne)
        {
            Tag = ligne;
        }

        //-------------------------------------------------------------
        public override int Index
        {
            get
            {
                return base.Index;
            }
            set
            {
                base.Index = value;
                if (Tag is CLigneCommande)
                    ((CLigneCommande)Tag).Numero = value;
            }
        }
    }
}
