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
using timos.data;

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionCreerSqueletteProjet : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleWorkflow;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleProjetParent;
        private Label label2;
		private System.ComponentModel.IContainer components = null;
        private SplitContainer m_splitContainer;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleTypeEtapeDebut;
        private Label label3;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleEnCours = null;

		public CFormEditActionCreerSqueletteProjet()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_txtFormuleEnCours = m_txtFormuleWorkflow;
			m_txtFormuleWorkflow.BackColor = Color.LightGreen;

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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionCreerSqueletteProjet), typeof(CFormEditActionCreerSqueletteProjet));
		}


		public CActionCreerSqueletteProjet ActionCreerSqueletteProjet
		{
			get
			{
				return (CActionCreerSqueletteProjet)ObjetEdite;
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
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_txtFormuleProjetParent = new sc2i.win32.expression.CControleEditeFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtFormuleWorkflow = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.m_txtFormuleTypeEtapeDebut = new sc2i.win32.expression.CControleEditeFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_splitContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 407);
            this.panel2.TabIndex = 2;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_splitContainer.Location = new System.Drawing.Point(3, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_txtFormuleTypeEtapeDebut);
            this.m_splitContainer.Panel1.Controls.Add(this.label3);
            this.m_splitContainer.Panel1.Controls.Add(this.m_txtFormuleProjetParent);
            this.m_splitContainer.Panel1.Controls.Add(this.label2);
            this.m_splitContainer.Panel1.Controls.Add(this.m_txtFormuleWorkflow);
            this.m_splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_wndAideFormule);
            this.m_splitContainer.Size = new System.Drawing.Size(748, 370);
            this.m_splitContainer.SplitterDistance = 548;
            this.m_splitContainer.TabIndex = 12;
            // 
            // m_txtFormuleProjetParent
            // 
            this.m_txtFormuleProjetParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleProjetParent.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleProjetParent.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleProjetParent.Formule = null;
            this.m_txtFormuleProjetParent.Location = new System.Drawing.Point(7, 268);
            this.m_txtFormuleProjetParent.LockEdition = false;
            this.m_txtFormuleProjetParent.Name = "m_txtFormuleProjetParent";
            this.m_txtFormuleProjetParent.Size = new System.Drawing.Size(534, 95);
            this.m_txtFormuleProjetParent.TabIndex = 4;
            this.m_txtFormuleProjetParent.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(498, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parent projet|20576";
            // 
            // m_txtFormuleWorkflow
            // 
            this.m_txtFormuleWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleWorkflow.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleWorkflow.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleWorkflow.Formule = null;
            this.m_txtFormuleWorkflow.Location = new System.Drawing.Point(6, 25);
            this.m_txtFormuleWorkflow.LockEdition = false;
            this.m_txtFormuleWorkflow.Name = "m_txtFormuleWorkflow";
            this.m_txtFormuleWorkflow.Size = new System.Drawing.Size(534, 95);
            this.m_txtFormuleWorkflow.TabIndex = 2;
            this.m_txtFormuleWorkflow.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Workflow to use|20575";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(192, 366);
            this.m_wndAideFormule.TabIndex = 0;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // m_txtFormuleTypeEtapeDebut
            // 
            this.m_txtFormuleTypeEtapeDebut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTypeEtapeDebut.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleTypeEtapeDebut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleTypeEtapeDebut.Formule = null;
            this.m_txtFormuleTypeEtapeDebut.Location = new System.Drawing.Point(6, 141);
            this.m_txtFormuleTypeEtapeDebut.LockEdition = false;
            this.m_txtFormuleTypeEtapeDebut.Name = "m_txtFormuleTypeEtapeDebut";
            this.m_txtFormuleTypeEtapeDebut.Size = new System.Drawing.Size(534, 95);
            this.m_txtFormuleTypeEtapeDebut.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(420, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start step type (null for default)|20590";
            // 
            // CFormEditActionCreerSqueletteProjet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(754, 455);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionCreerSqueletteProjet";
            this.Text = "Create project squeleton|20574";
            this.Load += new System.EventHandler(this.CFormEditActionCreerSqueletteProjet_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression ( ObjetEdite.Process, typeof(CProcess));
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
			result = analyseur.AnalyseChaine ( m_txtFormuleWorkflow.Text );
			if ( !result )
				return result;
			ActionCreerSqueletteProjet.FormuleWorkflow = (C2iExpression)result.Data;
			result = analyseur.AnalyseChaine(m_txtFormuleProjetParent.Text);
			if (!result)
				return result;
			ActionCreerSqueletteProjet.FormuleProjetParent = (C2iExpression)result.Data;

            if (m_txtFormuleTypeEtapeDebut.Text.Trim() != "")
            {
                result = analyseur.AnalyseChaine(m_txtFormuleTypeEtapeDebut.Text);
                if (!result)
                    return result;
                ActionCreerSqueletteProjet.FormuleTypeEtapeDebut = (C2iExpression)result.Data;
            }
            else
                ActionCreerSqueletteProjet.FormuleTypeEtapeDebut = null;



			
			return result;
		}

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_wndAideFormule.FournisseurProprietes = ObjetEdite.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);
			m_txtFormuleWorkflow.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleProjetParent.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormuleTypeEtapeDebut.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			
			CFournisseurPropDynStd four = new CFournisseurPropDynStd();
			four.AvecReadOnly = true;

			if ( ActionCreerSqueletteProjet.FormuleWorkflow!= null )
			{
                m_txtFormuleWorkflow.Text = ActionCreerSqueletteProjet.FormuleWorkflow.GetString();
			}
            if (ActionCreerSqueletteProjet.FormuleTypeEtapeDebut != null)
            {
                m_txtFormuleTypeEtapeDebut.Text = ActionCreerSqueletteProjet.FormuleTypeEtapeDebut.GetString();
            }
			if (ActionCreerSqueletteProjet.FormuleProjetParent != null)
			{
                m_txtFormuleProjetParent.Text = ActionCreerSqueletteProjet.FormuleProjetParent.GetString();
			}
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			m_wndAideFormule.InsereInTextBox ( m_txtFormuleEnCours, nPosCurseur, strCommande );
		}

        private void CFormEditActionCreerSqueletteProjet_Load(object sender, EventArgs e)
        {
            // Traduit le formulaire
            sc2i.win32.common.CWin32Traducteur.Translate(this);

        }

		private void m_txtFormule_Enter(object sender, EventArgs e)
		{
			if (sender is sc2i.win32.expression.CControleEditeFormule)
			{
				if (m_txtFormuleEnCours != null)
					m_txtFormuleEnCours.BackColor = Color.White;
				m_txtFormuleEnCours = (sc2i.win32.expression.CControleEditeFormule)sender;
				m_txtFormuleEnCours.BackColor = Color.LightGreen;
			}

		}

		
		

		




	}
}

