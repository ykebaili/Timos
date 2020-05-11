using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;

using sc2i.workflow;
using timos.process;
using sc2i.process;
using sc2i.common;
using sc2i.win32.common;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CProcessInDb))]
	public class CFormListeProcess : CFormListeStandardTimos, IFormNavigable
	{
		private System.Windows.Forms.LinkLabel m_btnExecuter;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeProcess()
			:base(typeof(CProcessInDb))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		public CFormListeProcess( CListeObjetsDonnees listeProcess )
			:base( listeProcess )
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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			this.m_btnExecuter = new System.Windows.Forms.LinkLabel();
			this.m_panelHaut.SuspendLayout();
			// 
			// m_panelListe
			// 
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 424;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
			this.m_panelListe.Name = "m_panelListe";
			this.m_panelListe.Size = new System.Drawing.Size(576, 360);
			// 
			// m_panelGauche
			// 
			this.m_panelGauche.Location = new System.Drawing.Point(0, 16);
			this.m_panelGauche.Name = "m_panelGauche";
			this.m_panelGauche.Size = new System.Drawing.Size(0, 360);
			// 
			// m_panelDroit
			// 
			this.m_panelDroit.Location = new System.Drawing.Point(576, 16);
			this.m_panelDroit.Name = "m_panelDroit";
			this.m_panelDroit.Size = new System.Drawing.Size(0, 360);
			// 
			// m_panelBas
			// 
			this.m_panelBas.Location = new System.Drawing.Point(0, 376);
			this.m_panelBas.Name = "m_panelBas";
			this.m_panelBas.Size = new System.Drawing.Size(576, 0);
			// 
			// m_panelHaut
			// 
			this.m_panelHaut.Controls.Add(this.m_btnExecuter);
			this.m_panelHaut.Name = "m_panelHaut";
			this.m_panelHaut.Size = new System.Drawing.Size(576, 16);
			// 
			// m_panelMilieu
			// 
			this.m_panelMilieu.Location = new System.Drawing.Point(0, 16);
			this.m_panelMilieu.Name = "m_panelMilieu";
			this.m_panelMilieu.Size = new System.Drawing.Size(576, 360);
			// 
			// m_btnExecuter
			// 
			this.m_btnExecuter.Location = new System.Drawing.Point(16, 0);
			this.m_btnExecuter.Name = "m_btnExecuter";
			this.m_btnExecuter.Size = new System.Drawing.Size(168, 16);
			this.m_btnExecuter.TabIndex = 2;
			this.m_btnExecuter.TabStop = true;
			this.m_btnExecuter.Text = "Execute selected Action|30332";
			this.m_btnExecuter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_btnExecuter_LinkClicked);
			// 
			// CFormListeProcess
			// 
			this.AffichePanelHaut = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 376);
			this.Name = "CFormListeProcess";
			this.m_panelHaut.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CProcessInDb),	
				typeof(CFormEditionProcess),
				null,"");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Actions list|989");
		}

		//-------------------------------------------------------------------
		private void m_btnExecuter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_panelListe.ElementSelectionne != null )
			{
				CProcessInDb process = (CProcessInDb)m_panelListe.ElementSelectionne;
				if ( CFormAlerte.Afficher(I.T( "Execute Action '@1' ?|990", process.Libelle),
					EFormAlerteType.Question) == DialogResult.Yes )
				{
					CResultAErreur result = CFormExecuteProcess.StartProcess ( 
						process.Process,
						null,
						process.ContexteDonnee.IdSession,
						process.ContexteDonnee.IdVersionDeTravail,
						false
						);
					if ( !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
					}
					else
						CFormAlerte.Afficher(I.T( "Execution complete|991"));
				}
			}
		}
		//-------------------------------------------------------------------
	}
}

