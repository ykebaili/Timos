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

using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos
{
	/// <summary>
	/// Description résumée de CControleSaisieUneActiviteActeur.
	/// </summary>
	public class CControleSaisieUneActiviteActeur : System.Windows.Forms.UserControl, IControlALockEdition
	{
		//Table des arbres de dictionnaire par type de données parente.
		//L'arbre princial a pour cle DBNull.value.
		private static CArbreVocabulaire m_arbreVocabulaire = null;

		private bool m_bAvecEntete = false;

		private static CRecepteurNotification m_recepteurNotificationTypeDonneeModifiee = null;
		private static CRecepteurNotification m_recepteurNotificationTypeDonneeAjoutee = null;

		private CElementAVariablesDynamiques m_elementAVariables = new CElementAVariablesDynamiques();

		private CControleSaisieDesActivitesActeur m_controleParent = null;

		private int m_nIndex = 0;
		private CActiviteActeur m_activite = null;

		private CTypeActiviteActeur m_typeActivite = null;


		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.IntellisenseTextBox m_txtTypeActivite;
		private System.Windows.Forms.PictureBox m_btnPoubelle;
		private System.Windows.Forms.PictureBox m_btnInsert;
		private System.Windows.Forms.PictureBox m_btnAdd;
		private System.Windows.Forms.Panel m_panelPoubelle;
		private C2iPanel m_panelDataStd;
		private C2iPanel m_panelEntete;
		private C2iTextBox m_txtCommentaire;
		private C2iPanel m_panelContientLaDurée;
		private Label label5;
		private Label label6;
		private Label label4;
		private Label label1;
		private Panel m_panelDuree;
		private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulaire;
		private Panel m_panelGaucheFormulaire;
		private Panel m_panelDroiteFormulaire;
		private Button m_btnLigneSuivante;
		private C2iPanel c2iPanel1;
		private Panel m_zoneSite;
		private C2iTextBoxSelectionne m_txtSelectSite;
		private Label label7;
		private C2iDateTimePicker m_wndDate;
		private Label lbl_date;
		private CWndSaisieHeure m_txtDuree;
        private Timer m_timerSize;
		private IContainer components;

		public CControleSaisieUneActiviteActeur( CControleSaisieDesActivitesActeur controlParent)
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
			m_controleParent = controlParent;

			if ( !DesignMode )
				InitRecepteurs();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleSaisieUneActiviteActeur));
            this.m_txtTypeActivite = new sc2i.win32.common.IntellisenseTextBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_btnInsert = new System.Windows.Forms.PictureBox();
            this.m_btnAdd = new System.Windows.Forms.PictureBox();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_panelDataStd = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_zoneSite = new System.Windows.Forms.Panel();
            this.m_txtSelectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelContientLaDurée = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelDuree = new System.Windows.Forms.Panel();
            this.m_txtDuree = new sc2i.win32.common.CWndSaisieHeure();
            this.m_wndDate = new sc2i.win32.common.C2iDateTimePicker();
            this.m_panelEntete = new sc2i.win32.common.C2iPanel(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_panelGaucheFormulaire = new System.Windows.Forms.Panel();
            this.m_panelDroiteFormulaire = new System.Windows.Forms.Panel();
            this.m_btnLigneSuivante = new System.Windows.Forms.Button();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_timerSize = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).BeginInit();
            this.m_panelPoubelle.SuspendLayout();
            this.m_panelDataStd.SuspendLayout();
            this.m_zoneSite.SuspendLayout();
            this.m_panelContientLaDurée.SuspendLayout();
            this.m_panelDuree.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtTypeActivite
            // 
            this.m_txtTypeActivite.AcceptReturn = false;
            this.m_txtTypeActivite.Arbre = null;
            this.m_txtTypeActivite.AvecBouton = true;
            this.m_txtTypeActivite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtTypeActivite.DisableIntellisense = false;
            this.m_txtTypeActivite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtTypeActivite.Location = new System.Drawing.Point(84, 0);
            this.m_txtTypeActivite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeActivite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypeActivite.Name = "m_txtTypeActivite";
            this.m_txtTypeActivite.ReplaceAllText = true;
            this.m_txtTypeActivite.SeparateursPrincipaux = "";
            this.m_txtTypeActivite.SeparateursSecondaires = "";
            this.m_txtTypeActivite.Size = new System.Drawing.Size(155, 25);
            this.m_txtTypeActivite.TabIndex = 1;
            this.m_txtTypeActivite.ValiderEnQuittant = true;
            this.m_txtTypeActivite.Load += new System.EventHandler(this.m_txtTypeActivite_Load);
            this.m_txtTypeActivite.OnLeaveTextBox += new System.EventHandler(this.m_txtTypeDonnee_OnLeaveTextBox);
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(16, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 24);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 6;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // m_btnInsert
            // 
            this.m_btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnInsert.BackColor = System.Drawing.Color.Lime;
            this.m_btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("m_btnInsert.Image")));
            this.m_btnInsert.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnInsert, sc2i.win32.common.TypeModeEdition.Autonome);
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
            this.m_btnAdd.Location = new System.Drawing.Point(0, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAdd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(16, 12);
            this.m_btnAdd.TabIndex = 8;
            this.m_btnAdd.TabStop = false;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_panelPoubelle
            // 
            this.m_panelPoubelle.BackColor = System.Drawing.Color.White;
            this.m_panelPoubelle.Controls.Add(this.m_btnInsert);
            this.m_panelPoubelle.Controls.Add(this.m_btnAdd);
            this.m_panelPoubelle.Controls.Add(this.m_btnPoubelle);
            this.m_panelPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelPoubelle.Location = new System.Drawing.Point(837, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(34, 25);
            this.m_panelPoubelle.TabIndex = 9;
            // 
            // m_panelDataStd
            // 
            this.m_panelDataStd.Controls.Add(this.m_txtCommentaire);
            this.m_panelDataStd.Controls.Add(this.m_zoneSite);
            this.m_panelDataStd.Controls.Add(this.m_panelContientLaDurée);
            this.m_panelDataStd.Controls.Add(this.m_txtTypeActivite);
            this.m_panelDataStd.Controls.Add(this.m_panelPoubelle);
            this.m_panelDataStd.Controls.Add(this.m_wndDate);
            this.m_panelDataStd.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelDataStd.Location = new System.Drawing.Point(0, 22);
            this.m_panelDataStd.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDataStd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDataStd.Name = "m_panelDataStd";
            this.m_panelDataStd.Size = new System.Drawing.Size(871, 25);
            this.m_panelDataStd.TabIndex = 0;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCommentaire.Location = new System.Drawing.Point(557, 0);
            this.m_txtCommentaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(280, 25);
            this.m_txtCommentaire.TabIndex = 4;
            this.m_txtCommentaire.WordWrap = false;
            // 
            // m_zoneSite
            // 
            this.m_zoneSite.BackColor = System.Drawing.Color.White;
            this.m_zoneSite.Controls.Add(this.m_txtSelectSite);
            this.m_zoneSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_zoneSite.Location = new System.Drawing.Point(311, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_zoneSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_zoneSite.Name = "m_zoneSite";
            this.m_zoneSite.Size = new System.Drawing.Size(246, 25);
            this.m_zoneSite.TabIndex = 3;
            // 
            // m_txtSelectSite
            // 
            this.m_txtSelectSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectSite.ElementSelectionne = null;
            this.m_txtSelectSite.FonctionTextNull = null;
            this.m_txtSelectSite.HasLink = true;
            this.m_txtSelectSite.Location = new System.Drawing.Point(0, 0);
            this.m_txtSelectSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectSite.Name = "m_txtSelectSite";
            this.m_txtSelectSite.SelectedObject = null;
            this.m_txtSelectSite.Size = new System.Drawing.Size(246, 25);
            this.m_txtSelectSite.TabIndex = 0;
            this.m_txtSelectSite.TextNull = "";
            // 
            // m_panelContientLaDurée
            // 
            this.m_panelContientLaDurée.BackColor = System.Drawing.Color.White;
            this.m_panelContientLaDurée.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelContientLaDurée.Controls.Add(this.m_panelDuree);
            this.m_panelContientLaDurée.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelContientLaDurée.Location = new System.Drawing.Point(239, 0);
            this.m_panelContientLaDurée.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContientLaDurée, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelContientLaDurée.Name = "m_panelContientLaDurée";
            this.m_panelContientLaDurée.Size = new System.Drawing.Size(72, 25);
            this.m_panelContientLaDurée.TabIndex = 2;
            this.m_panelContientLaDurée.TabStop = true;
            // 
            // m_panelDuree
            // 
            this.m_panelDuree.Controls.Add(this.m_txtDuree);
            this.m_panelDuree.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDuree, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDuree.Name = "m_panelDuree";
            this.m_panelDuree.Size = new System.Drawing.Size(70, 26);
            this.m_panelDuree.TabIndex = 1;
            this.m_panelDuree.TabStop = true;
            // 
            // m_txtDuree
            // 
            this.m_txtDuree.Location = new System.Drawing.Point(2, 2);
            this.m_txtDuree.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDuree.Name = "m_txtDuree";
            this.m_txtDuree.NullAutorise = true;
            this.m_txtDuree.SaisieDuree = true;
            this.m_txtDuree.Size = new System.Drawing.Size(63, 21);
            this.m_txtDuree.TabIndex = 2;
            this.m_txtDuree.ValeurHeure = null;
            // 
            // m_wndDate
            // 
            this.m_wndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_wndDate.Location = new System.Drawing.Point(0, 0);
            this.m_wndDate.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndDate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndDate.Name = "m_wndDate";
            this.m_wndDate.Size = new System.Drawing.Size(84, 20);
            this.m_wndDate.TabIndex = 0;
            this.m_wndDate.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.label5);
            this.m_panelEntete.Controls.Add(this.label7);
            this.m_panelEntete.Controls.Add(this.label1);
            this.m_panelEntete.Controls.Add(this.label6);
            this.m_panelEntete.Controls.Add(this.label4);
            this.m_panelEntete.Controls.Add(this.lbl_date);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(895, 22);
            this.m_panelEntete.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(557, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comment|51";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(311, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Site|175";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(239, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Duration|548";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(839, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 22);
            this.label6.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(84, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activity Type|547";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_date
            // 
            this.lbl_date.BackColor = System.Drawing.Color.White;
            this.lbl_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_date.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_date.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_date, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(84, 22);
            this.lbl_date.TabIndex = 8;
            this.lbl_date.Text = "Date|246";
            this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelFormulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(217, 47);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(620, 16);
            this.m_panelFormulaire.TabIndex = 1;
            this.m_panelFormulaire.SizeChanged += new System.EventHandler(this.m_panelFormulaire_SizeChanged);
            // 
            // m_panelGaucheFormulaire
            // 
            this.m_panelGaucheFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelGaucheFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGaucheFormulaire.Location = new System.Drawing.Point(0, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGaucheFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGaucheFormulaire.Name = "m_panelGaucheFormulaire";
            this.m_panelGaucheFormulaire.Size = new System.Drawing.Size(217, 19);
            this.m_panelGaucheFormulaire.TabIndex = 13;
            // 
            // m_panelDroiteFormulaire
            // 
            this.m_panelDroiteFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelDroiteFormulaire.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDroiteFormulaire.Location = new System.Drawing.Point(837, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDroiteFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDroiteFormulaire.Name = "m_panelDroiteFormulaire";
            this.m_panelDroiteFormulaire.Size = new System.Drawing.Size(34, 19);
            this.m_panelDroiteFormulaire.TabIndex = 18;
            // 
            // m_btnLigneSuivante
            // 
            this.m_btnLigneSuivante.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLigneSuivante.Image")));
            this.m_btnLigneSuivante.Location = new System.Drawing.Point(-1, -1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnLigneSuivante, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnLigneSuivante.Name = "m_btnLigneSuivante";
            this.m_btnLigneSuivante.Size = new System.Drawing.Size(24, 25);
            this.m_btnLigneSuivante.TabIndex = 0;
            this.m_btnLigneSuivante.UseVisualStyleBackColor = true;
            this.m_btnLigneSuivante.Click += new System.EventHandler(this.m_btnLigneSuivante_Click);
            this.m_btnLigneSuivante.Leave += new System.EventHandler(this.m_btnLigneSuivante_Leave);
            this.m_btnLigneSuivante.Enter += new System.EventHandler(this.m_btnLigneSuivante_Enter);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_btnLigneSuivante);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.c2iPanel1.Location = new System.Drawing.Point(871, 22);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(24, 44);
            this.c2iPanel1.TabIndex = 2;
            // 
            // m_timerSize
            // 
            this.m_timerSize.Tick += new System.EventHandler(this.m_timerSize_Tick);
            // 
            // CControleSaisieUneActiviteActeur
            // 
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelDroiteFormulaire);
            this.Controls.Add(this.m_panelGaucheFormulaire);
            this.Controls.Add(this.m_panelDataStd);
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.m_panelEntete);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleSaisieUneActiviteActeur";
            this.Size = new System.Drawing.Size(895, 66);
            this.Load += new System.EventHandler(this.CControleSaisieUneActiviteActeur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).EndInit();
            this.m_panelPoubelle.ResumeLayout(false);
            this.m_panelDataStd.ResumeLayout(false);
            this.m_panelDataStd.PerformLayout();
            this.m_zoneSite.ResumeLayout(false);
            this.m_panelContientLaDurée.ResumeLayout(false);
            this.m_panelDuree.ResumeLayout(false);
            this.m_panelEntete.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private class CLockerArbres
		{
		}

		//------------------------------------------------------------
		public CTypeActiviteActeur TypeActivite
		{
			get
			{
				return m_typeActivite;
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
				if (donneeAjout.NomTable == CTypeActiviteActeur.c_nomTable )
				{
					lock (typeof(CLockerArbres))
					{
						m_arbreVocabulaire = null;
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
				if (info.NomTable == CTypeActiviteActeur.c_nomTable)
				{
					lock (typeof(CLockerArbres))
					{
						m_arbreVocabulaire = null;
					}
					return;
				}
			}
		}

		//------------------------------------------------------------
		private CArbreVocabulaire Arbre
		{
			get
			{
				lock ( typeof(CLockerArbres) )
				{
					CArbreVocabulaire arbre = m_arbreVocabulaire;
					if ( arbre == null )
					{
						arbre = new CArbreVocabulaire ( 3,0, "" );
						arbre.TouteLaListeSurChaineVide = true;
						CListeObjetsDonnees liste;
						liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CTypeActiviteActeur) );
						liste.Filtre = new CFiltreData(CTypeActiviteActeur.c_champReadOnly + "=@1", 0);
						foreach (CTypeActiviteActeur typeOp in liste)
						{
							arbre.StockeMot(typeOp.Libelle, typeOp.Code);
						}
						m_arbreVocabulaire = arbre ;
					}
					return arbre;
				}
			}
		}

		//---------------------------------------------------
		private CControleSaisieDesActivitesActeur ControleActivites
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

		
		//---------------------------------------------------
		public void InitControle ( CActiviteActeur activite, int nIndex, bool bAvecEntete )
		{
            CWin32Traducteur.Translate(this);
			m_panelEntete.Visible = bAvecEntete;
			m_bAvecEntete = bAvecEntete;

			m_typeActivite =  null;
			m_nIndex = nIndex;
			m_txtTypeActivite.TextBox.Text = "";
			m_txtTypeActivite.Text = "";
			m_txtCommentaire.Text = "";
			m_panelDuree.Visible = false;

			m_txtSelectSite.Init<CSite>(
				"Libelle",
				false);
			FillWithActivite(activite);
			UpdateAspect();
			m_txtTypeActivite.Arbre = Arbre;
			
			if ( m_controleParent != null)
				LockEdition = m_controleParent.LockEdition;
		}

		public DateTime DateActivite
		{
			get
			{
				return m_wndDate.Value;
			}
			set
			{
				m_wndDate.Value = value;
			}
		}

		private void FillWithActivite(CActiviteActeur activite)
		{
			m_activite = activite;
			m_typeActivite = null;
			if (m_activite != null)
			{
				ChangeTypeActivite(activite.TypeActiviteActeur);
				m_txtDuree.ValeurHeure = m_activite.Duree;
				m_txtSelectSite.ElementSelectionne = m_activite.Site;
				m_wndDate.Value = m_activite.Date;
				m_txtCommentaire.Text = m_activite.Commentaires;
				
			}
			else
				ChangeTypeActivite ( null );
		}

		private void ChangeTypeActivite ( CTypeActiviteActeur typeActivite )
		{
			bool bChangement = false;
			if (typeActivite == null && m_typeActivite != null ||
				 m_typeActivite == null && typeActivite != null)
				bChangement = true;
			if (m_typeActivite != null && !m_typeActivite.Equals(typeActivite))
				bChangement = true;

			m_typeActivite = typeActivite;


			if (m_typeActivite == null)
			{
				m_txtTypeActivite.Text = "";
				m_panelDuree.Visible = true;
				m_panelFormulaire.Visible = false;
				m_txtSelectSite.Visible = true;
				m_panelFormulaire.InitPanel(null, null);
			}
			else
			{
				m_txtSelectSite.Visible = typeActivite.SiteObligatoire;
				//m_wndDate.Value = Activite.Date;
				m_txtTypeActivite.Text = m_typeActivite.Libelle;
				m_panelDuree.Visible = m_typeActivite.SaisieDuree;
				if (bChangement)
				{
					CFormulaire formulaire = m_typeActivite.Formulaire;
					if (formulaire != null)
					{
						object eltTmp = null;
						if (m_activite != null)
							eltTmp = m_activite;
						else
							eltTmp = m_elementAVariables;
						m_panelFormulaire.Size = formulaire.Formulaire.Size;
						if (m_panelFormulaire.Visible)
							m_panelFormulaire.AffecteValeursToElement();
						m_panelFormulaire.InitPanel(formulaire.Formulaire, eltTmp);
						m_panelFormulaire.Visible = true;
					}
					else
						m_panelFormulaire.Visible = false;
				}
			}
			RecalcSize();
		}

		//---------------------------------------------------
		private void UpdateAspect()
		{
			if (m_typeActivite == null)
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
            m_timerSize.Stop();
			int nHeight = m_panelDataStd.Height;
			if ( m_bAvecEntete )
				nHeight += m_panelEntete.Height;
			if (m_typeActivite != null && m_typeActivite.Formulaire != null)
				nHeight += m_panelFormulaire.Height;
			Height = nHeight;
		}

		//---------------------------------------------------
		private CTypeActiviteActeur FindType (  )
		{
			if (m_txtTypeActivite.Text == "")
				return null;
			CListeObjetsDonnees liste;
			liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CTypeActiviteActeur));
			liste.Filtre = new CFiltreData(
				CTypeActiviteActeur.c_champLibelle + "=@1 or " +
				CTypeActiviteActeur.c_champCode + "=@1",
				m_txtTypeActivite.Text);
			CTypeActiviteActeur typeDonnee =  null;
			if ( liste.Count > 0 )
				typeDonnee = (CTypeActiviteActeur)liste[0];

			return typeDonnee;
		}

		//---------------------------------------------------
		private void m_txtTypeDonnee_OnLeaveTextBox(object sender, System.EventArgs e)
		{
			if ( !m_gestionnaireModeEdition.ModeEdition )
				return;
			CTypeActiviteActeur typeDonnee = FindType ( );
			ChangeTypeActivite(typeDonnee);
			UpdateAspect();
		}


		//---------------------------------------------------
		private void CControleSaisieUneActiviteActeur_Load(object sender, System.EventArgs e)
		{
			CWin32Traducteur.Translate(this);
			m_txtTypeActivite.TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
			m_txtCommentaire.KeyDown += new KeyEventHandler(TextBox_KeyDown);
		}

		//---------------------------------------------------
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if ( (e.Modifiers & Keys.Control) == Keys.Control )
			{
				switch ( e.KeyCode )
				{
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
			ControleActivites.InsertAfter ( m_nIndex );
		}

		private void InsertBefore()
		{
			ControleActivites.InsertBefore ( m_nIndex );
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
				if (m_typeActivite != null && m_typeActivite.ReadOnly || 
					m_activite != null && (m_activite.RelationsInterventions.Count != 0 || m_activite.ReadOnly))
					m_gestionnaireModeEdition.ModeEdition = false;
				else
					m_gestionnaireModeEdition.ModeEdition = !value;
				m_btnInsert.Enabled = !value;
				m_btnAdd.Enabled = !value;
				m_btnLigneSuivante.Enabled = !value;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

		public bool ControleDonnees()
		{
			bool bResult = true;
			if ( m_typeActivite == null )
				bResult = false;
			if ( !bResult )
				BackColor = Color.Red;
			else
				BackColor = Parent.BackColor;			
			return bResult;
		}

		private void m_wndUnite_Leave(object sender, System.EventArgs e)
		{
			if ( ControleActivites.IsDernierControle ( m_nIndex ) )
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
				if ( CFormAlerte.Afficher(I.T("Delete the data ? |30180"), EFormAlerteType.Question)
					== DialogResult.No )
				{
					return;
				}
			}
			ControleActivites.RemoveActivite ( this );
		}

		//---------------------------------------------------
		public string Libelle
		{
			get
			{
				return m_txtTypeActivite.Text.Trim();
			}
		}
		
		
		//-----------------------------------------
		public CResultAErreur Maj_Champs( )
		{
			CResultAErreur result = CResultAErreur.True;
			
			if ( m_typeActivite == null && 
				(m_txtCommentaire.Text != "" ))
			{
				ControleDonnees();
				result.EmpileErreur ( I.T("Invalid Activiy @1|30190",m_nIndex.ToString()));
				return result;
			}				
			if ( m_typeActivite == null )
				return result;
					
            if (m_activite != null && m_activite.ReadOnly)
                return result;

			if ( m_activite == null )
			{
				m_activite = new CActiviteActeur ( ControleActivites.Acteur.ContexteDonnee );
				m_activite.CreateNewInCurrentContexte();
			}

			m_activite.Acteur = ControleActivites.Acteur;
			m_activite.TypeActiviteActeur = m_typeActivite;
			if (m_typeActivite.SiteObligatoire)
			{
				if (m_txtSelectSite.ElementSelectionne is CSite)
					m_activite.Site = (CSite)m_txtSelectSite.ElementSelectionne;
				else
					result.EmpileErreur(I.T("Enter a site|30191"));
			}
			else
				m_activite.Site = null;
			if (m_typeActivite != null && m_typeActivite.SaisieDuree)
				m_activite.Duree = m_txtDuree.ValeurHeure;
			else
				m_activite.Duree = null;
			m_activite.Commentaires = m_txtCommentaire.Text;
			if (m_typeActivite != null && m_typeActivite.Formulaire != null)
			{
				m_panelFormulaire.AffecteValeursToElement( m_activite );
			}
			m_activite.Date = m_wndDate.Value;
			return result;
			
		}

		//-----------------------------------------
		public CActiviteActeur Activite
		{
			get
			{
				return m_activite;
			}
			set
			{
				m_activite =  value;
			}
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

		private void m_txtTypeActivite_Load(object sender, EventArgs e)
		{

		}

		private void m_btnLigneSuivante_Click(object sender, EventArgs e)
		{
			InsertAfter();
		}

		private void m_btnLigneSuivante_Enter(object sender, EventArgs e)
		{
			UpdateAspect();
			m_btnLigneSuivante.BackColor = Color.Yellow;
		}

		private void m_btnLigneSuivante_Leave(object sender, EventArgs e)
		{
			m_btnLigneSuivante.BackColor = BackColor;
		}

        private void m_panelFormulaire_SizeChanged(object sender, EventArgs e)
        {
            RecalcSizeDelayed();
        }

        private void RecalcSizeDelayed()
        {
            m_timerSize.Stop();
            m_timerSize.Start();
        }

        private void m_timerSize_Tick(object sender, EventArgs e)
        {
            RecalcSize();
        }

	}
}
