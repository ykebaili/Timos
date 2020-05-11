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
using timos.interventions.crintervention;

namespace timos
{
	/// <summary>
	/// Description résumée de CControleSaisiesOperations.
	/// </summary>
	public class CControleSaisiesOperations : System.Windows.Forms.UserControl, IControlALockEdition
	{
        private bool m_bPanelEnteteVisible = true;
		private static ArrayList m_listeDerniersfractionInterventions = new ArrayList();
		private ArrayList m_listeControlsUtiles = new ArrayList();
		private ArrayList m_listeControlesReserve = new ArrayList();

		private IElementAOperationsRealisees m_elementAOperations = null;

		private sc2i.win32.common.C2iPanel m_panelControles;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private PictureBox m_btnCopierAnalyse;
		private Label label1;
		private C2iDateTimeExPicker m_dtDebut;
		private C2iDateTimeExPicker m_dtFin;
		private Label label2;
		private PictureBox pictureBox1;
		private Panel m_panelEntete;
		private CWndSaisieHeure m_wndDuree;
		private Label label3;
        private Button m_btnTest;
		private System.ComponentModel.IContainer components;

		public CControleSaisiesOperations()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleSaisiesOperations));
            this.m_panelControles = new sc2i.win32.common.C2iPanel(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnCopierAnalyse = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtDebut = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtFin = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.m_wndDuree = new sc2i.win32.common.CWndSaisieHeure();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopierAnalyse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panelEntete.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelControles
            // 
            this.m_panelControles.AutoScroll = true;
            this.m_panelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelControles.Location = new System.Drawing.Point(0, 42);
            this.m_panelControles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelControles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelControles.Name = "m_panelControles";
            this.m_panelControles.Size = new System.Drawing.Size(708, 153);
            this.m_panelControles.TabIndex = 0;
            // 
            // m_btnCopierAnalyse
            // 
            this.m_btnCopierAnalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCopierAnalyse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCopierAnalyse.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCopierAnalyse.Image")));
            this.m_btnCopierAnalyse.Location = new System.Drawing.Point(688, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnCopierAnalyse, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnCopierAnalyse.Name = "m_btnCopierAnalyse";
            this.m_btnCopierAnalyse.Size = new System.Drawing.Size(15, 13);
            this.m_btnCopierAnalyse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_btnCopierAnalyse.TabIndex = 2;
            this.m_btnCopierAnalyse.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnCopierAnalyse, "Copier l\'analyse sous forme de test");
            this.m_btnCopierAnalyse.Click += new System.EventHandler(this.m_btnCopierAnalyse_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start date|78";
            // 
            // m_dtDebut
            // 
            this.m_dtDebut.Checked = true;
            this.m_dtDebut.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtDebut.Location = new System.Drawing.Point(135, 0);
            this.m_dtDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtDebut.Name = "m_dtDebut";
            this.m_dtDebut.Size = new System.Drawing.Size(132, 20);
            this.m_dtDebut.TabIndex = 4;
            this.m_dtDebut.TextNull = "None";
            this.m_dtDebut.Value.DateTimeValue = new System.DateTime(2012, 11, 21, 15, 43, 12, 875);
            // 
            // m_dtFin
            // 
            this.m_dtFin.Checked = true;
            this.m_dtFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtFin.Location = new System.Drawing.Point(135, 19);
            this.m_dtFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtFin.Name = "m_dtFin";
            this.m_dtFin.Size = new System.Drawing.Size(132, 20);
            this.m_dtFin.TabIndex = 6;
            this.m_dtFin.TextNull = "None";
            this.m_dtFin.Value.DateTimeValue = new System.DateTime(2012, 11, 21, 15, 43, 12, 875);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "End date|79";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(3, 193);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 1);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.m_btnTest);
            this.m_panelEntete.Controls.Add(this.m_wndDuree);
            this.m_panelEntete.Controls.Add(this.label3);
            this.m_panelEntete.Controls.Add(this.label1);
            this.m_panelEntete.Controls.Add(this.m_dtFin);
            this.m_panelEntete.Controls.Add(this.m_btnCopierAnalyse);
            this.m_panelEntete.Controls.Add(this.label2);
            this.m_panelEntete.Controls.Add(this.m_dtDebut);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(708, 42);
            this.m_panelEntete.TabIndex = 8;
            // 
            // m_wndDuree
            // 
            this.m_wndDuree.Location = new System.Drawing.Point(376, 3);
            this.m_wndDuree.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndDuree.Name = "m_wndDuree";
            this.m_wndDuree.NullAutorise = true;
            this.m_wndDuree.SaisieDuree = true;
            this.m_wndDuree.Size = new System.Drawing.Size(54, 21);
            this.m_wndDuree.TabIndex = 8;
            this.m_wndDuree.ValeurHeure = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(274, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Appointed duration|557";
            // 
            // m_btnTest
            // 
            this.m_btnTest.Location = new System.Drawing.Point(521, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTest, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(75, 23);
            this.m_btnTest.TabIndex = 9;
            this.m_btnTest.Text = "button1";
            this.m_btnTest.UseVisualStyleBackColor = true;
            this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // CControleSaisiesOperations
            // 
            this.Controls.Add(this.m_panelControles);
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.pictureBox1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleSaisiesOperations";
            this.Size = new System.Drawing.Size(708, 195);
            this.Load += new System.EventHandler(this.CControleSaisiesOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopierAnalyse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelEntete.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        //------------------------------------------------------------------------------
        private void CControleSaisiesOperations_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //---------------------------------------------------------------------------------
        public ArrayList ListeControlesUtils
        {
            get { return m_listeControlsUtiles; }
        }

        //------------------------------------------------------------------------------
        public void ChangeElementAOperationsSansChangerLesValeursAffichees(IElementAOperationsRealisees element)
        {
            m_elementAOperations = element;
        }

        //------------------------------------------------------------------------------
        private bool m_bIsFilling = false;
        public void Init( IElementAOperationsRealisees element )
		{
            m_bIsFilling = true;
			m_panelControles.SuspendDrawing();
			m_elementAOperations = element;
			foreach ( Control ctrl in m_listeControlsUtiles )
			{
				ctrl.Visible = false;
				((CControleSaisieOperation)ctrl).Operation = null;
			}
            
			///Préinitialise avec les valeurs planifiées
			///comme ça, quand on clique sur check, la date est préinitialisée
            CFractionIntervention fraction = element as CFractionIntervention;
            if (fraction != null)
            {
                m_dtDebut.Value = fraction.DateDebutPlanifie;
                m_dtFin.Value = fraction.DateFinPlanifiee;
                
                m_wndDuree.ValeurHeure = fraction.DureeSaisie;		

            }

			///et affecte les valeurs réelles
			m_dtDebut.Value = element.DateDebut;
			m_dtFin.Value = element.DateFin;



			m_listeControlesReserve.AddRange ( m_listeControlsUtiles );
			m_listeControlsUtiles.Clear();
			CListeObjetsDonnees liste = m_elementAOperations.Operations;
			liste.Filtre = new CFiltreData ( COperation.c_champIdOpParente+" is null");
			int nIndex = 0;
			foreach ( COperation donnee in liste )
			{
				AddOperation ( donnee, ref nIndex , false );
			}
			if ( m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition )
			{
				CControleSaisieOperation ctrl = GetNewControle ( 0 );
				ctrl.InitControle ( null, 0, 0, true );
			}
			ReordonneeTout();

            m_bIsFilling = false;
			RecalcSize();

			m_panelControles.ResumeDrawing();
		}

		
		//------------------------------------------------------------------------------
		private void RecalcSize()
		{
            if (Dock == DockStyle.Fill)
                return;
            if (m_bIsFilling)
                return;
            int nHeight = 0;
            if (m_bPanelEnteteVisible)
                nHeight = m_panelEntete.Height + 4;
            else
                nHeight = 4;
			foreach (Control ctrl in m_listeControlsUtiles)
				nHeight += ctrl.Height;
            if (Math.Abs(nHeight - Height) > 5) 
			    Height = nHeight;
		}


        //-----------------------------------------------------------------------------
        public bool PanelEnteteVisible
        {
            get { return m_bPanelEnteteVisible; }
            set 
            {
                m_bPanelEnteteVisible = value;
                m_panelEntete.Visible = m_bPanelEnteteVisible;
                RecalcSize();
            }
        }


		//-----------------------------------------------------------------------------
		public IElementAOperationsRealisees ElementAOperations
		{
			get {return m_elementAOperations;}
		}

        //------------------------------------------------------------------------------
        public CPhaseTicket PhaseTicket
        {
            get { return ElementAOperations as CPhaseTicket ; }
        }

        //------------------------------------------------------------------------------
        public CFractionIntervention FractionIntervention
        {
            get { return ElementAOperations as CFractionIntervention; }
        }
 
		//------------------------------------------------------------------------------
		public CResultAErreur Maj_Champs()
		{
			CResultAErreur result = CResultAErreur.True;

            CObjetDonnee objElementAOp = ElementAOperations as CObjetDonnee;
			if (ElementAOperations == null || (objElementAOp != null && !objElementAOp.IsValide()))
				return result;
			ElementAOperations.DateDebut = m_dtDebut.Value;
			ElementAOperations.DateFin = m_dtFin.Value;
            //if (m_dtDebut.Value == null)
            //{
            //    result.EmpileErreur("Date de début d'intervention obligatoire");
            //    return result;
            //}

			if ( !m_listeDerniersfractionInterventions.Contains ( ElementAOperations.Id ) )
				m_listeDerniersfractionInterventions.Add ( ElementAOperations.Id );

			Hashtable tableNiveauToParent = new Hashtable();
			foreach ( CControleSaisieOperation control in m_listeControlsUtiles )
			{
				result = control.Maj_Champs(tableNiveauToParent);
				if ( !result )
					return result;
				COperation donnee = control.Operation;
				if ( donnee != null )
					tableNiveauToParent[donnee.Niveau] = donnee;
			}

            CFractionIntervention fraction = ElementAOperations as CFractionIntervention;
            if(fraction != null)
                fraction.DureeSaisie = m_wndDuree.ValeurHeure;

			return result;
		}

		//-----------------------------------------
		private CControleSaisieOperation GetNewControle ( int nIndex )
		{
			CControleSaisieOperation ctrl = null;
			if ( m_listeControlesReserve.Count == 0 )
			{
				ctrl = new CControleSaisieOperation ( this );
			}
			else
			{
				ctrl = (CControleSaisieOperation)m_listeControlesReserve[0];
				ctrl.Operation =  null;
			}

            bool bDernier = m_listeControlsUtiles.Count == nIndex;
			
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
				CControleSaisieOperation ctrlApres = (CControleSaisieOperation)m_listeControlsUtiles[nCtrl];
				ctrlApres.Index = nCtrl;
			}
            if (bDernier)
                ctrl.BringToFront();
            else
			    ReordonneeTout();
			ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			ctrl.BackColor = m_panelControles.BackColor;

			ctrl.SizeChanged += new EventHandler(ctrlOperation_SizeChanged);
		
			return ctrl;
		}

		//-----------------------------------------
		private void ReordonneeTout()
		{
            m_panelControles.SuspendDrawing();
			foreach ( CControleSaisieOperation ctrl in m_listeControlsUtiles )
			{
				ctrl.BringToFront();
			}
            m_panelControles.ResumeDrawing();
		}

		//-----------------------------------------
		private void AddOperation ( COperation operation, ref int nIndex, bool bRecalcSize )
		{
            if (operation == null)
                return;
            if (operation.TypeOperation != null )
            {
                //bool bEntete = m_panelControles.Controls.Count == 0;
                bool bEntete = nIndex == 0;
                CControleSaisieOperation ctrl = GetNewControle(nIndex);
                ctrl.Visible = true;
                ctrl.InitControle(operation, nIndex, operation.TypeOperation.Niveau, bEntete);
                nIndex++;
                foreach (COperation operationFille in operation.OperationsFilles)
                    AddOperation(operationFille, ref nIndex, false);
                if (bRecalcSize)
                    RecalcSize();
            }
            else if ( operation.IsNew() && !LockEdition)
                operation.Delete ( true );
		}

		void ctrlOperation_SizeChanged(object sender, EventArgs e)
		{
			RecalcSize();
		}

		//-----------------------------------------
		/// <summary>
		/// Retourne le type de donnée correspondant au niveau demandé pour l'index de controle demandé
		/// </summary>
		/// <param name="nNiveau"></param>
		/// <param name="nIndexControle"></param>
		public CTypeOperation GetTypeDonneeNiveau ( int nNiveau, int nIndexControle )
		{
			for ( int nCtrl = nIndexControle-1; nCtrl >= 0; nCtrl-- )
			{
				if ( nCtrl < m_listeControlsUtiles.Count-1 )
				{
					CControleSaisieOperation ctrl = (CControleSaisieOperation)m_listeControlsUtiles[nCtrl];
					CTypeOperation tdq = ctrl.TypeOperation;
					if ( tdq != null && tdq.Niveau == nNiveau )
						return tdq;
				}
			}
			return null;
		}

		//----------------------------------------------------------
		public bool CanChangeNiveau ( int nIndex, int nNiveauDemande )
		{
			if ( nNiveauDemande < 0 )
				return false;

			
			CControleSaisieOperation ctrlPrecedent = null,
				ctrlSuivant = null;

			if ( nIndex == 0 )
				return false;
			
			ctrlPrecedent = (CControleSaisieOperation)m_listeControlsUtiles[nIndex-1];

			if (ctrlPrecedent != null && ctrlPrecedent.TypeOperation != null &&
				ctrlPrecedent.TypeOperation.TypesOperationsFilles.Count == 0 && nNiveauDemande > ctrlPrecedent.Niveau)
				return false;

			if ( nIndex < m_listeControlsUtiles.Count-1 )
				ctrlSuivant = (CControleSaisieOperation)m_listeControlsUtiles[nIndex+1];

			bool bOkPourPrecedent = nNiveauDemande <= ctrlPrecedent.TypeOperation.Niveau+1;
			
			//Dernier contrôle ?
			if ( nIndex >= m_listeControlsUtiles.Count-1 )
				return bOkPourPrecedent;

			//Regarde le niveau du controle suivant
			if ( ctrlSuivant.TypeOperation == null )
				return bOkPourPrecedent;
			if ( ctrlSuivant.TypeOperation.Niveau <= nNiveauDemande )//fils de celui qui veut changer
				return bOkPourPrecedent;
	
			return false;							
		}

		//---------------------------------------------------
		private CControleSaisieOperation GetControle ( int nIndex )
		{
			return ( CControleSaisieOperation )m_listeControlsUtiles[nIndex];
		}

		//---------------------------------------------------
		public void InsertBefore ( int nIndex )
		{
			if ( !CanAddNew() )
				return;
			if ( nIndex >= m_listeControlsUtiles.Count-1 )
				return;
			CControleSaisieOperation ctrl = GetControle ( nIndex );
			if ( ctrl.TypeOperation == null )
				return;
			int nNiveau = ctrl.TypeOperation.Niveau;
            if (nIndex == 0)
                ctrl.AvecEntete = false;

			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex );
			ctrl.InitControle ( null, nIndex, nNiveau, nIndex == 0 );
			ReordonneeTout();
			m_panelControles.ResumeDrawing();
			ctrl.Focus();
		}

		//---------------------------------------------------
		public void InsertAfter ( int nIndex )
		{
			if ( !CanAddNew() )
				return;
			CControleSaisieOperation ctrl = GetControle ( nIndex );
			if ( ctrl.TypeOperation == null )
				return;
			int nNiveau = ctrl.TypeOperation.Niveau;
            bool bDernier = nIndex+1 == m_listeControlsUtiles.Count;
			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex+1 );
            if (CanChangeNiveau(nIndex + 1, nNiveau + 1))
                nNiveau++;
			ctrl.InitControle ( null, nIndex+1, nNiveau, false );
            ctrl.BringToFront();
            if ( !bDernier )
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
			foreach ( CControleSaisieOperation ctrl in m_listeControlsUtiles )
				if ( !ctrl.ControleDonnees() )
				{
					return false;
				}
			return true;
		}

		//---------------------------------------------------
		public bool RemoveDonnee( CControleSaisieOperation controle )
		{
			CResultAErreur result = CResultAErreur.True;
			if (controle.Operation != null)
			{
				result = controle.Operation.CanDelete();
				if (!result)
				{
					CFormAlerte.Afficher(result.Erreur);
					return false;
				}
			}
			int nNiveau = controle.Niveau;
			int nIndex = controle.Index;
			
			CControleSaisieOperation ctrlSuivant = null;
			if ( nIndex+1 < m_listeControlsUtiles.Count )
				ctrlSuivant = (CControleSaisieOperation)m_listeControlsUtiles[nIndex+1];
			while ( ctrlSuivant != null && ctrlSuivant.Niveau > nNiveau )
			{
				if ( !RemoveDonnee ( ctrlSuivant ) )
					return false;
				if ( nIndex+1 < m_listeControlsUtiles.Count )
					ctrlSuivant = (CControleSaisieOperation)m_listeControlsUtiles[nIndex+1];
				else
					ctrlSuivant = null;
			}
			if (controle.Operation != null)
			{
				result = controle.Operation.Delete(true);
				if (!result)
					return false;
			}

			m_listeControlsUtiles.Remove ( controle );
			m_listeControlesReserve.Add ( controle );
			nIndex = controle.Index;
			for ( int nChange = nIndex; nChange < m_listeControlsUtiles.Count; nChange++ )
			{
				((CControleSaisieOperation)m_listeControlsUtiles[nChange]).Index = nIndex;
				nIndex++;
			}
			
			controle.Operation =  null;
			controle.Hide();

			//s'il n'y a plus de contrôle, il faut en ajouter 1 !!!
			if (m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition)
			{
				CControleSaisieOperation ctrl = GetNewControle(0);
				ctrl.InitControle(null, 0, 0, true);
			}
			RecalcSize();

			return true;
		}

		//---------------------------------------------------
		public bool IsDernierControle ( int nIndex )
		{
			return nIndex == m_listeControlsUtiles.Count-1;
		}

		private class CMenuItemAfractionIntervention : MenuItem
		{
			public readonly int Id;

			public CMenuItemAfractionIntervention ( int nId, string strLibelle )
			{
				this.Text = strLibelle;
				Id = nId;
			}
		}

        //private void m_lnkReprendre_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        //{
        //    ContextMenu menu = new ContextMenu();
        //    if ( m_listeDerniersfractionInterventions.Count == 0 )
        //        CFormAlerte.Afficher("Pas d'historique", EFormAlerteType.Exclamation);
        //    foreach ( int nId in m_listeDerniersfractionInterventions )
        //    {
        //        IElementAOperationsRealisees fractionIntervention = new IElementAOperationsRealisees ( CSc2iWin32DataClient.ContexteCourant );
        //        if ( fractionIntervention.ReadIfExists ( new CFiltreData ( IElementAOperationsRealisees.c_champId+"=@1", nId) ))
        //        {
        //            CMenuItemAfractionIntervention item = new CMenuItemAfractionIntervention ( nId, fractionIntervention.Libelle );
        //            item.Click += new EventHandler(item_Click);
        //            menu.MenuItems.Add ( item );
        //        }
        //    }
        //    //menu.Show ( m_lnkReprendre, new Point ( 0, m_lnkReprendre.Height ) );
        //}

        //private void item_Click(object sender, EventArgs e)
        //{
        //    if ( sender is CMenuItemAfractionIntervention )
        //    {
        //        CMenuItemAfractionIntervention item = (CMenuItemAfractionIntervention)sender;
        //        if ( CFormAlerte.Afficher("Reprendre les données '"+
        //            item.Text+"' ?",EFormAlerteType.Question) == DialogResult.Yes )
        //        {
        //            IElementAOperationsRealisees fractionIntervention = new IElementAOperationsRealisees ( ElementAOperations.ContexteDonnee );
        //            if ( fractionIntervention.ReadIfExists ( new CFiltreData ( IElementAOperationsRealisees.c_champId+"=@1",item.Id ) ))
        //            {
        //                CObjetDonneeAIdNumeriqueAuto.Delete ( fractionIntervention.Operations );
        //                Hashtable mapDonnees = new Hashtable();
        //                CListeObjetsDonnees donneesToCopie = fractionIntervention.Operations;
        //                //donneesToCopie.Filtre = new CFiltreData ( COperation.c_champIdDonneeParente+" is null" );
        //                foreach ( COperation operation in donneesToCopie )
        //                {
        //                    COperation newOperation = (COperation)operation.Clone(false);
        //                    mapDonnees[operation.Id] = newOperation;
        //                    if ( operation.OperationParente != null )
        //                        newOperation.OperationParente = (COperation)mapDonnees[operation.OperationParente.Id];
        //                    else
        //                        newOperation.OperationParente = null;
        //                    newOperation.ElementAOperations = fractionIntervention;
        //                }
        //                Init ( fractionIntervention );
        //            }
        //        }
        //    }
        //}




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
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event System.EventHandler OnChangeLockEdition;

        #endregion


		//Appelé lorsqu'un élément change de type de donnée
		public void OnChangeTypeDonnee ( int nIndex, CTypeOperation typeDonnee )
		{
			if (nIndex > m_listeControlsUtiles.Count - 1)
				return; 
			CControleSaisieOperation ctrl = (CControleSaisieOperation)m_listeControlsUtiles[nIndex];
			int nNiveau = ctrl.Niveau;
			nIndex++;
			while ( nIndex < m_listeControlsUtiles.Count )
			{
				CControleSaisieOperation ctrlSuivant = (CControleSaisieOperation)m_listeControlsUtiles[nIndex];
				if ( ctrlSuivant.Niveau <= nNiveau )
					return;
				if ( ctrlSuivant.Niveau == nNiveau+1 )
				{
					ctrlSuivant.OnChangeTypeParent ( typeDonnee );
				}
				nIndex++;
			}
		}
		
		public bool GoDown ( int nIndex, string strNomControle )
		{
			if ( nIndex+1 < m_listeControlsUtiles.Count )
			{
				CControleSaisieOperation ctrl = GetControle ( nIndex+1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		public bool GoUp ( int nIndex, string strNomControle )
		{
			if ( nIndex-1 >= 0 )
			{
				CControleSaisieOperation ctrl = GetControle ( nIndex-1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		private void m_btnCopierAnalyse_Click(object sender, System.EventArgs e)
		{
			m_btnCopierAnalyse.Location.Offset(2,2);
			m_btnCopierAnalyse.Refresh();
			int nNiveauCourant = -1;
			string strText = "";
			foreach ( CControleSaisieOperation control in m_listeControlsUtiles )
			{
				int nNiveau = control.Niveau;
				if ( nNiveau == nNiveauCourant )
					strText += ", ";
				else if ( nNiveau < nNiveauCourant )
				{
					switch ( nNiveau )
					{
						case 0 :
							strText += "\r\n";
							break;
						default :
							strText += "), ";
							break;
					}
				}
				else
				{
					switch ( nNiveau )
					{
						case 0 : 
							strText += "";
							break;
						case 1 :
							strText += " : ";
							break;
						default : 
							strText += " (";
							break;
					}
				}
				nNiveauCourant = nNiveau;
				strText += control.Libelle;
			}
			while ( nNiveauCourant >= 2 )
			{
				strText += ")";
				nNiveauCourant--;
			}
			Clipboard.SetDataObject (strText); 
			m_btnCopierAnalyse.Location.Offset(-2,-2);
			m_btnCopierAnalyse.Refresh();
		}

		public CControleSaisieOperation GetControleNiveauParent ( CControleSaisieOperation controleFils )
		{
			CControleSaisieOperation ctrlParent = null;
			foreach ( CControleSaisieOperation ctrl in m_listeControlsUtiles )
			{
				if ( ctrl.Niveau == controleFils.Niveau-1 )
					ctrlParent = ctrl;
				if ( ctrl == controleFils )
					return ctrlParent;
			}
			return null;
		}


        internal void SetElementEditeSansChangerLesValeursAffichees(object element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void m_btnTest_Click(object sender, EventArgs e)
        {
            CFormPopupCRTest.Edite(m_elementAOperations);
        }
    }
}
