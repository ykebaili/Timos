using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.expression;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.data.dynamic;


namespace timos
{
	/// <summary>
	/// Description résumée de CPanelParametrageAgenda.
	/// </summary>
	public class CPanelParametrageAgenda : System.Windows.Forms.UserControl, IControlALockEdition
	{

		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;

		private CParametreEntreeAgenda m_parametre = null;
		private Type m_typeSource = null;
		private IFournisseurProprietesDynamiques m_fournisseurProprietes = null;

		//Relation->Controle
		private Hashtable m_tableControlesForLiens = new Hashtable();
		private int m_nYNextControleLien = 0;
		
		//NomChamp->controle
		private Hashtable m_tableControlesForChamps = new Hashtable();
		private int m_nYNextControleChamp = 0;


		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.expression.CControleEditeFormule m_txtDateHeureDebut;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.CheckBox m_chkSansHoraires;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox m_chkEtatAutomatique;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbEtat;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.expression.CControleEditeFormule m_txtCommentaires;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label6;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private sc2i.win32.common.C2iPanel m_panelLiens;
		private sc2i.win32.common.C2iPanel m_panelChamps;
		private sc2i.win32.expression.CControleEditeFormule m_txtDateHeureFin;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeEntree;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.expression.CControleEditeFormule m_txtCle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox m_chkRappel;
		private System.Windows.Forms.Panel m_panelMinutesRappel;
		private sc2i.win32.common.C2iTextBoxNumerique m_txtNbMinutesRappel;
		private System.Windows.Forms.Label label8;
        private CExtStyle m_ExtStyle;
		private System.ComponentModel.IContainer components;

		public CPanelParametrageAgenda()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbTypeEntree = new sc2i.win32.common.CComboboxAutoFilled();
            this.label6 = new System.Windows.Forms.Label();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtCle = new sc2i.win32.expression.CControleEditeFormule();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtCommentaires = new sc2i.win32.expression.CControleEditeFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelMinutesRappel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtNbMinutesRappel = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_chkRappel = new System.Windows.Forms.CheckBox();
            this.m_chkEtatAutomatique = new System.Windows.Forms.CheckBox();
            this.m_cmbEtat = new sc2i.win32.common.CComboboxAutoFilled();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_chkSansHoraires = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtDateHeureDebut = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtDateHeureFin = new sc2i.win32.expression.CControleEditeFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelLiens = new sc2i.win32.common.C2iPanel(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.common.C2iPanel(this.components);
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.panel1.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelMinutesRappel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.c2iPanelOmbre1);
            this.panel1.Controls.Add(this.c2iTabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 368);
            this.m_ExtStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbTypeEntree);
            this.c2iPanelOmbre1.Controls.Add(this.label6);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 8);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(528, 56);
            this.m_ExtStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 7;
            // 
            // m_cmbTypeEntree
            // 
            this.m_cmbTypeEntree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeEntree.BackColor = System.Drawing.Color.White;
            this.m_cmbTypeEntree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeEntree.IsLink = false;
            this.m_cmbTypeEntree.ListDonnees = null;
            this.m_cmbTypeEntree.Location = new System.Drawing.Point(104, 6);
            this.m_cmbTypeEntree.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeEntree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeEntree.Name = "m_cmbTypeEntree";
            this.m_cmbTypeEntree.NullAutorise = false;
            this.m_cmbTypeEntree.ProprieteAffichee = "Libelle";
            this.m_cmbTypeEntree.Size = new System.Drawing.Size(400, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_cmbTypeEntree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_cmbTypeEntree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeEntree.TabIndex = 4016;
            this.m_cmbTypeEntree.TextNull = I.T("(Empty)|30258");
            this.m_cmbTypeEntree.Tri = true;
            this.m_cmbTypeEntree.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeEntree_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 3;
            this.label6.Text = "Entry type|1060";
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 1;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(528, 296);
            this.m_ExtStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 6;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage2,
            this.tabPage1,
            this.tabPage3,
            this.tabPage4});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2.Controls.Add(this.m_txtCle);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.m_txtCommentaires);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.m_txtFormuleLibelle);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(512, 255);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Label and comments|1061";
            this.tabPage2.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // m_txtCle
            // 
            this.m_txtCle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCle.BackColor = System.Drawing.Color.White;
            this.m_txtCle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtCle.Formule = null;
            this.m_txtCle.Location = new System.Drawing.Point(88, 192);
            this.m_txtCle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCle.Name = "m_txtCle";
            this.m_txtCle.Size = new System.Drawing.Size(416, 56);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCle.TabIndex = 5;
            this.m_txtCle.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(8, 192);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4;
            this.label7.Text = "Key|43";
            // 
            // m_txtCommentaires
            // 
            this.m_txtCommentaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCommentaires.BackColor = System.Drawing.Color.White;
            this.m_txtCommentaires.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtCommentaires.Formule = null;
            this.m_txtCommentaires.Location = new System.Drawing.Point(88, 56);
            this.m_txtCommentaires.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaires, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaires.Name = "m_txtCommentaires";
            this.m_txtCommentaires.Size = new System.Drawing.Size(416, 128);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommentaires.TabIndex = 3;
            this.m_txtCommentaires.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Comments|51";
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleLibelle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(88, 8);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(416, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 1;
            this.m_txtFormuleLibelle.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label|50";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelMinutesRappel);
            this.tabPage1.Controls.Add(this.m_chkRappel);
            this.tabPage1.Controls.Add(this.m_chkEtatAutomatique);
            this.tabPage1.Controls.Add(this.m_cmbEtat);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.m_chkSansHoraires);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.m_txtDateHeureDebut);
            this.tabPage1.Controls.Add(this.m_txtDateHeureFin);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(512, 255);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Date and time|1062";
            // 
            // m_panelMinutesRappel
            // 
            this.m_panelMinutesRappel.Controls.Add(this.label8);
            this.m_panelMinutesRappel.Controls.Add(this.m_txtNbMinutesRappel);
            this.m_panelMinutesRappel.Location = new System.Drawing.Point(208, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMinutesRappel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMinutesRappel.Name = "m_panelMinutesRappel";
            this.m_panelMinutesRappel.Size = new System.Drawing.Size(152, 24);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelMinutesRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelMinutesRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMinutesRappel.TabIndex = 4018;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(56, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 1;
            this.label8.Text = "Minutes|876";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtNbMinutesRappel
            // 
            this.m_txtNbMinutesRappel.Arrondi = 0;
            this.m_txtNbMinutesRappel.DecimalAutorise = false;
            this.m_txtNbMinutesRappel.DoubleValue = 21;
            this.m_txtNbMinutesRappel.IntValue = 21;
            this.m_txtNbMinutesRappel.Location = new System.Drawing.Point(0, 0);
            this.m_txtNbMinutesRappel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNbMinutesRappel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNbMinutesRappel.Name = "m_txtNbMinutesRappel";
            this.m_txtNbMinutesRappel.NullAutorise = false;
            this.m_txtNbMinutesRappel.Size = new System.Drawing.Size(56, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtNbMinutesRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtNbMinutesRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNbMinutesRappel.TabIndex = 0;
            this.m_txtNbMinutesRappel.Text = "21";
            this.m_txtNbMinutesRappel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_chkRappel
            // 
            this.m_chkRappel.Location = new System.Drawing.Point(128, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkRappel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkRappel.Name = "m_chkRappel";
            this.m_chkRappel.Size = new System.Drawing.Size(74, 24);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkRappel.TabIndex = 4017;
            this.m_chkRappel.Text = "Remind me|858";
            this.m_chkRappel.CheckedChanged += new System.EventHandler(this.m_chkRappel_CheckedChanged);
            // 
            // m_chkEtatAutomatique
            // 
            this.m_chkEtatAutomatique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkEtatAutomatique.Location = new System.Drawing.Point(128, 152);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEtatAutomatique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkEtatAutomatique.Name = "m_chkEtatAutomatique";
            this.m_chkEtatAutomatique.Size = new System.Drawing.Size(232, 18);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkEtatAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkEtatAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkEtatAutomatique.TabIndex = 4016;
            this.m_chkEtatAutomatique.Text = "Automatic state management|964";
            // 
            // m_cmbEtat
            // 
            this.m_cmbEtat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbEtat.BackColor = System.Drawing.Color.White;
            this.m_cmbEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtat.IsLink = false;
            this.m_cmbEtat.ListDonnees = null;
            this.m_cmbEtat.Location = new System.Drawing.Point(128, 128);
            this.m_cmbEtat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEtat, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbEtat.Name = "m_cmbEtat";
            this.m_cmbEtat.NullAutorise = false;
            this.m_cmbEtat.ProprieteAffichee = "Libelle";
            this.m_cmbEtat.Size = new System.Drawing.Size(184, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_cmbEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_cmbEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEtat.TabIndex = 4015;
            this.m_cmbEtat.TextNull = I.T("(empty)|30258");
            this.m_cmbEtat.Tri = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.m_ExtStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 8;
            this.label4.Text = "Initial state|1067";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(16, 120);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 1);
            this.m_ExtStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // m_chkSansHoraires
            // 
            this.m_chkSansHoraires.Location = new System.Drawing.Point(128, 94);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSansHoraires, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSansHoraires.Name = "m_chkSansHoraires";
            this.m_chkSansHoraires.Size = new System.Drawing.Size(96, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkSansHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkSansHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSansHoraires.TabIndex = 6;
            this.m_chkSansHoraires.Text = "Without time|857";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start date/time|1065";
            // 
            // m_txtDateHeureDebut
            // 
            this.m_txtDateHeureDebut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDateHeureDebut.BackColor = System.Drawing.Color.White;
            this.m_txtDateHeureDebut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtDateHeureDebut.Formule = null;
            this.m_txtDateHeureDebut.Location = new System.Drawing.Point(128, 8);
            this.m_txtDateHeureDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateHeureDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDateHeureDebut.Name = "m_txtDateHeureDebut";
            this.m_txtDateHeureDebut.Size = new System.Drawing.Size(376, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtDateHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtDateHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateHeureDebut.TabIndex = 3;
            this.m_txtDateHeureDebut.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // m_txtDateHeureFin
            // 
            this.m_txtDateHeureFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDateHeureFin.BackColor = System.Drawing.Color.White;
            this.m_txtDateHeureFin.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtDateHeureFin.Formule = null;
            this.m_txtDateHeureFin.Location = new System.Drawing.Point(128, 48);
            this.m_txtDateHeureFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateHeureFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDateHeureFin.Name = "m_txtDateHeureFin";
            this.m_txtDateHeureFin.Size = new System.Drawing.Size(376, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtDateHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtDateHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateHeureFin.TabIndex = 5;
            this.m_txtDateHeureFin.Enter += new System.EventHandler(this.OnEnterZoneFormule);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.m_ExtStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "End date/time|1066";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_panelLiens);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(512, 255);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Linked elements|1063";
            // 
            // m_panelLiens
            // 
            this.m_panelLiens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLiens.AutoScroll = true;
            this.m_panelLiens.Location = new System.Drawing.Point(0, 0);
            this.m_panelLiens.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLiens, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelLiens.Name = "m_panelLiens";
            this.m_panelLiens.Size = new System.Drawing.Size(512, 256);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLiens.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_panelChamps);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(512, 255);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Fields|1064";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Size = new System.Drawing.Size(512, 256);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 0;
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(544, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAideFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(184, 368);
            this.m_ExtStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4030;
			this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(541, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 368);
            this.m_ExtStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 4031;
            this.splitter1.TabStop = false;
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEdition = true;
            // 
            // CPanelParametrageAgenda
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_wndAideFormule);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelParametrageAgenda";
            this.Size = new System.Drawing.Size(728, 368);
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CPanelParametrageAgenda_Load);
            this.panel1.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.m_panelMinutesRappel.ResumeLayout(false);
            this.m_panelMinutesRappel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public CParametreEntreeAgenda Parametre
		{
			get
			{
				return m_parametre;
			}
		}


		/// <summary>
		/// Initialise le panel avec un paramètre
		/// </summary>
		/// <param name="parametre"></param>
		/// <param name="typeObjetSource">Indique l'objet sur lequel les expressions sont basées</param>
		/// <param name="fournisseurProprietes">Indique quelles sont les propriétés et méthodes disponibles</param>
		/// <returns></returns>
		public CResultAErreur InitChamps( 
			CParametreEntreeAgenda parametre, 
			Type typeObjetSource, 
			IFournisseurProprietesDynamiques fournisseurProprietes )
		{
			m_parametre = parametre;
			m_typeSource = typeObjetSource;
			m_fournisseurProprietes = fournisseurProprietes;

			m_wndAideFormule.ObjetInterroge = typeObjetSource;
			m_wndAideFormule.FournisseurProprietes = fournisseurProprietes;

			m_txtCle.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtCommentaires.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtDateHeureDebut.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtDateHeureFin.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleLibelle.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			CResultAErreur result = CResultAErreur.True;
			m_cmbTypeEntree.ListDonnees =  new CListeObjetsDonnees (
				sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant,
				typeof(CTypeEntreeAgenda) );
			if ( parametre.TypeEntree != null )
				m_cmbTypeEntree.SelectedValue = parametre.TypeEntree;
			if ( parametre.FormuleCommentaires != null )
				m_txtCommentaires.Text = parametre.FormuleCommentaires.GetString();
			else
				m_txtCommentaires.Text = "";
			if ( parametre.FormuleCle != null )
				m_txtCle.Text = parametre.FormuleCle.GetString();
			else
				m_txtCle.Text = "";

			if ( parametre.FormuleDateDebut != null )
				m_txtDateHeureDebut.Text = parametre.FormuleDateDebut.GetString();
			else
				m_txtDateHeureDebut.Text = "";

			if ( parametre.FormuleDateFin != null )
				m_txtDateHeureFin.Text = parametre.FormuleDateFin.GetString();
			else
				m_txtDateHeureFin.Text = "";

			if ( parametre.FormuleLibelle != null )
				m_txtFormuleLibelle.Text = parametre.FormuleLibelle.GetString();
			else
				m_txtFormuleLibelle.Text = "";

			m_chkEtatAutomatique.Checked = parametre.EtatAutomatique;
			m_chkSansHoraires.Checked = parametre.SansHoraire;

			m_cmbEtat.ListDonnees = CEtatEntreeAgenda.Etats;
			m_cmbEtat.ProprieteAffichee = "Libelle";
			m_cmbEtat.SelectedValue = parametre.EtatInitial;

			m_chkRappel.Checked = parametre.MinutesRappel >= 0;
			m_txtNbMinutesRappel.IntValue = Math.Max(parametre.MinutesRappel,0);


			InitControlesLiens();

			return result;
		}

		/// ////////////////////////////////////////////
		public CResultAErreur MAJChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_cmbTypeEntree.SelectedValue is CTypeEntreeAgenda )
				Parametre.TypeEntree = (CTypeEntreeAgenda)m_cmbTypeEntree.SelectedValue;
			else
			{
				result.EmpileErreur(I.T( "Select the entry type to create|1068"));
				return result;
			}

			CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression ( m_fournisseurProprietes, m_typeSource );
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression ( contexte );

			CResultAErreur resultExpression = CResultAErreur.True;

			resultExpression = AnalyseFormule ( 
				m_txtCommentaires.Text,
				I.T( "Error in comment formula|1069"),
				analyseur );
			if ( resultExpression )
				Parametre.FormuleCommentaires = (C2iExpression)resultExpression.Data;
			else
				result.Erreur.EmpileErreurs ( resultExpression.Erreur );

			if ( m_txtCle.Text.Trim() != "" )
			{
				resultExpression = AnalyseFormule ( 
					m_txtCle.Text,
					I.T( "Error in key formula|1070"),
					analyseur );
				if ( resultExpression )
					Parametre.FormuleCle= (C2iExpression)resultExpression.Data;
				else
					result.Erreur.EmpileErreurs ( resultExpression.Erreur );
			}
			else
				Parametre.FormuleCle = null;



			

			resultExpression = AnalyseFormule ( 
				m_txtDateHeureDebut.Text,
				I.T( "Error in start date/time formula|1071"),
				analyseur );
			if ( resultExpression )
				Parametre.FormuleDateDebut = (C2iExpression)resultExpression.Data;
			else
				result.Erreur.EmpileErreurs ( resultExpression.Erreur );
			
			resultExpression = AnalyseFormule ( 
				m_txtDateHeureFin.Text,
                I.T( "Error in end date/time formula|1072"),
                analyseur);
			if ( resultExpression )
				Parametre.FormuleDateFin = (C2iExpression)resultExpression.Data;
			else
				result.Erreur.EmpileErreurs ( resultExpression.Erreur );


			resultExpression = AnalyseFormule (
				m_txtFormuleLibelle.Text,
				I.T("Error in label formula|1073"),
				analyseur );
			if ( resultExpression )
				Parametre.FormuleLibelle = (C2iExpression)resultExpression.Data;
			else
				result.Erreur.EmpileErreurs ( resultExpression.Erreur );

			

			if ( result.Erreur.Erreurs.Length > 0)
				result.Result = false;

			if ( !result )
				return result;

			Parametre.EtatAutomatique = m_chkEtatAutomatique.Checked;
			Parametre.SansHoraire = m_chkSansHoraires.Checked;
			if ( m_cmbEtat.SelectedValue is CEtatEntreeAgenda )
				Parametre.EtatInitial = (CEtatEntreeAgenda)m_cmbEtat.SelectedValue;

			Parametre.NettoieFormulesLienEtChamps();
			foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation in Parametre.TypeEntree.RelationsTypeElementsAAgenda )
			{
				CPanelLibelleEtFormule panel = (CPanelLibelleEtFormule)m_tableControlesForLiens[relation];
				if ( panel == null || panel.TexteFormule.Trim() == "" )
					Parametre.SetFormuleForRelationTypeElement ( relation, null );
				else
				{
					result = analyseur.AnalyseChaine ( panel.TexteFormule );
					if ( !result )
					{
						result.EmpileErreur(I.T( "Error in formula @1|1074", relation.Libelle));
						return result;
					}
					Parametre.SetFormuleForRelationTypeElement ( relation, (C2iExpression)result.Data );
				}
			}

			foreach ( CChampCustom champ in Parametre.TypeEntree.TousLesChampsAssocies )
			{
				CPanelLibelleEtFormule panel = (CPanelLibelleEtFormule)m_tableControlesForChamps[champ.Nom];
				if ( panel  == null  || panel.TexteFormule.Trim() == "" )
					Parametre.SetFormuleForRelationChamp ( champ.Id, null );
				else
				{
					result = analyseur.AnalyseChaine ( panel.TexteFormule );
					if ( !result )
					{
						result.EmpileErreur(I.T( "Error un field @1 formula|1075", champ.Nom));
						return result;
					}
					Parametre.SetFormuleForRelationChamp ( champ.Id, (C2iExpression)result.Data );
				}
			}

			if ( !m_chkRappel.Checked )
				Parametre.MinutesRappel = -1;
			else
				Parametre.MinutesRappel = m_txtNbMinutesRappel.IntValue == null?0:m_txtNbMinutesRappel.IntValue.Value;
			return result;
		}

		/// ////////////////////////////////////////////
		public CResultAErreur AnalyseFormule ( string strTexte, string strMessageErreur, CAnalyseurSyntaxiqueExpression analyseur )
		{
			CResultAErreur result = CResultAErreur.True;
			if ( strTexte.Trim() == "" )
				return result;
			result = analyseur.AnalyseChaine ( strTexte );
			if ( !result )
			{
				result.EmpileErreur(strMessageErreur);
				return result;
			}
			return result;
		}



		/// ////////////////////////////////////////////
		private void InitControlesLiens()
		{
			m_nYNextControleChamp = 0;
			m_nYNextControleLien = 0;
			//Supprime tous les controles créés
			foreach ( CPanelLibelleEtFormule panel in m_tableControlesForChamps.Values )
			{
				if ( m_txtFormule == panel.ZoneFormule )
					m_txtFormuleLibelle.Focus();
				panel.Hide();
				m_panelChamps.Controls.Remove ( panel );
				panel.Dispose();
				
			}
			m_tableControlesForChamps.Clear();

			foreach ( CPanelLibelleEtFormule panel in m_tableControlesForLiens.Values )
			{
				if ( m_txtFormule == panel.ZoneFormule )
					m_txtFormuleLibelle.Focus();
				panel.Hide();
				panel.Parent.Controls.Remove ( panel );
				panel.Dispose();
			}
			m_tableControlesForLiens.Clear();

			if ( m_cmbTypeEntree.SelectedValue is CTypeEntreeAgenda )
			{
				CTypeEntreeAgenda typeEntree = (CTypeEntreeAgenda)m_cmbTypeEntree.SelectedValue;
				foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation in typeEntree.RelationsTypeElementsAAgenda )
				{
					CPanelLibelleEtFormule newPanel = CreatePanelLibelleFormule (
						m_panelLiens, ref m_nYNextControleLien,
						relation.Libelle, Parametre.GetFormuleForRelationTypeElement ( relation ) );
					m_tableControlesForLiens[relation] = newPanel;
				}

				foreach ( CChampCustom champ in typeEntree.TousLesChampsAssocies )
				{
					CPanelLibelleEtFormule newPanel = CreatePanelLibelleFormule (
						m_panelChamps, ref m_nYNextControleChamp,
						champ.Nom, Parametre.GetFormuleForRelationChamp ( champ.Id ) );
					m_tableControlesForChamps[champ.Nom] = newPanel;
				}
			}
		}

		/// ////////////////////////////////////////////
		private CPanelLibelleEtFormule CreatePanelLibelleFormule ( 
			Control parent, 
			ref int nY,
			string strLibelle, 
			C2iExpression formule )
		{
			CPanelLibelleEtFormule newPanel = new CPanelLibelleEtFormule();
			newPanel.Parent = parent;
			newPanel.Left = 0;
			newPanel.Top = nY;
			nY += newPanel.Height;
			newPanel.Width = parent.Width;
			newPanel.Anchor = AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right;
			newPanel.CreateControl();
			newPanel.Visible = true;
			newPanel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			newPanel.Init(strLibelle, formule, m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge.TypeAnalyse);
			newPanel.Enter += new EventHandler ( OnEnterZoneFormule );
			return newPanel;
		}

		/// ////////////////////////////////////////////
		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule!= null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );

		}

		/// ////////////////////////////////////////////
		private void m_cmbTypeEntree_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			InitControlesLiens();
		}

		private void OnEnterZoneFormule(object sender, System.EventArgs e)
		{
			if ( sender is CPanelLibelleEtFormule )
				sender = ((CPanelLibelleEtFormule)sender).ZoneFormule;
			if ( sender is sc2i.win32.expression.CControleEditeFormule )
			{
				sc2i.win32.expression.CControleEditeFormule txtBox = (sc2i.win32.expression.CControleEditeFormule)sender;
				m_txtFormule.BackColor = Color.White;
				m_txtFormule = txtBox;
				m_txtFormule.BackColor = Color.LightGreen;
			}
		}

		private void CPanelParametrageAgenda_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_txtFormule = m_txtFormuleLibelle;
			m_txtFormule.BackColor = Color.LightGreen;
		}

		private void m_chkRappel_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( m_chkRappel.Checked )
				m_panelMinutesRappel.Visible = true;
			else
				m_panelMinutesRappel.Visible = false;
		}

		/// ////////////////////////////////////////////
		#region Membres de IControlALockEdition

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition(this, new EventArgs() );
			}
		}
		public event System.EventHandler OnChangeLockEdition;

		#endregion
	}
}
