using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using System.Threading;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using spv.data;
using spv.data.ConsultationAlarmes;
using sc2i.data.serveur;
using spv.data.serveur;
using sc2i.expression;
using System.Collections;
using timos.process;

namespace spv.serveur
{
    [AutoExec("Autoexec")]
    public static class CEvenementAlarmMonitor
    {

        private static bool m_bAutoexecDejaFait = false;
        private const string m_strExpMailParDefaut = "monitor@timos";

        public static void Autoexec()
        {
            lock (typeof(CInfoAlarmeAffichee))
            {
                if (m_bAutoexecDejaFait)
                    return;
                m_bAutoexecDejaFait = true;
            }
            Thread th = new Thread(new ThreadStart(MonitorAlarmes));
            th.Start();
        }

        public delegate void SendMailsDelegate(List<CEvenementAlarm> lstEvents, CContexteDonnee ctxDonnee);

        public static void MonitorAlarmes()
        {
            int nCptWatchDogAlSyst = 0;
            Thread.Sleep(50000);
            CSessionClient session = CSessionClient.CreateInstance();
            session.OpenSession(new CAuthentificationSessionServer());

            while (true)
            {
                //Thread.Sleep(200);    // inhibition pour faciliter debug des autres objets
                //continue;
                nCptWatchDogAlSyst++;
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, true ))
                {
                    CListeObjetsDonnees lst = new CListeObjetsDonnees(ctx, typeof(CSpvMessalrm));
                    if (lst.Count > 0)
                    {
                        List<CEvenementAlarm> lstAlarm = new List<CEvenementAlarm>();
                        
                        StringBuilder bl = new StringBuilder();
                        foreach (CSpvMessalrm message in lst)
                        {
                            try
                            {
                                CEvenementAlarm eventAlarm = message.GetNewEvenementAlarm();
                                if (eventAlarm != null)
                                    lstAlarm.Add(eventAlarm);
                            }
                            catch (Exception e)
                            {
                                C2iEventLog.WriteErreur(e.Message);
                            }

                            bl.Append(message.Id);

                            bl.Append(',');
                        }
                        bl.Remove(bl.Length - 1,1);

                        if (lstAlarm.Count > 0)
                        {
                            CDonneeNotificationAlarmes notif = new CDonneeNotificationAlarmes(session.IdSession, lstAlarm);
                            CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notif });
                        }
                        
						SendMailsDelegate sndMail = new SendMailsDelegate(SendMails);
                        sndMail.BeginInvoke(lstAlarm, ctx, null, null);

                        IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(session.IdSession, CSpvServeur.c_spvConnection);
                        connexion.RunStatement("Delete from " + CSpvMessalrm.c_nomTableInDb+" where "+
                            CSpvMessalrm.c_champMESSALRM_ID+" in ("+bl.ToString()+")");
                       /* TimeSpan sp = DateTime.Now - dt;
                        double fTime = sp.TotalMilliseconds;*/
                    }//if (lst.Count > 0)

                    if (nCptWatchDogAlSyst >= 200)  // vérification toutes les 20 secondes
                    {
                        nCptWatchDogAlSyst = 0;
                        IDatabaseConnexion cnx = CSc2iDataServer.GetInstance().GetDatabaseConnexion(session.IdSession, CSpvServeur.c_spvConnection);
                        cnx.RunStatement("begin WatchDog; end;");
                    }
                }

                if (C2iStopApp.AppStopper.WaitOne(100, false))
                    break;
            }
        }

        
        public static void SendMails(List<CEvenementAlarm> lstEvents, CContexteDonnee ctxDonnee)
        {
            /*
            foreach (CEvenementAlarm eventAl in lstEvents)
            {
                if (eventAl.CategorieMessageAlarme == ECategorieMessageAlarme.AlarmStartStop)
                {
                    if (eventAl.EventAlarmStartStop.AlarmInfo.SeverityCode == (int)EGraviteAlarmeAvecMasquage.EndAlarm)
                        continue;

                    CListeObjetsDonnees lstConsult = new CListeObjetsDonnees(ctxDonnee, typeof(CConsultationAlarmesEnCoursInDb));
                    lstConsult.Filtre = new CFiltreDataAvance(CConsultationAlarmesEnCoursInDb.c_nomTable,
                         CConsultationAlarmesEnCoursInDb.c_champActiverEMail + " = 1 and Has( Emails." +
                         CParamlArmEC_EMail.c_champParamAlarmECId + " )", null);

                    foreach (CConsultationAlarmesEnCoursInDb consult in lstConsult)
                    {
                        int id = consult.Id;//test
                        if (consult.Parametres.FormuleFiltre != null)
                        {
                            CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(eventAl.EventAlarmStartStop.AlarmInfo);
                            if (!consult.Parametres.FormuleFiltre.Eval(contexte))
                                continue;
                        }

                        List<string> lstColumnNames = new List<string>();
                        ArrayList arrayData = new ArrayList();
                        StringBuilder stblMessage = new StringBuilder();
                        string [] arrayDest;                        
                        string stSubject;
                        string stSender;
                        string st;
                        int i = 0;

                        lstColumnNames = consult.Parametres.GetColumnNames();
                        arrayData = consult.Parametres.GetDataToDisplay(eventAl.EventAlarmStartStop.AlarmInfo);
                        
                        foreach(string stColumnName in lstColumnNames)
                        {
                            st = stColumnName + " : " + arrayData[i];
                            stblMessage.AppendLine(st);
                            i++;
                        }

                        stSubject = I.T("Alarm @1|60000", eventAl.EventAlarmStartStop.AlarmInfo.AlarmeGeree.Name);

                        arrayDest = new string[consult.Emails.Count];                        
                        i=0;
                        foreach(CParamlArmEC_EMail paramlArmEC_EMail in consult.Emails)
                        {
                            arrayDest[i] = paramlArmEC_EMail.Email;
                            i++;
                        }

                        IDatabaseRegistre registre = (IDatabaseRegistre)C2iFactory.GetNew2iObjetServeur(typeof(IDatabaseRegistre), ctxDonnee.IdSession);
				        stSender =  (string)registre.GetValeurString("SENDER_ADDRESS","");

                        int[] docsArray = new int[0];
                        CMailSC2I mail = new CMailSC2I(stSender, stSubject, stblMessage.ToString(),
                            arrayDest, docsArray);
                        
                        IExpediteurMail expediteur = (IExpediteurMail)C2iFactory.GetNewObjetForSession("CExpediteurMail", typeof(IExpediteurMail), ctxDonnee.IdSession);
                        CResultAErreur result = expediteur.SendMail(mail);
                    }
                }
            }
        }*/
            foreach (CEvenementAlarm eventAlarme in lstEvents)
            {
                if (eventAlarme.GetType() == typeof (CEvenementAlarmStartStop))
                {
                    CEvenementAlarmStartStop eventAl = (CEvenementAlarmStartStop)eventAlarme;
                    if (eventAl.Gravite == EGraviteAlarmeAvecMasquage.EndAlarm)
                        continue;

                    CInfoAlarmeAffichee infoAlarmeAffichee = new CInfoAlarmeAffichee(eventAl);

                    CListeObjetsDonnees lstConsult = new CListeObjetsDonnees(ctxDonnee, typeof(CConsultationAlarmesEnCoursInDb));
                    lstConsult.Filtre = new CFiltreDataAvance(CConsultationAlarmesEnCoursInDb.c_nomTable,
                         CConsultationAlarmesEnCoursInDb.c_champActiverEMail + " = 1 and Has( Emails." +
                         CParamlArmEC_EMail.c_champParamAlarmECId + " )", null);

                    foreach (CConsultationAlarmesEnCoursInDb consult in lstConsult)
                    {
                        int id = consult.Id;//test
                        if (consult.Parametres.FormuleFiltre != null)
                        {
                            CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(infoAlarmeAffichee);
                            if (!consult.Parametres.FormuleFiltre.Eval(contexte))
                                continue;
                        }

                        List<string> lstColumnNames = new List<string>();
                        ArrayList arrayData = new ArrayList();
                        StringBuilder stblMessage = new StringBuilder();
                        string[] arrayDest;
                        string stSubject;
                        string stSender;
                        string st;
                        int i = 0;

                        lstColumnNames = consult.Parametres.GetColumnNames();
                        arrayData = consult.Parametres.GetDataToDisplay(infoAlarmeAffichee);

                        foreach (string stColumnName in lstColumnNames)
                        {
                            st = stColumnName + " : " + arrayData[i];
                            stblMessage.AppendLine(st);
                            i++;
                        }

                        stSubject = I.T("Alarm @1|60000", eventAl.NomAlarmeGeree);

                        arrayDest = new string[consult.Emails.Count];
                        i = 0;
                        foreach (CParamlArmEC_EMail paramlArmEC_EMail in consult.Emails)
                        {
                            arrayDest[i] = paramlArmEC_EMail.Email;
                            i++;
                        }

                        IDatabaseRegistre registre = (IDatabaseRegistre)C2iFactory.GetNew2iObjetServeur(typeof(IDatabaseRegistre), ctxDonnee.IdSession);
                        stSender = (string)registre.GetValeurString("SENDER_ADDRESS", m_strExpMailParDefaut);

                        int[] docsArray = new int[0];
                        CMailSC2I mail = new CMailSC2I(stSender, stSubject, stblMessage.ToString(),
                            arrayDest, null, null, docsArray);

                        IExpediteurMail expediteur = (IExpediteurMail)C2iFactory.GetNewObjetForSession("CExpediteurMail", typeof(IExpediteurMail), ctxDonnee.IdSession);
                        CResultAErreur result = expediteur.SendMail(mail);
                    }
                }
            }
        }
    }
}
