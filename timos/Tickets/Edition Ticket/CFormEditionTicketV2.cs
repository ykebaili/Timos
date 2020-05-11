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

using timos.acteurs;
using timos.data;

namespace timos
{
    [DynamicForm("Ticket editing form", "GetInfosParametres")]
	//[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTicket))]
	public class CFormEditionTicketV2 : CFormEditionStdTimos, IFormNavigable, IFormDynamiqueAParametres
    {
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTicketV2()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTicketV2(CTicket ticket)
			:base(ticket)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTicketV2(CTicket ticket, CListeObjetsDonnees liste)
            : base(ticket, liste)
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
            this.m_panelTotal = new System.Windows.Forms.Panel();
            this.m_splitterDetail = new System.Windows.Forms.Splitter();
            this.m_barreDetail = new Crownwood.DotNetMagic.Controls.SlidingTitleBar();
            this.m_splitterGauche = new System.Windows.Forms.Splitter();
            this.m_barreGauche = new Crownwood.DotNetMagic.Controls.SlidingTitleBar();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_barreDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_barreGauche)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(999, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(629, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(849, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTotal.BackColor = System.Drawing.Color.White;
            this.m_panelTotal.Controls.Add(this.m_splitterDetail);
            this.m_panelTotal.Controls.Add(this.m_barreDetail);
            this.m_panelTotal.Controls.Add(this.m_splitterGauche);
            this.m_panelTotal.Controls.Add(this.m_barreGauche);
            this.m_extLinkField.SetLinkField(this.m_panelTotal, "");
            this.m_panelTotal.Location = new System.Drawing.Point(0, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(849, 548);
            this.m_extStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTotal.TabIndex = 4004;
            // 
            // m_splitterDetail
            // 
            this.m_splitterDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_splitterDetail, "");
            this.m_splitterDetail.Location = new System.Drawing.Point(201, 184);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitterDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitterDetail.Name = "m_splitterDetail";
            this.m_splitterDetail.Size = new System.Drawing.Size(648, 3);
            this.m_extStyle.SetStyleBackColor(this.m_splitterDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitterDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitterDetail.TabIndex = 3;
            this.m_splitterDetail.TabStop = false;
            // 
            // m_barreDetail
            // 
            this.m_barreDetail.Arrows = true;
            this.m_barreDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_barreDetail.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
            this.m_extLinkField.SetLinkField(this.m_barreDetail, "");
            this.m_barreDetail.Location = new System.Drawing.Point(201, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_barreDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_barreDetail.MouseOverColor = System.Drawing.Color.Empty;
            this.m_barreDetail.Name = "m_barreDetail";
            // 
            // 
            // 
            this.m_barreDetail.Panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_barreDetail.Panel.Location = new System.Drawing.Point(0, 26);
            this.m_barreDetail.Panel.Name = "";
            this.m_barreDetail.Panel.Size = new System.Drawing.Size(646, 156);
            this.m_barreDetail.Panel.TabIndex = 1;
            this.m_barreDetail.Size = new System.Drawing.Size(648, 184);
            this.m_barreDetail.SlideOnHover = false;
            this.m_extStyle.SetStyleBackColor(this.m_barreDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_barreDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_barreDetail.TabIndex = 2;
            this.m_barreDetail.Text = "Detail|329";
            this.m_barreDetail.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // m_splitterGauche
            // 
            this.m_extLinkField.SetLinkField(this.m_splitterGauche, "");
            this.m_splitterGauche.Location = new System.Drawing.Point(198, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitterGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitterGauche.Name = "m_splitterGauche";
            this.m_splitterGauche.Size = new System.Drawing.Size(3, 548);
            this.m_extStyle.SetStyleBackColor(this.m_splitterGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitterGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitterGauche.TabIndex = 1;
            this.m_splitterGauche.TabStop = false;
            // 
            // m_barreGauche
            // 
            this.m_barreGauche.ArrowAlignment = Crownwood.DotNetMagic.Controls.ImageAlignment.Near;
            this.m_barreGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_barreGauche.Edge = Crownwood.DotNetMagic.Controls.TitleEdge.Left;
            this.m_barreGauche.GradientDirection = Crownwood.DotNetMagic.Controls.GradientDirection.TopToBottom;
            this.m_extLinkField.SetLinkField(this.m_barreGauche, "");
            this.m_barreGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_barreGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_barreGauche.MouseOverColor = System.Drawing.Color.Empty;
            this.m_barreGauche.Name = "m_barreGauche";
            // 
            // 
            // 
            this.m_barreGauche.Panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_barreGauche.Panel.Location = new System.Drawing.Point(26, 0);
            this.m_barreGauche.Panel.Name = "";
            this.m_barreGauche.Panel.Size = new System.Drawing.Size(170, 546);
            this.m_barreGauche.Panel.TabIndex = 1;
            this.m_barreGauche.Size = new System.Drawing.Size(198, 548);
            this.m_extStyle.SetStyleBackColor(this.m_barreGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_barreGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_barreGauche.TabIndex = 0;
            this.m_barreGauche.Text = "slidingTitleBar1";
            this.m_barreGauche.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CFormEditionTicketV2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(849, 583);
            this.Controls.Add(this.m_panelTotal);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTicketV2";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.AfterAnnulationModification += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionTicket_AfterAnnulationModification);
            this.Controls.SetChildIndex(this.m_panelTotal, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panelTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_barreDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_barreGauche)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTicket Ticket
		{
			get
			{
				return (CTicket)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Ticket number|666")+" :" + Ticket.Numero);


            // Si le ticket est clos il ne peut plus être édité
            if (Ticket.DateCloture != null ||
                Ticket.Responsable != CUtilSession.GetUserForSession(Ticket.ContexteDonnee))
            {
                this.ConsultationOnly = true;
                
            }
            else
                this.ConsultationOnly = false;


            if (Ticket.IsNew())
            {
                Ticket.CreerHistorique(null, I.T("Ticket opening|675"));
            }


            // Barre gauche
            m_barreGauche.Text = I.T("General information|10015");
            CPanelInfosGenerales panelInfos = new CPanelInfosGenerales();
            panelInfos.Dock = DockStyle.Fill;
            panelInfos.InitPanel(Ticket);
            m_barreGauche.Panel.Controls.Add(panelInfos);

            // Barre détail
            m_barreDetail.PostText = I.T("Ticket Number @1 |30260", Ticket.Numero.ToString());



			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();


            return result;

        }

        //-------------------------------------------------------------------------
        private void m_panelEditionTicket_OnCloseTicket(object sender, EventArgs e)
        {
            this.OnClickValider();
			if ( !m_gestionnaireModeEdition.ModeEdition )//La validation a réussi
				this.ConsultationOnly = true;
        }

        //-------------------------------------------------------------------------
        private void CFormEditionTicket_AfterAnnulationModification(object sender, CObjetDonneeEventArgs args)
        {
            if (this.Navigateur != null && this.Navigateur is CFormNavigateurPopup)
            {
                this.Navigateur.Close();
            }
        }

        #region IFormDynamiqueAParametres Membres

        public CResultAErreur SetParametres(System.Collections.Generic.Dictionary<string, object> dicParametres)
        {
            CResultAErreur result = CResultAErreur.True;

            object obj = null;
            if (dicParametres.TryGetValue(c_nomParametreId, out obj))
            {
                if (obj is int)
                {
                    int nId = (int)obj;
                    CTicket ticket = new CTicket(CSc2iWin32DataClient.ContexteCourant);

                    if (nId == -1)
                    {
                        ticket.CreateNew();
                    }
                    else if (!ticket.ReadIfExists(nId))
                    {
                        result.EmpileErreur(I.T("There is no Crystal Report Model corresponding to the Id: @1|10006", nId.ToString()));
                        return result;
                    }

                    // Affecte le ticket édité
                    this.ObjetEdite = ticket;    

                }
                else
                {
                    result.EmpileErreur(I.T("The Ticket ID parameter must be an integer value|10007"));
                }

            }

            return result;
        }

        private Panel m_panelTotal;
        private Crownwood.DotNetMagic.Controls.SlidingTitleBar m_barreGauche;
        private Splitter m_splitterDetail;
        private Crownwood.DotNetMagic.Controls.SlidingTitleBar m_barreDetail;
        private Splitter m_splitterGauche;

        private const string c_nomParametreId = "TICKET_ID";
        // Retournes les informations de paramètres disponibles pour ce formulaire
        public static CInfoParametreDynamicForm[] GetInfosParametres()
        {
            return new CInfoParametreDynamicForm[]{
                new CInfoParametreDynamicForm(c_nomParametreId, typeof(int), "The ticket ID to be edited. If this ID equals -1 a new Ticket is created")
            };
            
        }

        #endregion
    }
}

