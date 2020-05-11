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
	/// Description résumée de CEditeurParametrePlanificationIntervention.
	/// </summary>
	public class CEditeurParametrePlanificationIntervention : System.Windows.Forms.UserControl, IControlALockEdition
	{
        private CParametrePlanificationTache m_parametre = new CParametrePlanificationTache();
		private System.Windows.Forms.LinkLabel m_lnkAjouterPlanification;
		private sc2i.win32.common.C2iPanel m_panelPlanifications;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.ComponentModel.IContainer components;

		public CEditeurParametrePlanificationIntervention()
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
            this.m_lnkAjouterPlanification = new System.Windows.Forms.LinkLabel();
            this.m_panelPlanifications = new sc2i.win32.common.C2iPanel(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // m_lnkAjouterPlanification
            // 
            this.m_lnkAjouterPlanification.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterPlanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterPlanification.Name = "m_lnkAjouterPlanification";
            this.m_lnkAjouterPlanification.Size = new System.Drawing.Size(144, 16);
            this.m_lnkAjouterPlanification.TabIndex = 0;
            this.m_lnkAjouterPlanification.TabStop = true;
            this.m_lnkAjouterPlanification.Text = "Add a planning|30007";
            this.m_lnkAjouterPlanification.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterPlanification_LinkClicked);
            // 
            // m_panelPlanifications
            // 
            this.m_panelPlanifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelPlanifications.AutoScroll = true;
            this.m_panelPlanifications.Location = new System.Drawing.Point(0, 16);
            this.m_panelPlanifications.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPlanifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelPlanifications.Name = "m_panelPlanifications";
            this.m_panelPlanifications.Size = new System.Drawing.Size(512, 200);
            this.m_panelPlanifications.TabIndex = 3;
            // 
            // CEditeurParametrePlanificationIntervention
            // 
            this.Controls.Add(this.m_panelPlanifications);
            this.Controls.Add(this.m_lnkAjouterPlanification);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurParametrePlanificationIntervention";
            this.Size = new System.Drawing.Size(512, 216);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_lnkAjouterPlanification_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CreateNewPanel().Focus();

		}

		private CPanelIncorporePanelPlanification CreateNewPanel()
		{
			CPanelIncorporePanelPlanification lePanel = new CPanelIncorporePanelPlanification();
			lePanel.Parent = m_panelPlanifications;
			lePanel.Dock = DockStyle.Top;
			lePanel.CreateControl();
			lePanel.Visible = true;
			//lePanel.Focus();
			lePanel.SendToBack();
			lePanel.LockEdition = LockEdition;
			lePanel.OnDeletePlanification +=new EventHandler(panel_OnDeletePlanification);
			return lePanel;
		}										   


		private void panel_OnDeletePlanification(object sender, EventArgs e)
		{
			m_lnkAjouterPlanification.Focus();
			if ( CFormAlerte.Afficher(I.T("Delete this planning ?|30008"),EFormAlerteType.Question)==DialogResult.Yes )
			{
				CPanelIncorporePanelPlanification lePanel = (CPanelIncorporePanelPlanification)sender;
				lePanel.Parent.Controls.Remove(lePanel);
				lePanel.Dispose();
				lePanel = null;
			}
		}

		/// /////////////////////////////////////////////////////
		public void Init ( CParametrePlanificationTache parametre )
		{
			m_lnkAjouterPlanification.Focus();
			ArrayList lst = new ArrayList ( m_panelPlanifications.Controls );
			foreach ( Control ctrl in lst )
			{
				ctrl.Parent.Controls.Remove(ctrl);
				ctrl.Dispose();
			}
			m_panelPlanifications.Controls.Clear();
			foreach ( CPlanificationTache planif in parametre.Planifications )
			{
				CPanelIncorporePanelPlanification lePanel = CreateNewPanel();
				lePanel.Init(planif );
				lePanel.Collapse();
			}
		}

		/// /////////////////////////////////////////////////////
		public CResultAErreur ValideDonnees()
		{
			CResultAErreur result  = CResultAErreur.True;
			m_parametre.ResetPlanifications();
			foreach ( CPanelIncorporePanelPlanification lePanel in m_panelPlanifications.Controls )
			{
				if ( lePanel != null  )
				{
					result = lePanel.MajChamps();
					if ( !result )
						return result;
					m_parametre.AddPlanification ( lePanel.Planification );
				}
			}
			return result;
		}

		private void m_btnLock_Click(object sender, System.EventArgs e)
		{
		}

		/// /////////////////////////////////////////////////////
		public CParametrePlanificationTache ParametrePlanification
		{
			get
			{
				return m_parametre;
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
					OnChangeLockEdition(this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion
	}
}
