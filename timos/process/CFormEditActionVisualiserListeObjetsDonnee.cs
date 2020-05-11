using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;
using timos.process;
using sc2i.win32.expression;

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionVisualiserListeObjetsDonnee : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
		private System.Windows.Forms.CheckBox m_chkFiltreDefaut;
		private sc2i.win32.common.C2iTabControl c2iTabControl2;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.common.C2iPanel m_tmp;
		private System.Windows.Forms.Panel panel2;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleTitre;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleContexteUtilisation;
        private sc2i.win32.common.CExtStyle m_ExtStyle;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionVisualiserListeObjetsDonnee()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
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

		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionVisualiserListeObjetsDonnee), typeof(CFormEditActionVisualiserListeObjetsDonnee));
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_chkFiltreDefaut = new System.Windows.Forms.CheckBox();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl2 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleContexteUtilisation = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormuleTitre = new sc2i.win32.expression.CControleEditeFormule();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_tmp = new sc2i.win32.common.C2iPanel(this.components);
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.c2iTabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(712, 328);
            this.m_ExtStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 2;
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // m_chkFiltreDefaut
            // 
            this.m_chkFiltreDefaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkFiltreDefaut.BackColor = System.Drawing.Color.White;
            this.m_chkFiltreDefaut.Location = new System.Drawing.Point(8, 272);
            this.m_chkFiltreDefaut.Name = "m_chkFiltreDefaut";
            this.m_chkFiltreDefaut.Size = new System.Drawing.Size(184, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkFiltreDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkFiltreDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFiltreDefaut.TabIndex = 5;
            this.m_chkFiltreDefaut.Text = "Apply default filter|30252";
            this.m_chkFiltreDefaut.UseVisualStyleBackColor = false;
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltre.LockEdition = false;
            this.m_panelFiltre.ModeSansType = false;
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(592, 296);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 3;
            this.m_panelFiltre.OnChangeTypeElements += new sc2i.win32.data.dynamic.ChangeTypeElementsEventHandler(this.m_panelFiltre_OnChangeTypeElements);
            // 
            // c2iTabControl2
            // 
            this.c2iTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl2.BoldSelectedPage = true;
            this.c2iTabControl2.ControlBottomOffset = 16;
            this.c2iTabControl2.ControlRightOffset = 16;
            this.c2iTabControl2.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl2.IDEPixelArea = false;
            this.c2iTabControl2.Location = new System.Drawing.Point(8, 8);
            this.c2iTabControl2.Name = "c2iTabControl2";
            this.c2iTabControl2.Ombre = true;
            this.c2iTabControl2.PositionTop = true;
            this.c2iTabControl2.SelectedIndex = 0;
            this.c2iTabControl2.SelectedTab = this.tabPage1;
            this.c2iTabControl2.Size = new System.Drawing.Size(608, 336);
            this.m_ExtStyle.SetStyleBackColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl2.TabIndex = 4004;
            this.c2iTabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl2.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.m_wndAideFormule);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(592, 295);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Options|56";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_txtFormuleContexteUtilisation);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_txtFormuleTitre);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 295);
            this.m_ExtStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 13;
            this.label5.Text = "Using context|1056";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // m_txtFormuleContexteUtilisation
            // 
            this.m_txtFormuleContexteUtilisation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleContexteUtilisation.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleContexteUtilisation.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleContexteUtilisation.Formule = null;
            this.m_txtFormuleContexteUtilisation.Location = new System.Drawing.Point(6, 136);
            this.m_txtFormuleContexteUtilisation.LockEdition = false;
            this.m_txtFormuleContexteUtilisation.Name = "m_txtFormuleContexteUtilisation";
            this.m_txtFormuleContexteUtilisation.Size = new System.Drawing.Size(384, 152);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleContexteUtilisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleContexteUtilisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleContexteUtilisation.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 11;
            this.label1.Text = "Window title|1055";
            // 
            // m_txtFormuleTitre
            // 
            this.m_txtFormuleTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTitre.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleTitre.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleTitre.Formule = null;
            this.m_txtFormuleTitre.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormuleTitre.LockEdition = false;
            this.m_txtFormuleTitre.Name = "m_txtFormuleTitre";
            this.m_txtFormuleTitre.Size = new System.Drawing.Size(384, 88);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleTitre.TabIndex = 10;
            this.m_txtFormuleTitre.Enter += new System.EventHandler(this.m_txtFormuleTitre_Enter);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(397, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 295);
            this.m_ExtStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(400, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(192, 295);
            this.m_ExtStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 5;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_chkFiltreDefaut);
            this.tabPage1.Controls.Add(this.m_panelFiltre);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(592, 295);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Filter|581";
            // 
            // m_tmp
            // 
            this.m_tmp.Location = new System.Drawing.Point(144, 64);
            this.m_tmp.LockEdition = false;
            this.m_tmp.Name = "m_tmp";
            this.m_tmp.Size = new System.Drawing.Size(80, 32);
            this.m_ExtStyle.SetStyleBackColor(this.m_tmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_tmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tmp.TabIndex = 0;
            // 
            // CFormEditActionVisualiserListeObjetsDonnee
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 390);
            this.Controls.Add(this.c2iTabControl2);
            this.Name = "CFormEditActionVisualiserListeObjetsDonnee";
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Displaying a list of objects|1054";
            this.Load += new System.EventHandler(this.CFormEditActionVisualiserListeObjetsDonnee_Load);
            this.Controls.SetChildIndex(this.c2iTabControl2, 0);
            this.c2iTabControl2.ResumeLayout(false);
            this.c2iTabControl2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		private void m_panelFiltre_OnChangeTypeElements(object sender, System.Type typeSelectionne)
		{
			ActionVisualiser.Filtre = m_panelFiltre.FiltreDynamique;
		}


		/// ////////////////////////////////////////////////////
		private CActionVisualiserListeObjetsDonnee ActionVisualiser
		{
			get
			{
				return (CActionVisualiserListeObjetsDonnee)ObjetEdite;
			}
		}

		/// ////////////////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_panelFiltre.InitSansVariables ((CFiltreDynamique)ActionVisualiser.Filtre.Clone());
			m_chkFiltreDefaut.Checked = ActionVisualiser.AppliquerFiltreParDefaut;
			m_chkFiltreDefaut.BringToFront();

			m_wndAideFormule.FournisseurProprietes = ActionVisualiser.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtFormuleTitre.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleContexteUtilisation.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			m_txtFormuleTitre.Formule = ActionVisualiser.ExpressionTitreFenetre;
			m_txtFormuleContexteUtilisation.Formule = ActionVisualiser.ExpressionContexteFenetre;

			OnEnterTextFormule(m_txtFormuleTitre);
		}

		/// ////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			ActionVisualiser.Filtre = (CFiltreDynamique)m_panelFiltre.FiltreDynamique.Clone();
			ActionVisualiser.AppliquerFiltreParDefaut = m_chkFiltreDefaut.Checked;
			CResultAErreur result = base.MAJ_Champs();
			if ( m_txtFormuleTitre.Text != "" )
			{
				ActionVisualiser.ExpressionTitreFenetre = m_txtFormuleTitre.Formule;
				if ( !m_txtFormuleTitre.ResultAnalyse )
					return m_txtFormuleTitre.ResultAnalyse;
			}
			else
				ActionVisualiser.ExpressionTitreFenetre = null;

			if ( m_txtFormuleContexteUtilisation.Text != "" )
			{
				ActionVisualiser.ExpressionContexteFenetre = m_txtFormuleContexteUtilisation.Formule;
				if ( !m_txtFormuleContexteUtilisation.ResultAnalyse )
					return m_txtFormuleContexteUtilisation.ResultAnalyse;
			}
			else
				ActionVisualiser.ExpressionContexteFenetre = null;

			
			return result;
		}

		private void CFormEditActionVisualiserListeObjetsDonnee_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtFormuleTitre_Enter(object sender, System.EventArgs e)
		{
			OnEnterTextFormule ( sender );
		}

		private void OnEnterTextFormule ( object sender )
		{
			if ( sender is CControleEditeFormule )
			{
				if ( m_txtFormule != null )
					m_txtFormule.BackColor = Color.White;
				m_txtFormule = (CControleEditeFormule)sender;
				m_txtFormule.BackColor = Color.LightGreen;
			}
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule != null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}




	}
}

