using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;

using timos.acteurs;
using timos.data.supervision;
using timos.data.snmp;

namespace timos.snmp
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CEntiteSnmp))]
	public class CFormListeEntiteSnmps : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeEntiteSnmps()
			:base(typeof(CEntiteSnmp))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		/// <summary>
		/// Nettoyage des ressources utilis�es.
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
		/// M�thode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette m�thode avec l'�diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeEntiteSnmps));
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListe.Text = "List";
            // 
            // m_btnActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActions.Text = "Actions";
            // 
            // m_panelLinkList
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imgListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelListe
            // 
            this.m_panelListe.BoutonAjouterVisible = false;
            this.m_panelListe.BoutonModifierVisible = false;
            this.m_panelListe.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.Size = new System.Drawing.Size(448, 376);
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
            // CFormListeEntiteSnmps
            // 
            this.BoutonAjouterVisible = false;
            this.BoutonModifierVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Name = "CFormListeEntiteSnmps";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CEntiteSnmp),	
				null, "");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("SNMP Entities|10301");
		}
		//-------------------------------------------------------------------
	}
}

