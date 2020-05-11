namespace timos.win32.composants
{
	partial class CPanelEditPhasesTicket
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditPhasesTicket));
			sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique3 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
			sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique3 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
			this.m_panelHaut = new System.Windows.Forms.Panel();
			this.m_selectTypePhase = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_panelControles = new System.Windows.Forms.Panel();
			this.m_chkPhase = new System.Windows.Forms.RadioButton();
			this.m_chkLien = new System.Windows.Forms.RadioButton();
			this.m_chkCurseur = new System.Windows.Forms.RadioButton();
			this.m_lblTypePhase = new System.Windows.Forms.Label();
			this.m_panelDroite = new System.Windows.Forms.Panel();
			this.m_panelDetailPhase = new System.Windows.Forms.Panel();
			this.m_chkPhaseFinale = new System.Windows.Forms.CheckBox();
			this.m_chkPhaseDemarrage = new System.Windows.Forms.CheckBox();
			this.m_lblPhase = new System.Windows.Forms.Label();
			this.m_panelLien = new sc2i.win32.common.C2iPanel(this.components);
			this.m_lblCondition = new System.Windows.Forms.Label();
			this.m_wndFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
			this.m_lblPhase2 = new System.Windows.Forms.Label();
			this.m_lblPhase1 = new System.Windows.Forms.Label();
			this.m_lblA = new System.Windows.Forms.Label();
			this.m_lblDe = new System.Windows.Forms.Label();
			this.m_splitterPanelEdition = new System.Windows.Forms.Splitter();
			this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_controlEdition = new timos.win32.composants.CControlEditionPhasesDeTicket();
			this.m_panelHaut.SuspendLayout();
			this.m_panelControles.SuspendLayout();
			this.m_panelDroite.SuspendLayout();
			this.m_panelDetailPhase.SuspendLayout();
			this.m_panelLien.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelHaut
			// 
			this.m_panelHaut.Controls.Add(this.m_selectTypePhase);
			this.m_panelHaut.Controls.Add(this.m_lblTypePhase);
			this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
			this.m_extModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelHaut.Name = "m_panelHaut";
			this.m_panelHaut.Size = new System.Drawing.Size(417, 31);
			this.m_panelHaut.TabIndex = 1;
			// 
			// m_selectTypePhase
			// 
			this.m_selectTypePhase.ElementSelectionne = null;
			this.m_selectTypePhase.FonctionTextNull = null;
			this.m_selectTypePhase.HasLink = true;
			this.m_selectTypePhase.Location = new System.Drawing.Point(112, 1);
			this.m_selectTypePhase.LockEdition = true;
			this.m_extModeEdition.SetModeEdition(this.m_selectTypePhase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectTypePhase.Name = "m_selectTypePhase";
			this.m_selectTypePhase.SelectedObject = null;
			this.m_selectTypePhase.Size = new System.Drawing.Size(310, 21);
			this.m_selectTypePhase.TabIndex = 5;
			this.m_selectTypePhase.TextNull = "";
			this.m_selectTypePhase.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypePhase_OnSelectedObjectChanged);
			// 
			// m_panelControles
			// 
			this.m_panelControles.Controls.Add(this.m_chkPhase);
			this.m_panelControles.Controls.Add(this.m_chkLien);
			this.m_panelControles.Controls.Add(this.m_chkCurseur);
			this.m_panelControles.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelControles.Location = new System.Drawing.Point(0, 31);
			this.m_extModeEdition.SetModeEdition(this.m_panelControles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelControles.Name = "m_panelControles";
			this.m_panelControles.Size = new System.Drawing.Size(417, 36);
			this.m_panelControles.TabIndex = 4;
			// 
			// m_chkPhase
			// 
			this.m_chkPhase.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_chkPhase.Image = ((System.Drawing.Image)(resources.GetObject("m_chkPhase.Image")));
			this.m_chkPhase.Location = new System.Drawing.Point(37, 2);
			this.m_extModeEdition.SetModeEdition(this.m_chkPhase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkPhase.Name = "m_chkPhase";
			this.m_chkPhase.Size = new System.Drawing.Size(32, 32);
			this.m_chkPhase.TabIndex = 9;
			// 
			// m_chkLien
			// 
			this.m_chkLien.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_chkLien.Image = ((System.Drawing.Image)(resources.GetObject("m_chkLien.Image")));
			this.m_chkLien.Location = new System.Drawing.Point(68, 2);
			this.m_extModeEdition.SetModeEdition(this.m_chkLien, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkLien.Name = "m_chkLien";
			this.m_chkLien.Size = new System.Drawing.Size(32, 32);
			this.m_chkLien.TabIndex = 8;
			this.m_chkLien.CheckedChanged += new System.EventHandler(this.m_chkLien_CheckedChanged);
			// 
			// m_chkCurseur
			// 
			this.m_chkCurseur.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_chkCurseur.Image = ((System.Drawing.Image)(resources.GetObject("m_chkCurseur.Image")));
			this.m_chkCurseur.Location = new System.Drawing.Point(5, 2);
			this.m_extModeEdition.SetModeEdition(this.m_chkCurseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkCurseur.Name = "m_chkCurseur";
			this.m_chkCurseur.Size = new System.Drawing.Size(32, 32);
			this.m_chkCurseur.TabIndex = 6;
			this.m_chkCurseur.CheckedChanged += new System.EventHandler(this.m_chkCurseur_CheckedChanged);
			// 
			// m_lblTypePhase
			// 
			this.m_lblTypePhase.AutoSize = true;
			this.m_lblTypePhase.Location = new System.Drawing.Point(3, 4);
			this.m_extModeEdition.SetModeEdition(this.m_lblTypePhase, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTypePhase.Name = "m_lblTypePhase";
			this.m_lblTypePhase.Size = new System.Drawing.Size(80, 13);
			this.m_lblTypePhase.TabIndex = 1;
			this.m_lblTypePhase.Text = "Phase type|101";
			// 
			// m_panelDroite
			// 
			this.m_panelDroite.Controls.Add(this.m_panelLien);
			this.m_panelDroite.Controls.Add(this.m_panelDetailPhase);
			this.m_panelDroite.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_panelDroite.Location = new System.Drawing.Point(422, 0);
			this.m_extModeEdition.SetModeEdition(this.m_panelDroite, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelDroite.Name = "m_panelDroite";
			this.m_panelDroite.Size = new System.Drawing.Size(269, 418);
			this.m_panelDroite.TabIndex = 3;
			// 
			// m_panelDetailPhase
			// 
			this.m_panelDetailPhase.Controls.Add(this.m_chkPhaseFinale);
			this.m_panelDetailPhase.Controls.Add(this.m_chkPhaseDemarrage);
			this.m_panelDetailPhase.Controls.Add(this.m_lblPhase);
			this.m_panelDetailPhase.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelDetailPhase.Location = new System.Drawing.Point(0, 0);
			this.m_extModeEdition.SetModeEdition(this.m_panelDetailPhase, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelDetailPhase.Name = "m_panelDetailPhase";
			this.m_panelDetailPhase.Size = new System.Drawing.Size(269, 67);
			this.m_panelDetailPhase.TabIndex = 1;
			// 
			// m_chkPhaseFinale
			// 
			this.m_chkPhaseFinale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkPhaseFinale.Location = new System.Drawing.Point(11, 34);
			this.m_extModeEdition.SetModeEdition(this.m_chkPhaseFinale, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkPhaseFinale.Name = "m_chkPhaseFinale";
			this.m_chkPhaseFinale.Size = new System.Drawing.Size(182, 20);
			this.m_chkPhaseFinale.TabIndex = 1;
			this.m_chkPhaseFinale.Text = "End phase|30107";
			this.m_chkPhaseFinale.UseVisualStyleBackColor = true;
			// 
			// m_chkPhaseDemarrage
			// 
			this.m_chkPhaseDemarrage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkPhaseDemarrage.Location = new System.Drawing.Point(11, 17);
			this.m_extModeEdition.SetModeEdition(this.m_chkPhaseDemarrage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkPhaseDemarrage.Name = "m_chkPhaseDemarrage";
			this.m_chkPhaseDemarrage.Size = new System.Drawing.Size(182, 20);
			this.m_chkPhaseDemarrage.TabIndex = 1;
			this.m_chkPhaseDemarrage.Text = "Start phase|30108";
			this.m_chkPhaseDemarrage.UseVisualStyleBackColor = true;
			// 
			// m_lblPhase
			// 
			this.m_lblPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblPhase.Location = new System.Drawing.Point(4, 6);
			this.m_extModeEdition.SetModeEdition(this.m_lblPhase, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblPhase.Name = "m_lblPhase";
			this.m_lblPhase.Size = new System.Drawing.Size(262, 23);
			this.m_lblPhase.TabIndex = 0;
			// 
			// m_panelLien
			// 
			this.m_panelLien.Controls.Add(this.m_lblCondition);
			this.m_panelLien.Controls.Add(this.m_wndFormule);
			this.m_panelLien.Controls.Add(this.m_lblPhase2);
			this.m_panelLien.Controls.Add(this.m_lblPhase1);
			this.m_panelLien.Controls.Add(this.m_lblA);
			this.m_panelLien.Controls.Add(this.m_lblDe);
			this.m_panelLien.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelLien.Location = new System.Drawing.Point(0, 67);
			this.m_panelLien.LockEdition = false;
			this.m_extModeEdition.SetModeEdition(this.m_panelLien, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelLien.Name = "m_panelLien";
			this.m_panelLien.Size = new System.Drawing.Size(269, 102);
			this.m_panelLien.TabIndex = 0;
			// 
			// m_lblCondition
			// 
			this.m_lblCondition.AutoSize = true;
			this.m_lblCondition.Location = new System.Drawing.Point(5, 54);
			this.m_extModeEdition.SetModeEdition(this.m_lblCondition, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblCondition.Name = "m_lblCondition";
			this.m_lblCondition.Size = new System.Drawing.Size(51, 13);
			this.m_lblCondition.TabIndex = 5;
			this.m_lblCondition.Text = "Condition|30109";
			// 
			// m_wndFormule
			// 
			this.m_wndFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndFormule.Formule = null;
			this.m_wndFormule.Location = new System.Drawing.Point(8, 70);
			this.m_wndFormule.LockEdition = false;
			this.m_extModeEdition.SetModeEdition(this.m_wndFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_wndFormule.Name = "m_wndFormule";
			this.m_wndFormule.Size = new System.Drawing.Size(258, 23);
			this.m_wndFormule.TabIndex = 4;
			// 
			// m_lblPhase2
			// 
			this.m_lblPhase2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblPhase2.Location = new System.Drawing.Point(33, 26);
			this.m_extModeEdition.SetModeEdition(this.m_lblPhase2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblPhase2.Name = "m_lblPhase2";
			this.m_lblPhase2.Size = new System.Drawing.Size(233, 14);
			this.m_lblPhase2.TabIndex = 3;
			// 
			// m_lblPhase1
			// 
			this.m_lblPhase1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblPhase1.Location = new System.Drawing.Point(33, 7);
			this.m_extModeEdition.SetModeEdition(this.m_lblPhase1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblPhase1.Name = "m_lblPhase1";
			this.m_lblPhase1.Size = new System.Drawing.Size(233, 14);
			this.m_lblPhase1.TabIndex = 2;
			// 
			// m_lblA
			// 
			this.m_lblA.Location = new System.Drawing.Point(4, 26);
			this.m_extModeEdition.SetModeEdition(this.m_lblA, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblA.Name = "m_lblA";
			this.m_lblA.Size = new System.Drawing.Size(23, 14);
			this.m_lblA.TabIndex = 1;
			this.m_lblA.Text = "To|30110";
			// 
			// m_lblDe
			// 
			this.m_lblDe.Location = new System.Drawing.Point(4, 7);
			this.m_extModeEdition.SetModeEdition(this.m_lblDe, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDe.Name = "m_lblDe";
			this.m_lblDe.Size = new System.Drawing.Size(23, 14);
			this.m_lblDe.TabIndex = 0;
			this.m_lblDe.Text = "From|30111";
			// 
			// m_splitterPanelEdition
			// 
			this.m_splitterPanelEdition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.m_splitterPanelEdition.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_splitterPanelEdition.Location = new System.Drawing.Point(417, 0);
			this.m_extModeEdition.SetModeEdition(this.m_splitterPanelEdition, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_splitterPanelEdition.Name = "m_splitterPanelEdition";
			this.m_splitterPanelEdition.Size = new System.Drawing.Size(5, 418);
			this.m_splitterPanelEdition.TabIndex = 4;
			this.m_splitterPanelEdition.TabStop = false;
			// 
			// m_extModeEdition
			// 
			this.m_extModeEdition.ModeEditionChanged += new System.EventHandler(this.m_extModeEdition_ModeEditionChanged);
			// 
			// m_controlEdition
			// 
			this.m_controlEdition.AllowDrop = true;
			this.m_controlEdition.AutoScroll = true;
			this.m_controlEdition.BackColor = System.Drawing.Color.White;
			this.m_controlEdition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_controlEdition.Echelle = 1F;
			this.m_controlEdition.EffetAjoutSuppression = false;
			this.m_controlEdition.EffetFonduMenu = true;
			this.m_controlEdition.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
			cGrilleEditeurObjetGraphique3.Couleur = System.Drawing.Color.Blue;
			cGrilleEditeurObjetGraphique3.HauteurCarreau = 20;
			cGrilleEditeurObjetGraphique3.LargeurCarreau = 25;
			cGrilleEditeurObjetGraphique3.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
			cGrilleEditeurObjetGraphique3.TailleCarreau = new System.Drawing.Size(25, 20);
			this.m_controlEdition.GrilleAlignement = cGrilleEditeurObjetGraphique3;
			this.m_controlEdition.HauteurMinimaleDesObjets = 10;
			this.m_controlEdition.HistorisationActive = false;
			this.m_controlEdition.LargeurMinimaleDesObjets = 10;
			this.m_controlEdition.Location = new System.Drawing.Point(0, 67);
			this.m_controlEdition.LockEdition = false;
			this.m_controlEdition.Marge = 10;
			this.m_controlEdition.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
			this.m_controlEdition.ModeEdition = timos.win32.composants.EModeEditeurPhaseTicket.Selection;
			this.m_extModeEdition.SetModeEdition(this.m_controlEdition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_controlEdition.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
			this.m_controlEdition.Name = "m_controlEdition";
			this.m_controlEdition.NombreHistorisation = 0;
			this.m_controlEdition.ObjetEdite = null;
			cProfilEditeurObjetGraphique3.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
			cProfilEditeurObjetGraphique3.Grille = cGrilleEditeurObjetGraphique3;
			cProfilEditeurObjetGraphique3.HistorisationActive = true;
			cProfilEditeurObjetGraphique3.Marge = 10;
			cProfilEditeurObjetGraphique3.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
			cProfilEditeurObjetGraphique3.NombreHistorisation = 10;
			cProfilEditeurObjetGraphique3.ToujoursAlignerSurLaGrille = false;
			this.m_controlEdition.Profil = cProfilEditeurObjetGraphique3;
			this.m_controlEdition.Size = new System.Drawing.Size(417, 351);
			this.m_controlEdition.TabIndex = 0;
			this.m_controlEdition.ToujoursAlignerSelonLesControles = true;
			this.m_controlEdition.ToujoursAlignerSurLaGrille = false;
			this.m_controlEdition.TypePhaseEnCreation = null;
			this.m_controlEdition.WndTypeTicketEdite = null;
			this.m_controlEdition.AfterAddElementToTypePhase += new System.EventHandler(this.m_controlEdition_AfterAddElementToTypePhase);
			this.m_controlEdition.AfterModeEditionChanged += new System.EventHandler(this.m_controlEdition_AfterModeEditionChanged);
			this.m_controlEdition.AfterRemoveObjetGraphique += new System.EventHandler(this.m_controlEdition_AfterRemoveObjetGraphique);
			// 
			// CPanelEditPhasesTicket
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_controlEdition);
			this.Controls.Add(this.m_panelControles);
			this.Controls.Add(this.m_panelHaut);
			this.Controls.Add(this.m_splitterPanelEdition);
			this.Controls.Add(this.m_panelDroite);
			this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelEditPhasesTicket";
			this.Size = new System.Drawing.Size(691, 418);
			this.Load += new System.EventHandler(this.CPanelEditPhasesTicket_Load);
			this.m_panelHaut.ResumeLayout(false);
			this.m_panelHaut.PerformLayout();
			this.m_panelControles.ResumeLayout(false);
			this.m_panelDroite.ResumeLayout(false);
			this.m_panelDetailPhase.ResumeLayout(false);
			this.m_panelLien.ResumeLayout(false);
			this.m_panelLien.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CControlEditionPhasesDeTicket m_controlEdition;
		private System.Windows.Forms.Panel m_panelHaut;
		private System.Windows.Forms.Panel m_panelDroite;
		private System.Windows.Forms.Splitter m_splitterPanelEdition;
		private System.Windows.Forms.Label m_lblTypePhase;
		private System.Windows.Forms.Panel m_panelControles;
		private System.Windows.Forms.RadioButton m_chkCurseur;
		private System.Windows.Forms.RadioButton m_chkLien;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypePhase;
		private System.Windows.Forms.RadioButton m_chkPhase;
		private sc2i.win32.common.C2iPanel m_panelLien;
		private System.Windows.Forms.Label m_lblPhase2;
		private System.Windows.Forms.Label m_lblPhase1;
		private System.Windows.Forms.Label m_lblA;
		private System.Windows.Forms.Label m_lblDe;
		private System.Windows.Forms.Label m_lblCondition;
		private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormule;
		private System.Windows.Forms.Panel m_panelDetailPhase;
		private System.Windows.Forms.CheckBox m_chkPhaseDemarrage;
		private System.Windows.Forms.Label m_lblPhase;
        private System.Windows.Forms.CheckBox m_chkPhaseFinale;
	}
}
