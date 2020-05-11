using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.common;

using sc2i.workflow;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de C2iNecessiteGroupeTreeView.
	/// </summary>
	[DefaultEvent("AfterModifications")]
	public class C2iNecessiteGroupeTreeView : TreeView, IControlALockEdition
	{
		private CListeObjetsDonnees m_listeTousLesGroupes = null;
		private CObjetDeGroupe m_objet;
		private Type m_typeGroupe;
		private Type m_typeRelationNecessite;
		private string m_strNomTable = "";
		private string m_strChampIdGroupe = "";
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer m_timer;
		private bool m_bLockEdition = false;

		public event EventHandler AfterModifications;
		//-------------------------------------------------------------------------
		public C2iNecessiteGroupeTreeView()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------
		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_timer = new System.Windows.Forms.Timer(this.components);
			// 
			// m_timer
			// 
			this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
			// 
			// C2iNecessiteGroupeTreeView
			// 
			this.CheckBoxes = true;
			this.Size = new System.Drawing.Size(272, 272);
			this.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.C2iNecessiteGroupeTreeView_AfterCheck);
			this.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.C2iNecessiteGroupeTreeView_BeforeCheck);

		}
		#endregion
		//-------------------------------------------------------------------------
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
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition(this, new EventArgs());
			}
		}
		//-------------------------------------------------------------------------
		public CResultAErreur Init(CObjetDeGroupe objet)
		{
			m_objet = objet;
			m_typeGroupe = m_objet.TypeGroupe;
			using(CGroupeStructurant tempGroupe =( (CGroupeStructurant)Activator.CreateInstance( m_typeGroupe, new object[] {m_objet.ContexteDonnee}) ) )
			{
				m_typeRelationNecessite = tempGroupe.TypeRelationNecessaire;
				m_strNomTable = tempGroupe.GetNomTable();
				m_strChampIdGroupe = tempGroupe.GetChampId();
			}

			CResultAErreur result = CResultAErreur.True;

			if ( !m_typeGroupe.IsSubclassOf( typeof(CGroupeStructurant) ) )
				throw new Exception("The group type must inherit from CGroupeStructurant.|30077");
			
			Nodes.Clear();
			//Lit tous les groupes et toutes les dépendances du groupe
			m_listeTousLesGroupes = new CListeObjetsDonnees ( objet.ContexteDonnee, m_typeGroupe );
			m_listeTousLesGroupes.ReadDependances ( "RelationsGroupesNecessitants","RelationsGroupesNecessaires" );
			FillNodes(null, null);

			return result;
		}
		//-------------------------------------------------------------------------
		protected void FillNodes ( TreeNode nodeParent, CGroupeStructurant objetParent )
		{
			TreeNodeCollection nodes = null;
			if ( nodeParent == null )
				nodes = Nodes;
			else
				nodes = nodeParent.Nodes;
			nodes.Clear();

			/*CListeObjetsDonnees listeGroupesNecessitants = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, m_typeGroupe, false);
			CFiltreData filtre;*/
			ArrayList listeGroupes = new ArrayList();
			
			if ( objetParent == null )
			{
				foreach ( CGroupeStructurant groupe in m_listeTousLesGroupes )
					if ( groupe.RelationsGroupesNecessaires.Count == 0 )
						listeGroupes.Add ( groupe );
				//filtre = new CFiltreDataAvance ( m_strNomTable, "HasNo(RelationsGroupesNecessitants.Id)" );
			}
			else
			{
				CListeObjetsDonnees listeRelations = objetParent.RelationsGroupesNecessitants;//new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, m_typeRelationNecessite, false);
				
				//string strIds = "";
				foreach( IRelationGroupeGroupeNecessaire rel in listeRelations)
				{
					listeGroupes.Add ( rel.GroupeNecessitant );
					//strIds += rel.GroupeNecessitant.Id+",";
				}

				/*if (strIds=="")
					filtre = new CFiltreDataImpossible();
				else
					//filtre = new CFiltreDataAvance(m_strNomTable, strIds, null); //"RelationsGroupesNecessaires.GroupeNecessaire.Id = @1", new object[] {objetParent.Id});
				{
					strIds = "("+strIds.Substring(0, strIds.Length-1)+")";
					filtre = new CFiltreData ( m_strChampIdGroupe+" in "+strIds );
				}*/
			}
			//listeGroupesNecessitants.Filtre = filtre;
			
			foreach ( CGroupeStructurant groupe in listeGroupes)//listeGroupesNecessitants )
			{
				TreeNode node = new TreeNode();
				node.Text = groupe.Libelle;
				node.Tag = groupe;
				if ( groupe.RelationsGroupesNecessitants.Count > 0 )
					FillNodes(node, groupe);
				nodes.Add ( node );
			}
		}
		//-------------------------------------------------------------------------
		private void C2iNecessiteGroupeTreeView_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			e.Cancel = m_bLockEdition;
		}
		//-------------------------------------------------------------------------
		public Hashtable TableGroupesIdChecked
		{
			get
			{
				Hashtable tempTable = new Hashtable();
				AddNodesToTable(Nodes, ref tempTable, false);
				return tempTable;
			}
		}
		//-------------------------------------------------------------------------
		public Hashtable TableGroupesIdCheckedWithParents
		{
			get
			{
				Hashtable tempTable = new Hashtable();
				AddNodesToTable(Nodes, ref tempTable, true);
				return tempTable;
			}
		}
		//-------------------------------------------------------------------------
		private void AddNodesToTable(TreeNodeCollection nodes, ref Hashtable table, bool bWithParents)
		{
			foreach(TreeNode node in nodes)
			{
				if ((node.Checked) && (node.Tag is CGroupeStructurant))
				{
					CGroupeStructurant groupe = (CGroupeStructurant) node.Tag;
					table[groupe.Id] = true;
					if (bWithParents)
						AddGroupesParentsToTable(groupe, ref table);
					AddNodesToTable(node.Nodes, ref table, bWithParents);
				}
			}
		}
		//-------------------------------------------------------------------------
		private void AddGroupesParentsToTable(CGroupeStructurant groupe, ref Hashtable table)
		{
			foreach(IRelationGroupeStructurantGroupeParent rel in groupe.RelationsTousGroupesContenants)
			{
				table[rel.GroupeContenant.Id] = true;
			}
		}
		//-------------------------------------------------------------------------
		private void C2iNecessiteGroupeTreeView_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_timer.Stop();

			if (e.Node == null)
				return;
			
			if (e.Node.Checked)
			{
				if (e.Node.Parent!=null)
				{
					e.Node.Parent.Checked = true;
					TreeViewEventArgs tvea = new TreeViewEventArgs(e.Node.Parent);
					C2iNecessiteGroupeTreeView_AfterCheck(sender, tvea);
				}
			}
			else
			{
				if (e.Node.Nodes.Count>0)
				{
					foreach (TreeNode node in e.Node.Nodes)
					{
						node.Checked = false;
						TreeViewEventArgs tvea = new TreeViewEventArgs(node);
						C2iNecessiteGroupeTreeView_AfterCheck(sender, tvea);
					}
				}
			}
			m_timer.Start();
		}
		//-------------------------------------------------------------------------
		private CResultAErreur CheckFromListe(CListeObjetsDonnees liste)
		{
			return CheckNodesFromListe(Nodes, liste);
		}
		//-------------------------------------------------------------------------
		private CResultAErreur CheckNodesFromListe(TreeNodeCollection nodeCollection, CListeObjetsDonnees liste)
		{
			CResultAErreur result = CResultAErreur.True;

			if ( !liste.TypeObjets.IsSubclassOf( typeof(CGroupeStructurant) ) )
				throw new Exception(I.T("The type of the list objects  must inherit from CGroupeStructurant.|30078"));
			
			foreach (TreeNode node in nodeCollection)
			{
				if (node.Tag is CGroupeStructurant)
				{
					CGroupeStructurant groupe = (CGroupeStructurant) node.Tag;
					if ( liste.Contains(groupe) )
					{
						if (node.Parent != null)
							node.Parent.Expand();
						node.Checked = true;
						CResultAErreur tempResult = CheckNodesFromListe(node.Nodes, liste);
						if (!tempResult)
						{
							result.Erreur.EmpileErreurs( tempResult.Erreur );
							result.SetFalse();
							return result;
						}
					}
					else
						node.Checked = false;
				}
			}
			return result;
		}
		//-------------------------------------------------------------------------
		public CObjetDeGroupe ObjetEdite
		{
			get
			{
				return m_objet;
			}
			set
			{
				if (m_objet==null )
					return;
				m_objet = value;
				bool bOldVal = m_bLockEdition;
				m_bLockEdition = false;
				CheckFromListe(m_objet.GetGroupesDirects());
				m_bLockEdition = bOldVal;
			}
		}
		//-------------------------------------------------------------------------
		public void SaveModifs()
		{
			ArrayList tableRelations = new ArrayList();
			foreach(IRelationGroupe rel in m_objet.RelationsGroupes)
				tableRelations.Add( rel );

			foreach(IRelationGroupe rel in tableRelations)
			{
				if ( !TableGroupesIdChecked.ContainsKey( rel.Groupe.Id) )
					rel.Delete();
			}

			foreach(int nGroupeId in TableGroupesIdChecked.Keys)
			{
				using(CGroupeStructurant groupe = (CGroupeStructurant) Activator.CreateInstance( m_typeGroupe, new object[] {m_objet.ContexteDonnee} ) )
				{
					groupe.Id = nGroupeId;
					if ( !m_objet.GetGroupesDirects().Contains(groupe) )
					{
						IRelationGroupe relation = (IRelationGroupe) Activator.CreateInstance( m_objet.RelationsGroupes.TypeObjets , new object[] {m_objet.ContexteDonnee} );
						relation.CreateNewInCurrentContexte();
						relation.Groupe = groupe;
						relation.ObjetDeGroupe = m_objet;
					}
				}
			}
		}
		//-------------------------------------------------------------------------
		private void m_timer_Tick(object sender, System.EventArgs e)
		{
			m_timer.Stop();
			if (AfterModifications!=null)
				AfterModifications(sender, e);
		}
		//-------------------------------------------------------------------------
		public CGroupeStructurant GetGroupeForNode(TreeNode node)
		{
			if (node.Tag is CGroupeStructurant)
				return (CGroupeStructurant) node.Tag;
			else
				return null;
		}
		//-------------------------------------------------------------------------
		public CGroupeStructurant[] GetGroupesForNode(TreeNode node)
		{
			ArrayList tableGroupes = new ArrayList();
			CGroupeStructurant groupe =  GetGroupeForNode(node);
			tableGroupes.Add(groupe);
			foreach (IRelationGroupeStructurantGroupeParent rel in groupe.RelationsTousGroupesContenants )
				if (!tableGroupes.Contains (rel.GroupeContenant) )
					tableGroupes.Add( rel.GroupeContenant);

			return (CGroupeStructurant[]) tableGroupes.ToArray( typeof(CGroupeStructurant) );
		}
		//-------------------------------------------------------------------------
	}
}