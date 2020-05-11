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
using sc2i.workflow;
using timos.win32.composants;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CModeleTexte))]
	public class CFormEditionModeleTexte : CFormEditionStdTimos, IFormNavigable
	{

		private CPanelEditModeleTexte m_panelModele;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionModeleTexte()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionModeleTexte(CModeleTexte ModeleTexte)
			:base(ModeleTexte)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionModeleTexte(CModeleTexte ModeleTexte, CListeObjetsDonnees liste)
			:base(ModeleTexte, liste)
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
            this.m_panelModele = new timos.win32.composants.CPanelEditModeleTexte();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(725, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelModele
            // 
            this.m_panelModele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelModele.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_panelModele, "");
            this.m_panelModele.Location = new System.Drawing.Point(0, 34);
            this.m_panelModele.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelModele, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelModele.Name = "m_panelModele";
            this.m_panelModele.Size = new System.Drawing.Size(725, 474);
            this.m_extStyle.SetStyleBackColor(this.m_panelModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelModele.TabIndex = 4004;
            // 
            // CFormEditionModeleTexte
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(725, 507);
            this.Controls.Add(this.m_panelModele);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionModeleTexte";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelModele, 0);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CModeleTexte ModeleTexte
		{
			get
			{
				return (CModeleTexte)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre ( I.T( "Text model|471"));
			result = m_panelModele.Init(ModeleTexte);
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
			CResultAErreur  result = base.MAJ_Champs();
			if (result)
				result = m_panelModele.MAJ_Champs();
			return result;
        }

		

	}
}

