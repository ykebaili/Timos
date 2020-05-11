using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using System.Windows.Forms;
using sc2i.documents;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(C2iRapportCrystal))]
	public class CFormEditionRapportCrystal : CFormEditionStdTimos, IFormNavigable
	{
		private CFichierLocalTemporaire m_fichierDonnees = new CFichierLocalTemporaire("MDB");
		private DataSet m_datasetTest = null;
		private CProxyGED m_proxyReport = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.ComponentModel.IContainer components = null;
		private sc2i.win32.common.C2iLink m_linkCategorie;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbCategorie;
		private sc2i.win32.common.C2iLink m_linkVisualiser;
		private sc2i.win32.data.dynamic.CPanelEditMultiStructure m_panelMultiStructure;
		private System.Windows.Forms.Button m_btnModifierModele;
		private sc2i.win32.common.C2iLink m_lnkModeleStructure;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbModeleStructure;
		
		public CFormEditionRapportCrystal()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionRapportCrystal(C2iRapportCrystal rapport)
			:base(rapport)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionRapportCrystal(C2iRapportCrystal rapport, CListeObjetsDonnees liste)
			:base(rapport, liste)
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
				if ( m_fichierDonnees != null )
					m_fichierDonnees.Dispose();
				m_fichierDonnees = null;
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkModeleStructure = new sc2i.win32.common.C2iLink(this.components);
            this.m_cmbModeleStructure = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_cmbCategorie = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_btnModifierModele = new System.Windows.Forms.Button();
            this.m_linkVisualiser = new sc2i.win32.common.C2iLink(this.components);
            this.m_linkCategorie = new sc2i.win32.common.C2iLink(this.components);
            this.m_panelMultiStructure = new sc2i.win32.data.dynamic.CPanelEditMultiStructure();
            this.c2iPanelOmbre4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Report label|926";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(120, 12);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(304, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkModeleStructure);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbModeleStructure);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbCategorie);
            this.c2iPanelOmbre4.Controls.Add(this.m_btnModifierModele);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_linkVisualiser);
            this.c2iPanelOmbre4.Controls.Add(this.m_linkCategorie);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 36);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(636, 132);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lnkModeleStructure
            // 
            this.m_lnkModeleStructure.ClickEnabled = true;
            this.m_lnkModeleStructure.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkModeleStructure.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkModeleStructure.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkModeleStructure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkModeleStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkModeleStructure.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_lnkModeleStructure, "");
            this.m_lnkModeleStructure.Location = new System.Drawing.Point(4, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkModeleStructure, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkModeleStructure.Name = "m_lnkModeleStructure";
            this.m_lnkModeleStructure.Size = new System.Drawing.Size(110, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModeleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModeleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModeleStructure.TabIndex = 4052;
            this.m_lnkModeleStructure.Text = "Structure model|927";
            this.m_lnkModeleStructure.LinkClicked += new System.EventHandler(this.m_lnkModeleStructure_LinkClicked);
            // 
            // m_cmbModeleStructure
            // 
            this.m_cmbModeleStructure.ComportementLinkStd = true;
            this.m_cmbModeleStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeleStructure.ElementSelectionne = null;
            this.m_cmbModeleStructure.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbModeleStructure, "");
            this.m_cmbModeleStructure.LinkProperty = "";
            this.m_cmbModeleStructure.ListDonnees = null;
            this.m_cmbModeleStructure.Location = new System.Drawing.Point(120, 88);
            this.m_cmbModeleStructure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeleStructure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbModeleStructure.Name = "m_cmbModeleStructure";
            this.m_cmbModeleStructure.NullAutorise = true;
            this.m_cmbModeleStructure.ProprieteAffichee = null;
            this.m_cmbModeleStructure.ProprieteParentListeObjets = null;
            this.m_cmbModeleStructure.SelectionneurParent = null;
            this.m_cmbModeleStructure.Size = new System.Drawing.Size(304, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeleStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeleStructure.TabIndex = 4051;
            this.m_cmbModeleStructure.TextNull = "(None)|30292";
            this.m_cmbModeleStructure.Tri = true;
            this.m_cmbModeleStructure.TypeFormEdition = null;
            this.m_cmbModeleStructure.SelectionChangeCommitted += new System.EventHandler(this.m_cmbModeleStructure_SelectionChangeCommitted);
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.ComportementLinkStd = true;
            this.m_cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCategorie.ElementSelectionne = null;
            this.m_cmbCategorie.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbCategorie, "");
            this.m_cmbCategorie.LinkProperty = "";
            this.m_cmbCategorie.ListDonnees = null;
            this.m_cmbCategorie.Location = new System.Drawing.Point(120, 36);
            this.m_cmbCategorie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCategorie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.NullAutorise = true;
            this.m_cmbCategorie.ProprieteAffichee = null;
            this.m_cmbCategorie.ProprieteParentListeObjets = null;
            this.m_cmbCategorie.SelectionneurParent = null;
            this.m_cmbCategorie.Size = new System.Drawing.Size(304, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCategorie.TabIndex = 1;
            this.m_cmbCategorie.TextNull = I.T("(None)|30292");
            this.m_cmbCategorie.Tri = true;
            this.m_cmbCategorie.TypeFormEdition = null;
            // 
            // m_btnModifierModele
            // 
            this.m_btnModifierModele.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_btnModifierModele, "");
            this.m_btnModifierModele.Location = new System.Drawing.Point(120, 61);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModifierModele, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnModifierModele.Name = "m_btnModifierModele";
            this.m_btnModifierModele.Size = new System.Drawing.Size(148, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnModifierModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModifierModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnModifierModele.TabIndex = 4049;
            this.m_btnModifierModele.Text = "Edit Report|928";
            this.m_btnModifierModele.UseVisualStyleBackColor = false;
            this.m_btnModifierModele.Click += new System.EventHandler(this.m_btnModifierModele_Click);
            // 
            // m_linkVisualiser
            // 
            this.m_linkVisualiser.ClickEnabled = true;
            this.m_linkVisualiser.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkVisualiser.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkVisualiser.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkVisualiser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkVisualiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkVisualiser.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_linkVisualiser, "");
            this.m_linkVisualiser.Location = new System.Drawing.Point(497, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkVisualiser, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_linkVisualiser.Name = "m_linkVisualiser";
            this.m_linkVisualiser.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_linkVisualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkVisualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkVisualiser.TabIndex = 4045;
            this.m_linkVisualiser.Text = "Visualise Report|925";
            this.m_linkVisualiser.LinkClicked += new System.EventHandler(this.m_linkVisualiser_LinkClicked);
            // 
            // m_linkCategorie
            // 
            this.m_linkCategorie.ClickEnabled = true;
            this.m_linkCategorie.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkCategorie.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkCategorie.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkCategorie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkCategorie.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_linkCategorie, "");
            this.m_linkCategorie.Location = new System.Drawing.Point(4, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkCategorie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_linkCategorie.Name = "m_linkCategorie";
            this.m_linkCategorie.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.m_linkCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkCategorie.TabIndex = 4044;
            this.m_linkCategorie.Text = "Category|852";
            this.m_linkCategorie.LinkClicked += new System.EventHandler(this.m_linkCategorie_LinkClicked);
            // 
            // m_panelMultiStructure
            // 
            this.m_panelMultiStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelMultiStructure.BackColor = System.Drawing.Color.White;
            this.m_panelMultiStructure.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelMultiStructure, "");
            this.m_panelMultiStructure.Location = new System.Drawing.Point(8, 174);
            this.m_panelMultiStructure.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMultiStructure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelMultiStructure.Name = "m_panelMultiStructure";
            this.m_panelMultiStructure.Size = new System.Drawing.Size(822, 356);
            this.m_extStyle.SetStyleBackColor(this.m_panelMultiStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMultiStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMultiStructure.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelMultiStructure.TabIndex = 4048;
            // 
            // CFormEditionRapportCrystal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_panelMultiStructure);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionRapportCrystal";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Closed += new System.EventHandler(this.CFormEditionRapportCrystal_Closed);
            this.BeforeValideModification += new sc2i.data.ObjetDonneeCancelEventHandler(this.CFormEditionRapportCrystal_BeforeValideModification);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_panelMultiStructure, 0);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private C2iRapportCrystal Rapport
		{
			get
			{
				return (C2iRapportCrystal)ObjetEdite;
			}
		}
		//-----------------------------------------------------------
		private CResultAErreur InitComboBoxCategorie(bool bForceInit)
		{
			return m_cmbCategorie.Init(typeof(C2iCategorieRapportCrystal),null,"Libelle", typeof(CFormEditionCategorieRapportCrystal), bForceInit );
		}

		//-----------------------------------------------------------
		private CResultAErreur InitComboBoxStructure(bool bForceInit)
		{
			return m_cmbModeleStructure.Init(typeof(C2iStructureExportInDB),null,"Libelle", typeof(CFormEditionStructureDonnee), bForceInit );
		}
		
		
		//-------------------------------------------------------------------------
		private CResultAErreur MAJ_Modele()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_proxyReport!= null && m_proxyReport.HasChange() )
			{
				result = m_proxyReport.UpdateGed();
				if ( result )
				{
					CDocumentGED doc = Rapport.DocumentGED;
					if ( doc == null )
					{
						doc = new CDocumentGED ( Rapport.ContexteDonnee );
						doc.CreateNewInCurrentContexte();
						doc.Descriptif = "";
						doc.DateCreation = DateTime.Now;
						Rapport.DocumentGED = doc;
					}
                    doc.Libelle = I.T("Report Model @1|30228", Rapport.Libelle);
					doc.ReferenceDoc = (CReferenceDocument)result.Data;
					doc.DateMAJ = DateTime.Now;
					doc.NumVersion++;
					doc.IsFichierSysteme = true;
				}
			}
			return result;
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			if (!result)
				return result;

			
			result = InitComboBoxCategorie(false);
			if ( result )
				result = InitComboBoxStructure(false);
			if (!result)
				return result;
			m_cmbCategorie.SelectedValue = Rapport.CategorieRapport;

			m_cmbModeleStructure.ElementSelectionne = Rapport.ModeleDonnees;


			AffecterTitre(I.T( "Crystal Report|469") +" " + Rapport.Libelle);

			if ( m_proxyReport != null )
			{
				m_proxyReport.Dispose();
				m_proxyReport = null;
			}
			if ( Rapport.DocumentGED != null )
				m_proxyReport = new CProxyGED ( Rapport.ContexteDonnee.IdSession, Rapport.DocumentGED.ReferenceDoc );
			else
			{
				m_proxyReport = new CProxyGED ( Rapport.ContexteDonnee.IdSession, null );
				m_proxyReport.CreateNewFichier();
			}

			
			if ( Rapport.MultiStructure != null )
				m_panelMultiStructure.Init ( Rapport.MultiStructure );
			else
				m_panelMultiStructure.Init ( new CMultiStructureExport ( Rapport.ContexteDonnee ) );

            UpdateDispoControles();
	
            return result;

		}

		//-------------------------------------------------------------------------
		private void UpdateDispoControles()
		{
			m_panelMultiStructure.Enabled = m_cmbModeleStructure.ElementSelectionne == null;
			if ( m_cmbModeleStructure.ElementSelectionne is C2iStructureExportInDB )
				m_panelMultiStructure.Init ( ((C2iStructureExportInDB)m_cmbModeleStructure.ElementSelectionne).MultiStructure );
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			
			Rapport.CategorieRapport = (C2iCategorieRapportCrystal) m_cmbCategorie.SelectedValue;
			
			result = MAJ_Modele();

			if ( m_cmbModeleStructure.ElementSelectionne is C2iStructureExportInDB ) 
				Rapport.ModeleDonnees = (C2iStructureExportInDB)m_cmbModeleStructure.ElementSelectionne;
			else
			{
				Rapport.ModeleDonnees = null;
				Rapport.MultiStructure = m_panelMultiStructure.MultiStructure;
			}
			
			return result;
		}
		
		//-------------------------------------------------------------------------
		private void m_linkCategorie_LinkClicked(object sender, System.EventArgs e)
		{
			CFormNavigateurPopupListe.Show( new CFormListeCategoriesRapportCrystal() );
			InitComboBoxCategorie(true);
		}

	
		//-------------------------------------------------------------------------
		private void m_linkVisualiser_LinkClicked(object sender, System.EventArgs e)
		{
			CFormVisualisationRapport frm = new CFormVisualisationRapport(Rapport);
			CSc2iWin32DataNavigation.Navigateur.AffichePage(frm);
		}
		
		private void CFormEditionRapportCrystal_Closed(object sender, System.EventArgs e)
		{
			m_fichierDonnees.Dispose();
			m_fichierDonnees = null;
		}

		private void CFormEditionRapportCrystal_BeforeValideModification(object sender, sc2i.data.CObjetDonneeCancelEventArgs args)
		{
		
		}


		private void m_lnkJeuTest_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CreateJeuDeTest();
		}

		private bool CreateJeuDeTest()
		{
			CServicePopupProgressionTimos serviceIndicateur = new CServicePopupProgressionTimos();
			IIndicateurProgression indicateur = serviceIndicateur.GetNewIndicateurAndPopup();

			DataSet ds = m_panelMultiStructure.GetJeuEssai(indicateur);
			if ( ds != null )
			{
				try
				{
					Rapport.CompleteDataSetDonnees(ds, m_panelMultiStructure.MultiStructure);
				}
				catch (Exception e)
				{
					serviceIndicateur.EndIndicateur(indicateur);
					CFormAlerte.Afficher(e.ToString(), EFormAlerteType.Erreur);
					return false;
				}
			}


			serviceIndicateur.EndIndicateur(indicateur);

			if ( ds == null )
			{
				return false;
			}
			
			
			/*CMultiStructureExport structure = m_panelMultiStructure.MultiStructure;
			if ( structure.Formulaire != null && structure.Formulaire.Childs.Length > 0 )
			{
				if ( !CFormFormulairePopup.EditeElement ( structure.Formulaire, structure, "Données de l'état" ) )
					return false;
			}
			CServicePopupProgressionCafel serviceIndicateur = new CServicePopupProgressionCafel();
			IIndicateurProgression indicateur = serviceIndicateur.GetNewIndicateurAndPopup();
			CResultAErreur result = Rapport.GetDataFromMultiStructure( structure, null, false, indicateur );
			serviceIndicateur.EndIndicateur(indicateur);
			if ( !result )
			{
				CFormAlerte.Afficher(  result.Erreur );
				return false;
			}*/
			m_datasetTest = ds;
			return true;
		}

		private void m_btnModifierModele_Click(object sender, System.EventArgs e)
		{
			CResultAErreur result = CResultAErreur.True;

            MAJ_Champs();

			if ( (Rapport.DocumentGED == null || Rapport.DocumentGED.ReferenceDoc == null) && m_proxyReport == null)
				m_proxyReport.CreateNewFichier();
			else
			{
				if ( !m_proxyReport.IsFichierRappatrie() )
				{
					result = m_proxyReport.CopieFichierEnLocal();
					if ( !result )
					{
						result.EmpileErreur(I.T("Error while reading document from EDM|30230"));
						CFormAlerte.Afficher ( result.Erreur );
						if ( CFormAlerte.Afficher(I.T("The original model could not have been read again, create a new model ?|30231"),
							EFormAlerteType.Question) == DialogResult.No )
							return;
						m_proxyReport.CreateNewFichier();
					}
				}
			}

			if (!CreateJeuDeTest())
				return;

			DataSet m_datasetTest = m_panelMultiStructure.GetJeuEssai(null);
			
			m_fichierDonnees.CreateNewFichier();
			result = new CExporteurDatasetAccess().Export(m_datasetTest, new CDestinationExportFile(m_fichierDonnees.NomFichier));
			if ( !result )
			{
				CFormAlerte.Afficher(  result.Erreur );
				return;
			}
			if ( result )
			{
				CEditeurEtatCrystal.EditeEtat ( m_fichierDonnees.NomFichier, m_proxyReport.NomFichierLocal );
			}
		}

		private void m_lnkModeleStructure_LinkClicked(object sender, System.EventArgs e)
		{
			CFormNavigateurPopupListe.Show( new CFormListeStructuresDonnees() );
			InitComboBoxStructure(true);
		}



        private void m_cmbModeleStructure_SelectionChangeCommitted(object sender, EventArgs e)
        {
			UpdateDispoControles();

        }
	}
}

