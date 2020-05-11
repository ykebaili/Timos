using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimosInventory
{
    public class CListViewTablette : ListView
    {
        private ColumnHeader m_colonne1;
        private Color m_itemsColor = Color.White;
    
        public CListViewTablette()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            this.m_colonne1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // CListViewTablette
            // 
            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonne1});
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.OwnerDraw = true;
            this.View = System.Windows.Forms.View.Details;
            this.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.CListViewTablette_DrawItem);
            this.SizeChanged += new System.EventHandler(this.CListViewTablette_SizeChanged);
            this.ResumeLayout(false);

        }

        public Color ItemsColor
        {
            get
            {
                return m_itemsColor;
            }
            set
            {
                m_itemsColor = value;
            }
        }

        private void CListViewTablette_SizeChanged(object sender, EventArgs e)
        {
            m_colonne1.Width = ClientSize.Width - 1;
        }

        private Color Assombrir(Color color, int nPct)
        {
            byte nR = (byte)Math.Max(color.R - color.R * nPct / 100, 0);
            byte nG = (byte)Math.Max(color.G - color.G * nPct / 100, 0);
            byte nB = (byte)Math.Max(color.B - color.B * nPct / 100, 0);
            return Color.FromArgb(color.A, nR, nG, nB);
        }

        private void CListViewTablette_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Rectangle rctText = e.Bounds;
            Color c = e.Item.BackColor;
            if (c == BackColor)
                c = m_itemsColor;
            Brush br = new LinearGradientBrush(
                rctText, 
                m_itemsColor,
                Assombrir(c, 30),
                90.0f );
            e.Graphics.FillRectangle ( br, rctText );
            br.Dispose();
            e.Graphics.DrawRectangle ( Pens.Black, rctText );               

            float fSizeFont = Font.Size;
            Font ft = new Font(Font.FontFamily, fSizeFont);
            SizeF sz = e.Graphics.MeasureString(e.Item.Text, ft, rctText.Width);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            while ((sz.Width > rctText.Width || sz.Height > rctText.Height) && fSizeFont > 3)
            {
                fSizeFont -= 0.2f;
                ft.Dispose();
                ft = new Font(Font.FontFamily, fSizeFont);
                sz = e.Graphics.MeasureString(e.Item.Text, ft, rctText.Width, sf);
            }
            br = new SolidBrush(e.Item.ForeColor);
            e.Graphics.DrawString(e.Item.Text, ft, br, rctText, sf);
            ft.Dispose();
            sf.Dispose();
        }
    }
}
