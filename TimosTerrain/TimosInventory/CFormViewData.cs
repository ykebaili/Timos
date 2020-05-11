using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimosInventory
{
    public partial class CFormViewData : Form
    {
        public CFormViewData()
        {
            InitializeComponent();
        }

        public static void ViewData(DataSet ds)
        {
            CFormViewData form = new CFormViewData();
            form.m_grid.DataSource = ds;
            form.m_grid.Refresh();
            form.ShowDialog();
            form.Dispose();
        }

    }
}
