using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using timos.acteurs;
using sc2i.common;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CUrgenceTicket))]
	public class CFormListeUrgencesTickets : CFormListeStandardTimos, IFormNavigable
	{
        private LinkLabel m_lnkOrdonnerElements;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeUrgencesTickets()
			:base(typeof(CUrgenceTicket))
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
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeUrgencesTickets));
            this.m_lnkOrdonnerElements = new System.Windows.Forms.LinkLabel();
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text  = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelListe.Size = new System.Drawing.Size(705, 405);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 405);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(705, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 405);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 405);
            this.m_panelBas.Size = new System.Drawing.Size(705, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(705, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_lnkOrdonnerElements);
            this.m_panelMilieu.Size = new System.Drawing.Size(705, 405);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_lnkOrdonnerElements, 0);
            // 
            // m_lnkOrdonnerElements
            // 
            this.m_lnkOrdonnerElements.AutoSize = true;
            this.m_lnkOrdonnerElements.Location = new System.Drawing.Point(410, 26);
            this.m_lnkOrdonnerElements.Name = "m_lnkOrdonnerElements";
            this.m_lnkOrdonnerElements.Size = new System.Drawing.Size(117, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkOrdonnerElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkOrdonnerElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOrdonnerElements.TabIndex = 5;
            this.m_lnkOrdonnerElements.TabStop = true;
            this.m_lnkOrdonnerElements.Text = "Sort Urgency Levels|59";
            this.m_lnkOrdonnerElements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CFormListeUrgencesTickets
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(705, 405);
            this.Name = "CFormListeUrgencesTickets";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelMilieu.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CUrgenceTicket),	
				null, "");

			m_panelListe.RemplirGrille();
		}

		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Ticket Urgency List|503");
		}

        //-------------------------------------------------------------------
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormOrdonnerEntites.ModifieOrdre(
                m_listeObjets,
                "Libelle",
                "Priorite");
        }
	}
}

