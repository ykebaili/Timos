using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using sc2i.common;
using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.win32.common;
using timos.Controles.notifications;


namespace timos
{
	[ObjectListeur(typeof(CBesoinInterventionProcess))]
	public class CFormListeActionsUtilisateur : CFormListeStandardTimos, IFormNavigable
	{
		private System.Windows.Forms.PictureBox m_imageExecuter;
		private System.Windows.Forms.LinkLabel m_lnkExecuter;
		private System.Windows.Forms.LinkLabel m_lnkAnnuler;
		private System.Windows.Forms.PictureBox m_btnAnnuler;
        private C2iPanelFondDegradeStd c2iPanelFondDegradeStd1;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeActionsUtilisateur()
			:base(typeof(CBesoinInterventionProcess))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeActionsUtilisateur));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_imageExecuter = new System.Windows.Forms.PictureBox();
            this.m_lnkExecuter = new System.Windows.Forms.LinkLabel();
            this.m_btnAnnuler = new System.Windows.Forms.PictureBox();
            this.m_lnkAnnuler = new System.Windows.Forms.LinkLabel();
            this.c2iPanelFondDegradeStd1 = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_panelMilieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageExecuter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAnnuler)).BeginInit();
            this.c2iPanelFondDegradeStd1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            this.m_panelListe.BoutonAjouterVisible = false;
            this.m_panelListe.BoutonExporterVisible = false;
            this.m_panelListe.BoutonModifierVisible = false;
            this.m_panelListe.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "DateDemande";
            glColumn1.Text = "Date";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namex";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 400;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_panelListe.Size = new System.Drawing.Size(534, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(534, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(534, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(534, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.c2iPanelFondDegradeStd1);
            this.m_panelMilieu.Size = new System.Drawing.Size(534, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.c2iPanelFondDegradeStd1, 0);
            // 
            // m_imageExecuter
            // 
            this.m_imageExecuter.BackColor = System.Drawing.Color.Transparent;
            this.m_imageExecuter.Image = ((System.Drawing.Image)(resources.GetObject("m_imageExecuter.Image")));
            this.m_imageExecuter.Location = new System.Drawing.Point(9, 7);
            this.m_imageExecuter.Name = "m_imageExecuter";
            this.m_imageExecuter.Size = new System.Drawing.Size(16, 15);
            this.m_imageExecuter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_imageExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageExecuter.TabIndex = 2;
            this.m_imageExecuter.TabStop = false;
            // 
            // m_lnkExecuter
            // 
            this.m_lnkExecuter.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkExecuter.Location = new System.Drawing.Point(22, 6);
            this.m_lnkExecuter.Name = "m_lnkExecuter";
            this.m_lnkExecuter.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkExecuter.TabIndex = 3;
            this.m_lnkExecuter.TabStop = true;
            this.m_lnkExecuter.Text = "Run|15";
            this.m_lnkExecuter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkExecuter_LinkClicked);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(107, 6);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(16, 16);
            this.m_btnAnnuler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 5;
            this.m_btnAnnuler.TabStop = false;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_lnkAnnuler
            // 
            this.m_lnkAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkAnnuler.Location = new System.Drawing.Point(129, 6);
            this.m_lnkAnnuler.Name = "m_lnkAnnuler";
            this.m_lnkAnnuler.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAnnuler.TabIndex = 6;
            this.m_lnkAnnuler.TabStop = true;
            this.m_lnkAnnuler.Text = "Cancel|11";
            this.m_lnkAnnuler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAnnuler_LinkClicked);
            // 
            // c2iPanelFondDegradeStd1
            // 
            this.c2iPanelFondDegradeStd1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("c2iPanelFondDegradeStd1.BackgroundImage")));
            this.c2iPanelFondDegradeStd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lnkExecuter);
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lnkAnnuler);
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_btnAnnuler);
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_imageExecuter);
            this.c2iPanelFondDegradeStd1.Location = new System.Drawing.Point(92, -1);
            this.c2iPanelFondDegradeStd1.Name = "c2iPanelFondDegradeStd1";
            this.c2iPanelFondDegradeStd1.Size = new System.Drawing.Size(257, 26);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelFondDegradeStd1.TabIndex = 7;
            // 
            // CFormListeActionsUtilisateur
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BoutonAjouterVisible = false;
            this.BoutonModifierVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(534, 376);
            this.Name = "CFormListeActionsUtilisateur";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageExecuter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAnnuler)).EndInit();
            this.c2iPanelFondDegradeStd1.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
            //TESTDBKEYOK
			m_panelListe.FiltreDeBase = new CFiltreData(
				CBesoinInterventionProcess.c_champKeyUtilisateur+"=@1",
				CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur.StringValue );
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CBesoinInterventionProcess),	
				null,
				null, "");
			m_panelListe.OnObjetDoubleClick += new EventHandler(OnDoubleClick);

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
		protected void OnDoubleClick ( object sender, EventArgs args )
		{
			LanceInterventionSelectionnee();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Standby Actions list|752");
		}
		//-------------------------------------------------------------------
		protected void LanceInterventionSelectionnee()
		{
			CBesoinInterventionProcess besoin = (CBesoinInterventionProcess)m_panelListe.ElementSelectionne;
			if ( besoin == null )
				return;
            CResultAErreur result = CExecuteurNotificationBesoinUtilisateur.ExecuteBesoinInterventionProcess(besoin.Id);
			if ( result )
			{
				besoin.Delete();
				m_panelListe.RemplirGrille();
			}
			else
			{
				CFormAlerte.Afficher ( result.Erreur );
				if ( CFormAlerte.Afficher(I.T( "Remove Action ?|753"),
					EFormAlerteType.Question ) == DialogResult.Yes )
				{
					besoin.Delete();
					m_panelListe.RemplirGrille();
				}
			}
		}

		//-------------------------------------------------------------------
		private void m_lnkExecuter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LanceInterventionSelectionnee();
		}

		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			AnnuleInterventionSelectionnee();
		}

		private void m_lnkAnnuler_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AnnuleInterventionSelectionnee();
		}

		private void AnnuleInterventionSelectionnee()
		{
			CBesoinInterventionProcess besoin = (CBesoinInterventionProcess)m_panelListe.ElementSelectionne;
			if ( besoin == null )
				return;
			CResultAErreur result = CResultAErreur.True;
			result = besoin.ProcessEnExecution.AnnuleReprise ( CTimosApp.SessionClient.GetInfoUtilisateur().NomUtilisateur );
			if ( result )
			{
				besoin.Delete();
				m_panelListe.RemplirGrille();
			}
			else
			{
				CFormAlerte.Afficher ( result.Erreur );
			}
		}
	}
}

