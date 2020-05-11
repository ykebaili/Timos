using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using sc2i.drawing;
using timos.data;


namespace timos
{
    public partial class CControlDessinSymbole : UserControl
    {
        public CControlDessinSymbole()
        {
            InitializeComponent();
        }

        private C2iSymbole m_symbole;


        public void InitSymbole(C2iSymbole symbole)
        {
            m_symbole = symbole;

        }
        private void CControlDessinSymbole_Paint(object sender, PaintEventArgs e)
        {

           
             Graphics g = e.Graphics;

            if (m_symbole !=null)
            {
             //   float fScale = (float)(((double)Math.Min(this.Size.Height,this.Size.Width)) /((double)Math.Min(m_symbole.Size.Height,m_symbole.Size.Width)));


                float fScale;

                if (this.Size.Height > this.Size.Width)
                    fScale = (float)((double)this.Size.Width / (double)m_symbole.Size.Width);
                else
                    fScale = (float)((double)this.Size.Height / (double)m_symbole.Size.Height);


                if (fScale < 1)
                {
                    Matrix mat = new Matrix(fScale, 0, 0, fScale, 0, 0);
                    g.Transform = mat;
                }
                else
                {
                    float depX = (float)(((double)this.Size.Width-(double)m_symbole.Size.Width)/2.0);
                    float depY = (float)(((double)this.Size.Height - (double)m_symbole.Size.Height) / 2.0);

                    Matrix mat = new Matrix(1, 0, 0, 1, depX, depY);
                    g.Transform = mat;
                }
                 CContextDessinObjetGraphique ctg = new CContextDessinObjetGraphique(g);
    
                 m_symbole.Draw(ctg);
            }

        }
    }
}
