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

namespace timos.preventives
{
	/// <summary>
	/// Description résumée de CControlePrevisionsOperations.
	/// </summary>
	public class CControlePrevisionsOperations : System.Windows.Forms.UserControl, IControlALockEdition
	{

        private CControlePrevisionOperation m_controlActif = null;
        private static ArrayList m_listeDerniersfractionInterventions = new ArrayList();
        
		private ArrayList m_listeControlsUtiles = new ArrayList();
		private ArrayList m_listeControlesReserve = new ArrayList();

		private IElementAOperationPrevisionnelle m_elementEdite = null;

		private sc2i.win32.common.C2iPanel m_panelControles;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.ToolTip m_tooltip;
        private PictureBox pictureBox1;
        private C2iPanel m_panelMonterDescendre;
        private Button m_btnMonterOperation;
        private Button m_btnDescendreOperation;
		private System.ComponentModel.IContainer components;

		public CControlePrevisionsOperations()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlePrevisionsOperations));
            this.m_panelControles = new sc2i.win32.common.C2iPanel(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelMonterDescendre = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnDescendreOperation = new System.Windows.Forms.Button();
            this.m_btnMonterOperation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelMonterDescendre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelControles
            // 
            this.m_panelControles.AutoScroll = true;
            this.m_panelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelControles.Location = new System.Drawing.Point(0, 0);
            this.m_panelControles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelControles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelControles.Name = "m_panelControles";
            this.m_panelControles.Size = new System.Drawing.Size(466, 195);
            this.m_panelControles.TabIndex = 0;
            // 
            // m_panelMonterDescendre
            // 
            this.m_panelMonterDescendre.Controls.Add(this.m_btnDescendreOperation);
            this.m_panelMonterDescendre.Controls.Add(this.m_btnMonterOperation);
            this.m_panelMonterDescendre.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelMonterDescendre.Location = new System.Drawing.Point(466, 0);
            this.m_panelMonterDescendre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMonterDescendre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMonterDescendre.Name = "m_panelMonterDescendre";
            this.m_panelMonterDescendre.Size = new System.Drawing.Size(25, 195);
            this.m_panelMonterDescendre.TabIndex = 8;
            // 
            // m_btnDescendreOperation
            // 
            this.m_btnDescendreOperation.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDescendreOperation.Image")));
            this.m_btnDescendreOperation.Location = new System.Drawing.Point(2, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDescendreOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnDescendreOperation.Name = "m_btnDescendreOperation";
            this.m_btnDescendreOperation.Size = new System.Drawing.Size(21, 21);
            this.m_btnDescendreOperation.TabIndex = 0;
            this.m_btnDescendreOperation.UseVisualStyleBackColor = true;
            this.m_btnDescendreOperation.Click += new System.EventHandler(this.m_btnDescendreOperation_Click);
            // 
            // m_btnMonterOperation
            // 
            this.m_btnMonterOperation.Image = ((System.Drawing.Image)(resources.GetObject("m_btnMonterOperation.Image")));
            this.m_btnMonterOperation.Location = new System.Drawing.Point(2, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnMonterOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnMonterOperation.Name = "m_btnMonterOperation";
            this.m_btnMonterOperation.Size = new System.Drawing.Size(21, 21);
            this.m_btnMonterOperation.TabIndex = 0;
            this.m_btnMonterOperation.UseVisualStyleBackColor = true;
            this.m_btnMonterOperation.Click += new System.EventHandler(this.m_btnMonterOperation_Click);
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
            // CControlePrevisionsOperations
            // 
            this.Controls.Add(this.m_panelControles);
            this.Controls.Add(this.m_panelMonterDescendre);
            this.Controls.Add(this.pictureBox1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlePrevisionsOperations";
            this.Size = new System.Drawing.Size(491, 195);
            this.m_panelMonterDescendre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void Init( IElementAOperationPrevisionnelle element )
		{
			Visible = false;
			m_panelControles.SuspendDrawing();
            m_elementEdite = element;
			foreach ( Control ctrl in m_listeControlsUtiles )
			{
				ctrl.Visible = false;
				((CControlePrevisionOperation)ctrl).Operation = null;
			}
            
			m_listeControlesReserve.AddRange ( m_listeControlsUtiles );
			m_listeControlsUtiles.Clear();
            CListeObjetsDonnees liste = m_elementEdite.Operations;
			liste.Filtre = new CFiltreData ( COperation.c_champIdOpParente+" is null");
			int nIndex = 0;
			foreach ( COperation donnee in liste )
			{
				AddOperation ( donnee, ref nIndex , false );
			}
			if ( m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition )
			{
				CControlePrevisionOperation ctrl = GetNewControle ( 0 );
				ctrl.InitControle ( null, 0, 0, true );
			}
			ReordonneeTout();

			RecalcSize();

			m_panelControles.ResumeDrawing();
			Visible = true;
		}
		
		//-----------------------------------------
		private void RecalcSize()
		{
            int nHeight = 4;
            foreach (Control ctrl in m_listeControlsUtiles)
				nHeight += ctrl.Height;
			Height = nHeight;
		}
		

		//-----------------------------------------
		public IElementAOperationPrevisionnelle ElementEdite
		{
			get
			{
                return m_elementEdite;
			}
		}

		//-----------------------------------------
		public CResultAErreur Maj_Champs()
		{
			CResultAErreur result = CResultAErreur.True;

			if (ElementEdite == null)
				return result;

			if ( !m_listeDerniersfractionInterventions.Contains ( ElementEdite.Id ) )
				m_listeDerniersfractionInterventions.Add ( ElementEdite.Id );

			Hashtable tableNiveauToParent = new Hashtable();
			foreach ( CControlePrevisionOperation control in m_listeControlsUtiles )
			{
				result = control.Maj_Champs(tableNiveauToParent);
				if ( !result )
					return result;
				COperation donnee = control.Operation;
				if ( donnee != null )
					tableNiveauToParent[donnee.Niveau] = donnee;
			}
            //Intervention.DureeSaisie = m_wndDuree.ValeurHeure;
			return result;
		}

		//-----------------------------------------
		private CControlePrevisionOperation GetNewControle ( int nIndex )
		{
			CControlePrevisionOperation ctrl = null;
			if ( m_listeControlesReserve.Count == 0 )
			{
				ctrl = new CControlePrevisionOperation ( this );
			}
			else
			{
				ctrl = (CControlePrevisionOperation)m_listeControlesReserve[0];
				ctrl.Operation =  null;
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
				CControlePrevisionOperation ctrlApres = (CControlePrevisionOperation)m_listeControlsUtiles[nCtrl];
				ctrlApres.Index = nCtrl;
			}
			ReordonneeTout();
			ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			ctrl.BackColor = m_panelControles.BackColor;

			ctrl.SizeChanged += new EventHandler(ctrlOperation_SizeChanged);
		
			return ctrl;
		}

		//------------------------------------------------------------------------------
		private void ReordonneeTout()
		{
			foreach ( CControlePrevisionOperation ctrl in m_listeControlsUtiles )
			{
				ctrl.BringToFront();
			}
		}

		//------------------------------------------------------------------------------------
		private void AddOperation ( COperation operation, ref int nIndex, bool bRecalcSize )
		{
			bool bEntete = m_panelControles.Controls.Count == 0;
			CControlePrevisionOperation ctrl = GetNewControle ( nIndex );
			ctrl.Visible = true;
			ctrl.InitControle ( operation, nIndex, operation.TypeOperation.Niveau, bEntete );			
			nIndex++;
			foreach ( COperation operationFille in operation.OperationsFilles )
				AddOperation ( operationFille, ref nIndex, false );
			if (bRecalcSize)
				RecalcSize();
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
					CControlePrevisionOperation ctrl = (CControlePrevisionOperation)m_listeControlsUtiles[nCtrl];
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

			
			CControlePrevisionOperation ctrlPrecedent = null,
				ctrlSuivant = null;

			if ( nIndex == 0 )
				return false;
			
			ctrlPrecedent = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex-1];

			/*if (ctrlPrecedent != null && ctrlPrecedent.TypeOperation != null &&
				ctrlPrecedent.TypeOperation.TypesOperationsFilles.Count == 0)
				return false;*/

			if ( nIndex < m_listeControlsUtiles.Count-1 )
				ctrlSuivant = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex+1];

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
		private CControlePrevisionOperation GetControle ( int nIndex )
		{
			return ( CControlePrevisionOperation )m_listeControlsUtiles[nIndex];
		}

		//---------------------------------------------------
		public void InsertBefore ( int nIndex )
		{
			if ( !CanAddNew() )
				return;
			if ( nIndex >= m_listeControlsUtiles.Count-1 )
				return;
			CControlePrevisionOperation ctrl = GetControle ( nIndex );
			if ( ctrl.TypeOperation == null )
				return;
			int nNiveau = ctrl.TypeOperation.Niveau;

			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex );
			ctrl.InitControle ( null, nIndex, nNiveau, false );
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
			CControlePrevisionOperation ctrl = GetControle ( nIndex );
			if ( ctrl.TypeOperation == null )
				return;
			int nNiveau = ctrl.TypeOperation.Niveau;

			m_panelControles.SuspendDrawing();
			ctrl = GetNewControle ( nIndex+1 );
			ctrl.InitControle ( null, nIndex+1, nNiveau, false );
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
			foreach ( CControlePrevisionOperation ctrl in m_listeControlsUtiles )
				if ( !ctrl.ControleDonnees() )
				{
					return false;
				}
			return true;
		}

		//---------------------------------------------------
		public bool RemoveDonnee( CControlePrevisionOperation controle )
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
			
			CControlePrevisionOperation ctrlSuivant = null;
			if ( nIndex+1 < m_listeControlsUtiles.Count )
				ctrlSuivant = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex+1];
			while ( ctrlSuivant != null && ctrlSuivant.Niveau > nNiveau )
			{
				if ( !RemoveDonnee ( ctrlSuivant ) )
					return false;
				if ( nIndex+1 < m_listeControlsUtiles.Count )
					ctrlSuivant = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex+1];
				else
					ctrlSuivant = null;
			}
			if (controle.Operation != null)
			{
				result = controle.Operation.Delete();
				if (!result)
					return false;
			}

			m_listeControlsUtiles.Remove ( controle );
			m_listeControlesReserve.Add ( controle );
			nIndex = controle.Index;
			for ( int nChange = nIndex; nChange < m_listeControlsUtiles.Count; nChange++ )
			{
				((CControlePrevisionOperation)m_listeControlsUtiles[nChange]).Index = nIndex;
				nIndex++;
			}
			
			controle.Operation =  null;
			controle.Hide();

			//s'il n'y a plus de contrôle, il faut en ajouter 1 !!!
			if (m_listeControlsUtiles.Count == 0 && m_gestionnaireModeEdition.ModeEdition)
			{
				CControlePrevisionOperation ctrl = GetNewControle(0);
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

		private void m_lnkReprendre_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ContextMenu menu = new ContextMenu();
			if ( m_listeDerniersfractionInterventions.Count == 0 )
				CFormAlerte.Afficher(I.T("No history|30187"), EFormAlerteType.Exclamation);
			foreach ( int nId in m_listeDerniersfractionInterventions )
			{
				CIntervention intervention = new CIntervention ( CSc2iWin32DataClient.ContexteCourant );
				if ( intervention.ReadIfExists ( new CFiltreData ( CIntervention.c_champId+"=@1", nId) ))
				{
					CMenuItemAfractionIntervention item = new CMenuItemAfractionIntervention ( nId, intervention.Libelle );
					item.Click += new EventHandler(item_Click);
					menu.MenuItems.Add ( item );
				}
			}
			//menu.Show ( m_lnkReprendre, new Point ( 0, m_lnkReprendre.Height ) );
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

		private void item_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemAfractionIntervention )
			{
				CMenuItemAfractionIntervention item = (CMenuItemAfractionIntervention)sender;
				if ( CFormAlerte.Afficher(I.T("Retake the data '@1' ?|30188",item.Text),EFormAlerteType.Question) == DialogResult.Yes )
				{
					CIntervention intervention = new CIntervention ( ElementEdite.ContexteDonnee );
                    if (intervention.ReadIfExists(new CFiltreData(CIntervention.c_champId + "=@1", item.Id)))
					{
                        CObjetDonneeAIdNumerique.Delete(intervention.Operations);
						Hashtable mapDonnees = new Hashtable();
                        CListeObjetsDonnees donneesToCopie = intervention.Operations;
						//donneesToCopie.Filtre = new CFiltreData ( COperation.c_champIdDonneeParente+" is null" );
						foreach ( COperation operation in donneesToCopie )
						{
							COperation newDonnee = (COperation)operation.Clone(false);
							mapDonnees[operation.Id] = newDonnee;
							if ( operation.OperationParente != null )
								newDonnee.OperationParente = (COperation)mapDonnees[operation.OperationParente.Id];
							else
								newDonnee.OperationParente = null;
                            newDonnee.Intervention = intervention;
						}
                        Init(intervention);
					}
				}
			}
		}

		//Appelé lorsqu'un élément change de type de donnée
		public void OnChangeTypeDonnee ( int nIndex, CTypeOperation typeDonnee )
		{
			if (nIndex > m_listeControlsUtiles.Count - 1)
				return; 
			CControlePrevisionOperation ctrl = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex];
			int nNiveau = ctrl.Niveau;
			nIndex++;
			while ( nIndex < m_listeControlsUtiles.Count )
			{
				CControlePrevisionOperation ctrlSuivant = (CControlePrevisionOperation)m_listeControlsUtiles[nIndex];
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
				CControlePrevisionOperation ctrl = GetControle ( nIndex+1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		public bool GoUp ( int nIndex, string strNomControle )
		{
			if ( nIndex-1 >= 0 )
			{
				CControlePrevisionOperation ctrl = GetControle ( nIndex-1 );
				return ctrl.FocusOn ( strNomControle );
			}
			return false;
		}

		private void m_btnCopierAnalyse_Click(object sender, System.EventArgs e)
		{
			int nNiveauCourant = -1;
			string strText = "";
			foreach ( CControlePrevisionOperation control in m_listeControlsUtiles )
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
		}

        //------------------------------------------------------------------------------------------
		public CControlePrevisionOperation GetControleNiveauParent ( CControlePrevisionOperation controleFils )
		{
			CControlePrevisionOperation ctrlParent = null;
			foreach ( CControlePrevisionOperation ctrl in m_listeControlsUtiles )
			{
				if ( ctrl.Niveau == controleFils.Niveau-1 )
					ctrlParent = ctrl;
				if ( ctrl == controleFils )
					return ctrlParent;
			}
			return null;
		}

        //------------------------------------------------------------------------------------------
        public CControlePrevisionOperation ControlActif
        {
            get
            {
                return m_controlActif;
            }
            set
            {
                m_controlActif = value;
            }
        }

        //------------------------------------------------------------------------------------------
        private void m_btnMonterOperation_Click(object sender, EventArgs e)
        {
            if (ControlActif is CControlePrevisionOperation)
            {
                //int positionH = m_panelControles.HorizontalScroll.Value;
                COperation opeCache = ControlActif.Operation;
                CResultAErreur result = ControlActif.Operation.MonterIndex();
                if (result)
                {
                    Init(m_elementEdite);
                    foreach (CControlePrevisionOperation ct in m_listeControlsUtiles)
                    {
                        if (ct.Operation.Id == opeCache.Id)
                            ct.Focus();
                    }
                    //m_panelControles.HorizontalScroll.Value = positionH;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------
        private void m_btnDescendreOperation_Click(object sender, EventArgs e)
        {
            if (ControlActif is CControlePrevisionOperation)
            {
                //int positionH = m_panelControles.HorizontalScroll.Value;
                COperation opeCache = ControlActif.Operation;
				if (opeCache == null)
					return;
				CResultAErreur result = opeCache.DescendreIndex();
                if (result)
                {
                    Init(m_elementEdite);
                    foreach (CControlePrevisionOperation ct in m_listeControlsUtiles)
                    {
                        if (ct.Operation.Id == opeCache.Id)
                            ct.Focus();
                    }
                    //m_panelControles.HorizontalScroll.Value = positionH;
                }
            }

        }
	}
}
