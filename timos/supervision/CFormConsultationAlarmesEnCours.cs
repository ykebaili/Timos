using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common.memorydb;
using futurocom.supervision.alarmes;
using sc2i.multitiers.client;
using sc2i.win32.navigation;
using futurocom.supervision;
using sc2i.expression;
using sc2i.common;
using sc2i.win32.common;
using timos.data.supervision;
using System.Threading;
using sc2i.documents;
using sc2i.data;
using timos.supervision.Masquage;

namespace timos.supervision
{
    public partial class CFormConsultationAlarmesEnCours : Form
    {
        CMemoryDb m_dataBase;
        CParametreAffichageListeAlarmes m_parametreAffichage;
        CRecepteurNotification m_recepteurNotifications = null;
        CFormNavigateur m_navigateur;
        Dictionary<string, Image> m_dicImages = new Dictionary<string, Image>();

        public CFormConsultationAlarmesEnCours()
        {
            InitializeComponent();

            m_recepteurNotifications = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CNotificationModificationsAlarme));
            m_recepteurNotifications.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotification);
        
        }

        //-----------------------------------------------------------------------------------
        void OnReceiveNotification(IDonneeNotification donnee)
        {
            CNotificationModificationsAlarme notification = donnee as CNotificationModificationsAlarme;
            if (notification == null)
                return;
            lock (typeof(CLockerNotificationAlarmes))
            {
                TraiteNotification(notification);
            }
        }
        
        //-----------------------------------------------------------------------------------
        private void TraiteNotification(CNotificationModificationsAlarme notification)
        {
            HashSet<string> tableAlarmeAvant = UpdateNombreAlarmesNonAcquittees();

            // Mise à jour des Alarmes
            CListeEntitesDeMemoryDb<CLocalAlarme> listeAlaremsMaj = new CListeEntitesDeMemoryDb<CLocalAlarme>(notification.MemoryDb);

            m_dataBase.AcceptChanges();
            foreach (CLocalAlarme alarmeAjoutModif in listeAlaremsMaj)
            {
                if (alarmeAjoutModif.Parent == null)
                {
                    CLocalAlarme alrm = m_dataBase.ImporteObjet(alarmeAjoutModif, true, true) as CLocalAlarme;
                    /*if (alrm != null)
                        alrm.Row.Row.SetModified();*/
                }
            }

            m_tableauAlarmesEnCours.UpdateDataBase(m_dataBase);
            m_tableauAlarmesRetombees.UpdateDataBase(m_dataBase);

            HashSet<string> tableAlarmeApres = UpdateNombreAlarmesNonAcquittees();

            bool bSonnerie = false;
            foreach (string strIdAlarme in tableAlarmeApres)
            {
                if (!tableAlarmeAvant.Contains(strIdAlarme))
                {
                    bSonnerie = true;
                    break;
                }
            }

            if (bSonnerie)
                StartSonnerie();
            else
                StopSonnerie();
            
        }

        //-------------------------------------------------------------------------------------
        private HashSet<string> UpdateNombreAlarmesNonAcquittees()
        {
            HashSet<string> tableIdAlarmes = new HashSet<string>();
            int nHashCode = 0;

            // Affiche le nombre d'Alarmes non aqcuittées
            if (m_dataBase != null)
            {
                CListeEntitesDeMemoryDb<CLocalTypeAlarme> listeTypesAlarme = new CListeEntitesDeMemoryDb<CLocalTypeAlarme>(m_dataBase);
                listeTypesAlarme.Filtre = new CFiltreMemoryDb(
                    CLocalTypeAlarme.c_champAAcquitter + " = @1",
                    true);
                List<string> lstIdString = new List<string>();
                foreach (CLocalTypeAlarme typeAlarme in listeTypesAlarme)
                    lstIdString.Add(typeAlarme.Id);
                string strListeIdTypes = string.Join(",", lstIdString.ToArray());

                CListeEntitesDeMemoryDb<CLocalAlarme> listeAlarmes = new CListeEntitesDeMemoryDb<CLocalAlarme>(m_dataBase);
                CFiltreMemoryDb filtre = new CFiltreMemoryDb(
                        CLocalAlarme.c_champIdParent + " is null and " +
                        CLocalAlarme.c_champDateFin + " is null and " +
                        CLocalAlarme.c_champDateAcquittement + " is null and " +
                        CLocalAlarme.c_champIdMasquageHerite + " is null");
                if (strListeIdTypes != "")
                    filtre = CFiltreMemoryDb.GetAndFiltre(filtre, new CFiltreMemoryDb(
                        CLocalTypeAlarme.c_champId + " in(" + strListeIdTypes + ")"));
                else
                    filtre = new CFiltreMemoryDBImpossible();
                listeAlarmes.Filtre = filtre;
                listeAlarmes.Sort = CLocalAlarme.c_champId;

                int nCompteur = listeAlarmes.Count();
                m_lblCompteurNouvellesAlarmes.Text = nCompteur.ToString();

                // Calcul du Hash Code
                StringBuilder sb = new StringBuilder();
                foreach (CLocalAlarme alarme in listeAlarmes)
                    tableIdAlarmes.Add(alarme.Id);
            }

            return tableIdAlarmes;

        }

        private int? m_nIdSonnerieEnCours = null;
        private CProxyGED m_proxySonnerie = null;
        //-------------------------------------------------------------------------------------
        private void StartSonnerie()
        {
            m_btnStopSonnerie.ImageIndex = 0;
            m_btnStopSonnerie.Enabled = true;

            string strFichier = "";
            if (m_proxySonnerie != null)
                strFichier = m_proxySonnerie.NomFichierLocal;
            
            int? nIdSonnerie = CSoundPlayer.StartSound(strFichier);
            if (nIdSonnerie != null)
                m_nIdSonnerieEnCours = nIdSonnerie;

        }

        //-------------------------------------------------------------------------------------
        private void StopSonnerie()
        {
            m_btnStopSonnerie.ImageIndex = 1;
            m_btnStopSonnerie.Enabled = false;
            
            if (m_nIdSonnerieEnCours != null)
                CSoundPlayer.StopSound(m_nIdSonnerieEnCours.Value);
            m_nIdSonnerieEnCours = null;

        }

        //-------------------------------------------------------------------------------------
        private void CFormConsultationAlarmesEnCours_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_chkAlwaysOnTop.Checked = this.TopMost;

            if (m_dataBase != null)
            {
                m_tableauAlarmesEnCours.Init(m_dataBase, m_parametreAffichage, m_dicImages, true);
                m_tableauAlarmesRetombees.Init(m_dataBase, m_parametreAffichage, m_dicImages, false);

                HashSet<string> tableIdsAlarmes = UpdateNombreAlarmesNonAcquittees();
                if (tableIdsAlarmes.Count > 0)
                    StartSonnerie();
                else
                    StopSonnerie();
            }
        }

        //-------------------------------------------------------------------------------------
        public static void AfficheAlarmes(CMemoryDb database, CParametrageAffichageListeAlarmes paramConsultation, CFormNavigateur nav)
        {
            CFormConsultationAlarmesEnCours form = new CFormConsultationAlarmesEnCours();

            form.Text = paramConsultation.Libelle; 
            form.m_dataBase = database;
            form.m_navigateur = nav;
            form.TopMost = false;
            CParametreAffichageListeAlarmes parametre = paramConsultation.ParametreAffichageAlarmes;            
            if (parametre == null)
                parametre = CParametreAffichageListeAlarmes.ParametreParDefaut;

            form.m_parametreAffichage = parametre;

            CDocumentGED docSonnerie = paramConsultation.DocumentFichierSon;
            if (docSonnerie != null && docSonnerie.ReferenceDoc != null)
            {
                CProxyGED proxySonnerie = new CProxyGED(paramConsultation.ContexteDonnee.IdSession, docSonnerie.ReferenceDoc);
                if (proxySonnerie.CopieFichierEnLocal())
                {
                    form.m_proxySonnerie = proxySonnerie;
                }
                else
                {
                    proxySonnerie.Dispose();
                    proxySonnerie = null;
                }
            }

            form.m_dicImages.Clear();
            CListeObjetsDonnees listTypesAlarmes = new CListeObjetsDonnees(paramConsultation.ContexteDonnee, typeof(CTypeAlarme));
            foreach (CTypeAlarme typeAlarme in listTypesAlarmes)
            {
                if (typeAlarme.Image != null)
                    form.m_dicImages.Add(typeAlarme.Id.ToString(), typeAlarme.Image);

            }
            
            form.Show();

        }

        private void m_chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = m_chkAlwaysOnTop.Checked;
            m_chkAlwaysOnTop.ImageIndex = m_chkAlwaysOnTop.Checked ? 1 : 0;
        }

        private void m_btnStopSonnerie_Click(object sender, EventArgs e)
        {
            StopSonnerie();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (CFormAlerte.Afficher(I.T("Are you sure you want to quit Alams Supervision Window ?|10262"), EFormAlerteType.Question) == DialogResult.No)
                e.Cancel = true;
            else
                StopSonnerie();

            base.OnClosing(e);
        }

        private CLocalCategorieMasquageAlarme m_lastCategorieMasquage = null;
        private void m_btnAficherMasque_Click(object sender, EventArgs e)
        {
            CListeEntitesDeMemoryDb<CLocalCategorieMasquageAlarme> listeCategoriesMask = new CListeEntitesDeMemoryDb<CLocalCategorieMasquageAlarme>(m_dataBase);
            listeCategoriesMask.Sort = CLocalCategorieMasquageAlarme.c_champPriorite;
            CFiltreMemoryDb filtre = GetFiltreMasquage(null);

            CFormSelectNiveauMasquagePopup form = new CFormSelectNiveauMasquagePopup();
            form.Init(listeCategoriesMask.ToArray(), m_lastCategorieMasquage);
            form.Left = MousePosition.X;
            form.Top = MousePosition.Y;
            DialogResult reponse = form.ShowDialog();
            switch (reponse)
            {
                case DialogResult.OK:
                    m_lastCategorieMasquage = form.ElementSelectionne;
                    filtre = GetFiltreMasquage(m_lastCategorieMasquage);
                    m_btnAficherMasque.Text = m_lastCategorieMasquage.Libelle;
                    break;
                case DialogResult.No:
                    m_lastCategorieMasquage = null;
                    filtre = GetFiltreMasquage(null);
                    m_btnAficherMasque.Text = I.T("Masked Alarms|10312");
                    break;
                case DialogResult.Cancel:
                    return;
                default:
                    return;
            }
            m_tableauAlarmesEnCours.FiltreAlarmes = filtre;
            m_tableauAlarmesRetombees.FiltreAlarmes = filtre;

        }

        private CFiltreMemoryDb GetFiltreMasquage(CLocalCategorieMasquageAlarme categorieNiveauMax)
        {
            CFiltreMemoryDb nouveauFiltre = null;

            if (categorieNiveauMax != null)
            {
                int nNiveau = categorieNiveauMax.Priorite;
                nouveauFiltre = new CFiltreMemoryDb(
                    CLocalAlarme.c_champIdMasquageHerite + " is null OR (" +
                    CLocalAlarme.c_champIdMasquageHerite + " is not null AND " +
                    CLocalAlarme.c_champNiveauMasquage + " <= @1)", nNiveau);
            }
            else
            {
                nouveauFiltre = new CFiltreMemoryDb(
                    CLocalAlarme.c_champIdMasquageHerite + " is null");

            }

            return nouveauFiltre;
        }
         

        
    }
}
