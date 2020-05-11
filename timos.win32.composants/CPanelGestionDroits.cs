using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.common;

using timos.acteurs;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.common;
using timos.securite;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelGestionDroits.
	/// </summary>
	public class CPanelGestionDroits : System.Windows.Forms.UserControl, IControlALockEdition
	{
		private Hashtable m_tableCodeToNode = new Hashtable();

		protected class CDroitNode : TreeNode
		{
			public readonly CDroitUtilisateur Droit;
			private CRelationElement_Droit m_relation = null;

			public CDroitNode(CDroitUtilisateur droit)
				:base(droit.Libelle)
			{
				Droit = droit;
				m_relation = null;
			}

			public CRelationElement_Droit Relation
			{
				get
				{
					return m_relation;
				}
				set
				{
					m_relation = value;
				}
			}
		}

		
		private bool m_bIsInitialising = false;
		private CDroitNode	m_lastNodeAffiche = null;
		private bool m_bLockEdition = true;
		private IElementDefinissantDesDroits m_elementADroits = null;
		private System.Windows.Forms.Label m_labelInfo;
		private sc2i.win32.common.ListViewAutoFilled m_listeExtensions;
		private sc2i.win32.common.ListViewAutoFilledColumn m_colonne;
		private System.Windows.Forms.TreeView m_arbre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox m_wndListeOptions;

		public CPanelGestionDroits()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitForm

		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_labelInfo = new System.Windows.Forms.Label();
            this.m_listeExtensions = new sc2i.win32.common.ListViewAutoFilled();
            this.m_colonne = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.m_wndListeOptions = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // m_labelInfo
            // 
            this.m_labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelInfo.Location = new System.Drawing.Point(312, 16);
            this.m_labelInfo.Name = "m_labelInfo";
            this.m_labelInfo.Size = new System.Drawing.Size(352, 40);
            this.m_labelInfo.TabIndex = 7;
            this.m_labelInfo.Text = "(information)|30113";
            this.m_labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_listeExtensions
            // 
            this.m_listeExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeExtensions.CheckBoxes = true;
            this.m_listeExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonne});
            this.m_listeExtensions.EnableCustomisation = false;
            this.m_listeExtensions.FullRowSelect = true;
            this.m_listeExtensions.Location = new System.Drawing.Point(304, 144);
            this.m_listeExtensions.Name = "m_listeExtensions";
            this.m_listeExtensions.Size = new System.Drawing.Size(360, 168);
            this.m_listeExtensions.TabIndex = 6;
            this.m_listeExtensions.UseCompatibleStateImageBehavior = false;
            this.m_listeExtensions.View = System.Windows.Forms.View.Details;
            // 
            // m_colonne
            // 
            this.m_colonne.Field = "DescriptionElement";
            this.m_colonne.PrecisionWidth = 1108;
            this.m_colonne.ProportionnalSize = false;
            this.m_colonne.Text = "Element|30114";
            this.m_colonne.Visible = true;
            this.m_colonne.Width = 1108;
            // 
            // m_arbre
            // 
            this.m_arbre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_arbre.CheckBoxes = true;
            this.m_arbre.Location = new System.Drawing.Point(0, 16);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(296, 296);
            this.m_arbre.TabIndex = 5;
            this.m_arbre.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterCheck);
            this.m_arbre.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeCheck);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rights|30112";
            // 
            // m_wndListeOptions
            // 
            this.m_wndListeOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_wndListeOptions.Location = new System.Drawing.Point(304, 56);
            this.m_wndListeOptions.Name = "m_wndListeOptions";
            this.m_wndListeOptions.Size = new System.Drawing.Size(184, 75);
            this.m_wndListeOptions.TabIndex = 8;
            // 
            // CPanelGestionDroits
            // 
            this.Controls.Add(this.m_wndListeOptions);
            this.Controls.Add(this.m_labelInfo);
            this.Controls.Add(this.m_listeExtensions);
            this.Controls.Add(this.m_arbre);
            this.Controls.Add(this.label1);
            this.Name = "CPanelGestionDroits";
            this.Size = new System.Drawing.Size(672, 320);
            this.Load += new System.EventHandler(this.CPanelGestionDroits_Load);
            this.ResumeLayout(false);

		}
		#endregion
		/// //////////////////////////////////////////////////////
		public IElementDefinissantDesDroits ElementDefinissantLesDroits
		{
			get
			{
				return m_elementADroits;
			}
			set
			{
				m_elementADroits = value;
				AfficheDroitsElementDefinisseur();
			}
		}

		/// //////////////////////////////////////////////////////
		public event EventHandler OnChangeLockEdition; 
		public bool LockEdition
		{
			get
			{
				return m_bLockEdition;
			}
			set
			{
				m_bLockEdition = value;
				//m_arbre.Enabled = !m_bLockEdition;
				m_listeExtensions.Enabled = !m_bLockEdition;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		/// //////////////////////////////////////////////////////
		private void CPanelGestionDroits_Load(object sender, System.EventArgs e)
		{
			InitPanel();
		}

		/// //////////////////////////////////////////////////////
		private void InitPanel()
		{
			FillNode ( m_arbre.Nodes, null );
			AfficheDroitsElementDefinisseur();
		}

		/// //////////////////////////////////////////////////////
		private void FillNode ( TreeNodeCollection nodes, CDroitUtilisateur droitParent )
		{
			if ( DesignMode )
				return;
			CListeObjetsDonnees lst = new CListeObjetsDonnees ( sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant, typeof(CDroitUtilisateur));
			CFiltreData filtre = new CFiltreData();
			if ( droitParent == null )
				filtre.Filtre = CDroitUtilisateur.c_champCodeDroitParent+" is null";
			else
			{
				filtre.Filtre = CDroitUtilisateur.c_champCodeDroitParent+"=@1";
				filtre.Parametres.Add ( droitParent.Code );
			}
			lst.Filtre = filtre;
			lst.Tri = CDroitUtilisateur.c_champNumOrdre;
			foreach ( CDroitUtilisateur droit in lst )
			{
				CDroitNode node = new CDroitNode(droit);
               
				nodes.Add ( node );
				m_tableCodeToNode[droit.Code] = node;
				FillNode ( node.Nodes, droit );
			}
		}

		/// //////////////////////////////////////////////////////
		private void m_arbre_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			ValideModifsDroitEnCours();
			CDroitNode node = (CDroitNode)e.Node;
			CDroitUtilisateur droit = node.Droit;
			m_listeExtensions.Visible = droit.TypeAssocieURI != null && droit.TypeAssocieURI != "";
			m_labelInfo.Text = droit.Infos;
			OptionsDroit[] options = droit.ListeOptionsPossibles;
			m_wndListeOptions.Items.Clear();
			if ( options.Length == 0 )
			{
				m_wndListeOptions.Visible = false;
			}
			else
			{
				foreach ( OptionsDroit option in options )
				{
					int nItem = m_wndListeOptions.Items.Add ( new COptionDroitUtilisateur(option));
					if ( node.Relation != null )
						m_wndListeOptions.SetItemChecked(nItem, node.Relation.HasOption(option));
				}
				m_wndListeOptions.Visible = true;
			}
			if ( droit.TypeAssocieURI != null )
			{
				CListeObjetsDonnees lst = droit.ListeObjetsAssocies;
				m_listeExtensions.Remplir(lst);
				if ( node.Relation != null )
				{
					//Coche ce qui doit l'être
					Hashtable tableCheck = new Hashtable();
					foreach( CObjetDonnee obj in node.Relation.ListeObjetsOption )
						tableCheck[obj] = true;
					foreach ( ListViewItem item in m_listeExtensions.Items )
					{
						if ( tableCheck[item.Tag] != null )
							item.Checked = true;
					}
				}
			}
			if ( e.Node.Checked && !m_bLockEdition )
			{
				m_listeExtensions.Enabled = true;
				m_wndListeOptions.Enabled = true;
			}
			else
			{
				m_listeExtensions.Enabled = false;
				m_wndListeOptions.Enabled = false;
			}
			m_lastNodeAffiche = (CDroitNode)e.Node;
		}	

		/// //////////////////////////////////////////////////////
		private void ResetNodes( TreeNodeCollection nodes )
		{
			if ( nodes == null )
				nodes = m_arbre.Nodes;
			foreach ( CDroitNode node in nodes )
			{
				node.Relation = null;
				node.Checked = false;
				ResetNodes ( node.Nodes );
			}
		}
	
		/// //////////////////////////////////////////////////////
		private void AfficheDroitsElementDefinisseur()
		{
			m_bIsInitialising = true;
			ResetNodes(null);
			if ( m_elementADroits == null )
			{
				m_bIsInitialising = false;
				return;
			}
			foreach ( CRelationElement_Droit rel in m_elementADroits.RelationsDroits )
			{
				CDroitNode node = GetNodeFor(m_arbre.Nodes, rel.CodeDroit);
				if ( node != null )
				{
					node.Relation = rel;
					node.Checked = true;
				}
			}
			m_bIsInitialising = false;
		}


		/// //////////////////////////////////////////////////////
		public CResultAErreur ValideModifs ( )
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_arbre.Nodes.Count == 0 )
				return result;
			ValideModifsDroitEnCours();
			if ( m_elementADroits == null )
				return result;
			//Liste des relations à supprimer
			ArrayList listeToDelete = new ArrayList();
			foreach ( CRelationElement_Droit rel in m_elementADroits.RelationsDroits )
			{
				TreeNode node = GetNodeFor(m_arbre.Nodes,rel.CodeDroit);
				if ( node == null || !node.Checked )
					listeToDelete.Add ( rel );
			}
			foreach ( CRelationElement_Droit rel in listeToDelete )
			{
				CDroitNode node = GetNodeFor(m_arbre.Nodes,rel.CodeDroit);
				if ( node != null )
					node.Relation = null;
				result = rel.Delete();
				if ( !result )
					return result;
			}
			
				
			return result;
		}

		private void m_arbre_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if ( !e.Node.Checked || m_elementADroits == null || m_bIsInitialising)
				return;

            // Utilistauer connecté
            CDonneesActeurUtilisateur userConnecte = null;
            CObjetDonnee objet = m_elementADroits as CObjetDonnee;
            if (objet != null)
            {
                userConnecte = CDonneesActeurUtilisateur.GetUserForSession(objet.ContexteDonnee.IdSession, objet.ContexteDonnee);
            }

            CDroitNode node = (CDroitNode)e.Node;
            if (userConnecte != null)
            {
                // Verifie que l'utilisateur tente d'affecter un droit qu'il n'a pas !
                if (userConnecte.GetDonneeDroit(node.Droit.Code) == null)
                {
                    node.Checked = false;
                    CFormAlerte.Afficher(I.T("You don't have right to affect this system Right : @1|10010", node.Droit.Libelle));
                    return;
                }
            }


			if ( node.Relation == null )
			{
				CRelationElement_Droit relation = m_elementADroits.GetNewObjetRelationDroit();
				relation.Droit = (CDroitUtilisateur)node.Droit;
				relation.ElementDefinisseur = m_elementADroits;
				node.Relation = relation;
			}
			m_arbre.SelectedNode = node;
			if ( node.Checked && !m_bLockEdition )
			{
				m_listeExtensions.Enabled = true;
				m_wndListeOptions.Enabled = true;
			}
			else
			{
				m_listeExtensions.Enabled = false;
				m_wndListeOptions.Enabled = false;
			}
		}

		/// //////////////////////////////////////////////////////
		private void m_arbre_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if ( m_bLockEdition && !m_bIsInitialising)
				e.Cancel = true;
		}

		/// //////////////////////////////////////////////////////
		private void ValideModifsDroitEnCours()
		{
			if ( m_lastNodeAffiche == null || !(m_lastNodeAffiche.Relation!=null )  || m_bLockEdition)
				return;
			CObjetDonneeAIdNumerique[] select = new CObjetDonneeAIdNumerique[m_listeExtensions.CheckedItems.Count];
			for ( int n = 0; n < select.Length; n++ )
				select[n] = ((CObjetDonneeAIdNumerique)m_listeExtensions.CheckedItems[n].Tag);
			m_lastNodeAffiche.Relation.ListeObjetsOption = select;

			for ( int nOption = 0; nOption < m_wndListeOptions.Items.Count; nOption++ )
			{
				COptionDroitUtilisateur option = (COptionDroitUtilisateur)m_wndListeOptions.Items[nOption];
				if ( m_wndListeOptions.CheckedItems.Contains(option) )
					m_lastNodeAffiche.Relation.AddOption( option.Option );
				else
					m_lastNodeAffiche.Relation.RemoveOption( option.Option );
			}
		}

		/// //////////////////////////////////////////////////////
		protected CDroitNode GetNodeFor ( TreeNodeCollection nodes, string strCodeDroit )
		{
			return (CDroitNode)m_tableCodeToNode[strCodeDroit];
		}

	}
}
