using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using futurocom.snmp;
using System.Net;
using sc2i.common;

namespace futurocom.win32.snmp
{
    public partial class CFormSetupInterrogationSNMP : Form
    {
        CSnmpConnexion m_connexion = null;

        //-----------------------------------------------------------------------
        public CFormSetupInterrogationSNMP()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------
        private void CFormSetupInterrogationSNMP_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);

            foreach ( VersionCode code in Enum.GetValues ( typeof(VersionCode ) ))
            {
                m_cmbVersion.Items.Add ( code );
            }
            if (m_connexion == null)
                m_connexion = new CSnmpConnexion();
            if (m_connexion.EndPoint != null)
            {
                if (m_connexion.EndPoint.Address != null)
                    m_txtIP.Text = m_connexion.EndPoint.Address.ToString();
                m_txtPort.IntValue = m_connexion.EndPoint.Port;
            }
            m_cmbVersion.SelectedItem = m_connexion.Version;
            m_txtTimeout.IntValue = m_connexion.TimeOut;
            m_txtCommunaute.Text = m_connexion.Community;
        }

        //-----------------------------------------------------------------------
        public static bool EditeConnexion(ref CSnmpConnexion connexion)
        {
            CFormSetupInterrogationSNMP form = new CFormSetupInterrogationSNMP();
            form.m_connexion = connexion;
            bool bResult = form.ShowDialog() == DialogResult.OK;
            if (bResult)
                connexion = form.m_connexion;
            form.Dispose();

            return bResult;
        }

        //-----------------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            IPAddress adresse = null;
            try
            {
                adresse = IPAddress.Parse(m_txtIP.Text);
            }
            catch { }
            if (adresse == null)
            {
                MessageBox.Show(I.T("Invalid IP address|20037"));
                return;
            }
            if (m_txtPort.IntValue == null)
            {
                MessageBox.Show(I.T("Invalid port|20038"));
                return;
            }
            if (!(m_cmbVersion.SelectedItem is VersionCode))
            {
                MessageBox.Show(I.T("Invalid version|20039"));
                return;
            }
            if (m_txtTimeout.IntValue == null)
            {
                MessageBox.Show(I.T("Invalid timeout value|20040"));
                return;
            }
            if (m_connexion == null)
                m_connexion = new CSnmpConnexion();
            m_connexion.Community = m_txtCommunaute.Text;
            m_connexion.EndPoint = new IPEndPoint(adresse, m_txtPort.IntValue.Value);
            m_connexion.Version = (VersionCode)m_cmbVersion.SelectedItem;
            m_connexion.TimeOut = m_txtTimeout.IntValue.Value;
            m_connexion.Community = m_txtCommunaute.Text;
            DialogResult = DialogResult.OK;
            Close();                
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        

            
    }
}
