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
using timos.acteurs;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CControlAgendaModeMois.
	/// </summary>
	public class CControlAgendaModeMois : System.Windows.Forms.UserControl, IControlAgenda
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private DateTime m_dateEnCours = new DateTime ( 1900,1,1 );
		private CFiltreData m_filtreAAppliquer;
		private CImagesForRolesAgenda m_imagesRoles = null;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel m_panelJours;
		private System.Windows.Forms.Panel m_panelNomsJours;

		private ArrayList m_listeControlsJours = new ArrayList();
		private ArrayList m_listeLabelsNoms = new ArrayList();
		private ArrayList m_listeLabelsSemaines = new ArrayList();

		private System.Windows.Forms.Panel m_panelNumSemaine;
		private System.Windows.Forms.Panel m_panelEntete;
		private System.Windows.Forms.Label m_labelTitre;
		private System.Windows.Forms.Button m_btnSuivant;
		private System.Windows.Forms.Button m_btnPrecedent;
		private System.Windows.Forms.VScrollBar m_scrollBar;

		private Color m_couleursMoisPairs = Color.FromArgb(240, 240, 240);
		private Color m_couleurMoisImpairs = Color.FromArgb(255,255,255);

		private CObjetDonneeAIdNumerique[] m_elementsAAgenda = new CObjetDonneeAIdNumerique[0];

		//Date de la première cellule
		private DateTime m_dtFirstCellDate = DateTime.Now;

		public CControlAgendaModeMois()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CControlAgendaModeMois));
			this.m_panelJours = new System.Windows.Forms.Panel();
			this.m_panelNomsJours = new System.Windows.Forms.Panel();
			this.m_panelNumSemaine = new System.Windows.Forms.Panel();
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
			this.m_panelJours.Location = new System.Drawing.Point(24, 40);
			this.m_panelJours.Name = "m_panelJours";
			this.m_panelJours.Size = new System.Drawing.Size(680, 424);
			this.m_panelJours.TabIndex = 0;
			this.m_panelJours.SizeChanged += new System.EventHandler(this.m_panelJours_SizeChanged);
			this.m_panelJours.Enter += new System.EventHandler(this.m_panelJours_Enter);
			// 
			// m_panelNomsJours
			// 
			this.m_panelNomsJours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelNomsJours.Location = new System.Drawing.Point(24, 24);
			this.m_panelNomsJours.Name = "m_panelNomsJours";
			this.m_panelNomsJours.Size = new System.Drawing.Size(680, 16);
			this.m_panelNomsJours.TabIndex = 1;
			this.m_panelNomsJours.SizeChanged += new System.EventHandler(this.m_panelNomsJours_SizeChanged);
			// 
			// m_panelNumSemaine
			// 
			this.m_panelNumSemaine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_panelNumSemaine.Location = new System.Drawing.Point(0, 40);
			this.m_panelNumSemaine.Name = "m_panelNumSemaine";
			this.m_panelNumSemaine.Size = new System.Drawing.Size(24, 424);
			this.m_panelNumSemaine.TabIndex = 2;
			this.m_panelNumSemaine.SizeChanged += new System.EventHandler(this.m_panelNumSemaine_SizeChanged);
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
			this.m_panelEntete.Size = new System.Drawing.Size(720, 24);
			this.m_panelEntete.TabIndex = 4;
			// 
			// m_btnSuivant
			// 
			this.m_btnSuivant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnSuivant.ForeColor = System.Drawing.Color.White;
			this.m_btnSuivant.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSuivant.Image")));
			this.m_btnSuivant.Location = new System.Drawing.Point(688, 0);
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
			this.m_btnPrecedent.Location = new System.Drawing.Point(656, 0);
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
			this.m_labelTitre.Size = new System.Drawing.Size(624, 24);
			this.m_labelTitre.TabIndex = 0;
			// 
			// m_scrollBar
			// 
			this.m_scrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_scrollBar.LargeChange = 3;
			this.m_scrollBar.Location = new System.Drawing.Point(704, 64);
			this.m_scrollBar.Maximum = 2;
			this.m_scrollBar.Name = "m_scrollBar";
			this.m_scrollBar.Size = new System.Drawing.Size(16, 232);
			this.m_scrollBar.TabIndex = 5;
			this.m_scrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_scrollBar_Scroll);
			// 
			// CControlAgendaModeMois
			// 
			this.Controls.Add(this.m_scrollBar);
			this.Controls.Add(this.m_panelEntete);
			this.Controls.Add(this.m_panelNumSemaine);
			this.Controls.Add(this.m_panelNomsJours);
			this.Controls.Add(this.m_panelJours);
			this.Name = "CControlAgendaModeMois";
			this.Size = new System.Drawing.Size(720, 464);
			this.Load += new System.EventHandler(this.CControlAgendaModeMois_Load);
			this.SizeChanged += new System.EventHandler(this.CControlAgendaModeMois_SizeChanged);
			this.m_panelEntete.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public event DemandeAffichageEntreeAgendaEventHandler OnAfficherEntreeAgenda;

		private void CControlAgendaModeMois_Load(object sender, System.EventArgs e)
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
			int nWidthElt = nWidth / 7;
			int nHeightElement = nHeight/5;
			Label labelNom;
			for ( int nSemaine = 0; nSemaine < 5; nSemaine++ )
			{
				Label labelSemaine = new Label();
				labelSemaine.Parent = m_panelNumSemaine;
				labelSemaine.Width = m_panelNumSemaine.Width;
				labelSemaine.Height = nHeightElement;
				labelSemaine.Left = 0;
				labelSemaine.Top = nSemaine * (nHeightElement-1);
				labelSemaine.TextAlign = ContentAlignment.MiddleCenter;
				labelSemaine.Visible = true;
				labelSemaine.CreateControl();
				
				m_listeLabelsSemaines.Add ( labelSemaine );

				CControlJourAgendaModeMois jour ;
				for ( int nJour = 0; nJour < 7; nJour++ )
				{
					jour = new CControlJourAgendaModeMois(this);
					jour.AvecInitiales = m_elementsAAgenda!= null && m_elementsAAgenda.Length > 0;
					jour.ImageRoles = m_imagesRoles != null?m_imagesRoles.ImageList:null;
					jour.OnDemandeAffichageEntree += new DemandeAffichageEntreeAgendaEventHandler(OnDemandeAffichageEntree);
					jour.Parent = m_panelJours;
					jour.Left = nJour * (nWidthElt-1);
					jour.Top = nSemaine * (nHeightElement-1);
					jour.Width = nWidthElt;
					jour.Height = nHeightElement;
					jour.Visible = true;
					jour.CreateControl();
					jour.Enter += new EventHandler(jour_Enter);
					jour.OnDemandeCreationEntreeAgenda +=new EventHandler(jour_OnDemandeCreationEntreeAgenda);
					m_listeControlsJours.Add ( jour );

					if ( nSemaine == 0 )
					{
						labelNom = new Label();
						labelNom.Parent = m_panelNomsJours;
						labelNom.Height = m_panelNomsJours.ClientRectangle.Height;
						labelNom.Width = nWidthElt;
						labelNom.Top = 0;
						labelNom.Left = nJour * nWidthElt;
						labelNom.Visible = true;
						labelNom.TextAlign = ContentAlignment.TopCenter;
						labelNom.CreateControl();
						switch ( nJour )
						{
							case 0 :
								labelNom.Text = I.T("Monday|30023");
								break;
							case 1 :
                                labelNom.Text = I.T("Thursday|30024");
								break;
							case 2 :
                                labelNom.Text = I.T("Wednesday|30025");
								break;
							case 3 :
                                labelNom.Text = I.T("Thursday|30026");
								break;
							case 4 :
                                labelNom.Text = I.T("Friday|30027");
								break;
							case 5 :
                                labelNom.Text = I.T("Saturday|30028");
								break;
							case 6 :
                                labelNom.Text = I.T("Sunday|30029");
								break;
						}
						m_listeLabelsNoms.Add ( labelNom );
					}
				}
				m_scrollBar.Left = m_panelJours.Left + 7*(nWidthElt-1)+1;
				m_scrollBar.Top = m_panelJours.Top;
				m_scrollBar.Height = 5*(nHeightElement-1);
			}
			SetMoisEnCours ( DateTime.Now.Month, 2003);
			this.ResumeDrawing();
			Visible = true;
			DateEnCours = m_dateEnCours;
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CControlAgendaModeMois_SizeChanged(object sender, System.EventArgs e)
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
					Label labelSemaine = (Label)m_listeLabelsSemaines[nSemaine];
					labelSemaine.Width = m_panelNumSemaine.Width;
					labelSemaine.Height = nHeightElement;
					labelSemaine.Left = 0;
					labelSemaine.Top = nSemaine * (nHeightElement-1);
			
					m_listeLabelsSemaines.Add ( labelSemaine );

					for ( int nJour = 0; nJour < 7; nJour++ )
					{
						jour = (CControlJourAgendaModeMois)m_listeControlsJours[nJour+nSemaine*7];
						jour.Left = nJour * (nWidthElt-1);
						jour.Top = nSemaine * (nHeightElement-1);
						jour.Width = nWidthElt;
						jour.Height = nHeightElement;

						if ( nSemaine == 0 )
						{
							Label labelNom = (Label)m_listeLabelsNoms[nJour];
							labelNom.Height = m_panelNomsJours.ClientRectangle.Height;
							labelNom.Width = nWidthElt;
							labelNom.Top = 0;
							labelNom.Left = nJour * nWidthElt;
						}

					}
				}
				m_scrollBar.Left = m_panelJours.Left + 7*(nWidthElt-1);
				m_scrollBar.Top = m_panelJours.Top;
				m_scrollBar.Height = 5*(nHeightElement-1);
			}
		}

		/// <summary>
		/// Définit le mois à afficher
		/// </summary>
		/// <param name="nMois"></param>
		/// <param name="nYear"></param>
		public void SetMoisEnCours ( int nMois, int nYear )
		{
			DateTime dt = new DateTime ( nYear, nMois, 1);
			int nDay = ((int)dt.DayOfWeek-1)%7;
			dt = dt.AddDays(-nDay);
			SetDateStart ( dt );
		}

		/// ////////////////////////////////////////////
		public DateTime DateEnCours
		{
			get
			{
				return m_dateEnCours;
			}
			set
			{
				if ( value != m_dateEnCours )
				{
					//Si la date en cours n'est pas visible, affiche le mois de la date en cours
					if ( value < m_dtFirstCellDate.Date || value >= m_dtFirstCellDate.AddDays(35).Date )
						SetMoisEnCours ( value.Month, value.Year );
					m_dateEnCours = value;
				}
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
			bool bOnlyOnMonth = false;
			int nMonthAvec1 = dt.Month;
			int nYearAvec1= dt.Year;
			for ( int nJour = 0; nJour < 35; nJour++ )
			{
				if ( (nJour % 7) == 0 )
				{
					Label labelSemaine = (Label)m_listeLabelsSemaines[(int)(nJour/7)];
					labelSemaine.Text = CUtilDate.GetWeekNum(dt).ToString();
				}
				CControlJourAgendaModeMois jour = (CControlJourAgendaModeMois)m_listeControlsJours[nJour];
				if ( dt.Day == 1  && nJour < 7 )
				{
					bOnlyOnMonth = true;
					nMonthAvec1 = dt.Month;
					nYearAvec1 = dt.Year;
				}
				jour.SetJour ( dt );
				//jour.SetCalendrier ( m_calendrierAssocie );
				if ( dt.Month%2 == 0 )
					jour.CouleurFond = m_couleursMoisPairs;
				else
					jour.CouleurFond = m_couleurMoisImpairs;
				if ( dt == m_dateEnCours )
					jour.Focus();
				dt = dt.AddDays(1);
			}
			if ( bOnlyOnMonth )
				m_labelTitre.Text = CUtilDate.GetNomMois(nMonthAvec1, false)+" "+nYearAvec1.ToString();
			else
			{
				m_labelTitre.Text = CUtilDate.GetNomMois (m_dtFirstCellDate.Month, false)+" ";
				if ( m_dtFirstCellDate.Year !=  m_dtFirstCellDate.AddDays(35).Year )
					m_labelTitre.Text += m_dtFirstCellDate.Year.ToString()+" ";
				m_labelTitre.Text += "- ";
				m_labelTitre.Text += CUtilDate.GetNomMois(m_dtFirstCellDate.AddDays(35).Month, false)+" ";
				m_labelTitre.Text += m_dtFirstCellDate.AddDays(35).Year.ToString()+" ";
				
				
			}
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
			SetDateStart ( m_dtFirstCellDate.AddDays(-35));
			DateEnCours = m_dateEnCours.AddMonths(-1);
		}

		/// ////////////////////////////////////////////
		private void m_btnSuivant_Click(object sender, System.EventArgs e)
		{
			SetDateStart ( m_dtFirstCellDate.AddDays(35));
			DateEnCours = m_dateEnCours.AddMonths(1);
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
			if ( m_elementsAAgenda != null && m_elementsAAgenda.Length > 0 )
			{
				listeEntrees = new CListeRelationsEntreeAgenda ( m_elementsAAgenda[0].ContexteDonnee, m_elementsAAgenda );
				listeEntrees.Filtre = m_filtreAAppliquer;
				visus = listeEntrees.GetVisusForPeriode ( m_dtFirstCellDate, m_dtFirstCellDate.AddDays(35) );
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
					int nMax = (int)Math.Min(sp.TotalDays, 34);
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
				m_scrollBar.Left = m_panelJours.Left + 7*(nWidthElt-1);
				m_scrollBar.Top = m_panelJours.Top;
				m_scrollBar.Height = 5*(nHeightElement-1);
			}
		}

		private void m_panelNomsJours_SizeChanged(object sender, System.EventArgs e)
		{
			//REplace les controles
			if ( m_listeControlsJours.Count == 35 )
			{
				int nWidth = m_panelJours.ClientRectangle.Width;
				int nHeight = m_panelJours.ClientRectangle.Height;
				int nWidthElt = nWidth / 7;
				int nHeightElement = nHeight/5;
				for ( int nJour = 0; nJour < 7; nJour++ )
				{
					Label labelNom = (Label)m_listeLabelsNoms[nJour];
					labelNom.Height = m_panelNomsJours.ClientRectangle.Height;
					labelNom.Width = nWidthElt;
					labelNom.Top = 0;
					labelNom.Left = nJour * nWidthElt;
				}
			}
			
		}

		private void m_panelNumSemaine_SizeChanged(object sender, System.EventArgs e)
		{
			//REplace les controles
			if ( m_listeControlsJours.Count == 35 )
			{
				int nWidth = m_panelJours.ClientRectangle.Width;
				int nHeight = m_panelJours.ClientRectangle.Height;
				int nWidthElt = nWidth / 7;
				int nHeightElement = nHeight/5;
				for ( int nSemaine = 0; nSemaine < 5; nSemaine++ )
				{
					Label labelSemaine = (Label)m_listeLabelsSemaines[nSemaine];
					labelSemaine.Width = m_panelNumSemaine.Width;
					labelSemaine.Height = nHeightElement;
					labelSemaine.Left = 0;
					labelSemaine.Top = nSemaine * (nHeightElement-1);
				}			
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

		/// ////////////////////////////////////////////
		private void jour_Enter(object sender, EventArgs e)
		{
			if ( sender is CControlJourAgendaModeMois  )
				m_dateEnCours = ((CControlJourAgendaModeMois)sender).Jour;
		}

		private void m_panelJours_Enter(object sender, System.EventArgs e)
		{
			
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
