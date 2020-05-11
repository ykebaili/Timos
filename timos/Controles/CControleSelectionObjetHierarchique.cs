using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using sc2i.multitiers.client;
using sc2i.win32.data;
using timos.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;


namespace timos
{
	/// <summary>
	/// Description résumée de CControleSelectionObjetHierarchique.
	/// </summary>
	public class CControleSelectionObjetHierarchique : System.Windows.Forms.UserControl, IControlALockEdition
	{
		
		private Type m_typeObjets = null;
		private Type m_typeFormListe = null;
		private CObjetHierarchique m_objetSelectionne = null;
		private int m_nHeightDeplie = 250;
		private static DataSet m_datasetRecherche = new DataSet();
		private static CRecepteurNotification m_recepteurNotificationModificationObjets = null;
		private static CRecepteurNotification m_recepteurNotificationAjoutObjets = null;

		private TreeView m_arbre = null;
		private System.Windows.Forms.TreeView m_arbreViewSelection;
		private System.Windows.Forms.Timer m_timerFiltre;
		private System.Windows.Forms.Panel m_panelSelection;
		private System.Windows.Forms.Button m_boutonDropList;
		private System.Windows.Forms.TextBox m_txtFiltre;
		private System.Windows.Forms.PictureBox m_corbeille;
		private System.Windows.Forms.PictureBox m_btnEdition;
        protected CExtStyle m_ExtStyle1;
		private System.ComponentModel.IContainer components;



		public CControleSelectionObjetHierarchique()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

			try
			{

				if ( m_recepteurNotificationModificationObjets == null )
				{
					m_recepteurNotificationModificationObjets = new CRecepteurNotification ( CSessionClient.GetSessionUnique().IdSession, typeof(CDonneeNotificationModificationContexteDonnee));
					m_recepteurNotificationModificationObjets.OnReceiveNotification += new NotificationEventHandler(OnChangementDansObjets);
				}
				if ( m_recepteurNotificationAjoutObjets == null )
				{
					m_recepteurNotificationModificationObjets = new CRecepteurNotification ( CSessionClient.GetSessionUnique().IdSession, typeof(CDonneeNotificationAjoutEnregistrement));
					m_recepteurNotificationModificationObjets.OnReceiveNotification += new NotificationEventHandler(OnChangementDansObjets);
				}
			}
			catch{}

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
				if ( m_arbre != null )
					m_arbre.Dispose();
			}
			base.Dispose( disposing );
		}


		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleSelectionObjetHierarchique));
            this.m_arbreViewSelection = new System.Windows.Forms.TreeView();
            this.m_timerFiltre = new System.Windows.Forms.Timer(this.components);
            this.m_panelSelection = new System.Windows.Forms.Panel();
            this.m_btnEdition = new System.Windows.Forms.PictureBox();
            this.m_corbeille = new System.Windows.Forms.PictureBox();
            this.m_txtFiltre = new System.Windows.Forms.TextBox();
            this.m_boutonDropList = new System.Windows.Forms.Button();
            this.m_ExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_corbeille)).BeginInit();
            this.SuspendLayout();
            // 
            // m_arbreViewSelection
            // 
            this.m_arbreViewSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_arbreViewSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreViewSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_arbreViewSelection.ForeColor = System.Drawing.Color.Black;
            this.m_arbreViewSelection.Location = new System.Drawing.Point(0, 20);
            this.m_arbreViewSelection.Name = "m_arbreViewSelection";
            this.m_arbreViewSelection.Size = new System.Drawing.Size(464, 52);
            this.m_ExtStyle1.SetStyleBackColor(this.m_arbreViewSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_arbreViewSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_arbreViewSelection.TabIndex = 1;
            this.m_arbreViewSelection.TabStop = false;
            // 
            // m_timerFiltre
            // 
            this.m_timerFiltre.Interval = 200;
            this.m_timerFiltre.Tick += new System.EventHandler(this.m_timerFiltre_Tick);
            // 
            // m_panelSelection
            // 
            this.m_panelSelection.Controls.Add(this.m_btnEdition);
            this.m_panelSelection.Controls.Add(this.m_corbeille);
            this.m_panelSelection.Controls.Add(this.m_txtFiltre);
            this.m_panelSelection.Controls.Add(this.m_boutonDropList);
            this.m_panelSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelSelection.Location = new System.Drawing.Point(0, 0);
            this.m_panelSelection.Name = "m_panelSelection";
            this.m_panelSelection.Size = new System.Drawing.Size(464, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelection.TabIndex = 2;
            // 
            // m_btnEdition
            // 
            this.m_btnEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnEdition.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEdition.Image")));
            this.m_btnEdition.Location = new System.Drawing.Point(432, 0);
            this.m_btnEdition.Name = "m_btnEdition";
            this.m_btnEdition.Size = new System.Drawing.Size(16, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_btnEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_btnEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEdition.TabIndex = 4;
            this.m_btnEdition.TabStop = false;
            this.m_btnEdition.Click += new System.EventHandler(this.m_btnEdition_Click);
            // 
            // m_corbeille
            // 
            this.m_corbeille.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_corbeille.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_corbeille.Image = ((System.Drawing.Image)(resources.GetObject("m_corbeille.Image")));
            this.m_corbeille.Location = new System.Drawing.Point(448, 0);
            this.m_corbeille.Name = "m_corbeille";
            this.m_corbeille.Size = new System.Drawing.Size(16, 16);
            this.m_corbeille.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_ExtStyle1.SetStyleBackColor(this.m_corbeille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_corbeille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_corbeille.TabIndex = 3;
            this.m_corbeille.TabStop = false;
            this.m_corbeille.Click += new System.EventHandler(this.m_corbeille_Click);
            // 
            // m_txtFiltre
            // 
            this.m_txtFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_txtFiltre.Name = "m_txtFiltre";
            this.m_txtFiltre.Size = new System.Drawing.Size(416, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFiltre.TabIndex = 0;
            this.m_txtFiltre.TextChanged += new System.EventHandler(this.m_txtFiltre_TextChanged);
            this.m_txtFiltre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFiltre_KeyDown);
            // 
            // m_boutonDropList
            // 
            this.m_boutonDropList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_boutonDropList.BackColor = System.Drawing.SystemColors.Control;
            this.m_boutonDropList.Image = ((System.Drawing.Image)(resources.GetObject("m_boutonDropList.Image")));
            this.m_boutonDropList.Location = new System.Drawing.Point(416, 0);
            this.m_boutonDropList.Name = "m_boutonDropList";
            this.m_boutonDropList.Size = new System.Drawing.Size(17, 17);
            this.m_ExtStyle1.SetStyleBackColor(this.m_boutonDropList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_boutonDropList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_boutonDropList.TabIndex = 2;
            this.m_boutonDropList.TabStop = false;
            this.m_boutonDropList.UseVisualStyleBackColor = false;
            this.m_boutonDropList.Click += new System.EventHandler(this.m_boutonDropList_Click);
            // 
            // CControleSelectionObjetHierarchique
            // 
            this.Controls.Add(this.m_arbreViewSelection);
            this.Controls.Add(this.m_panelSelection);
            this.Name = "CControleSelectionObjetHierarchique";
            this.Size = new System.Drawing.Size(464, 72);
            this.m_ExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Leave += new System.EventHandler(this.CControleSelectionObjetHierarchique_Leave);
            this.BackColorChanged += new System.EventHandler(this.CControleSelectionObjetHierarchique_BackColorChanged);
            this.m_panelSelection.ResumeLayout(false);
            this.m_panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_corbeille)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void Init ( Type typeObjet, Type typeFormListeObjets )
		{
			m_typeObjets = typeObjet;
			m_typeFormListe = typeFormListeObjets;
		}

		private void CControleSelectionObjetHierarchique_BackColorChanged(object sender, System.EventArgs e)
		{
			m_arbreViewSelection.BackColor = BackColor;
		}

		private const string c_champLibelleTotal = "LIBELLE";
		private void PrepareTableRecherche()
		{
			lock(  m_datasetRecherche )
			{
				if ( m_datasetRecherche.Tables[m_typeObjets.ToString()] != null )
					m_datasetRecherche.Tables.Remove ( m_typeObjets.ToString() );

				DataTable newTable = new DataTable ( m_typeObjets.ToString() );
				m_datasetRecherche.Tables.Add ( newTable );
			
				CObjetHierarchique objet = (CObjetHierarchique)Activator.CreateInstance ( m_typeObjets, new object[]{CSc2iWin32DataClient.ContexteCourant} );
				newTable.Columns.Add ( objet.ChampLibelle, typeof(string)).MaxLength = 16000;
				newTable.Columns.Add ( c_champLibelleTotal, typeof(string)).MaxLength = 16000;
				newTable.Columns.Add ( objet.GetChampId(), typeof(int) );
				CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, m_typeObjets );
				liste.Tri = objet.ChampNiveau+","+objet.ChampLibelle;
				foreach ( CObjetHierarchique objetH in liste )
				{
					DataRow row = newTable.NewRow();
					row[objetH.GetChampId()] = objetH.Id;
					row[objetH.ChampLibelle] = RemoveAccents(objetH.Libelle);
					row[ c_champLibelleTotal] = RemoveAccents(GetLibelleComplet ( objetH ));
					newTable.Rows.Add ( row );
				}
			}
		}

		private string RemoveAccents ( string strLibelle )
		{
			return CUtilTexte.RemplaceAccentsParEquivalent ( strLibelle );
		}


		private int HeightDeplie
		{
			get
			{
				return m_nHeightDeplie;
			}
			set
			{
				m_nHeightDeplie = value;
				if ( m_arbre != null )
					m_arbre.Height = value;
			}
		}

		private string GetLibelleComplet ( IObjetHierarchiqueACodeHierarchique objet )
		{
			if ( objet == null )
				return "";
			return GetLibelleComplet ( objet.ObjetParent )+"/"+objet.Libelle ;
		}

		private Hashtable m_tableObjetToClavier = new Hashtable();
		private Hashtable m_tableClavierToObjet = new Hashtable();
		private Hashtable m_tableObjetToNode = new Hashtable();

		private void m_timerFiltre_Tick(object sender, System.EventArgs e)
		{
			using ( CWaitCursor waiter = new CWaitCursor() )
			{
				m_timerFiltre.Stop();

				RemplitArbre(false);
			}
		}

		private void RemplitArbre( bool bForcer )
		{
			ArrayList liste = new ArrayList();
			int nNiveauMax = 0;

			lock( m_datasetRecherche )
			{
				DataTable tableRecherche = m_datasetRecherche.Tables[m_typeObjets.ToString()];
				if ( tableRecherche == null )
					PrepareTableRecherche();
				tableRecherche = m_datasetRecherche.Tables[m_typeObjets.ToString()];

			
				if ( m_txtFiltre.Text.Trim().Length < 3 && !bForcer )
					return;
				m_tableObjetToClavier.Clear();
				m_tableClavierToObjet.Clear();
				//Extrait les mots du filtre
				string[] strValeurs = RemoveAccents(m_txtFiltre.Text).Split(' ');
				if ( strValeurs.Length == 0 )
					return;
				string strFiltreSurTotal = "";
				string strFiltreSurLibelle = "";
				CObjetHierarchique objet = (CObjetHierarchique)Activator.CreateInstance ( m_typeObjets, new object[]{CSc2iWin32DataClient.ContexteCourant} );
				foreach ( string strValeur in strValeurs )
				{
					if ( strValeur.Trim().Length > 0 )
					{
						if ( strFiltreSurLibelle.Length > 0 )
							strFiltreSurLibelle += " and ";
						strFiltreSurLibelle += "("+objet.ChampLibelle+" like "+
							"'"+strValeur.Trim()+"%' or "+
							objet.ChampLibelle+" like '% "+strValeur.Trim()+"%' or "+
							objet.ChampLibelle+" like '%/"+strValeur.Trim()+"%')";
							
						if ( strFiltreSurTotal.Length > 0 )
							strFiltreSurTotal+= " and ";
						strFiltreSurTotal += "("+c_champLibelleTotal+" like "+
							"'"+strValeur.Trim()+"%' or "+
							c_champLibelleTotal+" like '% "+strValeur.Trim()+"%' or "+
							c_champLibelleTotal+" like '%/"+strValeur.Trim()+"%')";
					}
				}
				DataRow[] rows = tableRecherche.Select ( strFiltreSurLibelle );
				Hashtable tableContenantSurLibelle = new Hashtable();
				foreach( DataRow row in rows )
					tableContenantSurLibelle[row[objet.GetChampId()]] = true;
				rows = tableRecherche.Select ( strFiltreSurTotal );

		
				
				Hashtable tableCodes = new Hashtable();
				Hashtable tableNbFils = new Hashtable();
				Hashtable tableQuiNeContientPasDirectement = new Hashtable();
				foreach ( DataRow row in rows )
				{
					CObjetHierarchique objetType = (CObjetHierarchique)Activator.CreateInstance ( m_typeObjets, new object[]{CSc2iWin32DataClient.ContexteCourant} );
					if ( objetType.ReadIfExists ( (int)row[objetType.GetChampId()] ) )
					{
						liste.Add ( objetType) ;
						tableCodes[objetType.CodeSystemeComplet] = 0;
						string strFamP = objetType.CodeSystemeComplet.Substring(0, objetType.CodeSystemeComplet.Length-objetType.NbCarsParNiveau);
						if ( strFamP != "" && tableContenantSurLibelle.Contains(objetType.Id) )
						{
							if ( !tableNbFils.Contains(strFamP) )
								tableNbFils[strFamP] = 1;
							else
								tableNbFils[strFamP] = (int)tableNbFils[strFamP]+1;
						}
					}
				}
				//Enlève de la liste les sous familles des familles sélectionnées
				ArrayList lstNew = new ArrayList();
				foreach ( CObjetHierarchique objetTmp in liste )
				{
					string strCodeFamille = objetTmp.CodeSystemeComplet.Substring(0, objetTmp.CodeSystemeComplet.Length-objetTmp.NbCarsParNiveau);
					bool bSupprimer = false;
					while ( strCodeFamille != "" && !bSupprimer)
					{
						object nbChilds = tableNbFils[strCodeFamille];
						if ( tableCodes.Contains ( strCodeFamille ) &&
							(( nbChilds != null && 
							(int)nbChilds > 1) || !tableContenantSurLibelle.Contains(objetTmp.Id) )  )
							bSupprimer = true;
						strCodeFamille = strCodeFamille.Substring(0, strCodeFamille.Length-objet.NbCarsParNiveau);
					}
					if ( !bSupprimer )
					{
						lstNew.Add ( objetTmp );
						if ( objetTmp.Niveau > nNiveauMax )
							nNiveauMax = objetTmp.Niveau;
					}

				}
				liste = lstNew;
			}

			m_tableObjetToNode = new Hashtable();

			if ( liste.Count != 0  )
			{
				if ( m_arbre == null )
				{
					Form frm = FindForm();
					if ( frm == null )
						return;
					Point pt = PointToScreen ( m_txtFiltre.Location );
					pt.Y += m_txtFiltre.Height;
					pt = frm.PointToClient ( pt );
					m_arbre = new TreeView();
					m_arbre.Parent = frm;
					m_arbre.Location = pt;
					m_arbre.Size = new Size ( Size.Width, HeightDeplie );
					m_arbre.CreateControl();
					m_arbre.DoubleClick += new EventHandler(m_arbre_DoubleClick);
					m_arbre.Leave += new EventHandler ( CControleSelectionObjetHierarchique_Leave );
					m_arbre.BeforeExpand += new TreeViewCancelEventHandler(m_arbre_BeforeExpand);
				}
				m_arbre.BeginUpdate();
				m_arbre.Nodes.Clear();
				m_arbre.BringToFront();
				m_arbre.Visible = true;
			}
			else
				if ( m_arbre != null )
				m_arbre.Nodes.Clear();
			
			int n = 1;
			
			foreach ( CObjetHierarchique objet in liste )
			{
				if ( n < 10 )
				{
					m_tableObjetToClavier[objet] = n;
					m_tableClavierToObjet[n] = objet;
				}
				n++;
				AddObjet ( objet, m_tableObjetToNode, true, nNiveauMax );
			}
			if ( m_arbre != null )
				m_arbre.EndUpdate();
		}


		private TreeNode AddObjet ( IObjetHierarchiqueACodeHierarchique objet, Hashtable tableObjetToNode, bool bExpandable, int nNiveauToExpand )
		{
			TreeNode leNode = (TreeNode)tableObjetToNode[objet];
			if ( leNode != null )
			{
				return leNode;
			}
			TreeNode nodeParent = null;
			if ( objet.ObjetParent != null )
				nodeParent = AddObjet ( objet.ObjetParent, tableObjetToNode, false, nNiveauToExpand );
			
			leNode = new TreeNode ( objet.Libelle );
			if ( m_tableObjetToClavier[objet] != null )
				leNode.Text = ((int)m_tableObjetToClavier[objet]).ToString()+" - "+objet.Libelle;
			leNode.Tag = objet;
			if ( nodeParent == null )
				m_arbre.Nodes.Add ( leNode );
			else
			{
				if ( nodeParent.Nodes.Count ==1 && nodeParent.Nodes[0].Tag == null )
					nodeParent.Nodes.Clear();//C'était un node à completer, on va le completer dans l'appelant
				nodeParent.Nodes.Add ( leNode );
				if ( !nodeParent.IsExpanded )
					nodeParent.Expand();
			}
			if ( bExpandable && objet.ObjetsFils.Count > 0 )
			{
				leNode.BackColor = Color.LightGreen;
				if ( objet.Niveau == nNiveauToExpand )
				{
					FillChilds ( leNode );
					leNode.Expand();
				}
				else
				{
					TreeNode nodeTmp = new TreeNode("");
					nodeTmp.Tag = null;
					leNode.Nodes.Add ( nodeTmp );
				}
			}
			tableObjetToNode[objet]=leNode;
			return leNode;
		}

		private void m_arbre_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if ( e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null )
				FillChilds ( e.Node );
		}

		private void FillChilds ( TreeNode nodeParent )
		{
			CObjetHierarchique objet = (CObjetHierarchique)nodeParent.Tag;
			if ( nodeParent.Nodes.Count == 1 && nodeParent.Nodes[0].Tag == null )
				nodeParent.Nodes.Clear();
			foreach ( CObjetHierarchique objetFille in objet.ObjetsFils )
			{
				TreeNode node = new TreeNode ( objetFille.Libelle );
				node.Tag = objetFille;
				nodeParent.Nodes.Add ( node );
				if ( objetFille.ObjetsFils.Count > 0 )
				{
					TreeNode nodeTmp = new TreeNode("");
					nodeTmp.Tag = null;
					node.Nodes.Add ( nodeTmp );
				}
			}
		}

		private void m_txtFiltre_TextChanged(object sender, System.EventArgs e)
		{
			if ( m_txtFiltre.Enabled )
			{
				m_timerFiltre.Stop();
				m_timerFiltre.Start();
			}
		}

		//------------------------------------------------------------------------------------
		private void OnChangementDansObjets ( IDonneeNotification donnee )
		{
			if ( donnee is CDonneeNotificationModificationContexteDonnee )
			{
				CDonneeNotificationModificationContexteDonnee modif = (CDonneeNotificationModificationContexteDonnee)donnee;
				foreach ( CDonneeNotificationModificationContexteDonnee.CInfoEnregistrementModifie info in modif.ListeModifications )
				{
					if ( m_datasetRecherche.Tables[info.NomTable] != null )
					{
						lock(  m_datasetRecherche )
						{
							m_datasetRecherche.Tables.Remove ( info.NomTable );
						}
					}
				}
			}
			if ( donnee is CDonneeNotificationAjoutEnregistrement )
			{
				string strNomTable = ((CDonneeNotificationAjoutEnregistrement)donnee).NomTable;
				if ( m_datasetRecherche.Tables[strNomTable] != null )
				{
					lock(  m_datasetRecherche )
					{
						m_datasetRecherche.Tables.Remove ( strNomTable );
					}
				}
			}
		}

		private void CControleSelectionObjetHierarchique_Leave(object sender, System.EventArgs e)
		{
			if ( m_arbre != null && !m_arbre.Focused && !this.Focused && !m_txtFiltre.Focused )
			{
				if ( m_arbre.Visible )
					m_arbre.Hide();
			}
		}

		private void m_txtFiltre_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int nCode = 0;
			if ( (e.Modifiers & Keys.Control) == Keys.Control )
			{
				nCode = (int)e.KeyCode-(int)Keys.NumPad0;
				if ( nCode <= 0 || nCode > 9 )
					nCode = (int)e.KeyCode-(int)Keys.D0;
			}
			if ( e.KeyCode == Keys.Enter )
				nCode = 1;
			if ( nCode > 0 && nCode <= 9 )
			{
				if ( m_tableClavierToObjet[nCode] != null )
				{
					CObjetHierarchique objet = (CObjetHierarchique)m_tableClavierToObjet[nCode];
					TreeNode node = (TreeNode)m_tableObjetToNode[objet];
					if ( node.Nodes.Count > 0 && !node.IsExpanded )
						node.Expand();
					else
					{
						ObjetSelectionne = objet;
						
						if ( m_arbre.Visible )
							m_arbre.Hide();
					}
					e.Handled = true;
				}
			}
			if ( e.KeyCode == Keys.Tab && m_arbre != null )
				m_arbre.Focus();
		}
		#region Membres de IControlALockEdition

		public bool LockEdition
		{
			get
			{
				return !m_panelSelection.Visible;
			}
			set
			{
				m_panelSelection.Visible = !value;
				if ( value && m_arbre != null && m_arbre.Visible )
					m_arbre.Hide();
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this , new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

		public event EventHandler OnChangeSelection;
		[DefaultValue(null)]
		public CObjetHierarchique ObjetSelectionne
		{
			get
			{
				return m_objetSelectionne;
			}
			set
			{
				m_objetSelectionne = value;
				if  ( value != null )
				{
					m_txtFiltre.Enabled = false;
					m_txtFiltre.Text = ObjetSelectionne.Libelle;
					m_txtFiltre.Enabled = true;
				}
				else
					m_txtFiltre.Text = "";
				ShowSelection();
				if ( OnChangeSelection != null )
					OnChangeSelection ( this, new EventArgs() );
			}
		}

		private void ShowSelection()
		{
			m_arbreViewSelection.Nodes.Clear();
			AddObjetToSelection ( m_objetSelectionne );
		}

		private TreeNode AddObjetToSelection ( IObjetHierarchiqueACodeHierarchique objet )
		{
			if ( objet == null )
				return null;
			TreeNode nodeParent = AddObjetToSelection ( objet.ObjetParent );
			TreeNode node = new TreeNode ( objet.Libelle );
			node.Tag = objet;
			if ( nodeParent != null )
			{
				nodeParent.Nodes.Add ( node );
				nodeParent.Expand();
			}
			else
				m_arbreViewSelection.Nodes.Add ( node );
			return node;
		}

		private void m_boutonDropList_Click(object sender, System.EventArgs e)
		{
			RemplitArbre ( true );
			/*if ( m_arbre != null )
				m_arbre.Visible = !m_arbre.Visible;*/
		}

		private void m_arbre_DoubleClick(object sender, EventArgs e)
		{
			TreeNode item = m_arbre.SelectedNode;
			if ( item != null && item.Tag is CObjetHierarchique )
			{
				ObjetSelectionne = (CObjetHierarchique)item.Tag;
				if ( m_arbre != null )
					m_arbre.Hide();
			}
		}

		
		

		private void m_corbeille_Click(object sender, System.EventArgs e)
		{
			ObjetSelectionne =  null;
		}

		private void m_btnEdition_Click(object sender, System.EventArgs e)
		{
			if ( m_typeFormListe != null )
			{
				try
				{
					IFormNavigable form = (IFormNavigable)Activator.CreateInstance ( m_typeFormListe );
					CFormNavigateurPopup.Show ( form );
					PrepareTableRecherche();
				}
				catch
				{
				}
			}
				

		}

		
	}
}
