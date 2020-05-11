using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.navigation;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using sc2i.win32.data;
using sc2i.data;
using sc2i.formulaire.win32;
using sc2i.win32.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.Properties;
using sc2i.win32.data.navigation;
using System.Collections.Generic;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormFormulaireCustom.
	/// </summary>
    public class CFormFormulaireCustom : sc2i.win32.navigation.CFormMaxiSansMenu, IFormNavigable, IFormEditObjetDonnee, IFormAContexteDonnee
	{
        private CContexteDonnee m_contexteEdition = null;
        private CCreateur2iFormulaireV2 m_createur = null;
		private object m_objetEdite = null;
		private CFormulaire m_formulaire = null;
        private System.Windows.Forms.ToolTip m_tooltip;
        private ContextMenuStrip m_menuCustomizer;
        private ToolStripMenuItem m_menuItemCustomize;
        protected Panel m_panelEdition;
        protected Button m_btnEditerObjet;
        protected Button m_btnValiderModifications;
        protected Button m_btnAnnulerModifications;
        private sc2i.win32.common.C2iPanel m_panelFormulaire;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private System.ComponentModel.IContainer components;
        private CGestionnaireReadOnlySysteme m_gestionnaireReadOnly = new CGestionnaireReadOnlySysteme();

		public CFormFormulaireCustom()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		public CFormFormulaireCustom ( CFormulaire formulaire, object objetEdite )
		{
			m_formulaire = formulaire ;
			m_objetEdite = objetEdite;
			InitializeComponent();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormFormulaireCustom));
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_menuCustomizer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuItemCustomize = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelEdition = new System.Windows.Forms.Panel();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
            this.m_btnEditerObjet = new System.Windows.Forms.Button();
            this.m_panelFormulaire = new sc2i.win32.common.C2iPanel(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_menuCustomizer.SuspendLayout();
            this.m_panelEdition.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_menuCustomizer
            // 
            this.m_menuCustomizer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuItemCustomize});
            this.m_extModeEdition.SetModeEdition(this.m_menuCustomizer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuCustomizer.Name = "m_menuCustomizer";
            this.m_menuCustomizer.Size = new System.Drawing.Size(194, 26);
            this.m_extStyle.SetStyleBackColor(this.m_menuCustomizer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuCustomizer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_menuItemCustomize
            // 
            this.m_menuItemCustomize.Image = ((System.Drawing.Image)(resources.GetObject("m_menuItemCustomize.Image")));
            this.m_menuItemCustomize.Name = "m_menuItemCustomize";
            this.m_menuItemCustomize.Size = new System.Drawing.Size(193, 22);
            this.m_menuItemCustomize.Text = "Customize form|30067";
            this.m_menuItemCustomize.Click += new System.EventHandler(this.m_menuItemCustomize_Click);
            // 
            // m_panelEdition
            // 
            this.m_panelEdition.BackColor = System.Drawing.Color.White;
            this.m_panelEdition.Controls.Add(this.m_btnEditerObjet);
            this.m_panelEdition.Controls.Add(this.m_btnValiderModifications);
            this.m_panelEdition.Controls.Add(this.m_btnAnnulerModifications);
            this.m_panelEdition.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEdition.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelEdition, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEdition.Name = "m_panelEdition";
            this.m_panelEdition.Size = new System.Drawing.Size(684, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEdition.TabIndex = 4001;
            this.m_panelEdition.Visible = false;
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValiderModifications.Image")));
            this.m_btnValiderModifications.Location = new System.Drawing.Point(80, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValiderModifications.TabIndex = 2;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // m_btnAnnulerModifications
            // 
            this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnulerModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnulerModifications.Image")));
            this.m_btnAnnulerModifications.Location = new System.Drawing.Point(120, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
            this.m_btnAnnulerModifications.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnulerModifications.TabIndex = 3;
            this.m_btnAnnulerModifications.TabStop = false;
            this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
            // 
            // m_btnEditerObjet
            // 
            this.m_btnEditerObjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditerObjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnEditerObjet.ForeColor = System.Drawing.Color.White;
            this.m_btnEditerObjet.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEditerObjet.Image")));
            this.m_btnEditerObjet.Location = new System.Drawing.Point(12, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_btnEditerObjet.Name = "m_btnEditerObjet";
            this.m_btnEditerObjet.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditerObjet.TabIndex = 4;
            this.m_btnEditerObjet.TabStop = false;
            this.m_btnEditerObjet.Click += new System.EventHandler(this.m_btnEditerObjet_Click);
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 32);
            this.m_panelFormulaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(684, 241);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 4002;
            // 
            // CFormFormulaireCustom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 273);
            this.ContextMenuStrip = this.m_menuCustomizer;
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelEdition);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormFormulaireCustom";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormFormulaireCustom";
            this.Load += new System.EventHandler(this.CFormFormulaireCustom_Load);
            this.m_menuCustomizer.ResumeLayout(false);
            this.m_panelEdition.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Membres de IFormNavigable

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

		public CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable ctx = new CContexteFormNavigable ( GetType() );
			if ( m_formulaire != null )
				ctx["ID_FORMULAIRE"] = m_formulaire.Id;
			if ( m_objetEdite is CObjetDonnee )
				ctx["OBJET_EDITE"] = new CReferenceObjetDonnee ( (CObjetDonnee)m_objetEdite );
            if ( m_objetEdite is CObjetDonnee[] )
            {
                List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
                foreach ( CObjetDonnee obj in (CObjetDonnee[])m_objetEdite )
                    lst.Add ( new CReferenceObjetDonnee ( obj ));
                ctx["OBJETS_EDITES"] = lst;
            }
            if (AfterGetContexte != null)
                AfterGetContexte(this, ctx);
			return ctx;
		}

		public bool QueryClose()
		{
            if (m_contexteEdition != null)
            {

                MessageBox.Show(I.T("You have to validate or cancel modifications before leave this window|20830"),
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
			return true;
		}

        public void AddRestrictionComplementaire(string strTag, CListeRestrictionsUtilisateurSurType restrictions, bool bApplicationImmediate)
        {
            //TODO
        }

		public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			if ( contexte["ID_FORMULAIRE"] != null )
			{
				int nIdFormulaire = (int)contexte["ID_FORMULAIRE"];
				m_formulaire = new CFormulaire ( CSc2iWin32DataClient.ContexteCourant );
				if ( !m_formulaire.ReadIfExists ( nIdFormulaire ) )
					m_formulaire = null;
			}
			if ( contexte["OBJET_EDITE"] is CReferenceObjetDonnee )
				m_objetEdite = ((CReferenceObjetDonnee)contexte["OBJET_EDITE"]).GetObjet ( CSc2iWin32DataClient.ContexteCourant );
            List<CReferenceObjetDonnee> lstRefs = contexte["OBJETS_EDITES"] as List<CReferenceObjetDonnee>;
            if (lstRefs != null)
            {
                List<CObjetDonnee> lst = new List<CObjetDonnee>();
                foreach (CReferenceObjetDonnee reference in lstRefs)
                {
                    CObjetDonnee obj = reference.GetObjet(CSc2iWin32DataClient.ContexteCourant);
                    if (obj != null)
                        lst.Add(obj);
                }
                m_objetEdite = lst.ToArray();
            }
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this,contexte);
			return CResultAErreur.True;
		}

        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }

		#endregion

		private void CFormFormulaireCustom_Load(object sender, System.EventArgs e)
		{
            m_extModeEdition.ModeEdition = false;
			if ( m_formulaire != null )
			{
				if (m_objetEdite is CObjetDonnee)
                {
					m_createur = new CCreateur2iFormulaireObjetDonnee(((CObjetDonnee)m_objetEdite).ContexteDonnee.IdSession);
                }
                else if (m_objetEdite is CObjetDonnee[])
                {
                    m_createur = new CCreateur2iFormulaireV2();
                }
                else
                {
                    m_objetEdite = CSc2iWin32DataClient.ContexteCourant;
                    m_createur = new CCreateur2iFormulaireV2();
                }
				m_createur.CreateControlePrincipalEtChilds(m_panelFormulaire, m_formulaire.Formulaire, new CFournisseurPropDynStd(true));
                m_createur.LockEdition = !m_extModeEdition.ModeEdition;
                CSessionClient session = CSessionClient.GetSessionForIdSession(CTimosApp.SessionClient.IdSession);
                CListeRestrictionsUtilisateurSurType restrictions = session.GetInfoUtilisateur().GetListeRestrictions(null).Clone() as CListeRestrictionsUtilisateurSurType;

				m_createur.ElementEdite = m_objetEdite;

                m_createur.AppliqueRestrictions(restrictions, m_gestionnaireReadOnly);
                
                m_panelEdition.Visible = m_formulaire.AllowEditMode;
				CTimosApp.Titre = m_formulaire.Formulaire.Text;
                
			}
			else
				CTimosApp.Titre = "";

            if (CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                    CDroitDeBase.c_droitBasePersonnalisation) != null)
            {
                this.ContextMenuStrip = m_menuCustomizer;
            }
            else
            {
                this.ContextMenuStrip = null;
            }
		}

		private void m_btnEdit_Click(object sender, System.EventArgs e)
		{
			if ( m_formulaire != null )
				CTimosApp.Navigateur.AffichePage ( new CFormEditionFormulaireAvance ( m_formulaire ) );
		}
		#region Membres de IFormEditObjetDonnee

		public event System.EventHandler ObjetEditeChanged;

		public sc2i.data.CObjetDonnee GetObjetEdite()
		{
			//Juste pour le warning ObjetEditeChanged inutilisé
			if ( ObjetEditeChanged != null )
			{}
			if ( m_objetEdite is CObjetDonnee )
				return (CObjetDonnee)m_objetEdite;
			return null;
		}

		#endregion


        private void m_menuItemCustomize_Click(object sender, EventArgs e)
        {
            if (m_formulaire != null)
                CTimosApp.Navigateur.AffichePage(new CFormEditionFormulaireAvance(m_formulaire));

        }

        private void m_btnEditerObjet_Click(object sender, EventArgs e)
        {
            if (m_contexteEdition == null)
            {
                CObjetDonnee objet = m_objetEdite as CObjetDonnee;
                if (objet != null)
                {
                    objet.BeginEdit();
                    m_contexteEdition = objet.ContexteDonnee;
                    m_createur.ElementEdite = objet;
                }
                else
                {
                    CObjetDonnee[] objets = m_objetEdite as CObjetDonnee[];
                    if (objets != null && objets.Length > 0)
                    {
                        objet = (CObjetDonnee)Activator.CreateInstance(objets[0].GetType(), new object[] { objets[0].Row.Row });
                        objet.BeginEdit();
                        m_contexteEdition = objet.ContexteDonnee;
                        List<CObjetDonnee> lst = new List<CObjetDonnee>();
                        foreach (CObjetDonnee objetToAdd in objets)
                        {
                            CObjetDonnee tmp = objetToAdd.GetObjetInContexte(m_contexteEdition);
                            lst.Add(tmp);
                        }
                        m_createur.ElementEdite = lst.ToArray();
                    }
                    else
                    {
                        m_contexteEdition = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition();
                        m_createur.ElementEdite = m_contexteEdition;
                    }
                }
                m_extModeEdition.ModeEdition = true;
                m_createur.LockEdition = false;
            }
        }

        private void m_btnValiderModifications_Click(object sender, EventArgs e)
        {
            OnClickValider();

        }

        //----------------------------------------------------------------
        private bool OnClickValider()
        {
            CResultAErreur result = CResultAErreur.True;
            CObjetDonnee objet = m_objetEdite as CObjetDonnee;
            if (objet != null)
            {
                result = m_createur.MAJ_Champs();
                if ( result )
                    result = objet.VerifieDonnees(true);
                if (result)
                    result = objet.CommitEdit();
            }
            else
            {
                if (m_contexteEdition != null)
                {
                    result = m_contexteEdition.CommitEdit();
                }
            }
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return false;
            }
            else
            {
                m_contexteEdition = null;
                m_extModeEdition.ModeEdition = false;
                m_createur.LockEdition = true;
                m_createur.ElementEdite = m_objetEdite;
            }
            return true;
        }



        private void m_btnAnnulerModifications_Click(object sender, EventArgs e)
        {
            OnClickAnnuler();
        }

        private void OnClickAnnuler()
        {
            CResultAErreur result = CResultAErreur.True;
            CObjetDonnee objet = m_objetEdite as CObjetDonnee;
            if (objet != null)
            {
                objet.CancelEdit();
            }
            else
            {
                if (m_contexteEdition != null)
                {
                    m_contexteEdition.CancelEdit();
                }
            }
            m_contexteEdition = null;
            m_extModeEdition.ModeEdition = false;
            m_createur.LockEdition = true;
            m_createur.ElementEdite = m_objetEdite;
        }

        public virtual string GetTitle()
        {
            return m_formulaire != null?m_formulaire.Formulaire.Text:"";
        }

        public virtual Image GetImage()
        {
            if (m_objetEdite != null)
            {
                Image img = DynamicClassAttribute.GetImage(m_objetEdite.GetType());
                if (img != null)
                    return img;
            }
            return Resources.view_edit;
        }


        #region IFormAContexteDonnee Membres

        public CContexteDonnee ContexteDonnee
        {
            get
            {
                IObjetAContexteDonnee objetAC = m_objetEdite as IObjetAContexteDonnee;
                if (objetAC == null)
                    objetAC = m_formulaire as IObjetAContexteDonnee;
                if (objetAC != null)
                    return objetAC.ContexteDonnee;
                return null;
            }
        }

        #endregion

        public bool EtatEdition
        {
            get
            {
                return m_extModeEdition.ModeEdition;
            }
        }

        public bool ValiderModifications()
        {
            return OnClickValider();
        }

        public void AnnulerModifications()
        {
            OnClickAnnuler();
        }
    }
}
