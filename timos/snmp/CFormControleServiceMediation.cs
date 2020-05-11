using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.snmp.Proxy;
using sc2i.win32.common;
using sc2i.common;
using futurocom.snmp.mediation;
using futurocom.snmp;
using System.Net;
using sc2i.common.memorydb;
using sc2i.common.trace;
using futurocom.supervision;

namespace timos.snmp
{
    public partial class CFormControleServiceMediation : Form
    {
        private bool? m_bCurrentState = null;
        private CSnmpProxyInDb m_proxy = null;
        private CSnmpConnexion m_connexion = null;
        private CFuturocomTraceListenerAMessage m_listener = null;

        public CFormControleServiceMediation()
        {
            InitializeComponent();
        }

        private CSnmpConnexion GetConnexion()
        {
            if (m_connexion == null)
            {
                m_connexion = new CSnmpConnexion();
                m_connexion.EndPoint = new IPEndPoint(IPAddress.Parse(m_proxy.AdresseIp), m_proxy.Port);
            }
            return m_connexion;
        }


        //-------------------------------------------------------------
        public static void ShowMediationInfo(CSnmpProxyInDb proxy)
        {
            CFormControleServiceMediation frm = new CFormControleServiceMediation();
            frm.m_proxy = proxy;
            frm.Show();
        }

        private delegate void GetInfoMediationDelegate();
        //-------------------------------------------------------------
        private void CFormControleServiceMediation_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_lblProxyName.Text = m_proxy.Libelle;
            m_lblIP.Text = m_proxy.AdresseIp;

            m_lblEtatService.BackColor = Color.Yellow;
            m_lblEtatService.Text = I.T("Searching...|20324");
            m_bCurrentState = null;
            Invoke(new GetInfoMediationDelegate(GetEtatMediation));
        }

        //-------------------------------------------------------------
        private void GetEtatMediation()
        {

            CSnmpConnexion cnx = GetConnexion();
            m_timerUpdateEtatService.Stop();

            try
            {
                IServiceMediation service = cnx.ServiceMediation;
                m_bCurrentState = service.IsStarted;
                if (m_bCurrentState.Value)
                {
                    m_lblEtatService.BackColor = Color.LightGreen;
                    m_lblEtatService.ForeColor = Color.Black;
                    m_lblEtatService.Text = I.T("Started|20327");
                }
                else
                {
                    m_lblEtatService.BackColor = Color.Red;
                    m_lblEtatService.ForeColor = Color.Black;
                    m_lblEtatService.Text = I.T("Stopped|20328");
                }

            }
            catch (Exception ex)
            {
                m_errorProvider.SetError(m_lblEtatService,
                    I.T("Error while reaching service \n@1|20325", ex.ToString()));
                m_lblEtatService.BackColor = Color.DarkGray;
                m_lblEtatService.ForeColor = Color.White;
                m_lblEtatService.Text = I.T("Error|20326");
            }
            m_timerUpdateEtatService.Enabled = false;
            m_timerUpdateEtatService.Start();
        }

        private void GetDataMediation()
        {
            using (CWaitCursor waiter = new CWaitCursor())
            {
                CSnmpConnexion cnx = GetConnexion();
                try
                {
                    IServiceMediation service = cnx.ServiceMediation;
                    CConfigurationServiceMediation config = service.Configuration;
                    DataSet ds = config.DataBase;
                    m_dataGrid.DataSource = ds;
                }
                catch (Exception ex)
                {
                    CResultAErreur result = CResultAErreur.True;
                    result.EmpileErreur(new CErreurException(ex));
                    result.EmpileErreur(I.T("Error while reading configuration|20331"));
                    CFormAlerte.Afficher(result.Erreur);
                }
            }
        }

        private void m_lnkShowDataset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetDataMediation();
        }

        private void m_lblEtatService_Click(object sender, EventArgs e)
        {
            m_menuControl.Show(m_lblEtatService, new Point(0, m_lblEtatService.Height));

        }

        private void m_menuControl_Opening(object sender, CancelEventArgs e)
        {
            m_menuStart.Visible = m_bCurrentState != null && !m_bCurrentState.Value;
            m_menuStop.Visible = m_bCurrentState != null && m_bCurrentState.Value;
        }

        private void m_menuStart_Click(object sender, EventArgs e)
        {
            try
            {
                CSnmpConnexion cnx = GetConnexion();
                cnx.ServiceMediation.Start();
                GetEtatMediation();
            }
            catch (Exception ex)
            {
                CResultAErreur result = CResultAErreur.True;
                result.EmpileErreur(new CErreurException(ex));
                CFormAlerte.Afficher(result.Erreur);
            }
        }

        private void m_menuStop_Click(object sender, EventArgs e)
        {
            try
            {
                CSnmpConnexion cnx = GetConnexion();
                cnx.ServiceMediation.Stop();
                GetEtatMediation();
            }
            catch (Exception ex)
            {
                CResultAErreur result = CResultAErreur.True;
                result.EmpileErreur(new CErreurException(ex));
                CFormAlerte.Afficher(result.Erreur);
            }

        }

        //------------------------------------------------------------
        private void m_btnToogleDebug_Click(object sender, EventArgs e)
        {
            if (m_listener == null)
            {
                m_listener = new CFuturocomTraceListenerAMessage(ALTRACE.DEBUG, ALTRACE.TRACE, ALTRACE.POLLING);
                m_listener.OnTraceMessage += new OnTraceMessageEventHander(m_listener_OnTraceMessage);
                GetConnexion().AddTraceListener(m_listener);
                m_btnStopDebug.Enabled = true;
                m_btnStartDebug.Enabled = false;
            }
            
            
        }

        //------------------------------------------------------------
        private void OnTraceMessage(string strMessage, string[] strCategories)
        {
            ListViewItem itemVisible = null;
            if (m_wndListDebug.SelectedItems.Count == 1 &&
                m_wndListDebug.SelectedItems[0].Index != 0)
                itemVisible = m_wndListDebug.SelectedItems[0];
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
            item.SubItems.Add(strMessage);
            if (m_wndListDebug.Items.Count == 0)
                m_wndListDebug.Items.Add(item);
            else
                m_wndListDebug.Items.Insert(0, item);

            if (itemVisible != null)
                m_wndListDebug.EnsureVisible(itemVisible.Index + 1);
            else
            {
                m_wndListDebug.SelectedItems.Clear();
                m_wndListDebug.Items[0].Selected = true;
            }
        }

        //------------------------------------------------------------
        public void m_listener_OnTraceMessage(string strMessage, params string[] strCategories)
        {
            OnTraceMessageEventHander ha = new OnTraceMessageEventHander(OnTraceMessage);
            BeginInvoke(ha, strMessage, strCategories);
        }

        private void m_wndListDebug_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListDebug.SelectedItems.Count == 1)
                m_txtMessage.Text = m_wndListDebug.SelectedItems[0].SubItems[1].Text;
        }

        private void m_btnStopDebug_Click(object sender, EventArgs e)
        {
            if (m_listener != null)
            {
                GetConnexion().RemoveTraceListener(m_listener);
                m_listener.Dispose();
                m_listener = null;
                m_btnStopDebug.Enabled = false;
                m_btnStartDebug.Enabled = true;
            }
        }

        private void m_timerUpdateEtatService_Tick(object sender, EventArgs e)
        {
            GetEtatMediation();
        }

        private void m_btnClear_Click(object sender, EventArgs e)
        {
            m_wndListDebug.Items.Clear();
        }
    }
}
