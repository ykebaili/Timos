using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data;
using sc2i.data;
using timos.data;
using timos.acteurs;
using sc2i.workflow;
using sc2i.win32.data.navigation;
using sc2i.data.dynamic;
using timos.General;
using sc2i.win32.data.dynamic;
using System.Collections;
using sc2i.expression;
using sc2i.formulaire.win32.editor;


namespace timos.interventions
{
    public partial class CPanelPlanification : UserControl, IControlALockEdition
    {
        IBasePlanning m_basePlanning;

        private CFiltreDynamiqueInDb m_filtreDynamicSelectionnee = null;
        private CFiltreDynamique m_filtreDynamicApplique = null;

        private CListeEntites m_listeEntitesSelectionnee = null;

        private HashSet<int> m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;

        private CContexteDonnee m_contexteDonnee = null;
        public CPanelPlanification()
        {
            InitializeComponent();
            m_contexteDonnee = CSc2iWin32DataClient.ContexteCourant;
            m_basePlanning = new CFournisseurEntreesPlanning(m_contexteDonnee);
            m_controlePlanning.BaseAffichee = m_basePlanning; ;

            try
            {
                if (!DesignMode)
                {
                    InitMenuListesInters();
                    InitMenuFiltresInters();
                }
            }
            catch { }

        }

        //---------------------------------------------------
        private void InitMenuListesInters()
        {
            m_menuListeEntitesInter.Items.Clear();
            CListeObjetDonneeGenerique<CListeEntites> lst = new CListeObjetDonneeGenerique<CListeEntites>(m_contexteDonnee);
            lst.Filtre = new CFiltreData(CListeEntites.c_champTypeElements + "=@1",
                typeof(CIntervention).ToString());
            foreach (CListeEntites liste in lst)
            {
                CObjetDonneeMenuItem menuListe = new CObjetDonneeMenuItem(
                    liste,
                    liste,
                    liste.Libelle,
                    false);
                menuListe.Click += new EventHandler(menuListe_Click);
                m_menuListeEntitesInter.Items.Add(menuListe);
            }
        }


        //---------------------------------------------------
        private void InitMenuFiltresInters()
        {
            m_menuFiltresInters.Items.Clear();
            CListeObjetDonneeGenerique<CFiltreDynamiqueInDb> lst = new CListeObjetDonneeGenerique<CFiltreDynamiqueInDb>(m_contexteDonnee);
            lst.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1",
                typeof(CIntervention).ToString());
            foreach (CFiltreDynamiqueInDb filtre in lst)
            {
                CObjetDonneeMenuItem menuFiltre = new CObjetDonneeMenuItem(
                    filtre,
                    filtre,
                    filtre.Libelle,
                    false);
                menuFiltre.Click += new EventHandler(menuFiltre_Click);
                m_menuFiltresInters.Items.Add(menuFiltre);
            }
        }

        //---------------------------------------------------
        private CFiltreDynamique m_lastFiltreDynamique = null;
        void menuFiltre_Click(object sender, EventArgs e)
        {
            CObjetDonneeMenuItem item = sender as CObjetDonneeMenuItem;
            CFiltreDynamiqueInDb filtreInDb = item != null ? item.ObjetDragDrop as CFiltreDynamiqueInDb : null;
            if (filtreInDb != null)
            {
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
                    {
                        return;
                    }
                }
                m_filtreDynamicSelectionnee = filtreInDb;
                m_filtreDynamicApplique = filtre;
                m_chkIntersFiltre.Checked = true;
                m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;
                FillListeIntersAvecDelai();
            }
        }

        //---------------------------------------------------
        public void SetListeFiltreInters(CListeEntites lstInters)
        {
            m_listeEntitesSelectionnee = lstInters;
            m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;
            m_chkIntersSurListe.Checked = true;
            FillListeIntersAvecDelai();
        }

        //---------------------------------------------------
        void menuListe_Click(object sender, EventArgs e)
        {
            CObjetDonneeMenuItem item = sender as CObjetDonneeMenuItem;
            CListeEntites liste = item != null ? item.ObjetDragDrop as CListeEntites : null;
            if (liste != null)
            {
                SetListeFiltreInters(liste);
            }
        }

        //---------------------------------------------------
        public bool OnlyNotPlanned
        {
            get
            {
                return m_chkIntersNonPlanifiées.Checked;
            }
            set
            {
                m_chkIntersNonPlanifiées.Checked = value;
            }
        }

        //---------------------------------------------------
        public bool OnlyNotAssigned
        {
            get
            {
                return m_chkIntersNonAffectées.Checked;
            }
            set
            {
                m_chkIntersNonAffectées.Checked = value;
            }
        }

        //---------------------------------------------------
        public void SetDates(DateTime dateDebut, DateTime dateFin)
        {
            m_controlePlanning.DateDebut = dateDebut;
            m_controlePlanning.DateFin = dateFin;
            m_controlePlanning.Refresh();
        }

        public void SetContexteDonnee(CContexteDonnee contexte)
        {
            m_contexteDonnee = contexte;
            //Crée une nouvelle baseplanning dans ce contexte;
            CFournisseurEntreesPlanning newBase = new CFournisseurEntreesPlanning(contexte);
            if (m_basePlanning != null)
            {
                foreach (IElementAIntervention elt in m_basePlanning.ElementsAIntervention)
                {
                    if (elt is CObjetDonnee)
                    {
                        CObjetDonnee newElt = (CObjetDonnee)Activator.CreateInstance(elt.GetType(), contexte);
                        if (newElt.ReadIfExists(((CObjetDonnee)elt).GetValeursCles()))
                            newBase.AddElementAIntervention((IElementAIntervention)newElt);
                    }
                }
                foreach (IRessourceEntreePlanning ressource in m_basePlanning.Ressources)
                {
                    if (ressource is CObjetDonnee)
                    {
                        CObjetDonnee newElt = (CObjetDonnee)Activator.CreateInstance(ressource.GetType(), contexte);
                        if (newElt.ReadIfExists(((CObjetDonnee)ressource).GetValeursCles()))
                            newBase.AddRessource((IRessourceEntreePlanning)newElt);
                    }
                }
            }
            m_basePlanning = newBase;
            m_controlePlanning.BaseAffichee = m_basePlanning;
            FillListeInterventionsAPlanifier();
        }

        public void ShowElementAIntervention(IElementAIntervention element)
        {
            m_basePlanning.AddElementAIntervention(element);
            m_controlePlanning.Refresh();
            m_controlePlanning.ElementAInterventionSelectionne = element;
        }

        public void ShowRessources(IRessourceEntreePlanning[] ressources)
        {
            foreach (IRessourceEntreePlanning res in ressources)
            {
                m_basePlanning.AddRessource(res);
            }
            m_controlePlanning.Refresh();
        }

        //--------------------------------------------
        private void m_timerRefreshInterventionsPlanifiees_Tick(object sender, EventArgs e)
        {
            FillListeInterventionsAPlanifier();
        }

        //---------------------------------------------
        private void FillListeInterventionsAPlanifier()
        {
            m_timerRefreshInterventionsPlanifiees.Stop();
            IElementAIntervention element = m_controlePlanning.ElementAInterventionSelectionne;
            if (element == null)
            {
                m_chkIntersSurSiteSelectionné.Visible = false;
            }
            else
            {
                m_chkIntersSurSiteSelectionné.Text = I.T("Filter on @1|20658", element.DescriptionElement);
            }
            m_panelTachesPrePlanifiees.Visible = true;

            DateTime dateDebut = m_controlePlanning.DateDebut.Date;

            DateTime dateFin = m_controlePlanning.DateFin.Date.AddDays(1);

            m_lblDatesListe.Text = I.T("from @1 to @2|20652", dateDebut.ToShortDateString(),
                dateFin.ToShortDateString());

            if (m_listeEntitesSelectionnee != null)
                m_chkIntersSurListe.Text = m_listeEntitesSelectionnee.Libelle;
            if (m_filtreDynamicSelectionnee != null)
                m_chkIntersFiltre.Text = m_filtreDynamicSelectionnee.Libelle;


            CListeObjetsDonnees listeInters = new CListeObjetsDonnees(m_contexteDonnee, typeof(CIntervention));
            listeInters.PreserveChanges = true;

            CFiltreData filtre = new CFiltreDataAvance(CIntervention.c_nomTable,
                    "(" + CIntervention.c_champDateDebutPreplanifiee + "<@1 and " +
                    CIntervention.c_champDateFinPrePlanifiee + ">@2) or (" +
                    CFractionIntervention.c_nomTable + "." +
                    CFractionIntervention.c_champDateDebutPlanifie + "<@1 and " +
                    CFractionIntervention.c_nomTable + "." +
                    CFractionIntervention.c_champDateFinPlanifiee + ">@2)",
                    dateFin,
                    dateDebut);
            if (m_chkIntersSurSiteSelectionné.Checked && element is CSite)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreData(CIntervention.c_champIdElementLie + "=@1",
                        element.Id));
            }
            if (m_chkIntersNonPlanifiées.Checked)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreDataAvance(CIntervention.c_nomTable,
                        "HasNo(" + CFractionIntervention.c_nomTable + "." +
                    CFractionIntervention.c_champId + ")"));
            }
            if (m_chkIntersNonAffectées.Checked)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreDataAvance(CIntervention.c_nomTable,
                        "Hasno(" + CIntervention_Intervenant.c_nomTable + "." +
                        CIntervention_Intervenant.c_champId + ")"));
            }
            listeInters.Filtre = filtre;

            if (m_setIdsInterventionsVisiblesCalculéDefiltreEtListe == null)
                CalculeSetIdsInterventionsVisibles();


            List<CIntervention> lstFiltree = listeInters.ToList<CIntervention>();
            foreach (CIntervention inter in listeInters.ToArrayList())
            {
                if (m_chkIntersNonPlanifiées.Checked && inter.Fractions.Count > 0)
                    lstFiltree.Remove(inter);
                if (m_chkIntersNonAffectées.Checked && inter.RelationsIntervenants.Count > 0)
                    lstFiltree.Remove(inter);
                if (inter.Id >= 0 && m_setIdsInterventionsVisiblesCalculéDefiltreEtListe != null &&
                    !m_setIdsInterventionsVisiblesCalculéDefiltreEtListe.Contains(inter.Id))
                    lstFiltree.Remove(inter);
            }
            m_wndListeInterAPlanifier.ListeSource = lstFiltree;
            m_wndListeInterAPlanifier.Refresh();

        }

        //---------------------------------------------------------------
        private void CalculeSetIdsInterventionsVisibles()
        {
            if (m_filtreDynamicApplique == null && m_listeEntitesSelectionnee == null)
            {
                m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;
                return;
            }

            HashSet<int> setIdsFromfiltre = null;
            HashSet<int> setIdsFromListe = null;

            if (m_filtreDynamicApplique != null && m_chkIntersFiltre.Checked)
            {
                CFiltreData filtre = null;
                CResultAErreur res = m_filtreDynamicApplique.GetFiltreData();
                if (res && res.Data is CFiltreData)
                    filtre = res.Data as CFiltreData;
                if (filtre != null)
                {
                    setIdsFromfiltre = new HashSet<int>();
                    C2iRequeteAvancee requete = new C2iRequeteAvancee(m_contexteDonnee.IdVersionDeTravail);
                    requete.FiltreAAppliquer = filtre;
                    requete.TableInterrogee = CIntervention.c_nomTable;
                    requete.ListeChamps.Add(new C2iChampDeRequete(
                        "INTER_ID",
                        new CSourceDeChampDeRequete(CIntervention.c_champId),
                        typeof(int),
                        OperationsAgregation.None,
                        false));
                    res = requete.ExecuteRequete(m_contexteDonnee.IdSession);
                    if (res && res.Data is DataTable)
                    {
                        foreach (DataRow row in ((DataTable)res.Data).Rows)
                        {
                            setIdsFromfiltre.Add((int)row["INTER_ID"]);
                        }
                    }
                }
            }
            if (m_listeEntitesSelectionnee != null && m_chkIntersSurListe.Checked)
            {
                setIdsFromListe = new HashSet<int>();
                foreach (CIntervention inter in m_listeEntitesSelectionnee.ElementsLies)
                {
                    setIdsFromListe.Add(inter.Id);
                }
            }
            if (setIdsFromListe != null || setIdsFromfiltre != null)
            {
                if (setIdsFromListe == null)
                    m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = setIdsFromfiltre;
                else if (setIdsFromfiltre == null)
                    m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = setIdsFromListe;
                else
                {
                    m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = new HashSet<int>();
                    foreach (int nId in setIdsFromListe)
                        if (setIdsFromfiltre.Contains(nId))
                            m_setIdsInterventionsVisiblesCalculéDefiltreEtListe.Add(nId);
                }
            }
                    
        }







        private void m_lnkAjouterIntervention_LinkClicked(object sender, EventArgs e)
        {
            if (m_contexteDonnee == null || m_controlePlanning.ElementAInterventionSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Function not avaliable|30204"), EFormAlerteType.Exclamation);
                return;
            }
            CIntervention intervention = new CIntervention(m_contexteDonnee);
            intervention.CreateNew();
            intervention.ElementAIntervention = (CObjetDonneeAIdNumerique)m_controlePlanning.ElementAInterventionSelectionne;
            intervention.DateDebutPrePlanifiee = m_controlePlanning.DateDebut;
            intervention.DateFinPrePlanifiee = m_controlePlanning.DateFin;
            intervention.UserPreplanifieur = CUtilSession.GetUserForSession(m_contexteDonnee);
            intervention.UserPlanifieur = intervention.UserPlanifieur;
            EditeIntervention(intervention);
        }

        //---------------------------------------------------
        private void AfficheInfosElement(IElementAIntervention element)
        {
            FillListeIntersAvecDelai();
        }

        private bool m_bPreventFromFillListeInters = false;
        private void FillListeIntersAvecDelai()
        {
            if (!m_bPreventFromFillListeInters)
            {
                m_timerRefreshInterventionsPlanifiees.Stop();
                m_timerRefreshInterventionsPlanifiees.Start();
            }
        }

        //---------------------------------------------------
        private void m_controlePlanning_OnChangeSelectionElementAIntervention(object sender, EventArgs e)
        {
            AfficheInfosElement(m_controlePlanning.ElementAInterventionSelectionne);
        }

        //---------------------------------------------------
        private void EditeIntervention(CIntervention intervention)
        {
            if (intervention != null)
            {
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CIntervention));
                if (refTypeForm != null)
                {
                    CFormEditionStandard frm = refTypeForm.GetForm(intervention) as CFormEditionStandard;
                    if (frm != null)
                    {
                        if (m_gestionnaireModeEdition.ModeEdition)
                            CFormNavigateurPopup.Show(frm, FormWindowState.Maximized);
                        else
                        {
                            sc2i.win32.navigation.IFormNavigable thisFrm = FindForm() as sc2i.win32.navigation.IFormNavigable;
                            if (thisFrm != null && thisFrm.Navigateur != null)
                                thisFrm.Navigateur.AffichePage(frm);
                            else
                                CFormMain.GetInstance().AffichePage(frm);
                        }
                    }
                }
                FillListeInterventionsAPlanifier();
                m_controlePlanning.Refresh();
            }
        }


        //---------------------------------------------------
        private void m_lnkDetailIntervention_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeInterAPlanifier.SelectedItems.Count == 1)
            {
                CIntervention intervention = (CIntervention)m_wndListeInterAPlanifier.SelectedItems[0];
                EditeIntervention(intervention);
            }
        }

        //-------------------------------------------------------------------------------
        private void m_controlePlanning_OnChangeBornesDates(object sender, EventArgs e)
        {
            AfficheInfosElement(m_controlePlanning.ElementAInterventionSelectionne);
        }

        //-------------------------------------------------------------------------------
        private void m_wndListeInterAPlanifier_MouseMove(object sender, MouseEventArgs e)
        {
        }

        //-------------------------------------------------------------------------------
        private void m_wndListeInterAPlanifier_OnBeginDragItem(object sender, object itemDrag)
        {
            if (itemDrag is CIntervention)
            {

                CReferenceObjetDonneeDragDropData data = new CReferenceObjetDonneeDragDropData((CIntervention)itemDrag);

                //data.SetData(itemDrag);

                if (DoDragDrop(data, DragDropEffects.Move | DragDropEffects.Link) != DragDropEffects.None)
                {
                    AfficheInfosElement(m_controlePlanning.ElementAInterventionSelectionne);
                    m_controlePlanning.Refresh();
                }
            }
        }

        #region IControlALockEdition Membres
        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }
        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_controlePlanning_OnEditerIntervention(object sender, EventArgs e)
        {
            IEntreePlanning entree = m_controlePlanning.EntreePlanningSelectionnee;
            if (entree is CIntervention)
            {
                CFormEditionIntervention form = new CFormEditionIntervention((CIntervention)entree);
                if (m_gestionnaireModeEdition.ModeEdition)
                {
                    CFormNavigateurPopup.Show(form, FormWindowState.Maximized);
                    m_controlePlanning.Refresh();
                }
                else
                    CTimosApp.Navigateur.AffichePage(form);
            }
        }

        //------------------------------------------------------------------------------------------
        public void FillContexteFormNavigable(sc2i.win32.navigation.CContexteFormNavigable contexte)
        {
            List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
            foreach (IElementAIntervention elt in m_basePlanning.ElementsAIntervention)
                if (elt is CObjetDonnee)
                    lst.Add(new CReferenceObjetDonnee((CObjetDonnee)elt));
            contexte["ELTSAINTER"] = lst;

            lst = new List<CReferenceObjetDonnee>();
            foreach (IRessourceEntreePlanning ressource in m_basePlanning.Ressources)
                if (ressource is CObjetDonnee)
                    lst.Add(new CReferenceObjetDonnee((CObjetDonnee)ressource));
            contexte["ELTSRES"] = lst;
            contexte["DATE_DEBUT"] = m_controlePlanning.DateDebut;
            contexte["DATE_FIN"] = m_controlePlanning.DateFin;
        }

        //------------------------------------------------------------------------------------------
        public CResultAErreur FillFromContexteFormNavigable(sc2i.win32.navigation.CContexteFormNavigable contexte)
        {
            if (m_basePlanning == null)
                m_basePlanning = new CFournisseurEntreesPlanning(CSc2iWin32DataClient.ContexteCourant);
            List<CReferenceObjetDonnee> lst = (List<CReferenceObjetDonnee>)contexte["ELTSAINTER"];
            if (lst != null)
            {
                foreach (CReferenceObjetDonnee refr in lst)
                    m_basePlanning.AddElementAIntervention((IElementAIntervention)refr.GetObjet(CSc2iWin32DataClient.ContexteCourant));
            }
            lst = (List<CReferenceObjetDonnee>)contexte["ELTSRES"];
            if (lst != null)
            {
                foreach (CReferenceObjetDonnee refr in lst)
                    m_basePlanning.AddRessource((IRessourceEntreePlanning)refr.GetObjet(CSc2iWin32DataClient.ContexteCourant));
            }
            if (contexte["DATE_DEBUT"] is DateTime)
                m_controlePlanning.DateDebut = (DateTime)contexte["DATE_DEBUT"];
            if (contexte["DATE_FIN"] is DateTime)
                m_controlePlanning.DateFin = (DateTime)contexte["DATE_FIN"];
            m_controlePlanning.BaseAffichee = m_basePlanning;
            return CResultAErreur.True;
        }

        private void m_btnModeIntervenants_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeIntervenants.Checked)
                m_controlePlanning.TypeRessourcesAAffecter = typeof(CActeur);
        }

        private void m_btnModeRessources_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeRessources.Checked)
                m_controlePlanning.TypeRessourcesAAffecter = typeof(CRessourceMaterielle);
        }

        private void m_btnTailleLigne_Click(object sender, EventArgs e)
        {
            if (m_controlePlanning.HauteurLigne == 16)
                m_controlePlanning.HauteurLigne = 26;
            else
                m_controlePlanning.HauteurLigne = 16;
        }

        //------------------------------------------------------------------
        private void m_picIntersSurListe_Click(object sender, EventArgs e)
        {
            m_menuListeEntitesInter.Show(m_picIntersSurListe, new Point(0, m_picIntersSurListe.Height));
        }


        //------------------------------------------------------------------
        private void m_picIntersFiltre_Click(object sender, EventArgs e)
        {
            m_menuFiltresInters.Show(m_picIntersFiltre, new Point(0, m_picIntersFiltre.Height));
        }

        //------------------------------------------------------------------
        private void m_chkIntersSurSiteSelectionné_CheckedChanged(object sender, EventArgs e)
        {
            FillListeIntersAvecDelai();
        }

        //------------------------------------------------------------------
        private void m_chkIntersNonPlanifiées_CheckedChanged(object sender, EventArgs e)
        {
            FillListeIntersAvecDelai();
        }

        //------------------------------------------------------------------
        private void m_chkIntersNonAffectées_CheckedChanged(object sender, EventArgs e)
        {
            FillListeIntersAvecDelai();
        }

        //------------------------------------------------------------------
        private void m_chkIntersSurListe_CheckedChanged(object sender, EventArgs e)
        {
            m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;
            FillListeIntersAvecDelai();

        }

        //------------------------------------------------------------------
        private void m_chkIntersFiltre_CheckedChanged(object sender, EventArgs e)
        {
            m_setIdsInterventionsVisiblesCalculéDefiltreEtListe = null;
            FillListeIntersAvecDelai();
        }


        //------------------------------------------------------------------
        private void m_btnOpenConfig_MouseUp(object sender, MouseEventArgs e)
        {
            m_menuLoadFile.Show(m_btnOpenConfig, new Point(0, m_btnOpenConfig.Height));
        }

        //------------------------------------------------------------------
        private void m_btnSaveConfig_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (m_strNomFichierEnCours.Length > 0)
                    SaveConfig(m_strNomFichierEnCours);
                else
                    SaveConfigAs();
            }
            if (e.Button == MouseButtons.Left)
            {
                m_menuSaveConfig.Show(m_btnSaveConfig, new Point(0, m_btnSaveConfig.Height));
            }
        }

        //------------------------------------------------------------------
        public CConfigFenetrePlanification Config
        {
            get
            {
                CConfigFenetrePlanification config = new CConfigFenetrePlanification();
                config.NomFichier = m_strNomFichierEnCours;
                config.DateDebut = m_controlePlanning.DateDebut;
                config.DateFin = m_controlePlanning.DateFin;

                List<int> lstIds = new List<int>();
                foreach (IElementAIntervention elt in m_controlePlanning.BaseAffichee.ElementsAIntervention)
                {
                    if (elt is CSite)
                        lstIds.Add(elt.Id);
                }
                config.IdsSitesVisibles = lstIds.ToArray();

                List<int> lstIdsRessources = new List<int>();
                List<int> lstIdsActeurs = new List<int>();
                foreach (IRessourceEntreePlanning res in m_controlePlanning.BaseAffichee.Ressources)
                {
                    if (res is CActeur)
                        lstIdsActeurs.Add(res.Id);

                    if (res is CRessourceMaterielle)
                        lstIdsRessources.Add(res.Id);
                }
                config.IdsRessourcesVisibles = lstIdsRessources.ToArray();
                config.IdsActeursVisibles = lstIdsActeurs.ToArray();

                config.NonAffectesOnly = m_chkIntersNonAffectées.Checked;
                config.NonPlanifiesOnly = m_chkIntersNonPlanifiées.Checked;

                if (m_chkIntersSurListe.Checked && m_listeEntitesSelectionnee != null)
                    config.IdListeFiltreInters = m_listeEntitesSelectionnee.Id;
                if (m_chkIntersFiltre.Checked && m_filtreDynamicApplique != null)
                {
                    config.FiltreDynamiqueInters = m_filtreDynamicApplique;
                    config.LibelleFiltreInters = m_chkIntersFiltre.Text;
                }
                return config;
            }
            set
            {
                if (value != null)
                {
                    m_bPreventFromFillListeInters = true;
                    IBasePlanning b = m_controlePlanning.BaseAffichee;
                    b.ClearElementsAIntervention();
                    b.ClearRessources();
                    foreach (int nIdSite in value.IdsSitesVisibles)
                    {
                        CSite site = new CSite(m_contexteDonnee);
                        if (site.ReadIfExists(nIdSite))
                            b.AddElementAIntervention(site);
                    }

                    foreach (int nIdActeur in value.IdsActeursVisibles)
                    {
                        CActeur acteur = new CActeur(m_contexteDonnee);
                        if (acteur.ReadIfExists(nIdActeur))
                            b.AddRessource(acteur);
                    }
                    foreach (int nIdressource in value.IdsRessourcesVisibles)
                    {
                        CRessourceMaterielle res = new CRessourceMaterielle(m_contexteDonnee);
                        if (res.ReadIfExists(nIdressource))
                            b.AddRessource(res);
                    }
                    m_filtreDynamicApplique = value.FiltreDynamiqueInters;
                    if (value.LibelleFiltreInters.Length > 0)
                        m_chkIntersFiltre.Text = value.LibelleFiltreInters;
                    if (m_filtreDynamicApplique != null)
                        m_lastFiltreDynamique = m_filtreDynamicApplique;
                    m_chkIntersFiltre.Checked = m_filtreDynamicApplique != null;

                    if (value.IdListeFiltreInters != null)
                    {
                        CListeEntites lst = new CListeEntites(m_contexteDonnee);
                        if (lst.ReadIfExists(value.IdListeFiltreInters.Value))
                            SetListeFiltreInters(lst);
                    }
                    else
                        m_chkIntersSurListe.Checked = false;


                    m_chkIntersNonAffectées.Checked = value.NonAffectesOnly;
                    m_chkIntersNonPlanifiées.Checked = value.NonPlanifiesOnly;
                    m_bPreventFromFillListeInters = false;
                    m_controlePlanning.DateDebut = value.DateDebut;
                    m_controlePlanning.DateFin = value.DateFin;
                    FillListeIntersAvecDelai();
                    m_controlePlanning.Refresh();
                }
            }
        }




        //------------------------------------------------------------------
        private void m_menuOpenConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("Planning configuration|*.futPln|All files|*.*|20670");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadConfig(dlg.FileName);
            }
        }

        //------------------------------------------------------------------
        private string m_strNomFichierEnCours = "";
        private void LoadConfig(string strNomFicher)
        {
            CConfigFenetrePlanification config = new CConfigFenetrePlanification();
            CResultAErreur result = config.ReadFile(strNomFicher);
            if (!result)
            {
                CTimosAppRegistre.RemoveRecentConfigPlanning(strNomFicher);
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                Config = config;
                CTimosAppRegistre.AddRecentConfigPlanning(strNomFicher);
                m_strNomFichierEnCours = strNomFicher;
            }
        }

        //------------------------------------------------------------------
        private void m_menuSaveConfigDirect_Click(object sender, EventArgs e)
        {
            if (m_strNomFichierEnCours != "")
                SaveConfig(m_strNomFichierEnCours);
            else
                SaveConfigAs();
        }

        //------------------------------------------------------------------
        private void m_menuSaveConfigAs_Click(object sender, EventArgs e)
        {
            SaveConfigAs();
        }

        //------------------------------------------------------------------
        private void SaveConfig(string strNomFichier)
        {
            CConfigFenetrePlanification config = Config;
            config.NomFichier = strNomFichier;
            CResultAErreur result = config.SaveFile(strNomFichier);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                m_strNomFichierEnCours = strNomFichier;
                CTimosAppRegistre.AddRecentConfigPlanning(strNomFichier);
            }
        }

        //------------------------------------------------------------------
        private void SaveConfigAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = I.T("Planning configuration|*.futPln|All files|*.*|20670");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveConfig(dlg.FileName);
            }
        }

        //------------------------------------------------------------------
        private void m_menuLoadFile_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripItem item in new ArrayList(m_menuLoadFile.Items))
            {
                if (item != m_menuOpenConfig)
                    m_menuLoadFile.Items.Remove(item);
            }
            string[] strRecents = CTimosAppRegistre.GetRecentsConfigPlanning();
            if (strRecents.Length > 0)
            {
                m_menuLoadFile.Items.Add(new ToolStripSeparator());
                foreach (string strRecent in strRecents)
                {
                    ToolStripMenuItem itemOpenFile = new ToolStripMenuItem(CUtilTexte.TronqueLeMilieu(strRecent, 40));
                    itemOpenFile.Tag = strRecent;
                    m_menuLoadFile.Items.Add(itemOpenFile);
                    itemOpenFile.Click += new EventHandler(itemOpenFile_Click);
                }
            }
        }

        //----------------------------------------------------------------
        private void itemOpenFile_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string strFichier = item != null ? item.Tag as string : null;
            if (strFichier != null)
                LoadConfig(strFichier);
        }

        //----------------------------------------------------------------
        private void m_menuSaveConfig_Opening(object sender, CancelEventArgs e)
        {
            m_menuSaveConfigDirect.Text = I.T("Save|20668") + " " + CUtilTexte.TronqueLeMilieu(m_strNomFichierEnCours, 40);
        }
    }
}
