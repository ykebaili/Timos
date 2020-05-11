namespace timos.sites.releve
{
    partial class CControlActionReleve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlActionReleve));
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_panelFull = new System.Windows.Forms.Panel();
            this.m_panelChampsOriginaux = new System.Windows.Forms.Panel();
            this.m_panelOriginal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblRefFourDB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblTypeDB = new System.Windows.Forms.Label();
            this.m_lblSerialDB = new System.Windows.Forms.Label();
            this.m_lblCoordDb = new System.Windows.Forms.Label();
            this.m_imageFromBase = new System.Windows.Forms.PictureBox();
            this.m_panelReleve = new System.Windows.Forms.Panel();
            this.m_panelTypeReleve = new System.Windows.Forms.Panel();
            this.m_lblRefFourReleve = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblTypeReleve = new System.Windows.Forms.Label();
            this.m_lblSerialReleve = new System.Windows.Forms.Label();
            this.m_lblCoordReleve = new System.Windows.Forms.Label();
            this.m_imageOeil = new System.Windows.Forms.PictureBox();
            this.m_panelChampsReleve = new System.Windows.Forms.Panel();
            this.m_panelAction = new System.Windows.Forms.Panel();
            this.m_panelChooseAction = new System.Windows.Forms.Panel();
            this.m_lblAction = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnChooseAction = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_lblCommentReleve = new System.Windows.Forms.Label();
            this.m_lblSep = new System.Windows.Forms.Label();
            this.m_panelForExpand = new System.Windows.Forms.Panel();
            this.m_chkActionValidee = new System.Windows.Forms.CheckBox();
            this.m_imageActionsDessous = new System.Windows.Forms.PictureBox();
            this.m_btnExpand = new System.Windows.Forms.Button();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelComments = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_btnInfo = new System.Windows.Forms.RadioButton();
            this.m_btnCommentaire = new System.Windows.Forms.RadioButton();
            this.m_panelFull.SuspendLayout();
            this.m_panelOriginal.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFromBase)).BeginInit();
            this.m_panelReleve.SuspendLayout();
            this.m_panelTypeReleve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageOeil)).BeginInit();
            this.m_panelAction.SuspendLayout();
            this.m_panelChooseAction.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelForExpand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageActionsDessous)).BeginInit();
            this.m_panelComments.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(21, 127);
            this.m_panelMarge.TabIndex = 0;
            // 
            // m_panelFull
            // 
            this.m_panelFull.Controls.Add(this.m_panelOriginal);
            this.m_panelFull.Controls.Add(this.m_panelReleve);
            this.m_panelFull.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelFull.Location = new System.Drawing.Point(54, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelFull, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFull.Name = "m_panelFull";
            this.m_panelFull.Size = new System.Drawing.Size(555, 127);
            this.m_panelFull.TabIndex = 2;
            // 
            // m_panelChampsOriginaux
            // 
            this.m_panelChampsOriginaux.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelChampsOriginaux.Location = new System.Drawing.Point(23, 40);
            this.m_extModeEdition.SetModeEdition(this.m_panelChampsOriginaux, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelChampsOriginaux.Name = "m_panelChampsOriginaux";
            this.m_panelChampsOriginaux.Size = new System.Drawing.Size(532, 24);
            this.m_panelChampsOriginaux.TabIndex = 8;
            // 
            // m_panelOriginal
            // 
            this.m_panelOriginal.Controls.Add(this.panel1);
            this.m_panelOriginal.Controls.Add(this.m_lblSerialDB);
            this.m_panelOriginal.Controls.Add(this.m_lblCoordDb);
            this.m_panelOriginal.Controls.Add(this.m_panelChampsOriginaux);
            this.m_panelOriginal.Controls.Add(this.m_imageFromBase);
            this.m_panelOriginal.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelOriginal.Location = new System.Drawing.Point(0, 63);
            this.m_extModeEdition.SetModeEdition(this.m_panelOriginal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelOriginal.Name = "m_panelOriginal";
            this.m_panelOriginal.Size = new System.Drawing.Size(555, 64);
            this.m_panelOriginal.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblRefFourDB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lblTypeDB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(316, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 40);
            this.panel1.TabIndex = 6;
            // 
            // m_lblRefFourDB
            // 
            this.m_lblRefFourDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblRefFourDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblRefFourDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblRefFourDB.Location = new System.Drawing.Point(20, 19);
            this.m_extModeEdition.SetModeEdition(this.m_lblRefFourDB, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblRefFourDB.Name = "m_lblRefFourDB";
            this.m_lblRefFourDB.Size = new System.Drawing.Size(218, 19);
            this.m_lblRefFourDB.TabIndex = 5;
            this.m_lblRefFourDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "P/N";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblTypeDB
            // 
            this.m_lblTypeDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblTypeDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblTypeDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTypeDB.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeDB, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeDB.Name = "m_lblTypeDB";
            this.m_lblTypeDB.Size = new System.Drawing.Size(238, 19);
            this.m_lblTypeDB.TabIndex = 4;
            this.m_lblTypeDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSerialDB
            // 
            this.m_lblSerialDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblSerialDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblSerialDB.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblSerialDB.Location = new System.Drawing.Point(146, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblSerialDB, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSerialDB.Name = "m_lblSerialDB";
            this.m_lblSerialDB.Size = new System.Drawing.Size(170, 40);
            this.m_lblSerialDB.TabIndex = 4;
            this.m_lblSerialDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblCoordDb
            // 
            this.m_lblCoordDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblCoordDb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCoordDb.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblCoordDb.Location = new System.Drawing.Point(23, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblCoordDb, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCoordDb.Name = "m_lblCoordDb";
            this.m_lblCoordDb.Size = new System.Drawing.Size(123, 40);
            this.m_lblCoordDb.TabIndex = 7;
            this.m_lblCoordDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_imageFromBase
            // 
            this.m_imageFromBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_imageFromBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageFromBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageFromBase.Image = global::timos.Properties.Resources.database;
            this.m_imageFromBase.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_imageFromBase, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageFromBase.Name = "m_imageFromBase";
            this.m_imageFromBase.Size = new System.Drawing.Size(23, 64);
            this.m_imageFromBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageFromBase.TabIndex = 0;
            this.m_imageFromBase.TabStop = false;
            this.m_imageFromBase.Click += new System.EventHandler(this.m_imageFromBase_Click);
            // 
            // m_panelReleve
            // 
            this.m_panelReleve.Controls.Add(this.m_panelTypeReleve);
            this.m_panelReleve.Controls.Add(this.m_lblSerialReleve);
            this.m_panelReleve.Controls.Add(this.m_lblCoordReleve);
            this.m_panelReleve.Controls.Add(this.m_panelChampsReleve);
            this.m_panelReleve.Controls.Add(this.m_imageOeil);
            this.m_panelReleve.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelReleve.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelReleve.Name = "m_panelReleve";
            this.m_panelReleve.Size = new System.Drawing.Size(555, 63);
            this.m_panelReleve.TabIndex = 0;
            // 
            // m_panelTypeReleve
            // 
            this.m_panelTypeReleve.Controls.Add(this.m_lblRefFourReleve);
            this.m_panelTypeReleve.Controls.Add(this.label1);
            this.m_panelTypeReleve.Controls.Add(this.m_lblTypeReleve);
            this.m_panelTypeReleve.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelTypeReleve.Location = new System.Drawing.Point(316, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTypeReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTypeReleve.Name = "m_panelTypeReleve";
            this.m_panelTypeReleve.Size = new System.Drawing.Size(238, 39);
            this.m_panelTypeReleve.TabIndex = 5;
            // 
            // m_lblRefFourReleve
            // 
            this.m_lblRefFourReleve.BackColor = System.Drawing.Color.White;
            this.m_lblRefFourReleve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblRefFourReleve.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblRefFourReleve.Location = new System.Drawing.Point(20, 19);
            this.m_extModeEdition.SetModeEdition(this.m_lblRefFourReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblRefFourReleve.Name = "m_lblRefFourReleve";
            this.m_lblRefFourReleve.Size = new System.Drawing.Size(218, 19);
            this.m_lblRefFourReleve.TabIndex = 5;
            this.m_lblRefFourReleve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 19);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "P/N";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblTypeReleve
            // 
            this.m_lblTypeReleve.BackColor = System.Drawing.Color.White;
            this.m_lblTypeReleve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblTypeReleve.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTypeReleve.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeReleve.Name = "m_lblTypeReleve";
            this.m_lblTypeReleve.Size = new System.Drawing.Size(238, 19);
            this.m_lblTypeReleve.TabIndex = 4;
            this.m_lblTypeReleve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSerialReleve
            // 
            this.m_lblSerialReleve.BackColor = System.Drawing.Color.White;
            this.m_lblSerialReleve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblSerialReleve.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblSerialReleve.Location = new System.Drawing.Point(146, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblSerialReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSerialReleve.Name = "m_lblSerialReleve";
            this.m_lblSerialReleve.Size = new System.Drawing.Size(170, 39);
            this.m_lblSerialReleve.TabIndex = 3;
            this.m_lblSerialReleve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblCoordReleve
            // 
            this.m_lblCoordReleve.BackColor = System.Drawing.Color.White;
            this.m_lblCoordReleve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCoordReleve.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblCoordReleve.Location = new System.Drawing.Point(23, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblCoordReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCoordReleve.Name = "m_lblCoordReleve";
            this.m_lblCoordReleve.Size = new System.Drawing.Size(123, 39);
            this.m_lblCoordReleve.TabIndex = 6;
            this.m_lblCoordReleve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_imageOeil
            // 
            this.m_imageOeil.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageOeil.Image = global::timos.Properties.Resources.eye;
            this.m_imageOeil.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_imageOeil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageOeil.Name = "m_imageOeil";
            this.m_imageOeil.Size = new System.Drawing.Size(23, 63);
            this.m_imageOeil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageOeil.TabIndex = 0;
            this.m_imageOeil.TabStop = false;
            // 
            // m_panelChampsReleve
            // 
            this.m_panelChampsReleve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelChampsReleve.Location = new System.Drawing.Point(23, 39);
            this.m_extModeEdition.SetModeEdition(this.m_panelChampsReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelChampsReleve.Name = "m_panelChampsReleve";
            this.m_panelChampsReleve.Size = new System.Drawing.Size(532, 24);
            this.m_panelChampsReleve.TabIndex = 7;
            // 
            // m_panelAction
            // 
            this.m_panelAction.Controls.Add(this.m_panelChooseAction);
            this.m_panelAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelAction.Location = new System.Drawing.Point(730, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelAction.Name = "m_panelAction";
            this.m_panelAction.Size = new System.Drawing.Size(202, 127);
            this.m_panelAction.TabIndex = 3;
            // 
            // m_panelChooseAction
            // 
            this.m_panelChooseAction.Controls.Add(this.m_lblAction);
            this.m_panelChooseAction.Controls.Add(this.panel2);
            this.m_panelChooseAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChooseAction.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelChooseAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelChooseAction.Name = "m_panelChooseAction";
            this.m_panelChooseAction.Size = new System.Drawing.Size(202, 127);
            this.m_panelChooseAction.TabIndex = 5;
            // 
            // m_lblAction
            // 
            this.m_lblAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblAction.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblAction.Name = "m_lblAction";
            this.m_lblAction.Size = new System.Drawing.Size(178, 127);
            this.m_lblAction.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnChooseAction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(178, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 127);
            this.panel2.TabIndex = 2;
            // 
            // m_btnChooseAction
            // 
            this.m_btnChooseAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnChooseAction.Image = global::timos.Properties.Resources.edit;
            this.m_btnChooseAction.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnChooseAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnChooseAction.Name = "m_btnChooseAction";
            this.m_btnChooseAction.Size = new System.Drawing.Size(24, 37);
            this.m_btnChooseAction.TabIndex = 0;
            this.m_btnChooseAction.UseVisualStyleBackColor = true;
            this.m_btnChooseAction.Click += new System.EventHandler(this.m_btnChooseAction_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1363642739_message_edit.png");
            this.imageList1.Images.SetKeyName(1, "Information.png");
            // 
            // m_lblCommentReleve
            // 
            this.m_lblCommentReleve.BackColor = System.Drawing.Color.White;
            this.m_lblCommentReleve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCommentReleve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblCommentReleve.Location = new System.Drawing.Point(29, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblCommentReleve, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCommentReleve.Name = "m_lblCommentReleve";
            this.m_lblCommentReleve.Size = new System.Drawing.Size(92, 127);
            this.m_lblCommentReleve.TabIndex = 7;
            this.m_lblCommentReleve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSep
            // 
            this.m_lblSep.BackColor = System.Drawing.Color.Gray;
            this.m_lblSep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lblSep.Location = new System.Drawing.Point(0, 127);
            this.m_extModeEdition.SetModeEdition(this.m_lblSep, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSep.Name = "m_lblSep";
            this.m_lblSep.Size = new System.Drawing.Size(932, 1);
            this.m_lblSep.TabIndex = 0;
            // 
            // m_panelForExpand
            // 
            this.m_panelForExpand.Controls.Add(this.m_chkActionValidee);
            this.m_panelForExpand.Controls.Add(this.m_imageActionsDessous);
            this.m_panelForExpand.Controls.Add(this.m_btnExpand);
            this.m_panelForExpand.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelForExpand.Location = new System.Drawing.Point(21, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelForExpand, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelForExpand.Name = "m_panelForExpand";
            this.m_panelForExpand.Size = new System.Drawing.Size(33, 127);
            this.m_panelForExpand.TabIndex = 8;
            // 
            // m_chkActionValidee
            // 
            this.m_chkActionValidee.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkActionValidee.AutoSize = true;
            this.m_chkActionValidee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_chkActionValidee.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkActionValidee.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkActionValidee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkActionValidee.Image = global::timos.Properties.Resources.Check16;
            this.m_chkActionValidee.Location = new System.Drawing.Point(0, 52);
            this.m_extModeEdition.SetModeEdition(this.m_chkActionValidee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkActionValidee.Name = "m_chkActionValidee";
            this.m_chkActionValidee.Size = new System.Drawing.Size(33, 22);
            this.m_chkActionValidee.TabIndex = 3;
            this.m_chkActionValidee.UseVisualStyleBackColor = false;
            this.m_chkActionValidee.CheckedChanged += new System.EventHandler(this.m_chkActionValidee_CheckedChanged);
            // 
            // m_imageActionsDessous
            // 
            this.m_imageActionsDessous.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_imageActionsDessous.Image = global::timos.Properties.Resources.child_Alert;
            this.m_imageActionsDessous.Location = new System.Drawing.Point(0, 33);
            this.m_extModeEdition.SetModeEdition(this.m_imageActionsDessous, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageActionsDessous.Name = "m_imageActionsDessous";
            this.m_imageActionsDessous.Size = new System.Drawing.Size(33, 19);
            this.m_imageActionsDessous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageActionsDessous.TabIndex = 2;
            this.m_imageActionsDessous.TabStop = false;
            // 
            // m_btnExpand
            // 
            this.m_btnExpand.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExpand.Image")));
            this.m_btnExpand.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnExpand, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnExpand.Name = "m_btnExpand";
            this.m_btnExpand.Size = new System.Drawing.Size(33, 33);
            this.m_btnExpand.TabIndex = 1;
            this.m_btnExpand.UseVisualStyleBackColor = true;
            this.m_btnExpand.Click += new System.EventHandler(this.m_btnExpand_Click);
            // 
            // m_panelComments
            // 
            this.m_panelComments.Controls.Add(this.m_lblCommentReleve);
            this.m_panelComments.Controls.Add(this.panel3);
            this.m_panelComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelComments.Location = new System.Drawing.Point(609, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelComments, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelComments.Name = "m_panelComments";
            this.m_panelComments.Size = new System.Drawing.Size(121, 127);
            this.m_panelComments.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_btnInfo);
            this.panel3.Controls.Add(this.m_btnCommentaire);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 127);
            this.panel3.TabIndex = 9;
            // 
            // m_btnInfo
            // 
            this.m_btnInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnInfo.AutoSize = true;
            this.m_btnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnInfo.Image = global::timos.Properties.Resources.Information;
            this.m_btnInfo.Location = new System.Drawing.Point(0, 30);
            this.m_extModeEdition.SetModeEdition(this.m_btnInfo, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnInfo.Name = "m_btnInfo";
            this.m_btnInfo.Size = new System.Drawing.Size(29, 30);
            this.m_btnInfo.TabIndex = 1;
            this.m_btnInfo.UseVisualStyleBackColor = true;
            this.m_btnInfo.CheckedChanged += new System.EventHandler(this.m_btnInfo_CheckedChanged);
            // 
            // m_btnCommentaire
            // 
            this.m_btnCommentaire.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnCommentaire.AutoSize = true;
            this.m_btnCommentaire.Checked = true;
            this.m_btnCommentaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnCommentaire.Image = global::timos.Properties.Resources.message_edit;
            this.m_btnCommentaire.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnCommentaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnCommentaire.Name = "m_btnCommentaire";
            this.m_btnCommentaire.Size = new System.Drawing.Size(29, 30);
            this.m_btnCommentaire.TabIndex = 0;
            this.m_btnCommentaire.TabStop = true;
            this.m_btnCommentaire.UseVisualStyleBackColor = true;
            this.m_btnCommentaire.CheckedChanged += new System.EventHandler(this.m_btnCommentaire_CheckedChanged);
            // 
            // CControlActionReleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_panelComments);
            this.Controls.Add(this.m_panelFull);
            this.Controls.Add(this.m_panelForExpand);
            this.Controls.Add(this.m_panelAction);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.m_lblSep);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlActionReleve";
            this.Size = new System.Drawing.Size(932, 128);
            this.Load += new System.EventHandler(this.CControlActionReleve_Load);
            this.m_panelFull.ResumeLayout(false);
            this.m_panelOriginal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFromBase)).EndInit();
            this.m_panelReleve.ResumeLayout(false);
            this.m_panelTypeReleve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageOeil)).EndInit();
            this.m_panelAction.ResumeLayout(false);
            this.m_panelChooseAction.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_panelForExpand.ResumeLayout(false);
            this.m_panelForExpand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageActionsDessous)).EndInit();
            this.m_panelComments.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelMarge;
        private System.Windows.Forms.Button m_btnExpand;
        private System.Windows.Forms.Panel m_panelFull;
        private System.Windows.Forms.Panel m_panelReleve;
        private System.Windows.Forms.PictureBox m_imageOeil;
        private System.Windows.Forms.Panel m_panelOriginal;
        private System.Windows.Forms.Label m_lblSerialDB;
        private System.Windows.Forms.PictureBox m_imageFromBase;
        private System.Windows.Forms.Label m_lblSerialReleve;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblRefFourDB;
        private System.Windows.Forms.Label m_lblTypeDB;
        private System.Windows.Forms.Label m_lblCoordDb;
        private System.Windows.Forms.Panel m_panelTypeReleve;
        private System.Windows.Forms.Label m_lblRefFourReleve;
        private System.Windows.Forms.Label m_lblTypeReleve;
        private System.Windows.Forms.Label m_lblCoordReleve;
        private System.Windows.Forms.Panel m_panelAction;
        private System.Windows.Forms.Label m_lblCommentReleve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblSep; 
        private System.Windows.Forms.Label m_lblAction;
        private System.Windows.Forms.Panel m_panelForExpand;
        private System.Windows.Forms.PictureBox m_imageActionsDessous;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnChooseAction;
        private System.Windows.Forms.Panel m_panelChooseAction;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Panel m_panelComments;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton m_btnInfo;
        private System.Windows.Forms.RadioButton m_btnCommentaire;
        private System.Windows.Forms.CheckBox m_chkActionValidee;
        private System.Windows.Forms.Panel m_panelChampsOriginaux;
        private System.Windows.Forms.Panel m_panelChampsReleve;
    }
}
