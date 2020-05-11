using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

using timos.data;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using sc2i.process;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CFormatNumerotation))]
    public class CFormEditionFormatNumerotation : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer
		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panel1;
        private C2iNumericUpDown m_nudNbCarac;
        private Label m_lblLabel;
        private Label m_lblNbCarac;
        private Label m_lblSequence;
        private C2iTextBox m_txtSequence;
        private C2iTextBox m_txtIndex;
		private C2iTextBox m_txtReference;
		private Label m_lblIndexMax;
		private Label m_lblReferenceMax;
		private Label m_lblResultIMax;
		private Label m_lblResultRefMax;
		private Label m_lblErr;
		private Label m_lblIndex;
		private Label m_lblReference;
		private C2iPanelOmbre m_panelDetail;
		private Label m_lblPan2;
		private Timer m_tMAJConvertisseur;
        private CheckBox m_chkRomain;
		private C2iPanelOmbre c2iPanelOmbre1;
        private Panel panel1;
        private System.ComponentModel.IContainer components = null;


		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panel1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_chkRomain = new System.Windows.Forms.CheckBox();
            this.m_txtSequence = new sc2i.win32.common.C2iTextBox();
            this.m_nudNbCarac = new sc2i.win32.common.C2iNumericUpDown();
            this.m_lblSequence = new System.Windows.Forms.Label();
            this.m_lblNbCarac = new System.Windows.Forms.Label();
            this.m_txtIndex = new sc2i.win32.common.C2iTextBox();
            this.m_lblIndexMax = new System.Windows.Forms.Label();
            this.m_lblResultIMax = new System.Windows.Forms.Label();
            this.m_txtReference = new sc2i.win32.common.C2iTextBox();
            this.m_lblReferenceMax = new System.Windows.Forms.Label();
            this.m_lblResultRefMax = new System.Windows.Forms.Label();
            this.m_lblErr = new System.Windows.Forms.Label();
            this.m_lblIndex = new System.Windows.Forms.Label();
            this.m_lblReference = new System.Windows.Forms.Label();
            this.m_panelDetail = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lblPan2 = new System.Windows.Forms.Label();
            this.m_tMAJConvertisseur = new System.Windows.Forms.Timer(this.components);
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNbCarac)).BeginInit();
            this.m_panelDetail.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(66, 5);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(297, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            this.m_txtLibelle.TextChanged += new System.EventHandler(this.Modif);
            // 
            // m_panel1
            // 
            this.m_panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panel1.Controls.Add(this.m_txtLibelle);
            this.m_panel1.Controls.Add(this.m_lblLabel);
            this.m_panel1.Controls.Add(this.m_chkRomain);
            this.m_panel1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panel1, "");
            this.m_panel1.Location = new System.Drawing.Point(8, 52);
            this.m_panel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panel1, "");
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(464, 78);
            this.m_extStyle.SetStyleBackColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panel1.TabIndex = 0;
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(13, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_chkRomain
            // 
            this.m_chkRomain.AutoSize = true;
            this.m_chkRomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkField.SetLinkField(this.m_chkRomain, "Romain");
            this.m_chkRomain.Location = new System.Drawing.Point(66, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkRomain, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkRomain, "");
            this.m_chkRomain.Name = "m_chkRomain";
            this.m_chkRomain.Size = new System.Drawing.Size(141, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkRomain, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkRomain, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkRomain.TabIndex = 4006;
            this.m_chkRomain.Text = "Roman numerotation|410";
            this.m_chkRomain.UseVisualStyleBackColor = true;
            this.m_chkRomain.CheckedChanged += new System.EventHandler(this.m_chkRomain_CheckedChanged);
            // 
            // m_txtSequence
            // 
            this.m_extLinkField.SetLinkField(this.m_txtSequence, "Sequence");
            this.m_txtSequence.Location = new System.Drawing.Point(159, 36);
            this.m_txtSequence.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSequence, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSequence, "");
            this.m_txtSequence.Multiline = true;
            this.m_txtSequence.Name = "m_txtSequence";
            this.m_txtSequence.Size = new System.Drawing.Size(204, 56);
            this.m_extStyle.SetStyleBackColor(this.m_txtSequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSequence.TabIndex = 1;
            this.m_txtSequence.Text = "[Sequence]";
            this.m_txtSequence.TextChanged += new System.EventHandler(this.Modif);
            // 
            // m_nudNbCarac
            // 
            this.m_nudNbCarac.DoubleValue = 0;
            this.m_nudNbCarac.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_nudNbCarac, "LongueurReference");
            this.m_nudNbCarac.Location = new System.Drawing.Point(159, 9);
            this.m_nudNbCarac.LockEdition = false;
            this.m_nudNbCarac.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_nudNbCarac, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_nudNbCarac, "");
            this.m_nudNbCarac.Name = "m_nudNbCarac";
            this.m_nudNbCarac.Size = new System.Drawing.Size(51, 20);
            this.m_extStyle.SetStyleBackColor(this.m_nudNbCarac, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_nudNbCarac, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nudNbCarac.TabIndex = 0;
            this.m_nudNbCarac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_nudNbCarac.ThousandsSeparator = true;
            this.m_nudNbCarac.ValueChanged += new System.EventHandler(this.Modif);
            // 
            // m_lblSequence
            // 
            this.m_lblSequence.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblSequence, "");
            this.m_lblSequence.Location = new System.Drawing.Point(50, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSequence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblSequence, "");
            this.m_lblSequence.Name = "m_lblSequence";
            this.m_lblSequence.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblSequence.Size = new System.Drawing.Size(76, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSequence.TabIndex = 4007;
            this.m_lblSequence.Text = "Sequence|315";
            this.m_lblSequence.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblNbCarac
            // 
            this.m_lblNbCarac.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblNbCarac, "");
            this.m_lblNbCarac.Location = new System.Drawing.Point(16, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNbCarac, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblNbCarac, "");
            this.m_lblNbCarac.Name = "m_lblNbCarac";
            this.m_lblNbCarac.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblNbCarac.Size = new System.Drawing.Size(110, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblNbCarac, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbCarac, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNbCarac.TabIndex = 4005;
            this.m_lblNbCarac.Text = "Numbering lenght|314";
            this.m_lblNbCarac.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txtIndex
            // 
            this.m_extLinkField.SetLinkField(this.m_txtIndex, "");
            this.m_txtIndex.Location = new System.Drawing.Point(97, 41);
            this.m_txtIndex.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtIndex, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtIndex, "");
            this.m_txtIndex.Name = "m_txtIndex";
            this.m_txtIndex.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIndex.TabIndex = 0;
            this.m_txtIndex.TextChanged += new System.EventHandler(this.m_txtIndex_TextChanged);
            // 
            // m_lblIndexMax
            // 
            this.m_lblIndexMax.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblIndexMax, "");
            this.m_lblIndexMax.Location = new System.Drawing.Point(228, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblIndexMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblIndexMax, "");
            this.m_lblIndexMax.Name = "m_lblIndexMax";
            this.m_lblIndexMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblIndexMax.Size = new System.Drawing.Size(76, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblIndexMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblIndexMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblIndexMax.TabIndex = 4007;
            this.m_lblIndexMax.Text = "Max Index|353";
            this.m_lblIndexMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblResultIMax
            // 
            this.m_lblResultIMax.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblResultIMax, "");
            this.m_lblResultIMax.Location = new System.Drawing.Point(311, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblResultIMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblResultIMax, "");
            this.m_lblResultIMax.Name = "m_lblResultIMax";
            this.m_lblResultIMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblResultIMax.Size = new System.Drawing.Size(66, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblResultIMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblResultIMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblResultIMax.TabIndex = 4007;
            this.m_lblResultIMax.Text = "INDEX MAX";
            this.m_lblResultIMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txtReference
            // 
            this.m_extLinkField.SetLinkField(this.m_txtReference, "");
            this.m_txtReference.Location = new System.Drawing.Point(97, 67);
            this.m_txtReference.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtReference, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtReference, "");
            this.m_txtReference.Name = "m_txtReference";
            this.m_txtReference.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtReference.TabIndex = 1;
            this.m_txtReference.TextChanged += new System.EventHandler(this.m_txtReference_TextChanged);
            // 
            // m_lblReferenceMax
            // 
            this.m_lblReferenceMax.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblReferenceMax, "");
            this.m_lblReferenceMax.Location = new System.Drawing.Point(204, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblReferenceMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblReferenceMax, "");
            this.m_lblReferenceMax.Name = "m_lblReferenceMax";
            this.m_lblReferenceMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblReferenceMax.Size = new System.Drawing.Size(100, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblReferenceMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblReferenceMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblReferenceMax.TabIndex = 4007;
            this.m_lblReferenceMax.Text = "Max Reference|354";
            this.m_lblReferenceMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblResultRefMax
            // 
            this.m_lblResultRefMax.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblResultRefMax, "");
            this.m_lblResultRefMax.Location = new System.Drawing.Point(311, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblResultRefMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblResultRefMax, "");
            this.m_lblResultRefMax.Name = "m_lblResultRefMax";
            this.m_lblResultRefMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblResultRefMax.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblResultRefMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblResultRefMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblResultRefMax.TabIndex = 4007;
            this.m_lblResultRefMax.Text = "REFERENCE MAX";
            this.m_lblResultRefMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblErr
            // 
            this.m_lblErr.AutoSize = true;
            this.m_lblErr.ForeColor = System.Drawing.Color.Red;
            this.m_extLinkField.SetLinkField(this.m_lblErr, "");
            this.m_lblErr.Location = new System.Drawing.Point(106, 171);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblErr, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblErr, "");
            this.m_lblErr.Name = "m_lblErr";
            this.m_lblErr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblErr.Size = new System.Drawing.Size(0, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblErr.TabIndex = 4007;
            this.m_lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblIndex
            // 
            this.m_lblIndex.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblIndex, "");
            this.m_lblIndex.Location = new System.Drawing.Point(16, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblIndex, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblIndex, "");
            this.m_lblIndex.Name = "m_lblIndex";
            this.m_lblIndex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblIndex.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblIndex.TabIndex = 4007;
            this.m_lblIndex.Text = "Index|10090";
            this.m_lblIndex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblReference
            // 
            this.m_lblReference.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblReference, "");
            this.m_lblReference.Location = new System.Drawing.Point(16, 70);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblReference, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblReference, "");
            this.m_lblReference.Name = "m_lblReference";
            this.m_lblReference.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblReference.Size = new System.Drawing.Size(89, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblReference.TabIndex = 4007;
            this.m_lblReference.Text = "Reference|10091";
            this.m_lblReference.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_panelDetail
            // 
            this.m_panelDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelDetail.Controls.Add(this.m_txtSequence);
            this.m_panelDetail.Controls.Add(this.m_nudNbCarac);
            this.m_panelDetail.Controls.Add(this.m_lblNbCarac);
            this.m_panelDetail.Controls.Add(this.m_lblErr);
            this.m_panelDetail.Controls.Add(this.m_lblSequence);
            this.m_panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelDetail.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelDetail, "");
            this.m_panelDetail.Location = new System.Drawing.Point(0, 0);
            this.m_panelDetail.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDetail, "");
            this.m_panelDetail.Name = "m_panelDetail";
            this.m_panelDetail.Size = new System.Drawing.Size(510, 118);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelDetail.TabIndex = 4004;
            // 
            // m_lblPan2
            // 
            this.m_lblPan2.AutoSize = true;
            this.m_lblPan2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblPan2, "");
            this.m_lblPan2.Location = new System.Drawing.Point(7, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPan2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPan2, "");
            this.m_lblPan2.Name = "m_lblPan2";
            this.m_lblPan2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblPan2.Size = new System.Drawing.Size(100, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblPan2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPan2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPan2.TabIndex = 4007;
            this.m_lblPan2.Text = "Converter|10089";
            this.m_lblPan2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_tMAJConvertisseur
            // 
            this.m_tMAJConvertisseur.Interval = 200;
            this.m_tMAJConvertisseur.Tick += new System.EventHandler(this.m_tMAJConvertisseur_Tick);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_txtReference);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtIndex);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblPan2);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblReference);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblIndex);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblResultRefMax);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblReferenceMax);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblResultIMax);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblIndexMax);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 118);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(510, 120);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4005;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c2iPanelOmbre1);
            this.panel1.Controls.Add(this.m_panelDetail);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(8, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 348);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4005;
            // 
            // CFormEditionFormatNumerotation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panel1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionFormatNumerotation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panel1.ResumeLayout(false);
            this.m_panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNbCarac)).EndInit();
            this.m_panelDetail.ResumeLayout(false);
            this.m_panelDetail.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		#endregion

		#region ++ Constructeurs ++
		public CFormEditionFormatNumerotation()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionFormatNumerotation(CFormatNumerotation FormatNumerotation)
            : base(FormatNumerotation)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionFormatNumerotation(CFormatNumerotation FormatNumerotation, CListeObjetsDonnees liste)
            : base(FormatNumerotation, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
		}
		#endregion

		//-------------------------------------------------------------------------
        private CFormatNumerotation FormatNumerotation
        {
            get
            {
                return (CFormatNumerotation)ObjetEdite;
            }
		}

		#region ~~ Méthodes ~~

		//-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
			m_bFormInitialisee = false;
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Numbering Format|331") + " " + FormatNumerotation.Libelle);

			m_panelDetail.Visible = !m_chkRomain.Checked;
			MAJConvertisseur();

			m_bFormInitialisee = true;
            return result;
        }

		
		private void MAJConvertisseur()
		{
			int indexMax = FormatNumerotation.IndexMax;
			if(indexMax == -1)
				this.m_lblResultIMax.Text = I.T("Not defined Sequence|451");
			else if(indexMax == -2)
				this.m_lblResultIMax.Text = I.T("Too short Sequence|452");
			else
				this.m_lblResultIMax.Text = indexMax.ToString();

			this.m_lblResultRefMax.Text = FormatNumerotation.ReferenceMax;

			this.m_txtReference.Text = "";
			this.m_txtIndex.Text = "";
		}
		#endregion

		#region ** Evenements **
		internal bool m_bFormInitialisee = false;
		internal bool m_bEdition = false;

		private void m_txtIndex_TextChanged(object sender, EventArgs e)
		{
			if (!m_bEdition)
			{

				if (m_txtIndex.Text != null && m_txtIndex.Text != "")
				{
					m_bEdition = true;

					m_lblErr.Text = "";
					m_txtReference.Text = "";
					
					CResultAErreur result = CResultAErreur.True;

					try
					{
						result = FormatNumerotation.GetReference(int.Parse(m_txtIndex.Text));
					}
					catch
					{
						result.EmpileErreur(I.T( "Bad Index or too long|334"));
					}

					if (!result.Result)
					{
						foreach (CErreurSimple E in result.Erreur)
							m_lblErr.Text += E.Message;
					}
					else
						m_txtReference.Text = result.Data.ToString();

					m_bEdition = false;
				}
				else
				{
					m_bEdition = true;
					m_txtReference.Text = "";
					m_bEdition = false;
				}
			}
		}
		private void m_txtReference_TextChanged(object sender, EventArgs e)
		{
			if (!m_bEdition)
			{

				if (m_txtReference.Text != null && m_txtReference.Text != "")
				{
					m_bEdition = true;

					m_lblErr.Text = "";
					m_txtIndex.Text = "";
					
					CResultAErreur result = CResultAErreur.True;

					result = FormatNumerotation.GetIndex(m_txtReference.Text);
					if (!result.Result)
					{
						foreach (IErreur E in result.Erreur)
							m_lblErr.Text += E.Message;
					}
					else
						m_txtIndex.Text = result.Data.ToString();

					m_bEdition = false;
				}
				else
				{
					m_bEdition = true;
					m_txtIndex.Text = "";
					m_bEdition = false;
				}
			}
		}

		private void m_tMAJConvertisseur_Tick(object sender, EventArgs e)
		{
			MAJConvertisseur();
			m_tMAJConvertisseur.Stop();
		}
		private void Modif(object sender, EventArgs e)
		{
			if (m_bFormInitialisee)
			{
				m_tMAJConvertisseur.Stop();
				m_tMAJConvertisseur.Start();

				this.MAJ_Champs();
			}
		}
		
		private void m_chkRomain_CheckedChanged(object sender, EventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition && m_bFormInitialisee)
			{
				FormatNumerotation.Romain = m_chkRomain.Checked;
				m_panelDetail.Visible = !m_chkRomain.Checked;
				MAJConvertisseur();
			}
		}
		#endregion

	}
}

