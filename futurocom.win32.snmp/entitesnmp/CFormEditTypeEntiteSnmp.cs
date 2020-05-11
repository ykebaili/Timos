using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.alarme;
using sc2i.common;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CFormEditTypeEntiteSnmp : Form
    {
        public CFormEditTypeEntiteSnmp()
        {
            InitializeComponent();
        }

        public static bool EditeTypeEntite(CTypeEntiteSnmpPourSupervision typeEntite,
            CTypeAgentPourSupervision typeAgent)
        {
            CFormEditTypeEntiteSnmp form = new CFormEditTypeEntiteSnmp();
            CTypeEntiteSnmpPourSupervision typeEdite = CCloner2iSerializable.Clone(typeEntite) as CTypeEntiteSnmpPourSupervision;
            form.m_panelEdition.Init(typeEdite, typeAgent);
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                CCloner2iSerializable.CopieTo(typeEdite, typeEntite);
                bResult = true;
            }
            form.Dispose();
            return bResult;
        }

        private void CFormEditTypeEntiteSnmp_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

        //-------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result=  m_panelEdition.MajChamps();
            if ( !result )
            {
                CFormAlerte.Afficher ( result.Erreur);
                return ;
            }
            DialogResult = DialogResult.OK;
            Close();
                
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_panelEdition_Load(object sender, EventArgs e)
        {

        }
    }
}
