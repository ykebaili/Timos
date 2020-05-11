using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using timos.data.projet.gantt;
using timos.data.workflow.gantt;
using timos.data;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.data;
using sc2i.data.dynamic;
using System.Collections;
using sc2i.win32.data.dynamic;
using sc2i.process;
using timos.win32.gantt;
using sc2i.win32.navigation;
using timos.data.projet;
using timos.Controles;
using timos.data.projet.besoin;
using sc2i.expression;
using sc2i.formulaire.win32.editor;

namespace timos.projet.gantt
{
    public partial class CControlGanttProjet : UserControl, IControlALockEdition
    {
        private CParametrageGantt m_parametreGroupement = null;
        private CParametrageDessinGantt m_parametreDessinGantt = null;
        private CParametreDessinLigneGantt m_parametreDessinLigne = CParametreDessinLigneGantt.ParametreParDefaut;
        private CFiltreData m_filtreDeBase = null;
        private CFiltreData m_filtreUser = null;
        private CProjet m_projet = null;
        private CMetaProjet m_metaProjet = null;
        private CContexteDonnee m_contexteDonnee = null;
        private CBaseGantt m_baseGantt = null;
        private CFiltreDynamique m_lastFiltreDynamique = null;
        private CParametresAffichageGantt m_parametreAffichage = new CParametresAffichageGantt();
        private ToolStripMenuItem m_menuApplyTemplate = null;
        private ToolStripMenuItem m_menuDetailRapide = null;

        private ToolStripMenuItem m_detailMenuItem = null;

        public CControlGanttProjet()
        {
            InitializeComponent();
            m_parametreAffichage.Unit = EGanttTimeUnit.Semaine;
            m_composantSauvegardePreferences.ControlGantt = this;

            m_gantt.MenuRClickArbre.Opening += new CancelEventHandler(MenuRClickArbre_Opening);

            m_detailMenuItem = new ToolStripMenuItem(I.T("Detail|20495"));
            m_detailMenuItem.Click += new EventHandler(m_menuDetailFromArbre_Click);
            m_gantt.MenuRClickArbre.Items.Add(new ToolStripSeparator());
            m_gantt.MenuRClickArbre.Items.Add(m_detailMenuItem);

            m_menuDetailRapide= new ToolStripMenuItem(I.T("Short detail|20731"));
            m_menuDetailRapide.Click += new EventHandler(m_menuDetailRapide_Click);
            m_gantt.MenuRClickArbre.Items.Add(m_menuDetailRapide);

            m_menuApplyTemplate = new ToolStripMenuItem(I.T("Apply template|20719"));
            m_gantt.MenuRClickArbre.Items.Add(m_menuApplyTemplate);

            C2iTextBoxSelectionneForMenu txtSelectTemplate = new C2iTextBoxSelectionneForMenu();
            m_menuApplyTemplate.DropDownItems.Add(txtSelectTemplate);
            txtSelectTemplate.TextBoxSelection.InitAvecFiltreDeBase<CPhaseSpecifications>("Libelle",
                new CFiltreData(CPhaseSpecifications.c_champUseAsTemplate + "=@1", true),
                false);
            txtSelectTemplate.OnSelectObject += new ObjetDonneeEventHandler(txtSelectTemplate_OnSelectObject);


        }

        

        //-------------------------------------
        void txtSelectTemplate_OnSelectObject(object sender, CObjetDonneeEventArgs args)
        {
            CPhaseSpecifications phase = args.Objet as CPhaseSpecifications;
            if (phase != null)
            {
                CElementDeGanttProjet prj = m_gantt.SelectedElement as CElementDeGanttProjet;
                CProjet projetParent = prj != null ? prj.ProjetAssocie : null;
                if (projetParent != null)
                {
                    if (CFormAlerte.Afficher(I.T("Apply template '@1' to project '@2'|20730",
                        phase.Libelle, projetParent.Libelle),
                        EFormAlerteBoutons.OuiNon,
                        EFormAlerteType.Question) == DialogResult.Yes)
                    {
                        CListeObjetsDonnees lst = phase.Besoins;
                        lst.Filtre = new CFiltreData(CBesoin.c_champTypeBesoin + "=@1 and " +
                            CTypeProjet.c_champId + " is null",
                            (int)ETypeDonneeBesoin.Projet);
                        CTypeProjet typeProjetDefault = null;
                        if (lst.Count > 0)
                        {
                            typeProjetDefault = CFormSelectUnObjetDonnee.SelectObjetDonnee(
                                I.T("Select default project type (for needs without project type)|20737"),
                                typeof(CTypeProjet), null, "Libelle") as CTypeProjet;
                            if (typeProjetDefault == null)
                                return;
                        }
                        using (CWaitCursor waiter = new CWaitCursor())
                        {
                            projetParent.ApplySpecificationTemplate(phase, typeProjetDefault);
                            Reinit();
                        }
                    }
                }
            }
        }


       
        //--------------------------------------------------------------------------
        public void SetPreferencesParametres(int nIdParametreGroupement, int nIdParametreDessin)
        {
            try
            {
                // Parametrage groupe
                CParametrageGantt paramGroupe = new CParametrageGantt(m_contexteDonnee);
                if (paramGroupe.ReadIfExists(nIdParametreGroupement))
                {
                    m_parametreGroupement = paramGroupe;
                    CResultAErreur result = paramGroupe.FiltreElements.GetFiltreData();
                    if (result)
                        m_filtreDeBase = result.Data as CFiltreData;
                }

                // Parametrage dessin
                CParametrageDessinGantt paramDessin = new CParametrageDessinGantt(m_contexteDonnee);
                if (paramDessin.ReadIfExists(nIdParametreDessin))
                {
                    m_parametreDessinGantt = paramDessin;
                    m_parametreDessinLigne = paramDessin.ParametreDessin;
                    m_gantt.ParametreDessinLigne = m_parametreDessinLigne;
                    Refresh();
                }

            }
            catch { }
        }

        public CParametrageGantt ParametrageGroupement
        {
            get
            {
                return m_parametreGroupement;
            }
        }

        public CParametrageDessinGantt ParametrageDessin
        {
            get
            {
                return m_parametreDessinGantt;
            }
        }

        public void Reinit()
        {
            CProjet old = m_projet;
            m_projet = null;
            Init(old);
        }


        public void Init(CProjet projet)
        {
            if (projet == null || !projet.IsValide())
            {
                Visible = false;
                return;
            }
            Visible = true;
            if (projet != m_projet)
            {
                DateTime dateDebut = DateTime.Now;
                if (projet != null && projet.DateDebutPlanifiee != null)
                    dateDebut = projet.DateDebutPlanifiee.Value;
                m_parametreAffichage.DateDebut = m_parametreAffichage.AddCells(dateDebut, -1);
            }
            m_projet = projet;
            m_metaProjet = null;
            if (projet != null)
                m_contexteDonnee = projet.ContexteDonnee;

            CParametreDessinLigneGantt parametreDessinGantt;

            m_composantSauvegardePreferences.InitFromRegistre();

            if (m_parametreDessinLigne != null)
                parametreDessinGantt = m_parametreDessinLigne;
            else
                parametreDessinGantt = CParametreDessinLigneGantt.ParametreParDefaut;

            m_parametreAffichage.LineHeight = parametreDessinGantt.HauteurLigne;

            m_gantt.Visible = false;
            m_gantt.Parametre = m_parametreAffichage;
            CFiltreData filtre = m_filtreDeBase;
            if (m_filtreUser != null)
                filtre = CFiltreData.GetAndFiltre(filtre, m_filtreUser);
            m_iconeHasFilter.Visible = m_filtreUser != null && m_filtreUser.Filtre!="" && m_filtreUser.Filtre!="1=1";
            CResultAErreur result = CParametrageGantt.CreateGantt(
                projet,
                m_parametreGroupement == null ? null : m_parametreGroupement.GroupeRacine,
                filtre);
            if (result)
            {
                m_baseGantt = result.Data as CBaseGantt;
                m_gantt.Visible = true;
                m_gantt.Init(m_baseGantt);
                m_gantt.ParametreDessinLigne = parametreDessinGantt;
                
            }
            m_cmbDisplayMode.Init(typeof(CParametrageGantt), "Libelle", false);
            if (m_parametreGroupement != null)
                m_cmbDisplayMode.ElementSelectionne = m_parametreGroupement;

        }

        public void Init(CMetaProjet metaProjet)
        {
            if (metaProjet != m_metaProjet)
            {
                DateTime dateDebut = DateTime.Now;
                dateDebut = metaProjet.DateDebutPlanifiee;
                m_parametreAffichage.DateDebut = m_parametreAffichage.AddCells(dateDebut, -1);
            }
            m_metaProjet = metaProjet;
            m_projet = null;
            if (metaProjet != null)
                m_contexteDonnee = metaProjet.ContexteDonnee;

            CParametreDessinLigneGantt parametreDessinGantt;

            m_composantSauvegardePreferences.InitFromRegistre();

            if (m_parametreDessinLigne != null)
                parametreDessinGantt = m_parametreDessinLigne;
            else
                parametreDessinGantt = CParametreDessinLigneGantt.ParametreParDefaut;

            m_parametreAffichage.LineHeight = parametreDessinGantt.HauteurLigne;

            m_gantt.Visible = false;
            m_gantt.Parametre = m_parametreAffichage;
            CFiltreData filtre = m_filtreDeBase;
            if (m_filtreUser != null)
                filtre = CFiltreData.GetAndFiltre(filtre, m_filtreUser);
            m_iconeHasFilter.Visible = m_filtreUser != null && m_filtreUser.Filtre != "" && m_filtreUser.Filtre != "1=1";
            CResultAErreur result = CParametrageGantt.CreateGantt(
                metaProjet,
                m_parametreGroupement == null ? null : m_parametreGroupement.GroupeRacine,
                filtre);
            if (result)
            {
                m_baseGantt = result.Data as CBaseGantt;
                m_gantt.Visible = true;
                m_gantt.Init(m_baseGantt);
                m_gantt.ParametreDessinLigne = parametreDessinGantt;

            }
            m_cmbDisplayMode.Init(typeof(CParametrageGantt), "Libelle", false);
            if (m_parametreGroupement != null)
                m_cmbDisplayMode.ElementSelectionne = m_parametreGroupement;

        }

        private void Init()
        {
            if (m_projet != null)
                Init(m_projet);
            else if (m_metaProjet != null)
                Init(m_metaProjet);
        }




        private void m_gantt_ElementGanttArbreMouseDown(object sender, timos.win32.gantt.CGanttElementEventArgs args)
        {
            //CElementDeGanttProjet eltProjet = m_gantt.SelectedElement as CElementDeGanttProjet;
            //if (eltProjet != null && args.MouseButtons == MouseButtons.Right && !LockEdition)
            //{
            //    Point pt = Cursor.Position;
            //    m_menuArbreGantt.Show(pt);
            //}
        }

        private void m_menuArbreGanttAdd_Click(object sender, EventArgs e)
        {
            CElementDeGanttProjet eltProjet = m_gantt.SelectedElement as CElementDeGanttProjet;
            if (eltProjet != null)
            {
                CProjet projet = new CProjet(eltProjet.ProjetAssocie.ContexteDonnee);
                projet.CreateNew();
                projet.Projet = eltProjet.ProjetAssocie;
                CFormNavigateurPopup.Show(new CFormEditionProjet(projet), FormWindowState.Maximized);
                if (!projet.IsValide() || !projet.VerifieDonnees(false).Result)
                    return;
                Init();
            }
        }

        private void m_gantt_ElementGanttArbreDoubleClick(object sender, timos.win32.gantt.CGanttElementEventArgs args)
        {
            /*CElementDeGanttProjet elt = args.ElementGantt as CElementDeGanttProjet;
            if (elt != null && elt.ProjetAssocie != m_projet)
            {
                if (!LockEdition)
                {
                    //CFormNavigateurPopup.Show(new CFormEditionProjet(elt.ProjetAssocie), FormWindowState.Maximized);
                    //Init(m_projet);
                }
                else
                {
                    CTimosApp.Navigateur.AffichePage(new CFormEditionProjet(elt.ProjetAssocie));
                }
            }*/
        }

        //-----------------------------------------------------------------
        void  MenuRClickArbre_Opening(object sender, CancelEventArgs e)
        {
            m_detailMenuItem.DropDownItems.Clear();
            m_menuDetailRapide.DropDownItems.Clear();
            m_detailMenuItem.Enabled = m_gantt.SelectedElement as CElementDeGanttProjet != null &&
                ((CElementDeGanttProjet)m_gantt.SelectedElement).ProjetAssocie != m_projet && LockEdition;
            m_menuDetailRapide.Enabled = m_gantt.SelectedElement as CElementDeGanttProjet != null &&
                ((CElementDeGanttProjet)m_gantt.SelectedElement).ProjetAssocie != m_projet;

            if ( m_gantt.SelectedElement.ElementsADessinerSurLaLigne.Count() > 1 )
            {
                List<IElementDeGantt> lstElts = new List<IElementDeGantt>();
                foreach ( IElementDeGantt eltTmp in m_gantt.SelectedElement.ElementsADessinerSurLaLigne )
                    lstElts.Add ( eltTmp );
                lstElts.Sort((x, y) => (x is CElementDeGanttProjet && y is CElementDeGanttProjet) ?
                    ((CElementDeGanttProjet)x).ProjetAssocie.NumeroIteration.CompareTo(((CElementDeGanttProjet)y).ProjetAssocie.NumeroIteration) :
                    0);
                foreach (IElementDeGantt elt in lstElts)
                {
                    CElementDeGanttProjet eltProjet = elt as CElementDeGanttProjet;
                    if (eltProjet != null)
                    {
                        string strLibelleElement = eltProjet.Libelle;
                        if (eltProjet.GanttBarId.Length > 0)
                        {
                            CProjet projetAssocie = eltProjet.ProjetAssocie;
                            string strDateDebut = I.T("(None)|148");
                            string strDateFin = I.T("(None)|148");
                            if (projetAssocie.DateDebutReel != null)
                                strDateDebut = projetAssocie.DateDebutReel.Value.ToShortDateString();

                            if (projetAssocie.DateFinRelle != null)
                                strDateFin = projetAssocie.DateFinRelle.Value.ToShortDateString();

                            string strPlageDates = "[" + strDateDebut + " - " + strDateFin + "]";
                            strLibelleElement += " " + eltProjet.ProjetAssocie.NumeroIteration + " " + strPlageDates;
                        }

                        ToolStripMenuItem itemProjet = new ToolStripMenuItem();
                        itemProjet.Text = strLibelleElement;
                        itemProjet.Tag = eltProjet;
                        itemProjet.Click += new EventHandler(itemProjet_Click);
                        m_detailMenuItem.DropDownItems.Add(itemProjet);

                        itemProjet = new ToolStripMenuItem();
                        itemProjet.Text = strLibelleElement;
                        itemProjet.Tag = eltProjet;
                        itemProjet.Click += new EventHandler(itemProjetRapide_Click);
                        m_menuDetailRapide.DropDownItems.Add(itemProjet);
                    }
                }
                m_detailMenuItem.Enabled = m_detailMenuItem.DropDownItems.Count > 0 && LockEdition;
                m_menuDetailRapide.Enabled = m_menuDetailRapide.DropDownItems.Count > 0;
            }
            m_menuApplyTemplate.Visible = m_gantt.SelectedElement is CElementDeGanttProjet && !LockEdition && 
                ((CElementDeGanttProjet)m_gantt.SelectedElement).ProjetAssocie.TypeProjet != null;
        }

        //-----------------------------------------------------------------
        void itemProjet_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CElementDeGanttProjet  projet = item != null ? item.Tag as CElementDeGanttProjet : null;
            if (projet != null && projet.ProjetAssocie != null)
            {
                if (LockEdition)
                {
                    CTimosApp.Navigateur.AffichePage(new CFormEditionProjet(projet.ProjetAssocie));
                }
            }
        }

        //-----------------------------------------------------------------
        void itemProjetRapide_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CElementDeGanttProjet projet = item != null ? item.Tag as CElementDeGanttProjet : null;
            if (projet != null && projet.ProjetAssocie != null)
            {
                CFormEditionStandard frm = FindForm() as CFormEditionStandard;
                CFormQuickEditProjet.EditeProjet(projet.ProjetAssocie, m_extModeEdition.ModeEdition, frm);
                if (projet.ElementParent != null)
                    projet.ElementParent.DatesAreDirty = true;
            }
        }

        //-----------------------------------------------------------------
        void m_menuDetailRapide_Click(object sender, EventArgs e)
        {
            CElementDeGanttProjet projet = m_gantt.SelectedElement as CElementDeGanttProjet;
            if (projet != null)
            {
                CFormEditionStandard frm = FindForm() as CFormEditionStandard;
                CFormQuickEditProjet.EditeProjet(projet.ProjetAssocie, m_extModeEdition.ModeEdition, frm);
                m_gantt.RefreshElement(projet);
            }
        }


        //-----------------------------------------------------------------
        void m_menuDetailFromArbre_Click(object sender, EventArgs e)
        {
            CElementDeGanttProjet projet = m_gantt.SelectedElement as CElementDeGanttProjet;
            if (projet != null && projet.ProjetAssocie != null)
            {
                if (LockEdition)
                {
                    CTimosApp.Navigateur.EditeElement(projet.ProjetAssocie, false, "");
                }
            }
        }


        



        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_gantt_Load(object sender, EventArgs e)
        {

        }

        private void m_cmbDisplayMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CParametrageGantt parametre = m_cmbDisplayMode.SelectedValue as CParametrageGantt;
            if (parametre != m_parametreGroupement)
            {
                m_parametreGroupement = parametre;
                m_filtreDeBase = null;
                if (parametre != null && parametre.FiltreElements != null)
                {
                    CResultAErreur result = parametre.FiltreElements.GetFiltreData();
                    if (result)
                        m_filtreDeBase = result.Data as CFiltreData;
                }
                m_composantSauvegardePreferences.SaveToRegistre();
                Init();
            }

        }

        private class CMenuItemFiltre : ToolStripMenuItem
        {
            CFiltreDynamiqueInDb m_filtre = null;
            public CMenuItemFiltre(CFiltreDynamiqueInDb filtre) :
                base(filtre.Libelle)
            {
                m_filtre = filtre;
            }

            public CFiltreDynamiqueInDb Filtre
            {
                get
                {
                    return m_filtre;
                }
            }
        }


        private void m_menuFiltres_Opening(object sender, CancelEventArgs e)
        {
            if (sender == m_menuFiltres)
            {
                foreach (IDisposable obj in new ArrayList(m_menuFiltres.Items))
                {
                    obj.Dispose();
                }
                CListeObjetDonneeGenerique<CFiltreDynamiqueInDb> lst = new CListeObjetDonneeGenerique<CFiltreDynamiqueInDb>(m_contexteDonnee);
                lst.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1",
                    typeof(CProjet).ToString());
                foreach (CFiltreDynamiqueInDb filtre in lst)
                {
                    CMenuItemFiltre itemMenuFiltre = new CMenuItemFiltre(filtre);
                    itemMenuFiltre.Click += new EventHandler(itemMenuFiltre_Click);
                    m_menuFiltres.Items.Add(itemMenuFiltre);
                }
            }

        }


        void itemMenuFiltre_Click(object sender, EventArgs e)
        {
            CMenuItemFiltre menuFiltre = sender as CMenuItemFiltre;
            if (menuFiltre != null)
            {
                CFiltreDynamiqueInDb filtreInDb = menuFiltre.Filtre;
                CFiltreDynamique filtre = filtreInDb.Filtre;

                if (m_lastFiltreDynamique != null)
                {
                    foreach (IVariableDynamique variable in m_lastFiltreDynamique.ListeVariables)
                    {
                        object val = m_lastFiltreDynamique.GetValeurChamp(variable.IdVariable);
                        IVariableDynamique var2 = filtre.GetVariable(variable.IdVariable);
                        if (var2 != null && var2.Nom == variable.Nom)
                            filtre.SetValeurChamp(var2, val);
                    }
                }
                m_lastFiltreDynamique = filtre;

                if (filtre.FormulaireEdition.Childs.Count() > 0)
                {
                    if (!CFormFormulairePopup.EditeElement(
                        filtre.FormulaireEdition, filtre, "Filter|20175"))
                        return;
                }
                ApplyFiltre(filtre);
            }
        }

        private void ApplyFiltre(CFiltreDynamique filtre)
        {
            if (filtre != null)
            {
                m_lastFiltreDynamique = filtre;
                CResultAErreur result = filtre.GetFiltreData();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur.Erreurs);
                    return;
                }
                m_filtreUser = result.Data as CFiltreData;
                Init();
            }
        }

        private void m_imageFiltre_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_menuFiltres.Show(m_imageFiltre, new Point(0, m_imageFiltre.Height));
            }
            else if (e.Button == MouseButtons.Right)
            {
                m_filtreUser = null;
                Init();
            }
        }


        private void m_gantt_GanttContextMenuOpenning(object sender, timos.win32.gantt.CGanttElementEventArgs args)
        {
            // Ajoute des items suplpémentaires au menu contextuel des barres de Gantt
            ContextMenuStrip menu = sender as ContextMenuStrip;
            if (menu == null)
                return;
            
            IElementDeGantt elementGantt = args.ElementGantt;
            CProjet projetSelectionne = null;

            if (elementGantt != null)
                projetSelectionne = elementGantt.ProjetAssocie;

            if (projetSelectionne != null)
            {
                // Ajout de la gestion des dates
                ToolStripMenuItem itemDatesAuto = new ToolStripMenuItem(I.T("Automatic dates|10080"));
                itemDatesAuto.Checked = elementGantt.DatesAuto;
                itemDatesAuto.CheckOnClick = true;
                itemDatesAuto.Tag = elementGantt;
                itemDatesAuto.Click += new EventHandler(OnClickItemDatesAuto);
                itemDatesAuto.Enabled = !LockEdition;
                //if (!projetSelectionne.HasChilds())
                {
                    menu.Items.Add(itemDatesAuto);
                    menu.Items.Add(new ToolStripSeparator()); //----------------------------

                }
                // Sélections des Action à déclencher
                ToolStripMenuItem itemActions = new ToolStripMenuItem(I.T("Actions|169"));
                menu.Items.Add(itemActions);

                CUtilMenuActionSurElement.InitMenuActions(
                    projetSelectionne,
                    itemActions.DropDownItems, 
                    new MenuActionEventHandler(OnClickItemActionSurProjet));

                ///Stef 19/11/2012 : utilisation du CUtilMenuActionSurElement
                /*IDeclencheurAction[] declencheurs = CRecuperateurDeclencheursActions.GetActionsManuelles(projetSelectionne, false);
                foreach (IDeclencheurAction declencheur in declencheurs)
                {
                    IDeclencheurActionManuelle declencheurManu = declencheur as IDeclencheurActionManuelle;
                    if (declencheurManu != null)
                    {

                        if (declencheurManu.DeclencherSurContexteClient || LockEdition)
                        {
                            string strMenu = "";
                            strMenu = declencheurManu.MenuManuel;
                            string[] strMenus = strMenu.Split('/');
                            ToolStripItemCollection listeSousMenus = itemActions.DropDownItems;
                            if (strMenus.Length > 0)
                            {
                                foreach (string strSousMenu in strMenus)
                                {
                                    if (strSousMenu.Trim().Length > 0)
                                    {
                                        ToolStripMenuItem sousMenu = null;
                                        foreach (ToolStripMenuItem item in listeSousMenus)
                                            if (item.Text == strSousMenu)
                                            {
                                                sousMenu = item;
                                                break;
                                            }
                                        if (sousMenu == null)
                                        {
                                            sousMenu = new ToolStripMenuItem(strSousMenu);
                                            listeSousMenus.Add(sousMenu);
                                        }
                                        listeSousMenus = sousMenu.DropDownItems;
                                    }
                                }
                            }

                            ToolStripMenuItem itemAction = new ToolStripMenuItem(declencheurManu.Libelle);
                            itemAction.Tag = new CInfoDeclenchementActionSurProjet(declencheurManu, projetSelectionne);
                            itemAction.Click += new EventHandler(OnClickItemActionSurProjet);
                            listeSousMenus.Add(itemAction);
                        }
                    }
                }
                if (itemActions.DropDownItems.Count == 0)
                {
                    ToolStripMenuItem itemActionVide = new ToolStripMenuItem(I.T("(None)|10074"));
                    itemActionVide.Enabled = false;
                    itemActions.DropDownItems.Add(itemActionVide);

                }*/

            }

            // Sélection des parametres de dessin de Gantt
            ToolStripMenuItem itemDisplay = new ToolStripMenuItem(I.T("Display|10072"));
            menu.Items.Add(itemDisplay);
            // Créer le paramatre de dessin par défaut
            ToolStripMenuItem itemParam = new ToolStripMenuItem(I.T("Default display setting|10073"));
            itemParam.Tag = null;
            itemParam.Click += new EventHandler(OnClickItemParametreDessinGantt);
            itemDisplay.DropDownItems.Add(itemParam);


            CListeObjetsDonnees lstParametragesDessin = new CListeObjetsDonnees(m_contexteDonnee, typeof(CParametrageDessinGantt));
            foreach (CParametrageDessinGantt paramInDB in lstParametragesDessin)
            {
                string strLibelle = paramInDB.Libelle;
                itemParam = new ToolStripMenuItem(strLibelle);
                itemParam.Tag = paramInDB;
                itemParam.Click += new EventHandler(OnClickItemParametreDessinGantt);
                itemDisplay.DropDownItems.Add(itemParam);

            }

            
        }

        void OnClickItemDatesAuto(object sender, EventArgs e)
        {
            ToolStripMenuItem itemDatesAuto = sender as ToolStripMenuItem;
            if(itemDatesAuto != null)
            {
                CElementDeGanttProjet elementProjet = itemDatesAuto.Tag as CElementDeGanttProjet;
                if (elementProjet != null)
                {
                    CProjet projetSelectionne = elementProjet.ProjetAssocie;
                    if (projetSelectionne != null)
                    {
                        projetSelectionne.DateDebutAuto = itemDatesAuto.Checked;
                        m_baseGantt.AppliqueParametreDessin(m_parametreDessinLigne);
                        Refresh();
                    }

                    if (OnMoveElementDeGantt != null)
                        OnMoveElementDeGantt(elementProjet);
                }
            }
        }

        private class CInfoDeclenchementActionSurProjet
        {
            public readonly IDeclencheurActionManuelle Declencheur;
            public readonly CProjet Projet;

            public CInfoDeclenchementActionSurProjet(IDeclencheurActionManuelle d, CProjet p)
            {
                Declencheur = d;
                Projet = p;
            }

        }

        void OnClickItemActionSurProjet(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetAction)
        {
            if (declencheur != null && objetAction != null)
            {
                CResultAErreur result = CResultAErreur.True;
                if (!LockEdition)
                {
                    IDeclencheurActionManuelle declencheurManuel = declencheur as IDeclencheurActionManuelle;
                    if (declencheurManuel != null)
                    {
                        // Déclancher ici l'évenement manuelle sur Client
                        result = declencheurManuel.EnregistreDeclenchementEvenementSurClient(
                            objetAction,
                            new CInfoDeclencheurProcess(TypeEvenement.Manuel),
                            null);
                    }
                    else
                        MessageBox.Show(I.T("Can not start this action|20673"));
                }
                else
                {
                    // Déclancher ici l'évenement manuelle sur Serveur
                    result = CFormExecuteProcess.RunEvent(declencheur, objetAction, false);
                }
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
                else
                {
                    CFormEditionStandard form = FindForm() as CFormEditionStandard;
                    if (form != null)
                        form.Actualiser();

                }

            }
        }

        void OnClickItemParametreDessinGantt(object sender, EventArgs e)
        {
            // Change le parametre de dessin du Gantt
            ToolStripMenuItem itemParam = sender as ToolStripMenuItem;
            if (itemParam != null)
            {
                CParametrageDessinGantt paramInDb = itemParam.Tag as CParametrageDessinGantt;
                if (paramInDb != null)
                {
                    // Applique le parmatre de dessin sélmectionné
                    m_parametreDessinGantt = paramInDb;
                    m_parametreDessinLigne = paramInDb.ParametreDessin;
                }
                else
                {
                    // Pas de parametre
                    m_parametreDessinGantt = null;
                    m_parametreDessinLigne = CParametreDessinLigneGantt.ParametreParDefaut;

                }

                m_composantSauvegardePreferences.SaveToRegistre();
                Init();

            }
        }

        public event OnMoveGanttElement OnMoveElementDeGantt;
        // Remonte l'événement pour controls parents
        private void m_gantt_OnMoveElementDeGantt(IElementDeGantt element)
        {
            if (OnMoveElementDeGantt != null)
                OnMoveElementDeGantt(element);
        }

        public void FillContexteNavigation(CContexteFormNavigable ctx)
        {
            if ( ctx != null )
                ctx["GANTT_FILTER"] = m_lastFiltreDynamique;
        }

        public void InitFromContexteNavigation(CContexteFormNavigable ctx)
        {
            if (ctx != null)
            {
                CFiltreDynamique filtre = ctx["GANTT_FILTER"] as CFiltreDynamique;
                ApplyFiltre(filtre);
            }
        }

    }
}
