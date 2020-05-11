namespace timos.projet.besoin
{
    partial class CEditeurCoutSuivi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditeurCoutSuivi));
            this.m_txtCoutCalculé = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_lblRegroupement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtCoutSaisi = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_menuDetailCoutCalculé = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelPrévisionnel = new System.Windows.Forms.Panel();
            this.m_panelSaisi = new System.Windows.Forms.Panel();
            this.m_panelRéel = new System.Windows.Forms.Panel();
            this.m_txtCoutReel = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label2 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tooltip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.m_chkSaisiAsReel = new System.Windows.Forms.CheckBox();
            this.m_chkSaisiAsPrevisionnel = new System.Windows.Forms.CheckBox();
            this.m_chkExcludeChilds = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_picFigerPrevisionnel = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.m_picInfoCalculPrévisionnel = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.m_picInfoCoutReel = new System.Windows.Forms.PictureBox();
            this.m_panelPrévisionnel.SuspendLayout();
            this.m_panelSaisi.SuspendLayout();
            this.m_panelRéel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFigerPrevisionnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfoCalculPrévisionnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfoCoutReel)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtCoutCalculé
            // 
            this.m_txtCoutCalculé.Arrondi = 4;
            this.m_txtCoutCalculé.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_txtCoutCalculé.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_txtCoutCalculé.DecimalAutorise = true;
            this.m_txtCoutCalculé.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCoutCalculé.DoubleValue = null;
            this.m_txtCoutCalculé.EmptyText = "C.U.";
            this.m_txtCoutCalculé.IntValue = null;
            this.m_txtCoutCalculé.Location = new System.Drawing.Point(21, 0);
            this.m_txtCoutCalculé.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutCalculé, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCoutCalculé.Name = "m_txtCoutCalculé";
            this.m_txtCoutCalculé.NullAutorise = true;
            this.m_txtCoutCalculé.SelectAllOnEnter = true;
            this.m_txtCoutCalculé.SeparateurMilliers = " ";
            this.m_txtCoutCalculé.Size = new System.Drawing.Size(95, 20);
            this.m_txtCoutCalculé.TabIndex = 16;
            this.m_txtCoutCalculé.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_tooltip.SetToolTip(this.m_txtCoutCalculé, "Estimated cost|20702");
            // 
            // m_lblRegroupement
            // 
            this.m_lblRegroupement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblRegroupement.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblRegroupement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblRegroupement.Name = "m_lblRegroupement";
            this.m_lblRegroupement.Size = new System.Drawing.Size(23, 21);
            this.m_lblRegroupement.TabIndex = 18;
            this.m_lblRegroupement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(180, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCoutSaisi
            // 
            this.m_txtCoutSaisi.Arrondi = 4;
            this.m_txtCoutSaisi.BackColor = System.Drawing.Color.White;
            this.m_txtCoutSaisi.DecimalAutorise = true;
            this.m_txtCoutSaisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCoutSaisi.DoubleValue = null;
            this.m_txtCoutSaisi.EmptyText = "C.U.";
            this.m_txtCoutSaisi.IntValue = null;
            this.m_txtCoutSaisi.Location = new System.Drawing.Point(21, 0);
            this.m_txtCoutSaisi.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutSaisi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCoutSaisi.Name = "m_txtCoutSaisi";
            this.m_txtCoutSaisi.NullAutorise = true;
            this.m_txtCoutSaisi.SelectAllOnEnter = true;
            this.m_txtCoutSaisi.SeparateurMilliers = " ";
            this.m_txtCoutSaisi.Size = new System.Drawing.Size(66, 20);
            this.m_txtCoutSaisi.TabIndex = 21;
            this.m_txtCoutSaisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_tooltip.SetToolTip(this.m_txtCoutSaisi, "Entered cost|20703");
            // 
            // m_menuDetailCoutCalculé
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menuDetailCoutCalculé, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuDetailCoutCalculé.Name = "m_menuDetailCoutCalculé";
            this.m_menuDetailCoutCalculé.Size = new System.Drawing.Size(61, 4);
            // 
            // m_panelPrévisionnel
            // 
            this.m_panelPrévisionnel.Controls.Add(this.m_txtCoutCalculé);
            this.m_panelPrévisionnel.Controls.Add(this.pictureBox1);
            this.m_panelPrévisionnel.Controls.Add(this.m_picFigerPrevisionnel);
            this.m_panelPrévisionnel.Controls.Add(this.pictureBox2);
            this.m_panelPrévisionnel.Controls.Add(this.m_picInfoCalculPrévisionnel);
            this.m_panelPrévisionnel.Controls.Add(this.label1);
            this.m_panelPrévisionnel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelPrévisionnel.Location = new System.Drawing.Point(203, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelPrévisionnel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPrévisionnel.Name = "m_panelPrévisionnel";
            this.m_panelPrévisionnel.Size = new System.Drawing.Size(195, 21);
            this.m_panelPrévisionnel.TabIndex = 26;
            // 
            // m_panelSaisi
            // 
            this.m_panelSaisi.Controls.Add(this.m_txtCoutSaisi);
            this.m_panelSaisi.Controls.Add(this.pictureBox3);
            this.m_panelSaisi.Controls.Add(this.pictureBox4);
            this.m_panelSaisi.Controls.Add(this.m_chkSaisiAsReel);
            this.m_panelSaisi.Controls.Add(this.m_chkSaisiAsPrevisionnel);
            this.m_panelSaisi.Controls.Add(this.m_chkExcludeChilds);
            this.m_panelSaisi.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelSaisi.Location = new System.Drawing.Point(398, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelSaisi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelSaisi.Name = "m_panelSaisi";
            this.m_panelSaisi.Size = new System.Drawing.Size(190, 21);
            this.m_panelSaisi.TabIndex = 27;
            // 
            // m_panelRéel
            // 
            this.m_panelRéel.Controls.Add(this.m_txtCoutReel);
            this.m_panelRéel.Controls.Add(this.pictureBox6);
            this.m_panelRéel.Controls.Add(this.pictureBox7);
            this.m_panelRéel.Controls.Add(this.m_picInfoCoutReel);
            this.m_panelRéel.Controls.Add(this.label2);
            this.m_panelRéel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelRéel.Location = new System.Drawing.Point(23, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelRéel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelRéel.Name = "m_panelRéel";
            this.m_panelRéel.Size = new System.Drawing.Size(180, 21);
            this.m_panelRéel.TabIndex = 28;
            // 
            // m_txtCoutReel
            // 
            this.m_txtCoutReel.Arrondi = 4;
            this.m_txtCoutReel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_txtCoutReel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_txtCoutReel.DecimalAutorise = true;
            this.m_txtCoutReel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCoutReel.DoubleValue = null;
            this.m_txtCoutReel.EmptyText = "C.U.";
            this.m_txtCoutReel.IntValue = null;
            this.m_txtCoutReel.Location = new System.Drawing.Point(21, 0);
            this.m_txtCoutReel.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutReel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCoutReel.Name = "m_txtCoutReel";
            this.m_txtCoutReel.NullAutorise = true;
            this.m_txtCoutReel.SelectAllOnEnter = true;
            this.m_txtCoutReel.SeparateurMilliers = "  ";
            this.m_txtCoutReel.Size = new System.Drawing.Size(104, 20);
            this.m_txtCoutReel.TabIndex = 16;
            this.m_txtCoutReel.Text = " ";
            this.m_txtCoutReel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_tooltip.SetToolTip(this.m_txtCoutReel, "Actual cost|20701");
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(165, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(87, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = global::timos.Properties.Resources.edit;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // m_chkSaisiAsReel
            // 
            this.m_chkSaisiAsReel.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkSaisiAsReel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkSaisiAsReel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkSaisiAsReel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.m_chkSaisiAsReel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkSaisiAsReel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkSaisiAsReel.Image = global::timos.Properties.Resources.tools;
            this.m_chkSaisiAsReel.Location = new System.Drawing.Point(103, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkSaisiAsReel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSaisiAsReel.Name = "m_chkSaisiAsReel";
            this.m_chkSaisiAsReel.Size = new System.Drawing.Size(29, 21);
            this.m_chkSaisiAsReel.TabIndex = 25;
            this.m_tooltip.SetToolTip(this.m_chkSaisiAsReel, "Use entered cost as actual cost|20704");
            this.m_chkSaisiAsReel.UseVisualStyleBackColor = true;
            this.m_chkSaisiAsReel.CheckedChanged += new System.EventHandler(this.m_chkSaisiAsReel_CheckedChanged);
            // 
            // m_chkSaisiAsPrevisionnel
            // 
            this.m_chkSaisiAsPrevisionnel.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkSaisiAsPrevisionnel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkSaisiAsPrevisionnel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkSaisiAsPrevisionnel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.m_chkSaisiAsPrevisionnel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkSaisiAsPrevisionnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkSaisiAsPrevisionnel.Image = global::timos.Properties.Resources.Calculatrice;
            this.m_chkSaisiAsPrevisionnel.Location = new System.Drawing.Point(132, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkSaisiAsPrevisionnel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSaisiAsPrevisionnel.Name = "m_chkSaisiAsPrevisionnel";
            this.m_chkSaisiAsPrevisionnel.Size = new System.Drawing.Size(29, 21);
            this.m_chkSaisiAsPrevisionnel.TabIndex = 24;
            this.m_tooltip.SetToolTip(this.m_chkSaisiAsPrevisionnel, "Use entered cost as estimated cost|20705");
            this.m_chkSaisiAsPrevisionnel.UseVisualStyleBackColor = true;
            this.m_chkSaisiAsPrevisionnel.CheckedChanged += new System.EventHandler(this.m_chkSaisiAsPrevisionnel_CheckedChanged);
            // 
            // m_chkExcludeChilds
            // 
            this.m_chkExcludeChilds.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkExcludeChilds.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkExcludeChilds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.m_chkExcludeChilds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkExcludeChilds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkExcludeChilds.Image = global::timos.Properties.Resources.Hierarchy;
            this.m_chkExcludeChilds.Location = new System.Drawing.Point(161, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkExcludeChilds, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkExcludeChilds.Name = "m_chkExcludeChilds";
            this.m_chkExcludeChilds.Size = new System.Drawing.Size(29, 21);
            this.m_chkExcludeChilds.TabIndex = 26;
            this.m_tooltip.SetToolTip(this.m_chkExcludeChilds, "Include or exclude child costs|20743");
            this.m_chkExcludeChilds.UseVisualStyleBackColor = true;
            this.m_chkExcludeChilds.CheckedChanged += new System.EventHandler(this.m_chkExcludeChilds_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(116, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // m_picFigerPrevisionnel
            // 
            this.m_picFigerPrevisionnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picFigerPrevisionnel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picFigerPrevisionnel.Image = global::timos.Properties.Resources.lock_padlock;
            this.m_picFigerPrevisionnel.Location = new System.Drawing.Point(132, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picFigerPrevisionnel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_picFigerPrevisionnel.Name = "m_picFigerPrevisionnel";
            this.m_picFigerPrevisionnel.Size = new System.Drawing.Size(24, 21);
            this.m_picFigerPrevisionnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picFigerPrevisionnel.TabIndex = 26;
            this.m_picFigerPrevisionnel.TabStop = false;
            this.m_picFigerPrevisionnel.Click += new System.EventHandler(this.m_picFigerPrevisionnel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::timos.Properties.Resources.Calculatrice;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // m_picInfoCalculPrévisionnel
            // 
            this.m_picInfoCalculPrévisionnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picInfoCalculPrévisionnel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picInfoCalculPrévisionnel.Image = global::timos.Properties.Resources.Information;
            this.m_picInfoCalculPrévisionnel.Location = new System.Drawing.Point(156, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picInfoCalculPrévisionnel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picInfoCalculPrévisionnel.Name = "m_picInfoCalculPrévisionnel";
            this.m_picInfoCalculPrévisionnel.Size = new System.Drawing.Size(24, 21);
            this.m_picInfoCalculPrévisionnel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picInfoCalculPrévisionnel.TabIndex = 25;
            this.m_picInfoCalculPrévisionnel.TabStop = false;
            this.m_picInfoCalculPrévisionnel.Click += new System.EventHandler(this.m_picInfoCalculPrévisionnel_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(125, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 21);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox7.Image = global::timos.Properties.Resources.tools;
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(21, 21);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // m_picInfoCoutReel
            // 
            this.m_picInfoCoutReel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picInfoCoutReel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picInfoCoutReel.Image = global::timos.Properties.Resources.Information;
            this.m_picInfoCoutReel.Location = new System.Drawing.Point(141, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picInfoCoutReel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picInfoCoutReel.Name = "m_picInfoCoutReel";
            this.m_picInfoCoutReel.Size = new System.Drawing.Size(24, 21);
            this.m_picInfoCoutReel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picInfoCoutReel.TabIndex = 25;
            this.m_picInfoCoutReel.TabStop = false;
            this.m_picInfoCoutReel.Click += new System.EventHandler(this.m_picInfoCoutReel_Click);
            // 
            // CEditeurCoutSuivi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelSaisi);
            this.Controls.Add(this.m_panelPrévisionnel);
            this.Controls.Add(this.m_panelRéel);
            this.Controls.Add(this.m_lblRegroupement);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurCoutSuivi";
            this.Size = new System.Drawing.Size(690, 21);
            this.m_panelPrévisionnel.ResumeLayout(false);
            this.m_panelPrévisionnel.PerformLayout();
            this.m_panelSaisi.ResumeLayout(false);
            this.m_panelSaisi.PerformLayout();
            this.m_panelRéel.ResumeLayout(false);
            this.m_panelRéel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFigerPrevisionnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfoCalculPrévisionnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picInfoCoutReel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutCalculé;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_lblRegroupement;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutSaisi;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ContextMenuStrip m_menuDetailCoutCalculé;
        private System.Windows.Forms.PictureBox m_picInfoCalculPrévisionnel;
        private System.Windows.Forms.Panel m_panelPrévisionnel;
        private System.Windows.Forms.Panel m_panelSaisi;
        private System.Windows.Forms.Panel m_panelRéel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox m_picInfoCoutReel;
        private System.Windows.Forms.PictureBox pictureBox6;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutReel;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.CheckBox m_chkSaisiAsReel;
        private System.Windows.Forms.CheckBox m_chkSaisiAsPrevisionnel;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.CToolTipTraductible m_tooltip;
        private System.Windows.Forms.PictureBox m_picFigerPrevisionnel;
        private System.Windows.Forms.CheckBox m_chkExcludeChilds;
    }
}
