using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace futurocom.win32.snmp
{
    public partial class CFormVisuTable : Form
    {
        public CFormVisuTable()
        {
            InitializeComponent();
        }

        public static void ShowTable(
            string strInfoRequete,
            DataTable table)
        {
            CFormVisuTable form = new CFormVisuTable();
            form.Text = strInfoRequete;
            form.m_grid.DataSource = table;
            form.m_lblRequete.Text = strInfoRequete;
            form.Show();
        }
    }
}
