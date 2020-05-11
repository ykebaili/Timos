using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data;

namespace timos.interventions.crintervention
{
    public partial class CFormPopupCRTest : Form
    {
        private IElementAOperationsRealisees m_elementEdite = null;


        public CFormPopupCRTest()
        {
            InitializeComponent();
        }

        public static void Edite(IElementAOperationsRealisees elt)
        {
            CFormPopupCRTest frm = new CFormPopupCRTest();
            frm.m_elementEdite = elt;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void CFormPopupCRTest_Load(object sender, EventArgs e)
        {
            m_panelCR.Init(m_elementEdite);
        }
    }
}
