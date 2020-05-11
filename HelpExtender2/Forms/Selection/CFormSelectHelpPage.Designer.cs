namespace HelpExtender
{
	partial class CFormSelectHelpPage
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

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_wndListePages = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panelHaut = new System.Windows.Forms.Panel();
            this.m_txtRecherche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_timerRecherche = new System.Windows.Forms.Timer(this.components);
            this.pan_contenu = new System.Windows.Forms.Panel();
            this.ctrl_selectSelonTitre = new HelpExtender.CCtrlSelectTousAvecTitre();
            this.ctrl_selectMenu = new HelpExtender.CCtrlEditMenu();
            this.ctrl_selectType = new HelpExtender.CCtrlSelectHelpType();
            this.ctrl_selectIndependant = new HelpExtender.CCtrlSelectHelpLibre();
            this.ctrl_selectControl = new HelpExtender.CCtrlSelectHelpControl();
            this.pan_liaison = new System.Windows.Forms.Panel();
            this.ctrl_selectTypeSelection = new HelpExtender.CCtrlTypeSelection();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pan_btns = new System.Windows.Forms.Panel();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.m_panelBas.SuspendLayout();
            this.m_panelHaut.SuspendLayout();
            this.pan_contenu.SuspendLayout();
            this.pan_liaison.SuspendLayout();
            this.pan_btns.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListePages
            // 
            this.m_wndListePages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListePages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListePages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListePages.Location = new System.Drawing.Point(0, 26);
            this.m_wndListePages.Name = "m_wndListePages";
            this.m_wndListePages.Size = new System.Drawing.Size(406, 348);
            this.m_wndListePages.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_wndListePages.TabIndex = 0;
            this.m_wndListePages.UseCompatibleStateImageBehavior = false;
            this.m_wndListePages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 381;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnAnnuler);
            this.m_panelBas.Controls.Add(this.m_btnOk);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 374);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(406, 34);
            this.m_panelBas.TabIndex = 1;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(225, 6);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Annuler";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(107, 6);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_txtRecherche);
            this.m_panelHaut.Controls.Add(this.label1);
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(406, 26);
            this.m_panelHaut.TabIndex = 2;
            // 
            // m_txtRecherche
            // 
            this.m_txtRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRecherche.Location = new System.Drawing.Point(74, 0);
            this.m_txtRecherche.Name = "m_txtRecherche";
            this.m_txtRecherche.Size = new System.Drawing.Size(320, 20);
            this.m_txtRecherche.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rechercher";
            // 
            // m_timerRecherche
            // 
            this.m_timerRecherche.Interval = 500;
            // 
            // pan_contenu
            // 
            this.pan_contenu.Controls.Add(this.ctrl_selectSelonTitre);
            this.pan_contenu.Controls.Add(this.ctrl_selectMenu);
            this.pan_contenu.Controls.Add(this.ctrl_selectType);
            this.pan_contenu.Controls.Add(this.ctrl_selectIndependant);
            this.pan_contenu.Controls.Add(this.ctrl_selectControl);
            this.pan_contenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_contenu.Location = new System.Drawing.Point(0, 29);
            this.pan_contenu.Name = "pan_contenu";
            this.pan_contenu.Size = new System.Drawing.Size(576, 360);
            this.pan_contenu.TabIndex = 0;
            // 
            // ctrl_selectSelonTitre
            // 
            this.ctrl_selectSelonTitre.Location = new System.Drawing.Point(200, 32);
            this.ctrl_selectSelonTitre.Name = "ctrl_selectSelonTitre";
            this.ctrl_selectSelonTitre.Size = new System.Drawing.Size(133, 101);
            this.ctrl_selectSelonTitre.TabIndex = 6;
            this.ctrl_selectSelonTitre.DoubleClickHelp += new System.EventHandler(this.DoubleClickHelp);
            // 
            // ctrl_selectMenu
            // 
            this.ctrl_selectMenu.Location = new System.Drawing.Point(241, 240);
            this.ctrl_selectMenu.Name = "ctrl_selectMenu";
            this.ctrl_selectMenu.Size = new System.Drawing.Size(92, 93);
            this.ctrl_selectMenu.TabIndex = 5;
            this.ctrl_selectMenu.DoubleClickHelp += new System.EventHandler(this.DoubleClickHelp);
            // 
            // ctrl_selectType
            // 
            this.ctrl_selectType.Location = new System.Drawing.Point(383, 192);
            this.ctrl_selectType.Name = "ctrl_selectType";
            this.ctrl_selectType.Size = new System.Drawing.Size(112, 100);
            this.ctrl_selectType.TabIndex = 3;
            // 
            // ctrl_selectIndependant
            // 
            this.ctrl_selectIndependant.Location = new System.Drawing.Point(383, 55);
            this.ctrl_selectIndependant.Name = "ctrl_selectIndependant";
            this.ctrl_selectIndependant.Size = new System.Drawing.Size(164, 107);
            this.ctrl_selectIndependant.TabIndex = 2;
            this.ctrl_selectIndependant.DoubleClickHelp += new System.EventHandler(this.DoubleClickHelp);
            // 
            // ctrl_selectControl
            // 
            this.ctrl_selectControl.Location = new System.Drawing.Point(40, 55);
            this.ctrl_selectControl.Name = "ctrl_selectControl";
            this.ctrl_selectControl.Size = new System.Drawing.Size(154, 107);
            this.ctrl_selectControl.TabIndex = 1;
            this.ctrl_selectControl.DoubleClickHelp += new System.EventHandler(this.DoubleClickHelp);
            // 
            // pan_liaison
            // 
            this.pan_liaison.Controls.Add(this.ctrl_selectTypeSelection);
            this.pan_liaison.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_liaison.Location = new System.Drawing.Point(0, 0);
            this.pan_liaison.Name = "pan_liaison";
            this.pan_liaison.Size = new System.Drawing.Size(576, 29);
            this.pan_liaison.TabIndex = 0;
            // 
            // ctrl_selectTypeSelection
            // 
            this.ctrl_selectTypeSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrl_selectTypeSelection.Liaison = HelpExtender.ETypeSelection.Controles;
            this.ctrl_selectTypeSelection.Location = new System.Drawing.Point(0, 0);
            this.ctrl_selectTypeSelection.Name = "ctrl_selectTypeSelection";
            this.ctrl_selectTypeSelection.Size = new System.Drawing.Size(576, 29);
            this.ctrl_selectTypeSelection.TabIndex = 0;
            this.ctrl_selectTypeSelection.ChangementTypeLiaison += new System.EventHandler(this.ctrl_selectLiaison_ChangementTypeLiaison);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(195, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Ok|10";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pan_btns
            // 
            this.pan_btns.Controls.Add(this.btn_annuler);
            this.pan_btns.Controls.Add(this.btn_ok);
            this.pan_btns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_btns.Location = new System.Drawing.Point(0, 389);
            this.pan_btns.Name = "pan_btns";
            this.pan_btns.Size = new System.Drawing.Size(576, 30);
            this.pan_btns.TabIndex = 0;
            // 
            // btn_annuler
            // 
            this.btn_annuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_annuler.Location = new System.Drawing.Point(306, 4);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_annuler.TabIndex = 1;
            this.btn_annuler.Text = "Cancel|11";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // CFormSelectHelpPage
            // 
            this.AcceptButton = this.btn_ok;
            this.ClientSize = new System.Drawing.Size(576, 419);
            this.Controls.Add(this.pan_contenu);
            this.Controls.Add(this.pan_liaison);
            this.Controls.Add(this.pan_btns);
            this.Name = "CFormSelectHelpPage";
            this.m_panelBas.ResumeLayout(false);
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelHaut.PerformLayout();
            this.pan_contenu.ResumeLayout(false);
            this.pan_liaison.ResumeLayout(false);
            this.pan_btns.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView m_wndListePages;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel m_panelBas;
		private System.Windows.Forms.Panel m_panelHaut;
		private System.Windows.Forms.TextBox m_txtRecherche;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Timer m_timerRecherche;
		private System.Windows.Forms.Panel pan_contenu;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Panel pan_btns;
		private System.Windows.Forms.Button btn_annuler;
		private System.Windows.Forms.Panel pan_liaison;
		private CCtrlTypeSelection ctrl_selectTypeSelection;
		private CCtrlSelectHelpType ctrl_selectType;
		private CCtrlSelectHelpLibre ctrl_selectIndependant;
		private CCtrlSelectHelpControl ctrl_selectControl;
		private CCtrlEditMenu ctrl_selectMenu;
		private CCtrlSelectTousAvecTitre ctrl_selectSelonTitre;
	}
}