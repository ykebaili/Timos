using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.navigation;
using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.common;
using sc2i.process;
using sc2i.common.recherche;
using System.Collections.Generic;
using System.Data;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
using timos.securite;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormListeStandardTimos.
	/// </summary>
	public class CFormListeStandardTimos : sc2i.win32.data.navigation.CFormListeStandard, IFormNavigable
	{
		protected System.Windows.Forms.LinkLabel m_lnkListe;
		private System.Windows.Forms.ContextMenu m_menuPopup;
		protected System.Windows.Forms.PictureBox m_btnActions;
		private System.Windows.Forms.ContextMenu m_menuActions;
		protected System.Windows.Forms.Panel m_panelActions;
		protected System.Windows.Forms.LinkLabel m_lnkActions;
        protected Panel m_panelLinkList;
        protected PictureBox m_imgListe;
        private LinkLabel m_lnkRechercheObjetsNonUtilises;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormListeStandardTimos()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		public CFormListeStandardTimos( Type tp)
			:base(tp)
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		public CFormListeStandardTimos ( CListeObjetsDonnees liste )
			:base ( liste )
		{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeStandardTimos));
            this.m_lnkListe = new System.Windows.Forms.LinkLabel();
            this.m_menuPopup = new System.Windows.Forms.ContextMenu();
            this.m_btnActions = new System.Windows.Forms.PictureBox();
            this.m_menuActions = new System.Windows.Forms.ContextMenu();
            this.m_panelActions = new System.Windows.Forms.Panel();
            this.m_lnkRechercheObjetsNonUtilises = new System.Windows.Forms.LinkLabel();
            this.m_lnkActions = new System.Windows.Forms.LinkLabel();
            this.m_panelLinkList = new System.Windows.Forms.Panel();
            this.m_imgListe = new System.Windows.Forms.PictureBox();
            this.m_panelMilieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            this.m_panelListe.Size = new System.Drawing.Size(728, 413);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.Load += new System.EventHandler(this.m_panelListe_Load);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 413);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(728, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 413);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 413);
            this.m_panelBas.Size = new System.Drawing.Size(728, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(728, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_panelActions);
            this.m_panelMilieu.Controls.Add(this.m_panelLinkList);
            this.m_panelMilieu.Size = new System.Drawing.Size(728, 413);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelLinkList, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelActions, 0);
            // 
            // m_lnkListe
            // 
            this.m_lnkListe.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkListe.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkListe.Location = new System.Drawing.Point(21, 7);
            this.m_lnkListe.Name = "m_lnkListe";
            this.m_lnkListe.Size = new System.Drawing.Size(47, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListe.TabIndex = 2;
            this.m_lnkListe.TabStop = true;
            this.m_lnkListe.Text = "List|168";
            this.m_lnkListe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListe_LinkClicked);
            // 
            // m_btnActions
            // 
            this.m_btnActions.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnActions.Image = global::timos.Properties.Resources.applications;
            this.m_btnActions.Location = new System.Drawing.Point(0, 0);
            this.m_btnActions.Name = "m_btnActions";
            this.m_btnActions.Size = new System.Drawing.Size(24, 24);
            this.m_btnActions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnActions.TabIndex = 3;
            this.m_btnActions.TabStop = false;
            this.m_btnActions.Click += new System.EventHandler(this.m_btnActions_Click);
            // 
            // m_panelActions
            // 
            this.m_panelActions.BackColor = System.Drawing.Color.Transparent;
            this.m_panelActions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelActions.BackgroundImage")));
            this.m_panelActions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelActions.Controls.Add(this.m_lnkRechercheObjetsNonUtilises);
            this.m_panelActions.Controls.Add(this.m_lnkActions);
            this.m_panelActions.Controls.Add(this.m_btnActions);
            this.m_panelActions.Location = new System.Drawing.Point(361, 1);
            this.m_panelActions.Name = "m_panelActions";
            this.m_panelActions.Size = new System.Drawing.Size(142, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelActions.TabIndex = 4;
            this.m_panelActions.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelActions_Paint);
            // 
            // m_lnkRechercheObjetsNonUtilises
            // 
            this.m_lnkRechercheObjetsNonUtilises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkRechercheObjetsNonUtilises.Location = new System.Drawing.Point(104, 6);
            this.m_lnkRechercheObjetsNonUtilises.Name = "m_lnkRechercheObjetsNonUtilises";
            this.m_lnkRechercheObjetsNonUtilises.Size = new System.Drawing.Size(35, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRechercheObjetsNonUtilises, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRechercheObjetsNonUtilises, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRechercheObjetsNonUtilises.TabIndex = 6;
            this.m_lnkRechercheObjetsNonUtilises.TabStop = true;
            this.m_lnkRechercheObjetsNonUtilises.Text = ">>>";
            this.m_lnkRechercheObjetsNonUtilises.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRechercheObjetsNonUtilises_LinkClicked);
            // 
            // m_lnkActions
            // 
            this.m_lnkActions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkActions.Location = new System.Drawing.Point(24, 2);
            this.m_lnkActions.Name = "m_lnkActions";
            this.m_lnkActions.Size = new System.Drawing.Size(76, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActions.TabIndex = 4;
            this.m_lnkActions.TabStop = true;
            this.m_lnkActions.Text = "Actions|169";
            this.m_lnkActions.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.m_lnkActions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkActions_LinkClicked);
            // 
            // m_panelLinkList
            // 
            this.m_panelLinkList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelLinkList.BackgroundImage")));
            this.m_panelLinkList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelLinkList.Controls.Add(this.m_imgListe);
            this.m_panelLinkList.Controls.Add(this.m_lnkListe);
            this.m_panelLinkList.Location = new System.Drawing.Point(59, 1);
            this.m_panelLinkList.Name = "m_panelLinkList";
            this.m_panelLinkList.Size = new System.Drawing.Size(69, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLinkList.TabIndex = 5;
            this.m_panelLinkList.Visible = false;
            // 
            // m_imgListe
            // 
            this.m_imgListe.BackColor = System.Drawing.Color.Transparent;
            this.m_imgListe.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imgListe.Image = global::timos.Properties.Resources.liste;
            this.m_imgListe.Location = new System.Drawing.Point(0, 0);
            this.m_imgListe.Name = "m_imgListe";
            this.m_imgListe.Size = new System.Drawing.Size(24, 24);
            this.m_imgListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imgListe.TabIndex = 4;
            this.m_imgListe.TabStop = false;
            this.m_imgListe.Click += new System.EventHandler(this.m_imgListe_Click);
            // 
            // CFormListeStandardTimos
            // 
            this.ClientSize = new System.Drawing.Size(728, 413);
            this.Name = "CFormListeStandardTimos";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormListeStandardTimos";
            this.Load += new System.EventHandler(this.CFormListeStandardTimos_Load);
            this.m_panelMilieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormListeStandardTimos_Load(object sender, System.EventArgs e)
		{
			CCustomiseurFenetresStandard.BrancheSurFenetre(this);
			m_btnActions.BringToFront();
#if DEBUG
            if(!DesignMode)
                m_lnkRechercheObjetsNonUtilises.Visible = typeof(IObjetCherchable).IsAssignableFrom(ListeObjets.TypeObjets);
#else
            m_lnkRechercheObjetsNonUtilises.Visible = false;
#endif
        }

		/// //////////////////////////////////////////////////////////
		private class CMenuItemListe : MenuItem
		{
			public readonly CListeEntites Liste;

			public CMenuItemListe ( CListeEntites liste )
			{
				Liste = liste;
				if ( liste != null )
					Text = liste.Libelle;
				else
					Text = "All|36";
			}
		}

		private void m_lnkListe_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            InitMenuListe();
		}

        private void InitMenuListe()
        {
            m_menuPopup.MenuItems.Clear();

            MenuItem item = new CMenuItemListe(null);
            item.Click += new EventHandler(item_Liste_Click);
            m_menuPopup.MenuItems.Add(item);

            CListeObjetsDonnees liste = new CListeObjetsDonnees(ListeObjets.ContexteDonnee, typeof(CListeEntites));
            liste.Filtre = new CFiltreData(CListeEntites.c_champTypeElements + "=@1",
                ListeObjets.TypeObjets.ToString());
            foreach (CListeEntites listeEntites in liste)
            {
                item = new CMenuItemListe(listeEntites);
                item.Click += new EventHandler(item_Liste_Click);
                m_menuPopup.MenuItems.Add(item);
            }
            m_menuPopup.Show(m_lnkListe, new Point(0, m_lnkListe.Height));
        }

		/// //////////////////////////////////////////////////////////
		private void item_Liste_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemListe )
			{
				CListeEntites liste = ((CMenuItemListe)sender).Liste;
                if (liste == null)
                {
                    m_panelListe.ListeObjets.Filtre = null;
                    m_panelListe.RemplirGrille();
                }
                else
                {
                    if (liste.IsDynamique)
                    {
                        CFiltreDynamique filtre = liste.FiltreDynamique;
                        CResultAErreur result = filtre.GetFiltreData();
                        if (result.Data is CFiltreData)
                        {
                            m_panelListe.ListeObjets.Filtre = (CFiltreData)result.Data;
                            m_panelListe.RemplirGrille();
                        }
                    }
                    else
                    {
                        string strFiltre = "";
                        foreach (CObjetDonneeAIdNumerique objet in liste.ElementsLies)
                            strFiltre += objet.Id.ToString() + ",";
                        if (strFiltre.Length > 0)
                        {
                            strFiltre = strFiltre.Substring(0, strFiltre.Length - 1);
                        }
                        CStructureTable structure = CStructureTable.GetStructure(liste.TypeElements);
                        m_panelListe.ListeObjets.Filtre = new CFiltreData(
                            structure.ChampsId[0].NomChamp + " in (" +
                            strFiltre + ")");
                        m_panelListe.RemplirGrille();
                    }
                }
			}
		}

		
		private class CMenuItemDeclencheur : MenuItem
		{
			public readonly IDeclencheurAction Declencheur;
			public CMenuItemDeclencheur ( IDeclencheurAction declencheur )
			{
				Declencheur = declencheur;
				Text = declencheur.Libelle;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_btnActions_Click(object sender, System.EventArgs e)
		{
			CListeObjetsDonnees listeCheckes = m_panelListe.GetElementsCheckes();
			if ( listeCheckes.Count == 0 )
			{
				CFormAlerte.Afficher(I.T( "No element selected for action execution|1011"), EFormAlerteType.Exclamation);
				return;
			}

            CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(m_panelListe.ListeObjets.ContexteDonnee);
            bool bIsAdmin = user != null && user.GetDonneeDroit(CDroitDeBaseSC2I.c_droitAdministrationSysteme) != null;

			Hashtable listeActions = new Hashtable();
			using ( CWaitCursor curseur = new CWaitCursor() )
			{
				bool bFirst = true;
				//Cherche les actions applicables à tous les éléments
				foreach ( CObjetDonneeAIdNumerique objet in listeCheckes )
				{
					IDeclencheurAction[] declencheurs = CRecuperateurDeclencheursActions.GetActionsManuelles ( objet, false );
					Hashtable newTbl = new Hashtable();
					foreach ( IDeclencheurAction declencheur in declencheurs )
						if ( bFirst || listeActions[declencheur] != null )
							newTbl[declencheur] = true;
					bFirst = false;
					if ( newTbl.Count == 0 && !bIsAdmin)
					{
						CFormAlerte.Afficher(I.T( "There is no action to execute on the selected elements|1012"), EFormAlerteType.Exclamation);
						return;
					}
					listeActions = newTbl;
				}
			}
			m_menuActions.MenuItems.Clear();
			foreach ( IDeclencheurAction declencheur in listeActions.Keys )
			{
				string strMenu = "";
				if ( declencheur is IDeclencheurActionManuelle )
					strMenu = ((IDeclencheurActionManuelle)declencheur).MenuManuel;
				string[] strMenus = strMenu.Split('/');
				Menu.MenuItemCollection listeSousMenus = m_menuActions.MenuItems;
				if ( strMenus.Length > 0 )
				{
					foreach ( string strSousMenu in strMenus )
					{
						if ( strSousMenu.Trim().Length > 0 )
						{
							MenuItem sousMenu = null;
							foreach ( MenuItem item in listeSousMenus )
								if ( item.Text == strSousMenu )
								{
									sousMenu = item;
									break;
								}
							if ( sousMenu == null )
							{
								sousMenu = new MenuItem ( strSousMenu );
								listeSousMenus.Add ( sousMenu );
							}
							listeSousMenus = sousMenu.MenuItems;
						}
					}
				}
				CMenuItemDeclencheur itemAction = new CMenuItemDeclencheur ( declencheur );
				itemAction.Click += new EventHandler(MenuDeclencheurClick);
				listeSousMenus.Add ( itemAction );
			}

            if (bIsAdmin)
            {
                m_menuActions.MenuItems.Add(new MenuItem());
                MenuItem itemApplyFormula = new MenuItem(I.T("Apply formula|20834"));
                m_menuActions.MenuItems.Add(itemApplyFormula);
                itemApplyFormula.Click += new EventHandler(itemApplyFormula_Click);
            }
			m_menuActions.Show ( m_btnActions, new Point ( 0, m_btnActions.Height ) );
		}

        void itemApplyFormula_Click(object sender, EventArgs e)
        {
            if (CFormAppliquerFormule.ApplyFormula(m_panelListe.GetElementsCheckes()))
            {
                Refresh();
            }
        }

		//-------------------------------------------------------------------------
		private void MenuDeclencheurClick ( object sender, EventArgs e )
		{
			if ( sender is CMenuItemDeclencheur )
			{
				IDeclencheurAction declencheur = ((CMenuItemDeclencheur)sender).Declencheur;
				/*CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess(TypeEvenement.Manuel);
				CResultAErreur result = declencheur.RunEventMultiple ( 
					(CObjetDonneeAIdNumeriqueAuto[])m_panelListe.GetElementsCheckes().ToArray(typeof(CObjetDonneeAIdNumeriqueAuto)),
					infoDeclencheur );*/
				CResultAErreur result = CFormExecuteProcess.RunEventMultiple ( 
					declencheur,
					(CObjetDonneeAIdNumerique[])m_panelListe.GetElementsCheckes().ToArray(typeof(CObjetDonneeAIdNumerique)),
					false);

				m_panelListe.Refresh();
				if (! result )
				{
					CFormAlerte.Afficher ( result.Erreur );
				}

			}
		}

		private void m_panelActions_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void m_lnkActions_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_btnActions_Click ( sender, new EventArgs() );
		}

        private void m_panelListe_Load(object sender, EventArgs e)
        {

        }

        private void m_imgListe_Click(object sender, EventArgs e)
        {
            InitMenuListe();
        }

        private void m_lnkRechercheObjetsNonUtilises_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int nCombien = ListeObjets.Count;

            if (MessageBox.Show("Cette opération peut être très longue (estimation : " + (5 * nCombien).ToString()  + " secondes). Continuer ?", "Recherche des Objets non utilisés dans Timos", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (CWaitCursor cursor = new CWaitCursor())
                {
                    List<CObjetDonneeAIdNumerique> listeNonUtilises = new List<CObjetDonneeAIdNumerique>();
                    foreach (IObjetCherchable objet in ListeObjets)
                    {
                        CRequeteRechercheObjet requete = objet.GetRequeteRecherche();
                        CResultatRequeteRechercheObjet resultat = new CResultatRequeteRechercheObjet();
                        CMoteurRechercheObjetCherchable.ChercheObjet(requete, resultat);
                        if (!resultat.ObjetTrouve)
                            listeNonUtilises.Add(objet as CObjetDonneeAIdNumerique);
                    }

                    //string messageResultat = "";
                    //foreach (CObjetDonneeAIdNumerique obj in listeNonUtilises)
                    //{
                    //    messageResultat += obj.DescriptionElement + Environment.NewLine;
                    //}

                    //MessageBox.Show(messageResultat, listeNonUtilises.Count.ToString() + " Objet(s) non utilisé(s)");

                    DataSet dsResult = GetDataSetFromList(listeNonUtilises);
                    if (dsResult != null)
                        CFormVisualisationDataSet.AfficheDonnees(dsResult);

                }
            }
        }

        private DataSet GetDataSetFromList(IEnumerable<CObjetDonneeAIdNumerique> listeSource)
        {
            List<GLColumn> lstColonnes = new List<GLColumn>();
            foreach (GLColumn col in m_panelListe.Columns)
                lstColonnes.Add(col);
            C2iStructureExport structure = CConvertisseurInfoStructureDynamiqueToDefinitionChamp.ConvertToStructureExport(
                ListeObjets.TypeObjets,
                lstColonnes.ToArray());
            
            if (structure == null)
            {
                return null;
            }
            structure.TraiterSurServeur = true;
            DataSet ds = new DataSet("EXPORT OBJECTS");
            CResultAErreur result = structure.Export(
                ListeObjets.ContexteDonnee.IdSession,
                listeSource,
                ref ds,
                null);
            
            if (!result)
                return null;

            return ds;
        }
		

	}
}
