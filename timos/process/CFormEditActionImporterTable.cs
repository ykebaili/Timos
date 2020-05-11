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
	public class CFormEditActionImporterTable : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleFichier;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleTable;
		private Label label2;
		private Label label3;
		private RadioButton m_rbtDelete;
		private RadioButton m_rbtReset;
		private RadioButton m_rbtUpdate;
		private System.ComponentModel.IContainer components = null;
        private SplitContainer m_splitContainer;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleEnCours = null;

		public CFormEditActionImporterTable()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_txtFormuleEnCours = m_txtFormuleFichier;
			m_txtFormuleFichier.BackColor = Color.LightGreen;

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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionImporterTable), typeof(CFormEditActionImporterTable));
		}


		public CActionImporterTable ActionImporterTable
		{
			get
			{
				return (CActionImporterTable)ObjetEdite;
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
            this.label3 = new System.Windows.Forms.Label();
            this.m_rbtDelete = new System.Windows.Forms.RadioButton();
            this.m_rbtReset = new System.Windows.Forms.RadioButton();
            this.m_rbtUpdate = new System.Windows.Forms.RadioButton();
            this.m_txtFormuleTable = new sc2i.win32.expression.CControleEditeFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtFormuleFichier = new sc2i.win32.expression.CControleEditeFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_splitContainer);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_rbtDelete);
            this.panel2.Controls.Add(this.m_rbtReset);
            this.panel2.Controls.Add(this.m_rbtUpdate);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 409);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(533, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Import mode|1288";
            // 
            // m_rbtDelete
            // 
            this.m_rbtDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rbtDelete.AutoSize = true;
            this.m_rbtDelete.Location = new System.Drawing.Point(383, 386);
            this.m_rbtDelete.Name = "m_rbtDelete";
            this.m_rbtDelete.Size = new System.Drawing.Size(70, 17);
            this.m_rbtDelete.TabIndex = 10;
            this.m_rbtDelete.Text = "Remove|18";
            this.m_rbtDelete.UseVisualStyleBackColor = true;
            // 
            // m_rbtReset
            // 
            this.m_rbtReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rbtReset.AutoSize = true;
            this.m_rbtReset.Location = new System.Drawing.Point(195, 386);
            this.m_rbtReset.Name = "m_rbtReset";
            this.m_rbtReset.Size = new System.Drawing.Size(132, 17);
            this.m_rbtReset.TabIndex = 9;
            this.m_rbtReset.Text = "Reset and Import|1290";
            this.m_rbtReset.UseVisualStyleBackColor = true;
            // 
            // m_rbtUpdate
            // 
            this.m_rbtUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_rbtUpdate.AutoSize = true;
            this.m_rbtUpdate.Checked = true;
            this.m_rbtUpdate.Location = new System.Drawing.Point(8, 386);
            this.m_rbtUpdate.Name = "m_rbtUpdate";
            this.m_rbtUpdate.Size = new System.Drawing.Size(132, 17);
            this.m_rbtUpdate.TabIndex = 8;
            this.m_rbtUpdate.TabStop = true;
            this.m_rbtUpdate.Text = "Update or Create|1289";
            this.m_rbtUpdate.UseVisualStyleBackColor = true;
            // 
            // m_txtFormuleTable
            // 
            this.m_txtFormuleTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTable.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleTable.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleTable.Formule = null;
            this.m_txtFormuleTable.Location = new System.Drawing.Point(7, 228);
            this.m_txtFormuleTable.LockEdition = false;
            this.m_txtFormuleTable.Name = "m_txtFormuleTable";
            this.m_txtFormuleTable.Size = new System.Drawing.Size(476, 137);
            this.m_txtFormuleTable.TabIndex = 4;
            this.m_txtFormuleTable.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Custom table|20011";
            // 
            // m_txtFormuleFichier
            // 
            this.m_txtFormuleFichier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleFichier.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleFichier.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleFichier.Formule = null;
            this.m_txtFormuleFichier.Location = new System.Drawing.Point(6, 25);
            this.m_txtFormuleFichier.LockEdition = false;
            this.m_txtFormuleFichier.Name = "m_txtFormuleFichier";
            this.m_txtFormuleFichier.Size = new System.Drawing.Size(477, 171);
            this.m_txtFormuleFichier.TabIndex = 2;
            this.m_txtFormuleFichier.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "File name (from server)|20010";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(170, 368);
            this.m_wndAideFormule.TabIndex = 0;
			this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
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
            this.m_splitContainer.Panel1.Controls.Add(this.m_txtFormuleTable);
            this.m_splitContainer.Panel1.Controls.Add(this.label2);
            this.m_splitContainer.Panel1.Controls.Add(this.m_txtFormuleFichier);
            this.m_splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_wndAideFormule);
            this.m_splitContainer.Size = new System.Drawing.Size(668, 372);
            this.m_splitContainer.SplitterDistance = 490;
            this.m_splitContainer.TabIndex = 12;
            // 
            // CFormEditActionImporterTable
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(674, 455);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionImporterTable";
            this.Text = "Custom Table Import|20009";
            this.Load += new System.EventHandler(this.CFormEditActionImporterTable_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
			result = analyseur.AnalyseChaine ( m_txtFormuleFichier.Text );
			if ( !result )
				return result;
			ActionImporterTable.FormuleFichierSource = (C2iExpression)result.Data;
			result = analyseur.AnalyseChaine(m_txtFormuleTable.Text);
			if (!result)
				return result;
			ActionImporterTable.FormuleTableAImporter = (C2iExpression)result.Data;

			if (m_rbtDelete.Checked)
				ActionImporterTable.ModeImport = EImportTableParametrableMode.Delete;
			if (m_rbtReset.Checked)
				ActionImporterTable.ModeImport = EImportTableParametrableMode.RAZ_Puis_Import;
			if (m_rbtUpdate.Checked)
				ActionImporterTable.ModeImport = EImportTableParametrableMode.Update_Or_Create;
			
			return result;
		}

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_wndAideFormule.FournisseurProprietes = ObjetEdite.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);
			m_txtFormuleFichier.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleTable.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			
			CFournisseurPropDynStd four = new CFournisseurPropDynStd();
			four.AvecReadOnly = true;

			if ( ActionImporterTable.FormuleFichierSource != null )
			{
				m_txtFormuleFichier.Text = ActionImporterTable.FormuleFichierSource.GetString();
			}
			if (ActionImporterTable.FormuleTableAImporter != null)
			{
				m_txtFormuleTable.Text = ActionImporterTable.FormuleTableAImporter.GetString();
			}
			switch (ActionImporterTable.ModeImport)
			{
				case EImportTableParametrableMode.Update_Or_Create:
					m_rbtUpdate.Checked = true;
					break;
				case EImportTableParametrableMode.RAZ_Puis_Import:
					m_rbtReset.Checked = true;
					break;
				case EImportTableParametrableMode.Delete:
					m_rbtDelete.Checked = true;
					break;
			}
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			m_wndAideFormule.InsereInTextBox ( m_txtFormuleEnCours, nPosCurseur, strCommande );
		}

        private void CFormEditActionImporterTable_Load(object sender, EventArgs e)
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

