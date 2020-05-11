using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.common;
using sc2i.win32.data;
using timos.data;
using sc2i.common;
using timos.acteurs;

namespace timos
{
	/// <summary>
	/// Description résumée de CControleSaisieDesActivitesActeur.
	/// </summary>
	public class CControleSaisieDesActivitesActeur : System.Windows.Forms.UserControl, IControlALockEdition
	{
		
		private static ArrayList m_listeDerniersActeurs = new ArrayList();


		private ArrayList m_listeControlsUtiles = new ArrayList();
		private ArrayList m_listeControlesReserve = new ArrayList();

		private CActeur m_acteur = null;
		private sc2i.win32.common.C2iPanel m_panelControles;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private Label lbl_startinter;
		
		private C2iDateTimePicker m_dtDebutIntervention;
		private C2iDateTimePicker m_dtFinIntervention;
		private Label label2;
		private PictureBox pictureBox1;
		private Panel m_panelEntete;
		private LinkLabel m_lnkAppliquer;
		private System.ComponentModel.IContainer components;

		public CControleSaisieDesActivitesActeur()
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
				m_listeControlsUtiles.Clear();
				m_listeControlesReserve.Clear();
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
			this.m_panelControles = new sc2i.win32.common.C2iPanel(this.components);
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.lbl_startinter = new System.Windows.Forms.Label();
			this.m_dtDebutIntervention = new sc2i.win32.common.C2iDateTimePicker();
			this.m_dtFinIntervention = new sc2i.win32.common.C2iDateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_panelEntete = new System.Windows.Forms.Panel();
			this.m_lnkAppliquer = new System.Windows.Forms.LinkLabel();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.m_panelEntete.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelControles
			// 
			this.m_panelControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelControles.AutoScroll = true;
			this.m_panelControles.Location = new System.Drawing.Point(0, 42);
			this.m_panelControles.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelControles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelControles.Name = "m_panelControles";
			this.m_panelControles.Size = new System.Drawing.Size(491, 150);
			this.m_panelControles.TabIndex = 0;
			// 
			// lbl_startinter
			// 
			this.lbl_startinter.Location = new System.Drawing.Point(3, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_startinter, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_startinter.Name = "lbl_startinter";
			this.lbl_startinter.Size = new System.Drawing.Size(132, 16);
			this.lbl_startinter.TabIndex = 3;
			this.lbl_startinter.Text = "Beginning of intervention|543";
			// 
			// m_dtDebutIntervention
			// 
			this.m_dtDebutIntervention.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dtDebutIntervention.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dtDebutIntervention.Location = new System.Drawing.Point(135, 0);
			this.m_dtDebutIntervention.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebutIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_dtDebutIntervention.Name = "m_dtDebutIntervention";
			this.m_dtDebutIntervention.Size = new System.Drawing.Size(132, 20);
			this.m_dtDebutIntervention.TabIndex = 4;
			this.m_dtDebutIntervention.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
			this.m_dtDebutIntervention.ValueChanged += new System.EventHandler(this.m_dtDebutIntervention_ValueChanged);
			// 
			// m_dtFinIntervention
			// 
			this.m_dtFinIntervention.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dtFinIntervention.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dtFinIntervention.Location = new System.Drawing.Point(135, 19);
			this.m_dtFinIntervention.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFinIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_dtFinIntervention.Name = "m_dtFinIntervention";
			this.m_dtFinIntervention.Size = new System.Drawing.Size(132, 20);
			this.m_dtFinIntervention.TabIndex = 6;
			this.m_dtFinIntervention.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
			this.m_dtFinIntervention.ValueChanged += new System.EventHandler(this.m_dtFinIntervention_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 23);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "End of intervention|544";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(3, 193);
			this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(485, 1);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// m_panelEntete
			// 
			this.m_panelEntete.Controls.Add(this.m_lnkAppliquer);
			this.m_panelEntete.Controls.Add(this.lbl_startinter);
			this.m_panelEntete.Controls.Add(this.m_dtFinIntervention);
			this.m_panelEntete.Controls.Add(this.label2);
			this.m_panelEntete.Controls.Add(this.m_dtDebutIntervention);
			this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelEntete.Name = "m_panelEntete";
			this.m_panelEntete.Size = new System.Drawing.Size(491, 42);
			this.m_panelEntete.TabIndex = 8;
			// 
			// m_lnkAppliquer
			// 
			this.m_lnkAppliquer.Location = new System.Drawing.Point(283, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAppliquer, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lnkAppliquer.Name = "m_lnkAppliquer";
			this.m_lnkAppliquer.Size = new System.Drawing.Size(200, 13);
			this.m_lnkAppliquer.TabIndex = 7;
			this.m_lnkAppliquer.TabStop = true;
			this.m_lnkAppliquer.Text = "Apply dates|545";
			this.m_lnkAppliquer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAppliquer_LinkClicked);
			// 
			// CControleSaisieDesActivitesActeur
			// 
			this.Controls.Add(this.m_panelEntete);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_panelControles);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CControleSaisieDesActivitesActeur";
			this.Size = new System.Drawing.Size(491, 195);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.m_panelEntete.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        private bool m_bIsFilling = false;
		public void Init( CActeur acteur, DateTime dateDebut, DateTime dateFin )
		{
            CWin32Traducteur.Translate(this);
            m_bIsFilling = true;
			m_panelControles.SuspendDrawing();
			m_acteur = acteur;
			foreach ( Control ctrl in m_listeControlsUtiles )
			{
				ctrl.Visible = false;
				((CControleSaisieUneActiviteActeur)ctrl).Activite = null;
			}

			///Préinitialise avec les valeurs planifiées
			///comme ça, quand on clique sur check, la date est préinitialisée
			m_dtDebutIntervention.Value = dateDebut;
			m_dtFinIntervention.Value = dateFin;

			TimeSpan sp = m_dtFinIntervention.Value - m_dtDebutIntervention.Value;
			if (sp.TotalDays > 31)
			{
				CFormAlerte.Afficher(I.T("Display limited to 31 days|30189"), EFormAlerteType.Exclamation);
				m_dtFinIntervention.Value = m_dtDebutIntervention.Value.AddDays(31);
			}

			m_listeControlesReserve.AddRange ( m_listeControlsUtiles );
			m_listeControlsUtiles.Clear();
			CListeObjetsDonnees liste = acteur.Activites;
			liste.Filtre = new CFiltreData(
				CActiviteActeur.c_champDate + ">= @1 and " +
				CActiviteActeur.c_champDate + " < @2",
				m_dtDebutIntervention.Value.Date,
				m_dtFinIntervention.Value.Date.AddDays(1).AddMinutes(-1));
			if ( m_gestionnaireModeEdition.ModeEdition )
				liste.PreserveChanges = true;
			int nIndex = 0;
			foreach ( CActiviteActeur activite in liste )
			{
				AddActivite ( activite, ref nIndex , false );
			}
			if ( m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition )
			{
				CControleSaisieUneActiviteActeur ctrl = GetNewControle ( 0 );
				ctrl.InitControle ( null, 0, true );
			}
			ReordonneeTout();
            m_bIsFilling = false;
			//RecalcSize();

			m_panelControles.ResumeDrawing();
			Visible = true;
		}
		
		//-----------------------------------------
		private void RecalcSize()
		{
            if (Dock == DockStyle.Fill)
                return;
            if (m_bIsFilling)
                return;
            int nHeight = 0;
            nHeight = m_panelEntete.Height + 4;
            foreach (Control ctrl in m_listeControlsUtiles)
                nHeight += ctrl.Height;
            if (Math.Abs(nHeight - Height) > 5)
                Height = nHeight;
		}
		

		//-----------------------------------------
		public CActeur Acteur
		{
			get
			{
				return m_acteur;
			}
		}

		//-----------------------------------------
		public CResultAErreur Maj_Champs()
		{
			CResultAErreur result = CResultAErreur.True;

			if (Acteur == null)
				return result;

			if ( !m_listeDerniersActeurs.Contains ( Acteur.Id ) )
				m_listeDerniersActeurs.Add ( Acteur.Id );

			Hashtable tableNiveauToParent = new Hashtable();
			foreach ( CControleSaisieUneActiviteActeur control in m_listeControlsUtiles )
			{
				result = control.Maj_Champs();
				if ( !result )
					return result;
				CActiviteActeur donnee = control.Activite;
			}
			return result;
		}

		//-----------------------------------------
		private CControleSaisieUneActiviteActeur GetNewControle ( int nIndex )
		{
			CControleSaisieUneActiviteActeur ctrl = null;
			if ( m_listeControlesReserve.Count == 0 )
			{
				ctrl = new CControleSaisieUneActiviteActeur ( this );
			}
			else
			{
				ctrl = (CControleSaisieUneActiviteActeur)m_listeControlesReserve[0];
				ctrl.Activite =  null;
			}
			
			ctrl.Parent = m_panelControles;
			ctrl.Visible = true;
			ctrl.Dock = DockStyle.Top;
			ctrl.TabIndex = nIndex;
			m_listeControlesReserve.Remove ( ctrl );
			if ( nIndex < m_listeControlsUtiles.Count )
				m_listeControlsUtiles.Insert ( nIndex, ctrl );
			else
				m_listeControlsUtiles.Add ( ctrl );
			//Décale tous les controles suivants
			for ( int nCtrl = nIndex+1; nCtrl < m_listeControlsUtiles.Count; nCtrl++ )
			{
				CControleSaisieUneActiviteActeur ctrlApres = (CControleSaisieUneActiviteActeur)m_listeControlsUtiles[nCtrl];
				ctrlApres.Index = nCtrl;
			}
			ReordonneeTout();
			ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			ctrl.BackColor = m_panelControles.BackColor;
			if (nIndex == 0)
				ctrl.DateActivite = m_dtDebutIntervention.Value;
			else
				ctrl.DateActivite = GetControle(nIndex - 1).DateActivite;

			ctrl.SizeChanged += new EventHandler(ctrlActivite_SizeChanged);
		
			return ctrl;
		}

		//-----------------------------------------
		private void ReordonneeTout()
		{
			foreach ( CControleSaisieUneActiviteActeur ctrl in m_listeControlsUtiles )
			{
				ctrl.BringToFront();
			}
		}

		//-----------------------------------------
		private void AddActivite ( CActiviteActeur activite, ref int nIndex, bool bRecalcSize )
		{
			bool bEntete = m_panelControles.Controls.Count == 0;
			CControleSaisieUneActiviteActeur ctrl = GetNewControle ( nIndex );
			ctrl.Visible = true;
			ctrl.InitControle ( activite, nIndex, bEntete );	
			nIndex++;
			if (bRecalcSize)
				RecalcSize();
		}

		void ctrlActivite_SizeChanged(object sender, EventArgs e)
		{
			RecalcSize();
		}

		
		//---------------------------------------------------
		private CControleSaisieUneActiviteActeur GetControle ( int nIndex )
		{
			return ( CControleSaisieUneActiviteActeur )m_listeControlsUtiles[nIndex];
		}

		//---------------------------------------------------
		public void InsertBefore ( int nIndex )
		{
			if ( !CanAddNew() )
				return;
			if ( nIndex >= m_listeControlsUtiles.Count-1 )
				return;
			CControleSaisieUneActiviteActeur ctrl = GetControle ( nIndex );
			if ( ctrl.TypeActivite == null )
				return;

			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex );
			ctrl.InitControle ( null, nIndex, false );
			ReordonneeTout();
			m_panelControles.ResumeDrawing();
			m_panelControles.Visible = false;
			m_panelControles.Visible = true;
			ctrl.Focus();
		}

		//---------------------------------------------------
		public void InsertAfter ( int nIndex )
		{
			if ( !CanAddNew() )
				return;
			CControleSaisieUneActiviteActeur ctrl = GetControle ( nIndex );
			if ( ctrl.TypeActivite == null )
				return;

			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex+1 );
			ctrl.InitControle ( null, nIndex+1, false );
			ReordonneeTout();
			m_panelControles.ResumeDrawing();
			m_panelControles.Visible = false;
			m_panelControles.Visible = true;
			ctrl.Focus();
			RecalcSize();
		}

		//---------------------------------------------------
		private bool CanAddNew()
		{
			foreach ( CControleSaisieUneActiviteActeur ctrl in m_listeControlsUtiles )
				if ( !ctrl.ControleDonnees() )
				{
					return false;
				}
			return true;
		}

		//---------------------------------------------------
		public bool RemoveActivite( CControleSaisieUneActiviteActeur controle )
		{
			CResultAErreur result = CResultAErreur.True;
			if (controle.Activite != null)
			{
				result = controle.Activite.CanDelete();
				if (!result)
				{
					CFormAlerte.Afficher(result.Erreur);
					return false;
				}
			}
			int nIndex = controle.Index;
			
			CControleSaisieUneActiviteActeur ctrlSuivant = null;
			if ( nIndex+1 < m_listeControlsUtiles.Count )
				ctrlSuivant = (CControleSaisieUneActiviteActeur)m_listeControlsUtiles[nIndex+1];
			if (controle.Activite != null)
			{
				result = controle.Activite.Delete();
				if (!result)
					return false;
			}

			m_listeControlsUtiles.Remove ( controle );
			m_listeControlesReserve.Add ( controle );
			nIndex = controle.Index;
			for ( int nChange = nIndex; nChange < m_listeControlsUtiles.Count; nChange++ )
			{
				((CControleSaisieUneActiviteActeur)m_listeControlsUtiles[nChange]).Index = nIndex;
				nIndex++;
			}
			
			controle.Activite =  null;
			controle.Hide();

			//s'il n'y a plus de contrôle, il faut en ajouter 1 !!!
			if (m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition)
			{
				CControleSaisieUneActiviteActeur ctrl = GetNewControle(0);
				ctrl.InitControle(null, 0, true);
			}
			RecalcSize();

			return true;
		}

		//---------------------------------------------------
		public bool IsDernierControle ( int nIndex )
		{
			return nIndex == m_listeControlsUtiles.Count-1;
		}

		private class CMenuItemAActeur : MenuItem
		{
			public readonly int Id;

			public CMenuItemAActeur ( int nId, string strLibelle )
			{
				this.Text = strLibelle;
				Id = nId;
			}
		}

		
		#region Membres de IControlALockEdition

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

		
		//
		public bool GoDown ( int nIndex, string strNomControle )
		{
			if ( nIndex+1 < m_listeControlsUtiles.Count )
			{
				CControleSaisieUneActiviteActeur ctrl = GetControle ( nIndex+1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		public bool GoUp ( int nIndex, string strNomControle )
		{
			if ( nIndex-1 >= 0 )
			{
				CControleSaisieUneActiviteActeur ctrl = GetControle ( nIndex-1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		private void m_lnkAppliquer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Init(m_acteur, m_dtDebutIntervention.Value, m_dtFinIntervention.Value);
		}

		public event EventHandler OnChangeDates;

		private void m_dtDebutIntervention_ValueChanged(object sender, EventArgs e)
		{
			if (OnChangeDates != null && !m_bIsFilling)
				OnChangeDates(this, new EventArgs());
		}

		private void m_dtFinIntervention_ValueChanged(object sender, EventArgs e)
		{
			if (OnChangeDates != null && !m_bIsFilling)
				OnChangeDates(this, new EventArgs());
		}

		public DateTime DateDebut
		{
			get
			{
				return m_dtDebutIntervention.Value;
			}
		}

		public DateTime DateFin
		{
			get
			{
				return m_dtFinIntervention.Value;
			}
		}

		
	}
}
