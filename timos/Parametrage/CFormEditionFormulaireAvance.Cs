using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using sc2i.formulaire;
using sc2i.formulaire.win32.editor;

using timos.acteurs;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CFormulaire))]
	public class CFormEditionFormulaireAvance : CFormEditionStdTimos, IFormNavigable
	{

		private CFournisseurPropDynStd m_fournisseurProprietes = new CFournisseurPropDynStd(true);

        /// <summary>
        /// Liste des contrôles à ajouter au formulaire. il s'agit de contrôles
        /// qui sont dans la fenêtre principale en cas de formulaire superposé
        /// </summary>
        private List<IControleFormulaireExterne> m_listeControlesExternes = null;
	

		#region Designer generated code


		private System.Windows.Forms.Label m_lblLabel;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iPanelOmbre m_panelLibelle;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iNumericUpDown m_numericUpDown;
        private Crownwood.Magic.Controls.TabPage pageFormulaire;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeMasquer;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private CPanelEditionFullFormulaire m_panelEditionFullFormulaire;
        private Label label4;
        private C2iTextBox c2iTextBox1;
        private Label label5;
        private RadioButton m_radFormIncorpore;
        private RadioButton m_radFormComplet;
        private C2iComboBox m_cmbTypeElement;
        private CheckBox m_chkShowAlways;
        private CheckBox m_chkAllowEditMode;
        private CheckBox m_chkIsArray;
        private LinkLabel m_lnkSousRoles;
        private ContextMenuStrip m_menuAutresUtilisations;
		private System.ComponentModel.IContainer components = null;



		
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		//-------------------------------------------------------------------------
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionFormulaireAvance));
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelLibelle = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkIsArray = new System.Windows.Forms.CheckBox();
            this.m_chkShowAlways = new System.Windows.Forms.CheckBox();
            this.m_cmbTypeElement = new sc2i.win32.common.C2iComboBox();
            this.m_radFormIncorpore = new System.Windows.Forms.RadioButton();
            this.m_chkAllowEditMode = new System.Windows.Forms.CheckBox();
            this.m_radFormComplet = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.m_numericUpDown = new sc2i.win32.common.C2iNumericUpDown();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditionFullFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.m_wndListeMasquer = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_lnkSousRoles = new System.Windows.Forms.LinkLabel();
            this.m_menuAutresUtilisations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelLibelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDown)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.pageFormulaire.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "sc2i.data.dynamic.CFormulaire";
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(709, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(601, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(884, 28);
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
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLabel, false);
            this.m_lblLabel.Location = new System.Drawing.Point(7, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 67;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(64, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(261, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(335, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4001;
            this.label2.Text = "Associated Type|10023";
            // 
            // m_panelLibelle
            // 
            this.m_panelLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelLibelle.Controls.Add(this.m_lnkSousRoles);
            this.m_panelLibelle.Controls.Add(this.m_chkIsArray);
            this.m_panelLibelle.Controls.Add(this.m_cmbTypeElement);
            this.m_panelLibelle.Controls.Add(this.m_radFormIncorpore);
            this.m_panelLibelle.Controls.Add(this.m_chkShowAlways);
            this.m_panelLibelle.Controls.Add(this.m_radFormComplet);
            this.m_panelLibelle.Controls.Add(this.label5);
            this.m_panelLibelle.Controls.Add(this.m_chkAllowEditMode);
            this.m_panelLibelle.Controls.Add(this.m_txtLibelle);
            this.m_panelLibelle.Controls.Add(this.m_numericUpDown);
            this.m_panelLibelle.Controls.Add(this.m_lblLabel);
            this.m_panelLibelle.Controls.Add(this.c2iTextBox1);
            this.m_panelLibelle.Controls.Add(this.label3);
            this.m_panelLibelle.Controls.Add(this.label4);
            this.m_panelLibelle.Controls.Add(this.label2);
            this.m_panelLibelle.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLibelle, false);
            this.m_panelLibelle.Location = new System.Drawing.Point(16, 44);
            this.m_panelLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLibelle, "");
            this.m_panelLibelle.Name = "m_panelLibelle";
            this.m_panelLibelle.Size = new System.Drawing.Size(844, 86);
            this.m_extStyle.SetStyleBackColor(this.m_panelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelLibelle.TabIndex = 0;
            this.m_panelLibelle.Text = "[NumeroOrdre]";
            // 
            // m_chkIsArray
            // 
            this.m_chkIsArray.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkIsArray, "ElementEditeIsArray");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkIsArray, true);
            this.m_chkIsArray.Location = new System.Drawing.Point(762, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIsArray, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkIsArray, "");
            this.m_chkIsArray.Name = "m_chkIsArray";
            this.m_chkIsArray.Size = new System.Drawing.Size(82, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIsArray, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIsArray, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIsArray.TabIndex = 4013;
            this.m_chkIsArray.Text = "Array|20829";
            this.m_chkIsArray.UseVisualStyleBackColor = true;
            this.m_chkIsArray.CheckedChanged += new System.EventHandler(this.m_chkIsArray_CheckedChanged);
            // 
            // m_chkShowAlways
            // 
            this.m_chkShowAlways.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkShowAlways, "AfficherPartout");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkShowAlways, true);
            this.m_chkShowAlways.Location = new System.Drawing.Point(64, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkShowAlways, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkShowAlways, "");
            this.m_chkShowAlways.Name = "m_chkShowAlways";
            this.m_chkShowAlways.Size = new System.Drawing.Size(120, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkShowAlways, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkShowAlways, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkShowAlways.TabIndex = 4011;
            this.m_chkShowAlways.Text = "Show always|20190";
            this.m_chkShowAlways.UseVisualStyleBackColor = true;
            // 
            // m_cmbTypeElement
            // 
            this.m_cmbTypeElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeElement.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeElement, false);
            this.m_cmbTypeElement.Location = new System.Drawing.Point(462, 29);
            this.m_cmbTypeElement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElement, "");
            this.m_cmbTypeElement.Name = "m_cmbTypeElement";
            this.m_cmbTypeElement.Size = new System.Drawing.Size(298, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElement.TabIndex = 4010;
            this.m_cmbTypeElement.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeElement_SelectionChangeCommitted);
            this.m_cmbTypeElement.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeElement_SelectedIndexChanged);
            // 
            // m_radFormIncorpore
            // 
            this.m_radFormIncorpore.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radFormIncorpore, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radFormIncorpore, false);
            this.m_radFormIncorpore.Location = new System.Drawing.Point(603, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radFormIncorpore, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radFormIncorpore, "");
            this.m_radFormIncorpore.Name = "m_radFormIncorpore";
            this.m_radFormIncorpore.Size = new System.Drawing.Size(125, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radFormIncorpore, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radFormIncorpore, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radFormIncorpore.TabIndex = 4009;
            this.m_radFormIncorpore.TabStop = true;
            this.m_radFormIncorpore.Text = "Embeded form|10026";
            this.m_radFormIncorpore.UseVisualStyleBackColor = true;
            this.m_radFormIncorpore.CheckedChanged += new System.EventHandler(this.m_radUtilisation_CheckedChanged);
            // 
            // m_chkAllowEditMode
            // 
            this.m_chkAllowEditMode.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAllowEditMode, "AllowEditMode");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAllowEditMode, true);
            this.m_chkAllowEditMode.Location = new System.Drawing.Point(200, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAllowEditMode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAllowEditMode, "");
            this.m_chkAllowEditMode.Name = "m_chkAllowEditMode";
            this.m_chkAllowEditMode.Size = new System.Drawing.Size(132, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAllowEditMode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAllowEditMode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAllowEditMode.TabIndex = 4012;
            this.m_chkAllowEditMode.Text = "Allow edit mode|20473";
            this.m_chkAllowEditMode.UseVisualStyleBackColor = true;
            // 
            // m_radFormComplet
            // 
            this.m_radFormComplet.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radFormComplet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radFormComplet, false);
            this.m_radFormComplet.Location = new System.Drawing.Point(462, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radFormComplet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radFormComplet, "");
            this.m_radFormComplet.Name = "m_radFormComplet";
            this.m_radFormComplet.Size = new System.Drawing.Size(96, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radFormComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radFormComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radFormComplet.TabIndex = 4009;
            this.m_radFormComplet.TabStop = true;
            this.m_radFormComplet.Text = "Full form|10025";
            this.m_radFormComplet.UseVisualStyleBackColor = true;
            this.m_radFormComplet.CheckedChanged += new System.EventHandler(this.m_radUtilisation_CheckedChanged);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(335, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4008;
            this.label5.Text = "Purpose|898";
            // 
            // m_numericUpDown
            // 
            this.m_numericUpDown.DoubleValue = 0;
            this.m_numericUpDown.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numericUpDown, "NumeroOrdre");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numericUpDown, true);
            this.m_numericUpDown.Location = new System.Drawing.Point(64, 29);
            this.m_numericUpDown.LockEdition = false;
            this.m_numericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numericUpDown, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numericUpDown, "");
            this.m_numericUpDown.Name = "m_numericUpDown";
            this.m_numericUpDown.Size = new System.Drawing.Size(64, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numericUpDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numericUpDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numericUpDown.TabIndex = 4005;
            this.m_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numericUpDown.ThousandsSeparator = true;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "CodeFormulaire");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(200, 29);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(125, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4006;
            this.c2iTextBox1.Text = "[CodeFormulaire]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(7, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Order|782";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(134, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4004;
            this.label4.Text = "Code|40";
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(16, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.pageFormulaire;
            this.m_tabControl.Size = new System.Drawing.Size(860, 394);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFormulaire});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageFormulaire
            // 
            this.pageFormulaire.Controls.Add(this.m_panelEditionFullFormulaire);
            this.m_extLinkField.SetLinkField(this.pageFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageFormulaire, false);
            this.pageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFormulaire, "");
            this.pageFormulaire.Name = "pageFormulaire";
            this.pageFormulaire.Size = new System.Drawing.Size(844, 353);
            this.m_extStyle.SetStyleBackColor(this.pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageFormulaire.TabIndex = 10;
            this.pageFormulaire.Title = "Form|555";
            // 
            // m_panelEditionFullFormulaire
            // 
            this.m_panelEditionFullFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditionFullFormulaire.EntiteEditee = null;
            this.m_panelEditionFullFormulaire.FournisseurProprietes = null;
            this.m_extLinkField.SetLinkField(this.m_panelEditionFullFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditionFullFormulaire, false);
            this.m_panelEditionFullFormulaire.Location = new System.Drawing.Point(3, 3);
            this.m_panelEditionFullFormulaire.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionFullFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditionFullFormulaire, "");
            this.m_panelEditionFullFormulaire.Name = "m_panelEditionFullFormulaire";
            this.m_panelEditionFullFormulaire.Size = new System.Drawing.Size(835, 347);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionFullFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionFullFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionFullFormulaire.TabIndex = 0;
            this.m_panelEditionFullFormulaire.TypeEdite = null;
            this.m_panelEditionFullFormulaire.WndEditee = null;
            this.m_panelEditionFullFormulaire.Load += new System.EventHandler(this.m_panelEditionFullFormulaire_Load);
            // 
            // m_wndListeMasquer
            // 
            this.m_wndListeMasquer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeMasquer.CheckBoxes = true;
            this.m_wndListeMasquer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeMasquer.EnableCustomisation = true;
            this.m_wndListeMasquer.FullRowSelect = true;
            this.m_wndListeMasquer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_extLinkField.SetLinkField(this.m_wndListeMasquer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeMasquer, false);
            this.m_wndListeMasquer.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeMasquer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeMasquer, "");
            this.m_wndListeMasquer.MultiSelect = false;
            this.m_wndListeMasquer.Name = "m_wndListeMasquer";
            this.m_wndListeMasquer.Size = new System.Drawing.Size(216, 360);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeMasquer.TabIndex = 13;
            this.m_wndListeMasquer.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMasquer.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 200;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_panelEditionFullFormulaire.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // m_lnkSousRoles
            // 
            this.m_lnkSousRoles.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkSousRoles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSousRoles, false);
            this.m_lnkSousRoles.Location = new System.Drawing.Point(462, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSousRoles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkSousRoles, "");
            this.m_lnkSousRoles.Name = "m_lnkSousRoles";
            this.m_lnkSousRoles.Size = new System.Drawing.Size(104, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSousRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSousRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSousRoles.TabIndex = 4014;
            this.m_lnkSousRoles.TabStop = true;
            this.m_lnkSousRoles.Text = "Sub purposes|20586";
            this.m_lnkSousRoles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSousRoles_LinkClicked);
            // 
            // m_menuAutresUtilisations
            // 
            this.m_extLinkField.SetLinkField(this.m_menuAutresUtilisations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuAutresUtilisations, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuAutresUtilisations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuAutresUtilisations, "");
            this.m_menuAutresUtilisations.Name = "m_menuAutresUtilisations";
            this.m_menuAutresUtilisations.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuAutresUtilisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuAutresUtilisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormEditionFormulaireAvance
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(884, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelLibelle);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionFormulaireAvance";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionFormulaire_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelLibelle, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelLibelle.ResumeLayout(false);
            this.m_panelLibelle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDown)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageFormulaire.ResumeLayout(false);
            this.ResumeLayout(false);

		}


		#endregion


		private Type m_typeAssocie = null;
		private Image m_imageFond = null;


		//-------------------------------------------------------------------------
		public CFormEditionFormulaireAvance()
			: base()
		{
			InitializeComponent();

		}
		public CFormEditionFormulaireAvance(CFormulaire formulaire)
			: base(formulaire)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public CFormEditionFormulaireAvance(
            CFormulaire formulaire, 
            Image imageFond, 
            List<IControleFormulaireExterne> lstControlesExternes,
            Type typeAssocie)
			: base(formulaire)
		{
			InitializeComponent();
			m_imageFond = imageFond;
			m_typeAssocie = typeAssocie;
            m_listeControlesExternes = lstControlesExternes;
		}

		//-------------------------------------------------------------------------
		public CFormEditionFormulaireAvance(CFormulaire formulaire, CListeObjetsDonnees liste)
			: base(formulaire, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		
		}



		//-------------------------------------------------------------------------
		private CFormulaire Formulaire
		{
			get
			{
				return (CFormulaire)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Form @1|10000", Formulaire.Libelle));
			if (result)
			{
				//CUtilASauvegardeProfilDesigner.InitialiserProfil( new CContexteSauvegardeProfilDesigner(m_panelEditionFormulaire));

				ArrayList lst = new ArrayList ( CRoleChampCustom.Roles );
				foreach ( CRoleChampCustom role in lst.ToArray(typeof(CRoleChampCustom)) )
					if ( role.CodeRole == sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom )
						lst.Remove ( role );
				if ( Formulaire.Role != null && Formulaire.Role.CodeRole == 
					sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom )
					m_panelLibelle.Visible = false;
				else
					m_panelLibelle.Visible = true;
				C2iWndFenetre fenetre = Formulaire.Formulaire;
				fenetre.ImageFond = m_imageFond;

                if (m_listeControlesExternes != null)
                    fenetre.SetControlesExternes(m_listeControlesExternes.ToArray());

                if (m_typeAssocie != null)
                    Formulaire.TypeElementEdite = m_typeAssocie;

				CListeObjetsDonnees listeRestrictions = new CListeObjetsDonnees ( Formulaire.ContexteDonnee, typeof ( CRestrictionChampCustom ) );
				m_wndListeMasquer.Remplir ( listeRestrictions );
				foreach ( ListViewItem item in m_wndListeMasquer.Items )
				{
					CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
					if ( (Formulaire.RestrictionsMasquer & (int)Math.Pow(2,rest.ValeurFlag)) != 0 )
						item.Checked = true;
					else
						item.Checked = false;
				}

                if (Formulaire.TypeElementEdite == null)
                    m_radFormIncorpore.Checked = true;
                else if(Formulaire.Role != null)
                    m_radFormIncorpore.Checked = true;
                else
                    m_radFormComplet.Checked = true;

                InitComboTypes(false);
                m_panelEditionFullFormulaire.Init(
                    Formulaire.TypeElementEdite,
                    fenetre,
                    fenetre, 
                    m_fournisseurProprietes);
				m_panelEditionFullFormulaire.AddObjetForClonerSerializer(typeof(CContexteDonnee), Formulaire.ContexteDonnee);
			}
            UpdateVisuAvecEditMode();
            RefreshVisuSousRoles();
			return result;
		}

        //-------------------------------------------------------------------------
        private bool m_bComboRemplissageInitialized = false;
        protected void InitComboTypes(bool bForcerRemplissage)
        {

            if (!m_bComboRemplissageInitialized || bForcerRemplissage)
            {
                List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>();

                if (m_radFormComplet.Checked)
                {
                    lstTypes.AddRange(DynamicClassAttribute.GetAllDynamicClass(typeof(TableAttribute)));
                    m_lnkSousRoles.Visible = false;
                }
                else
                {
                    List<CRoleChampCustom> lstRoles = new List<CRoleChampCustom>(CRoleChampCustom.Roles);
                    foreach (CRoleChampCustom role in lstRoles.ToArray())
                        if (role.CodeRole == sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom)
                            lstRoles.Remove(role);
                    if (Formulaire.Role != null && Formulaire.Role.CodeRole ==
                        sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom)
                        m_panelLibelle.Visible = false;
                    else
                        m_panelLibelle.Visible = true;
                    // Converti les roles en CInfoClasseDynamique
                    foreach (CRoleChampCustom role in lstRoles)
                    {
                        lstTypes.Add(new CInfoClasseDynamique(role.TypeAssocie, role.Libelle));
                    }
                    m_lnkSousRoles.Visible = true;
                }
                lstTypes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("General Form|30331")));
                m_cmbTypeElement.DataSource = lstTypes;
                m_cmbTypeElement.ValueMember = "Classe";
			    m_cmbTypeElement.DisplayMember = "Nom";

                m_bComboRemplissageInitialized = true;

            }

            if (Formulaire.Role != null)
                m_cmbTypeElement.SelectedValue = Formulaire.Role.TypeAssocie;
            else if (Formulaire.TypeElementEdite != null)
                m_cmbTypeElement.SelectedValue = Formulaire.TypeElementEdite;
            
        }
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			//CUtilASauvegardeProfilDesigner.SauvegarderDansRegistre(new CContexteSauvegardeProfilDesigner(m_panelEditionFormulaire));

			if (!result)
				return result;

            Type tpClasse = (Type)m_cmbTypeElement.SelectedValue;
            if (tpClasse == null)
            {
                Formulaire.TypeElementEdite = null;
                Formulaire.Role = null;
                Formulaire.CodesRolesSecondaires = new string[0];
            }
            else
            {
                Formulaire.TypeElementEdite = tpClasse;
                if (m_radFormIncorpore.Checked)
                    Formulaire.Role = CRoleChampCustom.GetRoleForType(tpClasse);
                else
                {
                    Formulaire.CodesRolesSecondaires = new string[0];
                    Formulaire.Role = null;
                }
            }
            Formulaire.Formulaire = (sc2i.formulaire.C2iWndFenetre)m_panelEditionFullFormulaire.WndEditee;

			int nRest = 0;
			foreach ( ListViewItem item in m_wndListeMasquer.Items )
			{
				if ( item.Checked )
				{
					CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
					nRest |= (int)Math.Pow(2,rest.ValeurFlag);
				}
			}
			Formulaire.RestrictionsMasquer = nRest;
			return result;
		}
		//-------------------------------------------------------------------------
		private void CFormEditionFormulaire_Load(object sender, System.EventArgs e)
		{
			//CProprieteChampCustomEditor.SetEditeur ( new CSelectionneurChampCustomTimos() );
		}
		//-------------------------------------------------------------------------
		private void m_propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			m_panelEditionFullFormulaire.Refresh();
		}



        //-------------------------------------------------------------------------		
        private void m_cmbTypeElement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Formulaire.TypeElementEdite = (Type) m_cmbTypeElement.SelectedValue;
            //m_panelEditionFullFormulaire.Init(Formulaire.TypeElementEdite, Formulaire.Formulaire, m_fournisseurProprietes);
            m_panelEditionFullFormulaire.TypeEdite = Formulaire.TypeElementEdite;
        }

        private void m_radUtilisation_CheckedChanged(object sender, EventArgs e)
        {
            InitComboTypes(true);
        }

        private void m_cmbTypeElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVisuAvecEditMode();
        }

        private void UpdateVisuAvecEditMode()
        {
            //m_chkAllowEditMode.Visible = m_cmbTypeElement.SelectedValue == typeof(DBNull); ;
        }

        private void m_panelEditionFullFormulaire_Load(object sender, EventArgs e)
        {

        }

        private void m_chkIsArray_CheckedChanged(object sender, EventArgs e)
        {
            Formulaire.ElementEditeIsArray = m_chkIsArray.Checked;
        }

        //----------------------------------------------------------------------------------------
        private void RefreshVisuSousRoles()
        {
            if (Formulaire.CodesRolesSecondaires.Length > 0)
            {
                m_lnkSousRoles.Text = I.T("Sub purposes|20586") + " (" + Formulaire.CodesRolesSecondaires.Length + ")";
            }
            else
                m_lnkSousRoles.Text = I.T("Sub purposes|20586");
        }

        //----------------------------------------------------------------------------------------
        private void m_lnkSousRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_menuAutresUtilisations.Items.Clear();
            foreach (CRoleChampCustom role in CRoleChampCustom.Roles)
            {
                if (Formulaire.HasRoleSecondaire(role.CodeRole) || m_gestionnaireModeEdition.ModeEdition)
                {
                    ToolStripMenuItem itemRole = new ToolStripMenuItem(role.Libelle);
                    itemRole.Tag = role.CodeRole;
                    itemRole.Checked = Formulaire.HasRoleSecondaire(role.CodeRole);
                    itemRole.Enabled = m_gestionnaireModeEdition.ModeEdition;
                    itemRole.Click += new EventHandler(itemRole_Click);
                    m_menuAutresUtilisations.Items.Add(itemRole);
                }
            }
            m_menuAutresUtilisations.Show(m_lnkSousRoles, new Point(0, m_lnkSousRoles.Height));
        }

        //----------------------------------------------------------------------------------------
        private void itemRole_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string strCode = item != null ? item.Tag as string : null;
            if (strCode != null)
            {
                if (!item.Checked)
                    Formulaire.AddRoleSecondaire(strCode);
                else
                    Formulaire.RemoveRoleSecondaire(strCode);
                RefreshVisuSousRoles();
            }
        }



	}



}

