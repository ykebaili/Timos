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

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionEnvoyerSMS : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;

		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CControleEditeFormule m_txtMessage;
        protected sc2i.win32.common.CExtStyle m_extStyle;
        private LinkLabel m_lnkAjouterDestinataire;
        private Panel m_panelDestinataires;
        private LinkLabel m_lnkSupprimerDestinataire;
        private Label label1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionEnvoyerSMS()
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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionEnvoyerSMS), typeof(CFormEditActionEnvoyerSMS));
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
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtMessage = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_lnkAjouterDestinataire = new System.Windows.Forms.LinkLabel();
            this.m_panelDestinataires = new System.Windows.Forms.Panel();
            this.m_lnkSupprimerDestinataire = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tabControl.SuspendLayout();
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
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 2;
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(567, 396);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 3;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.c2iTabControl2_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.m_lnkAjouterDestinataire);
            this.tabPage1.Controls.Add(this.m_panelDestinataires);
            this.tabPage1.Controls.Add(this.m_lnkSupprimerDestinataire);
            this.tabPage1.Controls.Add(this.m_txtMessage);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(551, 355);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Message|1029";
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMessage.BackColor = System.Drawing.Color.White;
            this.m_txtMessage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtMessage.Formule = null;
            this.m_txtMessage.Location = new System.Drawing.Point(8, 19);
            this.m_txtMessage.LockEdition = false;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.Size = new System.Drawing.Size(538, 103);
            this.m_extStyle.SetStyleBackColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMessage.TabIndex = 5;
            this.m_txtMessage.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 2;
            this.label4.Text = "Message|1029";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(570, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(192, 396);
            this.m_extStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(567, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 396);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // m_lnkAjouterDestinataire
            // 
            this.m_lnkAjouterDestinataire.Location = new System.Drawing.Point(7, 143);
            this.m_lnkAjouterDestinataire.Name = "m_lnkAjouterDestinataire";
            this.m_lnkAjouterDestinataire.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterDestinataire.TabIndex = 8;
            this.m_lnkAjouterDestinataire.TabStop = true;
            this.m_lnkAjouterDestinataire.Text = "Add recipient|1035";
            this.m_lnkAjouterDestinataire.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_panelDestinataires
            // 
            this.m_panelDestinataires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDestinataires.AutoScroll = true;
            this.m_panelDestinataires.Location = new System.Drawing.Point(10, 162);
            this.m_panelDestinataires.Name = "m_panelDestinataires";
            this.m_panelDestinataires.Size = new System.Drawing.Size(538, 190);
            this.m_extStyle.SetStyleBackColor(this.m_panelDestinataires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDestinataires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDestinataires.TabIndex = 6;
            // 
            // m_lnkSupprimerDestinataire
            // 
            this.m_lnkSupprimerDestinataire.Location = new System.Drawing.Point(165, 143);
            this.m_lnkSupprimerDestinataire.Name = "m_lnkSupprimerDestinataire";
            this.m_lnkSupprimerDestinataire.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerDestinataire.TabIndex = 7;
            this.m_lnkSupprimerDestinataire.TabStop = true;
            this.m_lnkSupprimerDestinataire.Text = "Remove|18";
            this.m_lnkSupprimerDestinataire.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerDestinataire_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 9;
            this.label1.Text = "Recipient|1030";
            // 
            // CFormEditActionEnvoyerSMS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(762, 444);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_wndAideFormule);
            this.Name = "CFormEditActionEnvoyerSMS";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Send a SMS|20353";
            this.Controls.SetChildIndex(this.m_wndAideFormule, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// ////////////////////////////////////////////////////
		private CActionEnvoyerSMS ActionEnvoyerSMS
		{
			get
			{
				return (CActionEnvoyerSMS)ObjetEdite;
			}
		}

		/// ////////////////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();

			m_wndAideFormule.FournisseurProprietes = ActionEnvoyerSMS.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtMessage.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);


			if ( ActionEnvoyerSMS.FormuleMessage != null )
				m_txtMessage.Text = ActionEnvoyerSMS.FormuleMessage.GetString();
			else
				m_txtMessage.Text = "\"\"";

            // Supprime tous les controles présents
			ArrayList lst = new ArrayList( m_panelDestinataires.Controls );
			foreach ( Control ctrl in lst )
			{
				if ( ctrl== m_txtFormule)
					m_txtFormule = null;
				ctrl.Hide();
				m_panelDestinataires.Controls.Remove ( ctrl );
				ctrl.Dispose();
			}

            

			foreach ( C2iExpression expression in ActionEnvoyerSMS.ListeFormulesDestinataires )
			{
				if ( expression != null )
				{
					AddTextBox ( m_panelDestinataires ).Text = expression.GetString();
				}
			}

            
		}

		/// ////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression ( 
				new CContexteAnalyse2iExpression ( ActionEnvoyerSMS.Process, typeof(CProcess) ) );


			result &= analyseur.AnalyseChaine ( m_txtMessage.Text );
			if ( !result )
				result.EmpileErreur (I.T( "Error in the message formula|1049"));
			else
				ActionEnvoyerSMS.FormuleMessage = (C2iExpression)result.Data;

			// MAJ des Destinataires To
            ActionEnvoyerSMS.ListeFormulesDestinataires.Clear();
			foreach ( sc2i.win32.expression.CControleEditeFormule txt in m_panelDestinataires.Controls )
			{
				result &= analyseur.AnalyseChaine ( txt.Text );
				if ( !result )
					result.EmpileErreur(I.T( "Error in the recipient formula|1050"));
				else
                    ActionEnvoyerSMS.ListeFormulesDestinataires.Add(result.Data);
			}

           	return result;
		}

		//--------------------------------------------------------------------------------
		private void OnEnterTexteFormule(object sender, System.EventArgs e)
		{
			if ( m_txtFormule != null )
				m_txtFormule.BackColor = Color.White;

            m_txtFormule = sender as sc2i.win32.expression.CControleEditeFormule;
            if (m_txtFormule != null)
            {
                m_txtFormule.BackColor = Color.LightGreen;
            }
            //if ( sender is sc2i.win32.expression.CControleEditeFormule )
            //{
            //    m_txtFormule = (sc2i.win32.expression.CControleEditeFormule)sender;
            //    m_txtFormule.BackColor = Color.LightGreen;
            //}
		}

		//--------------------------------------------------------------------------------
		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule != null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

		//--------------------------------------------------------------------------------
		private sc2i.win32.expression.CControleEditeFormule AddTextBox ( Control parent )
		{
			sc2i.win32.expression.CControleEditeFormule txt = new sc2i.win32.expression.CControleEditeFormule();
			txt.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			txt.Height = 60;
			txt.Enter += new EventHandler(OnEnterTexteFormule);
			txt.CreateControl();
			parent.Controls.Add ( txt );
			txt.Dock = DockStyle.Top;
			return txt;
		}

		//--------------------------------------------------------------------------------
		private void m_lnkAjouter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AddTextBox ( m_panelDestinataires ).Text = "\"\"";
		}

		//--------------------------------------------------------------------------------
		private void m_lnkSupprimerDestinataire_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_txtFormule != null &&
				m_txtFormule.Parent == m_panelDestinataires )
			{
				m_txtFormule.Hide();
				m_panelDestinataires.Controls.Remove ( m_txtFormule );
				m_txtFormule.Dispose();
			}
		}

		

        private void c2iTabControl2_SelectionChanged(object sender, EventArgs e)
        {

        }


	}
}

