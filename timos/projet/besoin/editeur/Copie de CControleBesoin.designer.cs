using sc2i.win32.common.customizableList;
using timos.projet.besoin;
namespace timos.projet.besoin
{
    partial class CControleBesoin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleBesoin));
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_lblIndex = new System.Windows.Forms.Label();
            this.m_panelCentral = new System.Windows.Forms.Panel();
            this.m_iconPlusMoins = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbRegroupement = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_panelHeader = new System.Windows.Forms.Panel();
            this.m_panelTotalTotal = new System.Windows.Forms.Panel();
            this.m_txtTotalTotal = new sc2i.win32.common.C2iTextBoxNumerique();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelRegroupement = new System.Windows.Forms.Panel();
            this.m_panelCoutTotal = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.m_txtCoutTotal = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_panelDetailCout = new System.Windows.Forms.Panel();
            this.m_btnMenuQuantite = new System.Windows.Forms.PictureBox();
            this.m_imageBesoin = new System.Windows.Forms.PictureBox();
            this.m_btnDelete = new System.Windows.Forms.PictureBox();
            this.m_ctrlSatisfaction = new timos.projet.besoin.CControlePourResumeSatisfaction();
            this.m_picBoxSatisfait = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelDetails = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndListeQuantites = new timos.projet.besoin.CControleListeQuantites();
            this.m_panelFiletTop = new System.Windows.Forms.Panel();
            this.m_panelFiletBas = new System.Windows.Forms.Panel();
            this.m_menuBesoin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuTypeBesoin = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuActions = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyDeletedOnRuntimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelEditeurData = new System.Windows.Forms.Panel();
            this.m_menuSatisfactions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuDisplayMap = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSepSatisfaction = new System.Windows.Forms.ToolStripSeparator();
            this.m_panelFiletGauche = new System.Windows.Forms.PictureBox();
            this.m_picMarge = new System.Windows.Forms.PictureBox();
            this.m_panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_iconPlusMoins)).BeginInit();
            this.m_panelHeader.SuspendLayout();
            this.m_panelTotalTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panelRegroupement.SuspendLayout();
            this.m_panelCoutTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMenuQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageBesoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxSatisfait)).BeginInit();
            this.m_panelDetails.SuspendLayout();
            this.m_menuBesoin.SuspendLayout();
            this.m_menuSatisfactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelFiletGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarge)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(16, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(189, 20);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_lblIndex
            // 
            this.m_lblIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblIndex.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblIndex, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblIndex.Name = "m_lblIndex";
            this.m_lblIndex.Size = new System.Drawing.Size(20, 21);
            this.m_lblIndex.TabIndex = 6;
            this.m_lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelCentral
            // 
            this.m_panelCentral.Controls.Add(this.m_txtLibelle);
            this.m_panelCentral.Controls.Add(this.m_iconPlusMoins);
            this.m_panelCentral.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelCentral.Location = new System.Drawing.Point(41, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelCentral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCentral.Name = "m_panelCentral";
            this.m_panelCentral.Size = new System.Drawing.Size(205, 21);
            this.m_panelCentral.TabIndex = 0;
            this.m_panelCentral.TabStop = true;
            // 
            // m_iconPlusMoins
            // 
            this.m_iconPlusMoins.BackColor = System.Drawing.Color.Transparent;
            this.m_iconPlusMoins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_iconPlusMoins.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_iconPlusMoins.Image = global::timos.Properties.Resources.miniplus;
            this.m_iconPlusMoins.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_iconPlusMoins, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_iconPlusMoins.Name = "m_iconPlusMoins";
            this.m_iconPlusMoins.Size = new System.Drawing.Size(16, 21);
            this.m_iconPlusMoins.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_iconPlusMoins.TabIndex = 5;
            this.m_iconPlusMoins.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmbRegroupement
            // 
            this.m_cmbRegroupement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbRegroupement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRegroupement.FormattingEnabled = true;
            this.m_cmbRegroupement.IsLink = false;
            this.m_cmbRegroupement.ListDonnees = null;
            this.m_cmbRegroupement.Location = new System.Drawing.Point(15, 0);
            this.m_cmbRegroupement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbRegroupement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbRegroupement.Name = "m_cmbRegroupement";
            this.m_cmbRegroupement.NullAutorise = false;
            this.m_cmbRegroupement.ProprieteAffichee = null;
            this.m_cmbRegroupement.Size = new System.Drawing.Size(78, 21);
            this.m_cmbRegroupement.TabIndex = 0;
            this.m_cmbRegroupement.TextNull = "";
            this.m_cmbRegroupement.Tri = true;
            // 
            // m_panelHeader
            // 
            this.m_panelHeader.Controls.Add(this.m_panelTotalTotal);
            this.m_panelHeader.Controls.Add(this.m_panelRegroupement);
            this.m_panelHeader.Controls.Add(this.m_panelCoutTotal);
            this.m_panelHeader.Controls.Add(this.m_panelDetailCout);
            this.m_panelHeader.Controls.Add(this.m_panelCentral);
            this.m_panelHeader.Controls.Add(this.m_btnMenuQuantite);
            this.m_panelHeader.Controls.Add(this.m_imageBesoin);
            this.m_panelHeader.Controls.Add(this.m_btnDelete);
            this.m_panelHeader.Controls.Add(this.m_ctrlSatisfaction);
            this.m_panelHeader.Controls.Add(this.m_picBoxSatisfait);
            this.m_panelHeader.Controls.Add(this.m_lblIndex);
            this.m_panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeader.Location = new System.Drawing.Point(17, 2);
            this.m_extModeEdition.SetModeEdition(this.m_panelHeader, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeader.Name = "m_panelHeader";
            this.m_panelHeader.Size = new System.Drawing.Size(884, 21);
            this.m_panelHeader.TabIndex = 6;
            // 
            // m_panelTotalTotal
            // 
            this.m_panelTotalTotal.Controls.Add(this.m_txtTotalTotal);
            this.m_panelTotalTotal.Controls.Add(this.pictureBox1);
            this.m_panelTotalTotal.Controls.Add(this.label3);
            this.m_panelTotalTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelTotalTotal.Location = new System.Drawing.Point(668, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTotalTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTotalTotal.Name = "m_panelTotalTotal";
            this.m_panelTotalTotal.Size = new System.Drawing.Size(136, 21);
            this.m_panelTotalTotal.TabIndex = 14;
            // 
            // m_txtTotalTotal
            // 
            this.m_txtTotalTotal.Arrondi = 4;
            this.m_txtTotalTotal.DecimalAutorise = true;
            this.m_txtTotalTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTotalTotal.DoubleValue = null;
            this.m_txtTotalTotal.EmptyText = "Coût tot.";
            this.m_txtTotalTotal.IntValue = null;
            this.m_txtTotalTotal.Location = new System.Drawing.Point(15, 0);
            this.m_txtTotalTotal.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtTotalTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtTotalTotal.Name = "m_txtTotalTotal";
            this.m_txtTotalTotal.NullAutorise = true;
            this.m_txtTotalTotal.SelectAllOnEnter = true;
            this.m_txtTotalTotal.SeparateurMilliers = " ";
            this.m_txtTotalTotal.Size = new System.Drawing.Size(105, 20);
            this.m_txtTotalTotal.TabIndex = 18;
            this.m_txtTotalTotal.TabStop = false;
            this.m_txtTotalTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "=";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelRegroupement
            // 
            this.m_panelRegroupement.Controls.Add(this.m_cmbRegroupement);
            this.m_panelRegroupement.Controls.Add(this.label1);
            this.m_panelRegroupement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelRegroupement.Location = new System.Drawing.Point(575, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelRegroupement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelRegroupement.Name = "m_panelRegroupement";
            this.m_panelRegroupement.Size = new System.Drawing.Size(93, 21);
            this.m_panelRegroupement.TabIndex = 1;
            // 
            // m_panelCoutTotal
            // 
            this.m_panelCoutTotal.Controls.Add(this.pictureBox2);
            this.m_panelCoutTotal.Controls.Add(this.m_txtCoutTotal);
            this.m_panelCoutTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelCoutTotal.Location = new System.Drawing.Point(458, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelCoutTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCoutTotal.Name = "m_panelCoutTotal";
            this.m_panelCoutTotal.Size = new System.Drawing.Size(117, 21);
            this.m_panelCoutTotal.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(101, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // m_txtCoutTotal
            // 
            this.m_txtCoutTotal.Arrondi = 4;
            this.m_txtCoutTotal.DecimalAutorise = true;
            this.m_txtCoutTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtCoutTotal.DoubleValue = null;
            this.m_txtCoutTotal.EmptyText = "Coût tot.";
            this.m_txtCoutTotal.IntValue = null;
            this.m_txtCoutTotal.Location = new System.Drawing.Point(0, 0);
            this.m_txtCoutTotal.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCoutTotal.Name = "m_txtCoutTotal";
            this.m_txtCoutTotal.NullAutorise = true;
            this.m_txtCoutTotal.SelectAllOnEnter = true;
            this.m_txtCoutTotal.SeparateurMilliers = " ";
            this.m_txtCoutTotal.Size = new System.Drawing.Size(101, 20);
            this.m_txtCoutTotal.TabIndex = 0;
            this.m_txtCoutTotal.TabStop = false;
            this.m_txtCoutTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_panelDetailCout
            // 
            this.m_panelDetailCout.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelDetailCout.Location = new System.Drawing.Point(246, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelDetailCout, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDetailCout.Name = "m_panelDetailCout";
            this.m_panelDetailCout.Size = new System.Drawing.Size(212, 21);
            this.m_panelDetailCout.TabIndex = 1;
            // 
            // m_btnMenuQuantite
            // 
            this.m_btnMenuQuantite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnMenuQuantite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnMenuQuantite.Image = global::timos.Properties.Resources.quantity;
            this.m_btnMenuQuantite.Location = new System.Drawing.Point(806, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnMenuQuantite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnMenuQuantite.Name = "m_btnMenuQuantite";
            this.m_btnMenuQuantite.Size = new System.Drawing.Size(19, 21);
            this.m_btnMenuQuantite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnMenuQuantite.TabIndex = 9;
            this.m_btnMenuQuantite.TabStop = false;
            // 
            // m_imageBesoin
            // 
            this.m_imageBesoin.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageBesoin.Image = global::timos.Properties.Resources.PuzzleFem20;
            this.m_imageBesoin.Location = new System.Drawing.Point(20, 0);
            this.m_extModeEdition.SetModeEdition(this.m_imageBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageBesoin.Name = "m_imageBesoin";
            this.m_imageBesoin.Size = new System.Drawing.Size(21, 21);
            this.m_imageBesoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageBesoin.TabIndex = 1;
            this.m_imageBesoin.TabStop = false;
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnDelete.Image = global::timos.Properties.Resources.delete;
            this.m_btnDelete.Location = new System.Drawing.Point(825, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnDelete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(19, 21);
            this.m_btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnDelete.TabIndex = 8;
            this.m_btnDelete.TabStop = false;
            // 
            // m_ctrlSatisfaction
            // 
            this.m_ctrlSatisfaction.AllowDrop = true;
            this.m_ctrlSatisfaction.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctrlSatisfaction.Location = new System.Drawing.Point(844, 0);
            this.m_extModeEdition.SetModeEdition(this.m_ctrlSatisfaction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_ctrlSatisfaction.Name = "m_ctrlSatisfaction";
            this.m_ctrlSatisfaction.Size = new System.Drawing.Size(21, 21);
            this.m_ctrlSatisfaction.TabIndex = 10;
            this.m_ctrlSatisfaction.TabStop = false;
            // 
            // m_picBoxSatisfait
            // 
            this.m_picBoxSatisfait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picBoxSatisfait.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picBoxSatisfait.Image = global::timos.Properties.Resources.alerte;
            this.m_picBoxSatisfait.Location = new System.Drawing.Point(865, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picBoxSatisfait, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picBoxSatisfait.Name = "m_picBoxSatisfait";
            this.m_picBoxSatisfait.Size = new System.Drawing.Size(19, 21);
            this.m_picBoxSatisfait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_picBoxSatisfait.TabIndex = 4;
            this.m_picBoxSatisfait.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(844, 23);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(57, 62);
            this.panel1.TabIndex = 8;
            // 
            // m_panelDetails
            // 
            this.m_panelDetails.Controls.Add(this.label2);
            this.m_panelDetails.Controls.Add(this.m_wndListeQuantites);
            this.m_panelDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelDetails.Location = new System.Drawing.Point(17, 45);
            this.m_extModeEdition.SetModeEdition(this.m_panelDetails, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDetails.Name = "m_panelDetails";
            this.m_panelDetails.Size = new System.Drawing.Size(329, 40);
            this.m_panelDetails.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Détails";
            // 
            // m_wndListeQuantites
            // 
            this.m_wndListeQuantites.CurrentItemIndex = null;
            this.m_wndListeQuantites.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndListeQuantites.ItemControl = null;
            this.m_wndListeQuantites.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeQuantites.Location = new System.Drawing.Point(65, 0);
            this.m_wndListeQuantites.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeQuantites, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeQuantites.Name = "m_wndListeQuantites";
            this.m_wndListeQuantites.Size = new System.Drawing.Size(264, 40);
            this.m_wndListeQuantites.TabIndex = 7;
            this.m_wndListeQuantites.TabStop = false;
            // 
            // m_panelFiletTop
            // 
            this.m_panelFiletTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiletTop.Location = new System.Drawing.Point(17, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelFiletTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFiletTop.Name = "m_panelFiletTop";
            this.m_panelFiletTop.Size = new System.Drawing.Size(884, 2);
            this.m_panelFiletTop.TabIndex = 10;
            // 
            // m_panelFiletBas
            // 
            this.m_panelFiletBas.BackColor = System.Drawing.Color.Black;
            this.m_panelFiletBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelFiletBas.Location = new System.Drawing.Point(17, 85);
            this.m_extModeEdition.SetModeEdition(this.m_panelFiletBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFiletBas.Name = "m_panelFiletBas";
            this.m_panelFiletBas.Size = new System.Drawing.Size(884, 1);
            this.m_panelFiletBas.TabIndex = 11;
            // 
            // m_menuBesoin
            // 
            this.m_menuBesoin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuTypeBesoin,
            this.m_menuActions});
            this.m_extModeEdition.SetModeEdition(this.m_menuBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuBesoin.Name = "m_menuTypeCalcul";
            this.m_menuBesoin.Size = new System.Drawing.Size(170, 48);
            // 
            // m_menuTypeBesoin
            // 
            this.m_menuTypeBesoin.Image = global::timos.Properties.Resources.PuzzleFem20;
            this.m_menuTypeBesoin.Name = "m_menuTypeBesoin";
            this.m_menuTypeBesoin.Size = new System.Drawing.Size(169, 22);
            this.m_menuTypeBesoin.Text = "Need type|20672";
            // 
            // m_menuActions
            // 
            this.m_menuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyDeletedOnRuntimeToolStripMenuItem});
            this.m_menuActions.Name = "m_menuActions";
            this.m_menuActions.Size = new System.Drawing.Size(169, 22);
            this.m_menuActions.Text = "Actions|20673";
            // 
            // dummyDeletedOnRuntimeToolStripMenuItem
            // 
            this.dummyDeletedOnRuntimeToolStripMenuItem.Name = "dummyDeletedOnRuntimeToolStripMenuItem";
            this.dummyDeletedOnRuntimeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.dummyDeletedOnRuntimeToolStripMenuItem.Text = "Dummy deleted on runtime";
            // 
            // m_panelEditeurData
            // 
            this.m_panelEditeurData.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEditeurData.Location = new System.Drawing.Point(17, 23);
            this.m_extModeEdition.SetModeEdition(this.m_panelEditeurData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditeurData.Name = "m_panelEditeurData";
            this.m_panelEditeurData.Size = new System.Drawing.Size(827, 22);
            this.m_panelEditeurData.TabIndex = 13;
            // 
            // m_menuSatisfactions
            // 
            this.m_menuSatisfactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuDisplayMap,
            this.m_menuSepSatisfaction});
            this.m_extModeEdition.SetModeEdition(this.m_menuSatisfactions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuSatisfactions.Name = "m_menuSatisfactions";
            this.m_menuSatisfactions.Size = new System.Drawing.Size(177, 32);
            // 
            // m_menuDisplayMap
            // 
            this.m_menuDisplayMap.Name = "m_menuDisplayMap";
            this.m_menuDisplayMap.Size = new System.Drawing.Size(176, 22);
            this.m_menuDisplayMap.Text = "Display map|20635";
            // 
            // m_menuSepSatisfaction
            // 
            this.m_menuSepSatisfaction.Name = "m_menuSepSatisfaction";
            this.m_menuSepSatisfaction.Size = new System.Drawing.Size(173, 6);
            // 
            // m_panelFiletGauche
            // 
            this.m_panelFiletGauche.BackColor = System.Drawing.Color.Black;
            this.m_panelFiletGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelFiletGauche.Location = new System.Drawing.Point(16, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelFiletGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFiletGauche.Name = "m_panelFiletGauche";
            this.m_panelFiletGauche.Size = new System.Drawing.Size(1, 86);
            this.m_panelFiletGauche.TabIndex = 12;
            this.m_panelFiletGauche.TabStop = false;
            // 
            // m_picMarge
            // 
            this.m_picMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picMarge.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picMarge.Name = "m_picMarge";
            this.m_picMarge.Size = new System.Drawing.Size(16, 86);
            this.m_picMarge.TabIndex = 2;
            this.m_picMarge.TabStop = false;
            // 
            // CControleBesoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.Controls.Add(this.m_panelDetails);
            this.Controls.Add(this.m_panelEditeurData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelHeader);
            this.Controls.Add(this.m_panelFiletBas);
            this.Controls.Add(this.m_panelFiletTop);
            this.Controls.Add(this.m_panelFiletGauche);
            this.Controls.Add(this.m_picMarge);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleBesoin";
            this.Size = new System.Drawing.Size(901, 86);
            this.m_panelCentral.ResumeLayout(false);
            this.m_panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_iconPlusMoins)).EndInit();
            this.m_panelHeader.ResumeLayout(false);
            this.m_panelTotalTotal.ResumeLayout(false);
            this.m_panelTotalTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panelRegroupement.ResumeLayout(false);
            this.m_panelCoutTotal.ResumeLayout(false);
            this.m_panelCoutTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMenuQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageBesoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBoxSatisfait)).EndInit();
            this.m_panelDetails.ResumeLayout(false);
            this.m_menuBesoin.ResumeLayout(false);
            this.m_menuSatisfactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_panelFiletGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.PictureBox m_imageBesoin;
        private System.Windows.Forms.PictureBox m_picMarge;
        private System.Windows.Forms.PictureBox m_picBoxSatisfait;
        private System.Windows.Forms.PictureBox m_iconPlusMoins;
        private System.Windows.Forms.Label m_lblIndex;
        private System.Windows.Forms.Panel m_panelCentral;
        private System.Windows.Forms.PictureBox m_btnDelete;
        private System.Windows.Forms.Panel m_panelHeader;
        private CControleListeQuantites m_wndListeQuantites;
        private System.Windows.Forms.PictureBox m_btnMenuQuantite;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbRegroupement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel m_panelCoutTotal;
        private System.Windows.Forms.Panel m_panelRegroupement;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutTotal;
        private System.Windows.Forms.Panel m_panelFiletTop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel m_panelDetailCout;
        private System.Windows.Forms.Panel m_panelFiletBas;
        private System.Windows.Forms.PictureBox m_panelFiletGauche;
        private System.Windows.Forms.ContextMenuStrip m_menuBesoin;
        private System.Windows.Forms.Panel m_panelEditeurData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtTotalTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel m_panelTotalTotal;
        private System.Windows.Forms.ContextMenuStrip m_menuSatisfactions;
        private CControlePourResumeSatisfaction m_ctrlSatisfaction;
        private System.Windows.Forms.ToolStripMenuItem m_menuDisplayMap;
        private System.Windows.Forms.ToolStripSeparator m_menuSepSatisfaction;
        private System.Windows.Forms.ToolStripMenuItem m_menuTypeBesoin;
        private System.Windows.Forms.ToolStripMenuItem m_menuActions;
        private System.Windows.Forms.ToolStripMenuItem dummyDeletedOnRuntimeToolStripMenuItem;
    }
}
