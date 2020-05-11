using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;

using timos.acteurs;
using timos.securite;

using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.process;
using System.Collections.Generic;
using System.Threading;


namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CMessageSMSServeur.
	/// </summary>
    [AutoExec("Autoexec", AutoExecAttribute.BackGroundService)]
	public class CMessageSMSServeur : CObjetServeur
	{
        private static int c_nDelaiEnvoi = 1000*30;//Toutes les 30 secondes
        private static Timer m_timer = null;
        private static CSessionClient m_sessionRecherche = null;
#if PDA
		public CMessageSMSServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CMessageSMSServeur( int nIdSession )
			:base(nIdSession)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            m_timer = new Timer(new TimerCallback(OnSendSMS), null, c_nDelaiEnvoi, 1000*60);
            C2iEventLog.WriteInfo(I.T("SMS service started|20158"));
        }


		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CMessageSMS.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CMessageSMS MessageSMS = (CMessageSMS)objet;
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CMessageSMS);
		}

        //-------------------------------------------------------------------
        //-------------------------------------------------------------------
        private static bool m_bTraitementEnCours = false;
        private static void OnSendSMS(object state)
        {
            if (m_bTraitementEnCours)
                return;
            m_bTraitementEnCours = true;
            
            try
            {
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
                CResultAErreur result;
                if (m_sessionRecherche == null || !m_sessionRecherche.IsConnected)
                {
                    m_sessionRecherche = CSessionClient.CreateInstance();
                    result = m_sessionRecherche.OpenSession(new CAuthentificationSessionServer(),
                        I.T("SMS SERVICE|20159"),
                        ETypeApplicationCliente.Service);
                    if (!result)
                    {
                        C2iEventLog.WriteErreur(I.T("Session Opening error for SMS Service|20160"));
                        return;
                    }
                }
                try
                {
                    CFiltreData filtre = new CFiltreData(CMessageSMS.c_champNextSendDate + " < @1 and " +
                        CMessageSMS.c_champDateEnvoi+" is null and "+
                        CMessageSMS.c_champNbEssais +" < 10",
                        DateTime.Now
                        );
                    if (new CMessageSMSServeur(m_sessionRecherche.IdSession).CountRecords(
                        CMessageSMS.c_nomTable, filtre) > 0)
                    {
                        CSessionClient sessionTravail = new CSessionProcessServeurSuivi();
                        result = sessionTravail.OpenSession(new CAuthentificationSessionProcess(),
                            I.T("Send SMS|20161"),
                            ETypeApplicationCliente.Service);
                        if (!result)
                        {
                            C2iEventLog.WriteErreur(I.T("Working session openning error for SMS send|20162"));
                            return;
                        }
                        try
                        {
                            using (CContexteDonnee contexteTravail = new CContexteDonnee(sessionTravail.IdSession, true, false))
                            {
                                CMessageSMSServeur serveur = new CMessageSMSServeur(sessionTravail.IdSession);
                                CListeObjetsDonnees liste = new CListeObjetsDonnees(contexteTravail, typeof(CMessageSMS));
                                liste.Filtre = filtre;
                                ArrayList lstLock = liste.ToArrayList();

                                foreach (CMessageSMS message in lstLock)
                                {
                                    CMessageSMSPourEnvoi toSend = new CMessageSMSPourEnvoi(message.Destinataires, message.Texte);
                                    result = toSend.Send(sessionTravail.IdSession);
                                    message.BeginEdit();
                                    if (!result)
                                    {
                                        message.NextSendDate = DateTime.Now.AddMinutes(3);
                                        message.NbEssais++;
                                        message.LastErreur = result.Erreur.ToString();

                                    }
                                    else
                                    {
                                        message.DateEnvoi = DateTime.Now;
                                        message.LastErreur = "";
                                    }
                                    message.CommitEdit();

                                    result.SetTrue();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            C2iEventLog.WriteErreur(I.T("Error while sendind SMS : @1|20163", e.ToString()));
                        }
                        finally
                        {
                            try
                            {
                                sessionTravail.CloseSession();
                            }
                            catch { }
                        }
                    }
                }
                catch (Exception e)
                {
                    C2iEventLog.WriteErreur(I.T("Error while sendind SMS : @1|20163", e.ToString()));
                }
            }
            catch (Exception e)
            {
                {
                    C2iEventLog.WriteErreur(I.T("Error while sendind SMS : @1|20163", e.ToString()));
                }
            }
            finally
            {
                m_bTraitementEnCours = false;
            }
        }	
		
		


	}
}
