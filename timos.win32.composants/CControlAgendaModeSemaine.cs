using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.workflow;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CControlAgendaModeSemaine.
	/// </summary>
	public class CControlAgendaModeSemaine : System.Windows.Forms.UserControl, IControlAgenda
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private CFiltreData m_filtreAAppliquer;
		private CImagesForRolesAgenda m_imagesRoles = null;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel m_panelJours;

		public DateTime m_dateEnCours = DateTime.Now;

		private ArrayList m_listeControlsJours = new ArrayList();
		private System.Windows.Forms.Panel m_panelEntete;
		private System.Windows.Forms.Label m_labelTitre;
		private System.Windows.Forms.Button m_btnSuivant;
		private System.Windows.Forms.Button m_btnPrecedent;
		private System.Windows.Forms.VScrollBar m_scrollBar;

		private Color m_couleursMoisPairs = Color.FromArgb(240, 240, 240);
		private Color m_couleurMoisImpairs = Color.FromArgb(255,255,255);

		private CObjetDonneeAIdNumerique[] m_elementsAAgenda = null;

		//Date de la première cellule
		private DateTime m_dtFirstCellDate = DateTime.Now;

		public CControlAgendaModeSemaine()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CControlAgendaModeSemaine));
			this.m_panelJours = new System.Windows.Forms.Panel();
			this.m_panelEntete = new System.Windows.Forms.Panel();
			this.m_btnSuivant = new System.Windows.Forms.Button();
			this.m_btnPrecedent = new System.Windows.Forms.Button();
			this.m_labelTitre = new System.Windows.Forms.Label();
			this.m_scrollBar = new System.Windows.Forms.VScrollBar();
			this.m_panelEntete.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelJours
			// 
			this.m_panelJours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelJours.Location = new System.Drawing.Point(0, 24);
			this.m_panelJours.Name = "m_panelJours";
			this.m_panelJours.Size = new System.Drawing.Size(328, 280);
			this.m_panelJours.TabIndex = 0;
			this.m_panelJours.SizeChanged += new System.EventHandler(this.m_panelJours_SizeChanged);
			// 
			// m_panelEntete
			// 
			this.m_panelEntete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelEntete.BackColor = System.Drawing.Color.White;
			this.m_panelEntete.Controls.Add(this.m_btnSuivant);
			this.m_panelEntete.Controls.Add(this.m_btnPrecedent);
			this.m_panelEntete.Controls.Add(this.m_labelTitre);
			this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
			this.m_panelEntete.Name = "m_panelEntete";
			this.m_panelEntete.Size = new System.Drawing.Size(344, 24);
			this.m_panelEntete.TabIndex = 4;
			// 
			// m_btnSuivant
			// 
			this.m_btnSuivant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnSuivant.ForeColor = System.Drawing.Color.White;
			this.m_btnSuivant.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSuivant.Image")));
			this.m_btnSuivant.Location = new System.Drawing.Point(312, 0);
			this.m_btnSuivant.Name = "m_btnSuivant";
			this.m_btnSuivant.Size = new System.Drawing.Size(24, 26);
			this.m_btnSuivant.TabIndex = 3;
			this.m_btnSuivant.TabStop = false;
			this.m_btnSuivant.Click += new System.EventHandler(this.m_btnSuivant_Click);
			// 
			// m_btnPrecedent
			// 
			this.m_btnPrecedent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnPrecedent.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnPrecedent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnPrecedent.ForeColor = System.Drawing.Color.White;
			this.m_btnPrecedent.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrecedent.Image")));
			this.m_btnPrecedent.Location = new System.Drawing.Point(280, 0);
			this.m_btnPrecedent.Name = "m_btnPrecedent";
			this.m_btnPrecedent.Size = new System.Drawing.Size(24, 26);
			this.m_btnPrecedent.TabIndex = 2;
			this.m_btnPrecedent.TabStop = false;
			this.m_btnPrecedent.Click += new System.EventHandler(this.m_btnPrecedent_Click);
			// 
			// m_labelTitre
			// 
			this.m_labelTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_labelTitre.Location = new System.Drawing.Point(24, 0);
			this.m_labelTitre.Name = "m_labelTitre";
			this.m_labelTitre.Size = new System.Drawing.Size(248, 24);
			this.m_labelTitre.TabIndex = 0;
			// 
			// m_scrollBar
			// 
			this.m_scrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_scrollBar.LargeChange = 3;
			this.m_scrollBar.Location = new System.Drawing.Point(328, 64);
			this.m_scrollBar.Maximum = 2;
			this.m_scrollBar.Name = "m_scrollBar";
			this.m_scrollBar.Size = new System.Drawing.Size(16, 192);
			this.m_scrollBar.TabIndex = 5;
			// 
			// CControlAgendaModeSemaine
			// 
			this.Controls.Add(this.m_scrollBar);
			this.Controls.Add(this.m_panelEntete);
			this.Controls.Add(this.m_panelJours);
			this.Name = "CControlAgendaModeSemaine";
			this.Size = new System.Drawing.Size(344, 304);
			this.Load += new System.EventHandler(this.CControlAgendaModeSemaine_Load);
			this.SizeChanged += new System.EventHandler(this.CControlAgendaModeSemaine_SizeChanged);
			this.m_panelEntete.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public event DemandeAffichageEntreeAgendaEventHandler OnAfficherEntreeAgenda;

		private void CControlAgendaModeSemaine_Load(object sender, System.EventArgs e)
		{
			CreateControlsJour();
		}

		/// ////////////////////////////////////////////
		public Color CouleurMoisPairs
		{
			get
			{
				return m_couleursMoisPairs;
			}
			set
			{
				m_couleursMoisPairs = value;
			}
		}

		/// ////////////////////////////////////////////
		public CFiltreData FiltreAAppliquer
		{
			set
			{
				m_filtreAAppliquer = value;
				UpdateItems();
			}
		}

		/// ////////////////////////////////////////////
		private void OnDemandeAffichageEntree ( IEntreeAgenda entree )
		{
			if ( OnAfficherEntreeAgenda != null )
				OnAfficherEntreeAgenda ( entree );
		}

		/// ////////////////////////////////////////////
		public Color CouleurMoisImpairs
		{
			get
			{
				return m_couleurMoisImpairs;
			}
			set
			{
				m_couleurMoisImpairs = value;
			}
		}

		/// ////////////////////////////////////////////
		private void CreateControlsJour()
		{
			if ( m_listeControlsJours.Count != 0 )
				return;
            this.SuspendDrawing();
			Visible = false;
			int nWidth = m_panelJours.ClientRectangle.Width;
			int nHeight = m_panelJours.ClientRectangle.Height;
			int nWidthElt = nWidth / 2;
			int nHeightElement = nHeight/3;
			CControlJourAgendaModeMois jour ;
			for ( int nJour = 0; nJour < 7; nJour++ )
			{
				jour = new CControlJourAgendaModeMois(this);
				jour.AvecInitiales = m_elementsAAgenda!= null && m_elementsAAgenda.Length > 0;
				jour.ImageRoles = m_imagesRoles != null?m_imagesRoles.ImageList:null;
				jour.OnDemandeAffichageEntree += new DemandeAffichageEntreeAgendaEventHandler(OnDemandeAffichageEntree);
				jour.OnDemandeCreationEntreeAgenda += new EventHandler(jour_OnDemandeCreationEntreeAgenda);
				jour.Parent = m_panelJours;
				jour.Left = (nJour/3) * (nWidthElt-1);
				jour.Top = (nJour%3) * (nHeightElement-1);
				if ( nJour == 6 )
				{
					jour.Top = (nHeightElement-1)*2+nHeightElement/2;
					jour.Left = (nWidthElt-1);
				}
				jour.Width = nWidthElt;
				jour.Height = nHeightElement;
				if ( nJour >= 5 )
					jour.Height = nHeightElement/2;
				jour.Visible = true;
				jour.CreateControl();
				jour.Enter += new EventHandler(jour_Enter);
				jour.ModeSemaine = true;
				m_listeControlsJours.Add ( jour );
			}
			m_scrollBar.Left = m_panelJours.Left + 7*(nWidthElt-1);
			m_scrollBar.Top = m_panelJours.Top;
			m_scrollBar.Height = 5*(nHeightElement-1);
			SetSemaineEnCours ( CUtilDate.GetWeekNum(DateTime.Now), CUtilDate.GetYearOfWeek(DateTime.Now) );
			DateEnCours = m_dateEnCours;
			this.ResumeDrawing();
			Visible = true;
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CControlAgendaModeSemaine_SizeChanged(object sender, System.EventArgs e)
		{
			//REplace les controles
			if ( m_listeControlsJours.Count == 7 )
			{
				int nWidth = m_panelJours.ClientRectangle.Width;
				int nHeight = m_panelJours.ClientRectangle.Height;
				int nWidthElt = nWidth / 2;
				int nHeightElement = nHeight/3;
				CControlJourAgendaModeMois jour ;
				for ( int nJour = 0; nJour < 7; nJour++ )
				{
					jour = (CControlJourAgendaModeMois)m_listeControlsJours[nJour];
					jour.Left = (nJour/3) * (nWidthElt-1);
					jour.Top = (nJour%3) * (nHeightElement-1);
					if ( nJour == 6 )
					{
						jour.Top = (nHeightElement-1)*2+nHeightElement/2;
						jour.Left = (nWidthElt-1);
					}
					jour.Width = nWidthElt;
					jour.Height = nHeightElement;
					if ( nJour >= 5 )
						jour.Height = nHeightElement/2;

				}
				m_scrollBar.Left = m_panelJours.Left + 2*(nWidthElt-1);
				m_scrollBar.Top = m_panelJours.Top;
				m_scrollBar.Height = 3*(nHeightElement-1);
			}
		}

		/// <summary>
		/// Définit le mois à afficher
		/// </summary>
		/// <param name="nMois"></param>
		/// <param name="nYear"></param>
		public void SetSemaineEnCours ( int nSemaine, int nYear )
		{
			DateTime dt = CUtilDate.LundiDeSemaine ( nSemaine, nYear );
			SetDateStart ( dt );
		}

		//////////////////////////////////////////////////////
		public DateTime DateEnCours
		{
			get
			{
				return m_dateEnCours;
			}
			set
			{
				SetSemaineEnCours ( CUtilDate.GetWeekNum(value), CUtilDate.GetYearOfWeek(value) );
				m_dateEnCours = value;
				foreach ( CControlJourAgendaModeMois control in m_listeControlsJours )
					if ( control.Jour.Date == m_dateEnCours.Date )
						control.Focus();
			}
		}


		/// <summary>
		/// ////////////////////////////////////////////
		/// </summary>
		/// <param name="dt"></param>
		private void SetDateStart ( DateTime dt )
		{
			m_dtFirstCellDate = dt;
			CreateControlsJour();
			for ( int nJour = 0; nJour < 7; nJour++ )
			{
				CControlJourAgendaModeMois jour = (CControlJourAgendaModeMois)m_listeControlsJours[nJour];
				jour.SetJour ( dt );
				if ( dt.Month%2 == 0 )
					jour.CouleurFond = m_couleursMoisPairs;
				else
					jour.CouleurFond = m_couleurMoisImpairs;
				dt = dt.AddDays(1);
			}
			m_labelTitre.Text = I.T("Week |121 ")+CUtilDate.GetWeekNum(m_dtFirstCellDate).ToString().PadLeft(2,'0')+"/"+
				CUtilDate.GetYearOfWeek ( m_dtFirstCellDate ).ToString();
			m_scrollBar.Enabled = false;
			m_scrollBar.Minimum = -100;
			m_scrollBar.Value = 0;
			m_scrollBar.Maximum = 100;
			m_scrollBar.Enabled = true;
			UpdateItems();
		}

		/// ////////////////////////////////////////////
		private void m_btnPrecedent_Click(object sender, System.EventArgs e)
		{
			DateEnCours = DateEnCours.AddDays(-7);
		}

		/// ////////////////////////////////////////////
		private void m_btnSuivant_Click(object sender, System.EventArgs e)
		{
			DateEnCours = DateEnCours.AddDays(7);
		}

		/// ////////////////////////////////////////////
		private void m_scrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			if ( m_scrollBar.Enabled )
			{
				DateTime newStart = m_dtFirstCellDate;
				switch ( e.Type )
				{
					case ScrollEventType.SmallIncrement:
						newStart = newStart.AddDays(7);
						break;
					case ScrollEventType.SmallDecrement :
						newStart = newStart.AddDays(-7);
						break;
					case ScrollEventType.LargeDecrement :
						m_btnPrecedent_Click(this, new EventArgs());
						return;
					case ScrollEventType.LargeIncrement :
						m_btnSuivant_Click(this, new EventArgs() );
						return;
				}
				SetDateStart ( newStart );
			}
		}

		/// ////////////////////////////////////////////
		private void UpdateItems()
		{
			
			CreateControl();
			CListeRelationsEntreeAgenda listeEntrees = null;
			CVisuEntreeAgenda[] visus = new CVisuEntreeAgenda[0];
			if ( m_elementsAAgenda != null && m_elementsAAgenda.Length>0)
			{
				listeEntrees = new CListeRelationsEntreeAgenda ( m_elementsAAgenda[0].ContexteDonnee, m_elementsAAgenda );
				listeEntrees.Filtre = m_filtreAAppliquer;
				visus = listeEntrees.GetVisusForPeriode ( m_dtFirstCellDate, m_dtFirstCellDate.AddDays(7) );
			}
			foreach ( CControlJourAgendaModeMois ctrl in m_listeControlsJours )
			{
				ctrl.Clear();
				ctrl.AvecInitiales = m_elementsAAgenda!=null && m_elementsAAgenda.Length>1;
			}
			if ( m_elementsAAgenda == null )
				return;
			DateTime dtDebut = m_dtFirstCellDate;
			DateTime dtFin = m_dtFirstCellDate.AddDays(35);
			foreach ( CVisuEntreeAgenda visu in visus )
			{
				if ( visu.DateDebut <= dtFin ||
					visu.DateFin >= dtDebut )
				{
					TimeSpan sp = visu.DateDebut-m_dtFirstCellDate;
					int nMin = (int)Math.Max(sp.TotalDays, 0);
					sp = visu.DateFin-m_dtFirstCellDate;
					int nMax = (int)Math.Min(sp.TotalDays, 6);
					int nIdImage = -1;
					if ( m_imagesRoles != null )
						nIdImage = m_imagesRoles.GetIndexImageForRole(visu.Role);
					for ( int nDay = nMin; nDay <= nMax; nDay++ )
					{
						((CControlJourAgendaModeMois)m_listeControlsJours[nDay]).AddEntree(visu, nIdImage);
					}
				}
			}
		}

		/// ////////////////////////////////////////////
		public void SetElementAAgenda ( CObjetDonneeAIdNumerique element )
		{
			SetElementsAAgenda ( new CObjetDonneeAIdNumerique[]{element} );
		}

		/// ////////////////////////////////////////////
		public void SetElementsAAgenda ( CObjetDonneeAIdNumerique[] elements )
		{
			m_elementsAAgenda = elements;
			UpdateItems();
		}

		/// ////////////////////////////////////////////
		public void OnChangeDonnees ( )
		{
			SetElementsAAgenda ( m_elementsAAgenda );
		}

		private void m_panelJours_SizeChanged(object sender, System.EventArgs e)
		{
			//REplace les controles
			if ( m_listeControlsJours.Count == 35 )
			{
				int nWidth = m_panelJours.ClientRectangle.Width;
				int nHeight = m_panelJours.ClientRectangle.Height;
				int nWidthElt = nWidth / 7;
				int nHeightElement = nHeight/5;
				CControlJourAgendaModeMois jour ;
				for ( int nSemaine = 0; nSemaine < 5; nSemaine++ )
				{
					for ( int nJour = 0; nJour < 7; nJour++ )
					{
						jour = (CControlJourAgendaModeMois)m_listeControlsJours[nJour+nSemaine*7];
						jour.Left = nJour * (nWidthElt-1);
						jour.Top = nSemaine * (nHeightElement-1);
						jour.Width = nWidthElt;
						jour.Height = nHeightElement;
					}
				}
				m_scrollBar.Left = m_panelJours.Left + 2*(nWidthElt-1);
				m_scrollBar.Top = m_panelJours.Top;
				m_scrollBar.Height = 3*(nHeightElement-1);
			}
		}

		/// ////////////////////////////////////////////
		public CImagesForRolesAgenda ImagesRoles
		{
			get
			{
				return m_imagesRoles;
			}
			set
			{
				m_imagesRoles = value;
			}
		}

		private void jour_Enter(object sender, EventArgs e)
		{
			if ( sender is CControlJourAgendaModeMois )
				m_dateEnCours = ((CControlJourAgendaModeMois)sender).Jour;
		}

		/// ////////////////////////////////////////////
		public event EventHandler OnDemandeCreationEntreeAgenda;

		private void jour_OnDemandeCreationEntreeAgenda(object sender, EventArgs e)
		{
			if ( OnDemandeCreationEntreeAgenda != null)
				OnDemandeCreationEntreeAgenda ( this, new EventArgs() );
		}
	}
}
