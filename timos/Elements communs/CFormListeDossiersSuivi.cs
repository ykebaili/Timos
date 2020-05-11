using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.documents;
using sc2i.common;
using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CDossierSuivi))]
	public class CFormListeDossierSuivi : CFormListeStandardTimos, IFormNavigable
	{
		private System.Windows.Forms.Panel m_panelTitre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel m_lnkElement;
		private IObjetDonneeAIdNumerique m_objetForSuivi = null;
		private System.Windows.Forms.CheckBox m_chkOnlyPrincipaux;
        private Panel panel1;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeDossierSuivi()
			:base(new CListeObjetsDonnees( CSc2iWin32DataClient.ContexteCourant, typeof(CDossierSuivi) ))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		public CFormListeDossierSuivi( IObjetDonneeAIdNumerique objet)
			:base(new CListeObjetsDonnees( CSc2iWin32DataClient.ContexteCourant, typeof(CDossierSuivi)))
		{
			m_objetForSuivi = objet;
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

		private CFiltreData m_filtreDeBaseOriginal = null;
		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeDossierSuivi));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_lnkElement = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkOnlyPrincipaux = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelHaut.SuspendLayout();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.m_panelListe.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListe.AffectationsPourNouveauxElements")));
            this.m_panelListe.BoutonAjouterVisible = true;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "DateOuverture";
            glColumn1.Text = "Date ouverture";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namex";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 400;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_panelListe.Size = new System.Drawing.Size(633, 355);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListe_OnNewObjetDonnee);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Location = new System.Drawing.Point(0, 32);
            this.m_panelGauche.Size = new System.Drawing.Size(0, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(633, 32);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 407);
            this.m_panelBas.Size = new System.Drawing.Size(633, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_panelTitre);
            this.m_panelHaut.Size = new System.Drawing.Size(633, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.panel1);
            this.m_panelMilieu.Location = new System.Drawing.Point(0, 32);
            this.m_panelMilieu.Size = new System.Drawing.Size(633, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.panel1, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelLinkList, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelActions, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.BackColor = System.Drawing.Color.Navy;
            this.m_panelTitre.Controls.Add(this.m_lnkElement);
            this.m_panelTitre.Controls.Add(this.label1);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(633, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 2;
            // 
            // m_lnkElement
            // 
            this.m_lnkElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkElement.LinkColor = System.Drawing.Color.White;
            this.m_lnkElement.Location = new System.Drawing.Point(177, 0);
            this.m_lnkElement.Name = "m_lnkElement";
            this.m_lnkElement.Size = new System.Drawing.Size(444, 32);
            this.m_extStyle.SetStyleBackColor(this.m_lnkElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkElement.TabIndex = 1;
            this.m_lnkElement.TabStop = true;
            this.m_lnkElement.Text = "ELEMENT NAME";
            this.m_lnkElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkElement_LinkClicked);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 32);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workbook|855";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkOnlyPrincipaux
            // 
            this.m_chkOnlyPrincipaux.Checked = true;
            this.m_chkOnlyPrincipaux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkOnlyPrincipaux.Location = new System.Drawing.Point(4, 0);
            this.m_chkOnlyPrincipaux.Name = "m_chkOnlyPrincipaux";
            this.m_chkOnlyPrincipaux.Size = new System.Drawing.Size(208, 18);
            this.m_extStyle.SetStyleBackColor(this.m_chkOnlyPrincipaux, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkOnlyPrincipaux, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkOnlyPrincipaux.TabIndex = 3;
            this.m_chkOnlyPrincipaux.Text = "Only main Workbooks|868";
            this.m_chkOnlyPrincipaux.CheckedChanged += new System.EventHandler(this.m_chkOnlyPrincipaux_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_chkOnlyPrincipaux);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 20);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 6;
            // 
            // CFormListeDossierSuivi
            // 
            this.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouveauxElements")));
            this.AffichePanelHaut = true;
            this.BoutonAjouterVisible = true;
            this.ClientSize = new System.Drawing.Size(633, 407);
            this.Name = "CFormListeDossierSuivi";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			//N'affiche que les éléments avec catégorie et non liés à un
			//élément.
			if ( m_filtreDeBaseOriginal == null )
				m_filtreDeBaseOriginal = FiltreDeBase;
			CFiltreData filtreDeBase = m_filtreDeBaseOriginal;
			if ( m_objetForSuivi != null )
				filtreDeBase = 
					CFiltreData.GetAndFiltre ( filtreDeBase,
						new CFiltreData ( 
						CDossierSuivi.c_champTypeElementLie+"=@1 and "+
						CDossierSuivi.c_champIdElementLie+"=@2",
						m_objetForSuivi.GetType().ToString(),
						m_objetForSuivi.Id ) );
			if ( ContexteUtilisation.Trim() !=  "" )
			{
				m_chkOnlyPrincipaux.Visible = false;
				m_chkOnlyPrincipaux.Checked = false;
			}
			if ( m_chkOnlyPrincipaux.Checked )
			{
				CFiltreData filtre = new CFiltreDataAvance ( 
					CDossierSuivi.c_nomTable,
					"hasno("+CDossierSuivi.c_champIdDossierParent+")");
				filtreDeBase = CFiltreData.GetAndFiltre ( filtre, filtreDeBase );
			}
			bool bOldVal = m_panelListe.FiltreDeBaseEnAjout;
			m_panelListe.FiltreDeBaseEnAjout = false;
			m_panelListe.FiltreDeBase = filtreDeBase;
			m_panelListe.FiltreDeBaseEnAjout = bOldVal;

			//m_panelListe.ControlFiltreStandard = new CPanelFiltreDocumentGed();
			
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CDossierSuivi),	
				null, "");

			//S'il n'existe aucun type de dossier pour le type de l'élément, le bouton
			//AJoute est masqué.
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof ( CTypeDossierSuivi ) );
			if ( m_objetForSuivi != null )
				liste.Filtre = new CFiltreData ( CTypeDossierSuivi.c_champTypeSuivi+"=@1",
					m_objetForSuivi.GetType().ToString() );
			else
				liste.Filtre = new CFiltreData ( CTypeDossierSuivi.c_champTypeSuivi+"=@1",
					"" );
            m_panelListe.BoutonAjouterVisible = liste.Count > 0 && m_panelListe.BoutonAjouterVisible;

			m_panelListe.RemplirGrille();
			if ( m_objetForSuivi == null )
				m_lnkElement.Visible = false;
			else 
			{
				m_lnkElement.Visible = true;
				m_lnkElement.Text = m_objetForSuivi.DescriptionElement;
			}

		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Workbook list|869");
		}

		public override CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable contexte = base.GetContexte();
			if ( contexte == null )
				return null;
			if ( m_objetForSuivi != null )
			{
				contexte["TYPE_OBJET"] = m_objetForSuivi.GetType();
				contexte["ID_OBJET"] = m_objetForSuivi.Id;
			}
			contexte["PRINCIPAUX"] = m_chkOnlyPrincipaux.Checked;
			return contexte;
		}

		public override sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
		{
			CResultAErreur result = base.InitFromContexte(ctx);
			if ( !result )
				return result;
			if(  ctx["TYPE_OBJET"] != null )
			{
				m_objetForSuivi = (CObjetDonneeAIdNumerique)Activator.CreateInstance(
					(Type)ctx["TYPE_OBJET"],
					new object[]{CSc2iWin32DataClient.ContexteCourant});
				if ( !m_objetForSuivi.ReadIfExists((int)ctx["ID_OBJET"]) )
					m_objetForSuivi = null;
			}
			m_chkOnlyPrincipaux.Checked = (bool)ctx["PRINCIPAUX"];
			return result;
		}


		/// ////////////////////////////////////////
		private void m_lnkElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_objetForSuivi != null )
			{
                //Type tp = CFormFinder.GetTypeFormToEdit ( m_objetForSuivi.GetType() );
                //if ( tp.IsSubclassOf ( typeof(CFormEditionStandard) ))
                //{
                //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(tp, new object[]{m_objetForSuivi});
                //    CTimosApp.Navigateur.AffichePage ( form );
                //}

                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(m_objetForSuivi.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)m_objetForSuivi) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }

			}
		}

		/// ////////////////////////////////////////
		private void m_chkOnlyPrincipaux_CheckedChanged(object sender, System.EventArgs e)
		{
			InitPanel();
			m_panelListe.Refresh();
		}

		/// ////////////////////////////////////////
        private void m_panelListe_OnNewObjetDonnee(object sender, sc2i.data.CObjetDonnee nouvelObjet, ref bool bCancel)
        {
            if (bCancel)
                return;
			if ( m_objetForSuivi != null && nouvelObjet is CDossierSuivi )
				((CDossierSuivi)nouvelObjet).ElementSuivi = (CObjetDonneeAIdNumerique)m_objetForSuivi;
		}
		
	}
}

