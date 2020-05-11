using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using timos.acteurs;
using sc2i.win32.data;
using sc2i.multitiers.client;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.common;

namespace timos
{
    //[sc2i.win32.data.navigation.ObjectListeur(typeof(CActeur))]
	[DynamicForm("Activity members list")]
	public class CFormListeActiviteActeurs : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------
		public CFormListeActiviteActeurs()
			:base(typeof(CActeur))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			FiltreRapide = CFournisseurFiltreRapide.GetFiltreRapideForType ( typeof(CActeur) );
		}
		//-------------------------------------------------------------------
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
		//------------------------------------------------------------------------
		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeActiviteActeurs));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn10 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn11 = new sc2i.win32.common.GLColumn();
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
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Nom";
            glColumn1.Text  = "Name|164";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 120;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namex";
            glColumn2.Propriete = "Adresse";
            glColumn2.Text = "Address|755";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 120;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Namexx";
            glColumn3.Propriete = "CodePostal";
            glColumn3.Text = "Post code|756";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 120;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Namexxx";
            glColumn4.Propriete = "Ville";
            glColumn4.Text = "City|757";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 120;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Namexxxx";
            glColumn5.Propriete = "Telephone1";
            glColumn5.Text = "Phone 1|30293";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 120;
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Namexxxxx";
            glColumn6.Propriete = "Telephone2";
            glColumn6.Text = "Phoen 2|30294";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 120;
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "Namexxxxxx";
            glColumn7.Propriete = "Telephone3";
            glColumn7.Text = "Phone 3|30295";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 120;
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Namexxxxxxx";
            glColumn8.Propriete = "Portable";
            glColumn8.Text = "Mobile|30296";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 120;
            glColumn9.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn9.ActiveControlItems")));
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "Namexxxxxxxx";
            glColumn9.Propriete = "Fax";
            glColumn9.Text = "Fax|30297";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 120;
            glColumn10.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn10.ActiveControlItems")));
            glColumn10.BackColor = System.Drawing.Color.Transparent;
            glColumn10.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn10.ForColor = System.Drawing.Color.Black;
            glColumn10.ImageIndex = -1;
            glColumn10.IsCheckColumn = false;
            glColumn10.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn10.Name = "Namexxxxxxxxx";
            glColumn10.Propriete = "SiteWeb";
            glColumn10.Text = "Web site|30299";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 120;
            glColumn11.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn11.ActiveControlItems")));
            glColumn11.BackColor = System.Drawing.Color.Transparent;
            glColumn11.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn11.ForColor = System.Drawing.Color.Black;
            glColumn11.ImageIndex = -1;
            glColumn11.IsCheckColumn = false;
            glColumn11.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn11.Name = "Namexxxxxxxxxx";
            glColumn11.Propriete = "EMail";
            glColumn11.Text = "E-mail|30298";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn11.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10,
            glColumn11});
            this.m_panelListe.Size = new System.Drawing.Size(743, 520);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 520);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(743, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 520);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 520);
            this.m_panelBas.Size = new System.Drawing.Size(743, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(743, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Size = new System.Drawing.Size(743, 520);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormListeActiviteActeurs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(743, 520);
            this.Name = "CFormListeActiviteActeurs";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormListeActiviteActeurs_Load);
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CActeur),
				typeof(CFormEditionActiviteActeur),
				null, "");
			
			m_panelListe.ControlFiltreStandard = new CPanelFiltreActeur();
			//m_panelListe.ControlFiltre = new CPanelFiltreFormListStd(typeof(CActeur));
			
			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Activity followup list|883");
		}

		//-------------------------------------------------------------------
		private void CFormListeActiviteActeurs_Load(object sender, System.EventArgs e)
		{
		}
		//-------------------------------------------------------------------
	}
}

