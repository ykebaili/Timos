using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.data;
using sc2i.win32.data;
using timos.data;
using timos.acteurs;

using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.workflow;

namespace timos
{
	/// <summary>
	/// Description résumée de CControleSaisieOperation.
	/// </summary>
	public class CControleSaisieOperation : System.Windows.Forms.UserControl, IControlALockEdition
	{
        private CTypeIntervention m_typeInterventionArbre = null;
		//Table des arbres de dictionnaire par type de données parente.
		//L'arbre princial a pour cle DBNull.value.
		private static Hashtable m_tableArbres = new Hashtable();

		private bool m_bAvecEntete = false;
        private bool m_bSaisieActeur;

		private static CRecepteurNotification m_recepteurNotificationTypeDonneeModifiee = null;
		private static CRecepteurNotification m_recepteurNotificationTypeDonneeAjoutee = null;

		private CElementAVariablesDynamiques m_elementAVariables = new CElementAVariablesDynamiques();

		private CControleSaisiesOperations m_controleParent = null;

		private int m_nIndex = 0;
		private int m_nNiveau = 0;
		private COperation m_operation = null;

		private CTypeOperation m_typeOperationParente = null;
		private CTypeOperation m_typeOperation = null;

        private Color? m_clrBackSave;


		#region Code généré par le Concepteur de composants

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.IntellisenseTextBox m_txtTypeOperation;
		private System.Windows.Forms.PictureBox m_btnPoubelle;
		private System.Windows.Forms.PictureBox m_btnInsert;
		private System.Windows.Forms.PictureBox m_btnAdd;
		private System.Windows.Forms.Panel m_panelPoubelle;
		private C2iPanel m_panelDataStd;
		private Label m_lblCode;
		private C2iPanel m_panelEntete;
		private C2iTextBox m_txtCommentaire;
		private C2iPanel m_panelContientLaDurée;
		private Label m_lblHeaderComment;
		private Label label6;
		private Label m_lblHeaderOperationType;
		private Label m_lblHeaderCode;
		private Label m_lblHeaderDuration;
		private Panel m_panelDuree;
		private Label label2;
		private sc2i.win32.data.dynamic.CPanelFormulaireSurElement m_panelFormulaire;
		private Panel m_panelGaucheFormulaire;
		private Panel m_panelMarge;
		private Panel m_panelDroiteFormulaire;
		private Panel m_panelEchangeMateriel;
		private LinkLabel m_lnkEchange;
		private Button m_btnLigneSuivante;
		private C2iPanel c2iPanel1;
		private PictureBox m_imagePasOk;
		private PictureBox m_imageOk;
		private CWndSaisieHeure m_txtDuree;
        private Panel m_panelLieEquipement;
        private C2iTextBoxSelectionne m_txtSelectEquipementLie;
        private Label m_lblEquipement;
		private C2iPanel m_panelContientDateHeure;
        private Panel m_panelDate;
		private Label m_lblHeaderStartDate;
        private C2iDateTimePicker m_dateTimePicker;
        private ImageList m_pictosActeur;
        private Panel m_panelHeaderPicto;
        private ToolTip m_toolTip;
        private Label m_lblHeaderActeur;
        private Panel m_panelActeur;
        private Label m_lblActeur;
        private Button m_btnActeur;
        private C2iDateTimePicker m_dtFinOperation;
        private ErrorProvider m_errorProvider;
		private IContainer components;

	
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

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleSaisieOperation));
            this.m_txtTypeOperation = new sc2i.win32.common.IntellisenseTextBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_btnInsert = new System.Windows.Forms.PictureBox();
            this.m_btnAdd = new System.Windows.Forms.PictureBox();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_panelDataStd = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_dtFinOperation = new sc2i.win32.common.C2iDateTimePicker();
            this.m_panelContientLaDurée = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelDuree = new System.Windows.Forms.Panel();
            this.m_txtDuree = new sc2i.win32.common.CWndSaisieHeure();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelContientDateHeure = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelDate = new System.Windows.Forms.Panel();
            this.m_dateTimePicker = new sc2i.win32.common.C2iDateTimePicker();
            this.m_lblCode = new System.Windows.Forms.Label();
            this.m_panelActeur = new System.Windows.Forms.Panel();
            this.m_btnActeur = new System.Windows.Forms.Button();
            this.m_lblActeur = new System.Windows.Forms.Label();
            this.m_panelEntete = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblHeaderComment = new System.Windows.Forms.Label();
            this.m_lblHeaderDuration = new System.Windows.Forms.Label();
            this.m_lblHeaderStartDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblHeaderOperationType = new System.Windows.Forms.Label();
            this.m_lblHeaderCode = new System.Windows.Forms.Label();
            this.m_panelHeaderPicto = new System.Windows.Forms.Panel();
            this.m_lblHeaderActeur = new System.Windows.Forms.Label();
            this.m_panelFormulaire = new sc2i.win32.data.dynamic.CPanelFormulaireSurElement();
            this.m_panelGaucheFormulaire = new System.Windows.Forms.Panel();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_panelDroiteFormulaire = new System.Windows.Forms.Panel();
            this.m_panelEchangeMateriel = new System.Windows.Forms.Panel();
            this.m_imagePasOk = new System.Windows.Forms.PictureBox();
            this.m_imageOk = new System.Windows.Forms.PictureBox();
            this.m_lnkEchange = new System.Windows.Forms.LinkLabel();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnLigneSuivante = new System.Windows.Forms.Button();
            this.m_panelLieEquipement = new System.Windows.Forms.Panel();
            this.m_txtSelectEquipementLie = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblEquipement = new System.Windows.Forms.Label();
            this.m_pictosActeur = new System.Windows.Forms.ImageList(this.components);
            this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_panelPoubelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            this.m_panelDataStd.SuspendLayout();
            this.m_panelContientLaDurée.SuspendLayout();
            this.m_panelDuree.SuspendLayout();
            this.m_panelContientDateHeure.SuspendLayout();
            this.m_panelDate.SuspendLayout();
            this.m_panelActeur.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            this.m_panelHeaderPicto.SuspendLayout();
            this.m_panelEchangeMateriel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imagePasOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageOk)).BeginInit();
            this.c2iPanel1.SuspendLayout();
            this.m_panelLieEquipement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtTypeOperation
            // 
            this.m_txtTypeOperation.AcceptReturn = false;
            this.m_txtTypeOperation.Arbre = null;
            this.m_txtTypeOperation.AvecBouton = true;
            this.m_txtTypeOperation.DisableIntellisense = false;
            this.m_txtTypeOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtTypeOperation.Location = new System.Drawing.Point(160, 0);
            this.m_txtTypeOperation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypeOperation.Name = "m_txtTypeOperation";
            this.m_txtTypeOperation.ReplaceAllText = true;
            this.m_txtTypeOperation.SeparateursPrincipaux = "";
            this.m_txtTypeOperation.SeparateursSecondaires = "";
            this.m_txtTypeOperation.Size = new System.Drawing.Size(255, 22);
            this.m_txtTypeOperation.TabIndex = 2;
            this.m_txtTypeOperation.ValiderEnQuittant = true;
            this.m_txtTypeOperation.Load += new System.EventHandler(this.m_txtTypeOperation_Load);
            this.m_txtTypeOperation.OnLeaveTextBox += new System.EventHandler(this.m_txtTypeDonnee_OnLeaveTextBox);
            this.m_txtTypeOperation.Enter += new System.EventHandler(this.m_txtTypeOperation_Enter);
            // 
            // m_panelPoubelle
            // 
            this.m_panelPoubelle.BackColor = System.Drawing.Color.White;
            this.m_panelPoubelle.Controls.Add(this.m_btnInsert);
            this.m_panelPoubelle.Controls.Add(this.m_btnAdd);
            this.m_panelPoubelle.Controls.Add(this.m_btnPoubelle);
            this.m_panelPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelPoubelle.Location = new System.Drawing.Point(787, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(34, 22);
            this.m_panelPoubelle.TabIndex = 9;
            // 
            // m_btnInsert
            // 
            this.m_btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnInsert.BackColor = System.Drawing.Color.Lime;
            this.m_btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("m_btnInsert.Image")));
            this.m_btnInsert.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnInsert, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnInsert.Name = "m_btnInsert";
            this.m_btnInsert.Size = new System.Drawing.Size(16, 12);
            this.m_btnInsert.TabIndex = 7;
            this.m_btnInsert.TabStop = false;
            this.m_btnInsert.Click += new System.EventHandler(this.m_btnInsert_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnAdd.BackColor = System.Drawing.Color.Aqua;
            this.m_btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAdd.Image")));
            this.m_btnAdd.Location = new System.Drawing.Point(0, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(16, 12);
            this.m_btnAdd.TabIndex = 8;
            this.m_btnAdd.TabStop = false;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(16, -1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 24);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 6;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // m_panelDataStd
            // 
            this.m_panelDataStd.Controls.Add(this.m_txtCommentaire);
            this.m_panelDataStd.Controls.Add(this.m_dtFinOperation);
            this.m_panelDataStd.Controls.Add(this.m_panelContientLaDurée);
            this.m_panelDataStd.Controls.Add(this.m_panelContientDateHeure);
            this.m_panelDataStd.Controls.Add(this.m_txtTypeOperation);
            this.m_panelDataStd.Controls.Add(this.m_lblCode);
            this.m_panelDataStd.Controls.Add(this.m_panelActeur);
            this.m_panelDataStd.Controls.Add(this.m_panelPoubelle);
            this.m_panelDataStd.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelDataStd.Location = new System.Drawing.Point(18, 22);
            this.m_panelDataStd.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDataStd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDataStd.Name = "m_panelDataStd";
            this.m_panelDataStd.Size = new System.Drawing.Size(821, 22);
            this.m_panelDataStd.TabIndex = 10;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCommentaire.EmptyText = "";
            this.m_txtCommentaire.Location = new System.Drawing.Point(757, 0);
            this.m_txtCommentaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(30, 22);
            this.m_txtCommentaire.TabIndex = 6;
            this.m_txtCommentaire.WordWrap = false;
            // 
            // m_dtFinOperation
            // 
            this.m_dtFinOperation.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtFinOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_dtFinOperation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtFinOperation.Location = new System.Drawing.Point(643, 0);
            this.m_dtFinOperation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFinOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtFinOperation.Name = "m_dtFinOperation";
            this.m_dtFinOperation.Size = new System.Drawing.Size(114, 20);
            this.m_dtFinOperation.TabIndex = 5;
            this.m_dtFinOperation.Value = new System.DateTime(2009, 1, 16, 15, 1, 55, 125);
            this.m_dtFinOperation.ValueChanged += new System.EventHandler(this.m_dateTimePicker_ValueChanged);
            // 
            // m_panelContientLaDurée
            // 
            this.m_panelContientLaDurée.BackColor = System.Drawing.Color.White;
            this.m_panelContientLaDurée.Controls.Add(this.m_panelDuree);
            this.m_panelContientLaDurée.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelContientLaDurée.Location = new System.Drawing.Point(529, 0);
            this.m_panelContientLaDurée.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContientLaDurée, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelContientLaDurée.Name = "m_panelContientLaDurée";
            this.m_panelContientLaDurée.Size = new System.Drawing.Size(114, 22);
            this.m_panelContientLaDurée.TabIndex = 4;
            // 
            // m_panelDuree
            // 
            this.m_panelDuree.Controls.Add(this.m_txtDuree);
            this.m_panelDuree.Controls.Add(this.label2);
            this.m_panelDuree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDuree.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDuree, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDuree.Name = "m_panelDuree";
            this.m_panelDuree.Size = new System.Drawing.Size(114, 22);
            this.m_panelDuree.TabIndex = 0;
            // 
            // m_txtDuree
            // 
            this.m_txtDuree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtDuree.Location = new System.Drawing.Point(0, 0);
            this.m_txtDuree.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDuree.Name = "m_txtDuree";
            this.m_txtDuree.NullAutorise = true;
            this.m_txtDuree.SaisieDuree = true;
            this.m_txtDuree.Size = new System.Drawing.Size(98, 22);
            this.m_txtDuree.TabIndex = 0;
            this.m_txtDuree.ValeurHeure = null;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(98, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "h";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelContientDateHeure
            // 
            this.m_panelContientDateHeure.BackColor = System.Drawing.Color.White;
            this.m_panelContientDateHeure.Controls.Add(this.m_panelDate);
            this.m_panelContientDateHeure.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelContientDateHeure.Location = new System.Drawing.Point(415, 0);
            this.m_panelContientDateHeure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContientDateHeure, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelContientDateHeure.Name = "m_panelContientDateHeure";
            this.m_panelContientDateHeure.Size = new System.Drawing.Size(114, 22);
            this.m_panelContientDateHeure.TabIndex = 3;
            // 
            // m_panelDate
            // 
            this.m_panelDate.Controls.Add(this.m_dateTimePicker);
            this.m_panelDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDate.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDate.Name = "m_panelDate";
            this.m_panelDate.Size = new System.Drawing.Size(114, 22);
            this.m_panelDate.TabIndex = 0;
            // 
            // m_dateTimePicker
            // 
            this.m_dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.m_dateTimePicker.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dateTimePicker, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dateTimePicker.Name = "m_dateTimePicker";
            this.m_dateTimePicker.Size = new System.Drawing.Size(114, 20);
            this.m_dateTimePicker.TabIndex = 0;
            this.m_dateTimePicker.Value = new System.DateTime(2009, 1, 16, 15, 1, 55, 125);
            this.m_dateTimePicker.ValueChanged += new System.EventHandler(this.m_dateTimePicker_ValueChanged);
            // 
            // m_lblCode
            // 
            this.m_lblCode.BackColor = System.Drawing.Color.White;
            this.m_lblCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblCode.Location = new System.Drawing.Point(110, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCode.Name = "m_lblCode";
            this.m_lblCode.Size = new System.Drawing.Size(50, 22);
            this.m_lblCode.TabIndex = 12;
            this.m_lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelActeur
            // 
            this.m_panelActeur.BackColor = System.Drawing.Color.White;
            this.m_panelActeur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelActeur.Controls.Add(this.m_btnActeur);
            this.m_panelActeur.Controls.Add(this.m_lblActeur);
            this.m_panelActeur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelActeur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelActeur.Name = "m_panelActeur";
            this.m_panelActeur.Size = new System.Drawing.Size(110, 22);
            this.m_panelActeur.TabIndex = 1;
            // 
            // m_btnActeur
            // 
            this.m_btnActeur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnActeur.FlatAppearance.BorderSize = 0;
            this.m_btnActeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnActeur.Image = global::timos.Properties.Resources.Picto_acteur3;
            this.m_btnActeur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnActeur.Name = "m_btnActeur";
            this.m_btnActeur.Size = new System.Drawing.Size(22, 18);
            this.m_btnActeur.TabIndex = 1;
            this.m_btnActeur.TabStop = false;
            this.m_btnActeur.UseVisualStyleBackColor = true;
            this.m_btnActeur.Click += new System.EventHandler(this.m_btnActeur_Click);
            this.m_btnActeur.Enter += new System.EventHandler(this.m_btnActeur_Enter);
            // 
            // m_lblActeur
            // 
            this.m_lblActeur.AutoSize = true;
            this.m_lblActeur.Location = new System.Drawing.Point(19, 3);
            this.m_lblActeur.Margin = new System.Windows.Forms.Padding(0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblActeur.Name = "m_lblActeur";
            this.m_lblActeur.Size = new System.Drawing.Size(113, 13);
            this.m_lblActeur.TabIndex = 0;
            this.m_lblActeur.Text = "Member identity|30179";
            this.m_lblActeur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.m_lblHeaderComment);
            this.m_panelEntete.Controls.Add(this.m_lblHeaderDuration);
            this.m_panelEntete.Controls.Add(this.m_lblHeaderStartDate);
            this.m_panelEntete.Controls.Add(this.label6);
            this.m_panelEntete.Controls.Add(this.m_lblHeaderOperationType);
            this.m_panelEntete.Controls.Add(this.m_lblHeaderCode);
            this.m_panelEntete.Controls.Add(this.m_panelHeaderPicto);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(863, 22);
            this.m_panelEntete.TabIndex = 11;
            // 
            // m_lblHeaderComment
            // 
            this.m_lblHeaderComment.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblHeaderComment.Location = new System.Drawing.Point(643, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderComment, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderComment.Name = "m_lblHeaderComment";
            this.m_lblHeaderComment.Size = new System.Drawing.Size(164, 22);
            this.m_lblHeaderComment.TabIndex = 4;
            this.m_lblHeaderComment.Text = "Comments|51";
            this.m_lblHeaderComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderDuration
            // 
            this.m_lblHeaderDuration.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderDuration.Location = new System.Drawing.Point(529, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderDuration, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderDuration.Name = "m_lblHeaderDuration";
            this.m_lblHeaderDuration.Size = new System.Drawing.Size(114, 22);
            this.m_lblHeaderDuration.TabIndex = 6;
            this.m_lblHeaderDuration.Text = "End/Duration|873";
            this.m_lblHeaderDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderStartDate
            // 
            this.m_lblHeaderStartDate.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderStartDate.Location = new System.Drawing.Point(415, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderStartDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderStartDate.Name = "m_lblHeaderStartDate";
            this.m_lblHeaderStartDate.Size = new System.Drawing.Size(114, 22);
            this.m_lblHeaderStartDate.TabIndex = 7;
            this.m_lblHeaderStartDate.Text = "Start at|1283";
            this.m_lblHeaderStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(807, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 22);
            this.label6.TabIndex = 5;
            // 
            // m_lblHeaderOperationType
            // 
            this.m_lblHeaderOperationType.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderOperationType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderOperationType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderOperationType.Location = new System.Drawing.Point(160, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderOperationType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderOperationType.Name = "m_lblHeaderOperationType";
            this.m_lblHeaderOperationType.Size = new System.Drawing.Size(255, 22);
            this.m_lblHeaderOperationType.TabIndex = 3;
            this.m_lblHeaderOperationType.Text = "Op. type|882";
            this.m_lblHeaderOperationType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderCode
            // 
            this.m_lblHeaderCode.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderCode.Location = new System.Drawing.Point(110, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderCode.Name = "m_lblHeaderCode";
            this.m_lblHeaderCode.Size = new System.Drawing.Size(50, 22);
            this.m_lblHeaderCode.TabIndex = 2;
            this.m_lblHeaderCode.Text = "Op. code|881";
            this.m_lblHeaderCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelHeaderPicto
            // 
            this.m_panelHeaderPicto.BackColor = System.Drawing.Color.White;
            this.m_panelHeaderPicto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelHeaderPicto.Controls.Add(this.m_lblHeaderActeur);
            this.m_panelHeaderPicto.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelHeaderPicto.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeaderPicto, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeaderPicto.Name = "m_panelHeaderPicto";
            this.m_panelHeaderPicto.Size = new System.Drawing.Size(110, 22);
            this.m_panelHeaderPicto.TabIndex = 8;
            // 
            // m_lblHeaderActeur
            // 
            this.m_lblHeaderActeur.AutoSize = true;
            this.m_lblHeaderActeur.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHeaderActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderActeur.Name = "m_lblHeaderActeur";
            this.m_lblHeaderActeur.Size = new System.Drawing.Size(52, 13);
            this.m_lblHeaderActeur.TabIndex = 0;
            this.m_lblHeaderActeur.Text = "Author|89";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelFormulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(86, 82);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(719, 20);
            this.m_panelFormulaire.TabIndex = 12;
            this.m_panelFormulaire.SizeChanged += new System.EventHandler(this.m_panelFormulaire_SizeChanged);
            // 
            // m_panelGaucheFormulaire
            // 
            this.m_panelGaucheFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelGaucheFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGaucheFormulaire.Location = new System.Drawing.Point(18, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGaucheFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGaucheFormulaire.Name = "m_panelGaucheFormulaire";
            this.m_panelGaucheFormulaire.Size = new System.Drawing.Size(68, 59);
            this.m_panelGaucheFormulaire.TabIndex = 13;
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(18, 81);
            this.m_panelMarge.TabIndex = 17;
            // 
            // m_panelDroiteFormulaire
            // 
            this.m_panelDroiteFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelDroiteFormulaire.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDroiteFormulaire.Location = new System.Drawing.Point(805, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDroiteFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDroiteFormulaire.Name = "m_panelDroiteFormulaire";
            this.m_panelDroiteFormulaire.Size = new System.Drawing.Size(34, 59);
            this.m_panelDroiteFormulaire.TabIndex = 18;
            // 
            // m_panelEchangeMateriel
            // 
            this.m_panelEchangeMateriel.BackColor = System.Drawing.Color.White;
            this.m_panelEchangeMateriel.Controls.Add(this.m_imagePasOk);
            this.m_panelEchangeMateriel.Controls.Add(this.m_imageOk);
            this.m_panelEchangeMateriel.Controls.Add(this.m_lnkEchange);
            this.m_panelEchangeMateriel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEchangeMateriel.Location = new System.Drawing.Point(86, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEchangeMateriel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEchangeMateriel.Name = "m_panelEchangeMateriel";
            this.m_panelEchangeMateriel.Size = new System.Drawing.Size(719, 17);
            this.m_panelEchangeMateriel.TabIndex = 19;
            this.m_panelEchangeMateriel.VisibleChanged += new System.EventHandler(this.m_panelEchangeMateriel_VisibleChanged);
            // 
            // m_imagePasOk
            // 
            this.m_imagePasOk.Image = ((System.Drawing.Image)(resources.GetObject("m_imagePasOk.Image")));
            this.m_imagePasOk.Location = new System.Drawing.Point(126, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imagePasOk, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imagePasOk.Name = "m_imagePasOk";
            this.m_imagePasOk.Size = new System.Drawing.Size(16, 16);
            this.m_imagePasOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_imagePasOk.TabIndex = 3;
            this.m_imagePasOk.TabStop = false;
            this.m_imagePasOk.Visible = false;
            // 
            // m_imageOk
            // 
            this.m_imageOk.Image = ((System.Drawing.Image)(resources.GetObject("m_imageOk.Image")));
            this.m_imageOk.Location = new System.Drawing.Point(126, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageOk, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageOk.Name = "m_imageOk";
            this.m_imageOk.Size = new System.Drawing.Size(16, 16);
            this.m_imageOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_imageOk.TabIndex = 2;
            this.m_imageOk.TabStop = false;
            this.m_imageOk.Visible = false;
            // 
            // m_lnkEchange
            // 
            this.m_lnkEchange.Location = new System.Drawing.Point(1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEchange, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEchange.Name = "m_lnkEchange";
            this.m_lnkEchange.Size = new System.Drawing.Size(119, 17);
            this.m_lnkEchange.TabIndex = 1;
            this.m_lnkEchange.TabStop = true;
            this.m_lnkEchange.Text = "Change equipment|537";
            this.m_lnkEchange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEchange_LinkClicked);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_btnLigneSuivante);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.c2iPanel1.Location = new System.Drawing.Point(839, 22);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(24, 81);
            this.c2iPanel1.TabIndex = 22;
            // 
            // m_btnLigneSuivante
            // 
            this.m_btnLigneSuivante.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLigneSuivante.Image")));
            this.m_btnLigneSuivante.Location = new System.Drawing.Point(-1, -1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnLigneSuivante, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnLigneSuivante.Name = "m_btnLigneSuivante";
            this.m_btnLigneSuivante.Size = new System.Drawing.Size(24, 25);
            this.m_btnLigneSuivante.TabIndex = 11;
            this.m_btnLigneSuivante.UseVisualStyleBackColor = true;
            this.m_btnLigneSuivante.Click += new System.EventHandler(this.m_btnLigneSuivante_Click);
            this.m_btnLigneSuivante.Leave += new System.EventHandler(this.m_btnLigneSuivante_Leave);
            this.m_btnLigneSuivante.Enter += new System.EventHandler(this.m_btnLigneSuivante_Enter);
            // 
            // m_panelLieEquipement
            // 
            this.m_panelLieEquipement.BackColor = System.Drawing.Color.White;
            this.m_panelLieEquipement.Controls.Add(this.m_txtSelectEquipementLie);
            this.m_panelLieEquipement.Controls.Add(this.m_lblEquipement);
            this.m_panelLieEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelLieEquipement.Location = new System.Drawing.Point(86, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLieEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLieEquipement.Name = "m_panelLieEquipement";
            this.m_panelLieEquipement.Size = new System.Drawing.Size(719, 21);
            this.m_panelLieEquipement.TabIndex = 20;
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
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectEquipementLie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectEquipementLie.Name = "m_txtSelectEquipementLie";
            this.m_txtSelectEquipementLie.SelectedObject = null;
            this.m_txtSelectEquipementLie.Size = new System.Drawing.Size(612, 21);
            this.m_txtSelectEquipementLie.SpecificImage = null;
            this.m_txtSelectEquipementLie.TabIndex = 10;
            this.m_txtSelectEquipementLie.TextNull = "";
            // 
            // m_lblEquipement
            // 
            this.m_lblEquipement.Location = new System.Drawing.Point(3, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEquipement.Name = "m_lblEquipement";
            this.m_lblEquipement.Size = new System.Drawing.Size(95, 19);
            this.m_lblEquipement.TabIndex = 9;
            this.m_lblEquipement.Text = "Equipment|195";
            // 
            // m_pictosActeur
            // 
            this.m_pictosActeur.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_pictosActeur.ImageStream")));
            this.m_pictosActeur.TransparentColor = System.Drawing.Color.Transparent;
            this.m_pictosActeur.Images.SetKeyName(0, "Picto_acteur3.png");
            this.m_pictosActeur.Images.SetKeyName(1, "search.png");
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // CControleSaisieOperation
            // 
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelEchangeMateriel);
            this.Controls.Add(this.m_panelLieEquipement);
            this.Controls.Add(this.m_panelDroiteFormulaire);
            this.Controls.Add(this.m_panelGaucheFormulaire);
            this.Controls.Add(this.m_panelDataStd);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.m_panelEntete);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleSaisieOperation";
            this.Size = new System.Drawing.Size(863, 103);
            this.Load += new System.EventHandler(this.CControleSaisieOperation_Load);
            this.Enter += new System.EventHandler(this.CControleSaisieOperation_Enter);
            this.m_panelPoubelle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            this.m_panelDataStd.ResumeLayout(false);
            this.m_panelDataStd.PerformLayout();
            this.m_panelContientLaDurée.ResumeLayout(false);
            this.m_panelDuree.ResumeLayout(false);
            this.m_panelContientDateHeure.ResumeLayout(false);
            this.m_panelDate.ResumeLayout(false);
            this.m_panelActeur.ResumeLayout(false);
            this.m_panelActeur.PerformLayout();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelHeaderPicto.ResumeLayout(false);
            this.m_panelHeaderPicto.PerformLayout();
            this.m_panelEchangeMateriel.ResumeLayout(false);
            this.m_panelEchangeMateriel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imagePasOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageOk)).EndInit();
            this.c2iPanel1.ResumeLayout(false);
            this.m_panelLieEquipement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion


		public CControleSaisieOperation(CControleSaisiesOperations controlParent)
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
			m_controleParent = controlParent;

			if (!DesignMode)
				InitRecepteurs();

            this.m_txtTypeOperation.TextBox.TextChanged += new EventHandler(m_txtTypeOperation_TextChanged);
            m_clrBackSave = BackColor;

		}


		private class CLockerArbres
		{
		}


        //----------------------------------------------------------------
        public bool SaisieActeur
        {
            get { return m_bSaisieActeur; }
            set { m_bSaisieActeur = value; }
        }


		//------------------------------------------------------------
		public CTypeOperation TypeOperation
		{
			get
			{
				return m_typeOperation;
			}
		}

		//------------------------------------------------------------
		private void InitRecepteurs()
		{
			if (m_recepteurNotificationTypeDonneeAjoutee == null)
			{
				m_recepteurNotificationTypeDonneeAjoutee = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationAjoutEnregistrement));
				m_recepteurNotificationTypeDonneeAjoutee.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationAjout);
			}
			if (m_recepteurNotificationTypeDonneeModifiee == null)
			{
				m_recepteurNotificationTypeDonneeModifiee = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationModificationContexteDonnee));
				m_recepteurNotificationTypeDonneeModifiee.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationModif);
			}
		}

		////////////////////////////////////////////////////////////////////////////
		protected static void OnReceiveNotificationAjout(IDonneeNotification donnee)
		{
			try
			{
				if (!(donnee is CDonneeNotificationAjoutEnregistrement))
					return;
				//Marque tous les éléments comme étant à relire depuis la base de données
				CDonneeNotificationAjoutEnregistrement donneeAjout = (CDonneeNotificationAjoutEnregistrement)donnee;
				if (donneeAjout.NomTable == CTypeOperation.c_nomTable ||
					donneeAjout.NomTable == CTypeIntervention_TypeOperation.c_nomTable )
				{
					lock (typeof(CLockerArbres))
					{
						m_tableArbres = new Hashtable();
					}
				}
			}
			catch
			{
			}
		}

		////////////////////////////////////////////////////////////////////////////
		protected static void OnReceiveNotificationModif(IDonneeNotification donnee)
		{
			if (!(donnee is CDonneeNotificationModificationContexteDonnee))
				return;
			//Marque tous les éléments comme étant à relire depuis la base de données
			CDonneeNotificationModificationContexteDonnee donneeModif = (CDonneeNotificationModificationContexteDonnee)donnee;
			foreach (CDonneeNotificationModificationContexteDonnee.CInfoEnregistrementModifie info in donneeModif.ListeModifications)
			{
				if (info.NomTable == CTypeOperation.c_nomTable ||
					info.NomTable == CTypeIntervention_TypeOperation.c_nomTable)
				{
					lock (typeof(CLockerArbres))
					{
						m_tableArbres = new Hashtable();
					}
					return;
				}
			}
		}

		//----------------------------------------------------------------------------
		private CArbreVocabulaire Arbre
		{
			get
			{
				lock ( typeof(CLockerArbres) )
				{
					object obj = m_typeOperationParente;
                    if (m_typeOperationParente == null)
                    {
                        if (m_controleParent.FractionIntervention != null)
                        {
                            obj = m_controleParent.FractionIntervention.Intervention.TypeIntervention;
                            m_typeInterventionArbre = obj as CTypeIntervention;
                        }
                        else
                            obj = m_controleParent.PhaseTicket.TypePhase;
                    }
                    if (obj == null)
                        return null;
                    CArbreVocabulaire arbre = (CArbreVocabulaire)m_tableArbres[obj];
					if ( arbre == null )
					{
                        arbre = new CArbreVocabulaire(3, 0, "");
						arbre.TouteLaListeSurChaineVide = true;
						CListeObjetsDonnees liste;
						if ( m_typeOperationParente != null )
							liste = m_typeOperationParente.TypesOperationsFilles;
						else
						{
							liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CTypeOperation) );
                            if (obj is CTypeIntervention)
                            {
                                // Filtre les types d'opérations possibles en fonction du type d'Intervention
                                liste.Filtre = new CFiltreDataAvance(
                                   CTypeOperation.c_nomTable,
                                   CTypeIntervention_TypeOperation.c_nomTable + "." +
                                   CTypeIntervention.c_champId + "= @1 and " + 
                                   CTypeOperation.c_champNiveau + " = @2",
                                   ((CTypeIntervention)obj).Id,
                                   Niveau);
                            }
                            else
                            {
                                // Filtre les types d'opérations possibles en fonction du type de Phase
                                liste.Filtre = new CFiltreDataAvance(
                                   CTypeOperation.c_nomTable,
                                   CTypePhase_TypeOperation.c_nomTable + "." +
                                   CTypePhase.c_champId + "=@1 and " +
                                   CTypeOperation.c_champNiveau + " = @2",
                                   ((CTypePhase)obj).Id,
                                   Niveau);
                                
                            }
                            if (m_controleParent.FractionIntervention != null)
                            {
                                CListeObjetsDonnees listeOpPrev = m_controleParent.FractionIntervention.Intervention.Operations;
                                string strIdOpPrev = "";
                                foreach (COperation ope in listeOpPrev)
                                    strIdOpPrev += ope.TypeOperation.Id + ";";
                                if (strIdOpPrev.Length > 0)
                                {
                                    strIdOpPrev = strIdOpPrev.Substring(0, strIdOpPrev.Length - 1);
                                    liste.Filtre = CFiltreDataAvance.GetOrFiltre(
                                        liste.Filtre,
                                        new CFiltreDataAvance(
                                            CTypeOperation.c_nomTable,
                                            CTypeOperation.c_champId + " in (" + strIdOpPrev + ")"));
                                }
                            }
						}
						foreach (CTypeOperation typeOp in liste)
						{
							arbre.StockeMot(typeOp.Libelle, typeOp.Code);
						}
						m_tableArbres[obj] = arbre;
					}
					return arbre;
				}
			}
		}

		//---------------------------------------------------
		private CControleSaisiesOperations ControleOperation
		{
			get
			{
				return m_controleParent;
			}
		}

		//---------------------------------------------------
		public int Index
		{
			get
			{
				return m_nIndex;
			}
			set
			{
				m_nIndex = value;
			}
		}

        //--------------------------------------------------------------------------------------------
        public void InitControle(COperation operation, int nIndex, int nNiveau, bool bAvecEntete)
        {
            InitControle(operation, nIndex, nNiveau, bAvecEntete, true);
        }

        //--------------------------------------------------------------------------------------------
        public bool AvecEntete
        {
            get
            {
                return m_bAvecEntete;
            }
            set
            {
                m_bAvecEntete = value;
                m_panelEntete.Visible = m_bAvecEntete;
                RecalcSize();
            }
        }

		//--------------------------------------------------------------------------------------------
        public void InitControle(COperation operation, int nIndex, int nNiveau, bool bAvecEntete, bool bAvecSaisieActeur)
		{
            CWin32Traducteur.Translate(this);
			m_panelEntete.Visible = bAvecEntete;
			m_bAvecEntete = bAvecEntete;
            SaisieActeur = bAvecSaisieActeur;

			m_typeOperationParente = ControleOperation.GetTypeDonneeNiveau ( nNiveau-1, nIndex );
			m_nNiveau = nNiveau;
			m_typeOperation =  null;
			m_nIndex = nIndex;
			m_txtTypeOperation.TextBox.Text = "";
			m_txtTypeOperation.Text = "";
			m_txtCommentaire.Text = "";
			m_panelDuree.Visible = false;

			FillWithOperation(operation);
			/*if ( operation != null )
			{
				m_operation = operation;

				FillWithOperation(operation);
				
				if ( operation.TypeOperation != null )
				{
					m_txtTypeOperation.TextBox.Text = operation.TypeOperation.Libelle;
					m_typeOperation = operation.TypeOperation;
					m_txtCommentaire.Text = operation.Commentaires;
					if (operation.Duree != null)
						m_txtDuree.DoubleValue = (double)operation.Duree;
					else
						m_txtDuree.DoubleValue = Double.NaN;
				}
			}*/
			UpdateAspect();
			m_txtTypeOperation.Arbre = Arbre;
			OnChangeNiveau();
		}

		private void FillWithOperation(COperation operation)
		{
			m_operation = operation;
            m_typeOperation = null;

            if (m_controleParent.ElementAOperations is CFractionIntervention && Index > 0)
            {
                CControleSaisieOperation ctrlPrecedent = (CControleSaisieOperation)m_controleParent.ListeControlesUtils[Index - 1];
                m_dateTimePicker.Value = ctrlPrecedent.m_dateTimePicker.Value;
                if (ctrlPrecedent.m_dtFinOperation.Visible)
                    m_dateTimePicker.Value = ctrlPrecedent.m_dtFinOperation.Value;
                else if (ctrlPrecedent.m_txtDuree.Visible && ctrlPrecedent.m_txtDuree.ValeurHeure != null)
                    m_dateTimePicker.Value = ctrlPrecedent.m_dateTimePicker.Value.AddHours(ctrlPrecedent.m_txtDuree.ValeurHeure.Value);
            }
            else
                m_dateTimePicker.Value = DateTime.Now;

            InitActeur();

            if (m_operation != null)
            {

                m_txtDuree.ValeurHeure = m_operation.Duree;
                //m_txtHeure.ValeurHeure = m_operation.HeureDebut;
                if (m_operation.DateDebut != null)
                    m_dateTimePicker.Value = (DateTime)m_operation.DateDebut;
                else
                    m_dateTimePicker.Value = DateTime.Now;
                m_dtFinOperation.Value = m_operation.DateHeureFin == null ?
                    m_dateTimePicker.Value :
                    m_operation.DateHeureFin.Value;


                m_txtCommentaire.Text = m_operation.Commentaires;
                m_toolTip.SetToolTip(m_txtCommentaire, m_txtCommentaire.Text);
                m_toolTip.SetToolTip(m_txtTypeOperation, m_txtTypeOperation.Text);
                ChangeTypeOperation(operation.TypeOperation);
                int nCount = operation.Remplacements.Count;
                if (nCount > 0)
                    m_panelEchangeMateriel.Visible = true;
            }
            else
            {
                m_operation = new COperation(ControleOperation.ElementAOperations.ContexteDonnee);
                m_operation.CreateNewInCurrentContexte();
                m_operation.ElementAOperationsRealisees = m_controleParent.ElementAOperations;
                m_dtFinOperation.Value = m_dateTimePicker.Value;
                
                ChangeTypeOperation(null);
            }
		}

		private void ChangeTypeOperation ( CTypeOperation typeOperation )
		{
			bool bChangement = false;
			if (typeOperation == null && m_typeOperation != null ||
				 m_typeOperation == null && typeOperation != null)
				bChangement = true;
			if (m_typeOperation != null && !m_typeOperation.Equals(typeOperation))
				bChangement = true;

			m_typeOperation = typeOperation;


			if (m_typeOperation == null)
			{
				m_lblCode.Text = "";
				m_txtTypeOperation.Text = "";
				m_panelDuree.Visible = true;
                m_dtFinOperation.Visible = false;
				m_panelDate.Visible = true;
                m_panelLieEquipement.Visible = false;
				m_panelEchangeMateriel.Visible = false;
				m_panelFormulaire.Visible = false;
				m_panelFormulaire.InitPanel(null, null);
                m_txtTypeOperation.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                m_gestionnaireModeEdition.SetModeEdition(m_txtTypeOperation, TypeModeEdition.EnableSurEdition);
			}
			else
			{
				m_lblCode.Text = m_typeOperation.Code;
				m_txtTypeOperation.Text = m_typeOperation.Libelle;
                m_lblHeaderDuration.Visible = true;
                m_panelDuree.Visible = m_lblHeaderDuration.Visible = m_panelContientLaDurée.Visible = m_typeOperation.SaisieDureeAppliquee && !m_typeOperation.SaisieDureeParDateFin;
                m_lblHeaderDuration.Visible |= m_dtFinOperation.Visible = m_typeOperation.SaisieDureeAppliquee && m_typeOperation.SaisieDureeParDateFin;
                m_lblHeaderStartDate.Visible = m_panelContientDateHeure.Visible = m_typeOperation.SaisieHeureAppliquee;
                m_panelLieEquipement.Visible = m_typeOperation.IsLieeAEquipement && !m_typeOperation.IsRemplacementEquipement;
                m_panelEchangeMateriel.Visible = m_typeOperation.IsLieeAEquipement && m_typeOperation.IsRemplacementEquipement;
                if (m_typeOperation.VerrouillerLeTypeApresCreation && m_operation != null && !m_operation.IsNew())
                {
                    m_txtTypeOperation.LockEdition = true;
                    m_gestionnaireModeEdition.SetModeEdition(m_txtTypeOperation, TypeModeEdition.Autonome);
                }
                else
                {
                    m_txtTypeOperation.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                    m_gestionnaireModeEdition.SetModeEdition(m_txtTypeOperation, TypeModeEdition.EnableSurEdition);
                }

                if (m_typeOperation.InterditSuppressionApresCreation && m_operation != null && !m_operation.IsNew())
                {
                    m_btnPoubelle.Visible = false;
                }
                else
                {
                    m_btnPoubelle.Visible = true;
                }

				if (bChangement)
				{
                    InitSelectEquipement();

					CFormulaire formulaire = m_typeOperation.FormulaireCompteRendu;
					if (formulaire != null)
					{
						object eltTmp = null;
						if (m_operation != null)
							eltTmp = m_operation;
						else
							eltTmp = m_elementAVariables;
						m_panelFormulaire.Size = formulaire.Formulaire.Size;
                        m_panelFormulaire.AutoSize = formulaire.Formulaire.AutoSize;
                        m_panelFormulaire.AutoScroll = !formulaire.Formulaire.AutoSize;
						//STef 17/07/2009 : ne met plus à jour les champs
                        //pour éviter des erreurs de validation
                        /*if (m_panelFormulaire.Visible)
							m_panelFormulaire.AffecteValeursToElement();*/
						m_panelFormulaire.InitPanel(formulaire.Formulaire, eltTmp);
						m_panelFormulaire.Visible = true;
					}
					else
						m_panelFormulaire.Visible = false;
				}
			}
			RecalcSize();
			if ( bChangement )
				m_controleParent.OnChangeTypeDonnee(m_nIndex, m_typeOperation);
		}

		//---------------------------------------------------
		private void UpdateAspect()
		{
			if (m_typeOperation == null)
			{
				m_btnLigneSuivante.BackColor = Color.Red;
			}
			else
			{
				m_btnLigneSuivante.BackColor = BackColor;
			}
		}

		private void RecalcSize()
		{
			int nHeight = m_panelDataStd.Height;
			if ( m_bAvecEntete )
				nHeight += m_panelEntete.Height;
			if (m_typeOperation != null && m_typeOperation.FormulaireCompteRendu != null)
				nHeight += m_panelFormulaire.Height;
            if (m_typeOperation != null && m_typeOperation.IsLieeAEquipement && !m_typeOperation.IsRemplacementEquipement)
                nHeight += m_panelLieEquipement.Height;
            if (m_typeOperation != null && m_typeOperation.IsLieeAEquipement && m_typeOperation.IsRemplacementEquipement)
				nHeight += m_panelEchangeMateriel.Height;
			Height = nHeight;
		}

		//---------------------------------------------------
		private CTypeOperation FindType (  )
		{
			if (m_txtTypeOperation.Text == "")
				return null;
			CListeObjetsDonnees liste;
			if (m_typeOperationParente != null)
			{
				liste = m_typeOperationParente.TypesOperationsFilles;
				liste.Filtre = new CFiltreData(CTypeOperation.c_champLibelle + "=@1 or " +
					CTypeOperation.c_champCode + "=@1", m_txtTypeOperation.Text);
			}
			else
			{
                object obj = null;
                if (m_controleParent.FractionIntervention != null)
                    obj = m_controleParent.FractionIntervention.Intervention.TypeIntervention;
                else
                    obj = m_controleParent.PhaseTicket.TypePhase;

                liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CTypeOperation));
                if (obj is CTypeIntervention)
                {
                    // Filtre les types d'opérations possibles en fonction du type d'Intervention
                    liste.Filtre = new CFiltreDataAvance(
                       CTypeOperation.c_nomTable,
                       CTypeIntervention_TypeOperation.c_nomTable + "." +
                       CTypeIntervention.c_champId + "=@1",
                       ((CTypeIntervention)obj).Id);
                }
                else
                {
                    // Filtre les types d'opérations possibles en fonction du type de Phase
                    liste.Filtre = new CFiltreDataAvance(
                       CTypeOperation.c_nomTable,
                       CTypePhase_TypeOperation.c_nomTable + "." +
                       CTypePhase.c_champId + "=@1",
                       ((CTypePhase)obj).Id);

                }

                if (m_controleParent.FractionIntervention != null)
                {
                    CListeObjetsDonnees listeOpPrev = m_controleParent.FractionIntervention.Intervention.Operations;
                    string strIdOpPrev = "";
                    foreach (COperation ope in listeOpPrev)
                        strIdOpPrev += ope.TypeOperation.Id + ";";
                    if (strIdOpPrev.Length > 0)
                    {
                        strIdOpPrev = strIdOpPrev.Substring(0, strIdOpPrev.Length - 1);
                        liste.Filtre = CFiltreDataAvance.GetOrFiltre(
                            liste.Filtre,
                            new CFiltreDataAvance(
                                CTypeOperation.c_nomTable,
                                CTypeOperation.c_champId + " in (" + strIdOpPrev + ")"));
                    }
                }
                liste.Filtre = CFiltreDataAvance.GetAndFiltre(liste.Filtre,
                    new CFiltreDataAvance(
                        CTypeOperation.c_nomTable,
                        CTypeOperation.c_champLibelle + "=@1 or " +
					    CTypeOperation.c_champCode + "=@1",
                        m_txtTypeOperation.Text));

			}
			
			CTypeOperation typeDonnee =  null;
			if ( liste.Count > 0 )
				typeDonnee = (CTypeOperation)liste[0];

			return typeDonnee;
		}

		//---------------------------------------------------
		private void m_txtTypeDonnee_OnLeaveTextBox(object sender, System.EventArgs e)
		{
            //if ( !m_gestionnaireModeEdition.ModeEdition )
            //    return;
            //CTypeOperation typeDonnee = FindType ( );
            //ChangeTypeOperation(typeDonnee);
            //UpdateAspect();
		}

        void m_txtTypeOperation_TextChanged(object sender, EventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;
            CTypeOperation typeOperation = FindType();
            if (typeOperation != null)
            {
                ChangeTypeOperation(typeOperation);
                UpdateAspect();
            }
        }


		//-----------------------------------------------------------------------------
		private void CControleSaisieOperation_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
			m_txtTypeOperation.TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
			m_txtCommentaire.KeyDown += new KeyEventHandler(TextBox_KeyDown);
		}

		//-----------------------------------------------------------------------
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if ( (e.Modifiers & Keys.Control) == Keys.Control && !LockEdition )
			{
				switch ( e.KeyCode )
				{
					case Keys.Right :
						OnUpLevel();
						e.Handled = true;
						return;
					case Keys.Left :
						OnLowLevel();
						e.Handled = true;
						return;
					case Keys.Down :
						InsertAfter();
						e.Handled = true;
						return;
					case Keys.Up :
						InsertBefore();
						e.Handled = true;
						return;
				}
			}
			if ( sender == m_txtCommentaire  )
			{
				switch ( e.KeyCode )
				{
					case Keys.Down :
						e.Handled = m_controleParent.GoDown( Index, ((Control)sender).Name );
						break;
					case Keys.Up :
						e.Handled = m_controleParent.GoUp ( Index, ((Control)sender).Name );
						break;
				}
			}


		}

		private void OnUpLevel()
		{
			if ( ControleOperation.CanChangeNiveau ( m_nIndex, m_nNiveau+1 ) )
			{
				m_nNiveau++;
				OnChangeNiveau();
			}
		}

		private void OnLowLevel()
		{
			if ( ControleOperation.CanChangeNiveau ( m_nIndex, m_nNiveau-1 ) )
			{
				m_nNiveau--;
				OnChangeNiveau();
			}
		}

		private void OnChangeNiveau()
		{
			int nMax = m_nNiveau * 10;
			m_panelMarge.Width = nMax;
			m_typeOperationParente = ControleOperation.GetTypeDonneeNiveau ( m_nNiveau-1, m_nIndex );
			m_txtTypeOperation.Arbre = Arbre;
			
			
		}

		private void m_btnInsert_Click(object sender, System.EventArgs e)
		{
			InsertBefore();
		}

		private void m_btnAdd_Click(object sender, System.EventArgs e)
		{
			InsertAfter();
		}

		private void InsertAfter()
		{
			ControleOperation.InsertAfter ( m_nIndex );
		}

		private void InsertBefore()
		{
			ControleOperation.InsertBefore ( m_nIndex );
		}
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
					OnChangeLockEdition ( this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

		public bool ControleDonnees()
		{
			bool bResult = true;
			if ( m_typeOperation == null )
				bResult = false;
			if ( !bResult )
				BackColor = Color.Red;
			else
				BackColor = Parent.BackColor;			
			return bResult;
		}

		private void m_wndUnite_Leave(object sender, System.EventArgs e)
		{
			if ( ControleOperation.IsDernierControle ( m_nIndex ) )
			{
				if ( ControleDonnees() )
				{
					InsertAfter();
				}
			}
		}

		private void m_btnPoubelle_Click(object sender, System.EventArgs e)
		{
			if ( ControleDonnees() )
			{
				if ( CFormAlerte.Afficher(I.T("Delete the data ?|30180"), EFormAlerteType.Question) 
					== DialogResult.No )
				{
					return;
				}
			}
			ControleOperation.RemoveDonnee ( this );
		}

		//---------------------------------------------------
		public string Libelle
		{
			get
			{
				return m_txtTypeOperation.Text.Trim();
			}
		}
		
		
		//-----------------------------------------
		public int Niveau
		{
			get
			{
				return m_nNiveau;
			}
		}


		//-----------------------------------------
		public CResultAErreur Maj_Champs( Hashtable tableParentsParNiveau)
		{
			CResultAErreur result = CResultAErreur.True;
			
			if ( m_typeOperation == null && 
				(m_txtCommentaire.Text != "" ))
			{
				ControleDonnees();
				result.EmpileErreur ( I.T("Invalid operation @1 |30181",m_nIndex.ToString()));
				return result;
			}
            if (m_typeOperation == null)
            {
                if (m_operation != null && m_operation.IsNew())
                {
                    m_operation.CancelCreate();
                    m_operation = null;
                }
                return result;
            }
			if ( m_typeOperation.Niveau != m_nNiveau )
			{
				result.EmpileErreur(I.T("Operation @1 : coherence problem, retry|30182",m_nIndex.ToString()));
				return result;
			}
					
			if ( m_operation == null )
			{
				m_operation = new COperation ( ControleOperation.ElementAOperations.ContexteDonnee );
				m_operation.CreateNewInCurrentContexte();
			}		 
			m_operation.Index = m_nIndex;
            //m_operation.FractionIntervention = m_controleParent.FractionIntervention;
            m_operation.ElementAOperationsRealisees = m_controleParent.ElementAOperations;
			m_operation.TypeOperation = m_typeOperation;
            if (m_typeOperation != null && m_typeOperation.SaisieHeureAppliquee)
            {
                //m_operation.HeureDebut = m_txtHeure.ValeurHeure;
                m_operation.DateDebut = m_dateTimePicker.Value;
            }
            else
                m_operation.DateDebut = null;
            if (m_typeOperation != null && m_typeOperation.SaisieDureeAppliquee)
			{
                if (m_typeOperation.SaisieDureeParDateFin)
                    m_operation.DateHeureFin = m_dtFinOperation.Value;
                else
				    m_operation.Duree = m_txtDuree.ValeurHeure;
			}
			else
				m_operation.Duree = null;

			if ( tableParentsParNiveau.Contains ( m_nNiveau-1 ) )
				m_operation.OperationParente = (COperation)tableParentsParNiveau[m_nNiveau-1];
			else
				m_operation.OperationParente = null;
			m_operation.Commentaires = m_txtCommentaire.Text;
			if (m_typeOperation != null && m_typeOperation.FormulaireCompteRendu != null)
			{
				m_panelFormulaire.AffecteValeursToElement( m_operation );
			}
			m_operation.Index = m_nIndex;
			m_operation.Niveau = m_nNiveau;
			m_operation.FractionIntervention = ControleOperation.FractionIntervention;
            m_operation.Equipement = (CEquipement)m_txtSelectEquipementLie.ElementSelectionne;
            m_operation.Acteur = Acteur;

			return result;
			
		}

		//-----------------------------------------
		public COperation Operation
		{
			get
			{
				return m_operation;
			}
			set
			{
				m_operation =  value;
			}
		}


		//---------------------------------------------------------------------
		public void OnChangeTypeParent ( CTypeOperation newTypeParent )
		{
			if ( newTypeParent == null )
			{
				m_typeOperationParente = null;
				m_typeOperation = null;
				UpdateAspect();
				return;
			}
			if ( newTypeParent.Equals ( m_typeOperationParente ) )
				return;
			m_typeOperationParente = newTypeParent;
			m_typeOperation = FindType();
			UpdateAspect();
			m_controleParent.OnChangeTypeDonnee ( m_nIndex, m_typeOperation );
		}

		//---------------------------------------------------------------------
		public bool FocusOn( string strNomControle )
		{
			foreach ( Control ctrl in Controls )
				if ( ctrl.Name == strNomControle )
				{
					ctrl.Focus();
					return true;
				}
			return false;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void m_wndHeure_ValueChanged(object sender, EventArgs e)
		{

		}

		private void m_txtTypeOperation_Load(object sender, EventArgs e)
		{

		}

		private void m_btnLigneSuivante_Click(object sender, EventArgs e)
		{
			InsertAfter();
		}

		private void m_btnLigneSuivante_Enter(object sender, EventArgs e)
		{
            if (BackColor != Color.LightGreen)
                m_clrBackSave = BackColor;
            BackColor = Color.LightGreen;
			UpdateAspect();
		}

		private void m_btnLigneSuivante_Leave(object sender, EventArgs e)
		{
            if (m_clrBackSave != null)
                BackColor = m_clrBackSave.Value;
		}

		private void m_lnkEchange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				CResultAErreur result = m_controleParent.Maj_Champs();
				if (!result || m_operation == null)
				{
					result.EmpileErreur(I.T("The report is not valid, please correct errors to perform replacement|30183"));
					CFormAlerte.Afficher(result.Erreur);
					return;
				}
			}
			if ( m_operation != null )
			{
				CFormRemplacerEquipement.RemplaceEquipement(m_operation, m_gestionnaireModeEdition.ModeEdition);
				UpdateVisuEchange();
			}
			//CFormSaisieRemplacementEquipement.AfficheRemplacement(Operation, m_gestionnaireModeEdition.ModeEdition);
		}

		//-------------------------------------------------------------------------------------
		private void m_panelEchangeMateriel_VisibleChanged(object sender, EventArgs e)
		{
			UpdateVisuEchange();
		}

		//--------------------------------------------------------------------------------------
		private void UpdateVisuEchange()
		{
			if (m_operation != null && m_operation.IsValide() && m_operation.RemplacementAssocie != null)
            {
                m_imageOk.Visible = true;
                m_imagePasOk.Visible = false;
		    }
            else
            {
                m_imageOk.Visible = false;
                m_imagePasOk.Visible = true;
            }
		}

        //----------------------------------------------------------------------------------------
        void InitSelectEquipement()
        {
            CFiltreData filtre = null;

            if (Operation != null && Operation.TypeEquipement != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreData(
                        CTypeEquipement.c_champId + " = @1",
                        Operation.TypeEquipement.Id));
            }

            if (m_controleParent.FractionIntervention != null && 
                m_controleParent.FractionIntervention.Intervention.ElementAIntervention != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                        new CFiltreData(
                            CSite.c_champId + "=@1",
                            m_controleParent.FractionIntervention.Intervention.ElementAIntervention.Id));
            }

            m_txtSelectEquipementLie.InitAvecFiltreDeBase<CEquipement>(
                "Libelle",
                filtre,
                true);

            if (Operation != null)
                m_txtSelectEquipementLie.ElementSelectionne = Operation.Equipement;
        }

        private void m_btnActeur_Click(object sender, EventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;

            if (m_typeOperation != null && m_typeOperation.VerrouillerAuteur)
                return;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.ImageList = m_pictosActeur;

            if (m_controleParent.ElementAOperations != null)
            {
                // Item par défaut : Acteur utilisateur en cours
                CActeur acteurEnCours = CUtilSession.GetUserForSession(m_controleParent.ElementAOperations.ContexteDonnee).Acteur;
                
                ToolStripMenuItem itemParDefaut = new ToolStripMenuItem(acteurEnCours.IdentiteComplete);
                itemParDefaut.ImageIndex = 0;
                itemParDefaut.Tag = acteurEnCours;
                itemParDefaut.Click += new EventHandler(item_Click);
                menu.Items.Add(itemParDefaut);


                // ajoute les autres acteurs possibles
                if (m_controleParent.ElementAOperations is CFractionIntervention)
                {
                    // On est sur une Intervention
                    // Les acteurs possibles sont pris parmis les intervenants définit comme ressource
                    CIntervention intervention = ((CFractionIntervention)m_controleParent.ElementAOperations).Intervention;

                    ArrayList listerelationsIntervenants = intervention.RelationsIntervenants.ToArrayList();
                    if(listerelationsIntervenants.Count > 0)
                        menu.Items.Add(new ToolStripSeparator());

                    foreach (CIntervention_Intervenant rel in listerelationsIntervenants)
                    {
                        CActeur intervenant = rel.Intervenant;
                        ToolStripMenuItem item = new ToolStripMenuItem(intervenant.IdentiteComplete);
                        item.Tag = intervenant;
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);
                    }

                }
                else
                {
                    // On est sur une Phase de Ticket

                }

                menu.Items.Add(new ToolStripSeparator());

                CToolStripTextBoxSelectionneActeur selectActeurItem = new CToolStripTextBoxSelectionneActeur();
                selectActeurItem.C2iTextBoxSelectionneControl.Init<CActeur>(
                    "IdentiteComplete",
                    false);
                selectActeurItem.OnElementSelectionneChanged += new ActeurSelectionneChangedEventHandler(selectActeurItem_OnElementSelectionneChanged);
                //ToolStripMenuItem itemAutre = new ToolStripMenuItem(I.T("More...|1449"));
                //itemAutre.Tag = null;
                //itemAutre.Click += new EventHandler(item_Click);
                menu.Items.Add(selectActeurItem);

            }

            menu.Show((Control)sender, new Point(0, m_btnActeur.Height));
        }

        //---------------------------------------------------------------------------------
        void selectActeurItem_OnElementSelectionneChanged(object sender, ActeurSelectionneChangedEventArgs e)
        {
            CActeur acteur = e.Acteur;
			if (acteur != null)
			{
				// Met à jour l'acteur
				if (Operation != null)
				{
					Operation.Acteur = acteur;
				}

				m_btnActeur.Tag = acteur;
				string strIdentite = acteur.IdentiteComplete;
				m_toolTip.SetToolTip(m_btnActeur, strIdentite);
				m_lblActeur.Text = strIdentite;
			}
  
        }

        //---------------------------------------------------------------------------------
        void item_Click(object sender, EventArgs e)
        {
            // Selectionne un autre Acteur
            CActeur acteur = ((ToolStripMenuItem)sender).Tag as CActeur;

            // Met à jour l'acteur
            if (Operation != null)
            {
                Operation.Acteur = acteur;
            }

            m_btnActeur.Tag = acteur;
            string strIdentite = acteur.IdentiteComplete;
            m_toolTip.SetToolTip(m_btnActeur, strIdentite);
            m_lblActeur.Text = strIdentite;
                    
        }


        //----------------------------------------------------------------------------------
        private void InitActeur()
        {

            CActeur moi = CUtilSession.GetUserForSession(m_controleParent.ElementAOperations.ContexteDonnee).Acteur;

            if (Operation != null && Operation.Acteur != null)
            {
                m_btnActeur.Tag = Operation.Acteur;
            }
            else
            {
                m_btnActeur.Tag = moi;

            }
            string strIdentite = ((CActeur)m_btnActeur.Tag).IdentiteComplete;
            m_toolTip.SetToolTip(m_btnActeur, strIdentite);
            m_lblActeur.Text = strIdentite;

        }

        //-----------------------------------------------
        public CActeur Acteur
        {
            get
            {
                return m_btnActeur.Tag as CActeur;
            }
        }

        private void m_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            m_errorProvider.SetError(m_dtFinOperation, "");
            if (m_dateTimePicker.Visible && m_dtFinOperation.Visible)
                if (m_dtFinOperation.Value < m_dateTimePicker.Value)
                    m_errorProvider.SetError(m_dtFinOperation, I.T("End date is lower than start date|20140"));
        }

        private void CControleSaisieOperation_Enter(object sender, EventArgs e)
        {
            //m_txtTypeOperation.Focus();
        }

        private void m_btnActeur_Enter(object sender, EventArgs e)
        {
            if (m_typeOperation == null || m_typeOperation.VerrouillerAuteur)
                m_txtTypeOperation.Focus();
        }

        private void m_panelFormulaire_SizeChanged(object sender, EventArgs e)
        {
            if ( !DesignMode )
                RecalcSize();
        }

        private void m_txtTypeOperation_Enter(object sender, EventArgs e)
        {
            if (m_typeOperationParente == null &&
                m_controleParent != null &&
                m_controleParent.FractionIntervention != null &&
                m_controleParent.FractionIntervention.Intervention.TypeIntervention != m_typeInterventionArbre)
            {
                m_txtTypeOperation.Arbre = Arbre;
            }
        }



        


	}
}
