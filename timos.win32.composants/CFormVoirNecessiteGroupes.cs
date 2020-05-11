using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.common;
using sc2i.workflow;
using sc2i.data;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CFormVoirNecessiteGroupes.
	/// </summary>
	public class CFormVoirNecessiteGroupes : System.Windows.Forms.Form
	{
		private Type m_typeGroupes = null;
		private System.Windows.Forms.TreeView m_arbre;
		private System.Windows.Forms.LinkLabel m_btnFermer;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormVoirNecessiteGroupes()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_btnFermer = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbre.Location = new System.Drawing.Point(8, 8);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(312, 328);
            this.m_arbre.TabIndex = 0;
            // 
            // m_btnFermer
            // 
            this.m_btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFermer.Location = new System.Drawing.Point(256, 336);
            this.m_btnFermer.Name = "m_btnFermer";
            this.m_btnFermer.Size = new System.Drawing.Size(64, 16);
            this.m_btnFermer.TabIndex = 1;
            this.m_btnFermer.TabStop = true;
            this.m_btnFermer.Text = "Close|30091";
            this.m_btnFermer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.m_btnFermer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_btnFermer_LinkClicked);
            // 
            // CFormVoirNecessiteGroupes
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnFermer;
            this.ClientSize = new System.Drawing.Size(328, 358);
            this.Controls.Add(this.m_btnFermer);
            this.Controls.Add(this.m_arbre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormVoirNecessiteGroupes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group hierarchies|30090";
            this.Load += new System.EventHandler(this.CFormVoirNecessiteGroupes_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// ///////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CFormVoirNecessiteGroupes_Load(object sender, System.EventArgs e)
		{
			FillNode ( null );
		}

		/// ///////////////////////////////////////////////////////////
		public static void VoirNecessitesGroupes ( Type typeGroupes )
		{
			CFormVoirNecessiteGroupes form = new CFormVoirNecessiteGroupes();
			form.m_typeGroupes = typeGroupes;
			form.ShowDialog();
			form.Dispose();
		}

		/// ///////////////////////////////////////////////////////////
		private void FillNode ( TreeNode nodeParent )
		{
			CGroupeStructurant groupe = null;
			IList liste = null;
			if ( nodeParent != null )
			{
				groupe = (CGroupeStructurant)nodeParent.Tag;
				liste = new ArrayList();
				foreach ( IRelationGroupeGroupeNecessaire relation in groupe.RelationsGroupesNecessitants )
					liste.Add ( relation.GroupeNecessitant );
			}
			else
			{
				liste = new CListeObjetsDonnees ( sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant, m_typeGroupes );
				string strNomTable = CContexteDonnee.GetNomTableForType ( m_typeGroupes );
				((CListeObjetsDonnees)liste).Filtre = new CFiltreDataAvance ( strNomTable, "HasNo(RelationsGroupesNecessitants.Id)");
			}
			foreach ( CGroupeStructurant grp in liste )
			{
				TreeNode node = new TreeNode ( grp.Libelle );
				node.Tag = grp;
				if ( nodeParent == null )
					m_arbre.Nodes.Add ( node );
				else
					nodeParent.Nodes.Add ( node );
				FillNode ( node );
			}
		}

		private void m_btnFermer_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}
	}
}
