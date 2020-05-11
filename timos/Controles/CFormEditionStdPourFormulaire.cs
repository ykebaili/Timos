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
using sc2i.formulaire;
using sc2i.win32.data.dynamic;
using sc2i.multitiers.client;
using sc2i.expression;
using timos.Controles;
using System.Collections.Generic;

namespace timos
{
    [AutoExec("Autoexec")]
	public class CFormEditionStdPourFormulaire : CFormEditionStdTimos, 
                                                IFormNavigable,
                                                IFormRecepteurFormulaire
    {
        private List<CDbKey> m_listeIdsFormulaires = new List<CDbKey>();
        private CPanelChampsCustom m_panelRecepteurFormulaires;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionStdPourFormulaire()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionStdPourFormulaire(CObjetDonneeAIdNumeriqueAuto objetDonnee)
			:base(objetDonnee)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionStdPourFormulaire(CObjetDonneeAIdNumeriqueAuto objetDonnee, CListeObjetsDonnees liste)
            : base(objetDonnee, liste)
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
            this.m_panelRecepteurFormulaires = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelRecepteurFormulaires
            // 
            this.m_panelRecepteurFormulaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelRecepteurFormulaires.BoldSelectedPage = true;
            this.m_panelRecepteurFormulaires.ControlBottomOffset = 16;
            this.m_panelRecepteurFormulaires.ControlRightOffset = 16;
            this.m_panelRecepteurFormulaires.ElementEdite = null;
            this.m_panelRecepteurFormulaires.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelRecepteurFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelRecepteurFormulaires, false);
            this.m_panelRecepteurFormulaires.Location = new System.Drawing.Point(12, 43);
            this.m_panelRecepteurFormulaires.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRecepteurFormulaires, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelRecepteurFormulaires, "");
            this.m_panelRecepteurFormulaires.Name = "m_panelRecepteurFormulaires";
            this.m_panelRecepteurFormulaires.Ombre = true;
            this.m_panelRecepteurFormulaires.PositionTop = true;
            this.m_panelRecepteurFormulaires.Size = new System.Drawing.Size(818, 487);
            this.m_extStyle.SetStyleBackColor(this.m_panelRecepteurFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRecepteurFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRecepteurFormulaires.TabIndex = 4004;
            // 
            // CFormEditionStdPourFormulaire
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_panelRecepteurFormulaires);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionStdPourFormulaire";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionStdPourFormulaire_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelRecepteurFormulaires, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        //-------------------------------------------------------------------------
        public static void Autoexec()
        {
            CReferenceTypeFormDynamic.SetTypeFormRecepteur(typeof(CFormEditionStdPourFormulaire));
        }

        //-------------------------------------------------------------------------
        public override CReferenceTypeForm GetReferenceTypeForm()
        {
            if (m_listeIdsFormulaires.Count > 0)
            {
                return new CReferenceTypeFormDynamic(m_listeIdsFormulaires[0]);
            }
            return null;
        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = CResultAErreur.True;
            using (CWaitCursor waiter = new CWaitCursor())
            {
                this.SuspendDrawing();
                try
                {
                    result = base.MyInitChamps();
                    if (!result)
                        return result;

                    m_panelRecepteurFormulaires.Init(ObjetEdite, Formulaires);
                    AffecterTitre(ObjetEdite.DescriptionElement);

                }
                finally
                {
                    this.ResumeDrawing();
                }
            }

			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            result = m_panelRecepteurFormulaires.MAJ_Champs();

            return result;
        }
        
        //-------------------------------------------------------------------------
        public CDbKey IdFormulaireAffiche
        {
            get
            {
                if (m_listeIdsFormulaires.Count > 0)
                    return m_listeIdsFormulaires[0];
                return null;
            }
            set
            {
                m_listeIdsFormulaires = new List<CDbKey>() { value };
            }
        }

        //-------------------------------------------------------------------------
        public CDbKey[] IdsFormulairesAffiches
        {
            get
            {
                return m_listeIdsFormulaires.ToArray();
            }
            set
            {
                m_listeIdsFormulaires = new List<CDbKey>(value);
            }
        }

        //-------------------------------------------------------------------------
        private CFormulaire[] Formulaires
        {
            get
            {
                List<CFormulaire> listeFormulaires = new List<CFormulaire>();
                foreach (CDbKey dbKeyId in m_listeIdsFormulaires)
                {
                    CFormulaire form = new CFormulaire(ObjetEdite.ContexteDonnee);
                    if (form.ReadIfExists(dbKeyId))
                    {
                        listeFormulaires.Add(form);
                    }
                }
                return listeFormulaires.ToArray();
            }
        }

        //-------------------------------------------------------------------------
        public void CreateControles()
        {
            if (ObjetEdite == null)
                return;

            if (Formulaires.Length > 0)
            {
                C2iWnd wnd = Formulaires[0].Formulaire;
                this.DoubleBuffered = true;
                m_panelRecepteurFormulaires.BackColor = wnd.BackColor;
                m_panelRecepteurFormulaires.ForeColor = wnd.ForeColor;
                m_panelRecepteurFormulaires.Font = wnd.Font;
                m_panelRecepteurFormulaires.AutoScroll = true;
            }
            bool bHasEditMode = false;
            foreach (CFormulaire formulaire in Formulaires)
            {
                bHasEditMode |= formulaire.AllowEditMode;
            }
            ConsultationOnly = !bHasEditMode;
            
        }


        public override CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable ctx = base.GetContexte();

            if (ctx == null)
                return null;

            ctx["FORM_ID"] = m_listeIdsFormulaires;

            return ctx;
        }


        public override CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
        {
            object valeur = ctx["FORM_ID"];
            if (valeur != null)
            {
                m_listeIdsFormulaires = valeur as List<CDbKey>;
            }
            if (m_listeIdsFormulaires == null)
                m_listeIdsFormulaires = new List<CDbKey>();
            CResultAErreur result = base.InitFromContexte(ctx);

            return result;
        }

        private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, EventArgs e)
        {
            //m_createur.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
        }

        private void CFormEditionStdPourFormulaire_Load(object sender, EventArgs e)
        {
            CreateControles();
        }

    }
}

