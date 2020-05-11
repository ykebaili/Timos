using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.win32.process;

namespace timos.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionEditerElement : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView m_wndListeVariables;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleElement;
		private CheckBox m_chkDansNavigateurPrincipal;
        private CheckBox m_chkDansNouvelOnglet;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleCodeFormulaire;
        private Label label2;
        private SplitContainer m_splitContainer1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionEditerElement()
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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionEditerElement), typeof(CFormEditActionEditerElement));
		}


		public CActionEditerElement ActionEditerElement
		{
			get
			{
				return (CActionEditerElement)ObjetEdite;
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
            this.m_chkDansNavigateurPrincipal = new System.Windows.Forms.CheckBox();
            this.m_txtFormuleElement = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.m_wndListeVariables = new System.Windows.Forms.ListView();
            this.m_txtFormuleCodeFormulaire = new sc2i.win32.expression.CControleEditeFormule();
            this.m_chkDansNouvelOnglet = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            this.m_splitContainer1.Panel1.SuspendLayout();
            this.m_splitContainer1.Panel2.SuspendLayout();
            this.m_splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_splitContainer1);
            this.panel2.Location = new System.Drawing.Point(0, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 311);
            this.panel2.TabIndex = 2;
            // 
            // m_chkDansNavigateurPrincipal
            // 
            this.m_chkDansNavigateurPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkDansNavigateurPrincipal.Location = new System.Drawing.Point(3, 253);
            this.m_chkDansNavigateurPrincipal.Name = "m_chkDansNavigateurPrincipal";
            this.m_chkDansNavigateurPrincipal.Size = new System.Drawing.Size(274, 24);
            this.m_chkDansNavigateurPrincipal.TabIndex = 3;
            this.m_chkDansNavigateurPrincipal.Text = "Edit in main window|1254";
            this.m_chkDansNavigateurPrincipal.UseVisualStyleBackColor = true;
            this.m_chkDansNavigateurPrincipal.CheckedChanged += new System.EventHandler(this.m_chkDansNavigateurPrincipal_CheckedChanged);
            // 
            // m_txtFormuleElement
            // 
            this.m_txtFormuleElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleElement.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleElement.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleElement.Formule = null;
            this.m_txtFormuleElement.Location = new System.Drawing.Point(3, 27);
            this.m_txtFormuleElement.LockEdition = false;
            this.m_txtFormuleElement.Name = "m_txtFormuleElement";
            this.m_txtFormuleElement.Size = new System.Drawing.Size(405, 159);
            this.m_txtFormuleElement.TabIndex = 2;
            this.m_txtFormuleElement.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Element to edit|1027";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(180, 307);
            this.m_wndAideFormule.TabIndex = 0;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // m_wndListeVariables
            // 
            this.m_wndListeVariables.Location = new System.Drawing.Point(8, 8);
            this.m_wndListeVariables.Name = "m_wndListeVariables";
            this.m_wndListeVariables.Size = new System.Drawing.Size(544, 256);
            this.m_wndListeVariables.TabIndex = 0;
            this.m_wndListeVariables.UseCompatibleStateImageBehavior = false;
            this.m_wndListeVariables.View = System.Windows.Forms.View.Details;
            // 
            // m_txtFormuleCodeFormulaire
            // 
            this.m_txtFormuleCodeFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCodeFormulaire.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleCodeFormulaire.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleCodeFormulaire.Formule = null;
            this.m_txtFormuleCodeFormulaire.Location = new System.Drawing.Point(3, 208);
            this.m_txtFormuleCodeFormulaire.LockEdition = false;
            this.m_txtFormuleCodeFormulaire.Name = "m_txtFormuleCodeFormulaire";
            this.m_txtFormuleCodeFormulaire.Size = new System.Drawing.Size(405, 40);
            this.m_txtFormuleCodeFormulaire.TabIndex = 4;
            this.m_txtFormuleCodeFormulaire.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_chkDansNouvelOnglet
            // 
            this.m_chkDansNouvelOnglet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkDansNouvelOnglet.Location = new System.Drawing.Point(3, 276);
            this.m_chkDansNouvelOnglet.Name = "m_chkDansNouvelOnglet";
            this.m_chkDansNouvelOnglet.Size = new System.Drawing.Size(274, 24);
            this.m_chkDansNouvelOnglet.TabIndex = 5;
            this.m_chkDansNouvelOnglet.Text = "Edit in new tab|10033";
            this.m_chkDansNouvelOnglet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Form code (leave empty for default system form)|10027";
            // 
            // m_splitContainer1
            // 
            this.m_splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer1.Name = "m_splitContainer1";
            // 
            // m_splitContainer1.Panel1
            // 
            this.m_splitContainer1.Panel1.Controls.Add(this.label1);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_chkDansNouvelOnglet);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_txtFormuleElement);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_txtFormuleCodeFormulaire);
            this.m_splitContainer1.Panel1.Controls.Add(this.label2);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_chkDansNavigateurPrincipal);
            // 
            // m_splitContainer1.Panel2
            // 
            this.m_splitContainer1.Panel2.Controls.Add(this.m_wndAideFormule);
            this.m_splitContainer1.Size = new System.Drawing.Size(603, 311);
            this.m_splitContainer1.SplitterDistance = 415;
            this.m_splitContainer1.TabIndex = 6;
            // 
            // CFormEditActionEditerElement
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(603, 365);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionEditerElement";
            this.Text = "Edit an element|1026";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.m_splitContainer1.Panel1.ResumeLayout(false);
            this.m_splitContainer1.Panel2.ResumeLayout(false);
            this.m_splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_wndAideFormule.FournisseurProprietes = ObjetEdite.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

            m_txtFormuleElement.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormuleCodeFormulaire.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			if ( ActionEditerElement.FormuleElementAEditer != null )
			{
				m_txtFormuleElement.Text = ActionEditerElement.FormuleElementAEditer.GetString();
			}
            if (ActionEditerElement.ExpressionCodeFormulaire != null)
            {
                m_txtFormuleCodeFormulaire.Text = ActionEditerElement.ExpressionCodeFormulaire.GetString();
            }
			m_chkDansNavigateurPrincipal.Checked = ActionEditerElement.DansNavigateurPrincipal;
            m_chkDansNouvelOnglet.Checked = ActionEditerElement.DansNouvelOnglet;
            m_chkDansNouvelOnglet.Enabled = m_chkDansNavigateurPrincipal.Checked;
		}
	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression ( ObjetEdite.Process, typeof(CProcess));
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
			result = analyseur.AnalyseChaine ( m_txtFormuleElement.Text );
			if ( !result )
				return result;
			ActionEditerElement.FormuleElementAEditer = (C2iExpression)result.Data;
            if (m_txtFormuleCodeFormulaire.Text.Trim() != "")
            {
                result = analyseur.AnalyseChaine(m_txtFormuleCodeFormulaire.Text);
                if (!result)
                    return result;
                ActionEditerElement.ExpressionCodeFormulaire = (C2iExpression)result.Data;
            }
            else
                ActionEditerElement.ExpressionCodeFormulaire = null;
			ActionEditerElement.DansNavigateurPrincipal = m_chkDansNavigateurPrincipal.Checked;
            ActionEditerElement.DansNouvelOnglet = m_chkDansNouvelOnglet.Checked;
			return result;
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
            if(m_txtFormule != null)
			    m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

        private void m_chkDansNavigateurPrincipal_CheckedChanged(object sender, EventArgs e)
        {
            m_chkDansNouvelOnglet.Enabled = m_chkDansNavigateurPrincipal.Checked;
        }

        //--------------------------------------------------------------------------------
        private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;
        private void OnEnterTexteFormule(object sender, System.EventArgs e)
        {
            if (m_txtFormule != null)
                m_txtFormule.BackColor = Color.White;
            if (sender is sc2i.win32.expression.CControleEditeFormule)
            {
                m_txtFormule = (sc2i.win32.expression.CControleEditeFormule)sender;
                m_txtFormule.BackColor = Color.LightGreen;
            }
        }


	}
}

