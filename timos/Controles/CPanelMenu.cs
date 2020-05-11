using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.custom;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.win32.common;
using System.Drawing.Drawing2D;
using timos.acteurs;
using timos.securite;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelMenu.
	/// </summary>
	public class CPanelMenu : System.Windows.Forms.UserControl
	{
		private const string c_cleRegistre = "WIN32_MENU_PRINCIPAL";

		private CMenuCustom m_menuCustom = null;
		private ArrayList m_listLabels = new ArrayList();
		private const int c_nHauteur1Menu = 27;
		private const int c_nHauteurSeparation = 2;
        private const int c_margeGauche = 19;
		private System.Windows.Forms.ContextMenu m_sousMenu;
        private System.Windows.Forms.PictureBox m_btnEdit;
		private System.Windows.Forms.Timer m_timerMovePict;
        private LinkLabel m_labelExemple;
        private Panel m_panelTitre;
        private ToolTip m_toolTip;
		private System.ComponentModel.IContainer components;

		public CPanelMenu()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitForm

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

		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelMenu));
            this.m_btnEdit = new System.Windows.Forms.PictureBox();
            this.m_sousMenu = new System.Windows.Forms.ContextMenu();
            this.m_timerMovePict = new System.Windows.Forms.Timer(this.components);
            this.m_labelExemple = new System.Windows.Forms.LinkLabel();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdit)).BeginInit();
            this.m_panelTitre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnEdit
            // 
            this.m_btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.m_btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEdit.Image")));
            this.m_btnEdit.Location = new System.Drawing.Point(132, 0);
            this.m_btnEdit.Name = "m_btnEdit";
            this.m_btnEdit.Size = new System.Drawing.Size(29, 30);
            this.m_btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_btnEdit.TabIndex = 5;
            this.m_btnEdit.TabStop = false;
            this.m_btnEdit.Click += new System.EventHandler(this.m_btnEdit_Click);
            // 
            // m_timerMovePict
            // 
            this.m_timerMovePict.Enabled = true;
            this.m_timerMovePict.Interval = 20;
            this.m_timerMovePict.Tick += new System.EventHandler(this.m_timerMovePict_Tick);
            // 
            // m_labelExemple
            // 
            this.m_labelExemple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelExemple.BackColor = System.Drawing.Color.Transparent;
            this.m_labelExemple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelExemple.ForeColor = System.Drawing.Color.White;
            this.m_labelExemple.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_labelExemple.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_labelExemple.LinkColor = System.Drawing.Color.White;
            this.m_labelExemple.Location = new System.Drawing.Point(16, 88);
            this.m_labelExemple.Name = "m_labelExemple";
            this.m_labelExemple.Size = new System.Drawing.Size(140, 22);
            this.m_labelExemple.TabIndex = 4;
            this.m_labelExemple.TabStop = true;
            this.m_labelExemple.Text = "linkLabel1";
            this.m_labelExemple.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_labelExemple.Visible = false;
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.BackColor = System.Drawing.Color.Transparent;
            this.m_panelTitre.Controls.Add(this.m_btnEdit);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(164, 33);
            this.m_panelTitre.TabIndex = 6;
            // 
            // CPanelMenu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.m_panelTitre);
            this.Controls.Add(this.m_labelExemple);
            this.Name = "CPanelMenu";
            this.Size = new System.Drawing.Size(164, 214);
            this.Load += new System.EventHandler(this.CPanelMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdit)).EndInit();
            this.m_panelTitre.ResumeLayout(false);
            this.m_panelTitre.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CPanelMenu_Load(object sender, System.EventArgs e)
		{
			if ( !DesignMode )
				InitPanel();
		}

		private class CMenuItemTimos : MenuItem
		{
			private CMenuCustom m_menuCustom;
			public CMenuItemTimos ( CMenuCustom menuCustom )
			{
				m_menuCustom = menuCustom;
				Text = menuCustom.Libelle;
			}

			public CMenuCustom MenuCustom
			{
				get
				{
					return m_menuCustom;
				}
			}
		}

		/// ////////////////////////////////////////////////////
		private bool ShouldAffiche ( CMenuCustom menu )
		{
            bool bAfficheGroupes = false;
            bool bAfficheProfils = false;
            bool bAffiche = true;

            CDbKey[] keysGroupes = menu.KeysGroupes;
            if (keysGroupes != null && keysGroupes.Length > 0)
            {
                bAffiche = false;
                //TESTDBKEYOK
                CDbKey[] lstGroupesSession = CTimosApp.SessionClient.GetInfoUtilisateur().ListeKeysGroupes;
                foreach (CDbKey keyVoyant in keysGroupes)
                {
                    foreach (CDbKey key in lstGroupesSession)
                        if (keyVoyant == key)
                            bAfficheGroupes = true;
                }
            }

            //TESTDBKEYOK
            CDbKey[] keysProfils = menu.KeysProfils;
            if (keysProfils != null && keysProfils.Length > 0)
            {
                bAffiche = false;
                CDonneesActeurUtilisateur user = CDonneesActeurUtilisateur.GetUserForSession(
                    CTimosApp.SessionClient.IdSession,
                    m_menuCustom.ContexteDonnee);
                foreach (CDbKey keyVoyant in keysProfils)
                {
                    CProfilUtilisateur profilVoyant = new CProfilUtilisateur(m_menuCustom.ContexteDonnee);
                    if (profilVoyant.ReadIfExists(keyVoyant))
                    {
                        if (user.IsInProfil(profilVoyant))
                            bAfficheGroupes = true;
                    }
                }
            }

            if(!bAffiche)
                return bAfficheGroupes || bAfficheProfils;

            return bAffiche;
		}


		/// ////////////////////////////////////////////////////
        private void OnClickMenu(object sender, LinkLabelLinkClickedEventArgs args)
        {
            if (DesignMode)
                return;
            if (!(sender is Control))
                return;
            CMenuCustom menu = (CMenuCustom)args.Link.LinkData;
            if (menu.ListeMenusFils.Count == 0)
            {
                CResultAErreur result = CExecuteurActionSur2iLink.ExecuteAction(sender, menu.Action, null);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                //Crée le menu
                CreateSousMenu(m_sousMenu.MenuItems, menu);
                m_sousMenu.Show((Control)sender, new Point(0, ((Control)sender).Height));
            }

        }

		/// ////////////////////////////////////////////////////
		private void CreateSousMenu ( MenuItem.MenuItemCollection wndMenus, CMenuCustom menu )
		{
			wndMenus.Clear();
			foreach ( CMenuCustom menuCustom in menu.ListeMenusFils )
			{
				if ( ShouldAffiche ( menuCustom ) )
				{
					MenuItem item = new CMenuItemTimos(menuCustom);
					if ( menuCustom.ListeMenusFils.Count != 0 )
					{
						CreateSousMenu ( item.MenuItems, menuCustom );
					}
					else
					{
						item.Click += new EventHandler(OnClickSousMenu);
					}
					wndMenus.Add ( item );
				}
			}
		}

		/// ////////////////////////////////////////////////////
        private void OnClickSousMenu(object sender, EventArgs args)
        {
            if (!(sender is CMenuItemTimos))
                return;
            CMenuCustom menu = ((CMenuItemTimos)sender).MenuCustom;
            CResultAErreur result = CExecuteurActionSur2iLink.ExecuteAction(sender, menu.Action, null);
            if (!result)
                CFormAlerte.Afficher(result.Erreur);
        }

		/// ////////////////////////////////////////////////////
		public void InitPanel ()
		{
            AssureMenu();
			if ( m_menuCustom == null )
				return;

			try
			{
				m_btnEdit.Visible = CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
					CDroitDeBase.c_droitBasePersonnalisation) != null;
			}
			catch
			{
				m_btnEdit.Visible = false;
			}
			foreach ( LinkLabel label in m_listLabels )
			{
				label.Hide();
				label.Dispose();
			}
			m_listLabels.Clear();
			if ( m_menuCustom == null || m_menuCustom.ListeMenusFils.Count == 0 )
			{
				Visible = false;
				return;
			}
			else
				Visible = true;
			int nHeight = 0;
			int nStartY = 0;
            //if (m_menuCustom.Libelle != "")
            //{
                m_panelTitre.Visible = true;
                //m_lblTitre.Text = m_menuCustom.Libelle;
                nHeight += m_panelTitre.Height + c_nHauteurSeparation;
                nStartY += m_panelTitre.Height + c_nHauteurSeparation;
            //}
			int nNbMenus = 0;
			foreach ( CMenuCustom menu in m_menuCustom.ListeMenusFils )
			{
				if ( ShouldAffiche ( menu ) )
				{
					nNbMenus++;
					LinkLabel label = new LinkLabel();
					label.Font = m_labelExemple.Font;
					label.BackColor = m_labelExemple.BackColor;
					label.Image = m_labelExemple.Image;
					label.ImageAlign = m_labelExemple.ImageAlign;
					label.TextAlign = m_labelExemple.TextAlign;
					label.ForeColor = m_labelExemple.ForeColor;
					label.LinkColor = m_labelExemple.LinkColor;
                    label.LinkBehavior = m_labelExemple.LinkBehavior;
					label.Links.Add ( 0, menu.Libelle.Length, menu );
					label.Text = menu.Libelle;
					label.LinkClicked += new LinkLabelLinkClickedEventHandler (OnClickMenu);
					label.Parent = this;
					label.Left = c_margeGauche;
					label.Top = nStartY;
					label.Width = Width-c_margeGauche-5;
					label.Height = m_labelExemple.Height;
                    label.Anchor = m_labelExemple.Anchor;
					nStartY += c_nHauteur1Menu+c_nHauteurSeparation;
					this.Controls.Add ( label );
					m_listLabels.Add ( label );

                    label.Paint += new PaintEventHandler(label_Paint);

				}
			}
			nHeight += nNbMenus*(c_nHauteur1Menu+c_nHauteurSeparation)-c_nHauteurSeparation;
			Height = nHeight;
			
		}

        void label_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinkLabel label = sender as LinkLabel;
            if (label != null)
            {
                SizeF nLargeur = g.MeasureString(label.Text, label.Font);
                if (nLargeur.Width >= label.Width - 4*(label.Margin.Left + label.Margin.Right))
                    m_toolTip.SetToolTip(label, label.Text);
                else
                    m_toolTip.SetToolTip(label, "");
            }

        }


		private void AssureMenu ( )
		{
            if (DesignMode)
                return;
			if ( m_menuCustom == null && !DesignMode)
			{
				IDatabaseRegistre registre = (IDatabaseRegistre)C2iFactory.GetNew2iObjetServeur(typeof(IDatabaseRegistre), CTimosApp.SessionClient.IdSession);
				int nId =  (int)registre.GetValeurLong(c_cleRegistre,-1);
				m_menuCustom = new CMenuCustom ( CSc2iWin32DataClient.ContexteCourant );
				if ( !m_menuCustom.ReadIfExists ( nId ) )
				{
                    // Si l'ID n'éxiste pas alors on cherche par une requette pour être sûr
                    CListeObjetsDonnees listeMenus = new CListeObjetsDonnees(
                        CSc2iWin32DataClient.ContexteCourant,
                        typeof(CMenuCustom),
                        new CFiltreData(CMenuCustom.c_champIdMenuParent + " IS NULL"));

                    if (listeMenus.Count >= 1)
                        // On a trouvé le premier menu sans parent
                        m_menuCustom = (CMenuCustom) listeMenus[0];
                    else
                    {
                        //Construction du menu par défaut
                        m_menuCustom.CreateNew();
                        m_menuCustom.Libelle = I.T("Home|714");
                        m_menuCustom.Action = null;
                        AddMenuStandard(m_menuCustom, I.T("Assets management|1"), typeof(CFormMenuPatrimoine));
                        AddMenuStandard(m_menuCustom, I.T("Organisation|4"), typeof(CFormMenuOrganisation));
                        AddMenuStandard(m_menuCustom, I.T("Maintenance|8"), typeof(CFormMenuMaintenance));
                        AddMenuStandard(m_menuCustom, I.T("Engineering|6"), typeof(CFormMenuIngenierie));
                        AddMenuStandard(m_menuCustom, I.T("Configuration|7"), typeof(CFormMenuConfiguration));
                        m_menuCustom.CommitEdit();
                        registre.SetValeur(c_cleRegistre, m_menuCustom.Id.ToString());
                    }
				}
			}
		}

		private CMenuCustom AddMenuStandard ( CMenuCustom parent, string strLibelle, Type typeForm )
		{
			CMenuCustom menu = new CMenuCustom ( parent.ContexteDonnee );
			menu.Libelle = strLibelle;
			menu.MenuParent = parent;
			menu.NumMenu = parent.ListeMenusFils.Count;
			if ( typeForm != null )
			{
				CActionSur2iLinkAfficherFormulaire action = new CActionSur2iLinkAfficherFormulaire ();
				action.TypeFormulaire = typeForm;
				menu.Action = action;
			}
			return menu;
		}

		/// //////////////////////////////////////
		private void m_btnEdit_Click(object sender, System.EventArgs e)
		{
			if ( m_menuCustom == null )
			{
				m_menuCustom = new CMenuCustom ( CSc2iWin32DataClient.ContexteCourant );
				m_menuCustom.CreateNew();
				m_menuCustom.Libelle = I.T( "Main menu|716");
			}
			CFormEditionMenuCustom form = new CFormEditionMenuCustom ( m_menuCustom );
			form.AfterValideModification += new ObjetDonneeEventHandler(AfterModifieMenu);
			CTimosApp.Navigateur.AffichePage ( form );
		}


		/// //////////////////////////////////////
		private void AfterModifieMenu(object sender, CObjetDonneeEventArgs args)
		{
			InitPanel ( );
		}

		private void m_timerMovePict_Tick(object sender, System.EventArgs e)
		{
            //Point pt = PointToClient(Cursor.Position);
            //if ( ClientRectangle.Contains ( pt ) )
            //{
            //    pt.Y -= m_panelTitre.Height+c_nHauteurSeparation;
            //    m_nDestPictToMove = (int)(pt.Y/(c_nHauteur1Menu+c_nHauteurSeparation));
            //}
            //else
            //{
            //    m_nDestPictToMove = -1;
            //}
            //int nYAttendue = m_nDestPictToMove * (c_nHauteur1Menu+c_nHauteurSeparation)+m_panelTitre.Height+c_nHauteurSeparation;
            //if ( m_pictToMove.Location.Y != nYAttendue )
            //{
            //    int nInc = Math.Abs((m_pictToMove.Location.Y - nYAttendue)/4);
            //    if ( m_pictToMove.Location.Y < nYAttendue )
            //        nInc = Math.Max ( 1, nInc );
            //    else
            //        nInc = Math.Min (-1, -nInc );
            //    m_pictToMove.Location = new Point ( m_pictToMove.Location.X, m_pictToMove.Location.Y + nInc);
            //    m_pictToMove.Refresh();
            //}
        }
	
	}
}
