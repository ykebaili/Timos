﻿using sc2i.win32.common;
using System.Windows.Forms;
namespace timos.interventions.preventives
{
    partial class CEditeurUneOperationPreventive
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditeurUneOperationPreventive));
            this.m_panelOperation = new System.Windows.Forms.Panel();
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_txtDuree = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.m_cmbTypeOperation = new sc2i.win32.common.C2iComboBox();
            this.m_lblTypeOperation = new System.Windows.Forms.Label();
            this.m_lblCode = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_picBoxWarning = new System.Windows.Forms.PictureBox();
            this.m_picOperation = new System.Windows.Forms.PictureBox();
            this.m_picBoxAddLine = new System.Windows.Forms.PictureBox();
            this.m_panelLieEquipement = new System.Windows.Forms.Panel();
            this.m_txtSelectEquipementLie = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblEquipement = new System.Windows.Forms.Label();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_panelGaucheFormulaire = new System.Windows.Forms.Panel();
            this.m_panelFormulaire = new System.Windows.Forms.Panel();
            this.m_pictosActeur = new System.Windows.Forms.ImageList(this.components);
            this.m_panelOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxAddLine)).BeginInit();
            this.m_panelLieEquipement.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelOperation
            // 
            this.m_panelOperation.Controls.Add(this.m_txtCommentaire);
            this.m_panelOperation.Controls.Add(this.m_txtDuree);
            this.m_panelOperation.Controls.Add(this.m_cmbTypeOperation);
            this.m_panelOperation.Controls.Add(this.m_lblTypeOperation);
            this.m_panelOperation.Controls.Add(this.m_lblCode);
            this.m_panelOperation.Controls.Add(this.splitter1);
            this.m_panelOperation.Controls.Add(this.m_btnPoubelle);
            this.m_panelOperation.Controls.Add(this.m_picBoxWarning);
            this.m_panelOperation.Controls.Add(this.m_picOperation);
            this.m_panelOperation.Controls.Add(this.m_picBoxAddLine);
            this.m_panelOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelOperation.Location = new System.Drawing.Point(18, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelOperation.Name = "m_panelOperation";
            this.m_panelOperation.Size = new System.Drawing.Size(954, 22);
            this.m_panelOperation.TabIndex = 0;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCommentaire.EmptyText = "";
            this.m_txtCommentaire.Location = new System.Drawing.Point(479, 0);
            this.m_txtCommentaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(409, 20);
            this.m_txtCommentaire.TabIndex = 4;
            this.m_txtCommentaire.TextChanged += new System.EventHandler(this.m_controlSaisie_ValueChanged);
            // 
            // m_txtDuree
            // 
            this.m_txtDuree.AllowNoUnit = false;
            this.m_txtDuree.DefaultFormat = "";
            this.m_txtDuree.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtDuree.EmptyText = "";
            this.m_txtDuree.Location = new System.Drawing.Point(418, 0);
            this.m_txtDuree.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDuree.Name = "m_txtDuree";
            this.m_txtDuree.Size = new System.Drawing.Size(61, 20);
            this.m_txtDuree.TabIndex = 3;
            this.m_txtDuree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDuree.UnitValue = null;
            this.m_txtDuree.UseValueFormat = false;
            this.m_txtDuree.TextChanged += new System.EventHandler(this.m_controlSaisie_ValueChanged);
            // 
            // m_cmbTypeOperation
            // 
            this.m_cmbTypeOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbTypeOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeOperation.FormattingEnabled = true;
            this.m_cmbTypeOperation.IsLink = false;
            this.m_cmbTypeOperation.Location = new System.Drawing.Point(163, 0);
            this.m_cmbTypeOperation.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbTypeOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbTypeOperation.Name = "m_cmbTypeOperation";
            this.m_cmbTypeOperation.Size = new System.Drawing.Size(255, 21);
            this.m_cmbTypeOperation.TabIndex = 0;
            this.m_cmbTypeOperation.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeOperation_SelectionChangeCommitted);
            this.m_cmbTypeOperation.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeOperation_SelectedIndexChanged);
            this.m_cmbTypeOperation.Leave += new System.EventHandler(this.m_cmbTypeOperation_Leave);
            this.m_cmbTypeOperation.Enter += new System.EventHandler(this.m_cmbTypeOperation_Enter);
            this.m_cmbTypeOperation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_cmbTypeOperation_KeyUp);
            this.m_cmbTypeOperation.TextChanged += new System.EventHandler(this.m_cmbTypeOperation_TextChanged);
            // 
            // m_lblTypeOperation
            // 
            this.m_lblTypeOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblTypeOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblTypeOperation.Location = new System.Drawing.Point(75, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeOperation.Name = "m_lblTypeOperation";
            this.m_lblTypeOperation.Size = new System.Drawing.Size(88, 22);
            this.m_lblTypeOperation.TabIndex = 25;
            this.m_lblTypeOperation.Text = "OnlyOnLockEd";
            this.m_lblTypeOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblCode
            // 
            this.m_lblCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblCode.Location = new System.Drawing.Point(25, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCode.Name = "m_lblCode";
            this.m_lblCode.Size = new System.Drawing.Size(50, 22);
            this.m_lblCode.TabIndex = 13;
            this.m_lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(22, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 22);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(888, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(22, 22);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 19;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // m_picBoxWarning
            // 
            this.m_picBoxWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picBoxWarning.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picBoxWarning.Image = global::timos.Properties.Resources.alerte;
            this.m_picBoxWarning.Location = new System.Drawing.Point(910, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picBoxWarning, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picBoxWarning.Name = "m_picBoxWarning";
            this.m_picBoxWarning.Size = new System.Drawing.Size(22, 22);
            this.m_picBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_picBoxWarning.TabIndex = 23;
            this.m_picBoxWarning.TabStop = false;
            // 
            // m_picOperation
            // 
            this.m_picOperation.BackColor = System.Drawing.Color.White;
            this.m_picOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picOperation.Image = global::timos.Properties.Resources.COperation;
            this.m_picOperation.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picOperation.Name = "m_picOperation";
            this.m_picOperation.Size = new System.Drawing.Size(22, 22);
            this.m_picOperation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picOperation.TabIndex = 24;
            this.m_picOperation.TabStop = false;
            this.m_picOperation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_picOperation_MouseMove);
            this.m_picOperation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_picOperation_MouseDown);
            this.m_picOperation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_picOperation_MouseUp);
            // 
            // m_picBoxAddLine
            // 
            this.m_picBoxAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picBoxAddLine.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picBoxAddLine.Image = global::timos.Properties.Resources.check;
            this.m_picBoxAddLine.Location = new System.Drawing.Point(932, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picBoxAddLine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picBoxAddLine.Name = "m_picBoxAddLine";
            this.m_picBoxAddLine.Size = new System.Drawing.Size(22, 22);
            this.m_picBoxAddLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picBoxAddLine.TabIndex = 26;
            this.m_picBoxAddLine.TabStop = false;
            this.m_picBoxAddLine.Click += new System.EventHandler(this.m_picBoxAddLine_Click);
            // 
            // m_panelLieEquipement
            // 
            this.m_panelLieEquipement.Controls.Add(this.m_txtSelectEquipementLie);
            this.m_panelLieEquipement.Controls.Add(this.m_lblEquipement);
            this.m_panelLieEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelLieEquipement.Location = new System.Drawing.Point(63, 22);
            this.m_extModeEdition.SetModeEdition(this.m_panelLieEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLieEquipement.Name = "m_panelLieEquipement";
            this.m_panelLieEquipement.Size = new System.Drawing.Size(909, 21);
            this.m_panelLieEquipement.TabIndex = 21;
            // 
            // m_txtSelectEquipementLie
            // 
            this.m_txtSelectEquipementLie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectEquipementLie.ElementSelectionne = null;
            this.m_txtSelectEquipementLie.FonctionTextNull = null;
            this.m_txtSelectEquipementLie.HasLink = true;
            this.m_txtSelectEquipementLie.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectEquipementLie.Location = new System.Drawing.Point(104, 0);
            this.m_txtSelectEquipementLie.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectEquipementLie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectEquipementLie.Name = "m_txtSelectEquipementLie";
            this.m_txtSelectEquipementLie.SelectedObject = null;
            this.m_txtSelectEquipementLie.Size = new System.Drawing.Size(802, 21);
            this.m_txtSelectEquipementLie.SpecificImage = null;
            this.m_txtSelectEquipementLie.TabIndex = 0;
            this.m_txtSelectEquipementLie.TextNull = "";
            this.m_txtSelectEquipementLie.OnSelectedObjectChanged += new System.EventHandler(this.m_controlSaisie_ValueChanged);
            // 
            // m_lblEquipement
            // 
            this.m_lblEquipement.Location = new System.Drawing.Point(3, 1);
            this.m_extModeEdition.SetModeEdition(this.m_lblEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEquipement.Name = "m_lblEquipement";
            this.m_lblEquipement.Size = new System.Drawing.Size(95, 19);
            this.m_lblEquipement.TabIndex = 9;
            this.m_lblEquipement.Text = "Equipment|195";
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(18, 88);
            this.m_panelMarge.TabIndex = 22;
            // 
            // m_panelGaucheFormulaire
            // 
            this.m_panelGaucheFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGaucheFormulaire.Location = new System.Drawing.Point(18, 22);
            this.m_extModeEdition.SetModeEdition(this.m_panelGaucheFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGaucheFormulaire.Name = "m_panelGaucheFormulaire";
            this.m_panelGaucheFormulaire.Size = new System.Drawing.Size(45, 66);
            this.m_panelGaucheFormulaire.TabIndex = 23;
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaire.Location = new System.Drawing.Point(63, 43);
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(909, 20);
            this.m_panelFormulaire.TabIndex = 0;
            // 
            // m_pictosActeur
            // 
            this.m_pictosActeur.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_pictosActeur.ImageStream")));
            this.m_pictosActeur.TransparentColor = System.Drawing.Color.Transparent;
            this.m_pictosActeur.Images.SetKeyName(0, "Picto_acteur3.png");
            this.m_pictosActeur.Images.SetKeyName(1, "search.png");
            // 
            // CEditeurUneOperationPreventive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelLieEquipement);
            this.Controls.Add(this.m_panelGaucheFormulaire);
            this.Controls.Add(this.m_panelOperation);
            this.Controls.Add(this.m_panelMarge);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurUneOperationPreventive";
            this.Size = new System.Drawing.Size(972, 88);
            this.m_panelOperation.ResumeLayout(false);
            this.m_panelOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxAddLine)).EndInit();
            this.m_panelLieEquipement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelOperation;
        private System.Windows.Forms.Label m_lblCode;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtDuree;
        private sc2i.win32.common.C2iTextBox m_txtCommentaire;
        private System.Windows.Forms.PictureBox m_btnPoubelle;
        private System.Windows.Forms.Panel m_panelLieEquipement;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectEquipementLie;
        private System.Windows.Forms.Label m_lblEquipement;
        private System.Windows.Forms.Panel m_panelMarge;
        private System.Windows.Forms.Panel m_panelGaucheFormulaire;
        private Panel m_panelFormulaire;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ImageList m_pictosActeur;
        private C2iComboBox m_cmbTypeOperation;
        private System.Windows.Forms.PictureBox m_picBoxWarning;
        private System.Windows.Forms.PictureBox m_picOperation;
        private System.Windows.Forms.Label m_lblTypeOperation;
        private PictureBox m_picBoxAddLine;
    }
}
