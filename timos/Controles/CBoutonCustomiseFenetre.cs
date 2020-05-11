using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace timos.Controles
{
    public class CBoutonCustomiseFenetre : PictureBox
    {
        Size m_sizeReduite = new Size(10, 10);

        //---------------------------------------------
        public CBoutonCustomiseFenetre() :
            base()
        {
            Image = timos.Properties.Resources.Picto_note1;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Cursor = Cursors.Hand;
            InitializeComponent();
        }

        //---------------------------------------------
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CBoutonCustomiseFenetre
            // 
            this.MouseLeave += new System.EventHandler(this.CBoutonCustomiseFenetre_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.CBoutonCustomiseFenetre_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        //---------------------------------------------
        public void PoseDansControle(Control ctrlParent)
        {
            ctrlParent.Controls.Add(this);
            Size = m_sizeReduite;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Visible = true;
            AjusteDansParent();
        }

        //---------------------------------------------
        private void AjusteDansParent()
        {
            Location = new Point(Parent.Right - Size.Width, 0);
        }

        //---------------------------------------------
        private void CBoutonCustomiseFenetre_MouseEnter(object sender, EventArgs e)
        {
            Size = Image.Size;
            AjusteDansParent();
        }

        //---------------------------------------------
        private void CBoutonCustomiseFenetre_MouseLeave(object sender, EventArgs e)
        {
            Size = m_sizeReduite;
            AjusteDansParent();
        }


    }
}
