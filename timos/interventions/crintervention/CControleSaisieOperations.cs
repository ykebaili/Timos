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
using sc2i.win32.common.customizableList;

namespace timos
{
	/// <summary>
	/// Description résumée de CControleSaisiesOperations.
	/// </summary>
	public class CControleSaisiesOperations : System.Windows.Forms.UserControl, IControlALockEdition
	{
        private bool m_bPanelEnteteVisible = true;
		private static ArrayList m_listeDerniersfractionInterventions = new ArrayList();
		private IElementAOperationsRealisees m_elementAOperations = null;

        private timos.interventions.crintervention.CEditeurOperations m_wndListeOperations;
		
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
            this.m_wndListeOperations = new timos.interventions.crintervention.CEditeurOperations();
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
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopierAnalyse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panelEntete.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListeOperations
            // 
            this.m_wndListeOperations.CurrentItemIndex = null;
            this.m_wndListeOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeOperations.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeOperations.Location = new System.Drawing.Point(0, 42);
            this.m_wndListeOperations.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeOperations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeOperations.Name = "m_wndListeOperations";
            this.m_wndListeOperations.Size = new System.Drawing.Size(850, 153);
            this.m_wndListeOperations.TabIndex = 0;
            this.m_wndListeOperations.Load += new System.EventHandler(this.m_wndListeOperations_Load);
            this.m_wndListeOperations.ScrollSizeChanged += new System.EventHandler(this.m_wndListeOperations_ScrollSizeChanged);
            this.m_wndListeOperations.AfterAddOperation += new System.EventHandler(this.m_wndListeOperations_AfterAddOperation);
            this.m_wndListeOperations.SizeChanged += new System.EventHandler(this.m_wndListeOperations_SizeChanged);
            // 
            // m_btnCopierAnalyse
            // 
            this.m_btnCopierAnalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCopierAnalyse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCopierAnalyse.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCopierAnalyse.Image")));
            this.m_btnCopierAnalyse.Location = new System.Drawing.Point(830, 22);
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
            this.m_dtDebut.Value.DateTimeValue = new System.DateTime(2013, 9, 5, 15, 12, 53, 265);
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
            this.m_dtFin.Value.DateTimeValue = new System.DateTime(2013, 9, 5, 15, 12, 53, 265);
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
            this.pictureBox1.Size = new System.Drawing.Size(844, 1);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // m_panelEntete
            // 
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
            this.m_panelEntete.Size = new System.Drawing.Size(850, 42);
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
            // CControleSaisiesOperations
            // 
            this.Controls.Add(this.m_wndListeOperations);
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.pictureBox1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleSaisiesOperations";
            this.Size = new System.Drawing.Size(850, 195);
            this.Load += new System.EventHandler(this.CControleSaisiesOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopierAnalyse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelEntete.PerformLayout();
            this.ResumeLayout(false);

		}

        void m_wndListeOperations_AfterAddOperation(object sender, EventArgs e)
        {
            RecalcSize();
        }
		#endregion

        //------------------------------------------------------------------------------
        private void CControleSaisiesOperations_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
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
			m_wndListeOperations.SuspendDrawing();
			m_elementAOperations = element;
            m_wndListeOperations.Init(m_elementAOperations);
            
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

            m_bIsFilling = false;
			RecalcSize();

			m_wndListeOperations.ResumeDrawing();
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
            nHeight += m_wndListeOperations.HeaderHeight;
			foreach (CCustomizableListItem item in m_wndListeOperations.Items)
                nHeight += m_wndListeOperations.GetItemHeight(item.Index); ;
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
            
			if ( !m_listeDerniersfractionInterventions.Contains ( ElementAOperations.Id ) )
				m_listeDerniersfractionInterventions.Add ( ElementAOperations.Id );

            result = m_wndListeOperations.MajChamps();
            CFractionIntervention fraction = ElementAOperations as CFractionIntervention;
            if(fraction != null)
                fraction.DureeSaisie = m_wndDuree.ValeurHeure;

			return result;
		}

		void ctrlOperation_SizeChanged(object sender, EventArgs e)
		{
			RecalcSize();
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


		

		private void m_btnCopierAnalyse_Click(object sender, System.EventArgs e)
		{
			m_btnCopierAnalyse.Location.Offset(2,2);
			m_btnCopierAnalyse.Refresh();
			int nNiveauCourant = -1;
			string strText = "";
            foreach ( CItemOperation item in m_wndListeOperations.Items )
            {
                COperation operation = item.Operation;
                int nNiveau = operation.Niveau;
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
				strText += operation.Libelle;
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

		

        internal void SetElementEditeSansChangerLesValeursAffichees(object element)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        private void m_wndListeOperations_SizeChanged(object sender, EventArgs e)
        {
            RecalcSize();
        }

        private void m_wndListeOperations_ScrollSizeChanged(object sender, EventArgs e)
        {
            RecalcSize();
        }

        private void m_wndListeOperations_Load(object sender, EventArgs e)
        {

        }
    }
}
