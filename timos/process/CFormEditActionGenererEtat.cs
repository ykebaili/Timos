using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.win32.process;
using timos.process;
using sc2i.win32.data;

using sc2i.documents;
using sc2i.win32.common;


namespace timos
{
	[AutoExec("Autoexec")]
	public class CFormEditActionGenererEtat : sc2i.win32.process.CFormEditActionFonction
	{
		private Hashtable m_tableIdVariableToFormule = new Hashtable();
		private IVariableDynamique m_variableEnCoursEdition = null;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleEnCours = null;

		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Label m_lblNomVariable;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleVariable;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeVariables;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeCategories;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private sc2i.win32.common.C2iComboBox m_cmbFormat;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleCle;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleDescriptif;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleLibelle;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.CComboboxAutoFilled m_comboModeleEtat;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.CheckBox m_chkImprimer;
		private System.Windows.Forms.CheckBox m_chkStocker;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionGenererEtat()
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
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_cmbFormat = new sc2i.win32.common.C2iComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtFormuleCle = new sc2i.win32.expression.CControleEditeFormule();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtFormuleDescriptif = new sc2i.win32.expression.CControleEditeFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_lblNomVariable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtFormuleVariable = new sc2i.win32.expression.CControleEditeFormule();
            this.m_wndListeVariables = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_chkStocker = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_wndListeCategories = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_comboModeleEtat = new sc2i.win32.common.CComboboxAutoFilled();
            this.label8 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.m_chkImprimer = new System.Windows.Forms.CheckBox();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblStockerResIn
            // 
            this.m_exStyle.SetStyleBackColor(this.m_lblStockerResIn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblStockerResIn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStockerResIn.Text = "Store the result in|30239";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 80);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 2;
            this.m_tabControl.SelectedTab = this.tabPage3;
            this.m_tabControl.Size = new System.Drawing.Size(456, 312);
            this.m_exStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 7;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_cmbFormat);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.m_txtFormuleCle);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.m_txtFormuleDescriptif);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.m_txtFormuleLibelle);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(440, 271);
            this.m_exStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Document properties|1039";
            this.tabPage3.Visible = false;
            // 
            // m_cmbFormat
            // 
            this.m_cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormat.IsLink = false;
            this.m_cmbFormat.Location = new System.Drawing.Point(80, 8);
            this.m_cmbFormat.LockEdition = false;
            this.m_cmbFormat.Name = "m_cmbFormat";
            this.m_cmbFormat.Size = new System.Drawing.Size(176, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbFormat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbFormat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormat.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 8;
            this.label6.Text = "Format|30246";
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
            this.m_txtFormuleCle.Size = new System.Drawing.Size(424, 40);
            this.m_exStyle.SetStyleBackColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCle.TabIndex = 7;
            this.m_txtFormuleCle.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.m_exStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_txtFormuleDescriptif.Size = new System.Drawing.Size(424, 64);
            this.m_exStyle.SetStyleBackColor(this.m_txtFormuleDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtFormuleDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleDescriptif.TabIndex = 3;
            this.m_txtFormuleDescriptif.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 16);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(8, 48);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(424, 64);
            this.m_exStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 1;
            this.m_txtFormuleLibelle.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Document label|1041";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lblNomVariable);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.m_txtFormuleVariable);
            this.tabPage1.Controls.Add(this.m_wndListeVariables);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(440, 271);
            this.m_exStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Filter|47";
            // 
            // m_lblNomVariable
            // 
            this.m_lblNomVariable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomVariable.Location = new System.Drawing.Point(208, 8);
            this.m_lblNomVariable.Name = "m_lblNomVariable";
            this.m_lblNomVariable.Size = new System.Drawing.Size(232, 16);
            this.m_exStyle.SetStyleBackColor(this.m_lblNomVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblNomVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomVariable.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Variable value|30242";
            // 
            // m_txtFormuleVariable
            // 
            this.m_txtFormuleVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleVariable.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleVariable.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleVariable.Formule = null;
            this.m_txtFormuleVariable.Location = new System.Drawing.Point(208, 40);
            this.m_txtFormuleVariable.LockEdition = false;
            this.m_txtFormuleVariable.Name = "m_txtFormuleVariable";
            this.m_txtFormuleVariable.Size = new System.Drawing.Size(224, 224);
            this.m_exStyle.SetStyleBackColor(this.m_txtFormuleVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtFormuleVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleVariable.TabIndex = 1;
            this.m_txtFormuleVariable.Enter += new System.EventHandler(this.OnEnterTextBoxFormule);
            // 
            // m_wndListeVariables
            // 
            this.m_wndListeVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_wndListeVariables.EnableCustomisation = true;
            this.m_wndListeVariables.FullRowSelect = true;
            this.m_wndListeVariables.Location = new System.Drawing.Point(8, 8);
            this.m_wndListeVariables.MultiSelect = false;
            this.m_wndListeVariables.Name = "m_wndListeVariables";
            this.m_wndListeVariables.Size = new System.Drawing.Size(192, 256);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeVariables.TabIndex = 0;
            this.m_wndListeVariables.UseCompatibleStateImageBehavior = false;
            this.m_wndListeVariables.View = System.Windows.Forms.View.Details;
            this.m_wndListeVariables.SelectedIndexChanged += new System.EventHandler(this.m_wndListeVariables_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name |164";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 176;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_chkStocker);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.m_wndListeCategories);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(440, 271);
            this.m_exStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "EDM category|176";
            this.tabPage2.Visible = false;
            // 
            // m_chkStocker
            // 
            this.m_chkStocker.Location = new System.Drawing.Point(8, 8);
            this.m_chkStocker.Name = "m_chkStocker";
            this.m_chkStocker.Size = new System.Drawing.Size(296, 16);
            this.m_exStyle.SetStyleBackColor(this.m_chkStocker, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_chkStocker, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkStocker.TabIndex = 9;
            this.m_chkStocker.Text = "Store EDM document|30243";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 16);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "The document will be stored in the following categories|30244";
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
            this.m_wndListeCategories.Location = new System.Drawing.Point(8, 40);
            this.m_wndListeCategories.MultiSelect = false;
            this.m_wndListeCategories.Name = "m_wndListeCategories";
            this.m_wndListeCategories.Size = new System.Drawing.Size(296, 224);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeCategories.TabIndex = 0;
            this.m_wndListeCategories.UseCompatibleStateImageBehavior = false;
            this.m_wndListeCategories.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Category|30245";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 279;
            // 
            // m_comboModeleEtat
            // 
            this.m_comboModeleEtat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_comboModeleEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboModeleEtat.IsLink = false;
            this.m_comboModeleEtat.ListDonnees = null;
            this.m_comboModeleEtat.Location = new System.Drawing.Point(120, 40);
            this.m_comboModeleEtat.LockEdition = false;
            this.m_comboModeleEtat.Name = "m_comboModeleEtat";
            this.m_comboModeleEtat.NullAutorise = true;
            this.m_comboModeleEtat.ProprieteAffichee = "Libelle";
            this.m_comboModeleEtat.Size = new System.Drawing.Size(336, 21);
            this.m_exStyle.SetStyleBackColor(this.m_comboModeleEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_comboModeleEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_comboModeleEtat.TabIndex = 6;
            this.m_comboModeleEtat.TextNull = I.T("(None)|30291");
            this.m_comboModeleEtat.Tri = true;
            this.m_comboModeleEtat.SelectedIndexChanged += new System.EventHandler(this.m_comboModeleEtat_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.m_exStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 5;
            this.label8.Text = "Report model|30228";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(464, 32);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(176, 357);
            this.m_exStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // m_chkImprimer
            // 
            this.m_chkImprimer.Location = new System.Drawing.Point(8, 64);
            this.m_chkImprimer.Name = "m_chkImprimer";
            this.m_chkImprimer.Size = new System.Drawing.Size(296, 16);
            this.m_exStyle.SetStyleBackColor(this.m_chkImprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_chkImprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkImprimer.TabIndex = 8;
            this.m_chkImprimer.Text = "Server printing|30241";
            // 
            // CFormEditActionGenererEtat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(640, 437);
            this.Controls.Add(this.m_chkImprimer);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_comboModeleEtat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_wndAideFormule);
            this.Name = "CFormEditActionGenererEtat";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Function|30240";
            this.Load += new System.EventHandler(this.CFormEditActionGenererEtatCode_Load);
            this.Controls.SetChildIndex(this.m_wndAideFormule, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_comboModeleEtat, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_chkImprimer, 0);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionGenererEtat), typeof(CFormEditActionGenererEtat));
		}


		public CActionGenererEtat ActionGenererEtat
		{
			get
			{
				return (CActionGenererEtat)ObjetEdite;
			}
		}

		
	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			OnChangeVariable();

			if ( !(m_comboModeleEtat.SelectedValue is C2iRapportCrystal ) )
			{
				result.EmpileErreur(I.T("Select a report|30248"));
			}
			
			C2iRapportCrystal rapport = (C2iRapportCrystal)m_comboModeleEtat.SelectedValue;
			ActionGenererEtat.IdEtatCrystal = rapport.Id;

			ActionGenererEtat.ClearExpressionsVariables();
			foreach (string strIdVariable in m_tableIdVariableToFormule.Keys )
			{
                C2iExpression exp = (C2iExpression)m_tableIdVariableToFormule[strIdVariable];
				if ( exp != null )
                    ActionGenererEtat.SetExpressionForVariableFiltre(strIdVariable, exp);
			}

			ActionGenererEtat.ListeIdsCategoriesStockage.Clear();
			foreach ( ListViewItem item in m_wndListeCategories.CheckedItems )
			{
				ActionGenererEtat.ListeIdsCategoriesStockage.Add ( 
					((CCategorieGED)item.Tag).Id );
			}

			CResultAErreur resultExp = GetFormule ( m_txtFormuleCle );
			if ( !resultExp )
			{
				resultExp.EmpileErreur(I.T("Error in key formula|30249"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionGenererEtat.ExpressionCle = (C2iExpression)resultExp.Data;

			resultExp = GetFormule ( m_txtFormuleLibelle );
			if ( !resultExp )
			{
				resultExp.EmpileErreur(I.T("Error in label formula|30250"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionGenererEtat.ExpressionLibelle = (C2iExpression)resultExp.Data;

			resultExp = GetFormule ( m_txtFormuleDescriptif );
			if ( !resultExp )
			{
                resultExp.EmpileErreur(I.T("Error in description formula|30251"));
				result.Erreur += resultExp.Erreur;
				result.Result = false;
			}
			else
				ActionGenererEtat.ExpressionDescriptif = (C2iExpression)resultExp.Data;
			
			ActionGenererEtat.FormatExport = (TypeFormatExportCrystal)m_cmbFormat.SelectedValue;

			ActionGenererEtat.StockerDansLaGed = m_chkStocker.Checked;
			ActionGenererEtat.ImprimerSurClient = m_chkImprimer.Checked;
				
			
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
			m_txtFormuleVariable.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CCategorieGED) );
			m_wndListeCategories.Remplir(liste, false);
			foreach( ListViewItem item in m_wndListeCategories.Items )
			{
				CCategorieGED cat = (CCategorieGED)item.Tag;
				if ( ActionGenererEtat.ListeIdsCategoriesStockage.Contains(cat.Id) )
					item.Checked = true;
				else
					item.Checked = false;
			}

			liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(sc2i.documents.C2iRapportCrystal) );
			m_comboModeleEtat.ListDonnees = liste;
			C2iRapportCrystal rapport = new C2iRapportCrystal ( CSc2iWin32DataClient.ContexteCourant );
			m_tableIdVariableToFormule.Clear();
			if ( rapport.ReadIfExists ( ActionGenererEtat.IdEtatCrystal ) )
			{
				m_comboModeleEtat.SelectedValue = rapport;
				CMultiStructureExport multiStructure = rapport.MultiStructure;
				if ( multiStructure != null )
				{
					foreach ( IVariableDynamique variable in multiStructure.ListeVariables )
						m_tableIdVariableToFormule[variable.IdVariable] = ActionGenererEtat.GetExpressionForVariableFiltre(variable.IdVariable);
				}
			}
			else
				m_comboModeleEtat.SelectedValue = null;

			UpdateListeVariables();

			m_txtFormuleCle.Text = ActionGenererEtat.ExpressionCle.GetString();
			m_txtFormuleDescriptif.Text = ActionGenererEtat.ExpressionDescriptif.GetString();
			m_txtFormuleLibelle.Text = ActionGenererEtat.ExpressionLibelle.GetString();

			m_cmbFormat.DisplayMember = "Libelle";
			m_cmbFormat.ValueMember = "Valeur";
			m_cmbFormat.DataSource = CUtilSurEnum.GetCouplesFromEnum ( typeof(TypeFormatExportCrystal));
			
			m_cmbFormat.SelectedValue = (int)ActionGenererEtat.FormatExport;

			m_chkStocker.Checked = ActionGenererEtat.StockerDansLaGed;
			m_chkImprimer.Checked = ActionGenererEtat.ImprimerSurClient;


		}

		/// //////////////////////////////////////////
		private bool m_bListeVariablesRemplie = false;
		private void UpdateListeVariables()
		{
			m_bListeVariablesRemplie = false;
			m_variableEnCoursEdition = null;
			m_txtFormuleVariable.Visible = false;
			if ( !(m_comboModeleEtat.SelectedValue is C2iRapportCrystal ))
			{
				m_wndListeVariables.Enabled = false;
				m_txtFormuleVariable.Visible = false;
				return;
			}
			m_wndListeVariables.Enabled = true;
			m_txtFormuleVariable.Visible = true;

			C2iRapportCrystal etat = (C2iRapportCrystal)m_comboModeleEtat.SelectedValue;
			CMultiStructureExport multiStructure = etat.MultiStructure;
			if ( multiStructure == null)
			{
				m_wndListeVariables.Enabled = false;
				m_txtFormuleVariable.Visible = false;
				return;
			}
			IElementAVariablesDynamiques element = multiStructure;
			ArrayList lst = new ArrayList(element.ListeVariables);
			for ( int nVar = lst.Count-1; nVar >= 0; nVar-- )
			{
				if ( !((IVariableDynamique)lst[nVar]).IsChoixUtilisateur() )
					lst.RemoveAt ( nVar );
			}
			m_wndListeVariables.Remplir ( lst, false );
			m_bListeVariablesRemplie = true;
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
		private void OnChangeVariable()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_variableEnCoursEdition != null )
			{
				if ( m_txtFormuleVariable.Text.Trim() != "" )
				{
					result = GetFormule ( m_txtFormuleVariable );
					if ( !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
						return ;
					}
					m_tableIdVariableToFormule[m_variableEnCoursEdition.IdVariable] = result.Data;
				}
				else
					m_tableIdVariableToFormule[m_variableEnCoursEdition.IdVariable] = null;

			}
			if ( m_wndListeVariables.SelectedItems.Count != 1 )
			{
				m_variableEnCoursEdition = null;
				m_txtFormuleVariable.Visible = true;
				return ;
			}
			
			m_variableEnCoursEdition = (IVariableDynamique)m_wndListeVariables.SelectedItems[0].Tag;
			m_lblNomVariable.Text = m_variableEnCoursEdition.Nom;
			C2iExpression expression = (C2iExpression)m_tableIdVariableToFormule[m_variableEnCoursEdition.IdVariable];
			m_txtFormuleVariable.Text = expression==null?"":expression.GetString();
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
		private void CFormEditActionGenererEtatCode_Load(object sender, System.EventArgs e)
		{
			OnEnterTextBoxFormule ( m_txtFormuleVariable, new EventArgs() );
		}

		/// //////////////////////////////////////////
		private void m_wndListeVariables_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			if ( m_bListeVariablesRemplie )
				OnChangeVariable();
		}

		/// //////////////////////////////////////////
		private void m_comboModeleEtat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateListeVariables();
		}

		

		




	}
}

