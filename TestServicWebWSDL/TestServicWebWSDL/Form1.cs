using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using TestServicWebWSDL.SM9_ChangeWS;
using System.Net;
using System.ServiceModel;
using TestServicWebWSDL.WebReference;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace TestServicWebWSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void m_btnConnexion_Click(object sender, EventArgs e)
        {
            string strURL = m_txtURL.Text;
            string strUser = m_txtUser.Text;
            string strMdp = m_txtMdp.Text;

            request_serv_change client = new request_serv_change();
            client.Url = strURL;
            client.Credentials = new NetworkCredential(strUser, strMdp);
            client.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Default;
            //WebReference.MySebService myWebService = new WebReference.MySebService();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //bool result = client.TestConnection();

            try
            {
                Retrieverequest_changeListRequest requete = new Retrieverequest_changeListRequest();
                requete.attachmentInfo = false;
                requete.attachmentData = false;
                requete.ignoreEmptyElements = true;
                                
                Retrieverequest_changeListResponse reponse = client.Retrieverequest_changeList(null);
                m_txtReponse.Text = reponse.ToString();
            }
            catch (Exception ex)
            {
                m_txtReponse.Text = ex.Message;
            }
            
        }

        public  void VerifieCertificat(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

        }

        private void m_btnChangeKeys_Click(object sender, EventArgs e)
        {
            string strURL = m_txtURL.Text;
            string strUser = m_txtUser.Text;
            string strMdp = m_txtMdp.Text;

            try
            {
                request_serv_change client = new request_serv_change();
                client.Url = strURL;
                client.Credentials = new NetworkCredential(strUser, strMdp);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                Retrieverequest_changeKeysListResponse reponse = client.Retrieverequest_changeKeysList(new Retrieverequest_changeKeysListRequest());
                m_txtReponse.Text = reponse.ToString();
            }
            catch (Exception ex)
            {
                m_txtReponse.Text = ex.Message;
            }
        }

        private void m_btnChange_Click(object sender, EventArgs e)
        {
            string strURL = m_txtURL.Text;
            string strUser = m_txtUser.Text;
            string strMdp = m_txtMdp.Text;

            try
            {
                request_serv_change client = new request_serv_change();
                client.Url = strURL;
                client.Credentials = new NetworkCredential(strUser, strMdp);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                Retrieverequest_changeResponse reponse = client.Retrieverequest_change(new Retrieverequest_changeRequest());
                m_txtReponse.Text = reponse.ToString();
            }
            catch (Exception ex)
            {
                m_txtReponse.Text = ex.Message;
            }

        }
    }
}
