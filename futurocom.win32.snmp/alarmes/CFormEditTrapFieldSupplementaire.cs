using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.alarme;
using sc2i.common;

namespace futurocom.win32.snmp
{
    public partial class CFormEditTrapFieldSupplementaire : Form
    {
        private CTrapFieldSupplementaire m_field = null;
        public CFormEditTrapFieldSupplementaire()
        {
            InitializeComponent();
        }

        public static bool EditeField(CTrapFieldSupplementaire field)
        {
            CFormEditTrapFieldSupplementaire form = new CFormEditTrapFieldSupplementaire();
            form.m_field = field;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                bResult = true;
            }
            form.Dispose();
            return bResult;
        }

        //------------------------------------------------------------
        private void CFormEditTrapField_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_txtName.Text = m_field.Name;
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_txtName.Text.Length == 0)
            {
                MessageBox.Show(I.T("Please enter a field name|20065"));
                return;
            }
           
            m_field.Name = m_txtName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }




    }
}
