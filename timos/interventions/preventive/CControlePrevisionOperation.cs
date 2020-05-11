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

namespace timos.preventives
{
	/// <summary>
	/// Description résumée de CControlePrevisionOperation.
	/// </summary>
	public class CControlePrevisionOperation : System.Windows.Forms.UserControl, IControlALockEdition
	{
		//Table des arbres de dictionnaire par type de données parente.
		//L'arbre princial a pour cle DBNull.value.
		private static Hashtable m_tableArbres = new Hashtable();

		private bool m_bAvecEntete = false;

		private static CRecepteurNotification m_recepteurNotificationTypeDonneeModifiee = null;
		private static CRecepteurNotification m_recepteurNotificationTypeDonneeAjoutee = null;

		private CElementAVariablesDynamiques m_elementAVariables = new CElementAVariablesDynamiques();

		private CControlePrevisionsOperations m_controleParent = null;

		private int m_nIndex = 0;
		private int m_nNiveau = 0;
		private COperation m_operation = null;

		private CTypeOperation m_typeOperationParente = null;

		private CTypeOperation m_typeOperation = null;


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
		private Label label5;
		private Label label6;
		private Label label4;
        private Label label3;
		private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulaire;
		private Panel m_panelGaucheFormulaire;
		private Panel m_panelMarge;
		private Panel m_panelDroiteFormulaire;
        private Panel m_panelLieEquipement;
		private Button m_btnLigneSuivante;
        private C2iPanel c2iPanel1;
        private Label m_lblEquipement;
        private C2iTextBoxSelectionne m_txtSelectEquipementOuType;
		private IContainer components;

		public CControlePrevisionOperation( CControlePrevisionsOperations controlParent)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlePrevisionOperation));
            this.m_txtTypeOperation = new sc2i.win32.common.IntellisenseTextBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_btnInsert = new System.Windows.Forms.PictureBox();
            this.m_btnAdd = new System.Windows.Forms.PictureBox();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_panelDataStd = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_lblCode = new System.Windows.Forms.Label();
            this.m_panelEntete = new sc2i.win32.common.C2iPanel(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_panelGaucheFormulaire = new System.Windows.Forms.Panel();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_panelDroiteFormulaire = new System.Windows.Forms.Panel();
            this.m_panelLieEquipement = new System.Windows.Forms.Panel();
            this.m_txtSelectEquipementOuType = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblEquipement = new System.Windows.Forms.Label();
            this.m_btnLigneSuivante = new System.Windows.Forms.Button();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).BeginInit();
            this.m_panelPoubelle.SuspendLayout();
            this.m_panelDataStd.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            this.m_panelLieEquipement.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtTypeOperation
            // 
            this.m_txtTypeOperation.AcceptReturn = false;
            this.m_txtTypeOperation.Arbre = null;
            this.m_txtTypeOperation.AvecBouton = true;
            this.m_txtTypeOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtTypeOperation.DisableIntellisense = false;
            this.m_txtTypeOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtTypeOperation.Location = new System.Drawing.Point(50, 0);
            this.m_txtTypeOperation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypeOperation.Name = "m_txtTypeOperation";
            this.m_txtTypeOperation.ReplaceAllText = true;
            this.m_txtTypeOperation.SeparateursPrincipaux = "";
            this.m_txtTypeOperation.SeparateursSecondaires = "";
            this.m_txtTypeOperation.Size = new System.Drawing.Size(150, 25);
            this.m_txtTypeOperation.TabIndex = 0;
            this.m_txtTypeOperation.ValiderEnQuittant = true;
            this.m_txtTypeOperation.Load += new System.EventHandler(this.m_txtTypeOperation_Load);
            this.m_txtTypeOperation.OnLeaveTextBox += new System.EventHandler(this.m_txtTypeDonnee_OnLeaveTextBox);
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
            this.m_btnAdd.Location = new System.Drawing.Point(0, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
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
            this.m_panelPoubelle.Location = new System.Drawing.Point(548, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(34, 25);
            this.m_panelPoubelle.TabIndex = 9;
            // 
            // m_panelDataStd
            // 
            this.m_panelDataStd.Controls.Add(this.m_txtCommentaire);
            this.m_panelDataStd.Controls.Add(this.m_txtTypeOperation);
            this.m_panelDataStd.Controls.Add(this.m_lblCode);
            this.m_panelDataStd.Controls.Add(this.m_panelPoubelle);
            this.m_panelDataStd.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelDataStd.Location = new System.Drawing.Point(18, 22);
            this.m_panelDataStd.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDataStd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDataStd.Name = "m_panelDataStd";
            this.m_panelDataStd.Size = new System.Drawing.Size(582, 25);
            this.m_panelDataStd.TabIndex = 10;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCommentaire.Location = new System.Drawing.Point(200, 0);
            this.m_txtCommentaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(348, 25);
            this.m_txtCommentaire.TabIndex = 10;
            this.m_txtCommentaire.WordWrap = false;
            // 
            // m_lblCode
            // 
            this.m_lblCode.BackColor = System.Drawing.Color.White;
            this.m_lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblCode.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCode.Name = "m_lblCode";
            this.m_lblCode.Size = new System.Drawing.Size(50, 25);
            this.m_lblCode.TabIndex = 12;
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.label5);
            this.m_panelEntete.Controls.Add(this.label6);
            this.m_panelEntete.Controls.Add(this.label4);
            this.m_panelEntete.Controls.Add(this.label3);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(624, 22);
            this.m_panelEntete.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(200, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comments|51";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(568, 0);
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
            this.label4.Location = new System.Drawing.Point(50, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Op. type|882";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Op. code|881";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelFormulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(218, 68);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(348, 59);
            this.m_panelFormulaire.TabIndex = 12;
            // 
            // m_panelGaucheFormulaire
            // 
            this.m_panelGaucheFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelGaucheFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGaucheFormulaire.Location = new System.Drawing.Point(18, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGaucheFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGaucheFormulaire.Name = "m_panelGaucheFormulaire";
            this.m_panelGaucheFormulaire.Size = new System.Drawing.Size(200, 80);
            this.m_panelGaucheFormulaire.TabIndex = 13;
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(18, 105);
            this.m_panelMarge.TabIndex = 17;
            // 
            // m_panelDroiteFormulaire
            // 
            this.m_panelDroiteFormulaire.BackColor = System.Drawing.Color.White;
            this.m_panelDroiteFormulaire.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDroiteFormulaire.Location = new System.Drawing.Point(566, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDroiteFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDroiteFormulaire.Name = "m_panelDroiteFormulaire";
            this.m_panelDroiteFormulaire.Size = new System.Drawing.Size(34, 80);
            this.m_panelDroiteFormulaire.TabIndex = 18;
            // 
            // m_panelLieEquipement
            // 
            this.m_panelLieEquipement.BackColor = System.Drawing.Color.White;
            this.m_panelLieEquipement.Controls.Add(this.m_txtSelectEquipementOuType);
            this.m_panelLieEquipement.Controls.Add(this.m_lblEquipement);
            this.m_panelLieEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelLieEquipement.Location = new System.Drawing.Point(218, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLieEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLieEquipement.Name = "m_panelLieEquipement";
            this.m_panelLieEquipement.Size = new System.Drawing.Size(348, 21);
            this.m_panelLieEquipement.TabIndex = 19;
            // 
            // m_txtSelectEquipementOuType
            // 
            this.m_txtSelectEquipementOuType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectEquipementOuType.ElementSelectionne = null;
            this.m_txtSelectEquipementOuType.FonctionTextNull = null;
            this.m_txtSelectEquipementOuType.HasLink = true;
            this.m_txtSelectEquipementOuType.Location = new System.Drawing.Point(113, 0);
            this.m_txtSelectEquipementOuType.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectEquipementOuType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectEquipementOuType.Name = "m_txtSelectEquipementOuType";
            this.m_txtSelectEquipementOuType.SelectedObject = null;
            this.m_txtSelectEquipementOuType.Size = new System.Drawing.Size(232, 21);
            this.m_txtSelectEquipementOuType.TabIndex = 8;
            this.m_txtSelectEquipementOuType.TextNull = "";
            // 
            // m_lblEquipement
            // 
            this.m_lblEquipement.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEquipement.Name = "m_lblEquipement";
            this.m_lblEquipement.Size = new System.Drawing.Size(104, 16);
            this.m_lblEquipement.TabIndex = 7;
            this.m_lblEquipement.Text = "label1";
            // 
            // m_btnLigneSuivante
            // 
            this.m_btnLigneSuivante.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLigneSuivante.Image")));
            this.m_btnLigneSuivante.Location = new System.Drawing.Point(-1, -1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnLigneSuivante, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnLigneSuivante.Name = "m_btnLigneSuivante";
            this.m_btnLigneSuivante.Size = new System.Drawing.Size(24, 25);
            this.m_btnLigneSuivante.TabIndex = 21;
            this.m_btnLigneSuivante.UseVisualStyleBackColor = true;
            this.m_btnLigneSuivante.Click += new System.EventHandler(this.m_btnLigneSuivante_Click);
            this.m_btnLigneSuivante.Leave += new System.EventHandler(this.m_btnLigneSuivante_Leave);
            this.m_btnLigneSuivante.Enter += new System.EventHandler(this.m_btnLigneSuivante_Enter);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_btnLigneSuivante);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.c2iPanel1.Location = new System.Drawing.Point(600, 22);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(24, 105);
            this.c2iPanel1.TabIndex = 22;
            // 
            // CControlePrevisionOperation
            // 
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelLieEquipement);
            this.Controls.Add(this.m_panelDroiteFormulaire);
            this.Controls.Add(this.m_panelGaucheFormulaire);
            this.Controls.Add(this.m_panelDataStd);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.m_panelEntete);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlePrevisionOperation";
            this.Size = new System.Drawing.Size(624, 127);
            this.Load += new System.EventHandler(this.CControlePrevisionOperation_Load);
            this.Enter += new System.EventHandler(this.CControlePrevisionOperation_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).EndInit();
            this.m_panelPoubelle.ResumeLayout(false);
            this.m_panelDataStd.ResumeLayout(false);
            this.m_panelDataStd.PerformLayout();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelLieEquipement.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private class CLockerArbres
		{
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

		//------------------------------------------------------------
		private CArbreVocabulaire Arbre
		{
			get
			{
				lock ( typeof(CLockerArbres) )
				{
                    object obj = m_typeOperationParente;
                    if (m_typeOperationParente == null)
                        //obj = m_controleParent.ElementEdite.TypeIntervention;
                        obj = m_controleParent.ElementEdite.FournisseurListeTypeOperation;
					
                    CArbreVocabulaire arbre = (CArbreVocabulaire)m_tableArbres[obj];
					if ( arbre == null )
					{
						arbre = new CArbreVocabulaire ( 3,0, "" );
						arbre.TouteLaListeSurChaineVide = true;
						CListeObjetsDonnees liste;
						if ( m_typeOperationParente != null )
							liste = m_typeOperationParente.TypesOperationsFilles;
						else
						{
							liste = ((IFournisseurListeTypeOperation)obj).GetListeTypesOperations(CSc2iWin32DataClient.ContexteCourant);
                            //liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CTypeOperation) );
                            //liste.Filtre = new CFiltreDataAvance(
                            //    CTypeOperation.c_nomTable,
                            //    CTypeIntervention_TypeOperation.c_nomTable + "." +
                            //    CTypeIntervention.c_champId + "=@1",
                            //    ((CTypeIntervention)obj).Id);
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
		private CControlePrevisionsOperations ControleParent
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
		public void InitControle ( COperation operation, int nIndex, int nNiveau, bool bAvecEntete )
		{
			m_panelEntete.Visible = bAvecEntete;
			m_bAvecEntete = bAvecEntete;

			m_typeOperationParente = ControleParent.GetTypeDonneeNiveau ( nNiveau-1, nIndex );
			m_nNiveau = nNiveau;
			m_typeOperation =  null;
			m_nIndex = nIndex;
			m_txtTypeOperation.TextBox.Text = "";
			m_txtTypeOperation.Text = "";
			m_txtCommentaire.Text = "";
			//m_panelDuree.Visible = false;

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
			if (m_operation != null)
			{
				//m_txtDuree.ValeurHeure = m_operation.Duree;

				m_txtCommentaire.Text = m_operation.Commentaires;
				ChangeTypeOperation(operation.TypeOperation);
                //int nCount = operation.Remplacements.Count;
				//if (nCount > 0)
			}
			else
				ChangeTypeOperation (null);
		}

        //----------------------------------------------------------------------------------------
        void InitSelectTypeEquipement()
        {
            m_txtSelectEquipementOuType.Init<CTypeEquipement>(
                "Libelle",
                true);
            
            if(Operation != null)
                m_txtSelectEquipementOuType.ElementSelectionne = Operation.TypeEquipement;
        }

        //----------------------------------------------------------------------------------------
        void InitSelectEquipement()
        {
            CFiltreData filtre = null;
            
            if (Operation != null && Operation.TypeEquipement != null)
            {
                filtre = new CFiltreData(
                        CTypeEquipement.c_champId + " = @1",
                        Operation.TypeEquipement.Id);
            }

            if (m_controleParent.ElementEdite is CIntervention)
            {
                CIntervention inter = (CIntervention) m_controleParent.ElementEdite;
                if(inter.ElementAIntervention != null)
                    filtre = CFiltreData.GetAndFiltre(filtre,
                            new CFiltreData(
                                CSite.c_champId + "=@1", 
                                inter.ElementAIntervention.Id));
            }

            m_txtSelectEquipementOuType.InitAvecFiltreDeBase<CEquipement>(
                "Libelle",
                filtre,
                true);

            if (Operation != null)
                m_txtSelectEquipementOuType.ElementSelectionne = Operation.Equipement;
        }

        //----------------------------------------------------------------------------------------
        private void ChangeTypeOperation(CTypeOperation typeOperation)
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
				//m_panelDuree.Visible = true;
				m_panelLieEquipement.Visible = false;
				m_panelFormulaire.Visible = false;
				m_panelFormulaire.InitPanel(null, null);
			}
			else
			{
				m_lblCode.Text = m_typeOperation.Code;
				m_txtTypeOperation.Text = m_typeOperation.Libelle;
				//m_panelDuree.Visible = m_typeOperation.SaisieDureeAppliquee;
                m_panelLieEquipement.Visible = m_typeOperation.IsLieeAEquipement;
                if (bChangement)
				{
                    if (m_controleParent.ElementEdite is CListeOperations)
                    {
                        m_lblEquipement.Text = I.T( "Equipment Type|194");
                        InitSelectTypeEquipement();
                    }
                    else
                    {
                        m_lblEquipement.Text = I.T( "Equipment|195");
                        InitSelectEquipement();
                    }
                    
                    CFormulaire formulaire = m_typeOperation.FormulaireOpPrevisionnelle;
					if (formulaire != null)
					{
						object eltTmp = null;
						if (m_operation != null)
							eltTmp = m_operation;
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
			if (m_typeOperation != null && m_typeOperation.FormulaireOpPrevisionnelle!= null)
				nHeight += m_panelFormulaire.Height;
			if (m_typeOperation != null && m_typeOperation.IsLieeAEquipement)
				nHeight += m_panelLieEquipement.Height;
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
				//liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CTypeOperation));
				liste = ControleParent.ElementEdite.FournisseurListeTypeOperation.GetListeTypesOperations(CSc2iWin32DataClient.ContexteCourant);
                liste.Filtre = CFiltreData.GetAndFiltre(
                    liste.Filtre,
                    new CFiltreData(CTypeOperation.c_champLibelle + " = @1 or " +
                                    CTypeOperation.c_champCode + " = @1",
                                    m_txtTypeOperation.Text));

                //liste.Filtre = new CFiltreDataAvance(
                //    CTypeOperation.c_nomTable,
                //    CTypeIntervention_TypeOperation.c_nomTable + "." +
                //    CTypeIntervention.c_champId + "=@1 and (" +
                //    CTypeOperation.c_champLibelle + "=@2 or " +
                //    CTypeOperation.c_champCode + "=@2)",
                //    ControleOperation.ElementEdite.TypeIntervention.Id,
                //    m_txtTypeOperation.Text);
			}
			
			CTypeOperation typeDonnee =  null;
			if ( liste.Count > 0 )
				typeDonnee = (CTypeOperation)liste[0];

			return typeDonnee;
		}

		//---------------------------------------------------
		private void m_txtTypeDonnee_OnLeaveTextBox(object sender, System.EventArgs e)
		{
			if ( !m_gestionnaireModeEdition.ModeEdition )
				return;
			CTypeOperation typeDonnee = FindType ( );
			ChangeTypeOperation(typeDonnee);
			UpdateAspect();
		}


		//---------------------------------------------------
		private void CControlePrevisionOperation_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_txtTypeOperation.TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
			m_txtCommentaire.KeyDown += new KeyEventHandler(TextBox_KeyDown);
		}

		//---------------------------------------------------
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if ( (e.Modifiers & Keys.Control) == Keys.Control )
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
			if ( ControleParent.CanChangeNiveau ( m_nIndex, m_nNiveau+1 ) )
			{
				m_nNiveau++;
				OnChangeNiveau();
			}
		}

		private void OnLowLevel()
		{
			if ( ControleParent.CanChangeNiveau ( m_nIndex, m_nNiveau-1 ) )
			{
				m_nNiveau--;
				OnChangeNiveau();
			}
		}

		private void OnChangeNiveau()
		{
			int nMax = m_nNiveau * 10;
			m_panelMarge.Width = nMax;
			m_typeOperationParente = ControleParent.GetTypeDonneeNiveau ( m_nNiveau-1, m_nIndex );
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
			ControleParent.InsertAfter ( m_nIndex );
		}

		private void InsertBefore()
		{
			ControleParent.InsertBefore ( m_nIndex );
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
			if ( ControleParent.IsDernierControle ( m_nIndex ) )
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
			ControleParent.RemoveDonnee ( this );
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
                result.EmpileErreur(I.T("Invalid operation @1 |30181", m_nIndex.ToString()));
                return result;
			}				
			if ( m_typeOperation == null )
				return result;
			if ( m_typeOperation.Niveau != m_nNiveau )
			{
                result.EmpileErreur(I.T("Operation @1 : coherence problem, retry|30182", m_nIndex.ToString()));
                return result;
			}
					
			if ( m_operation == null )
			{
				m_operation = new COperation ( ControleParent.ElementEdite.ContexteDonnee );
				m_operation.CreateNewInCurrentContexte();
			}		 
			m_operation.Index = m_nIndex;
			m_operation.TypeOperation = m_typeOperation;
            //if (m_typeOperation != null && m_typeOperation.SaisieDureeAppliquee)
            //{
            //    m_operation.Duree = m_txtDuree.ValeurHeure;
            //}
			//else
				m_operation.Duree = null;
			if ( tableParentsParNiveau.Contains ( m_nNiveau-1 ) )
				m_operation.OperationParente = (COperation)tableParentsParNiveau[m_nNiveau-1];
			else
				m_operation.OperationParente = null;
			m_operation.Commentaires = m_txtCommentaire.Text;
			if (m_typeOperation != null && m_typeOperation.FormulaireOpPrevisionnelle!= null)
			{
				m_panelFormulaire.AffecteValeursToElement( m_operation );
			}
			m_operation.Index = m_nIndex;
			m_operation.Niveau = m_nNiveau;
            m_operation.ElementAOperationPrevisionnelle = ControleParent.ElementEdite;

            if (m_txtSelectEquipementOuType.ElementSelectionne is CTypeEquipement)
                Operation.TypeEquipement = (CTypeEquipement)m_txtSelectEquipementOuType.ElementSelectionne;
            else
                Operation.Equipement = (CEquipement)m_txtSelectEquipementOuType.ElementSelectionne;

            result = Operation.VerifieDonnees(false);


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
			UpdateAspect();
		}

		private void m_btnLigneSuivante_Leave(object sender, EventArgs e)
		{
		}

        private void CControlePrevisionOperation_Enter(object sender, EventArgs e)
        {
            ControleParent.ControlActif = this;            
        }


	}
}
