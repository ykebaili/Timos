using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using sc2i.common;


namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelCalendrierAnnee.
	/// </summary>
	public class CPanelCalendrierAnnee : System.Windows.Forms.UserControl
	{
		private CJourStyle m_defaultStyle = new CJourStyle ( Color.Black, Color.White );

		//Jour de semaine ( DayOfWeek ->CJourStyle )
		private Hashtable m_tableStylesParSemaine = new Hashtable();
		
		//Jour du mois->CjourStyle
		private Hashtable m_tableStylesParMois = new Hashtable();

		//Jour du mois+ 32*Numero de mois->CjourStyle
		private Hashtable m_tableStylesParAn = new Hashtable();

		private Hashtable m_tableStylesParJour = new Hashtable();

		//Jour->rectangle
		private Hashtable m_tableJourToRectangle = new Hashtable();

		private Bitmap m_bitmap = null;

		/*Priorité : 
		 * le style affiché est dans l'ordre de priorité suivant : 
		 * Jour précis
		 * Jour de l'année
		 * Jour du mois
		 * Jour de la semaine
		 */ 

		private DateTime m_selectedDate = DateTime.Now;
        private DateTime m_lastSelectedDate = DateTime.Now;
        private List<DateTime> m_lstSelectionDates = new List<DateTime>();
        
		
		private int m_nAnnee;
		private int m_nNbColonnes = 3;
		private const int c_champLargeurMois = 70;
		private const int c_champHauteurMois = 35;
		private const int c_champHauteurEnteteMois = 10;
		private System.Windows.Forms.Label m_labelModeleEntete;
		private System.Windows.Forms.Label m_labelModeleJour;
		private System.Windows.Forms.Panel m_panelCalendrier;
		private System.Windows.Forms.Button m_btnAnneePrecedente;
		private System.Windows.Forms.Button m_btnAnneeSuivante;
		private System.Windows.Forms.Label m_lblAnnee;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelCalendrierAnnee()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
			m_nAnnee = DateTime.Now.Year;
            m_lstSelectionDates.Add(DateTime.Now);

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
            this.m_labelModeleEntete = new System.Windows.Forms.Label();
            this.m_labelModeleJour = new System.Windows.Forms.Label();
            this.m_panelCalendrier = new System.Windows.Forms.Panel();
            this.m_lblAnnee = new System.Windows.Forms.Label();
            this.m_btnAnneePrecedente = new System.Windows.Forms.Button();
            this.m_btnAnneeSuivante = new System.Windows.Forms.Button();
            this.m_panelCalendrier.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelModeleEntete
            // 
            this.m_labelModeleEntete.BackColor = System.Drawing.Color.DarkGreen;
            this.m_labelModeleEntete.ForeColor = System.Drawing.Color.White;
            this.m_labelModeleEntete.Location = new System.Drawing.Point(112, 216);
            this.m_labelModeleEntete.Name = "m_labelModeleEntete";
            this.m_labelModeleEntete.Size = new System.Drawing.Size(88, 16);
            this.m_labelModeleEntete.TabIndex = 2;
            this.m_labelModeleEntete.Text = "January|30092";
            this.m_labelModeleEntete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_labelModeleEntete.Visible = false;
            // 
            // m_labelModeleJour
            // 
            this.m_labelModeleJour.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelModeleJour.Location = new System.Drawing.Point(32, 224);
            this.m_labelModeleJour.Name = "m_labelModeleJour";
            this.m_labelModeleJour.Size = new System.Drawing.Size(12, 12);
            this.m_labelModeleJour.TabIndex = 3;
            this.m_labelModeleJour.Text = "31";
            this.m_labelModeleJour.Visible = false;
            // 
            // m_panelCalendrier
            // 
            this.m_panelCalendrier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelCalendrier.Controls.Add(this.m_labelModeleJour);
            this.m_panelCalendrier.Controls.Add(this.m_labelModeleEntete);
            this.m_panelCalendrier.Location = new System.Drawing.Point(0, 16);
            this.m_panelCalendrier.Name = "m_panelCalendrier";
            this.m_panelCalendrier.Size = new System.Drawing.Size(318, 270);
            this.m_panelCalendrier.TabIndex = 4;
            this.m_panelCalendrier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_panelCalendrier_MouseDown);
            this.m_panelCalendrier.Resize += new System.EventHandler(this.m_panelCalendrier_Resize);
            this.m_panelCalendrier.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelCalendrier_Paint);
            // 
            // m_lblAnnee
            // 
            this.m_lblAnnee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAnnee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblAnnee.Location = new System.Drawing.Point(16, 0);
            this.m_lblAnnee.Name = "m_lblAnnee";
            this.m_lblAnnee.Size = new System.Drawing.Size(286, 16);
            this.m_lblAnnee.TabIndex = 4;
            this.m_lblAnnee.Text = "2004";
            this.m_lblAnnee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnAnneePrecedente
            // 
            this.m_btnAnneePrecedente.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnAnneePrecedente.Location = new System.Drawing.Point(0, 0);
            this.m_btnAnneePrecedente.Name = "m_btnAnneePrecedente";
            this.m_btnAnneePrecedente.Size = new System.Drawing.Size(16, 16);
            this.m_btnAnneePrecedente.TabIndex = 4;
            this.m_btnAnneePrecedente.Text = "<";
            this.m_btnAnneePrecedente.UseVisualStyleBackColor = false;
            this.m_btnAnneePrecedente.Click += new System.EventHandler(this.m_btnAnneePrecedente_Click);
            // 
            // m_btnAnneeSuivante
            // 
            this.m_btnAnneeSuivante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAnneeSuivante.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnAnneeSuivante.Location = new System.Drawing.Point(302, 0);
            this.m_btnAnneeSuivante.Name = "m_btnAnneeSuivante";
            this.m_btnAnneeSuivante.Size = new System.Drawing.Size(16, 16);
            this.m_btnAnneeSuivante.TabIndex = 5;
            this.m_btnAnneeSuivante.Text = ">";
            this.m_btnAnneeSuivante.UseVisualStyleBackColor = false;
            this.m_btnAnneeSuivante.Click += new System.EventHandler(this.m_btnAnneeSuivante_Click);
            // 
            // CPanelCalendrierAnnee
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_btnAnneeSuivante);
            this.Controls.Add(this.m_panelCalendrier);
            this.Controls.Add(this.m_lblAnnee);
            this.Controls.Add(this.m_btnAnneePrecedente);
            this.Name = "CPanelCalendrierAnnee";
            this.Size = new System.Drawing.Size(318, 286);
            this.Load += new System.EventHandler(this.CPanelCalendrierAnnee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CPanelCalendrierAnnee_Paint);
            this.m_panelCalendrier.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void CPanelCalendrierAnnee_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void m_panelCalendrier_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			RedrawCalendrier( e.Graphics );
		}

		private void ShowSelection()
		{
			Graphics g = m_panelCalendrier.CreateGraphics();
			if ( m_bitmap == null )
				RedrawCalendrier ( g );
			g.DrawImage ( m_bitmap, 0, 0 );

            Pen pen = new Pen(Color.Red, 2);
			Pen p2 = new Pen(Color.Black, 2);

            foreach (DateTime date in m_lstSelectionDates)
            {
                object obj = m_tableJourToRectangle[date];
                if (obj != null)
                {
                    Rectangle rect = (Rectangle)obj;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    g.DrawEllipse(p2, rect);
					rect.Offset(1,1);
					g.DrawEllipse(pen, rect);
                }

            }
            pen.Dispose();
			p2.Dispose();
            g.Dispose();
		}

		private void HideSelection()
		{
			Graphics g = m_panelCalendrier.CreateGraphics();
			if ( m_bitmap == null )
				RedrawCalendrier ( g );
			g.DrawImage ( m_bitmap, 0, 0 );
			g.Dispose();
		}

		private void RedrawCalendrier ( Graphics gToDraw )
		{
			//Dessin dans un bitamp
			if ( m_bitmap != null )
				m_bitmap.Dispose();
			m_bitmap = new Bitmap(m_panelCalendrier.Width, m_panelCalendrier.Height );

			m_tableJourToRectangle.Clear();

			Graphics g = Graphics.FromImage ( m_bitmap );
			
			g.FillRectangle ( Brushes.White, ClientRectangle );
            string[] mois = new string[]{I.T("January|30092"),I.T("February|30093"),I.T("March|30094"),I.T("April|30095"),
										I.T("May|30096"),I.T("June|30097"),I.T("July|30098"),I.T("August|30099"),I.T("September|30100"),
                                    I.T("October|30101"),I.T("November|30102"),I.T("December|30103")};
			/*int nLargeurMois = m_labelModeleEntete.Width;
			int nLargeurJour = m_labelModeleJour.Width;
			int nHauteurJour = m_labelModeleJour.Height;
			int nHauteurTotaleMois = m_labelModeleEntete.Height+m_labelModeleJour.Height*6;*/
			int nNbLignes = (int)(12/m_nNbColonnes+0.99999);
			int nLargeurMois = Math.Max(1,m_panelCalendrier.Width/m_nNbColonnes);
			int nLargeurJour = Math.Max(1,nLargeurMois/7);
			int nHauteurTotaleMois = Math.Max(1, m_panelCalendrier.Height/nNbLignes);
			int nHauteurJour = Math.Max(1, (nHauteurTotaleMois - m_labelModeleEntete.Height)/6);
			for ( int nMois = 0; nMois < 12; nMois++ )
			{
				int nX = (nMois % m_nNbColonnes)*nLargeurMois;
				int nY = (int)(nMois/m_nNbColonnes)*nHauteurTotaleMois;
				Rectangle rectTotal = new Rectangle ( nX, nY, nLargeurMois, nHauteurTotaleMois );
				Rectangle rectEntete = new Rectangle(nX, nY, nLargeurMois, m_labelModeleEntete.Height);
				g.FillRectangle ( Brushes.DarkGreen,  rectEntete );
				StringFormat format = new StringFormat (StringFormatFlags.NoWrap);
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;
				g.DrawString ( mois[nMois], m_labelModeleEntete.Font, Brushes.White,
					rectEntete, format );
				DateTime dt = new DateTime ( m_nAnnee, nMois+1, 1 );
				
				int nXJour;
				nY += m_labelModeleEntete.Height;
				while ( dt.Month-1 == nMois )
				{
					int nDay = (int)dt.DayOfWeek;
					nDay = (nDay+6)%7;
					nXJour = nDay * nLargeurJour;
					if ( nDay == 0 && dt.Day != 1 )
						nY += nHauteurJour;
					//Récupère le style pour le jour
					CJourStyle style = m_defaultStyle;
					object obj = m_tableStylesParJour[dt];
					if ( obj == null )
						obj = m_tableStylesParAn[dt.Month*32+dt.Day];
					if ( obj == null )
						obj = m_tableStylesParMois[dt.Day];
					if ( obj == null )
						obj = m_tableStylesParSemaine[dt.DayOfWeek];
					if ( obj != null )
						style = (CJourStyle)obj;
					Rectangle rect = new Rectangle (nX+nXJour, nY, nLargeurJour+1, nHauteurJour+1);
					Brush br = new SolidBrush ( style.CouleurFond );
					g.FillRectangle ( br, rect );
					br.Dispose();
					br = new SolidBrush ( style.CouleurTexte );
					g.DrawString ( dt.Day.ToString(), m_labelModeleJour.Font, br, rect, format );
					br.Dispose();
					m_tableJourToRectangle[dt] = rect;



					dt = dt.AddDays(1);
				}
				g.DrawRectangle(Pens.Black, rectTotal );
			}
			gToDraw.DrawImage ( m_bitmap, 0, 0 );
			g.Dispose();
			ShowSelection();
		}

		private void m_panelCalendrier_Resize(object sender, System.EventArgs e)
		{
			m_panelCalendrier.Refresh();
		}

		public int Colonnes
		{
			get
			{
				return m_nNbColonnes;
			}
			set
			{
				if ( value < 12 && value > 0 )
				{
					m_nNbColonnes = value;
					Refresh();
				}
			}
		}

		public CJourStyle DefaultStyle 
		{
			get
			{
				return m_defaultStyle;
			}
			set
			{
				m_defaultStyle = value;
			}
		}

		public void SetStyleJour ( DateTime jour, CJourStyle style )
		{
			m_tableStylesParJour[jour] = style;
		}

		public void SetStyleJourSemaine ( DayOfWeek jour, CJourStyle style )
		{
			m_tableStylesParSemaine[jour] = style;
		}

		public void SetStyleJourMois ( int nJour, CJourStyle style )
		{
			m_tableStylesParMois[nJour] = style;
		}

		public void SetStyleJourAn ( int nJour, int nMois, CJourStyle style )
		{
			m_tableStylesParAn[nMois*32+nJour] = style;
		}

		private void CPanelCalendrierAnnee_Load(object sender, System.EventArgs e)
		{
			m_lblAnnee.Text = m_nAnnee.ToString();
		}

		public void ResetStyles()
		{
			m_tableStylesParAn.Clear();
			m_tableStylesParJour.Clear();
			m_tableStylesParMois.Clear();
			m_tableStylesParSemaine.Clear();
		}

		private void m_btnAnneePrecedente_Click(object sender, System.EventArgs e)
		{
			m_nAnnee--;
			if ( m_nAnnee < DateTime.MinValue.Year )
				m_nAnnee = DateTime.MinValue.Year;
			m_lblAnnee.Text = m_nAnnee.ToString();
			Refresh();
		}

		private void m_btnAnneeSuivante_Click(object sender, System.EventArgs e)
		{
			m_nAnnee++;
			if ( m_nAnnee > DateTime.MaxValue.Year )
				m_nAnnee = DateTime.MaxValue.Year;
			m_lblAnnee.Text = m_nAnnee.ToString();
			Refresh();
		}

		public event EventHandler OnSelectedDateChanged;

        //private void m_panelCalendrier_Click(object sender, System.EventArgs e)
        //{
        //    m_panelCalendrier.Focus();
        //    DateTime dt = DateTime.Now;
        //    if (GetDateTimeFromPoint(m_panelCalendrier.PointToClient(Cursor.Position), ref dt))
        //        if (dt != m_selectedDate)
        //        {
        //            HideSelection();
        //            m_selectedDate = dt;
        //            ShowSelection();
        //            if (OnSelectedDateChanged != null)
        //                OnSelectedDateChanged(this, new EventArgs());
        //        }
        //}

		public DateTime DateSelectionnee
		{
			get
			{
				return m_selectedDate;
			}
			set
			{
				m_selectedDate = value;
				Refresh();
			}
		}

        public List<DateTime> DatesSelectionneesListe
        {
            get
            {
                return m_lstSelectionDates;
            }
        }

		private bool GetDateTimeFromPoint ( Point ptScreen, ref DateTime date )
		{
			foreach ( DictionaryEntry entry in m_tableJourToRectangle )
			{
				Rectangle rect = (Rectangle)entry.Value;
				if ( rect.Contains ( ptScreen ) )
				{
					date = (DateTime)entry.Key;
					return true;
				}
			}
			return false;
		}

		public override void Refresh()
		{
			Graphics g = m_panelCalendrier.CreateGraphics();
			RedrawCalendrier ( g );
			g.Dispose();
		}

        private void m_panelCalendrier_MouseDown(object sender, MouseEventArgs e)
        {
            m_panelCalendrier.Focus();
            if ((ModifierKeys & Keys.Control) != Keys.Control)
            {
                // Vider la sélection
                m_lstSelectionDates.Clear();
            }
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                // Ajoute du dernier au nouveau
                DateTime dt = DateTime.Now;
                if (GetDateTimeFromPoint(m_panelCalendrier.PointToClient(Cursor.Position), ref dt))
                {
                    HideSelection();
                    m_lstSelectionDates.Add(dt);
                    if (dt != m_lastSelectedDate)
                    {
                        int sens = dt < m_lastSelectedDate ? -1 : 1;
                        for (DateTime date = m_lastSelectedDate; date != dt; date = date.AddDays(sens))
                        {
                            m_lstSelectionDates.Add(date);
                        }
                    }
                    ShowSelection();
                    
                    if (OnSelectedDateChanged != null)
                        OnSelectedDateChanged(this, new EventArgs());
                }
            }
            else
            {
                DateTime dt = DateTime.Now;
                if (GetDateTimeFromPoint(m_panelCalendrier.PointToClient(Cursor.Position), ref dt))
                    // Ajoute nouveau
                    if (!m_lstSelectionDates.Contains(dt))
                    {
                        HideSelection();
                        m_lstSelectionDates.Add(dt);
                        ShowSelection();
                        if (OnSelectedDateChanged != null)
                            OnSelectedDateChanged(this, new EventArgs());
                    }
                    // Supprime nouveau
                    else
                    {
                        HideSelection();
                        m_lstSelectionDates.Remove(dt);
                        ShowSelection();
                        if (OnSelectedDateChanged != null)
                            OnSelectedDateChanged(this, new EventArgs());
                    }

                // Dernier = nouveau
                m_lastSelectedDate = dt;
            }
        }

	}

	public class CJourStyle
	{
		public Color CouleurFond = Color.White;
		public Color CouleurTexte = Color.Black;

		public CJourStyle  ( Color couleurText, Color couleurFond )
		{
			CouleurFond = couleurFond;
			CouleurTexte = couleurText;
		}
	}
}
