using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using sc2i.win32.data.navigation;

using timos.acteurs;
using timos.data;
using sc2i.multitiers.client;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CTicket))]
	public class CFormListeTicket : CFormListeStandardTimos, IFormNavigable
    {
        private LinkLabel m_lnkNouveauTicket;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeTicket()
			:base(typeof(CTicket))
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
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeTicket));
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn10 = new sc2i.win32.common.GLColumn();
            this.m_lnkNouveauTicket = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelHaut.SuspendLayout();
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListe.Text = "Liste";
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
            this.m_panelListe.BoutonSupprimerVisible = false;
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Num";
            glColumn6.Propriete = "Numero";
            glColumn6.Text = "Number|30317";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 120;
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "Auteur";
            glColumn7.Propriete = "Auteur.Acteur.IdentiteComplete";
            glColumn7.Text = "Author|30318";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 100;
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Client";
            glColumn8.Propriete = "Client.Acteur.IdentiteComplete";
            glColumn8.Text = "Customer|30319";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            glColumn9.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn9.ActiveControlItems")));
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "DateOuvert";
            glColumn9.Propriete = "DateOuverture";
            glColumn9.Text = "Opening date|30131";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 100;
            glColumn10.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn10.ActiveControlItems")));
            glColumn10.BackColor = System.Drawing.Color.Transparent;
            glColumn10.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn10.ForColor = System.Drawing.Color.Black;
            glColumn10.ImageIndex = -1;
            glColumn10.IsCheckColumn = false;
            glColumn10.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn10.Name = "Etat";
            glColumn10.Propriete = "EtatToString";
            glColumn10.Text = "State|57";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 100;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn6,
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10});
            this.m_panelListe.Size = new System.Drawing.Size(719, 450);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Location = new System.Drawing.Point(0, 16);
            this.m_panelGauche.Size = new System.Drawing.Size(0, 450);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(719, 16);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 450);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 466);
            this.m_panelBas.Size = new System.Drawing.Size(719, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_lnkNouveauTicket);
            this.m_panelHaut.Size = new System.Drawing.Size(719, 16);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Location = new System.Drawing.Point(0, 16);
            this.m_panelMilieu.Size = new System.Drawing.Size(719, 450);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkNouveauTicket
            // 
            this.m_lnkNouveauTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkNouveauTicket.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkNouveauTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkNouveauTicket.Location = new System.Drawing.Point(25, 2);
            this.m_lnkNouveauTicket.Name = "m_lnkNouveauTicket";
            this.m_lnkNouveauTicket.Size = new System.Drawing.Size(194, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNouveauTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNouveauTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNouveauTicket.TabIndex = 5;
            this.m_lnkNouveauTicket.TabStop = true;
            this.m_lnkNouveauTicket.Text = "New ticket...|10028";
            this.m_lnkNouveauTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNouveauTicket_LinkClicked);
            // 
            // CFormListeTicket
            // 
            this.AffichePanelHaut = true;
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(719, 466);
            this.Name = "CFormListeTicket";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//--------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CTicket),	
				null, "");

			m_panelListe.RemplirGrille();

            AppliqueRestrictions();
		}
		
        //--------------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Tickets list|730");
		}

        //--------------------------------------------------------------------------
        private void m_lnkNouveauTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Créer un nouveau ticket
            CTicket ticket = new CTicket(m_listeObjets.ContexteDonnee);
            ticket.CreateNew();
            // Edition dans un nouvel onglet

            CReferenceTypeForm rTpForm = CFormFinder.GetRefFormToEdit(typeof(CTicket));
            if (rTpForm != null)
            {
                IFormNavigable form = rTpForm.GetForm(ticket) as IFormNavigable;
                if(form != null)
                    CTimosApp.Navigateur.AffichePageDansNouvelOnglet(form);
            }
            
            //CFormNavigateurPopup.Show(new CFormEditionTicket(ticket),FormWindowState.Maximized);

            InitPanel();
        }

        private void AppliqueRestrictions()
        {
            IInfoUtilisateur infoUser = CTimosApp.SessionClient.GetInfoUtilisateur();
            
            if (infoUser != null)
            {
                int? nIdVersion = CSc2iWin32DataClient.ContexteCourant.IdVersionDeTravail;
                CListeRestrictionsUtilisateurSurType restrictions = infoUser.GetListeRestrictions(nIdVersion);

                if (restrictions != null)
                {
                    CRestrictionUtilisateurSurType rest;
                    rest = restrictions.GetRestriction(typeof(CTicket));

                    switch (rest.RestrictionGlobale)
                    {
                        case ERestriction.Aucune:
                            m_lnkNouveauTicket.Visible = true;
                            break;
                        case ERestriction.Hide:
                            m_lnkNouveauTicket.Visible = false;
                            break;
                        case ERestriction.NoCreate:
                            m_lnkNouveauTicket.Visible = false;
                            break;
                        case ERestriction.NoDelete:
                            m_lnkNouveauTicket.Visible = true;
                            break;
                        case ERestriction.ReadOnly:
                            m_lnkNouveauTicket.Visible = false;
                            break;
                        default:
                            m_lnkNouveauTicket.Visible = true;
                            break;
                    }
                }
            }
            
        }
	}
}

