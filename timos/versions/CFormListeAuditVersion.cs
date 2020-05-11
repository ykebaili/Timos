using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using timos.data.version;
using sc2i.common;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data;
using sc2i.win32.data.navigation;


namespace timos.version
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CAuditVersion))]
	public class CFormListeAuditVersion :
		CFormListeStandardTimos,
		IFormNavigable
	{
		#region Designer generated code
		//-------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilis�es.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// M�thode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette m�thode avec l'�diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeAuditVersion));
			this.m_panelMilieu.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelListe
			// 
			glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "c_colLibelle";
			glColumn1.Propriete = "Libelle";
			glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 350;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
			this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelGauche
			// 
			this.m_panelGauche.Size = new System.Drawing.Size(0, 376);
			this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelDroit
			// 
			this.m_panelDroit.Location = new System.Drawing.Point(448, 0);
			this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
			this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelBas
			// 
			this.m_panelBas.Location = new System.Drawing.Point(0, 376);
			this.m_panelBas.Size = new System.Drawing.Size(448, 0);
			this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelHaut
			// 
			this.m_panelHaut.Size = new System.Drawing.Size(448, 0);
			this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelMilieu
			// 
			this.m_panelMilieu.Size = new System.Drawing.Size(448, 376);
			this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// CFormListeAuditVersion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeAuditVersion";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelMilieu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region :: Propri�t�s ::
		private System.ComponentModel.IContainer components = null;
		private string m_strCodeRole = "";
		#endregion

		#region ++ Constructeurs ++

		//-------------------------------------------------------------------
		public CFormListeAuditVersion()
			: base(typeof(CAuditVersion))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------
		public CFormListeAuditVersion(string strCodeRole)
			: base(typeof(CAuditVersion))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_strCodeRole = strCodeRole;
		}
		#endregion

		#region ~~ M�thodes ~~
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CAuditVersion),
				null, "");

			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("List of Version Audits|20036");
		}
		#endregion

	}
}



