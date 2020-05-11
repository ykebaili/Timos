using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
    public partial class FrmPrompt : Form
    {
        public FrmPrompt()
        {
            InitializeComponent();
        }

        public string Value {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string Description {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}