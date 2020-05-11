namespace timos
{
    partial class CPanelInfosGenerales
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_gbInfosGenerales = new System.Windows.Forms.GroupBox();
            this.m_lblEtatCloture = new System.Windows.Forms.Label();
            this.m_lblDateOuverture = new System.Windows.Forms.Label();
            this.m_lblDateCloture = new System.Windows.Forms.Label();
            this.m_lblPhaseEncours = new System.Windows.Forms.Label();
            this.m_lblResponsable = new System.Windows.Forms.Label();
            this.m_lblAuteurTicket = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ticket = new System.Windows.Forms.Label();
            this.m_panelTitre = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblNumeroTicket = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_grpActions = new System.Windows.Forms.GroupBox();
            this.m_lnkCloreTicket = new System.Windows.Forms.LinkLabel();
            this.m_lnkPhaseSuivante = new System.Windows.Forms.LinkLabel();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn7 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gbInfosGenerales.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_gbInfosGenerales
            // 
            this.m_gbInfosGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gbInfosGenerales.Controls.Add(this.m_lblEtatCloture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblDateOuverture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblDateCloture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblPhaseEncours);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblResponsable);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblAuteurTicket);
            this.m_gbInfosGenerales.Controls.Add(this.label12);
            this.m_gbInfosGenerales.Controls.Add(this.label25);
            this.m_gbInfosGenerales.Controls.Add(this.label11);
            this.m_gbInfosGenerales.Controls.Add(this.label8);
            this.m_gbInfosGenerales.Controls.Add(this.label3);
            this.m_gbInfosGenerales.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_gbInfosGenerales, "");
            this.m_gbInfosGenerales.Location = new System.Drawing.Point(3, 198);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbInfosGenerales, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbInfosGenerales.Name = "m_gbInfosGenerales";
            this.m_gbInfosGenerales.Size = new System.Drawing.Size(182, 305);
            this.m_extStyle.SetStyleBackColor(this.m_gbInfosGenerales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gbInfosGenerales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gbInfosGenerales.TabIndex = 0;
            this.m_gbInfosGenerales.TabStop = false;
            this.m_gbInfosGenerales.Text = "General information|661";
            // 
            // m_lblEtatCloture
            // 
            this.m_lblEtatCloture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblEtatCloture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblEtatCloture, "");
            this.m_lblEtatCloture.Location = new System.Drawing.Point(100, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtatCloture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEtatCloture.Name = "m_lblEtatCloture";
            this.m_lblEtatCloture.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtatCloture.TabIndex = 12;
            // 
            // m_lblDateOuverture
            // 
            this.m_lblDateOuverture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDateOuverture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblDateOuverture, "");
            this.m_lblDateOuverture.Location = new System.Drawing.Point(100, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateOuverture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateOuverture.Name = "m_lblDateOuverture";
            this.m_lblDateOuverture.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateOuverture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateOuverture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateOuverture.TabIndex = 12;
            // 
            // m_lblDateCloture
            // 
            this.m_lblDateCloture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDateCloture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblDateCloture, "");
            this.m_lblDateCloture.Location = new System.Drawing.Point(100, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateCloture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateCloture.Name = "m_lblDateCloture";
            this.m_lblDateCloture.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateCloture.TabIndex = 12;
            // 
            // m_lblPhaseEncours
            // 
            this.m_lblPhaseEncours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPhaseEncours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblPhaseEncours, "PhaseEnCours.Libelle");
            this.m_lblPhaseEncours.Location = new System.Drawing.Point(100, 110);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPhaseEncours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblPhaseEncours.Name = "m_lblPhaseEncours";
            this.m_lblPhaseEncours.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblPhaseEncours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPhaseEncours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPhaseEncours.TabIndex = 13;
            this.m_lblPhaseEncours.Text = "[PhaseEnCours.Libelle]";
            // 
            // m_lblResponsable
            // 
            this.m_lblResponsable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblResponsable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblResponsable, "Responsable.Acteur.IdentiteComplete");
            this.m_lblResponsable.Location = new System.Drawing.Point(100, 92);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblResponsable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblResponsable.Name = "m_lblResponsable";
            this.m_lblResponsable.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblResponsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblResponsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblResponsable.TabIndex = 13;
            this.m_lblResponsable.Text = "[Responsable.Acteur.IdentiteComplete]";
            // 
            // m_lblAuteurTicket
            // 
            this.m_lblAuteurTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAuteurTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblAuteurTicket, "Auteur.Acteur.IdentiteComplete");
            this.m_lblAuteurTicket.Location = new System.Drawing.Point(100, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAuteurTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblAuteurTicket.Name = "m_lblAuteurTicket";
            this.m_lblAuteurTicket.Size = new System.Drawing.Size(78, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblAuteurTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAuteurTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAuteurTicket.TabIndex = 13;
            this.m_lblAuteurTicket.Text = "[Auteur.Acteur.IdentiteComplete]";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(3, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 13;
            this.label12.Text = "Current Phase|664";
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label25, "");
            this.label25.Location = new System.Drawing.Point(3, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label25, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label25.TabIndex = 13;
            this.label25.Text = "Assigned to|665";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(3, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 0;
            this.label11.Text = "Closing Date|670";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(3, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Closing state|671";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Opening date|662";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 14);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Opened by |663";
            // 
            // lbl_ticket
            // 
            this.lbl_ticket.AutoSize = true;
            this.lbl_ticket.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ticket.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.lbl_ticket, "");
            this.lbl_ticket.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_ticket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_ticket.Name = "lbl_ticket";
            this.lbl_ticket.Size = new System.Drawing.Size(84, 24);
            this.m_extStyle.SetStyleBackColor(this.lbl_ticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_ticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_ticket.TabIndex = 0;
            this.lbl_ticket.Text = "Nr|30261";
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.Controls.Add(this.m_lblNumeroTicket);
            this.m_panelTitre.Controls.Add(this.lbl_ticket);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTitre, "");
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTitre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(191, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 4;
            // 
            // m_lblNumeroTicket
            // 
            this.m_lblNumeroTicket.AutoSize = true;
            this.m_lblNumeroTicket.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblNumeroTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNumeroTicket.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblNumeroTicket, "Numero");
            this.m_lblNumeroTicket.Location = new System.Drawing.Point(84, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNumeroTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNumeroTicket.Name = "m_lblNumeroTicket";
            this.m_lblNumeroTicket.Size = new System.Drawing.Size(89, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lblNumeroTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNumeroTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNumeroTicket.TabIndex = 0;
            this.m_lblNumeroTicket.Text = "[Numero]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(138, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(161, 76);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(7, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(7, 127);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(7, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(211, 13);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.m_grpActions);
            this.panel1.Controls.Add(this.m_gbInfosGenerales);
            this.panel1.Controls.Add(this.m_panelTitre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 506);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_grpActions
            // 
            this.m_grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_grpActions.Controls.Add(this.m_lnkCloreTicket);
            this.m_grpActions.Controls.Add(this.m_lnkPhaseSuivante);
            this.m_extLinkField.SetLinkField(this.m_grpActions, "");
            this.m_grpActions.Location = new System.Drawing.Point(4, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_grpActions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_grpActions.Name = "m_grpActions";
            this.m_grpActions.Size = new System.Drawing.Size(181, 153);
            this.m_extStyle.SetStyleBackColor(this.m_grpActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_grpActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_grpActions.TabIndex = 5;
            this.m_grpActions.TabStop = false;
            this.m_grpActions.Text = "Actions|169";
            // 
            // m_lnkCloreTicket
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkCloreTicket, "");
            this.m_lnkCloreTicket.Location = new System.Drawing.Point(6, 121);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCloreTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkCloreTicket.Name = "m_lnkCloreTicket";
            this.m_lnkCloreTicket.Size = new System.Drawing.Size(156, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCloreTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCloreTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCloreTicket.TabIndex = 0;
            this.m_lnkCloreTicket.TabStop = true;
            this.m_lnkCloreTicket.Text = "Close Ticket|674";
            this.m_lnkCloreTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCloreTicket_LinkClicked);
            // 
            // m_lnkPhaseSuivante
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkPhaseSuivante, "");
            this.m_lnkPhaseSuivante.Location = new System.Drawing.Point(6, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPhaseSuivante, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkPhaseSuivante.Name = "m_lnkPhaseSuivante";
            this.m_lnkPhaseSuivante.Size = new System.Drawing.Size(156, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPhaseSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPhaseSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPhaseSuivante.TabIndex = 0;
            this.m_lnkPhaseSuivante.TabStop = true;
            this.m_lnkPhaseSuivante.Text = "Add a Follow-up...|10016";
            this.m_lnkPhaseSuivante.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPhaseSuivante_LinkClicked);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TypePhase.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Phase";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 105;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "DateDebutToString";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Date début";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 99;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "DateFinToString";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Date fin";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 92;
            // 
            // listViewAutoFilledColumn7
            // 
            this.listViewAutoFilledColumn7.Field = "InfosPhase";
            this.listViewAutoFilledColumn7.PrecisionWidth = 0;
            this.listViewAutoFilledColumn7.ProportionnalSize = false;
            this.listViewAutoFilledColumn7.Text = "Infos";
            this.listViewAutoFilledColumn7.Visible = true;
            this.listViewAutoFilledColumn7.Width = 298;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.DisplayIndex = 1;
            this.listViewAutoFilledColumn2.Field = "DateDebutToString";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Date début";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "DateFinToString";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Date fin";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 120;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "InfosPhase";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Infos";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 120;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "TypePhase";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Liste des Phases";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 171;
            // 
            // CPanelInfosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelInfosGenerales";
            this.Size = new System.Drawing.Size(191, 506);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gbInfosGenerales.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.m_panelTitre.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.m_grpActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.GroupBox m_gbInfosGenerales;
        private System.Windows.Forms.Label lbl_ticket;
        private sc2i.win32.common.CToolTipTraductible m_toolTipTraductible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private System.Windows.Forms.Label m_lblNumeroTicket;
        private System.Windows.Forms.Label label11;
        protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn6;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn7;
        private System.Windows.Forms.Label label25;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label m_lblAuteurTicket;
        private System.Windows.Forms.Label m_lblDateCloture;
        private System.Windows.Forms.Label m_lblEtatCloture;
        private System.Windows.Forms.Label m_lblDateOuverture;
        private System.Windows.Forms.Label m_lblResponsable;
        private System.Windows.Forms.Label m_lblPhaseEncours;
        private System.Windows.Forms.Label label12;
        private sc2i.win32.common.C2iPanel m_panelTitre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox m_grpActions;
        private System.Windows.Forms.LinkLabel m_lnkPhaseSuivante;
        private System.Windows.Forms.LinkLabel m_lnkCloreTicket;
    }
}
