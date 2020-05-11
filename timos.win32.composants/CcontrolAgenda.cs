using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;

using sc2i.workflow;
using timos.acteurs;
using timos.securite;
using sc2i.win32.common;


namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CcontrolAgenda.
	/// </summary>
	public class CcontrolAgenda : System.Windows.Forms.UserControl, IControlAgenda
	{
		public enum ModeAffichage
		{
			Jour = 0,
			Semaine = 1,
			Mois = 2,
			Annee = 3
		}

		private CImagesForRolesAgenda m_imagesRoles = new CImagesForRolesAgenda();
		private CFiltreData m_filtreEntrees = null;

		private DateTime m_dateStart = DateTime.Now;
		private CObjetDonneeAIdNumerique[] m_elementsAAgenda = null;
		private IControlAgenda m_controlAffichage = null;
		private ModeAffichage m_modeAffichage = ModeAffichage.Mois;
		private System.Windows.Forms.Panel m_panelVisuAgenda;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_btnModeMois;
		private System.Windows.Forms.ContextMenu m_menuAjouterAgenda;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
		private System.Windows.Forms.ContextMenu m_menuFiltrer;
		private sc2i.win32.common.CWndLinkStd m_lnkFiltrer;
		private System.Windows.Forms.Button m_btnSemaine;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event DemandeAffichageEntreeAgendaEventHandler OnAfficherEntreeAgenda = null;

		public CcontrolAgenda()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

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

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CcontrolAgenda));
            this.m_panelVisuAgenda = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnModeMois = new System.Windows.Forms.Button();
            this.m_menuAjouterAgenda = new System.Windows.Forms.ContextMenu();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkFiltrer = new sc2i.win32.common.CWndLinkStd();
            this.m_menuFiltrer = new System.Windows.Forms.ContextMenu();
            this.m_btnSemaine = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_panelVisuAgenda
            // 
            this.m_panelVisuAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelVisuAgenda.Location = new System.Drawing.Point(0, 24);
            this.m_panelVisuAgenda.Name = "m_panelVisuAgenda";
            this.m_panelVisuAgenda.Size = new System.Drawing.Size(560, 296);
            this.m_panelVisuAgenda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(509, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month|30017";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnModeMois
            // 
            this.m_btnModeMois.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeMois.Image")));
            this.m_btnModeMois.Location = new System.Drawing.Point(488, 0);
            this.m_btnModeMois.Name = "m_btnModeMois";
            this.m_btnModeMois.Size = new System.Drawing.Size(24, 24);
            this.m_btnModeMois.TabIndex = 2;
            this.m_btnModeMois.Click += new System.EventHandler(this.m_btnModeMois_Click);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(0, 8);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(80, 16);
            this.m_lnkAjouter.TabIndex = 0;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_lnkFiltrer
            // 
            this.m_lnkFiltrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkFiltrer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkFiltrer.Location = new System.Drawing.Point(80, 8);
            this.m_lnkFiltrer.Name = "m_lnkFiltrer";
            this.m_lnkFiltrer.Size = new System.Drawing.Size(80, 16);
            this.m_lnkFiltrer.TabIndex = 3;
            this.m_lnkFiltrer.TypeLien = sc2i.win32.common.TypeLinkStd.Filtre;
            this.m_lnkFiltrer.LinkClicked += new System.EventHandler(this.m_lnkFiltrer_LinkClicked);
            // 
            // m_btnSemaine
            // 
            this.m_btnSemaine.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSemaine.Image")));
            this.m_btnSemaine.Location = new System.Drawing.Point(408, 0);
            this.m_btnSemaine.Name = "m_btnSemaine";
            this.m_btnSemaine.Size = new System.Drawing.Size(24, 24);
            this.m_btnSemaine.TabIndex = 5;
            this.m_btnSemaine.Click += new System.EventHandler(this.m_btnSemaine_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(432, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Week|121";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CcontrolAgenda
            // 
            this.Controls.Add(this.m_btnSemaine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_lnkFiltrer);
            this.Controls.Add(this.m_btnModeMois);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_panelVisuAgenda);
            this.Controls.Add(this.m_lnkAjouter);
            this.Name = "CcontrolAgenda";
            this.Size = new System.Drawing.Size(560, 320);
            this.Load += new System.EventHandler(this.CcontrolAgenda_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void CcontrolAgenda_Load(object sender, System.EventArgs e)
		{
			CreateControleAgenda();
		}

		/// <summary>
		/// /////////////////////////////
		/// </summary>
		private void CreateControleAgenda()
		{
			if ( m_controlAffichage != null )
			{
				m_dateStart = m_controlAffichage.DateEnCours;
				((Control)m_controlAffichage).Dispose();
				m_controlAffichage = null;
			}
			switch ( m_modeAffichage )
			{
				case ModeAffichage.Mois :
					m_controlAffichage = new CControlAgendaModeMois();
					((Control)m_controlAffichage).Size = m_panelVisuAgenda.ClientSize;
					((Control)m_controlAffichage).Dock = DockStyle.Fill;
					((CControlAgendaModeMois)m_controlAffichage).ImagesRoles = m_imagesRoles;
					((Control)m_controlAffichage).Parent = m_panelVisuAgenda;
					((Control)m_controlAffichage).CreateControl();
					
					break;
				case ModeAffichage.Semaine :
					m_controlAffichage = new CControlAgendaModeSemaine();
					((Control)m_controlAffichage).Size = m_panelVisuAgenda.ClientSize;
					((Control)m_controlAffichage).Dock = DockStyle.Fill;
					((CControlAgendaModeSemaine)m_controlAffichage).ImagesRoles = m_imagesRoles;
					((Control)m_controlAffichage).Parent = m_panelVisuAgenda;
					((Control)m_controlAffichage).CreateControl();
					break;
			}
			if ( m_controlAffichage != null )
			{
				m_controlAffichage.OnAfficherEntreeAgenda += new DemandeAffichageEntreeAgendaEventHandler(OnDemandeAffichageEntree);
				m_controlAffichage.OnDemandeCreationEntreeAgenda += new EventHandler(m_controlAffichage_OnDemandeCreationEntreeAgenda);
				m_controlAffichage.DateEnCours = m_dateStart ;
				m_controlAffichage.SetElementsAAgenda ( m_elementsAAgenda );
			}
			/*((Control)m_controlAffichage).Width = m_panelVisuAgenda.ClientSize.Width;
			((Control)m_controlAffichage).Height = m_panelVisuAgenda.ClientSize.Height;
			((Control)m_controlAffichage).Dock = DockStyle.Fill;*/
		}

		/// /////////////////////////////
		private void OnDemandeAffichageEntree ( IEntreeAgenda entree )
		{
			if ( OnAfficherEntreeAgenda != null )
				OnAfficherEntreeAgenda ( entree );
		}

		/// /////////////////////////////
		public void SetElementAAgenda ( CObjetDonneeAIdNumerique element )
		{
			SetElementsAAgenda ( new CObjetDonneeAIdNumerique[]{element} );
		}

		/// /////////////////////////////
		public void SetElementsAAgenda ( CObjetDonneeAIdNumerique[] elements )
		{
			m_elementsAAgenda = elements;
			if ( m_controlAffichage != null )
				((IControlAgenda)m_controlAffichage).SetElementsAAgenda(m_elementsAAgenda);
			
			if(  m_elementsAAgenda.Length > 1 )
			{
				m_lnkAjouter.Visible = false;
				return;
			}

			//Si l'élément est un acteur, possible de créer une entrée si
			//c'est soi-même ou si c'est un acteur dont on gère l'agenda
			if ( elements.Length == 1 && elements[0] is CActeur )
			{
				CActeur part = (CActeur)elements[0];
				m_lnkAjouter.Visible = false;
				CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession ( elements[0].ContexteDonnee );
				if ( user.Acteur.Equals ( part ) )
					m_lnkAjouter.Visible = true;
				else
				{
					/*foreach ( CRelationUtilisateur_AgendasGeres rel in user.RelationsUtilisateursAgendaGeres )
						if ( rel.UtilisateurGere.Acteur.Equals ( part ) )
							m_lnkAjouter.Visible = true;*/
				}
			}
		}

		/// /////////////////////////////
		private void m_btnModeMois_Click(object sender, System.EventArgs e)
		{
			if ( m_modeAffichage != ModeAffichage.Mois )
			{
				m_modeAffichage = ModeAffichage.Mois;
				CreateControleAgenda();
			}
		}

		/// /////////////////////////////
		public void OnChangeDonnees ( )
		{
			SetElementsAAgenda ( m_elementsAAgenda );
		}

		private class CMenuItemATypeEntreeAgenda : MenuItem
		{
			public readonly CTypeEntreeAgenda TypeEntree;

			public CMenuItemATypeEntreeAgenda ( CTypeEntreeAgenda type )
			{
				TypeEntree = type;
			}
		}


		

		//-------------------------------------------------------------------------
		private void OnMenuAjouterAgenda ( object sender, EventArgs args )
		{
			if ( OnAfficherEntreeAgenda == null )
				return;
			if ( m_elementsAAgenda.Length!=1 )
				return;
			if ( sender is CMenuItemATypeEntreeAgenda )
			{
				CMenuItemATypeEntreeAgenda menu = (CMenuItemATypeEntreeAgenda)sender;
				CTypeEntreeAgenda typeEntree = menu.TypeEntree;
				CEntreeAgenda entree = new CEntreeAgenda ( m_elementsAAgenda[0].ContexteDonnee );
				entree.CreateNew();
				entree.DateDebut = DateEnCours.Date.AddHours(8);
				entree.DateFin = DateEnCours.Date.AddHours(18);
				
				typeEntree.InitEntreeManuelleFor(entree, m_elementsAAgenda[0]);
				OnAfficherEntreeAgenda ( entree );
			}
		}
		
		//-------------------------------------------------------------------------
		private void m_lnkAjouter_LinkClicked(object sender, System.EventArgs e)
		{
			if ( OnAfficherEntreeAgenda == null || m_elementsAAgenda.Length != 1)
				CFormAlerte.Afficher(I.T("Not availiable|30079"), EFormAlerteType.Exclamation);
			Point pt = PointToScreen ( new Point ( m_lnkAjouter.Left, m_lnkAjouter.Bottom ) );
				ShowMenuAjout ( pt );
		}

		//-------------------------------------------------------------------------
		public void ShowMenuAjout ( Point pt )
		{
			if ( !m_lnkAjouter.Visible )
				return;
			CObjetDonneeAIdNumerique element = m_elementsAAgenda[0];
			//cherche les entrées qui collent avec des acteurs
			CListeObjetsDonnees liste = new CListeObjetsDonnees(element.ContexteDonnee, typeof(CTypeEntreeAgenda));
			CFiltreDataAvance filtre = new CFiltreDataAvance(CTypeEntreeAgenda.c_nomTable,
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable+"."+
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champTypeElement+"=@1 and "+
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable+"."+
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champLienMaitre+"=@2",
				element.GetType().ToString(),
				true);
			liste.Filtre = filtre;
			if ( liste.Count == 0 )
			{
				CFormAlerte.Afficher(I.T("No Agenda entry type can be applied on this element type|30080"), EFormAlerteType.Exclamation);
				return;
			}
			m_menuAjouterAgenda.MenuItems.Clear();
			foreach ( CTypeEntreeAgenda typeEntree in liste )
			{
				CMenuItemATypeEntreeAgenda item = new CMenuItemATypeEntreeAgenda(typeEntree);
				item.Text = typeEntree.Libelle;
				item.Click += new EventHandler(OnMenuAjouterAgenda);
				m_menuAjouterAgenda.MenuItems.Add ( item );
			}
			pt = PointToClient ( pt );
			m_menuAjouterAgenda.Show(this, pt);
		}

		//-------------------------------------------------------------------------
		private class CMenuItemAFiltreDynamique : MenuItem
		{
			public readonly CFiltreDynamiqueInDb Filtre;

			public CMenuItemAFiltreDynamique ( CFiltreDynamiqueInDb filtre )
			{
				Filtre = filtre;
			}
		}

		//-------------------------------------------------------------------------
		private void m_lnkFiltrer_LinkClicked(object sender, System.EventArgs e)
		{
			if ( m_elementsAAgenda.Length == 0 )
				return;
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( m_elementsAAgenda[0].ContexteDonnee,
				typeof(CFiltreDynamiqueInDb) );
			liste.Filtre = new CFiltreData ( 
				CFiltreDynamiqueInDb.c_champTypeElements+"=@1",
				typeof(CRelationEntreeAgenda_ElementAAgenda).ToString() );
			if ( liste.Count == 0 )
			{
				CFormAlerte.Afficher(I.T("No filter exists on|30081")+
					DynamicClassAttribute.GetNomConvivial ( typeof(CRelationEntreeAgenda_ElementAAgenda)) , EFormAlerteType.Exclamation);
				return;
			}
			if ( m_menuFiltrer.MenuItems.Count ==0 )
			{
				CMenuItemAFiltreDynamique menu = new CMenuItemAFiltreDynamique(null);
				menu.Text = "None|30082";
				menu.Click += new EventHandler(OnMenuFiltrer);
				m_menuFiltrer.MenuItems.Add ( menu );
				foreach ( CFiltreDynamiqueInDb filtre in liste )
				{
					menu = new CMenuItemAFiltreDynamique(filtre);
					menu.Text = filtre.Libelle;
					menu.Click += new EventHandler(OnMenuFiltrer);
					m_menuFiltrer.MenuItems.Add ( menu );
				}
			}
			m_menuFiltrer.Show ( m_lnkFiltrer, new Point ( 0, m_lnkFiltrer.Height ) );
		}

		//-------------------------------------------------------------------------
		private void OnMenuFiltrer(object sender, System.EventArgs e)
		{
			try
			{
				if (sender is CMenuItemAFiltreDynamique )
				{
					CFiltreDynamiqueInDb filtre = ((CMenuItemAFiltreDynamique)sender).Filtre;
					if ( filtre == null )
					{
						m_filtreEntrees = null;
						CheckMenuFiltre ( (CMenuItemAFiltreDynamique)sender );
						((IControlAgenda)m_controlAffichage).FiltreAAppliquer = null;
						return;
					}
						
					CFiltreData filtreData = null;
					filtreData = sc2i.win32.data.dynamic.CFormFiltreDynamic.GetFiltreData ( filtre.Filtre);
					if ( filtreData != null )
					{
						m_filtreEntrees = filtreData;
						((IControlAgenda)m_controlAffichage).FiltreAAppliquer = filtreData;
						CheckMenuFiltre ( (CMenuItemAFiltreDynamique)sender );
					}
				}
			}
			catch
			{
				CFormAlerte.Afficher(I.T("Error while applying filter|30083"), EFormAlerteType.Erreur);
			}
		}

		private void CheckMenuFiltre ( CMenuItemAFiltreDynamique menu )
		{
			foreach ( MenuItem item in m_menuFiltrer.MenuItems )
				item.Checked = false;
			menu.Checked = true;
		}

		private void m_btnSemaine_Click(object sender, System.EventArgs e)
		{
			if ( m_modeAffichage != ModeAffichage.Semaine )
			{
				m_modeAffichage = ModeAffichage.Semaine;
				CreateControleAgenda();
			}
		}

		/// <summary>
		/// Ne fait rien
		/// </summary>
		public CFiltreData FiltreAAppliquer
		{
			set
			{
			}
		}

		/////////////////////////////////////////////////////
		public DateTime DateEnCours
		{
			get
			{
				if ( m_controlAffichage != null )
					return m_controlAffichage.DateEnCours;
				return DateTime.Now;
			}
			set
			{
				if ( m_controlAffichage != null )
					m_controlAffichage.DateEnCours = value;
			}
		}

		public event EventHandler OnDemandeCreationEntreeAgenda;

		private void m_controlAffichage_OnDemandeCreationEntreeAgenda(object sender, EventArgs e)
		{
			if ( OnDemandeCreationEntreeAgenda != null )
				OnDemandeCreationEntreeAgenda ( this, new EventArgs() );
			Point pt = new Point ( MousePosition.X, MousePosition.Y );
			ShowMenuAjout ( pt );
		}
	}
}
