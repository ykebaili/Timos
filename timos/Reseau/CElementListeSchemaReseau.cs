using System;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using sc2i.formulaire;
using sc2i.win32.common;

using timos.data;


namespace timos
{
    public class CElementListeSchemaReseau : System.Windows.Forms.Control
    {
        private string m_strName = "";
        private Image m_bmp;
        public Image Image
        {
            get
            {
                return m_bmp;
            }
            set
            {
                m_bmp = value;
            }
        }



        private EApparenceElementListeSymbole m_apparence = EApparenceElementListeSymbole.Icone_Texte;
        public EApparenceElementListeSymbole Apparence
        {
            get
            {
                return m_apparence;
            }
            set
            {
                m_apparence = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="rapport">1 = 100% inversement Couleur</param>
        /// <returns></returns>
        public static void InvertColors(Bitmap bmp)
        {
            if (bmp == null)
                return;
            Color cSource;
            Color cDest;
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    cSource = bmp.GetPixel(x, y);
                    cDest = Color.FromArgb(
                        Math.Abs(255 - cSource.R),
                        Math.Abs(255 - cSource.G),
                        Math.Abs(255 - cSource.B));
                    bmp.SetPixel(x, y, cDest);
                }
        }

        private Point m_ptStartDrag = new Point(0, 0);
        private Type m_typeAssocie = null;

        public Type TypeAssocie
        {
            get
            {
                return m_typeAssocie;
            }
            set
            {
                m_typeAssocie = value;
                object[] attribs = m_typeAssocie.GetCustomAttributes(typeof(WndNameAttribute), false);
                m_strName = sc2i.common.DynamicClassAttribute.GetNomConvivial(TypeAssocie);
                if (attribs.Length > 0)
                    m_strName = ((WndNameAttribute)attribs[0]).Name;
            }
        }


        #region Component Designer generated code
        /// <summary>
        /// M�thode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette m�thode avec l'�diteur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CElementListeWnd
            // 
            this.MouseLeave += new System.EventHandler(this.CElementListeWnd_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CElementListeWnd_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CElementListeWnd_MouseMove);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CElementListeWnd_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CElementListeWnd_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CElementListeWnd_MouseUp);
            this.MouseEnter += new System.EventHandler(this.CElementListeWnd_MouseEnter);
            this.ResumeLayout(false);

        }
        #endregion


        public CElementListeSchemaReseau()
        {
            InitializeComponent();
        }

        private void CElementListeWnd_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle rct = ClientRectangle;
            Point ptSouris = Cursor.Position;
            ptSouris = PointToClient(ptSouris);
            Bitmap bmpToShow = new Bitmap(rct.Width, rct.Height);
            Graphics g = Graphics.FromImage(bmpToShow);
            Brush br = new SolidBrush(BackColor);
            g.FillRectangle(br, rct);
            br.Dispose();

            SizeF szNom = g.MeasureString(m_strName, Font);

            if (Apparence != EApparenceElementListeSymbole.Icone)
            {
                if (Apparence == EApparenceElementListeSymbole.Texte
                    || Apparence == EApparenceElementListeSymbole.Texte_Icone
                    || Image == null)
                    g.DrawString(m_strName, Font, Brushes.Black, 5, rct.Top + rct.Height / 2 - szNom.Height / 2);
                else
                    g.DrawString(m_strName, Font, Brushes.Black, 10 + Image.Width, rct.Top + rct.Height / 2 - szNom.Height / 2);
            }
            if (Apparence != EApparenceElementListeSymbole.Texte && Image != null)
            {
                if (Apparence == EApparenceElementListeSymbole.Icone_Texte
                    || Apparence == EApparenceElementListeSymbole.Icone)
                {
                    g.DrawImageUnscaled(Image, new Point(5, rct.Top + rct.Height / 2 - Image.Height / 2));
                }
                else
                {
                    g.DrawImageUnscaled(Image, new Point((10 + (int)szNom.Width), rct.Top + rct.Height / 2 - Image.Height / 2));
                }
            }
            if (rct.Contains(ptSouris))
                InvertColors(bmpToShow);
            e.Graphics.DrawImage(bmpToShow, 0, 0);
            g.Dispose();
            bmpToShow.Dispose();
        }

        private void CElementListeWnd_MouseEnter(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void CElementListeWnd_MouseLeave(object sender, System.EventArgs e)
        {
            Refresh();
        }
        private void CElementListeWnd_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Math.Abs(m_ptStartDrag.X - e.X) > 3 &&
                    Math.Abs(m_ptStartDrag.Y - e.Y) > 3)
                {
                    CDonneeDragDropObjetGraphique donnee = new CDonneeDragDropObjetGraphique(GetType().ToString(), (C2iObjetDeSchema)Activator.CreateInstance(TypeAssocie), new Point(0, 0));
                    DoDragDrop(donnee, System.Windows.Forms.DragDropEffects.All);
                    Refresh();
                }
            }
        }

        private void CElementListeWnd_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_ptStartDrag = new Point(e.X, e.Y);
        }

        private void CElementListeWnd_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public void CElementListeWnd_DragDrop(object sender, DragEventArgs e)
        {
        }

        public string TypeName
        {
            get
            {
                return m_strName;
            }
        }
    }
}
