using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;

using sc2i.win32.data;
using sc2i.win32.data.dynamic;
using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.workflow;
using System.Collections.Generic;


namespace timos.win32.composants
{
	/// <summary>
	/// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e de CPanelSelectListeElements.
	/// </summary>
	public class CPanelSelectListeElements : System.Windows.Forms.UserControl, IControlALockEdition
	{
		private ArrayList m_listeAutorisee = null;
		private CFiltreData m_filtreInitial = null;
		private Type m_typElements = null;
        private List<CObjetDonneeAIdNumerique> m_listeElements = new List<CObjetDonneeAIdNumerique>();
		private System.Windows.Forms.LinkLabel m_lnkAjoutParFiltre;
		private sc2i.win32.common.CWndLinkStd m_lnkDelete;
        private sc2i.win32.common.GlacialList m_wndListeSelection;
		//private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurElement;
		private System.Windows.Forms.ContextMenu m_menuPopup;
		private System.Windows.Forms.Label m_lblNbSel;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.LinkLabel m_lnkAjoutParListe;
		private System.Windows.Forms.PictureBox m_btnSaveListe;
		private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurElement;
        protected CExtStyle m_ExtStyle;
        private CWndLinkStd m_lnkAjouter;
		private System.ComponentModel.IContainer components;

		public CPanelSelectListeElements()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODOÃƒâ€šÃ‚Â : ajoutez les initialisations aprÃƒÆ’Ã‚Â¨s l'appel ÃƒÆ’Ã‚Â  InitializeComponent

		}

		/// <summary> 
		/// Nettoyage des ressources utilisÃƒÆ’Ã‚Â©es.
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

		#region Code gÃƒÆ’Ã‚Â©nÃƒÆ’Ã‚Â©rÃƒÆ’Ã‚Â© par le Concepteur de composants
		/// <summary> 
		/// MÃƒÆ’Ã‚Â©thode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette mÃƒÆ’Ã‚Â©thode avec l'ÃƒÆ’Ã‚Â©diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelSelectListeElements));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.m_lnkAjoutParFiltre = new System.Windows.Forms.LinkLabel();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeSelection = new sc2i.win32.common.GlacialList();
            this.m_menuPopup = new System.Windows.Forms.ContextMenu();
            this.m_lblNbSel = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_lnkAjoutParListe = new System.Windows.Forms.LinkLabel();
            this.m_btnSaveListe = new System.Windows.Forms.PictureBox();
            this.m_selectionneurElement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveListe)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lnkAjoutParFiltre
            // 
            this.m_lnkAjoutParFiltre.Location = new System.Drawing.Point(131, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjoutParFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjoutParFiltre.Name = "m_lnkAjoutParFiltre";
            this.m_lnkAjoutParFiltre.Size = new System.Drawing.Size(146, 16);
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
            this.m_lnkDelete.Location = new System.Drawing.Point(1, 226);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(154, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDelete.TabIndex = 4015;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // m_wndListeSelection
            // 
            this.m_wndListeSelection.AllowColumnResize = true;
            this.m_wndListeSelection.AllowDrop = true;
            this.m_wndListeSelection.AllowMultiselect = true;
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
            this.m_wndListeSelection.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeSelection.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "DescriptionElement";
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
            this.m_wndListeSelection.HasImages = false;
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
            this.m_wndListeSelection.Location = new System.Drawing.Point(0, 46);
            this.m_wndListeSelection.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSelection, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeSelection.Name = "m_wndListeSelection";
            this.m_wndListeSelection.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeSelection.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeSelection.ShowBorder = true;
            this.m_wndListeSelection.ShowFocusRect = false;
            this.m_wndListeSelection.Size = new System.Drawing.Size(472, 180);
            this.m_wndListeSelection.SortIndex = 0;
            this.m_ExtStyle.SetStyleBackColor(this.m_wndListeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndListeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSelection.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeSelection.TabIndex = 4010;
            this.m_wndListeSelection.Text = "glacialList1";
            this.m_wndListeSelection.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeSelection.DragOver += new System.Windows.Forms.DragEventHandler(this.m_wndListeSelection_DragOver);
            this.m_wndListeSelection.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_wndListeSelection_DragDrop);
            this.m_wndListeSelection.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_wndListeSelection_DragEnter);
            // 
            // m_lblNbSel
            // 
            this.m_lblNbSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblNbSel.Location = new System.Drawing.Point(296, 232);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNbSel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNbSel.Name = "m_lblNbSel";
            this.m_lblNbSel.Size = new System.Drawing.Size(160, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblNbSel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblNbSel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNbSel.TabIndex = 4054;
            this.m_lblNbSel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lnkAjoutParListe
            // 
            this.m_lnkAjoutParListe.Location = new System.Drawing.Point(295, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjoutParListe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjoutParListe.Name = "m_lnkAjoutParListe";
            this.m_lnkAjoutParListe.Size = new System.Drawing.Size(133, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAjoutParListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAjoutParListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjoutParListe.TabIndex = 4055;
            this.m_lnkAjoutParListe.TabStop = true;
            this.m_lnkAjoutParListe.Text = "Add by list|30292";
            this.m_lnkAjoutParListe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjoutParListe_LinkClicked);
            // 
            // m_btnSaveListe
            // 
            this.m_btnSaveListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSaveListe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSaveListe.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSaveListe.Image")));
            this.m_btnSaveListe.Location = new System.Drawing.Point(453, 230);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSaveListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnSaveListe.Name = "m_btnSaveListe";
            this.m_btnSaveListe.Size = new System.Drawing.Size(14, 14);
            this.m_btnSaveListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_ExtStyle.SetStyleBackColor(this.m_btnSaveListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnSaveListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSaveListe.TabIndex = 4056;
            this.m_btnSaveListe.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnSaveListe, "Sauvegarde cette liste");
            this.m_btnSaveListe.Click += new System.EventHandler(this.m_btnSaveListe_Click);
            // 
            // m_selectionneurElement
            // 
            this.m_selectionneurElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectionneurElement.BackColor = System.Drawing.Color.Transparent;
            this.m_selectionneurElement.ElementSelectionne = null;
            this.m_selectionneurElement.FonctionTextNull = null;
            this.m_selectionneurElement.HasLink = true;
            this.m_selectionneurElement.Location = new System.Drawing.Point(0, 0);
            this.m_selectionneurElement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectionneurElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectionneurElement.Name = "m_selectionneurElement";
            this.m_selectionneurElement.SelectedObject = null;
            this.m_selectionneurElement.Size = new System.Drawing.Size(472, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_selectionneurElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_selectionneurElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurElement.TabIndex = 4057;
            this.m_selectionneurElement.TextNull = "";
            this.m_selectionneurElement.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurElement_OnChangeSelection);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(3, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(105, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 4015;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // CPanelSelectListeElements
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_selectionneurElement);
            this.Controls.Add(this.m_btnSaveListe);
            this.Controls.Add(this.m_lnkAjoutParListe);
            this.Controls.Add(this.m_lblNbSel);
            this.Controls.Add(this.m_lnkAjoutParFiltre);
            this.Controls.Add(this.m_wndListeSelection);
            this.Controls.Add(this.m_lnkAjouter);
            this.Controls.Add(this.m_lnkDelete);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelSelectListeElements";
            this.Size = new System.Drawing.Size(472, 248);
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelSelectListeElements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void Init ( Type typeElements, CObjetDonneeAIdNumerique[] objets, CFiltreData filtreInitial )
		{
			m_typElements = typeElements;
			Type typeForm = CFormFinder.GetTypeFormToList(typeElements);
            m_listeElements = new List<CObjetDonneeAIdNumerique>();
			if ( objets != null )
				m_listeElements.AddRange ( objets );
			if ( typeForm == null )
			{
				m_selectionneurElement.Visible = false;
				m_lnkAjouter.Visible = false;
			}
			else
			{
				m_lnkAjouter.Visible = true;
				m_selectionneurElement.Visible = true;
				m_filtreInitial = filtreInitial;
				m_selectionneurElement.InitForSelectAvecFiltreDeBase ( 
                    typeElements,
					"DescriptionElement",
					filtreInitial,
					true );
                m_selectionneurElement.ElementSelectionne = null;
			}
			if ( m_filtreInitial != null )
			{
				CListeObjetsDonnees listTmp = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeElements );
				m_listeAutorisee = listTmp.ToArrayList();
			}
			else
				m_listeAutorisee = null;
			UpdateListe();
		}

		/// //////////////////////////////////////////////////////////
		public CObjetDonneeAIdNumerique[] ElementSelectionnes
		{
			get
			{
				return m_listeElements.ToArray();
			}
		}

        public IEnumerable<CDbKey> ListeDbKeysElements
        {
            get
            {
                return from elt in m_listeElements select elt.DbKey;
            }
        }

		/// //////////////////////////////////////////////////////////
		private void UpdateListe()
		{
			m_wndListeSelection.ListeSource = m_listeElements;
			m_wndListeSelection.Refresh();
			m_lblNbSel.Text = m_listeElements.Count+" element";
			if ( m_listeElements.Count > 1 )
				m_lblNbSel.Text += "s";

            m_wndListeSelection.ClearSelection();
		}

		/// //////////////////////////////////////////////////////////
        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            AjouteElementUnique();
        }

		/// //////////////////////////////////////////////////////////
		private void AjouteElementUnique()
		{
			if ( m_selectionneurElement.ElementSelectionne is CObjetDonneeAIdNumerique )
			{
				CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)m_selectionneurElement.ElementSelectionne;
                m_selectionneurElement.ElementSelectionne = null;
                if (AddElement(objet))
                {
                    if (OnChangeSelection != null)
                        OnChangeSelection(this, new EventArgs());
                    UpdateListe();
                }
			}
		}

		/// //////////////////////////////////////////////////////////
		private bool AddElement ( CObjetDonneeAIdNumerique objet )
		{
			if(  !m_listeElements.Contains ( objet ) && (m_listeAutorisee == null || m_listeAutorisee.Contains ( objet ) ) )
			{
				m_listeElements.Add ( objet );
				return true;
			}
			return false;
		}

		/// //////////////////////////////////////////////////////////
		private void m_lnkDelete_LinkClicked(object sender, System.EventArgs e)
		{
			ArrayList lst = new ArrayList ( m_wndListeSelection.SelectedItems );
            foreach (CObjetDonneeAIdNumerique objet in lst)
                m_listeElements.Remove(objet);
			if ( lst.Count > 0 && OnChangeSelection != null )
					OnChangeSelection ( this, new EventArgs ( ) );
			UpdateListe();
		}

		/// //////////////////////////////////////////////////////////
		private class CMenuItemFiltre : MenuItem
		{
			public readonly CFiltreDynamiqueInDb Filtre;

			public CMenuItemFiltre ( CFiltreDynamiqueInDb filtre )
			{
				Filtre = filtre;
				Text = filtre.Libelle;
			}
		}

		/// //////////////////////////////////////////////////////////
		private void m_lnkAjoutParFiltre_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_menuPopup.MenuItems.Clear();
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CFiltreDynamiqueInDb));
			liste.Filtre = new CFiltreData ( CFiltreDynamiqueInDb.c_champTypeElements+"=@1",
				m_typElements.ToString() );
			foreach ( CFiltreDynamiqueInDb filtre in liste )
			{
				MenuItem item = new CMenuItemFiltre ( filtre );
				item.Click += new EventHandler(ItemFiltreClick);
				m_menuPopup.MenuItems.Add ( item );
			}
			m_menuPopup.Show ( m_lnkAjoutParFiltre, new Point ( 0, m_lnkAjoutParFiltre.Height ) );
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
			CListeObjetsDonnees listeSel = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, m_typElements);
			filtreData = CFiltreData.GetAndFiltre ( filtreData, m_filtreInitial );
			listeSel.Filtre = filtreData;

			try
			{
				if ( listeSel.CountNoLoad == 0 )
				{
					CFormAlerte.Afficher("Aucun "+DynamicClassAttribute.GetNomConvivial(m_typElements)+" ne correspond au filtre", EFormAlerteType.Exclamation);
					return;
				}
                if (CFormAlerte.Afficher(I.T("You will add @1 element(s) to the selection. Continue ?|30088", listeSel.CountNoLoad.ToString()), EFormAlerteType.Question) == DialogResult.Yes)
				{
					using ( CWaitCursor waiter = new CWaitCursor() )
					{
						bool bModif = false;
						foreach ( CObjetDonneeAIdNumerique objet in listeSel )
							bModif |= AddElement ( objet );
						if ( bModif && OnChangeSelection != null )
							OnChangeSelection ( this, new EventArgs ( ) );
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
            //if ( m_selectionneurElement.ElementSelectionne != null )
            //    AjouteElementUnique();
		}

		private void CPanelSelectListeElements_Load(object sender, System.EventArgs e)
		{
		
		}

		/// //////////////////////////////////////////////////////////
		private class CMenuItemListe : MenuItem
		{
			public readonly CListeEntites Liste;

			public CMenuItemListe ( CListeEntites liste )
			{
				Liste = liste;
				Text = liste.Libelle;
			}
		}

		/// //////////////////////////////////////////////////////////
		private void m_lnkAjoutParListe_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_menuPopup.MenuItems.Clear();
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CListeEntites));
			liste.Filtre = new CFiltreData ( CListeEntites.c_champTypeElements+"=@1",
				m_typElements.ToString() );
			foreach ( CListeEntites listeEntites in liste )
			{
				MenuItem item = new CMenuItemListe ( listeEntites );
				item.Click += new EventHandler(item_Liste_Click);
				m_menuPopup.MenuItems.Add ( item );
			}
			m_menuPopup.Show ( m_lnkAjoutParListe, new Point ( 0, m_lnkAjoutParListe.Height ) );
		}
		#region Membres de IControlALockEdition

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this , new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

		public event EventHandler OnChangeSelection;

		private void item_Liste_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemListe )
			{
				CListeEntites liste = ((CMenuItemListe)sender).Liste;
				CObjetDonneeAIdNumerique[] objets = liste.ElementsLies;
                if (CFormAlerte.Afficher(I.T("You will add @1 element(s) to the selection. Continue ?|30088",objets.Length.ToString() ), EFormAlerteType.Question) == DialogResult.Yes )
					using ( CWaitCursor waiter = new CWaitCursor() )
					{
						bool bModif = false;
						foreach ( CObjetDonneeAIdNumerique objet in objets )
							bModif |= AddElement ( objet );
						if ( bModif && OnChangeSelection != null )
							OnChangeSelection ( this, new EventArgs ( ) );
						UpdateListe();
					}
			}
		}

		private void m_btnSaveListe_Click(object sender, System.EventArgs e)
		{
			if ( m_listeElements.Count == 0 )
			{
				CFormAlerte.Afficher("List is empty !|30122", EFormAlerteType.Exclamation);
				return;
			}
			m_menuPopup.MenuItems.Clear();
			MenuItem itemNew = new MenuItem("<<Nouvelle liste>>");
			itemNew.Click +=new EventHandler(SaveAsNewListe);
			m_menuPopup.MenuItems.Add ( itemNew );
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CListeEntites));
			liste.Filtre = new CFiltreData ( CListeEntites.c_champTypeElements+"=@1",
				m_typElements.ToString() );
			foreach ( CListeEntites listeEntites in liste )
			{
				MenuItem item = new CMenuItemListe ( listeEntites );
				item.Click += new EventHandler(item_Liste_Save_Click);
				m_menuPopup.MenuItems.Add ( item );
			}
			m_menuPopup.Show ( m_btnSaveListe, new Point ( 0, m_btnSaveListe.Height ) );
		}

		/// ////////////////////////////////////////////////
		private void SaveAsNewListe(object sender, EventArgs e)
		{
			string strNom = "";
			bool bBoucle = true;
			while ( bBoucle )
			{
				bBoucle = InputBox.GetString ( ref strNom, I.T("List name|30123" ));
				if ( bBoucle )
				{
					bBoucle = false;
					CListeEntites liste = new CListeEntites ( CSc2iWin32DataClient.ContexteCourant );
					liste.CreateNew();
					liste.Libelle = strNom;
					liste.ElementsLies = ElementSelectionnes;
					CResultAErreur result = liste.VerifieDonnees(true);
					if ( result )
						result = liste.CommitEdit();
					if(  !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
						bBoucle = true;
					}
					else
						CFormAlerte.Afficher(I.T("List saved as '@1'|30124",strNom));
				}
			}
		}

		/// ////////////////////////////////////////////////
		private void item_Liste_Save_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemListe )
			{
				CListeEntites liste = ((CMenuItemListe)sender).Liste;
				if ( CFormAlerte.Afficher(I.T("Replace List '@1' ?|30125",liste.Libelle),
					EFormAlerteType.Question) == DialogResult.Yes )
				{
					liste.BeginEdit();
					liste.ElementsLies = ElementSelectionnes;
					CResultAErreur result = liste.CommitEdit();
					if ( !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
					}
					else
						CFormAlerte.Afficher("List saved|30126");
				}
			}
		}

        private void m_wndListeSelection_DragDrop(object sender, DragEventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;

            object listeReferences = e.Data.GetData(typeof(CReferenceObjetDonnee[]));
            if (listeReferences != null)
            {
                CReferenceObjetDonnee[] refObjets = listeReferences as CReferenceObjetDonnee[];
                if (refObjets != null)
                {
                    foreach (CReferenceObjetDonnee reference in refObjets)
                    {
                        CObjetDonneeAIdNumerique objet = reference.GetObjet() as CObjetDonneeAIdNumerique;
                        if (objet != null)
                        {
                            AddElement(objet);
                            if (OnChangeSelection != null)
                                OnChangeSelection(this, new EventArgs());
                            UpdateListe();
                        }

                    }
                }
            }
            else
            {
                object uneReference = e.Data.GetData(typeof(CReferenceObjetDonnee));
                if (uneReference != null)
                {
                    CReferenceObjetDonnee reference = uneReference as CReferenceObjetDonnee;
                    if (reference != null)
                    {
                        CObjetDonneeAIdNumerique objet = reference.GetObjet() as CObjetDonneeAIdNumerique;
                        if (objet != null)
                        {
                            AddElement(objet);
                            if (OnChangeSelection != null)
                                OnChangeSelection(this, new EventArgs());
                            UpdateListe();
                        }
                    }
                }
            }
        }

        private void m_wndListeSelection_DragEnter(object sender, DragEventArgs e)
        {
            VerifiePossibiliteDragDropSurListeElements(e);
        }

        private void m_wndListeSelection_DragOver(object sender, DragEventArgs e)
        {
            VerifiePossibiliteDragDropSurListeElements(e);
        }

        //---------------------------------------------------------------------------
        private void VerifiePossibiliteDragDropSurListeElements(DragEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                CReferenceObjetDonnee refObjet = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refObjet != null && refObjet.TypeObjet == m_typElements)
                {
                    e.Effect = DragDropEffects.Link;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }
        
	}
}
