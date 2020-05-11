using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.win32.process;
using timos.process;
using timos.securite;
using sc2i.win32.data.dynamic;

namespace timos
{
	[AutoExec("Autoexec")]
	public class CFormEditActionDefinirUtilisateur : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.LinkLabel m_btnSelectionnerUtilisateur;
		private System.Windows.Forms.Label m_lblUtilisateurEnDur;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionDefinirUtilisateur()
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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionDefinirUtilisateur), typeof(CFormEditActionDefinirUtilisateur));
		}


		public CActionDefinirUtilisateur ActionDefUser
		{
			get
			{
				return (CActionDefinirUtilisateur)ObjetEdite;
			}
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormule = new sc2i.win32.expression.CControleEditeFormule();
            this.m_lblUtilisateurEnDur = new System.Windows.Forms.Label();
            this.m_btnSelectionnerUtilisateur = new System.Windows.Forms.LinkLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.m_wndAideFormule);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 352);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.m_txtFormule);
            this.panel3.Controls.Add(this.m_lblUtilisateurEnDur);
            this.panel3.Controls.Add(this.m_btnSelectionnerUtilisateur);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 352);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id de l\'utilisateur";
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormule.BackColor = System.Drawing.Color.White;
            this.m_txtFormule.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(549, 300);
            this.m_txtFormule.TabIndex = 2;
            this.m_txtFormule.Validated += new System.EventHandler(this.m_txtFormule_Validated);
            // 
            // m_lblUtilisateurEnDur
            // 
            this.m_lblUtilisateurEnDur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblUtilisateurEnDur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblUtilisateurEnDur.Location = new System.Drawing.Point(8, 329);
            this.m_lblUtilisateurEnDur.Name = "m_lblUtilisateurEnDur";
            this.m_lblUtilisateurEnDur.Size = new System.Drawing.Size(549, 16);
            this.m_lblUtilisateurEnDur.TabIndex = 4;
            this.m_lblUtilisateurEnDur.Text = "Nom de l\'utilisateur en dur s\'il y a lieu";
            this.m_lblUtilisateurEnDur.Visible = false;
            // 
            // m_btnSelectionnerUtilisateur
            // 
            this.m_btnSelectionnerUtilisateur.Location = new System.Drawing.Point(136, 8);
            this.m_btnSelectionnerUtilisateur.Name = "m_btnSelectionnerUtilisateur";
            this.m_btnSelectionnerUtilisateur.Size = new System.Drawing.Size(144, 16);
            this.m_btnSelectionnerUtilisateur.TabIndex = 3;
            this.m_btnSelectionnerUtilisateur.TabStop = true;
            this.m_btnSelectionnerUtilisateur.Text = "Select a User|1025";
            this.m_btnSelectionnerUtilisateur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_btnSelectionnerUtilisateur_LinkClicked);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(565, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 352);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(568, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(176, 352);
            this.m_wndAideFormule.TabIndex = 0;
			this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // CFormEditActionDefinirUtilisateur
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 398);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionDefinirUtilisateur";
            this.Text = "Change User|1024";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			result = GetExpressionUtilisateur();
			if ( !result )
				return result;
			ActionDefUser.ExpressionUtilisateur = (C2iExpression)result.Data;
			return result;
		}

		/// //////////////////////////////////////////
		protected CResultAErreur GetExpressionUtilisateur()
		{
			CResultAErreur result = CResultAErreur.True;
			CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression ( ObjetEdite.Process, typeof(CProcess));
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
			result = analyseur.AnalyseChaine ( m_txtFormule.Text );
			return result;
		}

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_wndAideFormule.FournisseurProprietes = ObjetEdite.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtFormule.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			if ( ActionDefUser.ExpressionUtilisateur != null )
				m_txtFormule.Text = ActionDefUser.ExpressionUtilisateur.GetString();

			UpdateUtilisateurEnDur();
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

		/// //////////////////////////////////////////
		private void m_txtFormule_Validated(object sender, System.EventArgs e)
		{
			UpdateUtilisateurEnDur();
		}

		/// //////////////////////////////////////////
		private void UpdateUtilisateurEnDur()
		{
			CResultAErreur result = GetExpressionUtilisateur();
			if ( !result )
				m_lblUtilisateurEnDur.Visible = false;
			CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(null);
			C2iExpression exp = (C2iExpression)result.Data;
			if ( exp != null )
			{
				result = exp.Eval ( ctx );
				if ( result )
				{
					try
					{
						int nId = Convert.ToInt32(result.Data);
						using ( CContexteDonnee contexte = new CContexteDonnee ( CTimosApp.SessionClient.IdSession, true, false ) )
						{
							CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( contexte );
							if ( user.ReadIfExists ( nId ) )
							{
								m_lblUtilisateurEnDur.Text = user.Acteur.Nom;
								m_lblUtilisateurEnDur.Visible = true;
								return;
							}
						}
					}
					catch{}
				}
			}
			m_lblUtilisateurEnDur.Visible = false;
		}

		/// //////////////////////////////////////////
		private void m_btnSelectionnerUtilisateur_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{	
			CDonneesActeurUtilisateur user = (CDonneesActeurUtilisateur)CFormSelectUnObjetDonnee.SelectObjetDonnee ( 
                I.T("Select an application user|20739"),
                typeof(CDonneesActeurUtilisateur),
                null,
                "NomDestinataireMessage");
			if ( user != null )
			{
				m_txtFormule.Text = user.Id.ToString();;
			}
		}
		

		




	}
}

