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
using sc2i.workflow;
using sc2i.win32.data;

namespace timos.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionImprimerModeleTexte : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView m_wndListeVariables;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleElement;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleCodeFormulaire;
        private Label label2;
        private SplitContainer m_splitContainer1;
        private Label label3;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbModele;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionImprimerModeleTexte()
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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionImprimerModeleTexte), typeof(CFormEditActionImprimerModeleTexte));
		}


		public CActionImprimerModeleTexte ActionImprimerModeleTexte
		{
			get
			{
				return (CActionImprimerModeleTexte)ObjetEdite;
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
            this.m_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormuleElement = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtFormuleCodeFormulaire = new sc2i.win32.expression.CControleEditeFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.m_wndListeVariables = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbModele = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
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
            this.panel2.Size = new System.Drawing.Size(683, 310);
            this.panel2.TabIndex = 2;
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
            this.m_splitContainer1.Panel1.Controls.Add(this.m_cmbModele);
            this.m_splitContainer1.Panel1.Controls.Add(this.label3);
            this.m_splitContainer1.Panel1.Controls.Add(this.label1);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_txtFormuleElement);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_txtFormuleCodeFormulaire);
            this.m_splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // m_splitContainer1.Panel2
            // 
            this.m_splitContainer1.Panel2.Controls.Add(this.m_wndAideFormule);
            this.m_splitContainer1.Size = new System.Drawing.Size(683, 310);
            this.m_splitContainer1.SplitterDistance = 470;
            this.m_splitContainer1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Element to print|20118";
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
            this.m_txtFormuleElement.Size = new System.Drawing.Size(460, 104);
            this.m_txtFormuleElement.TabIndex = 2;
            this.m_txtFormuleElement.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_txtFormuleCodeFormulaire
            // 
            this.m_txtFormuleCodeFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCodeFormulaire.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleCodeFormulaire.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleCodeFormulaire.Formule = null;
            this.m_txtFormuleCodeFormulaire.Location = new System.Drawing.Point(3, 153);
            this.m_txtFormuleCodeFormulaire.LockEdition = false;
            this.m_txtFormuleCodeFormulaire.Name = "m_txtFormuleCodeFormulaire";
            this.m_txtFormuleCodeFormulaire.Size = new System.Drawing.Size(460, 94);
            this.m_txtFormuleCodeFormulaire.TabIndex = 4;
            this.m_txtFormuleCodeFormulaire.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Print setup|20117";
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
            this.m_wndAideFormule.Size = new System.Drawing.Size(205, 306);
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Text model|20119";
            // 
            // m_cmbModele
            // 
            this.m_cmbModele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmbModele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModele.ElementSelectionne = null;
            this.m_cmbModele.FormattingEnabled = true;
            this.m_cmbModele.IsLink = false;
            this.m_cmbModele.ListDonnees = null;
            this.m_cmbModele.Location = new System.Drawing.Point(10, 265);
            this.m_cmbModele.LockEdition = false;
            this.m_cmbModele.Name = "m_cmbModele";
            this.m_cmbModele.NullAutorise = false;
            this.m_cmbModele.ProprieteAffichee = "Libelle";
            this.m_cmbModele.ProprieteParentListeObjets = null;
            this.m_cmbModele.SelectionneurParent = null;
            this.m_cmbModele.Size = new System.Drawing.Size(302, 21);
            this.m_cmbModele.TabIndex = 6;
            this.m_cmbModele.TextNull = "(empty)";
            this.m_cmbModele.Tri = true;
            // 
            // CFormEditActionImprimerModeleTexte
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(683, 364);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionImprimerModeleTexte";
            this.Text = "Print text|20120";
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

			if ( ActionImprimerModeleTexte.FormuleElementAEditer != null )
			{
				m_txtFormuleElement.Text = ActionImprimerModeleTexte.FormuleElementAEditer.GetString();
			}
            if (ActionImprimerModeleTexte.FormuleElementAEditer != null)
            {
                m_txtFormuleCodeFormulaire.Text = ActionImprimerModeleTexte.FormuleParametresImpression.GetString();
            }

            m_cmbModele.Init(typeof(CModeleTexte), "Libelle", true);
            CModeleTexte modele = new CModeleTexte(CSc2iWin32DataClient.ContexteCourant);
            if ( ActionImprimerModeleTexte.IdModeleAEditer != null &&
                modele.ReadIfExists ( ActionImprimerModeleTexte.IdModeleAEditer.Value ))
                m_cmbModele.ElementSelectionne = modele;
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
			ActionImprimerModeleTexte.FormuleElementAEditer = (C2iExpression)result.Data;
            if (m_txtFormuleCodeFormulaire.Text.Trim() != "")
            {
                result = analyseur.AnalyseChaine(m_txtFormuleCodeFormulaire.Text);
                if (!result)
                    return result;
                ActionImprimerModeleTexte.FormuleParametresImpression = (C2iExpression)result.Data;
            }
            else
                ActionImprimerModeleTexte.FormuleParametresImpression = null;
            CModeleTexte modele = m_cmbModele.ElementSelectionne as CModeleTexte;
            if (modele != null)
                ActionImprimerModeleTexte.IdModeleAEditer = modele.Id;
            else
                ActionImprimerModeleTexte.IdModeleAEditer = null;
			return result;
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
            if(m_txtFormule != null)
			    m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
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

