namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkListe
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
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelListeEntites = new System.Windows.Forms.Panel();
            this.m_tabPageListe = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkOptionsFiltre = new System.Windows.Forms.LinkLabel();
            this.m_imgFiltreSpecifiqueOnList = new System.Windows.Forms.PictureBox();
            this.m_lnkFiltreSpecifique = new System.Windows.Forms.LinkLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_lnkEditActionDetailSpecifique = new System.Windows.Forms.LinkLabel();
            this.m_rbtnActionDetailSpecifique = new System.Windows.Forms.RadioButton();
            this.m_rbtnActionDetailEditElement = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.m_lnkAffectations = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtTitreListe = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtContexteListe = new sc2i.win32.expression.CControleEditeFormule();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_chkListeAvecDetail = new System.Windows.Forms.CheckBox();
            this.m_chkListeAvecRemove = new System.Windows.Forms.CheckBox();
            this.m_chkListeAvecAjouter = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_panelListeEntites.SuspendLayout();
            this.m_tabPageListe.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgFiltreSpecifiqueOnList)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelEditFiltre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListeEntites
            // 
            this.m_panelListeEntites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelListeEntites.Controls.Add(this.m_tabPageListe);
            this.m_panelListeEntites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeEntites.ForeColor = System.Drawing.Color.Black;
            this.m_panelListeEntites.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeEntites.Name = "m_panelListeEntites";
            this.m_panelListeEntites.Size = new System.Drawing.Size(834, 289);
            this.cExtStyle1.SetStyleBackColor(this.m_panelListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeEntites.TabIndex = 5;
            // 
            // m_tabPageListe
            // 
            this.m_tabPageListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabPageListe.BoldSelectedPage = true;
            this.m_tabPageListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabPageListe.ForeColor = System.Drawing.Color.Black;
            this.m_tabPageListe.IDEPixelArea = false;
            this.m_tabPageListe.Location = new System.Drawing.Point(0, 0);
            this.m_tabPageListe.Name = "m_tabPageListe";
            this.m_tabPageListe.Ombre = false;
            this.m_tabPageListe.PositionTop = true;
            this.m_tabPageListe.SelectedIndex = 1;
            this.m_tabPageListe.SelectedTab = this.tabPage2;
            this.m_tabPageListe.Size = new System.Drawing.Size(834, 289);
            this.cExtStyle1.SetStyleBackColor(this.m_tabPageListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_tabPageListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageListe.TabIndex = 5;
            this.m_tabPageListe.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabPageListe.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.m_wndAide);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(834, 264);
            this.cExtStyle1.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Options de la page";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkOptionsFiltre);
            this.panel2.Controls.Add(this.m_imgFiltreSpecifiqueOnList);
            this.panel2.Controls.Add(this.m_lnkFiltreSpecifique);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.m_lnkAffectations);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.m_txtTitreListe);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_txtContexteListe);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 264);
            this.cExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 9;
            // 
            // m_lnkOptionsFiltre
            // 
            this.m_lnkOptionsFiltre.AutoSize = true;
            this.m_lnkOptionsFiltre.Location = new System.Drawing.Point(51, 39);
            this.m_lnkOptionsFiltre.Name = "m_lnkOptionsFiltre";
            this.m_lnkOptionsFiltre.Size = new System.Drawing.Size(109, 15);
            this.cExtStyle1.SetStyleBackColor(this.m_lnkOptionsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lnkOptionsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOptionsFiltre.TabIndex = 15;
            this.m_lnkOptionsFiltre.TabStop = true;
            this.m_lnkOptionsFiltre.Text = "Filter options|20828";
            this.m_lnkOptionsFiltre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOptionsFiltre_LinkClicked);
            // 
            // m_imgFiltreSpecifiqueOnList
            // 
            this.m_imgFiltreSpecifiqueOnList.Image = global::timos.Properties.Resources.filtre;
            this.m_imgFiltreSpecifiqueOnList.Location = new System.Drawing.Point(11, 24);
            this.m_imgFiltreSpecifiqueOnList.Name = "m_imgFiltreSpecifiqueOnList";
            this.m_imgFiltreSpecifiqueOnList.Size = new System.Drawing.Size(16, 15);
            this.m_imgFiltreSpecifiqueOnList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cExtStyle1.SetStyleBackColor(this.m_imgFiltreSpecifiqueOnList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_imgFiltreSpecifiqueOnList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imgFiltreSpecifiqueOnList.TabIndex = 14;
            this.m_imgFiltreSpecifiqueOnList.TabStop = false;
            // 
            // m_lnkFiltreSpecifique
            // 
            this.m_lnkFiltreSpecifique.AutoSize = true;
            this.m_lnkFiltreSpecifique.Location = new System.Drawing.Point(28, 25);
            this.m_lnkFiltreSpecifique.Name = "m_lnkFiltreSpecifique";
            this.m_lnkFiltreSpecifique.Size = new System.Drawing.Size(129, 15);
            this.cExtStyle1.SetStyleBackColor(this.m_lnkFiltreSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lnkFiltreSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltreSpecifique.TabIndex = 13;
            this.m_lnkFiltreSpecifique.TabStop = true;
            this.m_lnkFiltreSpecifique.Text = "Use specific filter|20826";
            this.m_lnkFiltreSpecifique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFiltreSpecifique_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.m_lnkEditActionDetailSpecifique);
            this.panel5.Controls.Add(this.m_rbtnActionDetailSpecifique);
            this.panel5.Controls.Add(this.m_rbtnActionDetailEditElement);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(370, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 58);
            this.cExtStyle1.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 11;
            // 
            // m_lnkEditActionDetailSpecifique
            // 
            this.m_lnkEditActionDetailSpecifique.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEditActionDetailSpecifique.Location = new System.Drawing.Point(99, 39);
            this.m_lnkEditActionDetailSpecifique.Name = "m_lnkEditActionDetailSpecifique";
            this.m_lnkEditActionDetailSpecifique.Size = new System.Drawing.Size(53, 19);
            this.cExtStyle1.SetStyleBackColor(this.m_lnkEditActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lnkEditActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditActionDetailSpecifique.TabIndex = 3;
            this.m_lnkEditActionDetailSpecifique.TabStop = true;
            this.m_lnkEditActionDetailSpecifique.Text = "...";
            this.m_lnkEditActionDetailSpecifique.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkEditActionDetailSpecifique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEditActionDetailSpecifique_LinkClicked);
            // 
            // m_rbtnActionDetailSpecifique
            // 
            this.m_rbtnActionDetailSpecifique.AutoSize = true;
            this.m_rbtnActionDetailSpecifique.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rbtnActionDetailSpecifique.Location = new System.Drawing.Point(0, 39);
            this.m_rbtnActionDetailSpecifique.Name = "m_rbtnActionDetailSpecifique";
            this.m_rbtnActionDetailSpecifique.Size = new System.Drawing.Size(99, 19);
            this.cExtStyle1.SetStyleBackColor(this.m_rbtnActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_rbtnActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnActionDetailSpecifique.TabIndex = 2;
            this.m_rbtnActionDetailSpecifique.TabStop = true;
            this.m_rbtnActionDetailSpecifique.Text = "Specific|20804";
            this.m_rbtnActionDetailSpecifique.UseVisualStyleBackColor = true;
            this.m_rbtnActionDetailSpecifique.CheckedChanged += new System.EventHandler(this.m_rbtnActionDetailSpecifique_CheckedChanged);
            // 
            // m_rbtnActionDetailEditElement
            // 
            this.m_rbtnActionDetailEditElement.AutoSize = true;
            this.m_rbtnActionDetailEditElement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbtnActionDetailEditElement.Location = new System.Drawing.Point(0, 20);
            this.m_rbtnActionDetailEditElement.Name = "m_rbtnActionDetailEditElement";
            this.m_rbtnActionDetailEditElement.Size = new System.Drawing.Size(229, 19);
            this.cExtStyle1.SetStyleBackColor(this.m_rbtnActionDetailEditElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_rbtnActionDetailEditElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnActionDetailEditElement.TabIndex = 1;
            this.m_rbtnActionDetailEditElement.TabStop = true;
            this.m_rbtnActionDetailEditElement.Text = "Edit elementy|20803";
            this.m_rbtnActionDetailEditElement.UseVisualStyleBackColor = true;
            this.m_rbtnActionDetailEditElement.CheckedChanged += new System.EventHandler(this.m_rbtnActionDetailEditElement_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.label18);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.ForeColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(229, 20);
            this.cExtStyle1.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(173, 19);
            this.cExtStyle1.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            this.label18.Text = "Detail action|20802";
            // 
            // m_lnkAffectations
            // 
            this.m_lnkAffectations.AutoSize = true;
            this.m_lnkAffectations.Location = new System.Drawing.Point(8, 8);
            this.m_lnkAffectations.Name = "m_lnkAffectations";
            this.m_lnkAffectations.Size = new System.Drawing.Size(184, 15);
            this.cExtStyle1.SetStyleBackColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAffectations.TabIndex = 10;
            this.m_lnkAffectations.TabStop = true;
            this.m_lnkAffectations.Text = "New elements assignments|20689";
            this.m_lnkAffectations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffectations_LinkClicked);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.cExtStyle1.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Titre";
            // 
            // m_txtTitreListe
            // 
            this.m_txtTitreListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTitreListe.BackColor = System.Drawing.Color.White;
            this.m_txtTitreListe.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtTitreListe.Formule = null;
            this.m_txtTitreListe.Location = new System.Drawing.Point(8, 74);
            this.m_txtTitreListe.LockEdition = false;
            this.m_txtTitreListe.Name = "m_txtTitreListe";
            this.m_txtTitreListe.Size = new System.Drawing.Size(583, 76);
            this.cExtStyle1.SetStyleBackColor(this.m_txtTitreListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtTitreListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTitreListe.TabIndex = 8;
            this.m_txtTitreListe.Enter += new System.EventHandler(this.m_txtTitreListe_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(8, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.cExtStyle1.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contexte du formulaire";
            // 
            // m_txtContexteListe
            // 
            this.m_txtContexteListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtContexteListe.BackColor = System.Drawing.Color.White;
            this.m_txtContexteListe.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtContexteListe.Formule = null;
            this.m_txtContexteListe.Location = new System.Drawing.Point(8, 175);
            this.m_txtContexteListe.LockEdition = false;
            this.m_txtContexteListe.Name = "m_txtContexteListe";
            this.m_txtContexteListe.Size = new System.Drawing.Size(586, 74);
            this.cExtStyle1.SetStyleBackColor(this.m_txtContexteListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtContexteListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtContexteListe.TabIndex = 9;
            this.m_txtContexteListe.Enter += new System.EventHandler(this.m_txtTitreListe_Enter);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_chkListeAvecDetail);
            this.panel7.Controls.Add(this.m_chkListeAvecRemove);
            this.panel7.Controls.Add(this.m_chkListeAvecAjouter);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(214, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(137, 67);
            this.cExtStyle1.SetStyleBackColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel7.TabIndex = 12;
            // 
            // m_chkListeAvecDetail
            // 
            this.m_chkListeAvecDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecDetail.Location = new System.Drawing.Point(0, 52);
            this.m_chkListeAvecDetail.Name = "m_chkListeAvecDetail";
            this.m_chkListeAvecDetail.Size = new System.Drawing.Size(137, 16);
            this.cExtStyle1.SetStyleBackColor(this.m_chkListeAvecDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_chkListeAvecDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecDetail.TabIndex = 4;
            this.m_chkListeAvecDetail.Text = "Detail|20808";
            this.m_chkListeAvecDetail.UseVisualStyleBackColor = true;
            // 
            // m_chkListeAvecRemove
            // 
            this.m_chkListeAvecRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecRemove.Location = new System.Drawing.Point(0, 36);
            this.m_chkListeAvecRemove.Name = "m_chkListeAvecRemove";
            this.m_chkListeAvecRemove.Size = new System.Drawing.Size(137, 16);
            this.cExtStyle1.SetStyleBackColor(this.m_chkListeAvecRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_chkListeAvecRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecRemove.TabIndex = 3;
            this.m_chkListeAvecRemove.Text = "Remove|20807";
            this.m_chkListeAvecRemove.UseVisualStyleBackColor = true;
            // 
            // m_chkListeAvecAjouter
            // 
            this.m_chkListeAvecAjouter.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecAjouter.Location = new System.Drawing.Point(0, 20);
            this.m_chkListeAvecAjouter.Name = "m_chkListeAvecAjouter";
            this.m_chkListeAvecAjouter.Size = new System.Drawing.Size(137, 16);
            this.cExtStyle1.SetStyleBackColor(this.m_chkListeAvecAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_chkListeAvecAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecAjouter.TabIndex = 2;
            this.m_chkListeAvecAjouter.Text = "Add|20806";
            this.m_chkListeAvecAjouter.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.label19);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(137, 20);
            this.cExtStyle1.SetStyleBackColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel8.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 19);
            this.cExtStyle1.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 0;
            this.label19.Text = "Buttons|20802";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(599, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 264);
            this.cExtStyle1.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // m_wndAide
            // 
            this.m_wndAide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAide.FournisseurProprietes = null;
            this.m_wndAide.Location = new System.Drawing.Point(602, 0);
            this.m_wndAide.Name = "m_wndAide";
            this.m_wndAide.ObjetInterroge = null;
            this.m_wndAide.SendIdChamps = false;
            this.m_wndAide.Size = new System.Drawing.Size(232, 264);
            this.cExtStyle1.SetStyleBackColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAide.TabIndex = 10;
            this.m_wndAide.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAide_OnSendCommande);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelEditFiltre);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(834, 264);
            this.cExtStyle1.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Filtre";
            // 
            // m_panelEditFiltre
            // 
            this.m_panelEditFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelEditFiltre.Controls.Add(this.m_tab);
            this.m_panelEditFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelEditFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelEditFiltre.FiltreDynamique = null;
            this.m_panelEditFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditFiltre.LockEdition = false;
            this.m_panelEditFiltre.ModeFiltreExpression = false;
            this.m_panelEditFiltre.ModeSansType = false;
            this.m_panelEditFiltre.Name = "m_panelEditFiltre";
            this.m_panelEditFiltre.Size = new System.Drawing.Size(834, 264);
            this.cExtStyle1.SetStyleBackColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditFiltre.TabIndex = 1;
            // 
            // m_tab
            // 
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tab.IDEPixelArea = false;
            this.m_tab.Location = new System.Drawing.Point(0, 0);
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.Size = new System.Drawing.Size(834, 264);
            this.cExtStyle1.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 2;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(834, 264);
            this.cExtStyle1.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // CPanelEditeActionSurLinkListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelListeEntites);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkListe";
            this.Size = new System.Drawing.Size(834, 289);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_panelListeEntites.ResumeLayout(false);
            this.m_tabPageListe.ResumeLayout(false);
            this.m_tabPageListe.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgFiltreSpecifiqueOnList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.m_panelEditFiltre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle cExtStyle1;
        private System.Windows.Forms.Panel m_panelListeEntites;
        private sc2i.win32.common.C2iTabControl m_tabPageListe;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelEditFiltre;
        private sc2i.win32.common.C2iTabControl m_tab;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel m_lnkOptionsFiltre;
        private System.Windows.Forms.PictureBox m_imgFiltreSpecifiqueOnList;
        private System.Windows.Forms.LinkLabel m_lnkFiltreSpecifique;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.LinkLabel m_lnkEditActionDetailSpecifique;
        private System.Windows.Forms.RadioButton m_rbtnActionDetailSpecifique;
        private System.Windows.Forms.RadioButton m_rbtnActionDetailEditElement;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel m_lnkAffectations;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.expression.CControleEditeFormule m_txtTitreListe;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CControleEditeFormule m_txtContexteListe;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox m_chkListeAvecDetail;
        private System.Windows.Forms.CheckBox m_chkListeAvecRemove;
        private System.Windows.Forms.CheckBox m_chkListeAvecAjouter;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Splitter splitter1;
        private sc2i.win32.expression.CControlAideFormule m_wndAide;
    }
}
