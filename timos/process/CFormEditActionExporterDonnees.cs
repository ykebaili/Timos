using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.win32.process;
using sc2i.win32.data;
using sc2i.workflow;
using sc2i.documents;


namespace timos
{
	[AutoExec("Autoexec")]
	public class CFormEditionActionExporterDonnees : sc2i.win32.process.CFormEditActionFonction
	{
		private Hashtable m_tableIdVariableToFormule = new Hashtable();
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleEnCours = null;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeCategories;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Label label3;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleCle;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleDescriptif;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleLibelle;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private sc2i.win32.data.dynamic.CPanelEditMultiStructure m_panelStructure;
		private sc2i.win32.data.dynamic.CPanelEditFormatExport m_panelExporteur;
        private sc2i.win32.common.CExtStyle m_ExtStyle;
        private SplitContainer splitContainer1;
        private Panel m_panelFormuleStructure;
        private Panel m_panelSelectStructure;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleStructure;
        private Label label1;
        private RadioButton m_radStructureParFormule;
        private RadioButton m_radStructurePropre;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionActionExporterDonnees()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

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

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.components = new System.ComponentModel.Container();
            sc2i.data.dynamic.CExporteurDatasetXML cExporteurDatasetXML2 = new sc2i.data.dynamic.CExporteurDatasetXML();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_wndListeCategories = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormuleStructure = new System.Windows.Forms.Panel();
            this.m_txtFormuleStructure = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelStructure = new sc2i.win32.data.dynamic.CPanelEditMultiStructure();
            this.m_panelSelectStructure = new System.Windows.Forms.Panel();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtFormuleCle = new sc2i.win32.expression.CControleEditeFormule();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtFormuleDescriptif = new sc2i.win32.expression.CControleEditeFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelExporteur = new sc2i.win32.data.dynamic.CPanelEditFormatExport();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_radStructureParFormule = new System.Windows.Forms.RadioButton();
            this.m_radStructurePropre = new System.Windows.Forms.RadioButton();
            this.tabPage1.SuspendLayout();
            this.m_panelFormuleStructure.SuspendLayout();
            this.m_panelSelectStructure.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblStockerResIn
            // 
            this.m_ExtStyle.SetStyleBackColor(this.m_lblStockerResIn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblStockerResIn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStockerResIn.Text = "Store the result in|30239";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name|164";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 176;
            // 
            // m_wndListeCategories
            // 
            this.m_wndListeCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeCategories.CheckBoxes = true;
            this.m_wndListeCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeCategories.EnableCustomisation = true;
            this.m_wndListeCategories.FullRowSelect = true;
            this.m_wndListeCategories.Location = new System.Drawing.Point(8, 24);
            this.m_wndListeCategories.MultiSelect = false;
            this.m_wndListeCategories.Name = "m_wndListeCategories";
            this.m_wndListeCategories.Size = new System.Drawing.Size(296, 347);
            this.m_ExtStyle.SetStyleBackColor(this.m_wndListeCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndListeCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeCategories.TabIndex = 0;
            this.m_wndListeCategories.UseCompatibleStateImageBehavior = false;
            this.m_wndListeCategories.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Category|852";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 279;
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(195, 403);
            this.m_ExtStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.tabPage1.Controls.Add(this.m_panelStructure);
            this.tabPage1.Controls.Add(this.m_panelFormuleStructure);
            this.tabPage1.Controls.Add(this.m_panelSelectStructure);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(607, 378);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Structure|943";
            // 
            // m_panelFormuleStructure
            // 
            this.m_panelFormuleStructure.Controls.Add(this.m_txtFormuleStructure);
            this.m_panelFormuleStructure.Controls.Add(this.label1);
            this.m_panelFormuleStructure.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormuleStructure.Location = new System.Drawing.Point(0, 32);
            this.m_panelFormuleStructure.Name = "m_panelFormuleStructure";
            this.m_panelFormuleStructure.Size = new System.Drawing.Size(607, 129);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelFormuleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelFormuleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormuleStructure.TabIndex = 2;
            // 
            // m_txtFormuleStructure
            // 
            this.m_txtFormuleStructure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleStructure.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleStructure.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleStructure.Formule = null;
            this.m_txtFormuleStructure.Location = new System.Drawing.Point(8, 22);
            this.m_txtFormuleStructure.LockEdition = false;
            this.m_txtFormuleStructure.Name = "m_txtFormuleStructure";
            this.m_txtFormuleStructure.Size = new System.Drawing.Size(591, 88);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleStructure.TabIndex = 3;
            this.m_txtFormuleStructure.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document label|1041";
            // 
            // m_panelStructure
            // 
            this.m_panelStructure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelStructure.FiltreDynamique = null;
            this.m_panelStructure.ForeColor = System.Drawing.Color.Black;
            this.m_panelStructure.Location = new System.Drawing.Point(0, 161);
            this.m_panelStructure.LockEdition = false;
            this.m_panelStructure.Name = "m_panelStructure";
            this.m_panelStructure.Size = new System.Drawing.Size(607, 217);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelStructure.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelStructure.TabIndex = 0;
            // 
            // m_panelSelectStructure
            // 
            this.m_panelSelectStructure.Controls.Add(this.m_radStructurePropre);
            this.m_panelSelectStructure.Controls.Add(this.m_radStructureParFormule);
            this.m_panelSelectStructure.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelSelectStructure.Location = new System.Drawing.Point(0, 0);
            this.m_panelSelectStructure.Name = "m_panelSelectStructure";
            this.m_panelSelectStructure.Size = new System.Drawing.Size(607, 32);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelSelectStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelSelectStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectStructure.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.m_wndListeCategories);
            this.tabPage2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(607, 378);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "EDM category|176";
            this.tabPage2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 13);
            this.m_ExtStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "The document will be associated to following categories|1040";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.m_txtFormuleCle);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.m_txtFormuleDescriptif);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.m_txtFormuleLibelle);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tabPage3.ForeColor = System.Drawing.Color.Black;
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(607, 378);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Document properties|1039";
            this.tabPage3.Visible = false;
            // 
            // m_txtFormuleCle
            // 
            this.m_txtFormuleCle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCle.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleCle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleCle.Formule = null;
            this.m_txtFormuleCle.Location = new System.Drawing.Point(8, 224);
            this.m_txtFormuleCle.LockEdition = false;
            this.m_txtFormuleCle.Name = "m_txtFormuleCle";
            this.m_txtFormuleCle.Size = new System.Drawing.Size(591, 147);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCle.TabIndex = 7;
            this.m_txtFormuleCle.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 6;
            this.label7.Text = "Key (unique ID)|1043";
            // 
            // m_txtFormuleDescriptif
            // 
            this.m_txtFormuleDescriptif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleDescriptif.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleDescriptif.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleDescriptif.Formule = null;
            this.m_txtFormuleDescriptif.Location = new System.Drawing.Point(8, 136);
            this.m_txtFormuleDescriptif.LockEdition = false;
            this.m_txtFormuleDescriptif.Name = "m_txtFormuleDescriptif";
            this.m_txtFormuleDescriptif.Size = new System.Drawing.Size(591, 64);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleDescriptif.TabIndex = 3;
            this.m_txtFormuleDescriptif.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.m_ExtStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Document description|1042";
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleLibelle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(591, 88);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 1;
            this.m_txtFormuleLibelle.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Document label|1041";
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(607, 403);
            this.m_ExtStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 7;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage4,
            this.tabPage2,
            this.tabPage3});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_panelExporteur);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(607, 378);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Export options|1038";
            // 
            // m_panelExporteur
            // 
            cExporteurDatasetXML2.ExporteStructureOnly = false;
            this.m_panelExporteur.Exporteur = cExporteurDatasetXML2;
            this.m_panelExporteur.Location = new System.Drawing.Point(0, 0);
            this.m_panelExporteur.Name = "m_panelExporteur";
            this.m_panelExporteur.SansFichier = true;
            this.m_panelExporteur.Size = new System.Drawing.Size(608, 336);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelExporteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelExporteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelExporteur.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_tabControl);
            this.m_ExtStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_wndAideFormule);
            this.m_ExtStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(814, 407);
            this.splitContainer1.SplitterDistance = 611;
            this.m_ExtStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 8;
            // 
            // m_radStructureParFormule
            // 
            this.m_radStructureParFormule.Location = new System.Drawing.Point(55, 9);
            this.m_radStructureParFormule.Name = "m_radStructureParFormule";
            this.m_radStructureParFormule.Size = new System.Drawing.Size(241, 17);
            this.m_ExtStyle.SetStyleBackColor(this.m_radStructureParFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_radStructureParFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radStructureParFormule.TabIndex = 0;
            this.m_radStructureParFormule.TabStop = true;
            this.m_radStructureParFormule.Text = "Select Structure Model by formula|10049";
            this.m_radStructureParFormule.UseVisualStyleBackColor = true;
            this.m_radStructureParFormule.CheckedChanged += new System.EventHandler(this.m_radStructureParFormule_CheckedChanged);
            // 
            // m_radStructurePropre
            // 
            this.m_radStructurePropre.Location = new System.Drawing.Point(315, 9);
            this.m_radStructurePropre.Name = "m_radStructurePropre";
            this.m_radStructurePropre.Size = new System.Drawing.Size(243, 17);
            this.m_ExtStyle.SetStyleBackColor(this.m_radStructurePropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_radStructurePropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radStructurePropre.TabIndex = 0;
            this.m_radStructurePropre.TabStop = true;
            this.m_radStructurePropre.Text = "Create new Export Structure|10050";
            this.m_radStructurePropre.UseVisualStyleBackColor = true;
            // 
            // CFormEditionActionExporterDonnees
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(814, 487);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CFormEditionActionExporterDonnees";
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Export data|1037";
            this.Load += new System.EventHandler(this.CFormEditionActionExporterDonneesCode_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.tabPage1.ResumeLayout(false);
            this.m_panelFormuleStructure.ResumeLayout(false);
            this.m_panelSelectStructure.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionExporterDonnees), typeof(CFormEditionActionExporterDonnees));
		}


		public CActionExporterDonnees ActionExporterDonnees
		{
			get
			{
				return (CActionExporterDonnees)ObjetEdite;
			}
		}

		
	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			ActionExporterDonnees.ListeIdsCategoriesStockage.Clear();
			foreach ( ListViewItem item in m_wndListeCategories.CheckedItems )
			{
				ActionExporterDonnees.ListeIdsCategoriesStockage.Add ( 
					((CCategorieGED)item.Tag).Id );
			}

			CResultAErreur resultExp = GetFormule ( m_txtFormuleCle );
			if ( !resultExp )
			{
				resultExp.EmpileErreur(I.T( "Error in key formula|1044"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionExporterDonnees.ExpressionCle = (C2iExpression)resultExp.Data;

			resultExp = GetFormule ( m_txtFormuleLibelle );
			if ( !resultExp )
			{
				resultExp.EmpileErreur(I.T( "Error in label formula|1045"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionExporterDonnees.ExpressionLibelle = (C2iExpression)resultExp.Data;

			resultExp = GetFormule ( m_txtFormuleDescriptif );
			if ( !resultExp )
			{
				resultExp.EmpileErreur(I.T( "Error in description formula|1046"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionExporterDonnees.ExpressionDescriptif = (C2iExpression)resultExp.Data;

			ActionExporterDonnees.Exporteur = m_panelExporteur.Exporteur;

            if (m_radStructureParFormule.Checked)
            {
                ActionExporterDonnees.UtiliserFormule = true;
                resultExp = GetFormule(m_txtFormuleStructure);
                if (!resultExp)
                {
                    resultExp.EmpileErreur(I.T("Error in structure formula|10051"));
                    result.Erreur += resultExp.Erreur;
                    result.Result = false;
                }
                else 
                {
                    C2iExpression exp = resultExp.Data as C2iExpression;
                    if (exp != null && exp.TypeDonnee.TypeDotNetNatif != typeof(C2iStructureExportInDB))
                    {
                        resultExp.EmpileErreur(I.T("The Structure Formula doesn't return an 'Export Structure' object|10052"));
                        result.Erreur += resultExp.Erreur;
                        result.Result = false;
                    }
                    else
                        ActionExporterDonnees.ExpressionStructure = exp;
                }

            }
            else
            {
                ActionExporterDonnees.UtiliserFormule = false;
                ActionExporterDonnees.StructureExport = m_panelStructure.MultiStructure;
            }
            
			return result;
		}

		

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_wndAideFormule.FournisseurProprietes = ObjetEdite.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtFormuleCle.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleDescriptif.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormuleLibelle.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormuleStructure.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			
            CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CCategorieGED) );
			m_wndListeCategories.Remplir(liste, false);
			foreach( ListViewItem item in m_wndListeCategories.Items )
			{
				CCategorieGED cat = (CCategorieGED)item.Tag;
				if ( ActionExporterDonnees.ListeIdsCategoriesStockage.Contains(cat.Id) )
					item.Checked = true;
				else
					item.Checked = false;
			}

			liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(sc2i.documents.C2iRapportCrystal) );

			m_txtFormuleCle.Text = ActionExporterDonnees.ExpressionCle.GetString();
			m_txtFormuleDescriptif.Text = ActionExporterDonnees.ExpressionDescriptif.GetString();
			m_txtFormuleLibelle.Text = ActionExporterDonnees.ExpressionLibelle.GetString();

            m_radStructureParFormule.Checked = ActionExporterDonnees.UtiliserFormule;
            m_radStructurePropre.Checked = !ActionExporterDonnees.UtiliserFormule;

            if(ActionExporterDonnees.ExpressionStructure != null)
                m_txtFormuleStructure.Text = ActionExporterDonnees.ExpressionStructure.GetString();
            m_panelStructure.Init(ActionExporterDonnees.StructureExport);
			m_panelExporteur.Exporteur = ActionExporterDonnees.Exporteur;


            UpdateDispoControles();
		}

		
		/// //////////////////////////////////////////
		private CResultAErreur GetFormule ( sc2i.win32.expression.CControleEditeFormule textBox )
		{
			CResultAErreur result = CResultAErreur.True;
			CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression ( ObjetEdite.Process, typeof(CProcess));
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
			result = analyseur.AnalyseChaine ( textBox.Text );
			return result;
		}

		/// //////////////////////////////////////////
		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormuleEnCours != null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormuleEnCours, nPosCurseur, strCommande );
		}
	

		/// //////////////////////////////////////////
		private void OnEnterTextBoxFormule(object sender, System.EventArgs e)
		{
			if ( sender is sc2i.win32.expression.CControleEditeFormule )
			{
				if ( m_txtFormuleEnCours != null )
					m_txtFormuleEnCours.BackColor = Color.White;
				m_txtFormuleEnCours = (sc2i.win32.expression.CControleEditeFormule)sender;
				m_txtFormuleEnCours.BackColor = Color.LightGreen;
			}
			
		}

		/// //////////////////////////////////////////
		private void CFormEditionActionExporterDonneesCode_Load(object sender, System.EventArgs e)
		{
			OnEnterTextBoxFormule ( m_txtFormuleLibelle, new EventArgs() );
		}


        //--------------------------------------------------------------------------------
        private void UpdateDispoControles()
        {
            m_panelFormuleStructure.Visible = m_radStructureParFormule.Checked;
            m_panelStructure.Visible = !m_radStructureParFormule.Checked;
        }

        private void m_radStructureParFormule_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDispoControles();
        }

 
		

		




	}
}

