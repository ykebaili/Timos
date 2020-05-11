using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.easyquery;

using sc2i.common;
using sc2i.win32.common;
using futurocom.easyquery.snmp;
using futurocom.snmp;
using futurocom.snmp.dynamic;

namespace futurocom.win32.snmp
{
    public partial class CFormEditEasyQuery : Form
    {
        CEasyQuery m_query = null;
        public CFormEditEasyQuery()
        {
            InitializeComponent();
        }

        public static bool EditeQuery(CEasyQuery query)
        {
            CFormEditEasyQuery form = new CFormEditEasyQuery();
            CEasyQuery clone = CCloner2iSerializable.Clone(query) as CEasyQuery;
            foreach (CEasyQuerySource source in query.Sources)
            {
                clone.AddSource(source);
            }
            form.m_query = clone;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                bResult = true;
                CCloner2iSerializable.CopieTo(clone, query);
            }
            form.Dispose();
            return bResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CFormEditEasyQuery_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_txtLibelle.Text = m_query.Libelle;
            m_editeur.Init(m_query);
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            m_query.Libelle = m_txtLibelle.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_btnParametres_Click(object sender, EventArgs e)
        {
            SetupConnexion();
        }

        //----------------------------------
        private void SetupConnexion()
        {
            foreach (CEasyQuerySource source in m_query.Sources)
            {
                CSnmpConnexionForEasyQuery snmpFiller = source.Connexion as CSnmpConnexionForEasyQuery;
                if (snmpFiller != null)
                {
                    CInterrogateurSnmpSimplePourFiller agent = snmpFiller.Agent;
                    if (agent != null)
                    {
                        CSnmpConnexion cnx = agent.Connexion;
                        if (cnx == null)
                            cnx = new CSnmpConnexion();
                        if (CFormSetupInterrogationSNMP.EditeConnexion(ref cnx))
                            agent.Connexion = cnx;
                        break;
                    }
                }
            }

        }
    }
}
