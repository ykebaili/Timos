using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using spv.data.ConsultationAlarmes;
using spv.data;
using sc2i.common;
using sc2i.data;
using sc2i.expression;
using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.win32.navigation;
using sc2i.documents;


namespace spv.win32
{
    public partial class CFormListeAlarmeEnCours : Form
    {
        private CConsultationAlarmesEnCoursInDb m_consultationEnCours;

        CRecepteurNotification m_recepteurNotifications = null;
      /*  CRecepteurNotification m_recepteurNotificationsStop = null;
        CRecepteurNotification m_recepteurNotificationsMask = null;
        CRecepteurNotification m_recepteurNotificationsAcknowledge = null;*/

        private int m_NbMaskAdm = 0;
        private int m_NbMaskBrig = 0;
        private int m_NbAlFreq = 0;
        private int m_NbMasqCreat = 0;
        private int m_TotalAlarmes = 0;
        private bool m_VoyantEnCours = false;
        private string m_strFrequentButtonText;
        private string m_strMaskAdminButtonText;
        private string m_strMaskBrigButtonText;
        private CFormNavigateur m_navigateur = null;

        private  Color m_colorNonAcquitee = Color.Red;
        private  Color m_colorAcquitee = Color.Black;

        private bool m_bIsClignote = false;

        private int? m_nIdSonnerieEnCours = null;

        private CProxyGED m_proxySonnerie = null;

        public CFormListeAlarmeEnCours(CConsultationAlarmesEnCoursInDb consultation, CFormNavigateur navigateur)
        {
            c_nBaseControleRetombee = 15000 / c_nTimeClignote;

            List<string> strNomColonnes;
            string st;
            TimeSpan duree;
            DateTime start, stop;
            
            m_consultationEnCours = consultation;
            
            m_navigateur = navigateur;

            start = DateTime.Now;

            InitializeComponent();
            
            this.Text = consultation.Libelle;
            m_timerVoyant.Enabled = true;

            stop = DateTime.Now;
            duree = stop - start; //test duree = 8 sec !!!!!!!      

            m_recepteurNotifications = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmes));
            m_recepteurNotifications.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationAlarmEnCours);

         /*   m_recepteurNotificationsStop = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesStop));
            m_recepteurNotificationsStop.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationStop);

            m_recepteurNotificationsMask = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesMask));
            m_recepteurNotificationsMask.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationMask);

            m_recepteurNotificationsAcknowledge = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesAcknowledge));
            m_recepteurNotificationsAcknowledge.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationAcknowledge);*/

            
            List<CInfoAlarmeAffichee> lstEnCours = new List<CInfoAlarmeAffichee>();
            List<CInfoAlarmeAffichee> lstRetombe = new List<CInfoAlarmeAffichee>();

            m_lstViewEnCours.OnGetDonneesObjet += new GetDonneesLigneEventHandler(GetDonneesObjetEnCours);
            m_lstViewRetombe.OnGetDonneesObjet += new GetDonneesLigneEventHandler(GetDonneesObjetRetombe);

            m_lstViewEnCours.DoubleClick += new EventHandler(OnLstViewEnCoursDoubleClick);
            m_lstViewRetombe.DoubleClick += new EventHandler(OnLstViewRetombeDoubleClick);

            lstEnCours = GetAlarmsInfoFromDB();
            
            strNomColonnes = m_consultationEnCours.Parametres.GetColumnNames();

            m_lstViewEnCours.Init(strNomColonnes.ToArray(), lstEnCours.ToArray());

            st=I.T("End date|60023");
            strNomColonnes.Add(st);
            st = I.T("Duration|60022");
            strNomColonnes.Add(st);
            m_lstViewRetombe.Init((string[])strNomColonnes.ToArray(), lstRetombe.ToArray());

            m_strMaskAdminButtonText = I.T("Alarms masked by Administrator|60016") + " : ";
            m_strMaskBrigButtonText = I.T("Alarms masked by Operating agent|60017") + " : ";
            m_strFrequentButtonText = I.T("Current frequent alarms|60018") + " : ";

            InitButtonsInfo();

            MAJFrequentButtonText();
            MAJAdminButtonText();
            MAJBrigButtonText();

            m_btnMaskedOnCreation.Text = I.T("Alarms masked on creation|60047")+ " : " + m_NbMasqCreat.ToString();

            label1.Text = I.T("Current alarms|60014");
            label2.Text = I.T("Cleared alarms|60015");

            CDocumentGED docSonnerie = consultation.DocumentGEDSoundFile;
            if (docSonnerie != null && docSonnerie.ReferenceDoc != null)
            {
                m_proxySonnerie = new CProxyGED(consultation.ContexteDonnee.IdSession, docSonnerie.ReferenceDoc);
                if (!m_proxySonnerie.CopieFichierEnLocal())
                {
                    m_proxySonnerie.Dispose();
                    m_proxySonnerie = null;
                }
            }

            //SetVoyantAlarme();
            Type tpVar = GetType();

            Type tpGeneric = typeof(List<>);
            tpGeneric = tpGeneric.MakeGenericType(tpVar);

            object liste = Activator.CreateInstance(tpGeneric);

            
        }

        //-----------------------------------------------------------------------
        public List<CInfoAlarmeAffichee> GetAlarmsInfoFromDB()
        {
           List<CInfoAlarmeAffichee> lstInfoAlarmeAffichee = new List<CInfoAlarmeAffichee>();

           CListeObjetsDonnees lstAlarmes = new CListeObjetsDonnees(m_consultationEnCours.ContexteDonnee, typeof(CSpvAlarmeDonnee));

            //string clauseWhere = "HasNo( AlarmEnd." + CSpvAlarm.c_champALARM_ID + " )";  
            /*
            string clauseWhere = "Has( LienAccesAlarmeRep." +  CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID +
                " ) and LienAccesAlarmeRep.LienAccesAlarmes." + CSpvLienAccesAlarme.c_champCOMMUT +
                " = 0 and HasNo( AlarmeMasquee." + CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID + " )";*/
            /*
            string clauseWhere = "Has( LienAccesAlarmeRep." + CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID +
                " ) and LienAccesAlarmeRep.LienAccesAlarmes." + CSpvLienAccesAlarme.c_champCOMMUT +
                " = 0 and HasNo( SpvAlarme.AlarmeMasquee." + CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID + " )";
            */
           string clauseWhere = "Has( LienAccesAlarmeRep." + CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID +
               " ) and LienAccesAlarmeRep.LienAccesAlarmes." + CSpvLienAccesAlarme.c_champCOMMUT +
               " = 0 and HasNo( AlarmeMasquee." + CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID + " )";
            lstAlarmes.Filtre = new CFiltreDataAvance(CSpvAlarmeDonnee.c_nomTable, clauseWhere);
            
            //DateTime dateNow = DateTime.Now;
            DateTime dateNow = CDivers.GetSysdateNotNull();

            foreach (CSpvAlarmeDonnee alarme in lstAlarmes)
            {
         //       DateTime MaskBriDateMin = (DateTime)alarm.GetFirstAccesAccescRep().LienAccesAlarmes.MaskBriDateMin;
         //       DateTime MaskBriDateMax = (DateTime)alarm.GetFirstAccesAccescRep().LienAccesAlarmes.MaskBriDateMax;

                if (alarme.GetFirstAccesAccescRep().LienAccesAlarmes.MaskAdminDateMin <= dateNow &&
                    alarme.GetFirstAccesAccescRep().LienAccesAlarmes.MaskAdminDateMax >= dateNow)
                    continue;
                if (alarme.GetFirstAccesAccescRep().LienAccesAlarmes.MaskBriDateMin <= dateNow &&
                    alarme.GetFirstAccesAccescRep().LienAccesAlarmes.MaskBriDateMax >= dateNow)
                    continue;

                CInfoAlarmeAffichee infoAlarm = new CInfoAlarmeAffichee(alarme);
                
                if (m_consultationEnCours.Parametres.FormuleFiltre != null)
                {
                    CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(infoAlarm);
                    CResultAErreur result = m_consultationEnCours.Parametres.FormuleFiltre.Eval(contexte);
                    if (!Convert.ToBoolean(result.Data))
                        continue;
                }
                lstInfoAlarmeAffichee.Add(infoAlarm);
            }

            lstInfoAlarmeAffichee.Sort(new CTrieurInfoAlarmeAffichee(CSpvWin32Registre.TriConsultationAlarmeCroissant));
            return lstInfoAlarmeAffichee;
        }


        void GetDonneesObjetEnCours(object obj, ref object[] datas)
        {
            ArrayList lstData = m_consultationEnCours.Parametres.GetDataToDisplay((CInfoAlarmeAffichee)obj);
            datas = lstData.ToArray(); 
        }


        void GetDonneesObjetRetombe(object obj, ref object[] datas)
        {
            ArrayList lstData = m_consultationEnCours.Parametres.GetDataToDisplay((CInfoAlarmeAffichee)obj);
            lstData.Add(((CInfoAlarmeAffichee)obj).DateFin);
            lstData.Add(((CInfoAlarmeAffichee)obj).Duree);
            datas = lstData.ToArray();                       
        }

        private void m_btnMaskAdmin_Click(object sender, EventArgs e)
        {
            CFormListeAcces_AccescMasqueAdmin form = new CFormListeAcces_AccescMasqueAdmin(GetAccesAccescMaskAdmin());
            m_navigateur.AffichePage(form);
        }

        //-----------------------------------------------------------------------
        public CListeObjetsDonnees GetAccesAccescMaskAdmin()
        {
            CListeObjetsDonnees lst = CSpvLienAccesAlarme.ListeLienAccesMasqueAdmin(m_consultationEnCours.ContexteDonnee);
            
            lst.Tri = CSpvLienAccesAlarme.c_champMSKADM_MIN + " asc";

            return lst;
        }

        private void m_btnMaskBri_Click(object sender, EventArgs e)
        {
            CFormListeAcces_AccescMasqueBri form = new CFormListeAcces_AccescMasqueBri(GetAccesAccescMaskBrig());
            m_navigateur.AffichePage(form);
        }

        //-----------------------------------------------------------------------
        public CListeObjetsDonnees GetAccesAccescMaskBrig()
        {
            CListeObjetsDonnees lst = CSpvLienAccesAlarme.ListeLienAccesMasqueBriq(m_consultationEnCours.ContexteDonnee);
            
            lst.Tri = CSpvLienAccesAlarme.c_champMSKBRI_MIN + " asc";

            return lst;
        }

        private void m_btnFrequente_Click(object sender, EventArgs e)
        {
            CFormListeAlarms form = new CFormListeAlarms(GetFrequentAlarms());
            m_navigateur.AffichePage(form);
        }

        public CListeObjetsDonnees GetFrequentAlarms()
        {
            CListeObjetsDonnees lst = CSpvAlarmeDonnee.ListCurrentFrequentAlarms(m_consultationEnCours.ContexteDonnee);

            lst.Tri = CSpvAlarmeDonnee.c_champALARMEDONNEE_SECDEBUT + " asc";

            return lst;
        }

        private void m_btnMaskedOnCreation_Click(object sender, EventArgs e)
        {
            CFormListeAcces_AccescMasqueAdmin form = new CFormListeAcces_AccescMasqueAdmin(GetAccesAccescMaskedOnCreation());
            m_navigateur.AffichePage(form);
        }

        //-----------------------------------------------------------------------
        public CListeObjetsDonnees GetAccesAccescMaskedOnCreation()
        {            
            CListeObjetsDonnees lst = CSpvLienAccesAlarme.ListeLienAccesMasqueACreation(m_consultationEnCours.ContexteDonnee);
                        
            lst.Tri = CSpvLienAccesAlarme.c_champMSKADM_MIN + " asc";

            return lst;
        }


        void OnReceiveNotificationAlarmEnCours(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmes donneeAlarme = donnee as CDonneeNotificationAlarmes;
            if (donneeAlarme == null)
                return;
            CEvenementAlarm[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarm evAl in lstAlarmes)
            {
                if (evAl is CEvenementAlarmStartStop)
                {
                    CEvenementAlarmStartStop evAlarme = (CEvenementAlarmStartStop)evAl;

                    if (IsFrequentAlarm(evAlarme))
                    {
                        MAJFrequentButtonText();
                        continue;
                    }

                    CInfoAlarmeAffichee infoAlarm = new CInfoAlarmeAffichee(evAlarme);
                    if (m_consultationEnCours.Parametres.FormuleFiltre != null)
                    {
                        CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(infoAlarm);
                        CResultAErreur result = m_consultationEnCours.Parametres.FormuleFiltre.Eval(contexte);
                        if (!Convert.ToBoolean(result.Data))
                            continue;
                    }

                    if (evAlarme.Gravite == EGraviteAlarmeAvecMasquage.EndAlarm
                        && evAlarme.IdAlarmeDebut > 0)
                    {
                        for (int i = 0; i < m_lstViewEnCours.GetCount(); i++)
                        {
                            infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours.GetObjectFromList(i);
                            if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == evAlarme.IdAlarmeDebut)
                            {
                                if (m_consultationEnCours.Parametres.DelaiMasquageTerminnees > 0)
                                    infoAlarm.DateEffacement = DateTime.Now.AddMinutes(m_consultationEnCours.Parametres.DelaiMasquageTerminnees);

                                m_lstViewEnCours.RemoveObjet(infoAlarm);
                                infoAlarm.DateFin = evAlarme.DateEvenementAlarme;
                                m_lstViewRetombe.AddObject(infoAlarm, CSpvWin32Registre.TriConsultationAlarmeCroissant);
                                break;
                            }
                        }
                    }
                    else
                    {
                        m_lstViewEnCours.AddObject(new CInfoAlarmeAffichee (evAlarme),
                                                    CSpvWin32Registre.TriConsultationAlarmeCroissant);
                        SetVoyantAlarme();
                    }
                }
                else if (evAl is CEvenementAlarmMasqueeParUneAutre)
                {
                    for (int i = 0; i < m_lstViewEnCours.GetCount(); i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours.GetObjectFromList(i);
                        
                        if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == 
                            ((CEvenementAlarmMasqueeParUneAutre)evAl).AlarmStartId)
                        {
                            m_lstViewEnCours.RemoveObjet(infoAlarm);
                            //            infoAlarm.DateFin = evAlarme.EventAlarmRetombee.StopAlarmDate;
                            //            m_lstViewRetombe.AddObject(infoAlarm);
                            break;
                        }
                    }
                }
                else if (evAl is CEvenementAlarmMask)
                {
                    CEvenementAlarmMask evAlarme = (CEvenementAlarmMask)evAl;

                    if (evAlarme.NiveauMasquage != EMasquage.NonMasque)
                    {
                        if (evAlarme.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm++;
                        else
                            m_NbMaskBrig++;
                    }
                    else
                    {
                        if (evAlarme.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm--;
                        else
                            m_NbMaskBrig--;
                    }


                    MAJAdminButtonText();
                    MAJBrigButtonText();
                }
                else if (evAl is CEvenementAlarmAcknowledge)
                {
                    CEvenementAlarmAcknowledge evAlarme = (CEvenementAlarmAcknowledge)evAl;
                    if (evAlarme.IdAlarmeAcquittee == 0)    // Acquittement de liste
                    {
                        if (evAlarme.IdListeAlarmeAcquittee == m_consultationEnCours.Id) // Cette liste
                            TraiteAquitteAlarmes();
                    }
                    else
                    {       // Acquittement d'une alarme précise
                        bool bTrouve = false;
                        for (int i = 0; i < m_lstViewEnCours.GetCount(); i++)
                        {
                            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours.GetObjectFromList(i);
                            if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == evAlarme.IdAlarmeAcquittee)
                            {
                                infoAlarm.EstAcquittee = true;
                                bTrouve = true;
                                break;
                            }
                        }
                        if (!bTrouve)   // l'alarme doit être dans les retombées
                        {
                            for (int i = 0; i < m_lstViewRetombe.GetCount(); i++)
                            {
                                CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewRetombe.GetObjectFromList(i);
                                if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == evAlarme.IdAlarmeAcquittee)
                                {
                                    infoAlarm.EstAcquittee = true;
                                    if (m_consultationEnCours.Parametres.DelaiMasquageTerminnees > 0)
                                        infoAlarm.DateEffacement = DateTime.Now.AddMinutes(m_consultationEnCours.Parametres.DelaiMasquageTerminnees);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        void SetVoyantAlarme()
        {
            m_TotalAlarmes++;
            m_LabelCompteur.Text = m_TotalAlarmes.ToString();
            
            if (!m_bIsClignote)
                StartSonnerie();

            m_bIsClignote = true;
            ChangeVoyant();
        }

        void ResetVoyantAlarme()
        {
            m_TotalAlarmes = 0;
            m_LabelCompteur.Text = m_TotalAlarmes.ToString();
            m_bIsClignote = false;
            m_VoyantEnCours = false;
            m_btnAlarme.Image = spv.win32.Properties.Resources.IndicateurAlarmRepos;
        }

        void ChangeVoyant()
        {
            if (!m_VoyantEnCours)
                m_btnAlarme.Image = spv.win32.Properties.Resources.IndicateurAlarmEtat1;
            else
                m_btnAlarme.Image = spv.win32.Properties.Resources.IndicateurAlarmEtat2;

            m_VoyantEnCours = !m_VoyantEnCours;
        }

        /*
        bool IsFrequentAlarm(CInfoAlarmeAffichee infoAlarm)
        {
            if (infoAlarm.CodeAlarmeNature == (int)EAlarmNature.Frequente)
            {
                m_NbAlFreq++;
                return true;
            }
            else
                return false;
        }*/

        bool IsFrequentAlarm(CEvenementAlarmStartStop evAlarm)
        {
            if (evAlarm.NatureAlarme == EAlarmNature.Frequente)
            {
                m_NbAlFreq++;
                return true;
            }
            else
                return false;
        }
        
        void OnLstViewEnCoursDoubleClick(object sender, System.EventArgs e)
        {
            if (m_lstViewEnCours.SelectedIndices.Count > 0)
            {
                int index = m_lstViewEnCours.SelectedIndices[0];
                CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours.GetObjectFromList(index);
                ShowAlarmDlg(infoAlarm);
            }
        }

        void OnLstViewRetombeDoubleClick(object sender, System.EventArgs e)
        {
            int index = m_lstViewRetombe.SelectedIndices[0];

            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewRetombe.GetObjectFromList(index);
            ShowAlarmDlg(infoAlarm);
        }

        void ShowAlarmDlg(CInfoAlarmeAffichee alarmInfo)
        {
            CFormConsultationAlarmEvent alarmDlg = new CFormConsultationAlarmEvent(alarmInfo, m_consultationEnCours.ContexteDonnee);
            m_navigateur.AffichePage(alarmDlg);
        }

        private void MAJFrequentButtonText()
        {
            m_btnFrequente.Text = m_strFrequentButtonText + m_NbAlFreq.ToString();
        }
        
        private void MAJAdminButtonText()
        {
            m_NbMaskAdm = (m_NbMaskAdm < 0) ? 0 : m_NbMaskAdm;
            m_btnMaskAdmin.Text = m_strMaskAdminButtonText + m_NbMaskAdm.ToString();
        }

        private void MAJBrigButtonText()
        {
            m_NbMaskBrig = (m_NbMaskBrig < 0) ? 0 : m_NbMaskBrig;
            m_btnMaskBri.Text = m_strMaskBrigButtonText + m_NbMaskBrig.ToString();
        }

        private void InitButtonsInfo()
        {
            m_NbMasqCreat = CSpvLienAccesAlarme.ListeLienAccesMasqueACreation(m_consultationEnCours.ContexteDonnee).Count;
            m_NbMaskBrig = CSpvLienAccesAlarme.ListeLienAccesMasqueBriq(m_consultationEnCours.ContexteDonnee).Count;
            m_NbMaskAdm = CSpvLienAccesAlarme.ListeLienAccesMasqueAdmin(m_consultationEnCours.ContexteDonnee).Count;
            m_NbAlFreq = CSpvAlarmeDonnee.ListCurrentFrequentAlarms(m_consultationEnCours.ContexteDonnee).Count;            
        }


        /// <summary>
        /// Fait clignoter le voyant d'alarme lorsque c'est nécessaire et se charge
        /// de gérer la disparition des alarmes de la liste des retombées lorsqu'elles
        /// sont acquittées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_timerVoyant_Tick_1(object sender, EventArgs e)
        {
            if ( m_bIsClignote )
                ChangeVoyant();

            nNbTimeClignote += 1;

            // Traitement de l'effacement des alarmes retombées et acquittées
            if (nNbTimeClignote == c_nBaseControleRetombee)
            {
                nNbTimeClignote = 0;
                for (int i = m_lstViewRetombe.GetCount() - 1; i >= 0; i--)
                {
                    CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewRetombe.GetObjectFromList(i);
                    if (infoAlarm != null && infoAlarm.PeutElleDisparaitre())
                        m_lstViewRetombe.RemoveObjet(infoAlarm);
                }
            }
        }
        

        private void m_btnAlarme_Click(object sender, EventArgs e)
        {
            SetAcquitteAlarmes();
        }

        //Déclenchement de l'acquittement global des alarmes dans une liste
        private void SetAcquitteAlarmes()
        {
            //throw new Exception("The method or operation is not implemented.");
            /*
            CSpvAcquittement ack = new CSpvAcquittement (m_consultationEnCours.ContexteDonnee);
            ack.CreateNew();
            ack.ACK = true;
            ack.LISTALRM_ID = m_consultationEnCours.Id;
            //ResetVoyantAlarme();
            ack.CommitEdit();*/
            CSpvMessalrm spvMess = new CSpvMessalrm(m_consultationEnCours.ContexteDonnee);
            spvMess.CreateNew();
            spvMess.MessageAcquittementGlobalListeAlarme(m_consultationEnCours.Id);
            spvMess.CommitEdit();
        }

        // Traite l'acquittement global pour une liste d'alarmes en cours
        private void TraiteAquitteAlarmes()
        {
            ResetVoyantAlarme();
            StopSonnerie();
        }

        private void StartSonnerie()
        {
            string strFichier = "";
            if (m_proxySonnerie != null)
                strFichier = m_proxySonnerie.NomFichierLocal;

            int? nIdSonnerie = CSonneurDeSonnerieAlarme.StartSonnerie(strFichier);
            if (nIdSonnerie != null)
                m_nIdSonnerieEnCours = nIdSonnerie;
        }


        private void StopSonnerie()
        {
            if (m_nIdSonnerieEnCours != null)
                CSonneurDeSonnerieAlarme.StopSonnerie(m_nIdSonnerieEnCours.Value);
            m_nIdSonnerieEnCours = null;
        }

        private void CFormListeAlarmeEnCours_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopSonnerie();
        }
    }
}
