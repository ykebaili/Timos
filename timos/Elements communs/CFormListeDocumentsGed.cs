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
using sc2i.win32.common;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CDocumentGED))]
	public class CFormListeDocumentsGED : CFormListeStandardTimos, IFormNavigable
	{
		private System.Windows.Forms.Panel m_panelTitre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel m_lnkElement;
		private IObjetDonneeAIdNumerique m_objetForGED = null;
		private System.Windows.Forms.CheckBox m_chkTousDocuments;
		private System.Windows.Forms.LinkLabel m_lnkDocRecent;
        private C2iPanelFondDegradeStd c2iPanelFondDegradeStd1;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeDocumentsGED()
			:base(new CListeObjetsDonnees( CSc2iWin32DataClient.ContexteCourant, typeof(CDocumentGED) ))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		public CFormListeDocumentsGED( IObjetDonneeAIdNumerique objet)
			:base(new CListeObjetsDonnees( CSc2iWin32DataClient.ContexteCourant, typeof(CDocumentGED)))
		{
			m_objetForGED = objet;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeDocumentsGED));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_lnkElement = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkTousDocuments = new System.Windows.Forms.CheckBox();
            this.m_lnkDocRecent = new System.Windows.Forms.LinkLabel();
            this.c2iPanelFondDegradeStd1 = new sc2i.win32.common.C2iPanelFondDegradeStd();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelHaut.SuspendLayout();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.c2iPanelFondDegradeStd1.SuspendLayout();
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
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namex";
            glColumn2.Propriete = "Descriptif";
            glColumn2.Text = "Descriptif";
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
            glColumn3.Propriete = "Notes";
            glColumn3.Text = "Notes";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.m_panelListe.Size = new System.Drawing.Size(737, 416);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.AfterCreateFormEdition += new sc2i.win32.data.navigation.AfterCreateFormEditionEventHandler(this.m_panelListe_AfterCreateFormEdition);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Location = new System.Drawing.Point(0, 32);
            this.m_panelGauche.Size = new System.Drawing.Size(0, 416);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(737, 32);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 416);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 448);
            this.m_panelBas.Size = new System.Drawing.Size(737, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_panelTitre);
            this.m_panelHaut.Size = new System.Drawing.Size(737, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.c2iPanelFondDegradeStd1);
            this.m_panelMilieu.Location = new System.Drawing.Point(0, 32);
            this.m_panelMilieu.Size = new System.Drawing.Size(737, 416);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelLinkList, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelActions, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.c2iPanelFondDegradeStd1, 0);
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.BackColor = System.Drawing.Color.Navy;
            this.m_panelTitre.Controls.Add(this.m_lnkElement);
            this.m_panelTitre.Controls.Add(this.label1);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(737, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 2;
            // 
            // m_lnkElement
            // 
            this.m_lnkElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkElement.BackColor = System.Drawing.Color.Navy;
            this.m_lnkElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkElement.LinkColor = System.Drawing.Color.White;
            this.m_lnkElement.Location = new System.Drawing.Point(74, 0);
            this.m_lnkElement.Name = "m_lnkElement";
            this.m_lnkElement.Size = new System.Drawing.Size(607, 32);
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
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkTousDocuments
            // 
            this.m_chkTousDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkTousDocuments.Checked = true;
            this.m_chkTousDocuments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkTousDocuments.Location = new System.Drawing.Point(625, 433);
            this.m_chkTousDocuments.Name = "m_chkTousDocuments";
            this.m_chkTousDocuments.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkTousDocuments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkTousDocuments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkTousDocuments.TabIndex = 3;
            this.m_chkTousDocuments.Text = "All documents|863";
            this.m_chkTousDocuments.Visible = false;
            this.m_chkTousDocuments.CheckedChanged += new System.EventHandler(this.m_chkTousDocuments_CheckedChanged);
            // 
            // m_lnkDocRecent
            // 
            this.m_lnkDocRecent.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkDocRecent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkDocRecent.Location = new System.Drawing.Point(3, 6);
            this.m_lnkDocRecent.Name = "m_lnkDocRecent";
            this.m_lnkDocRecent.Size = new System.Drawing.Size(186, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDocRecent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDocRecent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDocRecent.TabIndex = 5;
            this.m_lnkDocRecent.TabStop = true;
            this.m_lnkDocRecent.Text = "Associate a recent document|864";
            this.m_lnkDocRecent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDocRecent_LinkClicked);
            // 
            // c2iPanelFondDegradeStd1
            // 
            this.c2iPanelFondDegradeStd1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("c2iPanelFondDegradeStd1.BackgroundImage")));
            this.c2iPanelFondDegradeStd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lnkDocRecent);
            this.c2iPanelFondDegradeStd1.Location = new System.Drawing.Point(360, 1);
            this.c2iPanelFondDegradeStd1.Name = "c2iPanelFondDegradeStd1";
            this.c2iPanelFondDegradeStd1.Size = new System.Drawing.Size(186, 24);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelFondDegradeStd1.TabIndex = 6;
            // 
            // CFormListeDocumentsGED
            // 
            this.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouveauxElements")));
            this.AffichePanelHaut = true;
            this.ClientSize = new System.Drawing.Size(737, 448);
            this.Controls.Add(this.m_chkTousDocuments);
            this.Name = "CFormListeDocumentsGED";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_chkTousDocuments, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			//N'affiche que les éléments avec catégorie et non liés à un
			//élément.
			if ( m_objetForGED == null)
			{
				if ( !m_chkTousDocuments.Checked )
				{
					m_panelListe.FiltreDeBase = new CFiltreDataAvance(
						CDocumentGED.c_nomTable,
						/*"has("+CRelationDocumentGED_Categorie.c_nomTable+"."+
						CRelationDocumentGED_Categorie.c_champId+") and "+*/
						"hasno("+CRelationElementToDocument.c_nomTable+"."+
						CRelationElementToDocument.c_champId+")" );
				}
				else
					m_panelListe.FiltreDeBase = null;
				m_chkTousDocuments.Visible = true;
			}
			else
			{
				m_chkTousDocuments.Visible = false;
				m_panelListe.FiltreDeBase = CDocumentGED.GetListeDocumentsForElement(m_objetForGED).Filtre;
			}

			m_panelListe.ControlFiltreStandard = new CPanelFiltreDocumentGed();
			
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CDocumentGED),	
				typeof(CFormEditionDocumentGED),
				null, "");

			
			m_lnkDocRecent.Visible = m_objetForGED != null;

			m_panelListe.RemplirGrille();
            if (m_objetForGED == null)
                m_lnkElement.Visible = false;
            else
            {
                m_lnkElement.Visible = true;
                m_lnkElement.Text = m_objetForGED.DescriptionElement;
            }
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T( "Documents list|865");
			
		}

		public override CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable contexte = base.GetContexte();
			if ( contexte == null )
				return null;
			if ( m_objetForGED != null )
			{
				contexte["TYPE_OBJET"] = m_objetForGED.GetType();
				contexte["ID_OBJET"] = m_objetForGED.Id;
			}
			return contexte;
		}

		public override sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
		{
			CResultAErreur result = base.InitFromContexte(ctx);
			if ( !result )
				return result;
			if(  ctx["TYPE_OBJET"] != null )
			{
				m_objetForGED = (CObjetDonneeAIdNumerique)Activator.CreateInstance(
					(Type)ctx["TYPE_OBJET"],
					new object[]{CSc2iWin32DataClient.ContexteCourant});
				if ( !m_objetForGED.ReadIfExists((int)ctx["ID_OBJET"]) )
					m_objetForGED = null;
			}
			return result;
		}


		/// ////////////////////////////////////////
		private void m_lnkElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_objetForGED != null )
			{
                //Type tp = CFormFinder.GetTypeFormToEdit ( m_objetForGED.GetType() );
                //if ( tp.IsSubclassOf ( typeof(CFormEditionStandard) ))
                //{
                //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(tp, new object[]{m_objetForGED});
                //    CTimosApp.Navigateur.AffichePage ( form );
                //}
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(m_objetForGED.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)m_objetForGED) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }

			}
		}

		/// ////////////////////////////////////////
		private void m_chkTousDocuments_CheckedChanged(object sender, System.EventArgs e)
		{
			InitPanel();
			m_panelListe.Refresh();
		}

		private void m_panelListe_AfterCreateFormEdition(object sender, sc2i.win32.data.navigation.CFormEditionStandard form)
		{
			if ( form is CFormEditionDocumentGED )
				((CFormEditionDocumentGED)form).ObjetAuquelAttacher = (CObjetDonneeAIdNumerique)m_objetForGED;
		}

		private class CMenuItemAHistorique : MenuItem
		{
			public readonly CHistoriqueDocumentGencod Historique;

			public CMenuItemAHistorique ( CHistoriqueDocumentGencod histo )
			{
				Text = histo.LibelleDocument;
				Historique = histo;
			}
		}


		//---------------------------------------------------------------------------
		private void m_lnkDocRecent_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CHistoriqueDocumentGencod[] historiques = CHistoriqueDocumentGencod.GetHistoriqueDocuments();
			if ( historiques.Length == 0 )
				return;
			ContextMenu menu = new ContextMenu();
			foreach ( CHistoriqueDocumentGencod historique in historiques )
			{
				CMenuItemAHistorique item = new CMenuItemAHistorique ( historique );
				item.Click += new EventHandler(itemHistorique_Click);
				menu.MenuItems.Add ( item );
			}
			menu.Show ( m_lnkDocRecent, new Point ( 0, m_lnkDocRecent.Height ));
			}

		//--------------------------------------------------------------------
		private void itemHistorique_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemAHistorique )
			{
				CHistoriqueDocumentGencod historique = ((CMenuItemAHistorique)sender).Historique;
				CDocumentGED doc = new CDocumentGED ( CSc2iWin32DataClient.ContexteCourant );
				if ( !doc.ReadIfExists ( historique.IdDocumentGed ) )
				{
					CFormAlerte.Afficher(
                        I.T("The document|866")+" "
                        +historique.LibelleDocument+" "+
                        I.T( "does not exist any more|867"), EFormAlerteType.Erreur);
					return;
				}
				doc.BeginEdit();
				doc.AssocieA ( (CObjetDonneeAIdNumerique)m_objetForGED );
				CResultAErreur result = doc.CommitEdit();
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
					return;
				}
				InitPanel();
			}
		}
	}
}

