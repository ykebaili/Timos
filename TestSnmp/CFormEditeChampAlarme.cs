using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision;
using sc2i.expression;

namespace TestSnmp
{
    public partial class CFormEditeChampAlarme : Form
    {
        private IChampAlarme m_champ = null;
        public CFormEditeChampAlarme()
        {
            InitializeComponent();
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_txtNomChamp.Text == "")
            {
                MessageBox.Show("Indiquez le nom du champ");
                return;
            }
            ETypeChampBasique? type = m_cmbType.SelectedItem as ETypeChampBasique?;
            if (type == null)
            {
                MessageBox.Show("Et le type alors ?");
                return;
            }
            m_champ.TypeDonnee = type.Value;
            m_champ.NomChamp = m_txtNomChamp.Text;
            m_champ.IsKey = m_chkCle.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        public static bool EditeChamp(IChampAlarme champ)
        {
            CFormEditeChampAlarme form = new CFormEditeChampAlarme();
            form.m_champ = champ;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
                bResult = true;
            form.Dispose();
            return bResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CFormEditeChampAlarme_Load(object sender, EventArgs e)
        {
            m_txtNomChamp.Text = m_champ.NomChamp;
            foreach (ETypeChampBasique typeChamp in Enum.GetValues(typeof(ETypeChampBasique)))
                m_cmbType.Items.Add ( typeChamp );
            m_cmbType.SelectedItem = m_champ.TypeDonnee;
            m_chkCle.Checked = m_champ.IsKey;
        }
    }
}
