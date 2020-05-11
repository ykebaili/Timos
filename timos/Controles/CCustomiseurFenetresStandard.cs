using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.multitiers.client;
using sc2i.custom;
using sc2i.workflow;
using sc2i.common;
using sc2i.win32.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.data.dynamic;
using sc2i.win32.navigation;
using sc2i.formulaire;
using sc2i.formulaire.win32;
using timos.Controles;
using timos.acteurs;
using timos.Securite.DroitsEdition;
using timos.securite;


namespace timos
{
	/// <summary>
	/// Description résumée de CCustomiseurFenetresStandard.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CCustomiseurFenetresStandard
	{
		private const string c_idHaut = "_#HAUT";
		private const string c_idBas = "_#BAS";
		private const string c_idGauche = "_#GAUCHE";
		private const string c_idDroite = "_#DROITE";
		private static Hashtable m_tableFormToCreateur = new Hashtable();
		
		//-------------------------------------------------------------------------------
		public static void Autoexec()
		{
            // Personalisation de l'interface
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0,
                CDroitDeBase.c_droitBasePersonnalisation,
                I.T("User interface customisation|10041"),
                0,
                CDroitDeBaseSC2I.c_droitInterface,
                I.T("Allow user to add costom Menus, and create custom forms|10042"),
                OptionsDroit.Aucune);


		}

		//-------------------------------------------------------------------------------
		private static string GetIdentifiantForm ( Form frm, string strOnglet )
		{
			string strContexteUtilisation = "";
			if ( frm is IElementAContexteUtilisation )
				strContexteUtilisation = ((IElementAContexteUtilisation)frm).ContexteUtilisation;
			return frm.GetType()+strContexteUtilisation+strOnglet;
            
		}

		private delegate void BrancheSurFenetreDelegate ( Form frm );

		private class CLockerBrancheSurFenetre{};
		

		//-------------------------------------------------------------------------------
		public static void BrancheSurFenetre ( Form frm )
		{
			try
			{
				//AsyncBrancheSurFenetre(frm);
				frm.BeginInvoke(new BrancheSurFenetreDelegate(AsyncBrancheSurFenetre), frm);
			}
			catch ( Exception )
			{
			}
		}

		
		private static void AsyncBrancheSurFenetre ( Form frm )
		{
			if ( ! (frm is IFormNavigable) )
				return;
			if ( !(((IFormNavigable)frm).Navigateur is CFormMain ) )
				return;

			try
			{
				CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CFormulaire));
				listeFormulaires.Filtre = new CFiltreData(CFormulaire.c_champLibelle + " like @1",
					GetIdentifiantForm(frm, "") + "%");

				foreach (CFormulaire formulaire in listeFormulaires)
				{
					C2iWnd wnd = formulaire.Formulaire;
					string strIdForm = GetIdentifiantForm(frm, "");
					string strOnglet = "";
					if (formulaire.Libelle != strIdForm)
						strOnglet = formulaire.Libelle.Substring(strIdForm.Length);

					Control parent = frm;
					if (strOnglet != "")
					{
						parent = GetTabPage(frm, strOnglet);
						if (parent == null && frm is CFormListeStandardTimos)
						{
							CFormListeStandardTimos frmCaf = (CFormListeStandardTimos)frm;
							if (strOnglet == c_idHaut)
							{
								frmCaf.PanelHaut.Visible = true;
								frmCaf.PanelHaut.Height = wnd.Size.Height;
								parent = frmCaf.PanelHaut;
							}
							else if (strOnglet == c_idBas)
							{
								frmCaf.PanelBas.Visible = true;
								frmCaf.PanelBas.Height = wnd.Size.Height;
								parent = frmCaf.PanelBas;
							}
							else if (strOnglet == c_idGauche)
							{
								frmCaf.PanelGauche.Visible = true;
								frmCaf.PanelGauche.Width = wnd.Size.Width;
								parent = frmCaf.PanelGauche;
							}
							else if (strOnglet == c_idDroite)
							{
								frmCaf.PanelDroit.Visible = true;
								frmCaf.PanelDroit.Width = wnd.Size.Width;
								parent = frmCaf.PanelDroit;
							}
							if (parent != null)
								parent.BackColor = wnd.BackColor;
						}
					}


					object elementEdite = null;
                    CFormEditionStdTimos frmTimos = frm as CFormEditionStdTimos;
					if (frmTimos != null)
					{
						elementEdite = frmTimos.GetObjetEdite();
						frm.Disposed += new EventHandler(frm_Disposed);
						frmTimos.ObjetEditeChanged += new EventHandler(CCustomiseurFenetresStandard_ObjetEditeChanged);
                        frmTimos.BeforeValideModification += new ObjetDonneeCancelEventHandler(frmTimos_BeforeValideModification);
                        frmTimos.OnChangeModeEdition += new EventHandler(frmTimos_OnChangeModeEdition);
                        frmTimos.OnInitChamps += new ResultEventHandler(frmTimos_OnInitChamps);
					}
					if (parent != null)
					{
						CCreateur2iFormulaireV2 createur = null;
						if (elementEdite is CObjetDonnee)
							createur = new CCreateur2iFormulaireObjetDonnee(((CObjetDonnee)elementEdite).ContexteDonnee.IdSession);
						else
							createur = new CCreateur2iFormulaireV2();

						ArrayList lstCreateurs = (ArrayList)m_tableFormToCreateur[frm];
						if (lstCreateurs == null)
						{
							lstCreateurs = new ArrayList();
							m_tableFormToCreateur[frm] = lstCreateurs;
						}
						lstCreateurs.Add(createur);
						createur.CreateControlesEnSurimpression(parent, wnd, new CFournisseurPropDynStd(true));
						createur.ElementEdite = elementEdite;
                        if (frmTimos != null)
                            createur.LockEdition = !frmTimos.ModeEdition;

					}
				}
				if (CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
					CDroitDeBase.c_droitBasePersonnalisation) != null)
				{
                    CBoutonCustomiseFenetre imageBox = new CBoutonCustomiseFenetre();
                    imageBox.Name = c_strCleImageBox;
                    imageBox.PoseDansControle(frm);
                    imageBox.BringToFront();
                    imageBox.Click += new EventHandler(imageBox_Click);
                    imageBox.Visible = true;
				}
			}
			catch
			{
			}
		}

        static void frmTimos_OnInitChamps(object sender, ref CResultAErreur result)
        {
            RefreshWindow(sender as Form);
        }

       

        
        private const string c_strCleImageBox = "IMAGE_EDIT_FORM_CUSTOM";
        static void frm_MouseMove(object sender, MouseEventArgs e)
        {
            Form frm = null;
            if(sender is Control)
                frm = ((Control)sender).FindForm();
            else
                frm = sender as Form;

            

            Image image = timos.Properties.Resources.Picto_note1;
            if(frm != null)
            {    
                try
                {
                    Control imgBox = frm.Controls[c_strCleImageBox];
                    if(imgBox is PictureBox)
                    {
                        if (e.X > frm.Width - image.Width && e.Y < image.Height)
                            imgBox.Visible = true;
                        else
                            imgBox.Visible = false;
                    }

                }
                catch
                {}
            }
                    
        }

        
        //-------------------------------------------------------------------------------
        private static void CreateContextMenu(Form frm)
        {
            if (frm == null)
                return;

            ContextMenuStrip menu = new ContextMenuStrip();
            frm.ContextMenuStrip = menu;

            if (menu != null)
            {
                ToolStripMenuItem itemUnique = new CMenuItemPourFormulaire(I.T("Customize form|30067"), frm, "");
                itemUnique.Image =  timos.Properties.Resources.Picto_timos_note1;
                menu.Items.Add(itemUnique);
				itemUnique.DropDownOpening += new EventHandler(contextmenu_Opening);

                //Y a t-il des tabs controls
                Crownwood.Magic.Controls.TabControl[] tabs = GetTabsControls(frm);
                if (tabs.Length > 0)
                {
                    ToolStripMenuItem item = new CMenuItemPourFormulaire(I.T("Form for the whole page|30068"), frm, "");
                    item.Click += new EventHandler(item_Click);
                    itemUnique.DropDownItems.Add(item);
                    foreach (Crownwood.Magic.Controls.TabControl tab in tabs)
                    {
						foreach ( Crownwood.Magic.Controls.TabPage page in tab.TabPages )
						{
							item = new CMenuItemPourFormulaire(I.T("Form for the page |30069 ") + page.Title, frm, page.Title);
                            item.Click += new EventHandler(item_Click);
                            itemUnique.DropDownItems.Add(item);
                        }
                    }
                    return;
                }
                else
                {
                    if (frm is CFormListeStandardTimos)
                    {
                        ToolStripMenuItem item = new CMenuItemPourFormulaire(I.T("Overprint form|30070"), frm, "");
                        item.Click += new EventHandler(item_Click);
                        itemUnique.DropDownItems.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on top|30071"), frm, c_idHaut);
                        item.Click += new EventHandler(item_Click);
                        itemUnique.DropDownItems.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on bottom|30072"), frm, c_idBas);
                        item.Click += new EventHandler(item_Click);
                        itemUnique.DropDownItems.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Formu on the left|30073"), frm, c_idGauche);
                        item.Click += new EventHandler(item_Click);
                        itemUnique.DropDownItems.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on the right|30074"), frm, c_idDroite);
                        item.Click += new EventHandler(item_Click);
                        itemUnique.DropDownItems.Add(item);

                        return;
                    }
                }

                itemUnique.Click += new EventHandler(item_Click);

            }
        }

		//-------------------------------------------------------------------------------
		static void contextmenu_Opening(object sender, EventArgs e)
		{
			CMenuItemPourFormulaire menu = sender as CMenuItemPourFormulaire;
			if (menu != null)
			{
				Form frm = menu.Formulaire;
				Dictionary<string, bool> tabsSelected = new Dictionary<string, bool>();
				foreach (Crownwood.Magic.Controls.TabControl ctrl in GetTabsControls ( frm ))
				{
					if (ctrl.SelectedTab != null)
						tabsSelected[ctrl.SelectedTab.Title] = true;
				}
				if (frm != null)
				{
					foreach (ToolStripMenuItem subItem in menu.DropDownItems)
					{
						CMenuItemPourFormulaire menuFormulaire = subItem as CMenuItemPourFormulaire;
						if (menuFormulaire != null &&
							menuFormulaire.Onglet != "" &&
							menuFormulaire.Onglet != c_idBas &&
							menuFormulaire.Onglet != c_idDroite &&
							menuFormulaire.Onglet != c_idGauche &&
							menuFormulaire.Onglet != c_idDroite )
							menuFormulaire.Visible = tabsSelected.ContainsKey(menuFormulaire.Onglet);
					}
				}
			}
		}


		//-------------------------------------------------------------------------------
		private static Crownwood.Magic.Controls.TabControl[] GetTabsControls ( Form frm )
		{
			ArrayList lst = new ArrayList();
			AddTabControls(frm, lst);
			return (Crownwood.Magic.Controls.TabControl[])lst.ToArray(typeof(Crownwood.Magic.Controls.TabControl));
		}

		//-------------------------------
		private static void AddTabControls ( Control ctrlParent, ArrayList liste )
		{
			foreach (Control ctrl in ctrlParent.Controls)
			{
				if (ctrl is Crownwood.Magic.Controls.TabControl)
					liste.Add(ctrl);
				AddTabControls(ctrl, liste);
			}
			
		}

		//-------------------------------------------------------------------------------
		private static Control GetTabPage ( Form frm, string strOnglet )
		{

			foreach ( Crownwood.Magic.Controls.TabControl tab in GetTabsControls(frm) )
				foreach ( Crownwood.Magic.Controls.TabPage page in tab.TabPages )
					if ( page.Title.ToUpper() == strOnglet.ToUpper() )
					{
						return page;
					}
			return null;
		}

		//-------------------------------------------------------------------------------
        private class CMenuItemPourFormulaire : ToolStripMenuItem
		{
			public readonly Form Formulaire;
			public readonly string Onglet;
			
			public CMenuItemPourFormulaire ( string strText, Form formulaire, string strOnglet  )
				:base ( strText )
			{
				Formulaire = formulaire;
				Onglet = strOnglet;
                
			}
		}


		//-------------------------------------------------------------------------------
        private static void imageBox_Click(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Form frm = ((Control)sender).FindForm();
                if (frm == null)
                    return;
                //Y a t-il des tabs controls
                Crownwood.Magic.Controls.TabControl[] tabs = GetTabsControls(frm);
                if (tabs.Length > 0)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripMenuItem item = new CMenuItemPourFormulaire(I.T("Full page form|20191"), frm, "");
                    item.Click += new EventHandler(item_Click);
                    menu.Items.Add(item);
                    foreach (Crownwood.Magic.Controls.TabControl tab in tabs)
                    {
                        if (tab.SelectedTab != null)
                        {
                            item = new CMenuItemPourFormulaire(I.T("Form for page @1|20192",tab.SelectedTab.Title), frm, tab.SelectedTab.Title);
                            item.Click += new EventHandler(item_Click);
                            menu.Items.Add(item);
                        }
                    }

                    IFormEditObjetDonnee frmEdition = frm as IFormEditObjetDonnee;
                    if ( frmEdition != null && frmEdition.GetObjetEdite() != null )
                    {
                    menu.Items.Add(new ToolStripSeparator());
                    ToolStripMenuItem itemDroits = new ToolStripMenuItem(I.T("Editions rights|20748"));
                    itemDroits.Click += new EventHandler(itemDroits_Click);
                        itemDroits.Tag = frmEdition.GetObjetEdite().GetType();
                    menu.Items.Add ( itemDroits );
                    }

                    if (menu.Items.Count > 1)
                    {
                        Control btn = (Control)sender;
                        menu.Show(btn, new Point(0, btn.Height));
                        return;
                    }
                }
                else
                {
                    if (frm is CFormListeStandardTimos)
                    {
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem item = new CMenuItemPourFormulaire(I.T("Overprint form|30070"), frm, "");
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on top|30071"), frm, c_idHaut);
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on bottom|30072"), frm, c_idBas);
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Formu on the left|30073"), frm, c_idGauche);
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);

                        item = new CMenuItemPourFormulaire(I.T("Form on the right|30074"), frm, c_idDroite);
                        item.Click += new EventHandler(item_Click);
                        menu.Items.Add(item);

                        Control btn = (Control)sender;
                        menu.Show(btn, new Point(0, btn.Height));
                        return;
                    }
                }
                EditeFormulaire(frm, "");
            }
        }

        //---------------------------------------------------------------------------------------
        static void itemDroits_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Type tp = item != null ? item.Tag as Type : null;
            if (tp != null)
            {
                CFormEditDroitsSurType.EditeDroits(tp);
            }
        }

        //-------------------------------------------------------------------------------
		private static void EditeFormulaire ( Form frm, string strOnglet )
		{
			Control ctrl = frm;
			//Chope l'image du formulaire
			if ( strOnglet != "" )
			{
				ctrl = GetTabPage ( frm, strOnglet );
			}
			bool bAvecImage = true;
			if(  strOnglet != "" && ctrl == null )
			{
				if ( strOnglet == c_idBas || strOnglet == c_idHaut || strOnglet == c_idGauche ||
					strOnglet == c_idGauche )
				{
					ctrl = frm;
					bAvecImage = false;
				}
			}
			if ( ctrl == null )
			{
				CFormAlerte.Afficher(I.T("Impossible to find page @1|30075",strOnglet), EFormAlerteType.Erreur);
				return;
			}					


			Bitmap bmp = null;
			if ( bAvecImage )
				bmp = CScreenCopieur.GetWindowImage ( ctrl );
			CFormulaire formulaire = new CFormulaire ( CSc2iWin32DataClient.ContexteCourant );
			if ( !formulaire.ReadIfExists ( new CFiltreData (
				CFormulaire.c_champLibelle+"=@1",
				GetIdentifiantForm(frm,  strOnglet) ) ) )
			{
				formulaire.CreateNew();
				formulaire.Role = CRoleChampCustom.GetRole ( CRoleFormulaireSurImpressionWin32.c_roleChampCustom );
				formulaire.Libelle=  GetIdentifiantForm(frm, strOnglet);
				C2iWndFenetre wnd = formulaire.Formulaire;
				wnd.BackColor = ctrl.BackColor;
				formulaire.Formulaire = wnd;
			}
			Type tp = null;
			if ( frm is CFormEditionStdTimos )
			{
				try
				{
					tp = ((CFormEditionStdTimos)frm).GetObjetEdite().GetType();
				}
				catch
				{
				}
			}
			if ( frm is CFormListeStandardTimos )
			{
				try
				{
					tp = ((CFormListeStandardTimos)frm).ListeObjets.TypeObjets;
				}
				catch{}
			}
           /* if (formulaire.IsNew())
                formulaire.TypeElementEdite = tp;*/
            List<IControleFormulaireExterne> lstControles = CEncapsuleurControleToControleFormulaireExterne.GetControlesFormulaireExterne(ctrl);
			CTimosApp.Navigateur.AffichePage ( new CFormEditionFormulaireAvance ( formulaire, bmp, lstControles,tp ));
		}

        //-------------------------------------------------------------------------------
        private static void FillListeControlesExternes(Control ctrl, List<IControleFormulaireExterne> lst)
        {
            IControleFormulaireExterne cex = ctrl as IControleFormulaireExterne;
            if (cex != null)
                lst.Add(cex);
            foreach (Control child in ctrl.Controls)
                FillListeControlesExternes(child, lst);
        }

		//-------------------------------------------------------------------------------
		private static void frm_Disposed(object sender, EventArgs e)
		{
			m_tableFormToCreateur.Remove ( sender );
		}

		//-------------------------------------------------------------------------------
		private static void CCustomiseurFenetresStandard_ObjetEditeChanged(object sender, EventArgs e)
		{
            RefreshWindow ( sender as Form );
		}

        //-------------------------------------------------------------------------------
        public static void RefreshWindow(Form frm)
        {
            if (frm == null)
                return;
            ArrayList lst = (ArrayList)m_tableFormToCreateur[frm];
            if (lst != null)
            {
                if (frm is IFormEditObjetDonnee)
                {
                    CFormEditionStdTimos frmTimos = frm as CFormEditionStdTimos;

                    foreach (CCreateur2iFormulaireV2 createur in lst)
                    {
                        if (createur != null)
                        {
                            createur.ElementEdite = frmTimos.GetObjetEdite();
                            createur.LockEdition = !frmTimos.ModeEdition;
                        }
                    }
                }
                else
                {
                    foreach (CCreateur2iFormulaireV2 createur in lst)
                    {
                        if (createur != null)
                            createur.InitChamps();
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------
        static void frmTimos_OnChangeModeEdition(object sender, EventArgs e)
        {
            ArrayList lst = (ArrayList)m_tableFormToCreateur[sender];
            if (lst != null && sender is CFormEditionStdTimos)
            {
                CFormEditionStdTimos frmTimos = sender as CFormEditionStdTimos;
                foreach (CCreateur2iFormulaireV2 createur in lst)
                {
                    if (createur != null)
                    {
                        createur.LockEdition = !frmTimos.ModeEdition;
                        
                        createur.SetElementEditeSansChangerLesValeursAffichees(frmTimos.GetObjetEdite());
                        

                    }
                }
                RefreshWindow(frmTimos);                
            }
            
        }

        //-------------------------------------------------------------------------------
        static void frmTimos_BeforeValideModification(object sender, CObjetDonneeCancelEventArgs args)
        {
            ArrayList lst = (ArrayList)m_tableFormToCreateur[sender];
            if (lst != null && sender is CFormEditionStdTimos)
            {
                CFormEditionStdTimos frmTimos = sender as CFormEditionStdTimos;
                foreach (CCreateur2iFormulaireV2 createur in lst)
                {
                    if (createur != null)
                    {
                        createur.MAJ_Champs();
                    }
                }
            }
        }


		//-------------------------------------------------------------------------------
		private static void item_Click(object sender, EventArgs e)
		{
			if ( sender is CMenuItemPourFormulaire )
			{ 
				CMenuItemPourFormulaire menu = (CMenuItemPourFormulaire)sender;
				EditeFormulaire ( menu.Formulaire, menu.Onglet );
			}
		}
	}
}
