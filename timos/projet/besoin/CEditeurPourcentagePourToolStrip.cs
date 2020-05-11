using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace timos.projet.besoin
{
    public partial class CEditeurPourcentagePourToolStrip : UserControl
    {
        public CEditeurPourcentagePourToolStrip()
        {
            InitializeComponent();
        }

        public event EventHandler OnValideSaisie;
        private void m_btnValide_Click(object sender, EventArgs e)
        {
            ValideSaisie();
        }

        private void ValideSaisie()
        {
            if (m_txtId.IntValue != null && OnValideSaisie != null)
            {
                OnValideSaisie(this, null);
            }
        }

        public int? IdDemande
        {
            get
            {
                return m_txtId.IntValue;
            }
        }

        private void m_txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValideSaisie();
            }
        }

        public double? Value
        {
            get
            {
                if (m_txtId.DoubleValue != null)
                    return m_txtId.DoubleValue;
                return null;
            }
            set
            {
                m_txtId.DoubleValue = value;
            }
        }

        private void m_picValider_Click(object sender, EventArgs e)
        {
            ValideSaisie();
        }
    }


    public class CToolStripPourcentage : ToolStripControlHost
    {
        public CToolStripPourcentage(double fValeur)
            : base(new CEditeurPourcentagePourToolStrip())
        {
            Control.Size = new Size(120, 30);
            Size = Control.Size;
            ((CEditeurPourcentagePourToolStrip)Control).OnValideSaisie += new EventHandler(CToolStripTextBox_OnValideSaisie);
            ((CEditeurPourcentagePourToolStrip)Control).Value = fValeur;

        }

        void CToolStripTextBox_OnValideSaisie(object sender, EventArgs e)
        {
            if (OnValideSaisie != null)
                OnValideSaisie(this, null);
        }


        public override Size GetPreferredSize(Size constrainingSize)
        {
            return new Size(100, 20);
        }

        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(276, 43);
            }
        }

        
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
        }

      
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
        }

        public event EventHandler OnValideSaisie;

       
        public double ? Value
        {
            get
            {
                return ((CEditeurPourcentagePourToolStrip)Control).Value;
            }
        }
    }
}
