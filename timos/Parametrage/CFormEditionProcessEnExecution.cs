using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using sc2i.process;
using sc2i.win32.data.navigation;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CProcessEnExecutionInDb))]
	public class CFormEditionProcessEnExecution : CFormEditionStdTimos, IFormNavigable
	{
		private sc2i.win32.common.C2iPanelOmbre m_panel;
		private sc2i.win32.process.CPanelDebugProcess m_panelDebug;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionProcessEnExecution()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProcessEnExecution(CProcessEnExecutionInDb processEnExec)
			:base(processEnExec)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProcessEnExecution(CProcessEnExecutionInDb processEnExec,CListeObjetsDonnees liste)
			:base(processEnExec, liste)
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
		//-------------------------------------------------------------------------
		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_panel = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelDebug = new sc2i.win32.process.CPanelDebugProcess();
            this.m_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panel
            // 
            this.m_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panel.Controls.Add(this.m_panelDebug);
            this.m_panel.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panel, "");
            this.m_panel.Location = new System.Drawing.Point(8, 40);
            this.m_panel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(822, 490);
            this.m_extStyle.SetStyleBackColor(this.m_panel, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panel, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panel.TabIndex = 4004;
            // 
            // m_panelDebug
            // 
            this.m_panelDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_panelDebug, "");
            this.m_panelDebug.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDebug, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDebug.Name = "m_panelDebug";
            this.m_panelDebug.Size = new System.Drawing.Size(806, 474);
            this.m_extStyle.SetStyleBackColor(this.m_panelDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDebug.TabIndex = 3;
            this.m_panelDebug.Load += new System.EventHandler(this.m_panelDebug_Load);
            // 
            // CFormEditionProcessEnExecution
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_panel);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionProcessEnExecution";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panel, 0);
            this.m_panel.ResumeLayout(false);
            this.m_panel.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CProcessEnExecutionInDb ProcessEnExecution
		{
			get
			{
				return (CProcessEnExecutionInDb) ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			
			AffecterTitre(I.T("Running Process|30227") + ProcessEnExecution.Libelle);

			m_panelDebug.OnShowObject = new sc2i.win32.process.CPanelDebugProcess.ShowObjetDelegate(ShowObjet);
			m_panelDebug.Init ( ProcessEnExecution );
			
			return result;
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			
			return result;
		}
		
		//-------------------------------------------------------------------------
		private void ShowObjet ( object obj )
		{
			if ( !(obj is CObjetDonnee) )
				CFormAlerte.Afficher(I.T("Not available|917"), EFormAlerteType.Exclamation);
			else
			{
                //Type typeForm = CFormFinder.GetTypeFormToEdit(obj.GetType());
                //if ( typeForm == null || !typeForm.IsSubclassOf(typeof(CFormEditionStandard)))
                //{
                //    CFormAlerte.Afficher("Non disponible", EFormAlerteType.Exclamation);
                //    return;
                //}
                //CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(typeForm, new object[]{obj});
                //CSc2iWin32DataNavigation.Navigateur.AffichePage ( form );
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(obj.GetType());
                if (refTypeForm == null)
                {
                    CFormAlerte.Afficher(I.T("No available Form|30229"), EFormAlerteType.Exclamation);
                    return;
                }
                CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)obj) as CFormEditionStandard;
                if (form != null)
                    CSc2iWin32DataNavigation.Navigateur.AffichePage(form);

			}
		}

        private void m_panelDebug_Load(object sender, EventArgs e)
        {

        }

	}
}

