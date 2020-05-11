using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;


using timos.data;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CIntervention))]
	public class CFormEditionIntervention : CFormEditionStdTimos, IFormNavigable
	{
		private timos.interventions.CPanelEditIntervention m_panelIntervention;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionIntervention()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionIntervention(CIntervention tache)
			:base(tache)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionIntervention(CIntervention tache, CListeObjetsDonnees liste)
			:base(tache, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_panelIntervention = new timos.interventions.CPanelEditIntervention();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelIntervention
			// 
			this.m_panelIntervention.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelIntervention.BackColor = System.Drawing.Color.White;
			this.m_panelIntervention.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panelIntervention, "");
			this.m_panelIntervention.Location = new System.Drawing.Point(0, 40);
			this.m_panelIntervention.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelIntervention.Name = "m_panelIntervention";
			this.m_panelIntervention.Size = new System.Drawing.Size(830, 490);
			this.m_extStyle.SetStyleBackColor(this.m_panelIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelIntervention.TabIndex = 4004;
			this.m_panelIntervention.Visible = false;
			this.m_panelIntervention.SaveRequired += new System.ComponentModel.CancelEventHandler(this.m_panelIntervention_SaveRequired);
			// 
			// CFormEditionIntervention
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_panelIntervention);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionIntervention";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.AfterAnnulationModification += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionIntervention_AfterAnnulationModification);
			this.AfterValideModification += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionIntervention_AfterValideModification);
			this.Controls.SetChildIndex(this.m_panelIntervention, 0);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CIntervention Intervention
		{
			get
			{
				return (CIntervention)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(Intervention.DescriptionElement);

			m_panelIntervention.InitChamps(Intervention);

			m_panelIntervention.Visible = true;
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (result)
				result = m_panelIntervention.MajChamps();
			return result;
        }

        //-------------------------------------------------------------------------
        private void CFormEditionIntervention_AfterAnnulationModification(object sender, CObjetDonneeEventArgs args)
        {
            if (this.Navigateur != null && this.Navigateur is CFormNavigateurPopup)
            {
                this.Navigateur.Close();
            }
        }

        //-------------------------------------------------------------------------
        private void CFormEditionIntervention_AfterValideModification(object sender, CObjetDonneeEventArgs args)
        {
            if (this.Navigateur != null && this.Navigateur is CFormNavigateurPopup)
            {
                this.Navigateur.Close();
            }
        }

		//-------------------------------------------------------------------------
		private void m_panelIntervention_SaveRequired(object sender, CancelEventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				e.Cancel = !OnClickValider();
			}
		}
	}
}

