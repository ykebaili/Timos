using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.workflow;

namespace Cafel.Win32.Composants
{
	/// <summary>
	/// Description résumée de CFormSelectLiensAgendaMultiples.
	/// </summary>
	public class CFormSelectLiensAgendaMultiples : System.Windows.Forms.Form
	{
		private CRelationTypeEntreeAgenda_TypeElementAAgenda m_typeLien = null;
		private CEntreeAgenda m_entreeAgenda;
		private System.Windows.Forms.LinkLabel m_lnkAjouterElement;
		private sc2i.win32.common.GlacialList m_wndListeSelection;
		private System.Windows.Forms.Label m_lblNbSel;
		private sc2i.win32.common.C2iPanelOmbre m_panelGeneral;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.common.CWndLinkStd m_lnkDelete;
		private System.Windows.Forms.LinkLabel m_lnkAjoutParFiltre;
		private System.Windows.Forms.ContextMenu m_menuFiltres;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurElement;
        protected CExtStyle m_ExtStyle;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormSelectLiensAgendaMultiples()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		public CFormSelectLiensAgendaMultiples( CRelationTypeEntreeAgenda_TypeElementAAgenda typeLien )
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			m_typeLien = typeLien;
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSelectLiensAgendaMultiples));
            this.m_panelGeneral = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkAjoutParFiltre = new System.Windows.Forms.LinkLabel();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_lblNbSel = new System.Windows.Forms.Label();
            this.m_wndListeSelection = new sc2i.win32.common.GlacialList();
            this.m_lnkAjouterElement = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_selectionneurElement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_menuFiltres = new System.Windows.Forms.ContextMenu();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelGeneral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGeneral
            // 
            this.m_panelGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelGeneral.Controls.Add(this.m_lnkAjoutParFiltre);
            this.m_panelGeneral.Controls.Add(this.m_lnkDelete);
            this.m_panelGeneral.Controls.Add(this.m_lblNbSel);
            this.m_panelGeneral.Controls.Add(this.m_wndListeSelection);
            this.m_panelGeneral.Controls.Add(this.m_lnkAjouterElement);
            this.m_panelGeneral.Controls.Add(this.panel1);
            this.m_panelGeneral.Controls.Add(this.m_selectionneurElement);
            this.m_panelGeneral.ForeColor = System.Drawing.Color.Black;
            this.m_panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.m_panelGeneral.LockEdition = false;
            this.m_panelGeneral.Name = "m_panelGeneral";
            this.m_panelGeneral.Size = new System.Drawing.Size(504, 403);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelGeneral.TabIndex = 4008;
            // 
            // m_lnkAjoutParFiltre
            // 
            this.m_lnkAjoutParFiltre.Location = new System.Drawing.Point(314, 32);
            this.m_lnkAjoutParFiltre.Name = "m_lnkAjoutParFiltre";
            this.m_lnkAjoutParFiltre.Size = new System.Drawing.Size(126, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAjoutParFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAjoutParFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjoutParFiltre.TabIndex = 4016;
            this.m_lnkAjoutParFiltre.TabStop = true;
            this.m_lnkAjoutParFiltre.Text = "Add by filter|30087";
            this.m_lnkAjoutParFiltre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjoutParFiltre_LinkClicked);
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDelete.Location = new System.Drawing.Point(16, 336);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(160, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDelete.TabIndex = 4015;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // m_lblNbSel
            // 
            this.m_lblNbSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblNbSel.Location = new System.Drawing.Point(320, 336);
            this.m_lblNbSel.Name = "m_lblNbSel";
            this.m_lblNbSel.Size = new System.Drawing.Size(160, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblNbSel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblNbSel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNbSel.TabIndex = 4011;
            this.m_lblNbSel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_wndListeSelection
            // 
            this.m_wndListeSelection.AllowColumnResize = true;
            this.m_wndListeSelection.AllowMultiselect = false;
            this.m_wndListeSelection.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeSelection.AlternatingColors = false;
            this.m_wndListeSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSelection.AutoHeight = true;
            this.m_wndListeSelection.AutoSort = true;
            this.m_wndListeSelection.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeSelection.CanChangeActivationCheckBoxes = false;
            this.m_wndListeSelection.CheckBoxes = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "ElementLie.DescriptionElement";
            glColumn1.Text = "Nom";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 450;
            this.m_wndListeSelection.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeSelection.ContexteUtilisation = "";
            this.m_wndListeSelection.EnableCustomisation = true;
            this.m_wndListeSelection.FocusedItem = null;
            this.m_wndListeSelection.FullRowSelect = true;
            this.m_wndListeSelection.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeSelection.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeSelection.HeaderHeight = 0;
            this.m_wndListeSelection.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeSelection.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeSelection.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeSelection.HeaderVisible = false;
            this.m_wndListeSelection.HeaderWordWrap = false;
            this.m_wndListeSelection.HotColumnIndex = -1;
            this.m_wndListeSelection.HotItemIndex = -1;
            this.m_wndListeSelection.HotTracking = false;
            this.m_wndListeSelection.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeSelection.ImageList = null;
            this.m_wndListeSelection.ItemHeight = 17;
            this.m_wndListeSelection.ItemWordWrap = false;
            this.m_wndListeSelection.ListeSource = null;
            this.m_wndListeSelection.Location = new System.Drawing.Point(8, 56);
            this.m_wndListeSelection.MaxHeight = 17;
            this.m_wndListeSelection.Name = "m_wndListeSelection";
            this.m_wndListeSelection.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeSelection.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeSelection.ShowBorder = true;
            this.m_wndListeSelection.ShowFocusRect = false;
            this.m_wndListeSelection.Size = new System.Drawing.Size(472, 280);
            this.m_wndListeSelection.SortIndex = 0;
            this.m_ExtStyle.SetStyleBackColor(this.m_wndListeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndListeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSelection.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeSelection.TabIndex = 4010;
            this.m_wndListeSelection.Text = "glacialList1";
            this.m_wndListeSelection.TrierAuClicSurEnteteColonne = true;
            // 
            // m_lnkAjouterElement
            // 
            this.m_lnkAjouterElement.Location = new System.Drawing.Point(8, 32);
            this.m_lnkAjouterElement.Name = "m_lnkAjouterElement";
            this.m_lnkAjouterElement.Size = new System.Drawing.Size(256, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAjouterElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAjouterElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterElement.TabIndex = 4007;
            this.m_lnkAjouterElement.TabStop = true;
            this.m_lnkAjouterElement.Text = "Add element|30086";
            this.m_lnkAjouterElement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.m_lnkAjouterElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterElement_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Location = new System.Drawing.Point(192, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 48);
            this.m_ExtStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4014;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(14, 0);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 4012;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(62, 0);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 4013;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_selectionneurElement
            // 
            this.m_selectionneurElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectionneurElement.ElementSelectionne = null;
            this.m_selectionneurElement.FonctionTextNull = null;
            this.m_selectionneurElement.HasLink = true;
            this.m_selectionneurElement.Location = new System.Drawing.Point(8, 8);
            this.m_selectionneurElement.LockEdition = false;
            this.m_selectionneurElement.Name = "m_selectionneurElement";
            this.m_selectionneurElement.SelectedObject = null;
            this.m_selectionneurElement.Size = new System.Drawing.Size(424, 24);
            this.m_ExtStyle.SetStyleBackColor(this.m_selectionneurElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_selectionneurElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurElement.TabIndex = 4053;
            this.m_selectionneurElement.TextNull = "";
            this.m_selectionneurElement.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurElement_OnChangeSelection);
            // 
            // CFormSelectLiensAgendaMultiples
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(504, 400);
            this.Controls.Add(this.m_panelGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormSelectLiensAgendaMultiples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormSelectLiensAgendaMultiples";
            this.Load += new System.EventHandler(this.CFormSelectLiensAgendaMultiples_Load);
            this.m_panelGeneral.ResumeLayout(false);
            this.m_panelGeneral.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		public static bool GetListeElements ( CEntreeAgenda entree, 
			CRelationTypeEntreeAgenda_TypeElementAAgenda typeLien  )
		{
			CFormSelectLiensAgendaMultiples form = new CFormSelectLiensAgendaMultiples( typeLien );
			form.m_entreeAgenda = entree;
			bool bResult = form.ShowDialog() == DialogResult.OK;
			form.Dispose();
			return bResult;
		}

		/// //////////////////////////////////////////////////////////
		private void CFormSelectLiensAgendaMultiples_Load(object sender, System.EventArgs e)
		{
			Type typeForm = CFormFinder.GetTypeFormToList(m_typeLien.TypeElements);
			if ( typeForm == null )
				m_selectionneurElement.Visible = false;
			else
			{
				m_selectionneurElement.InitForSelectAvecFiltreDeBase ( 
                    m_typeLien.TypeElements,
					"DescriptionElement",
					m_typeLien.FiltreDataAssocie,
					true );
			}
			UpdateListe();
			
		}

		/// //////////////////////////////////////////////////////////
		private void UpdateListe()
		{
			CListeObjetsDonnees liste = m_entreeAgenda.RelationsElementsAgenda;
			liste.Filtre = new CFiltreData ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId+"=@1",
				m_typeLien.Id );
			m_wndListeSelection.ListeSource = liste;
			m_wndListeSelection.Refresh();
			m_lblNbSel.Text = liste.Count+" element";
			if ( liste.Count > 1 )
				m_lblNbSel.Text += "s";
		}
			

		/// //////////////////////////////////////////////////////////
		private void m_lnkAjouterElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AjouteElementUnique();
		}

		private void AjouteElementUnique()
		{
			if ( m_selectionneurElement.ElementSelectionne is CObjetDonneeAIdNumerique )
			{
				CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)m_selectionneurElement.ElementSelectionne;
				CListeObjetsDonnees liste = m_entreeAgenda.RelationsElementsAgenda;
				liste.Filtre = new CFiltreData ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId+"=@1",
					m_typeLien.Id );
				liste.Filtre = CFiltreData.GetAndFiltre(liste.Filtre,new CFiltreData ( CRelationEntreeAgenda_ElementAAgenda.c_champIdElementAAgenda+"=@1 and "+
					CRelationEntreeAgenda_ElementAAgenda.c_champTypeElementAAgenda+"=@2",
					objet.Id,
					objet.GetType().ToString() ));
				if ( liste.Count == 0 )
				{
					CRelationEntreeAgenda_ElementAAgenda rel = new CRelationEntreeAgenda_ElementAAgenda ( m_entreeAgenda.ContexteDonnee );
					rel.CreateNewInCurrentContexte();
					rel.EntreeAgenda = m_entreeAgenda;
					rel.ElementLie = objet;
					rel.RelationTypeEntree_TypeElement = m_typeLien;
					UpdateListe();
				}
			}
		}

		
		/// //////////////////////////////////////////////////////////
		private void m_lnkDelete_LinkClicked(object sender, System.EventArgs e)
		{
			ArrayList lst = new ArrayList ( m_wndListeSelection.SelectedItems );
			foreach ( CRelationEntreeAgenda_ElementAAgenda rel in lst )
				rel.Delete();
			m_wndListeSelection.Refresh();
		}

		/// //////////////////////////////////////////////////////////
		private class CMenuItemFiltre : MenuItem
		{
			public readonly CFiltreDynamiqueInDb Filtre;

			public CMenuItemFiltre ( CFiltreDynamiqueInDb filtre )
			{
				Filtre = filtre;
				Text = DynamicClassAttribute.GetNomConvivial ( filtre.TypeElements )+"-"+filtre.Libelle ;
			}
		}

		/// //////////////////////////////////////////////////////////
		private void m_lnkAjoutParFiltre_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_menuFiltres.MenuItems.Clear();
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CFiltreDynamiqueInDb));
			liste.Filtre = new CFiltreData ( CFiltreDynamiqueInDb.c_champTypeElements+"=@1",
				m_typeLien.TypeElementsString );
			foreach ( CFiltreDynamiqueInDb filtre in liste )
			{
				MenuItem item = new CMenuItemFiltre ( filtre );
				item.Click += new EventHandler(ItemFiltreClick);
				m_menuFiltres.MenuItems.Add ( item );
			}
			m_menuFiltres.Show ( m_lnkAjoutParFiltre, new Point ( 0, m_lnkAjoutParFiltre.Height ) );
		}

		/// //////////////////////////////////////////////////////////
		private void ItemFiltreClick ( object sender, EventArgs e )
		{
			if ( !(sender is CMenuItemFiltre ))
				return;
			CFiltreDynamiqueInDb filtreInDb = ((CMenuItemFiltre)sender).Filtre;
			CFiltreDynamique filtreDyn = filtreInDb.Filtre;
			CFiltreData filtreData = CFormFiltreDynamic.GetFiltreData ( filtreDyn );
			if ( filtreData == null )
				return;
			CListeObjetsDonnees listeSel = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, m_typeLien.TypeElements );
			filtreData = CFiltreData.GetAndFiltre ( filtreData, m_typeLien.FiltreDataAssocie );
			listeSel.Filtre = filtreData;

			try
			{
				if ( listeSel.CountNoLoad == 0 )
				{
					CFormAlerte.Afficher(I.T("No @1 matches the filter|30089",DynamicClassAttribute.GetNomConvivial(m_typeLien.TypeElements)), EFormAlerteType.Exclamation);
					return;
				}
                if (CFormAlerte.Afficher(I.T("You will add @1 element(s) to the selection. Continue ?|30088",listeSel.CountNoLoad.ToString()), EFormAlerteType.Question) == DialogResult.Yes )
				{
					CListeObjetsDonnees listeExiste = m_entreeAgenda.RelationsElementsAgenda;
					listeExiste.Filtre = new CFiltreData ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId+"=@1",
						m_typeLien.Id );
					listeExiste.Filtre = CFiltreData.GetAndFiltre(listeExiste.Filtre, new CFiltreData( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId+"=@1",
						m_typeLien.Id ) );
					using ( CWaitCursor waiter = new CWaitCursor() )
					{
						foreach ( CObjetDonneeAIdNumerique objet in listeSel )
						{
							listeExiste.Filtre = new CFiltreData ( CRelationEntreeAgenda_ElementAAgenda.c_champIdElementAAgenda+"=@1",
								objet.Id );
							if ( listeExiste.Count == 0 )
							{
								CRelationEntreeAgenda_ElementAAgenda rel = new CRelationEntreeAgenda_ElementAAgenda ( m_entreeAgenda.ContexteDonnee );
								rel.CreateNewInCurrentContexte();
								rel.EntreeAgenda = m_entreeAgenda;
								rel.RelationTypeEntree_TypeElement = m_typeLien;
								rel.ElementLie = objet;
							}
						}
						UpdateListe();
					}
				}
			}
			catch
			{
			}
		}

		private void m_selectionneurElement_OnChangeSelection(object sender, System.EventArgs e)
		{
			AjouteElementUnique();
		}
			
		
	}
}
