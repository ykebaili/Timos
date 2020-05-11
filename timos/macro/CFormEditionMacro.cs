using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic.Macro;

namespace timos.macro
{
    public partial class CFormEditionMacro : Form
    {
        public CFormEditionMacro()
        {
            InitializeComponent();
        }

        public static void EditeMacro(CMacro macro)
        {
            CFormEditionMacro form = new CFormEditionMacro();
            form.m_panelMacro.Init(macro);
            form.ShowDialog();
        }

        private void m_panelMacro_Load(object sender, EventArgs e)
        {
            
        }
    }
}
