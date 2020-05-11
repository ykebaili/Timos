using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using timos.FinalCustomer;

namespace timos
{
    public partial class CFormSplash : Form
    {
        public CFormSplash()
        {
            InitializeComponent();
            string strSplash = CFinalCustomerInformations.GetSplashImageFile();
            if ( strSplash != null )
            {
                try
                {
                    Image img = Image.FromFile(strSplash);
                    if (img != null)
                        m_imageFond.Image = img;
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
