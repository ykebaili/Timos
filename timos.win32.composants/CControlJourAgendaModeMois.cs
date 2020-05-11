using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using timos.acteurs;


namespace timos.win32.composants
{
	/// <summary>
	/// Représente un jour dans un agenda en mode affichage mensuel
	/// </summary>
	
	public class CControlJourAgendaModeMois : System.Windows.Forms.UserControl
	{
		private bool m_bIsOuvert = true;
		private bool m_bAvecInitiales = false;
		private bool m_bModeSemaine = false;
		private ListViewItem m_lastItemInTooltip = null;
		private IControlAgenda m_controlToNotifyChangement;
		private System.Windows.Forms.Label m_lblJour;
		private System.Windows.Forms.ColumnHeader m_colWidthHour;
		private System.Windows.Forms.Panel m_panelCadre;
		private System.Windows.Forms.ListView m_wndListeEntrees;

		private DateTime m_date = DateTime.Now;
		
		private ArrayList m_listeEntreeAgenda = new ArrayList();

		private int m_nFirstEntreeAvecHeure = 0;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.PictureBox m_iconeFerme;
		private System.ComponentModel.IContainer components;

		public CControlJourAgendaModeMois()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		public CControlJourAgendaModeMois ( IControlAgenda controlToNotifyChangement )
		{
			m_controlToNotifyChangement = controlToNotifyChangement;
			InitializeComponent();
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

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlJourAgendaModeMois));
            this.m_lblJour = new System.Windows.Forms.Label();
            this.m_wndListeEntrees = new System.Windows.Forms.ListView();
            this.m_colWidthHour = new System.Windows.Forms.ColumnHeader();
            this.m_panelCadre = new System.Windows.Forms.Panel();
            this.m_iconeFerme = new System.Windows.Forms.PictureBox();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelCadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_iconeFerme)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblJour
            // 
            this.m_lblJour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblJour.BackColor = System.Drawing.Color.Silver;
            this.m_lblJour.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblJour.Location = new System.Drawing.Point(0, 0);
            this.m_lblJour.Name = "m_lblJour";
            this.m_lblJour.Size = new System.Drawing.Size(128, 12);
            this.m_lblJour.TabIndex = 0;
            this.m_lblJour.Text = "[DAY]|30084";
            this.m_lblJour.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.m_lblJour.Enter += new System.EventHandler(this.m_lblJour_Enter);
            this.m_lblJour.Leave += new System.EventHandler(this.m_lblJour_Leave);
            // 
            // m_wndListeEntrees
            // 
            this.m_wndListeEntrees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEntrees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_wndListeEntrees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colWidthHour});
            this.m_wndListeEntrees.FullRowSelect = true;
            this.m_wndListeEntrees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeEntrees.Location = new System.Drawing.Point(0, 12);
            this.m_wndListeEntrees.MultiSelect = false;
            this.m_wndListeEntrees.Name = "m_wndListeEntrees";
            this.m_wndListeEntrees.Size = new System.Drawing.Size(128, 140);
            this.m_wndListeEntrees.TabIndex = 1;
            this.m_wndListeEntrees.UseCompatibleStateImageBehavior = false;
            this.m_wndListeEntrees.View = System.Windows.Forms.View.Details;
            this.m_wndListeEntrees.DoubleClick += new System.EventHandler(this.m_wndListeEntrees_DoubleClick);
            this.m_wndListeEntrees.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_wndListeEntrees_MouseUp);
            this.m_wndListeEntrees.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_wndListeEntrees_MouseMove);
            this.m_wndListeEntrees.Click += new System.EventHandler(this.m_wndListeEntrees_Click);
            // 
            // m_colWidthHour
            // 
            this.m_colWidthHour.Width = 200;
            // 
            // m_panelCadre
            // 
            this.m_panelCadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelCadre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelCadre.Controls.Add(this.m_iconeFerme);
            this.m_panelCadre.Controls.Add(this.m_lblJour);
            this.m_panelCadre.Controls.Add(this.m_wndListeEntrees);
            this.m_panelCadre.Location = new System.Drawing.Point(0, 0);
            this.m_panelCadre.Name = "m_panelCadre";
            this.m_panelCadre.Size = new System.Drawing.Size(128, 152);
            this.m_panelCadre.TabIndex = 3;
            // 
            // m_iconeFerme
            // 
            this.m_iconeFerme.BackColor = System.Drawing.Color.Silver;
            this.m_iconeFerme.Image = ((System.Drawing.Image)(resources.GetObject("m_iconeFerme.Image")));
            this.m_iconeFerme.Location = new System.Drawing.Point(0, 0);
            this.m_iconeFerme.Name = "m_iconeFerme";
            this.m_iconeFerme.Size = new System.Drawing.Size(12, 12);
            this.m_iconeFerme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_iconeFerme.TabIndex = 2;
            this.m_iconeFerme.TabStop = false;
            this.m_iconeFerme.Visible = false;
            // 
            // CControlJourAgendaModeMois
            // 
            this.Controls.Add(this.m_panelCadre);
            this.Name = "CControlJourAgendaModeMois";
            this.Size = new System.Drawing.Size(128, 152);
            this.Enter += new System.EventHandler(this.CControlJourAgendaModeMois_Enter);
            this.Leave += new System.EventHandler(this.CControlJourAgendaModeMois_Leave);
            this.Resize += new System.EventHandler(this.CControlJourAgendaModeMois_Resize);
            this.m_panelCadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_iconeFerme)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		////////////////////////////
		public bool ModeSemaine
		{
			get
			{
				return m_bModeSemaine;
			}
			set
			{
				m_bModeSemaine = value;
				UpdateAspect();
			}
		}

		public bool AvecInitiales
		{
			get
			{
				return m_bAvecInitiales;
			}
			set
			{
				m_bAvecInitiales = value;
			}
		}
		
		
		/// <summary>
		/// /////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void CControlJourAgendaModeMois_Resize(object sender, System.EventArgs e)
		{
			try
			{
				m_wndListeEntrees.Columns[0].Width = m_wndListeEntrees.ClientRectangle.Width;
			}
			catch
			{
			}
			UpdateAspect();
		}

		public ImageList ImageRoles
		{
			get
			{
				return m_wndListeEntrees.SmallImageList;
			}
			set
			{
				m_wndListeEntrees.SmallImageList = value;
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="dt"></param>
		public void SetJour ( DateTime dt)
		{
			m_date = dt;
			UpdateAspect();
		}

		////////////////////////////////////
		public void Clear()
		{
			m_listeEntreeAgenda.Clear();
			m_wndListeEntrees.Items.Clear();
			m_nFirstEntreeAvecHeure = 0;
		}


		////////////////////////////////////
		public void AddEntree ( CVisuEntreeAgenda entree, int nIndexImage )
		{
			int nPos = 0;
			if ( entree.Entree.SansHoraire || entree.Entree.DateDebut != m_date)
			{
				nPos = m_nFirstEntreeAvecHeure;
				m_listeEntreeAgenda.Insert(m_nFirstEntreeAvecHeure, entree);
				m_nFirstEntreeAvecHeure++;
			}
			else
			{
				nPos = 0;
				bool bAdded = false;
				foreach ( CVisuEntreeAgenda entreeEnPlace in m_listeEntreeAgenda )
				{
					if ( !entreeEnPlace.Entree.SansHoraire && 
						entreeEnPlace.DateDebut > entree.DateDebut )
					{
						m_listeEntreeAgenda.Insert(nPos, entree );
						bAdded = true;
						break;
					}
					nPos++;
				}
				if ( !bAdded )
				{
					nPos = m_listeEntreeAgenda.Count;
					m_listeEntreeAgenda.Add ( entree );
				}
			}
			//Créee l'item
			ListViewItem item = new ListViewItem();
			item.Tag = entree;
			item.ImageIndex = nIndexImage;
			Color couleurTexte=Color.Black, couleurFond = Color.White;
			CCouleursForEntreeAgenda.GetCouleursFor ( entree.Entree, ref couleurFond, ref couleurTexte );
			item.BackColor = couleurFond;
			item.ForeColor = couleurTexte;
			m_wndListeEntrees.Items.Insert(nPos, item);
			m_wndListeEntrees.ListViewItemSorter = new ItemSorter();
			m_wndListeEntrees.Sort();
			UpdateItemText ( item );
		}

		////////////////////////////////////
		private class ItemSorter : IComparer
		{
			#region Membres de IComparer

			public int Compare(object x, object y)
			{
				if ( x is ListViewItem && y is ListViewItem )
				{
					CVisuEntreeAgenda entree1, entree2;
					entree1 = (CVisuEntreeAgenda)((ListViewItem)x).Tag;
					entree2 = (CVisuEntreeAgenda)((ListViewItem)y).Tag;
					int nRes = entree1.DateDebut.CompareTo ( entree2.DateDebut );
					if ( nRes != 0 )
						return nRes;
					return entree1.Entree.Libelle.CompareTo( entree2.Entree.Libelle );
				}
				return -1;
			}

			#endregion

		}


		////////////////////////////////////
		private void UpdateItemText ( ListViewItem item )
		{
			if ( !(item.Tag is CVisuEntreeAgenda) )
				return;
			CVisuEntreeAgenda entree = (CVisuEntreeAgenda)item.Tag;
			string strText = "";
			if ( !entree.Entree.SansHoraire && CUtilDate.SetTime0(entree.DateDebut) == CUtilDate.SetTime0(m_date) )
			{
				if ( Width > 68 )
					strText = GetHeure ( entree.DateDebut );
				if ( m_bModeSemaine ) 
				{
					if ( entree.DateFin.Date == m_date.Date )
						strText += "-"+GetHeure ( entree.DateFin )+" ";
					else
						strText += "...";
				}
				else
					strText += " ";

			}
			if ( CUtilDate.SetTime0(entree.DateDebut) != CUtilDate.SetTime0(m_date) )
			{
				strText += "...";
				if ( m_bModeSemaine && entree.DateFin.Date == m_date.Date )
					strText += GetHeure ( entree.DateFin )+" ";
			}
			if ( m_bAvecInitiales )
			{
				if ( entree.ElementLie is IElementAIdentificationCourteAgenda )
					strText += ((IElementAIdentificationCourteAgenda)entree.ElementLie).IdentificationCourte+"-";
			}
			strText += entree.Entree.Libelle;
			item.Text = strText;
		}

		////////////////////////////////////
		private string GetHeure ( DateTime dt )
		{
			string strHeure = dt.Hour.ToString().PadLeft(2,'0')+":"+
				dt.Minute.ToString().PadLeft(2,'0');
			return strHeure;
		}


		////////////////////////////////////
		private void UpdateAspect()
		{
			if ( m_bModeSemaine )
				m_lblJour.Text = m_date.ToString("dddd dd MMMM");
			else
			{
				m_lblJour.Text = m_date.Day.ToString();
				if ( m_date.Day == 1 )
					m_lblJour.Text += " "+CUtilDate.GetNomMois(m_date.Month, Width < 50);
			}
			m_iconeFerme.Visible = !m_bIsOuvert;
			foreach ( ListViewItem item in m_wndListeEntrees.Items )
				UpdateItemText(item);
		}

		public event DemandeAffichageEntreeAgendaEventHandler OnDemandeAffichageEntree;
		////////////////////////////////////
		private void m_wndListeEntrees_DoubleClick(object sender, System.EventArgs e)
		{
            if ( m_wndListeEntrees.SelectedItems.Count != 1 )
				return;
			CVisuEntreeAgenda entree = (CVisuEntreeAgenda)m_wndListeEntrees.SelectedItems[0].Tag;
			if ( OnDemandeAffichageEntree != null )
				OnDemandeAffichageEntree ( entree.Entree );
		}

		////////////////////////////////////
		private void m_lblJour_Enter(object sender, System.EventArgs e)
		{
			m_lblJour.BackColor = SystemColors.ActiveCaption;
		}

		////////////////////////////////////
		private void m_lblJour_Leave(object sender, System.EventArgs e)
		{
			m_lblJour.BackColor = System.Drawing.Color.Silver;
		}

		private void m_wndListeEntrees_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ListViewItem item = m_wndListeEntrees.GetItemAt ( e.X, e.Y );
			if ( item == m_lastItemInTooltip )
				return;
			if ( item == null )
				m_tooltip.SetToolTip(m_wndListeEntrees,"");
			else
			{
				CVisuEntreeAgenda entree = (CVisuEntreeAgenda)item.Tag;
				string strText = entree.Entree.Libelle+"\r\n";
				if ( entree.Entree.Commentaires.Trim() != "" )
					strText += entree.Entree.Commentaires+"\r\n";
				if ( entree.Entree is CEntreeAgenda )
				{
					CEntreeAgenda ea = (CEntreeAgenda)entree.Entree;
					foreach ( CRelationEntreeAgenda_ElementAAgenda relation in ea.RelationsElementsAgenda )
					{
						if ( relation.ElementLie != null )
						{
							strText += relation.RelationTypeEntree_TypeElement.Libelle+" : "+
								relation.ElementLie.DescriptionElement+"\r\n";
						}
					}
				}
				m_tooltip.SetToolTip ( m_wndListeEntrees, strText );
			}
			m_lastItemInTooltip = item;
		}

		private void CControlJourAgendaModeMois_Enter(object sender, System.EventArgs e)
		{
			m_lblJour.BackColor = SystemColors.ActiveCaption;
			m_lblJour.ForeColor = SystemColors.ActiveCaptionText;
		}

		private void CControlJourAgendaModeMois_Leave(object sender, System.EventArgs e)
		{
			m_lblJour.BackColor = System.Drawing.Color.Silver;
			m_lblJour.ForeColor = SystemColors.ControlText;
		}

		////////////////////////////////////
		private void m_wndListeEntrees_Click(object sender, System.EventArgs e)
		{
			
		}

		private void m_wndListeEntrees_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( OnDemandeCreationEntreeAgenda!=null && e.Button == MouseButtons.Right )
				OnDemandeCreationEntreeAgenda ( this, new EventArgs() );
		}
		
		////////////////////////////////////
		public Color CouleurFond
		{
			get
			{
				return m_wndListeEntrees.BackColor;
			}
			set
			{
				m_wndListeEntrees.BackColor = value;
			}
		}

		////////////////////////////////////
		public DateTime Jour
		{
			get
			{
				return m_date;
			}
		}

		/// ////////////////////////////////////////////
		public event EventHandler OnDemandeCreationEntreeAgenda;


		
	}
}
