using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common.planification;
using sc2i.common;
using sc2i.win32.common;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CEditeurPlanificationIntervention.
	/// </summary>
	public class CEditeurPlanificationIntervention : System.Windows.Forms.UserControl, IControlALockEdition
	{
		/// <summary>
		/// conserve toutes les planifications qui ont été allouées
		/// </summary>
		private Hashtable m_tableTypePlanifToAlloue = new Hashtable();

		private CPanelPlanficationIntervention m_panel = null;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbTypePlanification;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iPanel m_panelSousFormulaire;
		private System.ComponentModel.IContainer components;

		public CEditeurPlanificationIntervention()
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_cmbTypePlanification = new sc2i.win32.common.CComboboxAutoFilled();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelSousFormulaire = new sc2i.win32.common.C2iPanel(this.components);
            this.SuspendLayout();
            // 
            // m_cmbTypePlanification
            // 
            this.m_cmbTypePlanification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypePlanification.IsLink = false;
            this.m_cmbTypePlanification.ListDonnees = null;
            this.m_cmbTypePlanification.Location = new System.Drawing.Point(112, 0);
            this.m_cmbTypePlanification.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypePlanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypePlanification.Name = "m_cmbTypePlanification";
            this.m_cmbTypePlanification.NullAutorise = true;
            this.m_cmbTypePlanification.ProprieteAffichee = "Libelle";
            this.m_cmbTypePlanification.Size = new System.Drawing.Size(272, 21);
            this.m_cmbTypePlanification.TabIndex = 0;
            this.m_cmbTypePlanification.TextNull = "";
            this.m_cmbTypePlanification.Tri = true;
            this.m_cmbTypePlanification.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypePlanification_SelectedIndexChanged);
            this.m_cmbTypePlanification.SelectedValueChanged += new System.EventHandler(this.m_cmbTypePlanification_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Planning type|30009";
            // 
            // m_panelSousFormulaire
            // 
            this.m_panelSousFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelSousFormulaire.Location = new System.Drawing.Point(0, 24);
            this.m_panelSousFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelSousFormulaire.Name = "m_panelSousFormulaire";
            this.m_panelSousFormulaire.Size = new System.Drawing.Size(384, 80);
            this.m_panelSousFormulaire.TabIndex = 2;
            // 
            // CEditeurPlanificationIntervention
            // 
            this.Controls.Add(this.m_panelSousFormulaire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbTypePlanification);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurPlanificationIntervention";
            this.Size = new System.Drawing.Size(384, 104);
            this.Load += new System.EventHandler(this.CEditeurPlanificationIntervention_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private bool m_bRemplissageEnCours= false;
		private void FillListePlanificationsPossibles()
		{
			m_bRemplissageEnCours = true;
			m_cmbTypePlanification.ListDonnees = CPlanificationTache.GetTypesPlanificationsTaches;
			m_cmbTypePlanification.AssureRemplissage();
			m_bRemplissageEnCours = false;
		}

		/// /////////////////////////////////////////////////
		private void m_cmbTypePlanification_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( m_bRemplissageEnCours )
				return;
			if ( m_cmbTypePlanification.SelectedValue is CPlanificationTache.CInfoTypePlanification )
			{
				Type tp = ((CPlanificationTache.CInfoTypePlanification)m_cmbTypePlanification.SelectedValue).TypePlanification;
				CPlanificationTache planif = (CPlanificationTache)m_tableTypePlanifToAlloue[tp];
				if ( planif == null )
				{
					planif = (CPlanificationTache)Activator.CreateInstance ( tp );
					m_tableTypePlanifToAlloue[tp] = planif;
				}
				Init ( planif );

				
			}
		}

		private void CEditeurPlanificationIntervention_Load(object sender, System.EventArgs e)
		{
			FillListePlanificationsPossibles();
		}

		private void m_cmbTypePlanification_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// //////////////////////////////////////////////
		public CResultAErreur ValideDonnees()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_panel == null )
			{
				result.EmpileErreur(I.T("No planning type selected|30010"));
				return result;
			}
			return m_panel.MajChamps();
		}

		/// //////////////////////////////////////////////
		public CPlanificationTache Planification
		{
			get
			{
				if ( m_panel != null )
					return m_panel.Planification;
				return null;
			}
		}

		/// //////////////////////////////////////////////
		public void Init ( CPlanificationTache planification )
		{
			if ( m_cmbTypePlanification.ListDonnees == null )
				FillListePlanificationsPossibles();
			if ( planification == null )
				return;
			m_tableTypePlanifToAlloue[planification.GetType()] = planification;
			if ( m_panel != null )
			{
				m_panel.MajChamps();
				m_panelSousFormulaire.Controls.Remove ( m_panel );
				m_panel.Visible = false;
				m_panel.Dispose();
				m_panel = null;
			}
			Type tpPanel = CPanelPlanficationIntervention.GetTypePanelToEdit(planification.GetType());
			if ( tpPanel != null )
			{
				m_panel = (CPanelPlanficationIntervention)Activator.CreateInstance(tpPanel);
				m_panel.Parent = m_panelSousFormulaire;
				m_panel.Dock = DockStyle.Top;
				m_panel.CreateControl();
				m_panel.InitChamps ( planification );
				m_panel.LockEdition = LockEdition;
			}
			if ( m_panel != null )
				m_panel.BackColor = BackColor;
			
			CPlanificationTache.CInfoTypePlanification info = new CPlanificationTache.CInfoTypePlanification(planification.GetType(), "" );
			if ( m_cmbTypePlanification.SelectedValue == null || 
				!m_cmbTypePlanification.SelectedValue.Equals(info ))
				m_cmbTypePlanification.SelectedValue = info;
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
	}

}
