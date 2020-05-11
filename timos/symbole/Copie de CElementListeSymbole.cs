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
    public enum EApparenceElementListeSymbole
    {
        Icone,
        Texte,
        Icone_Texte,
        Texte_Icone,
    }

    public class CElementListeSymbole : System.Windows.Forms.Control
    {

        #region Graphique
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

        #region Effet Survol
        private bool m_bEffetCouleurEnter = false;
        private bool m_bEffetCouleurAuSurvol = true;
        public bool EffetCouleurAuSurvol
        {
            get
            {
                return m_bEffetCouleurAuSurvol;
            }
            set
            {
                m_bEffetCouleurAuSurvol = value;
            }
        }


        private int m_nbImgEffet = 1;
        private Dictionary<int, Bitmap> m_effetFondu;
        private void InitEffetFondu()
        {
            if (m_effetFondu != null)
                return;
            m_effetFondu = new Dictionary<int, Bitmap>();
            double nPas = (double)1 / (double)m_nbImgEffet;
            for (int n = 0; n < m_nbImgEffet; n++)
            {
                Bitmap img = InvertColors(m_bmpLast, nPas * (n + 1));
                m_effetFondu.Add(n + 1, img);
            }
        }
        private System.Windows.Forms.Timer m_timerSurvol;
        private System.Windows.Forms.Timer TimerSurvol
        {
            get
            {
                if (m_timerSurvol == null)
                {
                    m_timerSurvol = new System.Windows.Forms.Timer();
                    m_timerSurvol.Interval = 1;
                    m_timerSurvol.Tick += new EventHandler(m_timerSurvol_Tick);
                }
                return m_timerSurvol;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="rapport">1 = 100% inversement Couleur</param>
        /// <returns></returns>
        public static Bitmap InvertColors(Bitmap bmp, double rapport)
        {
            if (bmp == null)
                return bmp;
            Bitmap result = new Bitmap(bmp);
            int valeur = (int)(rapport * 255);

            Color cSource;
            Color cDest;
            for (int y = 0; y < result.Height; y++)
                for (int x = 0; x < result.Width; x++)
                {
                    cSource = result.GetPixel(x, y);
                    cDest = Color.FromArgb(
                        Math.Abs(valeur - cSource.R),
                        Math.Abs(valeur - cSource.G),
                        Math.Abs(valeur - cSource.B));
                    result.SetPixel(x, y, cDest);
                }
            return result;
        }
        private bool m_bModeEffetCouleur = false;
        private int m_niv = 0;
        private void m_timerSurvol_Tick(object sender, EventArgs e)
        {
            m_bModeEffetCouleur = true;
            if (m_bEffetCouleurEnter)
            {
                if (m_niv >= m_nbImgEffet)
                {
                    m_niv = m_nbImgEffet;
                    TimerSurvol.Stop();
                    m_bModeEffetCouleur = false;
                }
                else
                {
                    m_niv++;
                    Refresh();
                }
            }
            else
            {
                if (m_niv <= 0)
                {
                    m_niv = 0;
                    TimerSurvol.Stop();
                    m_bModeEffetCouleur = false;
                }
                else
                {
                    m_niv--;
                    Refresh();
                }
            }
        }

        #endregion

        private Font m_police;
        public Font PoliceEcriture
        {
            get
            {
                if (m_police == null)
                    m_police = new Font("Microsoft Sans Serif", 8);
                return m_police;
            }
            set
            {
                m_police = value;
            }
        }

        #endregion



        private Point m_ptStartDrag = new Point(0, 0);
        private bool m_bIsDragging = false;
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
            }
        }


        #region Component Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CElementListeSymbole
            // 
            this.MouseLeave += new System.EventHandler(this.CElementListeSymbole_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CElementListeSymbole_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CElementListeSymbole_MouseMove);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CElementListeSymbole_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CElementListeSymbole_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CElementListeSymbole_MouseUp);
            this.MouseEnter += new System.EventHandler(this.CElementListeSymbole_MouseEnter);
            this.ResumeLayout(false);

        }
        #endregion


        public CElementListeSymbole()
        {
            InitializeComponent();
        }

        private Size m_oldSize;
        private Bitmap m_bmpLast;
        private void CElementListeSymbole_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmpToShow = null;
            if (m_bmpLast == null && e.ClipRectangle != null && e.ClipRectangle.Width > 0 && e.ClipRectangle.Height > 0)
            {
                m_bmpLast = new Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height);
                Graphics g = Graphics.FromImage(m_bmpLast);

                Rectangle rect = e.ClipRectangle;// new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);

                g.FillRectangle(SystemBrushes.Control, rect);
                //if (m_bMouseIn)
                //{
                //    g.DrawRectangle(SystemPens.ControlDark, rect);
                //    g.DrawLine(SystemPens.ControlLight, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                //    g.DrawLine(SystemPens.ControlLight, rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Top);
                //}

                object[] attribs = TypeAssocie.GetCustomAttributes(typeof(WndNameAttribute), false);
                string strNom = TypeAssocie.Name;
                if (attribs.Length > 0)
                    strNom = ((WndNameAttribute)attribs[0]).Name;
                SizeF szNom = g.MeasureString(strNom, Font);

                if (Apparence != EApparenceElementListeSymbole.Icone)
                {
                    if (Apparence == EApparenceElementListeSymbole.Texte
                        || Apparence == EApparenceElementListeSymbole.Texte_Icone
                        || Image == null)
                        g.DrawString(strNom, PoliceEcriture, Brushes.Black, 5, rect.Top + rect.Height / 2 - szNom.Height / 2);
                    else
                        g.DrawString(strNom, PoliceEcriture, Brushes.Black, 10 + Image.Width, rect.Top + rect.Height / 2 - szNom.Height / 2);
                }
                if (Apparence != EApparenceElementListeSymbole.Texte && Image != null)
                {
                    if (Apparence == EApparenceElementListeSymbole.Icone_Texte
                        || Apparence == EApparenceElementListeSymbole.Icone)
                    {
                        g.DrawImageUnscaled(Image, new Point(5, rect.Top + rect.Height / 2 - Image.Height / 2));
                    }
                    else
                    {
                        g.DrawImageUnscaled(Image, new Point((10 + (int)szNom.Width), rect.Top + rect.Height / 2 - Image.Height / 2));
                    }
                }
            }
            bmpToShow = m_bmpLast;
            if (m_bModeEffetCouleur)
            {
                if (m_niv == 0)
                    bmpToShow = m_bmpLast;
                else
                {
                    while (m_effetFondu.Count < m_nbImgEffet)
                    {
                    }
                    bmpToShow = m_effetFondu[m_niv];
                }
            }

            if (bmpToShow != null)
                e.Graphics.DrawImageUnscaled(bmpToShow, new Point(0, 0));

            ThreadStart th = new ThreadStart(InitEffetFondu);
            Thread t = new Thread(th);
            t.Start();
            m_oldSize = e.ClipRectangle.Size;
        }

        private void CElementListeSymbole_MouseEnter(object sender, System.EventArgs e)
        {
            Refresh();
            if (EffetCouleurAuSurvol)
            {
                m_bEffetCouleurEnter = true;
                TimerSurvol.Start();
            }
        }

        private void CElementListeSymbole_MouseLeave(object sender, System.EventArgs e)
        {
            Refresh();
            if (EffetCouleurAuSurvol && !m_bIsDragging)
            {
                m_bEffetCouleurEnter = false;
                TimerSurvol.Start();
            }
        }
        private bool m_bDataDraggingCreated = false;
        private void CElementListeSymbole_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_bIsDragging && !m_bDataDraggingCreated)
            {
                if (Math.Abs(m_ptStartDrag.X - e.X) > 3 &&
                    Math.Abs(m_ptStartDrag.Y - e.Y) > 3)
                {
                    CDonneeDragDropObjetGraphique donnee = new CDonneeDragDropObjetGraphique((C2iSymbole)Activator.CreateInstance(TypeAssocie), new Point(0, 0));
                    //					CDonneeDragDropControl donnee = new CDonneeDragDropControl((C2iSymbole)Activator.CreateInstance(TypeAssocie));
                    DoDragDrop(donnee, System.Windows.Forms.DragDropEffects.All);

                    m_bDataDraggingCreated = true;
                }
            }
        }

        private void CElementListeSymbole_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_bIsDragging = true;
            m_ptStartDrag = new Point(e.X, e.Y);
        }

        private void CElementListeSymbole_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EndDrag(e.Location);
        }

        private void EndDrag(Point pt)
        {
            if (m_bIsDragging && !ClientRectangle.Contains(pt))
            {
                m_bModeEffetCouleur = false;
                Refresh();
            }
            m_bIsDragging = false;
            m_bDataDraggingCreated = false;

        }
        public void CElementListeSymbole_DragDrop(object sender, DragEventArgs e)
        {
            EndDrag(new Point(e.X, e.Y));
        }
    }
}
