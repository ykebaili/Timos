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

using timos.acteurs;
using timos.data;
using System.Collections.Generic;

namespace timos
{
    /// <summary>
    /// Ce formulaire Edite la suivi d'activité d'un acteur
    /// L'Objet édité est un "Acteur"
    /// </summary>
	[DynamicForm ("Member activity", "GetInfosParametres")]
	public class CFormEditionActiviteActeur : CFormEditionStdTimos, IFormNavigable,
		IFormDynamiqueAParametres
	{
		private const string c_parametreIdActeur = "MEMBER_ID";

		private System.Windows.Forms.Label lbl_nomcollaborateur;
		private sc2i.win32.common.C2iTextBox m_txtIdentite;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageSaisiActivite;
		private CControleSaisieDesActivitesActeur m_panelSaisie;
		private System.ComponentModel.IContainer components = null;

		private DateTime m_dateDebut = DateTime.Now.Date;
		private DateTime m_dateFin = DateTime.Now.Date.AddDays(1);

		public CFormEditionActiviteActeur()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionActiviteActeur(CActeur acteur)
            : base(acteur)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionActiviteActeur(CActeur acteur, CListeObjetsDonnees liste)
            : base(acteur, liste)
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
            this.lbl_nomcollaborateur = new System.Windows.Forms.Label();
            this.m_txtIdentite = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSaisiActivite = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSaisie = new timos.CControleSaisieDesActivitesActeur();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageSaisiActivite.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(612, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(528, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(748, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // lbl_nomcollaborateur
            // 
            this.m_extLinkField.SetLinkField(this.lbl_nomcollaborateur, "");
            this.lbl_nomcollaborateur.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_nomcollaborateur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_nomcollaborateur, "");
            this.lbl_nomcollaborateur.Name = "lbl_nomcollaborateur";
            this.lbl_nomcollaborateur.Size = new System.Drawing.Size(133, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_nomcollaborateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_nomcollaborateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_nomcollaborateur.TabIndex = 4002;
            this.lbl_nomcollaborateur.Text = "Collaborator identity|550";
            // 
            // m_txtIdentite
            // 
            this.m_extLinkField.SetLinkField(this.m_txtIdentite, "IdentiteComplete");
            this.m_txtIdentite.Location = new System.Drawing.Point(175, 8);
            this.m_txtIdentite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtIdentite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtIdentite, "");
            this.m_txtIdentite.Name = "m_txtIdentite";
            this.m_txtIdentite.ReadOnly = true;
            this.m_txtIdentite.Size = new System.Drawing.Size(281, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIdentite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIdentite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIdentite.TabIndex = 0;
            this.m_txtIdentite.Text = "[IdentiteComplete]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.lbl_nomcollaborateur);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtIdentite);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(488, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSaisiActivite;
            this.m_tabControl.Size = new System.Drawing.Size(716, 443);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSaisiActivite});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSaisiActivite
            // 
            this.m_pageSaisiActivite.Controls.Add(this.m_panelSaisie);
            this.m_extLinkField.SetLinkField(this.m_pageSaisiActivite, "");
            this.m_pageSaisiActivite.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSaisiActivite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSaisiActivite, "");
            this.m_pageSaisiActivite.Name = "m_pageSaisiActivite";
            this.m_pageSaisiActivite.Size = new System.Drawing.Size(700, 402);
            this.m_extStyle.SetStyleBackColor(this.m_pageSaisiActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSaisiActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSaisiActivite.TabIndex = 10;
            this.m_pageSaisiActivite.Title = "Enter Activity times|551";
            // 
            // m_panelSaisie
            // 
            this.m_panelSaisie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelSaisie, "");
            this.m_panelSaisie.Location = new System.Drawing.Point(0, 0);
            this.m_panelSaisie.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSaisie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSaisie, "");
            this.m_panelSaisie.Name = "m_panelSaisie";
            this.m_panelSaisie.Size = new System.Drawing.Size(700, 399);
            this.m_extStyle.SetStyleBackColor(this.m_panelSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSaisie.TabIndex = 0;
            this.m_panelSaisie.OnChangeDates += new System.EventHandler(this.m_panelSaisie_OnChangeDates);
            // 
            // CFormEditionActiviteActeur
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(748, 569);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionActiviteActeur";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageSaisiActivite.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		void m_panelSaisie_OnChangeDates(object sender, EventArgs e)
		{
			if (m_bIsPanelSaisieInit)
			{
				m_dateDebut = m_panelSaisie.DateDebut;
				m_dateFin = m_panelSaisie.DateFin;
			}
		}
		#endregion

		//-------------------------------------------------------------------------
		public static CInfoParametreDynamicForm[] GetInfosParametres()
		{
			List<CInfoParametreDynamicForm> lst = new List<CInfoParametreDynamicForm>();
			lst.Add ( new CInfoParametreDynamicForm ( c_parametreIdActeur, typeof(int), 
				I.T("Member Id for activity editing|20026")));
			return lst.ToArray();
		}

		public CResultAErreur SetParametres(Dictionary<string, object> dicParametres)
		{
			CResultAErreur result = CResultAErreur.True;
			object valeur = null;
			if (dicParametres.TryGetValue(c_parametreIdActeur, out valeur))
			{
				if (valeur is int)
				{
					CActeur acteur = new CActeur(CSc2iWin32DataClient.ContexteCourant);
					if (!acteur.ReadIfExists((int)valeur))
					{
						result.EmpileErreur(I.T("Member @1 doesn't exist|20027", valeur.ToString()));
						return result;
					}
					ObjetEdite = acteur;
					return result;
				}
			}
			result.EmpileErreur(I.T("Incorrect value for parameter  @1|20028", c_parametreIdActeur));
			return result;
		}

		//-------------------------------------------------------------------------
		private CActeur Acteur
		{
			get
			{
				return (CActeur)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		public DateTime DateDebut
		{
			get
			{
				return m_dateDebut;
			}
			set
			{
				m_dateDebut = value;
			}
		}

		//-------------------------------------------------------------------------
		public DateTime DateFin
		{
			get
			{
				return m_dateFin;
			}
			set
			{
				m_dateFin = value;
			}
		}

		//-------------------------------------------------------------------------
		private bool m_bIsPanelSaisieInit = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bIsPanelSaisieInit = false;
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Activity follow-up of @1|30315 ",Acteur.IdentiteCompleteAmelioree));

            m_panelSaisie.Init(Acteur, m_dateDebut, m_dateFin );
			m_bIsPanelSaisieInit = true;
			m_tabControl.SelectedIndex = 0;
			
            return result;
		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

			result = m_panelSaisie.Maj_Champs();

			EvenementAttribute.StockeDeclenchement(Acteur, CActeur.c_evenementValidationFicheActivite);

            return result;
        }

		//-------------------------------------------------------------------------
		public override CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable ctx = base.GetContexte();
			ctx["DATE_DEBUT"] = m_dateDebut;
			ctx["DATE_FIN"] = m_dateFin;
			return ctx;
		}

		public override CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
		{
			if (ctx["DATE_DEBUT"] is DateTime)
				m_dateDebut = (DateTime)ctx["DATE_DEBUT"];
			if (ctx["DATE_FIN"] is DateTime)
				m_dateFin = (DateTime)ctx["DATE_FIN"];
			CResultAErreur  result = base.InitFromContexte(ctx);
			return result;
			
		}

	
	}
}

