using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CTypeOccupationHoraire))]
	public class CFormListeTypeOccupationHoraire : CFormListeStandardTimos, IFormNavigable
	{
		private LinkLabel m_lnkOrdonnerElements;
        private sc2i.win32.common.C2iPanelFondDegradeStd c2iPanelFondDegradeStd1;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeTypeOccupationHoraire()
			:base(typeof(CTypeOccupationHoraire))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeTypeOccupationHoraire));
            this.m_lnkOrdonnerElements = new System.Windows.Forms.LinkLabel();
            this.c2iPanelFondDegradeStd1 = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_panelMilieu.SuspendLayout();
            this.c2iPanelFondDegradeStd1.SuspendLayout();
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
            glColumn1.Propriete = "Libelle";
            glColumn1.Text  = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.Size = new System.Drawing.Size(660, 376);
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
            this.m_panelDroit.Location = new System.Drawing.Point(660, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(660, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(660, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.c2iPanelFondDegradeStd1);
            this.m_panelMilieu.Size = new System.Drawing.Size(660, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.c2iPanelFondDegradeStd1, 0);
            // 
            // m_lnkOrdonnerElements
            // 
            this.m_lnkOrdonnerElements.AutoSize = true;
            this.m_lnkOrdonnerElements.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkOrdonnerElements.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkOrdonnerElements.Location = new System.Drawing.Point(10, 6);
            this.m_lnkOrdonnerElements.Name = "m_lnkOrdonnerElements";
            this.m_lnkOrdonnerElements.Size = new System.Drawing.Size(40, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkOrdonnerElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkOrdonnerElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOrdonnerElements.TabIndex = 6;
            this.m_lnkOrdonnerElements.TabStop = true;
            this.m_lnkOrdonnerElements.Text = "Sort|19";
            this.m_lnkOrdonnerElements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOrdonnerElements_LinkClicked);
            // 
            // c2iPanelFondDegradeStd1
            // 
            this.c2iPanelFondDegradeStd1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("c2iPanelFondDegradeStd1.BackgroundImage")));
            this.c2iPanelFondDegradeStd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lnkOrdonnerElements);
            this.c2iPanelFondDegradeStd1.Location = new System.Drawing.Point(371, 1);
            this.c2iPanelFondDegradeStd1.Name = "c2iPanelFondDegradeStd1";
            this.c2iPanelFondDegradeStd1.Size = new System.Drawing.Size(100, 24);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelFondDegradeStd1.TabIndex = 7;
            // 
            // CFormListeTypeOccupationHoraire
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(660, 376);
            this.Name = "CFormListeTypeOccupationHoraire";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CTypeOccupationHoraire),	
				typeof(CFormEditionTypeOccupationHoraire),
				null, "");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Occupation Type list|998");
		}

		private void m_lnkOrdonnerElements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormOrdonnerEntites.ModifieOrdre(m_listeObjets, "Libelle", "Priorite");
		}
		//-------------------------------------------------------------------
	}
}

