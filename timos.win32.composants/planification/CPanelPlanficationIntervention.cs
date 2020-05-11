using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.common;
using sc2i.common.planification;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelPlanficationIntervention.
	/// </summary>
	public class CPanelPlanficationIntervention : System.Windows.Forms.UserControl, IControlALockEdition
	{
        private CPlanificationTache m_planification;
		private static Hashtable m_tableTypePlanificationToPanelEdition = new Hashtable();
		private CFormatteurTextBoxMasque m_formatteurHeure = new CFormatteurTextBoxMasque("##:##");
		protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		protected Label label2;
		protected sc2i.win32.common.CExtLinkField m_extLinkField;
		private CWndSaisieHeure m_wndHeure;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelPlanficationIntervention()
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndHeure = new sc2i.win32.common.CWndSaisieHeure();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time|125";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_wndHeure
            // 
            this.m_extLinkField.SetLinkField(this.m_wndHeure, "");
            this.m_wndHeure.Location = new System.Drawing.Point(95, 0);
            this.m_wndHeure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndHeure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndHeure.Name = "m_wndHeure";
            this.m_wndHeure.NullAutorise = false;
            this.m_wndHeure.SaisieDuree = true;
            this.m_wndHeure.Size = new System.Drawing.Size(40, 20);
            this.m_wndHeure.TabIndex = 3;
            this.m_wndHeure.ValeurHeure = 9.5;
            // 
            // CPanelPlanficationIntervention
            // 
            this.Controls.Add(this.m_wndHeure);
            this.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelPlanficationIntervention";
            this.Size = new System.Drawing.Size(136, 24);
            this.Load += new System.EventHandler(this.CPanelPlanficationIntervention_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void CPanelPlanficationIntervention_Load(object sender, System.EventArgs e)
		{
		}

		

		
		

        public CPlanificationTache Planification
		{
			get
			{
				return m_planification;
			}
		}

        public virtual void InitChamps(CPlanificationTache planification)
		{
			CWin32Traducteur.Translate(this);
			m_planification = planification;

			m_wndHeure.ValeurHeure = planification.Heure;
			m_extLinkField.FillDialogFromObjet ( planification );
		}

		public virtual CResultAErreur MajChamps (  )
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_wndHeure.ValeurHeure == null )
				m_wndHeure.ValeurHeure = 0;
			Planification.Heure = (double)m_wndHeure.ValeurHeure;
			result = m_extLinkField.FillObjetFromDialog ( m_planification );
			return result;
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

		public static void RegisterPanelPlanification ( Type typePlanifiation, Type typePanel )
		{
			m_tableTypePlanificationToPanelEdition[typePlanifiation] = typePanel;
		}

		public static Type GetTypePanelToEdit ( Type typePlanification )
		{
			return ( Type )m_tableTypePlanificationToPanelEdition[typePlanification];
		}

		private void m_lblTitre_Click(object sender, System.EventArgs e)
		{
			CFormAlerte.Afficher( m_planification.GetLibelle() , EFormAlerteType.Exclamation);
		}
	}
}
