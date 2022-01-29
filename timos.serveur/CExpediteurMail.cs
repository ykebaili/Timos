using System;
using System.Net.Mail;
using System.Collections;

using sc2i.common;
using sc2i.multitiers.server;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.documents;
using sc2i.data;
using timos.process;

using timos.data;
using System.Net;


namespace timos.serveur
{
    /// <summary>
    /// Description résumée de CExpediteurMail.
    /// </summary>
    public class CExpediteurMail : C2iObjetServeur, IExpediteurMail
    {
        /// ////////////////////////////////////////////////////////////////
        public CExpediteurMail(int nIdSession)
            : base(nIdSession)
        {
        }

        /// ////////////////////////////////////////////////////////////////
        public CResultAErreur SendMail(CMailSC2I mail)
        {
            CResultAErreur result = CResultAErreur.True;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(mail.Expediteur);
            message.Subject = mail.Sujet;
            message.Body = mail.Message;
            message.IsBodyHtml = mail.IsFormatHTML;
            // Destinataires To
            if (mail.Destinataires != null)
                foreach (string strDest in mail.Destinataires)
                    message.To.Add(new MailAddress(strDest));

            // Destinataires CC
            if (mail.DestinatairesCC != null)
                foreach (string strDest in mail.DestinatairesCC)
                    message.CC.Add(new MailAddress(strDest));

            // Destinataires BCC
            if (mail.DestinatairesBCC != null)
                foreach (string strDest in mail.DestinatairesBCC)
                    message.Bcc.Add(new MailAddress(strDest));


            ArrayList lstProxy = new ArrayList();
            using (CContexteDonnee contexte = new CContexteDonnee(IdSession, true, false))
            {
                foreach (int nIdDoc in mail.DocumentsGED)
                {

                    CDocumentGED doc = new CDocumentGED(contexte);
                    if (doc.ReadIfExists(nIdDoc) && doc.ReferenceDoc != null)
                    {
                        CProxyGED proxy = new CProxyGED(IdSession, doc.ReferenceDoc);
                        // Ajouter un paramètre optionnel CopieFichierEnLocal(doc.Libelle)
                        if (proxy.CopieFichierEnLocal(mail.UseDocLabelAsFileName ? doc.Libelle : ""))
                        {
                            lstProxy.Add(proxy);
                            Attachment att = new Attachment(proxy.NomFichierLocal);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }

            try
            {
                string strServeur = "";
                string strUser = "";
                string strPass = "";
                int nPort = 0;

                if (mail.SMTPServer != String.Empty)
                {
                    strServeur = mail.SMTPServer;
                    nPort = mail.SMTPPort;
                    strUser = mail.SMTPUser;
                    strPass = mail.SMTPPassword;
                }
                else
                {
                    strServeur = CTimosServeurRegistre.SMTPServer;
                    nPort = CTimosServeurRegistre.SMTPPort;
                    strUser = CTimosServeurRegistre.SMTPUser;
                    strPass = CTimosServeurRegistre.SMTPPassword;
                }

                using (SmtpClient clientSmtp = new SmtpClient())
                {
                    clientSmtp.Host = strServeur;
                    if (nPort > 0)
                    {
                        clientSmtp.Port = nPort;
                    }
                    if (strUser != "" || strPass != "")
                    {
                        clientSmtp.Credentials = new NetworkCredential(strUser, strPass);
                    }
                    else
                    {
                        clientSmtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    }
                    clientSmtp.Send(message);
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(e.ToString());
                result.EmpileErreur(I.T("Error while sending mail|30000"));
            }
            finally
            {
                message.Dispose();
            }
            foreach (CProxyGED proxy in lstProxy)
                proxy.Dispose();
            return result;
        }

    }
}
